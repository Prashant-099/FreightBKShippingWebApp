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

        // ============================================================
        // 🔹 MAIN METHOD → GENERATE PDF BYTES (Reusable Core Logic)
        // ============================================================

        //public async Task<(byte[] pdfBytes, string fileName)> GeneratePdfAsync<T, TDto>(
        //    List<T> items,
        //    Func<T, Task<int>> getReportIdAsync,
        //    Func<T, Task<TDto?>> getDtoAsync,
        //    string fileName = "Report.pdf")
        //    where TDto : class
        //{
        //    if (items == null || !items.Any())
        //        throw new Exception("Select at least one item.");

        //    var reportGroups = await BuildReportGroupsAsync(items, getReportIdAsync);
        //    var allReports = new List<XtraReport>();

        //    foreach (var group in reportGroups)
        //    {
        //        var reportId = group.Key;
        //        var groupItems = group.Value;

        //        if (reportId <= 0)
        //            continue;

        //        var layoutBytes = await _reportDataService
        //            .GetLayoutBytesAsync(reportId);

        //        if (layoutBytes == null || layoutBytes.Length == 0)
        //            continue;

        //        var dtoDict = new Dictionary<T, TDto?>();

        //        foreach (var item in groupItems)
        //        {
        //            dtoDict[item] = await getDtoAsync(item);
        //        }

        //        var report = await _reportService.CreateMergedReportAsync<T, TDto>(
        //            groupItems,
        //            item => dtoDict.TryGetValue(item, out var dto) ? dto : null,
        //            layoutBytes);

        //        if (report != null)
        //            allReports.Add(report);
        //    }

        //    if (!allReports.Any())
        //        throw new Exception("No reports generated.");

        //    var finalReport = MergeReports(allReports);

        //    using var stream = new MemoryStream();
        //    finalReport.ExportToPdf(stream);

        //    return (stream.ToArray(), fileName);
        //}


        public async Task<(byte[] pdfBytes, string fileName)> GeneratePdfAsync<T, TDto>(
    List<T> items,
    Func<T, Task<int>> getReportIdAsync,
    Func<T, Task<TDto?>> getDtoAsync,
    Func<T, string> getDocType,   // 🔹 Added for fallback
    string fileName = "Report.pdf")
    where TDto : class
        {
            if (items == null || !items.Any())
                throw new Exception("Select at least one item.");

            var allReports = new List<XtraReport>();

            foreach (var item in items)
            {
                // 🔹 Step 1: Get ReportId
                var reportId = await getReportIdAsync(item);

                // 🔹 Step 2: If invalid → get default reportId using DocType
                if (reportId <= 0)
                {
                    var docType = getDocType(item);

                    var defaultReportId = await _reportDataService
                        .GetDefaultReportIdByTypeAsync(docType);

                    if (!defaultReportId.HasValue || defaultReportId.Value <= 0)
                        throw new Exception("Report format not found.");

                    reportId = defaultReportId.Value;
                }

                // 🔹 Step 3: Get Layout
                var layoutBytes = await _reportDataService
                    .GetLayoutBytesAsync(reportId);

                if (layoutBytes == null || layoutBytes.Length == 0)
                    throw new Exception("Report format not found.");

                // 🔹 Step 4: Get DTO
                var dto = await getDtoAsync(item);

                // 🔹 Step 5: Create Report
                var report = await _reportService.CreateMergedReportAsync<T, TDto>(
                    new List<T> { item },
                    _ => dto,
                    layoutBytes);

                if (report != null)
                    allReports.Add(report);
            }

            if (!allReports.Any())
                throw new Exception("No reports generated.");

            // 🔹 Step 6: Merge All Reports
            var finalReport = MergeReports(allReports);

            using var stream = new MemoryStream();
            finalReport.ExportToPdf(stream);

            return (stream.ToArray(), fileName);
        }


        // ============================================================
        // 🔹 DOWNLOAD PDF
        // ============================================================

        public async Task DownloadAsync<T, TDto>(
            List<T> items,
            Func<T, Task<int>> getReportIdAsync,
            Func<T, Task<TDto?>> getDtoAsync,
            Func<T, string> getDocType,   // 🔹 Added
            string fileName = "Report.pdf")
            where TDto : class
        {
            if (items == null || !items.Any())
            {
                _toast.Warning("Select at least one item.");
                return;
            }

            try
            {
                _loading.Show("Building PDF...");

                var (pdfBytes, finalFileName) =
                    await GeneratePdfAsync(
                        items,
                        getReportIdAsync,
                        getDtoAsync,
                        getDocType,      // 🔹 Pass here
                        fileName);

                using var stream = new MemoryStream(pdfBytes);
                using var streamRef = new DotNetStreamReference(stream);

                await _js.InvokeVoidAsync(
                    "downloadPdfFromStream",
                    finalFileName,
                    streamRef);

                _toast.Success("PDF downloaded successfully.");
            }
            catch (Exception ex)
            {
                _toast.Error(ex.Message);
            }
            finally
            {
                _loading.Hide();
            }
        }


        // ============================================================
        // 🔹 INTERNAL → GROUP BY REPORT ID
        // ============================================================

        private async Task<Dictionary<int, List<T>>> BuildReportGroupsAsync<T>(
            List<T> items,
            Func<T, Task<int>> getReportIdAsync)
        {
            var result = new Dictionary<int, List<T>>();

            foreach (var item in items)
            {
                var reportId = await getReportIdAsync(item);

                if (reportId <= 0)
                    continue;

                if (!result.ContainsKey(reportId))
                    result[reportId] = new List<T>();

                result[reportId].Add(item);
            }

            return result;
        }

        // ============================================================
        // 🔹 MERGE MULTIPLE REPORTS
        // ============================================================

        private XtraReport MergeReports(List<XtraReport> reports)
        {
            if (reports.Count == 1)
                return reports.First();

            var combinedReport = new XtraReport();

            foreach (var report in reports)
            {
                if (report.Pages.Count == 0)
                    report.CreateDocument();

                combinedReport.Pages.AddRange(report.Pages);
            }

            return combinedReport;
        }

        public async Task PreviewAsync<T, TDto>(
    List<T> items,
    Func<T, Task<int>> getReportIdAsync,
    Func<T, Task<TDto?>> getDtoAsync,
    Func<T, string> getDocType,   // 🔹 Added
    string fileName = "Report.pdf")
    where TDto : class
        {
            if (items == null || !items.Any())
            {
                _toast.Warning("Select at least one item.");
                return;
            }

            try
            {
                _loading.Show("Generating preview...");

                var (pdfBytes, finalFileName) =
                    await GeneratePdfAsync(
                        items,
                        getReportIdAsync,
                        getDtoAsync,
                        getDocType,   // 🔹 Pass here
                        fileName);

                using var stream = new MemoryStream(pdfBytes);
                using var streamRef = new DotNetStreamReference(stream);

                await _js.InvokeVoidAsync(
                    "previewPdfFromStream",
                    finalFileName,
                    streamRef);
            }
            catch (Exception ex)
            {
                _toast.Error(ex.Message);
            }
            finally
            {
                _loading.Hide();
            }
        }


    }


}
