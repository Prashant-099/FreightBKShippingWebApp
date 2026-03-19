//namespace FreightBKShippingWebApp.Model
//{
//    public class Ticket
//    {
//        public int TicketId { get; set; }

//        public string TicketNo { get; set; } = string.Empty;

//        public string Subject { get; set; } = string.Empty;

//        public int StatusId { get; set; }

//        public int PriorityId { get; set; }

//        public DateTime CreatedAt { get; set; }

//        public int UnreadCount { get; set; }
//    }

//    public class TicketReply
//    {
//        public int TicketId { get; set; }

//        public string MessageText { get; set; } = string.Empty;

//        public string SenderType { get; set; } = "User"; // "User" or "Support"

//        // ✅ Add this property for timestamp
//        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

//        // Optional: if you want attachments
//        public string? AttachmentUrl { get; set; }
//    }
//}

namespace FreightBKShippingWebApp.Model
{
    // ─── Request DTOs ──────────────────────────────────────────────────────

    /// <summary>
    /// POST api/Tickets/reply ke liye request body
    /// </summary>
    public class TicketReplyDto
    {
        public int TicketId { get; set; }
        public string MessageText { get; set; } = string.Empty;
        public string SenderType { get; set; } = "User"; // "User" or "Support"
    }

    /// <summary>
    /// PUT api/Tickets/{id} ke liye request body
    /// </summary>
    public class TicketUpdateDto
    {
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
    }

    /// <summary>
    /// Empty body required for PostAsync type inference (anonymous object se error aata tha)
    /// </summary>
    public class EmptyDto { }


    // ─── Response / View Models ────────────────────────────────────────────

    /// <summary>
    /// Ticket list / detail model (client side)
    /// </summary>
    public class Ticket
    {
        public int TicketId { get; set; }
        public string TicketNo { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }

        public int UnreadCount { get; set; } = 0;

        public string MessageText { get; set; } = string.Empty;
    }

    /// <summary>
    /// Single message / reply model (client side)
    /// Server returns this after POST api/Tickets/reply — includes MessageId
    /// </summary>
    public class TicketReply
    {
        public int MessageId { get; set; }   // ✅ Required for SignalR duplicate prevention
        public int TicketId { get; set; }
        public string MessageText { get; set; } = string.Empty;
        public string SenderId { get; set; } = string.Empty;
        public string SenderType { get; set; } = "User"; // "User" or "Support"
        public bool IsReadByUser { get; set; }
        public bool IsReadBySupport { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class TicketMessageDto
    {
        public int MessageId { get; set; }
        public int TicketId { get; set; }
        public string MessageText { get; set; } = "";
        public string SenderType { get; set; } = "";   // "Support" | "User"
        public string SenderName { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
    // ─── Admin DTOs ────────────────────────────────────────────────────────

    /// <summary>
    /// Admin ticket detail view — includes company name, messages list, assignee
    /// </summary>
    //public class SupportTicketAdminDto
    //{
    //    public int TicketId { get; set; }
    //    public string TicketNo { get; set; } = string.Empty;
    //    public string Subject { get; set; } = string.Empty;
    //    public string CompanyName { get; set; } = string.Empty;
    //    public int CompanyId { get; set; }
    //    public int StatusId { get; set; }
    //    public int PriorityId { get; set; }
    //    public string? AssignedToUserId { get; set; }
    //    public string? AssignedToName { get; set; }
    //    public DateTime CreatedAt { get; set; }
    //    public DateTime? UpdatedAt { get; set; }
    //    public DateTime? ClosedAt { get; set; }
    //    public List<TicketReply> Messages { get; set; } = new(); // ✅ TicketReply hi use karo — TicketMessageDto nahi chahiye
    //}

    /// <summary>
    /// Admin user dropdown ke liye
    /// </summary>
    //public class AdminUserDto
    //{
    //    public string UserId { get; set; } = string.Empty;
    //    public string UserName { get; set; } = string.Empty;
    //}
}