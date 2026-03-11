 
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class ServiceService
    {
        private readonly ApiClient _api;
         

        public ServiceService(ApiClient api )
        {
            _api = api;
            
        }
        public string? LastError { get; private set; }
        // ✅ GET ALL
        public async Task<List<Service>> GetAllAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<Service>>("api/Services?page=1&pageSize=1000" );
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading services: {ex.Message}");
                return new();
            }
           
           
        }

        // ✅ GET BY ID
        public async Task<Service?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<Service>($"api/Services/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching service {id}: {ex.Message}");
                return null;
            }
           
            
        }

        // ✅ CREATE
        public async Task<bool> CreateAsync(Service service)
        {
            try
            {
                LastError = null;
                var result = await _api.PostAsync<bool, Service>("api/Services", service);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error creating service: {ex.Message}");
                return false;
            }
           
           
        }

        // ✅ UPDATE
        public async Task<bool> UpdateAsync(Service service)
        {
            try
            {
                LastError = null;
                var result = await _api.PutAsync<bool, Service>($"api/Services/{service.ServiceId}", service);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error updating service: {ex.Message}");
                return false;
            }
           
            
             
        }

        // ✅ DELETE
        public async Task<(bool Success, string Error)> DeleteAsync(int serviceId)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Services/{serviceId}");
                return (true, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting service: {ex.Message}");
                return (false, ex.Message);
            }
           
           
        }
    }
}
