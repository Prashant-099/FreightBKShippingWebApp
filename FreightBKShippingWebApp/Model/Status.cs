using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreightBKShippingWebApp.Model
{
    [Table("Status")]
    public class Status
    {
        [Key]
        [Column("Status_id")]
        public int StatusId { get; set; }

        [Column("Status_name")]
        [Required]
        public string StatusName { get; set; }

        [Column("Status_created")]
        public DateTime StatusCreated { get; set; }

        [Column("Status_updated")]
        public DateTime StatusUpdated { get; set; }

        [Column("Status_createdbyuser")]
        public string? StatusCreatedByUser { get; set; } = string.Empty;

        [Column("Status_updatedbyuser")]
        public string? StatusUpdatedByUser { get; set; } = string.Empty;
    }
}
