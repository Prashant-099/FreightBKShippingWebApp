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
    }
}
