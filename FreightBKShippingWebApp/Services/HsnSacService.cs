 
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class HsnSacService
    {
        private readonly ApiClient _api;
         

        public HsnSacService(ApiClient api )
        {
            _api = api;
            
        }
        public string? LastError { get; private set; }
        public async Task<List<HsnSac>> GetAllAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<HsnSac>>("api/HsnSac?page=1&pageSize=1000");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading HSN/SAC records: {ex.Message}");
                return new();
            }
           
          
        }

        public async Task<HsnSac?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<HsnSac>($"api/HsnSac/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching HSN/SAC {id}: {ex.Message}");
                return null;
            }
           
            
        }

        public async Task<bool> CreateAsync(HsnSac hsn)
        {
            try
            {
                LastError = null;
                var result = await _api.PostAsync<bool, HsnSac>("api/HsnSac", hsn);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error creating HSN/SAC: {ex.Message}");
                return false;
            }
           
            
        }

        public async Task<bool> UpdateAsync(HsnSac hsn)
        {
            try
            {
                LastError = null;
                var result = await _api.PutAsync<bool, HsnSac>($"api/HsnSac/{hsn.HsnId}", hsn);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error updating HSN/SAC: {ex.Message}");
                return false;
            }
           
           
        }

        public async Task<(bool Success, string Error)> DeleteAsync(int hsnId)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/HsnSac/{hsnId}");
                return (true, null); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting HSN/SAC: {ex.Message}");
                return (false, ex.Message); 
            }
           
           
        }
    }
}
