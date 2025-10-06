using FreightBKShipping.Models;
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class CargoService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public CargoService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        public async Task<List<Cargo>> GetAllAsync()
        {
            _loadingService.Show("Loading cargo list...");
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
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<Cargo?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading cargo details...");
            try
            {
                return await _api.GetFromJsonAsync<Cargo>($"api/Cargo/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching cargo {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> CreateAsync(Cargo cargo)
        {
            _loadingService.Show("Creating cargo...");
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
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> UpdateAsync(Cargo cargo)
        {
            _loadingService.Show("Updating cargo...");
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
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> DeleteAsync(int cargoId)
        {
            _loadingService.Show("Deleting cargo...");
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Cargo/{cargoId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting cargo: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
