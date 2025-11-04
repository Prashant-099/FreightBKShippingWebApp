 
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class UserRoleService
    {
        private readonly ApiClient _api;
         

        public UserRoleService(ApiClient api )
        {
            _api = api;
            
        }

        public async Task<List<UserRole>> GetAllAsync()
        {
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
           
           
        }

        public async Task<UserRole?> GetByIdAsync(string roleUuid)
        {
            try
            {
                return await _api.GetFromJsonAsync<UserRole>($"api/UserRole/{roleUuid}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching role {roleUuid}: {ex.Message}");
                return null;
            }
           
           
        }

        public async Task<bool> CreateAsync(UserRole role)
        {
      
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
           
           
        }

        public async Task<bool> UpdateAsync(UserRole role)
        {
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
           
          
        }

        public async Task<bool> DeleteAsync(string roleUuid)
        {
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
           
           
        }
    }
}
