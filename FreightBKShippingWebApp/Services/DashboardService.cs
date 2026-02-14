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

        // 🔵 Normal User Dashboard (DO NOT CHANGE)
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
    }
}
