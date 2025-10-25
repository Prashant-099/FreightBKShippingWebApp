// FreightBKShippingWebApp.Model/GridLayout.cs
namespace FreightBKShippingWebApp.Model
{
    public class GridLayout
    {
        public int GridLayoutId { get; set; }
        public string? GridLayoutName { get; set; }
        public string? GridLayoutVoucherType { get; set; }
        public string? GridLayoutVoucherId { get; set; }
        public string? GridLayoutAddedBy { get; set; }
        public string? GridLayoutUpdateBy { get; set; }
        public int GridLayoutCompanyId { get; set; }
        public DateTime? GridLayoutCreated { get; set; }
        public DateTime? GridLayoutUpdated { get; set; }
        public bool GridLayoutDefault { get; set; }
        public string? GridLayoutData { get; set; }
    }

    public class GridLayoutDto
    {
        public int GridLayoutId { get; set; }
        public string? GridLayoutName { get; set; }
        public string? GridLayoutVoucherType { get; set; }
        public string? GridLayoutData { get; set; }
        public bool GridLayoutDefault { get; set; }
    }

    public class SaveGridLayoutRequest
    {
        public string GridLayoutName { get; set; } = string.Empty;
        public string GridLayoutVoucherType { get; set; } = string.Empty;
        public string GridLayoutData { get; set; } = string.Empty;
        public bool GridLayoutDefault { get; set; }
        public string? CompanyId { get; set; }
        public string? UserId { get; set; }
    }

    public class GridColumnLayout
    {
        public string FieldName { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public int DisplayIndex { get; set; }
        public bool Visible { get; set; } = true;
        public int Width { get; set; }
    }
}
