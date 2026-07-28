namespace FreightBKShippingWebApp.Model
{
    public class BulkBillResultItemDto
    {
        public string? BillNoInput { get; set; }
        public bool Success { get; set; }
        public int BillId { get; set; }
        public string? BillNo { get; set; }
        public string? Error { get; set; }
    }

    public class BulkBillImportResultDto
    {
        public int TotalCount { get; set; }
        public int SuccessCount { get; set; }
        public int FailCount { get; set; }
        public List<BulkBillResultItemDto> Items { get; set; } = new();
    }
}
