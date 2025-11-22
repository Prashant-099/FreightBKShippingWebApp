
using BlazorApp.Model;
using FreightBKShippingWebApp;
using FreightBKShippingWebApp.Model;
using global::BlazorApp.Model;
using System.Net.Http.Json;

namespace BlazorApp.Services
{
    public class WpMailConfigService
    {
        private readonly ApiClient _apiClient;

        public WpMailConfigService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        // Get all configs with optional paging
        public async Task<List<WpMailConfig>> GetAllAsync(int page = 1, int pageSize = 1000)
        {
            try
            {
                var response = await _apiClient.GetFromJsonAsync<PagedResponseDto<WpMailConfig>>($"api/WpMailConfig?page={page}&pageSize={pageSize}");
                return response?.Data ?? new List<WpMailConfig>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading WpMailConfigs: {ex.Message}");
                return new List<WpMailConfig>();
            }
        }

        // Get by ID
        public async Task<WpMailConfig?> GetByIdAsync(int id)
        {
            try
            {
                var config = await _apiClient.GetFromJsonAsync<WpMailConfig>($"api/WpMailConfig/{id}");
                return config;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading WpMailConfig {id}: {ex.Message}");
                return null;
            }
        }

        // Create new config
        public async Task<bool> CreateAsync(WpMailConfig config)
        {
            try
            {
                var result = await _apiClient.PostAsync<WpMailConfig, WpMailConfig>("api/WpMailConfig", config);
                return result != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating WpMailConfig: {ex.Message}");
                return false;
            }
        }

        // Update existing config
        public async Task<bool> UpdateAsync(WpMailConfig config)
        {
            try
            {
                // Change return type to bool in PutAsync call
                var result = await _apiClient.PutAsync<bool, WpMailConfig>($"api/WpMailConfig/{config.Id}", config);
                return result; // directly return bool
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating WpMailConfig: {ex.Message}");
                return false;
            }
        }


        // Delete config
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _apiClient.DeleteAsync<bool>($"api/WpMailConfig/{id}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting WpMailConfig: {ex.Message}");
                return false;
            }
        }


        // Get default config by MsgType (and optional CompanyId)
        public async Task<WpMailConfig?> GetDefaultAsync(string msgType, int? companyId = null)
        {
            try
            {
                var url = $"api/WpMailConfig/default?msgType={msgType}";
                if (companyId.HasValue)
                    url += $"&companyId={companyId.Value}";

                var config = await _apiClient.GetFromJsonAsync<WpMailConfig>(url);
                return config;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading default WpMailConfig for '{msgType}': {ex.Message}");
                return null;
            }
        }

    }
}
