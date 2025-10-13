 
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class UserRoleService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public UserRoleService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        public async Task<List<UserRole>> GetAllAsync()
        {
            _loadingService.Show("Loading roles...");
            try
            {
                var response = await _api.GetFromJsonAsync<List<UserRole>>("api/UserRole?page=1&pageSize=1000");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading roles: {ex.Message}");
                return new();
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<UserRole?> GetByIdAsync(string roleUuid)
        {
            _loadingService.Show("Loading role...");
            try
            {
                return await _api.GetFromJsonAsync<UserRole>($"api/UserRole/{roleUuid}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching role {roleUuid}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> CreateAsync(UserRole role)
        {
            _loadingService.Show("Creating role...");
            try
            {
                var result = await _api.PostAsync<bool, UserRole>("api/UserRole", role);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating role: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> UpdateAsync(UserRole role)
        {
            _loadingService.Show("Updating role...");
            try
            {
                var result = await _api.PutAsync<bool, UserRole>($"api/UserRole/{role.RoleUuid}", role);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating role: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> DeleteAsync(string roleUuid)
        {
            _loadingService.Show("Deleting role...");
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/UserRole/{roleUuid}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting role: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
