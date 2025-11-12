using FreightBKShippingWebApp.Model;

public static class PdfExportConfig
{
    public static PdfExtractionConfig GetExportConfig()
    {
        var config = new PdfExtractionConfig { ConfigName = "Export" };

        // Different fields for export
        config.FieldMappings.AddRange(new[]
        {
            new PdfFieldMapping { FieldName = "Shipping No", Pattern = @"Shipping No\s*:\s*([A-Z0-9]+)", Category = "Shipping", MapTo = "ShippingNo" },
            new PdfFieldMapping { FieldName = "Consignee", Pattern = @"Consignee\s*:\s*([^\n]+)", Category = "Parties", MapTo = "Consignee" },
            new PdfFieldMapping { FieldName = "Notification Party", Pattern = @"Notify\s*:\s*([^\n]+)", Category = "Parties", MapTo = "NotifyParty" },
            // ... export specific fields
        });

        //config.CustomExtractors["Export CHA"] = ExtractExportCha;
        //config.CustomExtractors["Export Containers"] = ExtractExportContainers;

        return config;
    }

    private static string ExtractExportCha(string fullText) => ""; // Custom logic
    private static string ExtractExportContainers(string fullText) => ""; // Custom logic
}
