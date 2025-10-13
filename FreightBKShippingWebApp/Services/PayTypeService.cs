 
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class PayTypeService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public PayTypeService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        // ✅ GET ALL
        public async Task<List<PayType>> GetAllAsync()
        {
            _loadingService.Show("Loading pay types...");
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
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ GET BY ID
        public async Task<PayType?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading pay type...");
            try
            {
                return await _api.GetFromJsonAsync<PayType>($"api/PayType/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching pay type {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ CREATE
        public async Task<bool> CreateAsync(PayType payType)
        {
            _loadingService.Show("Creating pay type...");
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
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ UPDATE
        public async Task<bool> UpdateAsync(PayType payType)
        {
            _loadingService.Show("Updating pay type...");
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
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ DELETE
        public async Task<bool> DeleteAsync(int payTypeId)
        {
            _loadingService.Show("Deleting pay type...");
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
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
