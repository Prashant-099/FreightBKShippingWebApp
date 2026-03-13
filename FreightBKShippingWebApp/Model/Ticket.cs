namespace FreightBKShippingWebApp.Model
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public string TicketNo { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public int StatusId { get; set; }

        public int PriorityId { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UnreadCount { get; set; }
    }

    public class TicketReply
    {
        public int TicketId { get; set; }

        public string MessageText { get; set; } = string.Empty;

        public string SenderType { get; set; } = "User"; // "User" or "Support"

        // ✅ Add this property for timestamp
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Optional: if you want attachments
        public string? AttachmentUrl { get; set; }
    }
}