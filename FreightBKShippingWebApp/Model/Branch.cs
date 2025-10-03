using FreightBKShippingWebApp.Components.Pages.Company;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreightBKShippingWebApp.Model
{
    [Table("branches")]
    public class Branch
    {
        [Key]
        [Column("branch_id")]
        public int BranchId { get; set; }

        [Required]
        [Column("branch_name")]
        public string BranchName { get; set; } = string.Empty;


        public string Pan;

        public string GstNo = string.Empty;
        [Column("branch_gstin")]

        public string? BranchGstin
        {
            get => GstNo;
            set
            {
                GstNo = value?.ToUpper() ?? string.Empty;
                Pan = (!string.IsNullOrEmpty(GstNo) && GstNo.Length >= 12)
                    ? GstNo.Substring(2, 10)
                    : string.Empty;
            }
        }

        [Column("branch_pan")]

        public string? BranchPan
        {
            get => Pan;
            set => Pan = value?.ToUpper();
        }

        [Column("branch_printname")]

        public string? BranchPrintName { get; set; }

        [Column("branch_address1")]

        public string? BranchAddress1 { get; set; }

        [Column("branch_address2")]

        public string? BranchAddress2 { get; set; }

        [Column("branch_address3")]

        public string? BranchAddress3 { get; set; }

        [Column("branch_pincode")]

        public string? BranchPincode { get; set; }

        [Required]
        [Column("branch_state_id")]
        public int BranchStateId { get; set; }

        [Column("branch_state_code")]

        public string? BranchStateCode { get; set; } = "String";

        [Column("branch_contact_no")]

        public string? BranchContactNo { get; set; }

        [Column("branch_email")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? BranchEmail { get; set; }

        [Column("branch_city")]

        public string? BranchCity { get; set; }

        [Column("branch_add_by")]

        public string BranchAddedBy { get; set; }

        [Column("branch_update_by")]

        public string? BranchUpdatedBy { get; set; }

        [Column("branch_updated")]
        public DateTime? BranchUpdated { get; set; }

        [Column("branch_created")]
        public DateTime BranchCreated { get; set; } = DateTime.UtcNow;

        [Column("branch_company_id")]
        public int BranchCompanyId { get; set; }

        [Column("branch_state")]

        public string? BranchState { get; set; }

        [Column("branch_country")]

        public string? BranchCountry { get; set; }

        [Column("branch_msmeno")]

        public string? BranchMsmeno { get; set; }

        [Column("branch_status")]
        public bool BranchStatus { get; set; } = true;
    }
}
