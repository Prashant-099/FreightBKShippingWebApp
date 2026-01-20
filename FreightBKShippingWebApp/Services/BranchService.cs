using FreightBKShippingWebApp.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FreightBKShippingWebApp.Services
{
    public class BranchService : BaseService
    {
        private readonly ApiClient _api;

        public BranchService(
           HttpClient http,
           ApiClient api,
           ITokenProvider tokenProvider) : base(http, tokenProvider)
        {
            _api = api;
        }
        // Get all branches
        public async Task<List<Branch>> GetAllAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<Branch>>("api/Branches?page=1&pageSize=1000");
                return response ?? new List<Branch>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading branches: {ex.Message}");
                return new List<Branch>();
            }
        }

        // Get branches by UserId
        public async Task<List<Branch>> GetBranchesForCurrentUserAsync()
        {
            var token = await GetTokenAsync();
            if (string.IsNullOrWhiteSpace(token))
                return new();

            var userId = JwtHelper.GetUserIdFromToken(token);
            if (string.IsNullOrWhiteSpace(userId))
                return new();

            return await _api.GetFromJsonAsync<List<Branch>>(
                $"api/Branches/byuser/{userId}"
            ) ?? new();
        }

        // Get branches for the current user from JWT token


        // Get branch by ID
        public async Task<Branch?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<Branch>($"api/Branches/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching branch {id}: {ex.Message}");
                return null;
            }
        }

        // Create branch
        public async Task<bool> CreateAsync(Branch branch)
        {
            try
            {
                return await _api.PostAsync<bool, Branch>("api/Branches", branch);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating branch: {ex.Message}");
                return false;
            }
        }

        // Update branch
        public async Task<bool> UpdateAsync(Branch branch)
        {
            try
            {
                return await _api.PutAsync<bool, Branch>($"api/Branches/{branch.BranchId}", branch);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating branch: {ex.Message}");
                return false;
            }
        }

        // Delete branch
        public async Task<bool> DeleteAsync(int branchId)
        {
            try
            {
                return await _api.DeleteAsync<bool>($"api/Branches/{branchId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting branch: {ex.Message}");
                return false;
            }
        }
    }
}
