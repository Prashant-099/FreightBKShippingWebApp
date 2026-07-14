using DevExpress.XtraReports.UI;
using System.Net.Http;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using FreightBKShippingWebApp.Services;
using FreightBKShippingWebApp.Model;
using FreightBKShippingWebApp.Models;

public  class ReportsFactory
{
    public  readonly Dictionary<string, XtraReport> Reports = new()
    {
        ["EmptyReport"] = new XtraReport()
    };
    private readonly ReportDataService _reportService;


public ReportsFactory(ReportDataService reportService )
{
    _reportService = reportService;
}
    public  ReportData? LoadedMetadata { get; private set; }

    public async Task<XtraReport> GetReport(string encodedReportName, HttpClient httpClient)
    {
        try
        {
            int reportDataId;

            // 🔍 Try to parse directly as ID
            if (int.TryParse(encodedReportName, out reportDataId))
            {
                Console.WriteLine("✔ Detected raw ID format.");
            }
            else
            {
                Console.WriteLine("✔ Detected Base64 JSON format. Decoding...");

                // 🧩 Decode and deserialize metadata
                string decodedJson = Encoding.UTF8.GetString(Convert.FromBase64String(encodedReportName));
                var baseMetadata = JsonSerializer.Deserialize<ReportData>(decodedJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (baseMetadata == null || baseMetadata.ReportDataId <= 0)
                    throw new Exception("Invalid ReportDataId in decoded metadata.");

                reportDataId = baseMetadata.ReportDataId;
            }

            // 🌐 Now fetch the report layout by ID
            string url = await _reportService.GetDesignerReportXmlAsync(reportDataId.ToString());
            

            var fullMetadata = JsonSerializer.Deserialize<ReportData>(url, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (fullMetadata == null || string.IsNullOrWhiteSpace(fullMetadata.LayoutData))
                throw new Exception("Report layout missing in API response.");

            LoadedMetadata = fullMetadata;

            // 🧼 Sanitize layout
            string rawXml = fullMetadata.LayoutData.Trim();
            int xmlStart = rawXml.IndexOf("<?xml", StringComparison.OrdinalIgnoreCase);
            if (xmlStart > 0)
                rawXml = rawXml.Substring(xmlStart);

            byte[] xmlBytes = Encoding.UTF8.GetBytes(rawXml);
            using MemoryStream reportStream = new(xmlBytes);
            
            return XtraReport.FromXmlStream(reportStream);
            
        }
        catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            Console.WriteLine($"Report not found. Returning EmptyReport.");
            return Reports["EmptyReport"];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading report: {ex.Message}");
            return Reports["EmptyReport"];
        }
       
    }




    //public async  Task SaveReport(string reportName, XtraReport report, HttpClient httpClient)
    //{
    //    try
    //    {
    //        string url = $"https://localhost:7208/api/Report/layout/{reportName}";

    //        using MemoryStream reportStream = new();
    //        report.SaveLayoutToXml(reportStream);
    //        reportStream.Position = 0;

    //        using StreamReader reader = new(reportStream, Encoding.UTF8);
    //        string xmlContent = await reader.ReadToEndAsync();

    //        // Manually wrap in JSON string
    //        string jsonWrapped = System.Text.Json.JsonSerializer.Serialize(xmlContent);
    //        var content = new StringContent(jsonWrapped, Encoding.UTF8, "application/json");
    //        HttpResponseMessage response = await httpClient.PutAsync(url, content);

    //        response.EnsureSuccessStatusCode();
    //        Console.WriteLine($"Report '{reportName}' saved successfully.");
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error saving report '{reportName}': {ex.Message}");
    //    }
    //}



}

//using DevExpress.XtraReports.UI;
//using System;
//using System.IO;
//using System.Text;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Collections.Generic;

//public class ReportsFactory
//{
//    private readonly ReportService _reportService;
//    private readonly HttpClient _httpClient;

//    public static readonly Dictionary<string, XtraReport> Reports = new()
//    {
//        ["EmptyReport"] = new XtraReport()
//    };

//    // Constructor for DI
//    public ReportsFactory(ReportService reportService, HttpClient httpClient)
//    {
//        _reportService = reportService;
//        _httpClient = httpClient;
//    }

//    // 🧾 Load Report
//    public async Task<XtraReport> GetReportAsync(string reportName)
//    {
//        try
//        {
//            // You can replace this with your own logic to resolve report ID from name
//            string xml = await _reportService.GetReportLayoutXmlAsync(reportName);
//            Console.WriteLine($"Report '{reportName}' loaded successfully.");

//            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml);
//            using MemoryStream reportStream = new(xmlBytes);
//            return XtraReport.FromXmlStream(reportStream);
//        }
//        catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
//        {
//            Console.WriteLine($"Report '{reportName}' not found. Returning EmptyReport.");
//            return Reports["EmptyReport"];
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Error loading report '{reportName}': {ex.Message}");
//            return Reports["EmptyReport"];
//        }
//    }

//    // 💾 Save Report
//    public async Task SaveReportAsync(string reportName, XtraReport report)
//    {
//        try
//        {
//            string url = $"https://localhost:7208/api/Report/layout/{reportName}";

//            using MemoryStream reportStream = new();
//            report.SaveLayoutToXml(reportStream);
//            reportStream.Position = 0;

//            using StreamReader reader = new(reportStream, Encoding.UTF8);
//            string xmlContent = await reader.ReadToEndAsync();

//            // Serialize as a JSON string
//            string jsonWrapped = System.Text.Json.JsonSerializer.Serialize(xmlContent);
//            var content = new StringContent(jsonWrapped, Encoding.UTF8, "application/json");

//            HttpResponseMessage response = await _httpClient.PutAsync(url, content);
//            response.EnsureSuccessStatusCode();

//            Console.WriteLine($"Report '{reportName}' saved successfully.");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Error saving report '{reportName}': {ex.Message}");
//        }
//    }
//}
