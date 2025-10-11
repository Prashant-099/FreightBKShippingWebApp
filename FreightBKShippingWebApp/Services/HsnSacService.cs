 
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class HsnSacService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public HsnSacService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        public async Task<List<HsnSac>> GetAllAsync()
        {
            _loadingService.Show("Loading HSN/SAC records...");
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
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<HsnSac?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading HSN/SAC details...");
            try
            {
                return await _api.GetFromJsonAsync<HsnSac>($"api/HsnSac/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching HSN/SAC {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> CreateAsync(HsnSac hsn)
        {
            _loadingService.Show("Creating HSN/SAC...");
            try
            {
                var result = await _api.PostAsync<bool, HsnSac>("api/HsnSac", hsn);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating HSN/SAC: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> UpdateAsync(HsnSac hsn)
        {
            _loadingService.Show("Updating HSN/SAC...");
            try
            {
                var result = await _api.PutAsync<bool, HsnSac>($"api/HsnSac/{hsn.HsnId}", hsn);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating HSN/SAC: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> DeleteAsync(int hsnId)
        {
            _loadingService.Show("Deleting HSN/SAC...");
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/HsnSac/{hsnId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting HSN/SAC: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
