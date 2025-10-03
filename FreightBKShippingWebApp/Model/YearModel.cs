using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreightBKShippingWebApp.Model
{
    public class YearModel
    {
        [Key]
        [Column("year_id")]
        public int YearId { get; set; }

        [Column("year_company_id")]

        public int YearCompanyId { get; set; }

        [Column("year_addby_user_id")]

        public string? YearAddByUserId { get; set; } = "1";

        [Column("year_updatedby_user_id")]

        public string? YearUpdatedByUserId { get; set; } = "1";

        [Required]
        [Column("year_name")]
        public string YearName { get; set; }

        [Required]
        [Column("year_datefrom")]
        public DateTime? YearDateFrom { get; set; }

        [Required]
        [Column("year_dateto")]
        public DateTime? YearDateTo { get; set; }

        [Column("year_status")]
        public bool YearStatus { get; set; }

        [Column("year_created")]
        public DateTime YearCreated { get; set; }

        [Column("year_updated")]
        public DateTime YearUpdated { get; set; }

        [Column("year_isdefault")]
        public bool YearIsDefault { get; set; }
    }
}
