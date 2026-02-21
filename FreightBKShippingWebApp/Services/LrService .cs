using FreightBKShippingWebApp;
using FreightBKShippingWebApp.Model;

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

        // ✅ CREATE
        public async Task<Lr?> CreateAsync(Lr model)
        {
            return await _http.PostAsync<Lr, Lr>("api/lr", model);
        }

        // ✅ UPDATE
        public async Task<bool> UpdateAsync(Lr model)
        {
            return await _http.PutAsync<bool, Lr>($"api/lr/{model.LrId}", model);
        }

        // ✅ DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            return await _http.DeleteAsync<bool>($"api/lr/{id}");
        }

        // 🔥 SAVE (Insert + Update)
        public async Task<Lr?> SaveAsync(Lr model)
        {
            return await _http.PostAsync<Lr, Lr>("api/lr/save", model);
        }
    }
}