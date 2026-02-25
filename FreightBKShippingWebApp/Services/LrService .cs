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

        // ✅ GET FULL LR ENTRY (WITH DETAILS + JOURNALS)
        public async Task<Lr?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Lr>($"api/lr/{id}");
        }
        public async Task<LrEntryDto?> GetEntryAsync(int id)
        {
            return await _http.GetFromJsonAsync<LrEntryDto>($"api/lr/entry/{id}");
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

        // 🔥 SAVE (LR + Details + Journals)
        public async Task<Lr?> SaveAsync(
                  Lr main,
                  List<LRDetail> details,
                  List<LRJournal> journals)
        {
            // Build the single DTO the API expects
            var dto = new LrEntryDto
            {
                Main = main,
                Details = details,
                Journals = journals
            };

            // POST the DTO, expect a plain Lr back.
            // ApiClient.PostAsync<TRequest, TResponse>: request body type first, return type second.
            return await _http.PostAsync<Lr, LrEntryDto>("api/lr/save", dto);
        }

        // ✅ DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            return await _http.DeleteAsync<bool>($"api/lr/{id}");
        }

        // ✅ GET ALL FOR GRID (WITH NAMES)
        public async Task<List<LrListVM>> GetListAsync()
        {
            return await _http.GetFromJsonAsync<List<LrListVM>>("api/lr/list")
                   ?? new List<LrListVM>();
        }

    }
}