 
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class UserService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public UserService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        // ✅ GET ALL USERS
        public async Task<List<User>> GetAllAsync()
        {
            _loadingService.Show("Loading users...");
            try
            {
                var response = await _api.GetFromJsonAsync<List<User>>("api/Users?page=1&pageSize=1000");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading users: {ex.Message}");
                return new();
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ GET USER BY ID
        public async Task<User?> GetByIdAsync(string id)
        {
            _loadingService.Show("Loading user...");
            try
            {
                return await _api.GetFromJsonAsync<User>($"api/Users/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching user {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ CREATE USER
        public async Task<bool> CreateAsync(User user)
        {
            _loadingService.Show("Creating user...");
            try
            {
                var result = await _api.PostAsync<bool, User>("api/Users", user);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating user: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ UPDATE USER
        public async Task<bool> UpdateAsync(User user)
        {
            _loadingService.Show("Updating user...");
            try
            {
                var result = await _api.PutAsync<bool, User>($"api/Users/{user.UserId}", user);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating user: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ DELETE USER
        public async Task<bool> DeleteAsync(string userId)
        {
            _loadingService.Show("Deleting user...");
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Users/{userId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting user: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ PAGINATION SUPPORT (Optional helper)
        public async Task<PagedUserResponse?> GetPagedAsync(int page = 1, int pageSize = 20)
        {
            _loadingService.Show("Loading paged users...");
            try
            {
                return await _api.GetFromJsonAsync<PagedUserResponse>($"api/Users?page={page}&pageSize={pageSize}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading paged users: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
