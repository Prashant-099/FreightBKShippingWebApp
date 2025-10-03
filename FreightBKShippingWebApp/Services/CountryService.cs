using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class CountryService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public CountryService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        public async Task<List<Country>> GetAllAsync()
        {
            _loadingService.Show("Loading countries...");
            try
            {
                var response = await _api.GetFromJsonAsync<List<Country>>("api/Countries?page=1&pageSize=1000");
                return response ;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading countries: {ex.Message}");
                return new();
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<Country?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading country...");
            try
            {
                return await _api.GetFromJsonAsync<Country>($"api/Countries/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching country {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> CreateAsync(Country country)
        {
            _loadingService.Show("Creating country...");
            try
            {
                var result = await _api.PostAsync<bool, Country>("api/Countries", country);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating country: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> UpdateAsync(Country country)
        {
            _loadingService.Show("Updating country...");
            try
            {
                var result = await _api.PutAsync<bool, Country>($"api/Countries/{country.CountryId}", country);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating country: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> DeleteAsync(int countryId)
        {
            _loadingService.Show("Deleting country...");
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Countries/{countryId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting country: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
