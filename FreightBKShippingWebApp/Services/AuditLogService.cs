using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class AuditLogService
    {
        private readonly ApiClient _api;

        public AuditLogService(ApiClient api)
        {
            _api = api;
        }

        /// <summary>
        /// Get latest 10 audit logs
        /// </summary>
        public async Task<List<AuditLog>> GetLatestAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<AuditLog>>(
                    "api/audit-log/latest");

                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading audit logs: {ex.Message}");
                return new();
            }
        }
    }
}
