using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class AccountService
    {
        private readonly ApiClient _api;
         

        public AccountService(ApiClient api )
        {
            _api = api;
            
        }

        public async Task<List<Account>> GetAllAsync(int page = 1, int pageSize = 1000)
        {
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
           
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
           
            try
            {
                return await _api.GetFromJsonAsync<Account>($"api/Accounts/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching account {id}: {ex.Message}");
                return null;
            }
           
           
        }

        public async Task<bool> CreateAsync(Account account)
        {
          
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
           
            
        }

        public async Task<bool> UpdateAsync(Account account)
        {
           
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
           
           
        }

        public async Task<bool> DeleteAsync(int accountId)
        {
            
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
           
            
        }
    }
}
