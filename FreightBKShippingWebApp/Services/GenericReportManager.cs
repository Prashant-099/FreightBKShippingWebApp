using DevExpress.XtraReports.UI;
using Microsoft.JSInterop;

namespace FreightBKShippingWebApp.Services
{
    public class GenericReportManager : IGenericReportManager
    {
        private readonly ReportService _reportService;
        private readonly ReportDataService _reportDataService;
        private readonly IJSRuntime _js;
        private readonly ToasteService _toast;
        private readonly LoadingService _loading;

        public GenericReportManager(
            ReportService reportService,
            ReportDataService reportDataService,
            IJSRuntime js,
            ToasteService toast,
            LoadingService loading)
        {
            _reportService = reportService;
            _reportDataService = reportDataService;
            _js = js;
            _toast = toast;
            _loading = loading;
        }

        public async Task PrintAsync<T, TDto>(
            List<T> items,
            Func<T, Task<int>> getReportIdAsync,
            Func<T, Task<TDto?>> getDtoAsync)
            where TDto : class
        {
            if (items == null || !items.Any())
            {
                _toast.Warning("Select at least one item.");
                return;
            }

            _loading.Show("Building PDF...");

            try
            {
                // 🔹 Resolve report groups
                var reportGroups = await BuildReportGroupsAsync(items, getReportIdAsync);

                var allReports = new List<XtraReport>();

                foreach (var (reportId, groupItems) in reportGroups)
                {
                    var layoutBytes = await _reportDataService
                        .GetLayoutBytesAsync(reportId);

                    if (layoutBytes == null || layoutBytes.Length == 0)
                    {
                        _toast.Error($"Layout not found for Report ID: {reportId}");
                        continue;
                    }

                    var dtoDict = new Dictionary<T, TDto?>();

                    foreach (var item in groupItems)
                    {
                        dtoDict[item] = await getDtoAsync(item);
                    }

                    await _reportService.CreateMergedReportAsync<T, TDto>(
                        groupItems,
                        item => dtoDict.TryGetValue(item, out var dto) ? dto : null,
                        layoutBytes);

                    if (_reportService.MergedReport != null)
                        allReports.Add(_reportService.MergedReport);
                }

                if (!allReports.Any())
                {
                    _toast.Error("No reports generated.");
                    return;
                }

                await ExportReportsAsync(allReports, "Report.pdf");

                _toast.Success("PDF downloaded successfully.");
            }
            catch (Exception ex)
            {
                _toast.Error($"Failed to generate report: {ex.Message}");
            }
            finally
            {
                _loading.Hide();
            }
        }

        public async Task DownloadAsync<T, TDto>(
            List<T> items,
            Func<T, Task<int>> getReportIdAsync,
            Func<T, Task<TDto?>> getDtoAsync,
            bool sendViaWhatsapp = false)
            where TDto : class
        {
            // For now reuse same logic
            await PrintAsync(items, getReportIdAsync, getDtoAsync);

            // Later you can add:
            // - Blob upload
            // - WhatsApp sending
        }

        private async Task<Dictionary<int, List<T>>> BuildReportGroupsAsync<T>(
            List<T> items,
            Func<T, Task<int>> getReportIdAsync)
        {
            var result = new Dictionary<int, List<T>>();

            foreach (var item in items)
            {
                var reportId = await getReportIdAsync(item);

                if (!result.ContainsKey(reportId))
                    result[reportId] = new List<T>();

                result[reportId].Add(item);
            }

            return result;
        }

        private async Task ExportReportsAsync(
            List<XtraReport> reports,
            string fileName)
        {
            var finalReport = MergeReports(reports);

            using var stream = new MemoryStream();
            finalReport.ExportToPdf(stream);
            stream.Position = 0;

            using var streamRef = new DotNetStreamReference(stream);

            await _js.InvokeVoidAsync(
                "downloadFileFromStream",
                fileName,
                streamRef);
        }

        private XtraReport MergeReports(List<XtraReport> reports)
        {
            if (reports.Count == 1)
                return reports.First();

            var combinedReport = new XtraReport();

            foreach (var report in reports)
            {
                if (report.Pages.Count == 0)
                    report.CreateDocument();

                foreach (DevExpress.XtraPrinting.Page page in report.Pages)
                {
                    combinedReport.Pages.Add(page);
                }
            }

            return combinedReport;
        }
    }
}
