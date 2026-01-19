 
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class CargoService
    {
        private readonly ApiClient _api;
         

        public CargoService(ApiClient api )
        {
            _api = api;
            
        }

        public async Task<List<Cargo>> GetAllAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<Cargo>>("api/Cargo?page=1&pageSize=1000");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading cargo list: {ex.Message}");
                return new();
            }
           
          
        }

        public async Task<Cargo?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<Cargo>($"api/Cargo/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching cargo {id}: {ex.Message}");
                return null;
            }
           
           
        }

        public async Task<bool> CreateAsync(Cargo cargo)
        {
            try
            {
                var result = await _api.PostAsync<bool, Cargo>("api/Cargo", cargo);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating cargo: {ex.Message}");
                return false;
            }
           
            
        }

        public async Task<bool> UpdateAsync(Cargo cargo)
        {
            try
            {
                var result = await _api.PutAsync<bool, Cargo>($"api/Cargo/{cargo.CargoId}", cargo);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating cargo: {ex.Message}");
                return false;
            }
           
            
        }

        public async Task<(bool Success, string Error)> DeleteAsync(int cargoId)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Cargo/{cargoId}");
                return (true, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting cargo: {ex.Message}");
                return (false, ex.Message);
            }
           
           
        }
    }
}
