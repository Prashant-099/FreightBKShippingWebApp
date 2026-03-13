using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class CountryService
    {
        private readonly ApiClient _api;
         

        public CountryService(ApiClient api )
        {
            _api = api;
            
        }
        public string? LastError { get; private set; }
        public async Task<List<Country>> GetAllAsync()
        {
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
           
          
        }

        public async Task<Country?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<Country>($"api/Countries/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching country {id}: {ex.Message}");
                return null;
            }
           
            
        }

        public async Task<bool> CreateAsync(Country country)
        {
            try
            {
                LastError = null;
                var result = await _api.PostAsync<bool, Country>("api/Countries", country);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error creating country: {ex.Message}");
                return false;
            }
           
            
        }

        public async Task<bool> UpdateAsync(Country country)
        {
            try
            {
                LastError = null;
                var result = await _api.PutAsync<bool, Country>($"api/Countries/{country.CountryId}", country);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error updating country: {ex.Message}");
                return false;
            }
           
            
        }

        public async Task<(bool Success, string Error)> DeleteAsync(int countryId)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Countries/{countryId}");
                return (true, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting country: {ex.Message}");
                return (false, ex.Message);
            }
           
            
        }
    }
}
