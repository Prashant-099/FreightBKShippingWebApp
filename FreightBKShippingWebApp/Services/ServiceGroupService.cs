using FreightBKShipping.Models;
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class ServiceGroupService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public ServiceGroupService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        // ✅ GET ALL
        public async Task<List<ServiceGroup>> GetAllAsync()
        {
            _loadingService.Show("Loading service groups...");
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
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ GET BY ID
        public async Task<ServiceGroup?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading service group...");
            try
            {
                return await _api.GetFromJsonAsync<ServiceGroup>($"api/ServiceGroups/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching service group {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ CREATE
        public async Task<bool> CreateAsync(ServiceGroup serviceGroup)
        {
            _loadingService.Show("Creating service group...");
            try
            {
                var result = await _api.PostAsync<bool, ServiceGroup>("api/ServiceGroups", serviceGroup);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating service group: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ UPDATE
        public async Task<bool> UpdateAsync(ServiceGroup serviceGroup)
        {
            _loadingService.Show("Updating service group...");
            try
            {
                var result = await _api.PutAsync<bool, ServiceGroup>($"api/ServiceGroups/{serviceGroup.ServiceGroupsId}", serviceGroup);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating service group: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ DELETE
        public async Task<bool> DeleteAsync(int serviceGroupId)
        {
            _loadingService.Show("Deleting service group...");
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/ServiceGroups/{serviceGroupId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting service group: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
