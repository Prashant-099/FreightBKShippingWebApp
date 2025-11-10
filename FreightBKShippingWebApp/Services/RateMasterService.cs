using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class RateMasterService
    {
        private readonly ApiClient _api;

        public RateMasterService(ApiClient api)
        {
            _api = api;
        }

        public async Task<List<RateMaster>> GetAllAsync(int page = 1, int pageSize = 1000)
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<RateMaster>>(
                    $"api/RateMaster?page={page}&pageSize={pageSize}");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading rate masters: {ex.Message}");
                return new();
            }
      
        }

        public async Task<RateMaster?> GetByIdAsync(int id)
        {
          
            try
            {
                return await _api.GetFromJsonAsync<RateMaster>($"api/RateMaster/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching rate master {id}: {ex.Message}");
                return null;
            }
         
        }

        public async Task<bool> CreateAsync(RateMaster dto)
        {
          
            try
            {
                var result = await _api.PostAsync<RateMaster, RateMaster>("api/RateMaster", dto);
                return result != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating rate master: {ex.Message}");
                return false;
            }
        
        }

        public async Task<bool> UpdateAsync(RateMaster rateMaster)
        {
          
            try
            {
                var result = await _api.PutAsync<RateMaster, RateMaster>(
                    $"api/RateMaster/{rateMaster.RateMasterId}", rateMaster);
                return result != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating rate master: {ex.Message}");
                return false;
            }
           
        }

        public async Task<bool> DeleteAsync(int rateMasterId)
        {
          
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/RateMaster/{rateMasterId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting rate master: {ex.Message}");
                return false;
            }
            
        }
    }
}
