using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class AccountService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public AccountService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        public async Task<List<Account>> GetAllAsync(int page = 1, int pageSize = 1000)
        {
            _loadingService.Show("Loading accounts...");
            try
            {
                var response = await _api.GetFromJsonAsync<List<Account>>(
                    $"api/Accounts?page={page}&pageSize={pageSize}");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading accounts: {ex.Message}");
                return new();
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading account...");
            try
            {
                return await _api.GetFromJsonAsync<Account>($"api/Accounts/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching account {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> CreateAsync(Account account)
        {
            _loadingService.Show("Creating account...");
            try
            {
                var result = await _api.PostAsync<bool, Account>("api/Accounts", account);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating account: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> UpdateAsync(Account account)
        {
            _loadingService.Show("Updating account...");
            try
            {
                var result = await _api.PutAsync<bool, Account>(
                    $"api/Accounts/{account.AccountId}", account);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating account: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> DeleteAsync(int accountId)
        {
            _loadingService.Show("Deleting account...");
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Accounts/{accountId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting account: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
