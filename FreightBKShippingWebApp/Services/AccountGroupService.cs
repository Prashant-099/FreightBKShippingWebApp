using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class AccountGroupService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public AccountGroupService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        public async Task<List<AccountGroup>> GetAllAsync()
        {
            _loadingService.Show("Loading account groups...");
            try
            {
                var response = await _api.GetFromJsonAsync<List<AccountGroup>>("api/AccountGroups?page=1&pageSize=1000");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading account groups: {ex.Message}");
                return new();
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<AccountGroup?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading account group...");
            try
            {
                return await _api.GetFromJsonAsync<AccountGroup>($"api/AccountGroups/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching account group {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> CreateAsync(AccountGroup accountGroup)
        {
            _loadingService.Show("Creating account group...");
            try
            {
                return await _api.PostAsync<bool, AccountGroup>("api/AccountGroups", accountGroup);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating account group: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> UpdateAsync(AccountGroup accountGroup)
        {
            _loadingService.Show("Updating account group...");
            try
            {
                return await _api.PutAsync<bool, AccountGroup>($"api/AccountGroups/{accountGroup.AccountGroupId}", accountGroup);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating account group: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> DeleteAsync(int accountGroupId)
        {
            _loadingService.Show("Deleting account group...");
            try
            {
                return await _api.DeleteAsync<bool>($"api/AccountGroups/{accountGroupId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting account group: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
