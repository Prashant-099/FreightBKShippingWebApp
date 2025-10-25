using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreightBKShippingWebApp.Model
{
    [Table("gridlayout")]
    public class GridLayout
    {
        [Key]
        [Column("gridlayout_id")]
        public int GridLayoutId { get; set; }

        [Column("gridlayout_name")]
        [StringLength(45)]
        public string? GridLayoutName { get; set; }

        [Column("gridlayout_vouchertype")]
        [StringLength(45)]
        public string? GridLayoutVoucherType { get; set; }

        [Column("gridlayout_voucherid")]
        [StringLength(45)]
        public string? GridLayoutVoucherId { get; set; }

        [Column("gridlayout_added_by")]
        [StringLength(45)]
        public string? GridLayoutAddedBy { get; set; }

        [Column("gridlayout_update_by")]
        [StringLength(45)]
        public string? GridLayoutUpdateBy { get; set; }

        [Column("gridlayout_company_id")]
        [StringLength(45)]
        [Required]
        public string GridLayoutCompanyId { get; set; } = string.Empty;

        [Column("gridlayout_created")]
        public DateTime? GridLayoutCreated { get; set; }

        [Column("gridlayout_updated")]
        public DateTime? GridLayoutUpdated { get; set; }

        [Column("gridlayout_default")]
        public bool GridLayoutDefault { get; set; }

        [Column("gridlayout_data")]
        public string? GridLayoutData { get; set; }
    }

    // Column layout ke liye helper class
    public class GridColumnLayout
    {
        public string FieldName { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public int DisplayIndex { get; set; }
        public bool Visible { get; set; } = true;
        public int Width { get; set; }
    }
}