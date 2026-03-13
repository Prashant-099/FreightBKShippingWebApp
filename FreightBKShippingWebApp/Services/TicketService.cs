using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    /// <summary>
    /// Client-side service for the Blazor WebApp.
    /// Calls the API via ApiClient. Does NOT implement ITicketService
    /// (which is server-side only).
    /// </summary>
    public class TicketService : BaseService
    {
        private readonly ApiClient _api;

        public TicketService(
            HttpClient http,
            ApiClient api,
            ITokenProvider tokenProvider) : base(http, tokenProvider)
        {
            _api = api;
        }

        // ─── Get All Tickets ───────────────────────────────────────────────
        public async Task<List<Ticket>> GetAllAsync()
        {
            try
            {
                return await _api.GetFromJsonAsync<List<Ticket>>("api/Tickets")
                       ?? new List<Ticket>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TicketService] GetAllAsync error: {ex.Message}");
                return new List<Ticket>();
            }
        }

        // ─── Get Ticket By Id ──────────────────────────────────────────────
        public async Task<Ticket?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<Ticket>($"api/Tickets/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TicketService] GetByIdAsync({id}) error: {ex.Message}");
                return null;
            }
        }

        // ─── Create Ticket ─────────────────────────────────────────────────
        public async Task<bool> CreateAsync(Ticket ticket)
        {
            try
            {
                return await _api.PostAsync<bool, Ticket>("api/Tickets", ticket);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TicketService] CreateAsync error: {ex.Message}");
                return false;
            }
        }

        // ─── Send Reply ────────────────────────────────────────────────────
        public async Task<bool> ReplyAsync(TicketReply reply)
        {
            try
            {
                return await _api.PostAsync<bool, TicketReply>("api/Tickets/reply", reply);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TicketService] ReplyAsync error: {ex.Message}");
                return false;
            }
        }

        // ─── Get Replies ───────────────────────────────────────────────────
        public async Task<List<TicketReply>> GetRepliesAsync(int ticketId)
        {
            try
            {
                return await _api.GetFromJsonAsync<List<TicketReply>>($"api/Tickets/{ticketId}/replies")
                       ?? new List<TicketReply>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TicketService] GetRepliesAsync({ticketId}) error: {ex.Message}");
                return new List<TicketReply>();
            }
        }

        // ─── Update Ticket (Status + Priority) ────────────────────────────
        public async Task<bool> UpdateAsync(Ticket ticket)
        {
            try
            {
                var dto = new { ticket.StatusId, ticket.PriorityId };
                return await _api.PutAsync<bool, object>($"api/Tickets/{ticket.TicketId}", dto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TicketService] UpdateAsync({ticket.TicketId}) error: {ex.Message}");
                return false;
            }
        }

        // ─── Close Ticket ──────────────────────────────────────────────────
        public async Task<bool> CloseAsync(int ticketId)
        {
            try
            {
                return await _api.PostAsync<bool, object>($"api/Tickets/close/{ticketId}", new { });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TicketService] CloseAsync({ticketId}) error: {ex.Message}");
                return false;
            }
        }
    }
}
