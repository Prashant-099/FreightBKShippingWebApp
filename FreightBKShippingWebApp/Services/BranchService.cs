
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class BranchService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public BranchService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        public async Task<List<Branch>> GetAllAsync()
        {
            _loadingService.Show("Loading branches...");
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
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<Branch?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading branch...");
            try
            {
                return await _api.GetFromJsonAsync<Branch>($"api/Branches/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching branch {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> CreateAsync(Branch branch)
        {
            _loadingService.Show("Creating branch...");
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
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> UpdateAsync(Branch branch)
        {
            _loadingService.Show("Updating branch...");
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
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> DeleteAsync(int branchId)
        {
            _loadingService.Show("Deleting branch...");
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
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
