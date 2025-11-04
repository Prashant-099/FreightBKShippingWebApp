
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class BranchService
    {
        private readonly ApiClient _api;
         

        public BranchService(ApiClient api )
        {
            _api = api;
            
        }

        public async Task<List<Branch>> GetAllAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<Branch>>("api/Branches?page=1&pageSize=1000");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading branches: {ex.Message}");
                return new();
            }
           
           
        }

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

        public async Task<bool> CreateAsync(Branch branch)
        {
            try
            {
                var result = await _api.PostAsync<bool, Branch>("api/Branches", branch);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating branch: {ex.Message}");
                return false;
            }
           
           
        }

        public async Task<bool> UpdateAsync(Branch branch)
        {
            try
            {
                var result = await _api.PutAsync<bool, Branch>($"api/Branches/{branch.BranchId}", branch);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating branch: {ex.Message}");
                return false;
            }
           
           
        }

        public async Task<bool> DeleteAsync(int branchId)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Branches/{branchId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting branch: {ex.Message}");
                return false;
            }
           
            
        }
    }
}
