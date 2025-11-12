using DevExpress.DataProcessing.InMemoryDataProcessor;
using FreightBKShippingWebApp.Model;
using System.Text.RegularExpressions;

public static class PdfImportConfig
{
    private static readonly PdfDetailedExtractorService _extractor;

    public static PdfExtractionConfig GetImportConfig(PdfDetailedExtractorService extractor = null)
    {
        var config = new PdfExtractionConfig { ConfigName = "Import" };
      

        // Basic Fields
        config.FieldMappings.AddRange(new[]
        {
            new PdfFieldMapping { FieldName = "Job No", Pattern = @"Job No & Date\s*:\s*(\d+)\s*&", Category = "Basic Info", MapTo = "JobNo" },
            new PdfFieldMapping { FieldName = "Job Date", Pattern = @"Job No & Date\s*:\s*\d+\s*&\s*(\d{1,2}/\d{1,2}/\d{4})", Category = "Basic Info", MapTo = "JobDate" },
            new PdfFieldMapping { FieldName = "MBL/MAWB", Pattern = @"MBL/MAWB\s*:\s*([A-Z0-9]+)", Category = "B/L Info", MapTo = "BlNo" },
            new PdfFieldMapping { FieldName = "HBL/HAWB", Pattern = @"HBL/HAWB\s*:\s*([A-Z0-9]+)", Category = "B/L Info", MapTo = "HblNo" },
            new PdfFieldMapping { FieldName = "Gross Weight", Pattern = @"Gross Weight\s*:\s*([\d,\.]+)", Category = "Weight/Qty", MapTo = "GrossWt" },
            new PdfFieldMapping { FieldName = "No of Pkgs", Pattern = @"No\.\s*of\s*Pkgs\s*:\s*(\d+)", Category = "Weight/Qty", MapTo = "Qty" },
            new PdfFieldMapping { FieldName = "Invoice No", Pattern = @"Inv\.No\s*:\s*([^\n]+)", Category = "Invoice", MapTo = "InvoiceNo" },
            new PdfFieldMapping { FieldName = "Invoice Date", Pattern = @"Inv\.Date\s*:\s*(\d{1,2}/\d{1,2}/\d{4})", Category = "Invoice", MapTo = "InvoiceDate" },
            new PdfFieldMapping { FieldName = "Invoice Value", Pattern = @"Inv\.Value\s*:\s*([\d,\.]+)", Category = "Invoice", MapTo = "InvoiceValue" },
            new PdfFieldMapping { FieldName = "Port Origin", Pattern = @"Port Origin\s*:\s*([^\n-]+)(?=-)", Category = "Location", MapTo = "PortOrigin" },
            new PdfFieldMapping { FieldName = "Port Shipment", Pattern = @"Port Shipment\s*:\s*([^\n-]+)(?=-)", Category = "Location", MapTo = "PortShipment" },
            new PdfFieldMapping { FieldName = "IGM Number", Pattern = @"IGM NO\s*:\s*(\d+)\s*/", Category = "Customs", MapTo = "IgmNo" },
            new PdfFieldMapping { FieldName = "IGM Date", Pattern = @"IGM NO\s*:\s*\d+\s*/\s*\d+\s*/\s*(\d{1,2}-\d{1,2}-\d{4})", Category = "Customs", MapTo = "IgmDate" },
        });

        // Custom extractors for complex sections
        // These now match the expected signature: Func<string, Dictionary<string, string>, Task>
        if (extractor != null)
        {
            config.CustomExtractors["CHA Details"] = (text, data) => extractor.ExtractChaDetailsAsync(text, data);
            config.CustomExtractors["Importer Details"] = (text, data) => extractor.ExtractImporterDetailsAsync(text, data);
            config.CustomExtractors["Supplier Details"] = (text, data) => extractor.ExtractSupplierDetailsAsync(text, data);
            config.CustomExtractors["Container Details"] = (text, data) => extractor.ExtractContainerDetailsAsync(text, data);
            config.CustomExtractors["Item Details"] = (text, data) => extractor.ExtractItemDetailsAsync(text, data);
            config.CustomExtractors["Duty Details"] = (text, data) => extractor.ExtractDutyDetailsAsync(text, data);
        }

        return config;
    }


  
}