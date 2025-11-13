namespace FreightBKShippingWebApp.Model
{
    public class PdfFieldMapping
    {
        public string FieldName { get; set; }
        public string Pattern { get; set; }
        public int GroupIndex { get; set; } = 1;
        public string Category { get; set; }
        public string MapTo { get; set; }
    }

    public class PdfExtractionConfig
    {
        public string ConfigName { get; set; }
        public List<PdfFieldMapping> FieldMappings { get; set; } = new();
        public Dictionary<string, Func<string, Dictionary<string, string>, Task>> CustomExtractors { get; set; } = new();
    }

}
