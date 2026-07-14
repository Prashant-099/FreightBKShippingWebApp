using DevExpress.XtraReports.Services;
using DevExpress.XtraReports.UI;

public class CustomReportProvider : IReportProviderAsync
{
    private readonly HttpClient _httpClient;
    private readonly ReportsFactory _reportsFactory;

    public CustomReportProvider(HttpClient httpClient, ReportsFactory reportsFactory)
    {
        _httpClient = httpClient;
        _reportsFactory = reportsFactory;
    }
    public Task<XtraReport> GetReportAsync(string id, ReportProviderContext context)
    {
        return _reportsFactory.GetReport(id, _httpClient);
    }

    //public async Task<XtraReport> SaveReportAsync(XtraReport report, ReportProviderContext context)
    //{
    //    // Extract report name from context or assign a default
    //    //string reportName = context.ReportDisplayName ?? "UntitledReport";
    //    string reportName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}";

    //    // Save the report layout using your utility method
    //    await _reportsFactory.SaveReport(reportName, report, _httpClient);

    //    // Return the report back
    //    return report;
    //}
}