using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class AccountTypeService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public AccountTypeService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        public async Task<List<AccountType>> GetAllAsync()
        {
            _loadingService.Show("Loading account types...");
            try
            {
                var response = await _api.GetFromJsonAsync<List<AccountType>>("api/AccountTypes?page=1&pageSize=1000");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading account types: {ex.Message}");
                return new();
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<AccountType?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading account type...");
            try
            {
                return await _api.GetFromJsonAsync<AccountType>($"api/AccountTypes/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching account type {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> CreateAsync(AccountType accountType)
        {
            _loadingService.Show("Creating account type...");
            try
            {
                return await _api.PostAsync<bool, AccountType>("api/AccountTypes", accountType);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating account type: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> UpdateAsync(AccountType accountType)
        {
            _loadingService.Show("Updating account type...");
            try
            {
                return await _api.PutAsync<bool, AccountType>($"api/AccountTypes/{accountType.AccountTypeId}", accountType);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating account type: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> DeleteAsync(int accountTypeId)
        {
            _loadingService.Show("Deleting account type...");
            try
            {
                return await _api.DeleteAsync<bool>($"api/AccountTypes/{accountTypeId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting account type: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
