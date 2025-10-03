using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class VoucherConfigService
    {
        private readonly ApiClient _apiClient;
        private readonly LoadingService _loadingService;

        public VoucherConfigService(ApiClient apiClient, LoadingService loadingService)
        {
            _apiClient = apiClient;
            _loadingService = loadingService;
        }

        // ✅ Get all voucher configs
        public async Task<List<VoucherConfig>> GetAllAsync()
        {
            try
            {
                var response = await _apiClient.GetFromJsonAsync<List<VoucherConfig>>("api/VoucherConfig");
                return response ?? [];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading voucher configs: {ex.Message}");
                return new();
            }
        }

        // ✅ Get voucher config by Id
        public async Task<VoucherConfig?> GetByIdAsync(int id)
        {
            try
            {
                return await _apiClient.GetFromJsonAsync<VoucherConfig>($"api/VoucherConfig/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading voucher config by id {id}: {ex.Message}");
                return null;
            }
        }

        // ✅ Create voucher config
        public async Task<bool> CreateAsync(VoucherConfig config)
        {
            _loadingService.Show("Creating voucher config...");
            try
            {
                var result = await _apiClient.PostAsync<VoucherConfig, VoucherConfig>("api/VoucherConfig", config);
                return result != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating voucher config: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ Update voucher config
        public async Task<bool> UpdateAsync(VoucherConfig config)
        {
            _loadingService.Show("Updating voucher config...");
            try
            {
                var result = await _apiClient.PutAsync<VoucherConfig, VoucherConfig>($"api/VoucherConfig/{config.VoucherConfig_Id}", config);
                return result != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating voucher config: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ Delete voucher config
        public async Task<bool> DeleteAsync(int id)
        {
            _loadingService.Show("Deleting voucher config...");
            try
            {
                var result = await _apiClient.DeleteAsync<bool>($"api/VoucherConfig/{id}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting voucher config: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
