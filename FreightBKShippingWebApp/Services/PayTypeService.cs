 
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class PayTypeService
    {
        private readonly ApiClient _api;
         

        public PayTypeService(ApiClient api )
        {
            _api = api;
            
        }

        // ✅ GET ALL
        public async Task<List<PayType>> GetAllAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<PayType>>("api/PayType?page=1&pageSize=1000");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading pay types: {ex.Message}");
                return new();
            }
           
           
        }

        // ✅ GET BY ID
        public async Task<PayType?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<PayType>($"api/PayType/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching pay type {id}: {ex.Message}");
                return null;
            }
           
            
        }

        // ✅ CREATE
        public async Task<bool> CreateAsync(PayType payType)
        {
            try
            {
                var result = await _api.PostAsync<bool, PayType>("api/PayType", payType);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating pay type: {ex.Message}");
                return false;
            }
           
           
        }

        // ✅ UPDATE
        public async Task<bool> UpdateAsync(PayType payType)
        {
            try
            {
                var result = await _api.PutAsync<bool, PayType>($"api/PayType/{payType.PayTypeId}", payType);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating pay type: {ex.Message}");
                return false;
            }
           
          
        }

        // ✅ DELETE
        public async Task<bool> DeleteAsync(int payTypeId)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/PayType/{payTypeId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting pay type: {ex.Message}");
                return false;
            }
           
            
        }
    }
}
