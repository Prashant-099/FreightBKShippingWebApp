namespace FreightBKShippingWebApp.Model
{
    public class PrintLrFullDto
    {
        public Lr Lr { get; set; }

        public string? FromLocationName { get; set; }
        public string? ToLocationName { get; set; }

        public string? PartyName { get; set; }
        public string? SupplierName { get; set; }

        public string? ConsigneeName { get; set; }
        public string? ConsigneeFullAddress { get; set; }
        public string? ConsigneeGst { get; set; }
        public string? ConsigneeState { get; set; }

        public string? ConsignorName { get; set; }
        public string? ConsignorFullAddress { get; set; }
        public string? ConsignorGst { get; set; }
        public string? ConsignorState { get; set; }

        public string? ProductName { get; set; }
        public string? JobType { get; set; } // IMPORT / EXPORT
    }

}
