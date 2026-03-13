namespace FreightBKShipping.DTOs
{
    public class TicketListDto
    {
        public int TicketId { get; set; }

        public string TicketNo { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;

        public int StatusId { get; set; }

        public int PriorityId { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UnreadCount { get; set; }
    }
}