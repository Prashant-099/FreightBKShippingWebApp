using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class AuditLogService
    {
        private readonly ApiClient _api;

        public event Action? OnAuditChanged;
        public event Action OnJobChanged;

        public void NotifyJobChanged()
        {
            OnJobChanged?.Invoke();
        }
        public AuditLogService(ApiClient api)
        {
            _api = api;
        }

        /// <summary>
        /// Get latest 10 audit logs
        /// </summary>
        public async Task<List<AuditLog>> GetLatestAsync(
     DateTime? fromDate,
     DateTime? toDate)
        {
            try
            {
                var queryParams = new List<string>();

                if (fromDate.HasValue)
                    queryParams.Add($"fromDate={fromDate.Value:yyyy-MM-dd}");

                if (toDate.HasValue)
                    queryParams.Add($"toDate={toDate.Value:yyyy-MM-dd}");

                var url = "api/audit-log/latest";

                if (queryParams.Any())
                    url += "?" + string.Join("&", queryParams);

                var response = await _api.GetFromJsonAsync<List<AuditLog>>(url);

                return response ?? new List<AuditLog>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading audit logs: {ex.Message}");
                return new List<AuditLog>();
            }
        }


        public void NotifyAuditChanged()
        {
            OnAuditChanged?.Invoke();
        }
    }
}
