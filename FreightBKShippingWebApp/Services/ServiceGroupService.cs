
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class ServiceGroupService
    {
        private readonly ApiClient _api;
         

        public ServiceGroupService(ApiClient api )
        {
            _api = api;
            
        }
        public string? LastError { get; private set; }
        // ✅ GET ALL
        public async Task<List<ServiceGroup>> GetAllAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<ServiceGroup>>("api/ServiceGroups?page=1&pageSize=1000");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading service groups: {ex.Message}");
                return new();
            }
           
           
        }

        // ✅ GET BY ID
        public async Task<ServiceGroup?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<ServiceGroup>($"api/ServiceGroups/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching service group {id}: {ex.Message}");
                return null;
            }
           
            
        }

        // ✅ CREATE
        public async Task<bool> CreateAsync(ServiceGroup serviceGroup)
        {
            try
            {
                LastError = null;
                var result = await _api.PostAsync<bool, ServiceGroup>("api/ServiceGroups", serviceGroup);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error creating service group: {ex.Message}");
                return false;
            }
           
            
        }

        // ✅ UPDATE
        public async Task<bool> UpdateAsync(ServiceGroup serviceGroup)
        {
            try
            {
                LastError = null;
                var result = await _api.PutAsync<bool, ServiceGroup>($"api/ServiceGroups/{serviceGroup.ServiceGroupsId}", serviceGroup);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error updating service group: {ex.Message}");
                return false;
            }
           
           
        }

        // ✅ DELETE
        public async Task<(bool Success, string Error)> DeleteAsync(int serviceGroupId)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/ServiceGroups/{serviceGroupId}");
                return (true, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting service group: {ex.Message}");
                return (false, ex.Message);
            }
           
            
        }
    }
}
