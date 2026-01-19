 
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class UserService
    {
        private readonly ApiClient _api;
         

        public UserService(ApiClient api )
        {
            _api = api;
            
        }

        // ✅ GET ALL USERS
        public async Task<List<User>> GetAllAsync()
        {
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
           
           
        }

        // ✅ GET USER BY ID
        public async Task<User?> GetByIdAsync(string id)
        {
            try
            {
                return await _api.GetFromJsonAsync<User>($"api/Users/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching user {id}: {ex.Message}");
                return null;
            }
           
           
        }







        // ✅ CREATE USER
        public async Task<bool> CreateAsync(User user)
        {
            try
            {
                await _api.PostAsync<User, User>("api/Users", user);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }


        // ✅ UPDATE USER
        public async Task<bool> UpdateAsync(User user)
        {
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
           
            
        }






        // ✅ DELETE USER
        public async Task<bool> DeleteAsync(string userId)
        {
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
           
           
        }

        // ✅ PAGINATION SUPPORT (Optional helper)
        public async Task<PagedUserResponse?> GetPagedAsync(int page = 1, int pageSize = 20)
        {
            try
            {
                return await _api.GetFromJsonAsync<PagedUserResponse>($"api/Users?page={page}&pageSize={pageSize}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading paged users: {ex.Message}");
                return null;
            }
           
            
        }
    }
}
