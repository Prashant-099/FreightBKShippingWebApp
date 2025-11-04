using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class AccountGroupService
    {
        private readonly ApiClient _api;
         

        public AccountGroupService(ApiClient api )
        {
            _api = api;
            
        }

        public async Task<List<AccountGroup>> GetAllAsync()
        {
           
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
           
           
        }

        public async Task<AccountGroup?> GetByIdAsync(int id)
        {
            
            try
            {
                return await _api.GetFromJsonAsync<AccountGroup>($"api/AccountGroups/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching account group {id}: {ex.Message}");
                return null;
            }
          
        }

        public async Task<bool> CreateAsync(AccountGroup accountGroup)
        {
            
            try
            {
                return await _api.PostAsync<bool, AccountGroup>("api/AccountGroups", accountGroup);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating account group: {ex.Message}");
                return false;
            }
           
           
        }

        public async Task<bool> UpdateAsync(AccountGroup accountGroup)
        {
          
            try
            {
                return await _api.PutAsync<bool, AccountGroup>($"api/AccountGroups/{accountGroup.AccountGroupId}", accountGroup);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating account group: {ex.Message}");
                return false;
            }
           
          
        }

        public async Task<bool> DeleteAsync(int accountGroupId)
        {
           
            try
            {
                return await _api.DeleteAsync<bool>($"api/AccountGroups/{accountGroupId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting account group: {ex.Message}");
                return false;
            }
           
            
        }
    }
}
