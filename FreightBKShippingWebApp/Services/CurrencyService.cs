using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class CurrencyService
    {
        private readonly ApiClient _api;
         

        public CurrencyService(ApiClient api )
        {
            _api = api;
            
        }
        public string? LastError { get; private set; }
        public async Task<List<Currency>> GetAllAsync()
        {
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
           
           
        }

        public async Task<Currency?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<Currency>($"api/Currency/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching currency {id}: {ex.Message}");
                return null;
            }
           
           
        }

        public async Task<bool> CreateAsync(Currency currency)
        {
            try
            {
                LastError = null;
                var result = await _api.PostAsync<bool, Currency>("api/Currency", currency);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error creating currency: {ex.Message}");
                return false;
            }
           
            
        }

        public async Task<bool> UpdateAsync(Currency currency)
        {
            try
            {
                LastError = null;
                var result = await _api.PutAsync<bool, Currency>($"api/Currency/{currency.CurrencyId}", currency);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error updating currency: {ex.Message}");
                return false;
            }
           
            
        }

        public async Task<(bool Success, string Error)> DeleteAsync(int currencyId)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Currency/{currencyId}");
                return (true, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting currency: {ex.Message}");
                return (false, ex.Message);
            }
           
          
        }
    }
}
