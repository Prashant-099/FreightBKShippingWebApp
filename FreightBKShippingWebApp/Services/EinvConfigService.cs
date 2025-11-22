
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
                EinvConfig? existing = null;

                // Try GET to check if record exists
                try
                {
                    existing = await _api.GetFromJsonAsync<EinvConfig>($"api/EinvConfig/{model.Username}");
                }
                catch (HttpRequestException httpEx)
                {
                    // When API returns 404 → this means "does not exist"
                    if (httpEx.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        existing = null;
                    }
                    else
                    {
                        // Re-throw other HTTP errors (500, 401, etc.)
                        throw;
                    }
                }

                // Determine insert vs update
                if (existing == null)
                {
                    // Create new record
                    return await _api.PostAsync<bool, EinvConfig>("api/EinvConfig", model);
                }
                else
                {
                    // Update existing record
                    return await _api.PutAsync<bool, EinvConfig>($"api/EinvConfig/{model.Username}", model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error saving config: {ex.Message}");
                return false;
            }
        }



    }
}
