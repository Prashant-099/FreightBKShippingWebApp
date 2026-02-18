using FreightBKShippingWebApp;
using FreightBKShippingWebApp.Model;
using System.Net.Http.Json;


namespace FreightBKShipping.Client.Services
{
    public class LrApiService
    {
        private readonly ApiClient _http;

        public LrApiService(ApiClient http)
        {
            _http = http;
        }

        // ✅ GET ALL
        public async Task<List<Lr>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<Lr>>("api/lr")
                   ?? new List<Lr>();
        }

        // ✅ GET BY ID
        public async Task<Lr?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Lr>($"api/lr/{id}");
        }

        // ✅ SEARCH
        public async Task<List<Lr>> SearchAsync(
            int partyId,
            DateTime? fromDate,
            DateTime? toDate)
        {
            var url = $"api/lr/search?partyId={partyId}";

            if (fromDate.HasValue)
                url += $"&fromDate={fromDate.Value:yyyy-MM-dd}";

            if (toDate.HasValue)
                url += $"&toDate={toDate.Value:yyyy-MM-dd}";

            return await _http.GetFromJsonAsync<List<Lr>>(url)
                   ?? new List<Lr>();
        }
    }
}
