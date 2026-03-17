using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class DashboardService
    {
        private readonly ApiClient _api;

        public DashboardService(ApiClient api)
        {
            _api = api;
        }
        public string GetApiBaseUrl() => _api.GetBaseUrl();
        private string? _cachedToken;
        public async Task<string?> GetAuthTokenAsync()
        {
            if (!string.IsNullOrWhiteSpace(_cachedToken))
                return _cachedToken;

            try
            {
                _cachedToken = await _api.GetAuthTokenAsync();
                return _cachedToken;
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("⚠️ Token fetch cancelled (JS not ready)");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Token fetch error: {ex.Message}");
                return null;
            }
        }        // 🔵 Normal User Dashboard (DO NOT CHANGE)
        public async Task<DashboardResponseDto?> GetDashboardAsync(
            int yearId,
            DateTime? fromDate,
            DateTime? toDate)
        {
            try
            {
                var url = $"api/dashboard?yearId={yearId}";

                if (fromDate.HasValue)
                    url += $"&fromDate={fromDate:yyyy-MM-dd}";

                if (toDate.HasValue)
                    url += $"&toDate={toDate:yyyy-MM-dd}";

                return await _api.GetFromJsonAsync<DashboardResponseDto>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading dashboard: {ex.Message}");
                return null;
            }
        }

        // 🔥 SUPER ADMIN DASHBOARD (FIXED ROUTE)
        public async Task<SuperAdminDashboardDto?> GetSuperAdminDashboardAsync()
        {
            try
            {
                var url = "api/superadmin/dashboard";

                return await _api.GetFromJsonAsync<SuperAdminDashboardDto>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading super admin dashboard: {ex.Message}");
                return null;
            }
        }

        // 🔥 COMPANY LOGS
        public async Task<List<UserLoginSessionDto>?> GetCompanyLogsAsync(int companyId)
        {
            try
            {
                var url = $"api/superadmin/company-logs/{companyId}";
                return await _api.GetFromJsonAsync<List<UserLoginSessionDto>>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading company logs: {ex.Message}");
                return null;
            }
        }

        // 🔥 FORCE LOGOUT
        public async Task<bool> ForceLogoutCompanyAsync(int companyId)
        {
            try
            {
                var url = $"api/superadmin/force-logout/{companyId}";
                await _api.PostAsync<object, object>(url, null);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error forcing logout: {ex.Message}");
                return false;
            }
        }



        // ── Tickets ────────────────────────────────────────────────
        public async Task<List<SupportTicketAdminDto>> GetAllTicketsAsync(
            int? companyId = null, int? statusId = null, int? priorityId = null)
        {
            try
            {
                var q = new List<string>();
                if (companyId.HasValue) q.Add($"company={companyId}");
                if (statusId.HasValue) q.Add($"status={statusId}");
                if (priorityId.HasValue) q.Add($"priority={priorityId}");
                var qs = q.Any() ? "?" + string.Join("&", q) : "";
                return await _api.GetFromJsonAsync<List<SupportTicketAdminDto>>($"api/superadmin/tickets{qs}")
                       ?? new List<SupportTicketAdminDto>();
            }
            catch (Exception ex) { Console.WriteLine($"[SuperAdminClientService] GetAllTickets error: {ex.Message}"); return new(); }
        }

        public async Task<SupportTicketAdminDto?> GetTicketDetailAsync(int ticketId)
        {
            try { return await _api.GetFromJsonAsync<SupportTicketAdminDto>($"api/superadmin/tickets/{ticketId}"); }
            catch (Exception ex) { Console.WriteLine($"[SuperAdminClientService] GetTicketDetail error: {ex.Message}"); return null; }
        }

        // DashboardService.cs — REPLACE the old ReplyAsync:
        public async Task<TicketMessageAdminDto?> ReplyAsync(int ticketId, string message)
        {
            try
            {
                return await _api.PostAsync<TicketMessageAdminDto, object>(
                    $"api/superadmin/tickets/{ticketId}/reply",
                    new { Message = message }
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SuperAdminClientService] Reply error: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> AssignTicketAsync(int ticketId, string userId)
        {
            try { return await _api.PostAsync<bool, object>($"api/superadmin/tickets/{ticketId}/assign", new { AssignedToUserId = userId }); }
            catch (Exception ex) { Console.WriteLine($"[SuperAdminClientService] Assign error: {ex.Message}"); return false; }
        }

        public async Task<bool> UpdateStatusAsync(int ticketId, int statusId, int priorityId)
        {
            try { return await _api.PutAsync<bool, object>($"api/superadmin/tickets/{ticketId}/status", new { StatusId = statusId, PriorityId = priorityId }); }
            catch (Exception ex) { Console.WriteLine($"[SuperAdminClientService] UpdateStatus error: {ex.Message}"); return false; }
        }

        public async Task<bool> CloseTicketAsync(int ticketId)
        {
            try { return await _api.PostAsync<bool, object>($"api/superadmin/tickets/{ticketId}/close", new { }); }
            catch (Exception ex) { Console.WriteLine($"[SuperAdminClientService] Close error: {ex.Message}"); return false; }
        }

        public async Task<List<AdminUserDto>> GetAdminUsersAsync()
        {
            try { return await _api.GetFromJsonAsync<List<AdminUserDto>>("api/superadmin/admin-users") ?? new(); }
            catch (Exception ex) { Console.WriteLine($"[SuperAdminClientService] GetAdminUsers error: {ex.Message}"); return new(); }
        }
    }
}
