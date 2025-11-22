namespace FreightBKShippingWebApp.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("sendwpmail")]
    public class SendWpMail
    {
        [Key]
        [Column("sendwpmail_id")]
        public int SendWpMailId { get; set; }

        [Column("sendwpmail_username")]
        [MaxLength(45)]
        public string SendWpMailUserName { get; set; }

        [Column("sendwpmail_wptoken")]
        [MaxLength(255)]
        public string SendWpMailWpToken { get; set; }

        [Column("sendwpmail_wpbalancetoken")]
        [MaxLength(255)]
        public string SendWpMailWpBalanceToken { get; set; }

        [Column("sendwpmail_balancetoken")]
        [MaxLength(255)]
        public string SendWpMailBalanceToken { get; set; }

        [Column("sendwpmail_created")]
        public DateTime? SendWpMailCreated { get; set; }
        [Column("sendwpmail_companyid")]
        public int? SendWpMailCompanyid { get; set; }

        [Column("sendwpmail_updated")]
        public DateTime? SendWpMailUpdated { get; set; }

        [Column("sendwpmail_create_uid")]
        [MaxLength(60)]
        public string SendWpMailCreateUid { get; set; }

        [Column("sendwpmail_edited_uid")]
        [MaxLength(60)]
        public string SendWpMailEditedUid { get; set; }
    }

}

public class SendWpMailConfigDto
{
    public string? EmailFrom { get; set; }
    public string? SmtpServer { get; set; }
    public string? SmtpPort { get; set; }
    public string? EmailUser { get; set; }
    public string? EmailPass { get; set; }
    public bool EnableSsl { get; set; }
}

public class SendEmailRequestDto
{
    public string ToEmail { get; set; } = "";
    public string Subject { get; set; } = "";
    public string Body { get; set; } = "";
    public string? CcEmails { get; set; }

    public string? AttachmentFileName { get; set; }
    public string? AttachmentBase64 { get; set; }
}