using DevExpress.ReportServer.ServiceModel.DataContracts;
using DevExpress.XtraReports.UI;
using FreightBKShippingWebApp.Model;
using System.Text;

namespace FreightBKShippingWebApp.Services
{
    public class ReportDataService
    {
        private readonly ApiClient _apiClient;

        public XtraReport? CurrentReport { get; private set; }

        public ReportDataService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public void SetReport(XtraReport report)
        {
            CurrentReport = report;
            Console.WriteLine("✅ Report has been set in ReportDataService.");
            Console.WriteLine($"📄 Report Type: {report?.GetType().Name}");
            Console.WriteLine($"📋 Report DataSource: {report?.DataSource}");
        }

        public XtraReport? GetReport() => CurrentReport;

        // --- Shared API response shape for pagination ---
        private sealed class PaginationDto
        {
            public int Page { get; set; }
            public int PageSize { get; set; }
            public int TotalRecords { get; set; }
            public int TotalPages { get; set; }
        }
        private sealed class ApiListResponse<T>
        {
            public PaginationDto? Pagination { get; set; }
            public List<T>? Data { get; set; }
        }

        // 🔹 Get paged list
        public async Task<List<ReportData>> GetAllAsync(int page = 1, int pageSize = 1000)
        {
            try
            {
                var response = await _apiClient.GetFromJsonAsync<ApiListResponse<ReportData>>(
                    $"api/ReportData?page={page}&pageSize={pageSize}");

                return response?.Data ?? new List<ReportData>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading ReportData: {ex.Message}");
                return new();
            }
        }

        // 🔹 Create
        public async Task<int?> CreateAsync(ReportData reportData)
        {
            try
            {
                var result = await _apiClient.PostAsync<Dictionary<string, object>, ReportData>(
                    "api/ReportData", reportData);

                if (result != null && result.TryGetValue("reportDataId", out var idObj)
                    && int.TryParse(idObj.ToString(), out var newId))
                {
                    reportData.ReportDataId = newId;
                    return newId;
                }

                Console.WriteLine("❌ API did not return reportDataId.");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating ReportData: {ex.Message}");
                return null;
            }

        }

        public async Task<bool> UpdateAsync(ReportData reportData)
        {
            if (reportData.ReportDataId <= 0)
            {
                Console.WriteLine("❌ Update failed: Invalid ReportDataId");
                return false;
            }

            try
            {
                var result = await _apiClient.PutAsync<object, ReportData>(
                    $"api/ReportData/{reportData.ReportDataId}", reportData);

                return result is not null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating ReportData: {ex.Message}");
                return false;
            }

        }

        // 🔹 Delete
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _apiClient.DeleteAsync<bool>($"api/ReportData/{id}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting ReportData: {ex.Message}");
                return false;
            }

        }

        // 🔹 Get raw layout (bytes) by numeric id
        public async Task<byte[]?> GetLayoutBytesAsync(int layoutId)
        {
            return await _apiClient.SafeGetBytesAsync($"api/ReportData/layout/{layoutId}");
        }

        // 🔹 Build XtraReport from layout
        public async Task<XtraReport?> GetReportFromApiAsync(int id)
        {
            try
            {
                var bytes = await _apiClient.SafeGetBytesAsync($"api/ReportData/layout/{id}");
                if (bytes == null || bytes.Length == 0)
                    return null;

                using var ms = new MemoryStream(bytes);
                var rpt = new XtraReport();
                rpt.LoadLayout(ms);
                return rpt;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading report layout from API: {ex.Message}");
                return null;
            }
        }

        // =========================
        // 🔧 REPORT DESIGNER
        // =========================

        // Get all designer report names
        public async Task<Dictionary<string, string>> GetDesignerReportsListAsync()
        {
            return await _apiClient.GetFromJsonAsync<Dictionary<string, string>>("api/ReportData/designer/reports")
                   ?? new Dictionary<string, string>();
        }

        // Get report XML by name
        public async Task<string?> GetDesignerReportXmlAsync(string reportName)
        {
            try
            {
                var bytes = await _apiClient.SafeGetBytesAsync($"api/ReportData/designer/reports/{reportName}");
                return (bytes == null || bytes.Length == 0) ? null : Encoding.UTF8.GetString(bytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error getting designer report '{reportName}': {ex.Message}");
                return null;
            }
        }

        // Save report XML by name
        public async Task<bool> SaveDesignerReportXmlAsync(string reportName, string layoutXml)
        {
            if (string.IsNullOrWhiteSpace(reportName))
            {
                Console.WriteLine("❌ Report name is required.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(layoutXml))
            {
                Console.WriteLine("❌ Layout XML is empty.");
                return false;
            }

            var content = new StringContent(layoutXml, Encoding.UTF8, "application/xml");
            try
            {
                // 👉 Better: use PUT for update
                var result = await _apiClient.PutAsync<object>(
                    $"api/ReportData/designer/reports/{reportName}", content);

                return result is not null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error saving designer report '{reportName}': {ex.Message}");
                return false;
            }
        }

        // Delete by name
        public async Task<bool> DeleteDesignerReportAsync(string reportName)
        {
            try
            {
                var result = await _apiClient.DeleteAsync<object>($"api/ReportData/designer/reports/{reportName}");
                return result is not null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting designer report '{reportName}': {ex.Message}");
                return false;
            }
        }


    }
}
