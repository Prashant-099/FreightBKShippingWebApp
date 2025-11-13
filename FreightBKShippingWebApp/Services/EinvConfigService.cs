
using FreightBKShippingWebApp.Models;

namespace FreightBKShippingWebApp.Services
{
    public class EinvConfigService
    {
        private readonly ApiClient _api;

        public EinvConfigService(ApiClient api)
        {
            _api = api;
        }

        // 🔹 Get all E-Invoice Configurations
        public async Task<List<EinvConfig>> GetAllAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<EinvConfig>>("api/EinvConfig?page=1&pageSize=1000");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading E-Invoice configs: {ex.Message}");
                return new();
            }
        }

        // 🔹 Get Configuration by Username (Primary Key)
        public async Task<EinvConfig?> GetByUsernameAsync(string username)
        {
            try
            {
                return await _api.GetFromJsonAsync<EinvConfig>($"api/EinvConfig/{username}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching E-Invoice config '{username}': {ex.Message}");
                return null;
            }
        }

        public async Task<bool> SaveAsync(EinvConfig model)
        {
            try
            {
                // Decide whether to insert or update based on existence
                if (model.Username == null || model.Username == "")
                    return await _api.PostAsync<bool, EinvConfig>("api/EinvConfig", model);
                else
                    return await _api.PutAsync<bool, EinvConfig>($"api/EinvConfig/{model.Username}", model);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error saving config: {ex.Message}");
                return false;
            }
        }
    }
}
