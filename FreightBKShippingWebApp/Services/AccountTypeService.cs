using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class AccountTypeService
    {
        private readonly ApiClient _api;
         

        public AccountTypeService(ApiClient api )
        {
            _api = api;
            
        }

        public async Task<List<AccountType>> GetAllAsync()
        {
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
           
           
        }

        public async Task<AccountType?> GetByIdAsync(int id)
        {
           
            try
            {
                return await _api.GetFromJsonAsync<AccountType>($"api/AccountTypes/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching account type {id}: {ex.Message}");
                return null;
            }
           
           
        }

        public async Task<bool> CreateAsync(AccountType accountType)
        {
            try
            {
                return await _api.PostAsync<bool, AccountType>("api/AccountTypes", accountType);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating account type: {ex.Message}");
                return false;
            }
          
        }

        public async Task<bool> UpdateAsync(AccountType accountType)
        {
            try
            {
                return await _api.PutAsync<bool, AccountType>($"api/AccountTypes/{accountType.AccountTypeId}", accountType);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating account type: {ex.Message}");
                return false;
            }
           

        }

        public async Task<bool> DeleteAsync(int accountTypeId)
        {
            try
            {
                return await _api.DeleteAsync<bool>($"api/AccountTypes/{accountTypeId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting account type: {ex.Message}");
                return false;
            }
           
            
        }
    }
}
