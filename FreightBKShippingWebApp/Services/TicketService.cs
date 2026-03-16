using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class TicketService : BaseService
    {
        private readonly ApiClient _api;
        private readonly AuthService _authService;

        public TicketService(
            HttpClient http,
            ApiClient api,
            ITokenProvider tokenProvider,
            AuthService authService) : base(http, tokenProvider)
        {
            _api = api;
            _authService = authService;
        }

        public async Task<string?> GetAuthTokenAsync()
        {
            try
            {
                return await _authService.GetTokenAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TicketService] GetAuthTokenAsync ERROR: {ex.Message}");
                return null;
            }
        }

        public string GetApiBaseUrl()
        {
            try
            {
                return _api.GetBaseUrl();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TicketService] GetApiBaseUrl ERROR: {ex.Message}");
                return "https://localhost:5003";
            }
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
                // ✅ FIX: explicit type arguments — T1=bool, T2=Ticket
                return await _api.PostAsync<bool, Ticket>("api/Tickets", ticket);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TicketService] CreateAsync error: {ex.Message}");
                return false;
            }
        }

        // ─── Send Reply (User) ─────────────────────────────────────────────
        // ✅ FIX: Use PostAsync<T1,T2> with anonymous DTO — returns TicketReply with MessageId
        public async Task<TicketReply?> ReplyAsync(TicketReply reply)
        {
            try
            {
                var dto = new TicketReplyDto
                {
                    TicketId = reply.TicketId,
                    MessageText = reply.MessageText,
                    SenderType = reply.SenderType
                };

                // ✅ T1=TicketReply (server returns saved message), T2=TicketReplyDto
                return await _api.PostAsync<TicketReply, TicketReplyDto>("api/Tickets/reply", dto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TicketService] ReplyAsync error: {ex.Message}");
                return null;
            }
        }

        // ─── Send Reply (Admin/Support) ────────────────────────────────────
        // ✅ FIX: TicketMessageDto → TicketReply use karo (same model, no missing type)
        public async Task<TicketReply?> ReplyAdminAsync(int ticketId, string message)
        {
            try
            {
                var dto = new TicketReplyDto
                {
                    TicketId = ticketId,
                    MessageText = message,
                    SenderType = "Support"
                };

                // ✅ T1=TicketReply, T2=TicketReplyDto — no ambiguity
                return await _api.PostAsync<TicketReply, TicketReplyDto>("api/Tickets/reply", dto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TicketService] ReplyAdminAsync error: {ex.Message}");
                return null;
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
                var dto = new TicketUpdateDto
                {
                    StatusId = ticket.StatusId,
                    PriorityId = ticket.PriorityId
                };

                // ✅ FIX: explicit type arguments — T1=bool, T2=TicketUpdateDto
                return await _api.PutAsync<bool, TicketUpdateDto>($"api/Tickets/{ticket.TicketId}", dto);
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
                var dto = new EmptyDto();
                // ✅ FIX: explicit type arguments — T1=bool, T2=EmptyDto
                return await _api.PostAsync<bool, EmptyDto>($"api/Tickets/close/{ticketId}", dto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TicketService] CloseAsync({ticketId}) error: {ex.Message}");
                return false;
            }
        }


        // =====================================================================
        // Yeh methods TicketService.cs mein ADD karo (existing methods ke baad)
        // AdminSupportDetail.razor inhe use karta hai
        // =====================================================================

        // ─── Get Admin Ticket Detail (with Messages list) ──────────────────
        public async Task<SupportTicketAdminDto?> GetAdminTicketDetailAsync(int ticketId)
        {
            try
            {
                // ✅ API endpoint: GET api/Tickets/{id}/admin-detail  (ya jo bhi tumhara endpoint ho)
                // Yeh SupportTicketAdminDto return karta hai jisme Messages list bhi hoti hai
                return await _api.GetFromJsonAsync<SupportTicketAdminDto>($"api/Tickets/{ticketId}/detail");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TicketService] GetAdminTicketDetailAsync({ticketId}) error: {ex.Message}");
                return null;
            }
        }

        // ─── Get Admin Users list (for assign dropdown) ────────────────────
        public async Task<List<AdminUserDto>> GetAdminUsersAsync()
        {
            try
            {
                return await _api.GetFromJsonAsync<List<AdminUserDto>>("api/Tickets/admin-users")
                       ?? new List<AdminUserDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TicketService] GetAdminUsersAsync error: {ex.Message}");
                return new List<AdminUserDto>();
            }
        }

        // ─── Assign Ticket to admin user ──────────────────────────────────
        public async Task<bool> AssignTicketAsync(int ticketId, string assigneeUserId)
        {
            try
            {
                var dto = new AssignTicketDto { AssignedToUserId = assigneeUserId };
                return await _api.PostAsync<bool, AssignTicketDto>($"api/Tickets/{ticketId}/assign", dto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TicketService] AssignTicketAsync error: {ex.Message}");
                return false;
            }
        }

        // ─── AssignTicketDto (TicketDtos.cs mein add karo) ────────────────
        public class AssignTicketDto
        {
            public string AssignedToUserId { get; set; } = string.Empty;
        }
    }
}