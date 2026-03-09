
using DocumentFormat.OpenXml.VariantTypes;
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class VoucherService
    {
        private readonly ApiClient _api;
         

        public VoucherService(ApiClient api )
        {
            _api = api;
            
        }
        public string? LastError { get; private set; }
        public async Task<List<Voucher>> GetAllAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<Voucher>>("api/Vouchers");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading vouchers: {ex.Message}");
                return new();
            }
           
           
        }

        public async Task<Voucher?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<Voucher>($"api/Vouchers/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching voucher {id}: {ex.Message}");
                return null;
            }
           
           
        }

        public async Task<bool> CreateAsync(Voucher voucher)
        {
            try
            {
                LastError = null;
                var result = await _api.PostAsync<bool, Voucher>("api/Vouchers", voucher);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;   // 👈 store API error
                Console.WriteLine($"❌ Error creating voucher: {ex.Message}");
                return false;
            }
           
           
        }

        public async Task<bool> UpdateAsync(Voucher voucher)
        {
            try
            {
                LastError = null;
                var result = await _api.PutAsync<bool, Voucher>($"api/Vouchers/{voucher.VoucherId}", voucher);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;   // 👈 store API error
                Console.WriteLine($"❌ Error updating voucher: {ex.Message}");
                return false;
            }
           
            
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Vouchers/{id}");
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;   // 👈 store API error
                Console.WriteLine($"❌ Error deleting voucher: {ex.Message}");
                return false;
            }
           
          
        }
    }
}
