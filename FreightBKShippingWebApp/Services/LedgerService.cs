using FreightBKShippingWebApp.Model;
using static System.Net.WebRequestMethods;

namespace FreightBKShippingWebApp.Services
{
    public class LedgerService
    {
        private readonly ApiClient _api;
        public LedgerService(ApiClient api)
        {
            _api = api;
        }

        public async Task<List<LedgerDto>> GetLedgerAsync(int accountId, DateTime? from, DateTime? to)
        {
            try
            {
                var query = $"api/AccountLedger?accountId={accountId}";

                if (from.HasValue)
                    query += $"&fromDate={from.Value:yyyy-MM-dd}";

                if (to.HasValue)
                    query += $"&toDate={to.Value:yyyy-MM-dd}";

                var result = await _api.GetFromJsonAsync<List<LedgerDto>>(query);
                return result ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading ledger: {ex.Message}");
                return new();
            }
        }
    }
}
