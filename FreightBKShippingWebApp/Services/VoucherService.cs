using FreightBKShipping.Models;

namespace FreightBKShippingWebApp.Services
{
    public class VoucherService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public VoucherService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        public async Task<List<Voucher>> GetAllAsync()
        {
            _loadingService.Show("Loading vouchers...");
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
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<Voucher?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading voucher...");
            try
            {
                return await _api.GetFromJsonAsync<Voucher>($"api/Vouchers/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching voucher {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> CreateAsync(Voucher voucher)
        {
            _loadingService.Show("Creating voucher...");
            try
            {
                var result = await _api.PostAsync<bool, Voucher>("api/Vouchers", voucher);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating voucher: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> UpdateAsync(Voucher voucher)
        {
            _loadingService.Show("Updating voucher...");
            try
            {
                var result = await _api.PutAsync<bool, Voucher>($"api/Vouchers/{voucher.VoucherId}", voucher);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating voucher: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _loadingService.Show("Deleting voucher...");
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Vouchers/{id}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting voucher: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
