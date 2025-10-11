 
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class ServiceService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public ServiceService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        // ✅ GET ALL
        public async Task<List<Service>> GetAllAsync()
        {
            _loadingService.Show("Loading services...");
            try
            {
                var response = await _api.GetFromJsonAsync<List<Service>>("api/Services?page=1&pageSize=1000");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading services: {ex.Message}");
                return new();
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ GET BY ID
        public async Task<Service?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading service...");
            try
            {
                return await _api.GetFromJsonAsync<Service>($"api/Services/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching service {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ CREATE
        public async Task<bool> CreateAsync(Service service)
        {
            _loadingService.Show("Creating service...");
            try
            {
                var result = await _api.PostAsync<bool, Service>("api/Services", service);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating service: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ UPDATE
        public async Task<bool> UpdateAsync(Service service)
        {
            _loadingService.Show("Updating service...");
            try
            {
                var result = await _api.PutAsync<bool, Service>($"api/Services/{service.ServiceId}", service);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating service: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ DELETE
        public async Task<bool> DeleteAsync(int serviceId)
        {
            _loadingService.Show("Deleting service...");
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Services/{serviceId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting service: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
