using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace FreightBKShippingWebApp.Model{
    [Table("ratemaster")]
    public class RateMaster
    {
        [Key]
        [Column("ratemaster_id")]
        public int RateMasterId { get; set; }

        [Required]
        [Column("ratemaster_applicable_dt")]
        public DateTime? RateMasterApplicableDt { get; set; }

        [Required]
        [Column("ratemaster_party_id")]
        public int RateMasterPartyId { get; set; }
        [Required]
        [Column("ratemaster_service_id")]
        public int RateMasterServiceId { get; set; }

        [Column("ratemaster_sale_rate")]
        public decimal? RateMasterSaleRate { get; set; }

        [Column("ratemaster_purchas_rate")]
        public decimal? RateMasterPurchaseRate { get; set; }

        [Column("ratemaster_addedby_user_id")]
        public string? RateMasterAddedByUserId { get; set; }

        [Column("ratemaster_updateby_user_id")]
        public string? RateMasterUpdateByUserId { get; set; }

        [Column("ratemaster_created")]
        public DateTime RateMasterCreated { get; set; } = DateTime.UtcNow;

        [Column("ratemaster_updated")]
        public DateTime? RateMasterUpdated { get; set; }

        [ValidateNever]
        [ForeignKey(nameof(RateMasterPartyId))]
        public Account Party { get; set; }  // Navigation property
        [ValidateNever]
        [ForeignKey(nameof(RateMasterServiceId))]
        public Service Service { get; set; } // Navigation property
        public string? PartyName { get; set; }
        public string? ServiceName { get; set; }

    }
}
