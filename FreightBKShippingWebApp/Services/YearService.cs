using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class YearService
    {
        private readonly ApiClient _api;
         

        public YearService(ApiClient api )
        {
            _api = api;
            
        }
        public string? LastError { get; private set; }
        public async Task<List<YearModel>> GetAllAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<YearModel>>("api/Years?page=1&pageSize=1000");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading years: {ex.Message}");
                return new();
            }
           
            
        }

        public async Task<YearModel?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<YearModel>($"api/Years/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching year {id}: {ex.Message}");
                return null;
            }
          
        }

        public async Task<bool> CreateAsync(YearModel year)
        {
            try
            {
                LastError = null;
                var result = await _api.PostAsync<bool, YearModel>("api/Years", year);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error creating year: {ex.Message}");
                return false;
            }
           
           
        }

        public async Task<bool> UpdateAsync(YearModel year)
        {
            try
            {
                LastError = null;
                var result = await _api.PutAsync<bool, YearModel>($"api/Years/{year.YearId}", year);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error updating year: {ex.Message}");
                return false;
            }
           
           
        }

        public async Task<(bool Success, string Error)> DeleteAsync(int yearId)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Years/{yearId}");
                return (true, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting year: {ex.Message}");
                return (false, ex.Message);
            }
           
          
        }
    }
}
