using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class CurrencyService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public CurrencyService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        public async Task<List<Currency>> GetAllAsync()
        {
            _loadingService.Show("Loading currencies...");
            try
            {
                var response = await _api.GetFromJsonAsync<List<Currency>>("api/Currency?page=1&pageSize=1000");
                return response ?? new List<Currency>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading currencies: {ex.Message}");
                return new List<Currency>();
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<Currency?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading currency...");
            try
            {
                return await _api.GetFromJsonAsync<Currency>($"api/Currency/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching currency {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> CreateAsync(Currency currency)
        {
            _loadingService.Show("Creating currency...");
            try
            {
                var result = await _api.PostAsync<bool, Currency>("api/Currency", currency);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating currency: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> UpdateAsync(Currency currency)
        {
            _loadingService.Show("Updating currency...");
            try
            {
                var result = await _api.PutAsync<bool, Currency>($"api/Currency/{currency.CurrencyId}", currency);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating currency: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> DeleteAsync(int currencyId)
        {
            _loadingService.Show("Deleting currency...");
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Currency/{currencyId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting currency: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
