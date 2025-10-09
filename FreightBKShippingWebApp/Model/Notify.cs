using FreightBKShippingWebApp.Components.Pages.Company;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreightBKShippingWebApp.Models
{
    [Table("notifies")]
    public class Notify
    {
        [Key]
        [Column("notify_id")]
        public int NotifyId { get; set; }

        [Column("notify_company_id")]
        public int NotifyCompanyId { get; set; }

        [Column("notify_state_id")]
        public int NotifyStateId { get; set; }

        [Column("notify_addedby_user_id")]
        public string NotifyAddedByUserId { get; set; }

        [Column("notify_updatedby_user_id")]
        public string NotifyUpdatedByUserId { get; set; }
        [Required]
        [Column("notify_name")]
        public string NotifyName { get; set; }
        [Required]
        [Column("notify_type")]
        public string NotifyType { get; set; }

        [Column("notify_address1")]
        public string? NotifyAddress1 { get; set; } = string.Empty;

        [Column("notify_address2")]
        public string? NotifyAddress2 { get; set; } = string.Empty;

        [Column("notify_address3")]
        public string? NotifyAddress3 { get; set; } = string.Empty;

        [Column("notify_city")]
        public string? NotifyCity { get; set; } = string.Empty;

        [Column("notify_tel")]
        public string? NotifyTel { get; set; } = string.Empty;

        [Column("notify_email")]
        public string? NotifyEmail { get; set; } = string.Empty;

        [Column("notify_contactno")]
        public string? NotifyContactNo { get; set; } = string.Empty;

        [Column("notify_contactperson")]
        public string? NotifyContactPerson { get; set; } = string.Empty;


        public string? Pan = string.Empty;

        public string? GstNo = string.Empty;


        [Column("notify_gstno")]
        public string? NotifyGstNo
        {
            get => GstNo;
            set
            {
                GstNo = value?.ToUpper() ?? string.Empty;
                NotifyPan = (!string.IsNullOrEmpty(GstNo) && GstNo.Length >= 12)
                    ? GstNo.Substring(2, 10)
                    : string.Empty;
            }
        }

        [Column("notify_pan")]
        public string? NotifyPan
        {
            get => Pan;
            set => Pan = value?.ToUpper();
        }

        [Column("notify_status")]
        public bool NotifyStatus { get; set; }

        [Column("notify_state")]
        public string? NotifyState { get; set; } = string.Empty;

        [Column("notify_pincode")]
        public string? NotifyPincode { get; set; } = string.Empty;

        [Column("notify_statecode")]
        public string? NotifyStateCode { get; set; } = string.Empty;

        [Column("notify_created")]
        public DateTime NotifyCreated { get; set; }

        [Column("notify_updated")]
        public DateTime NotifyUpdated { get; set; }

        [Column("notify_country")]
        public string? NotifyCountry { get; set; } = string.Empty;
    }
}
