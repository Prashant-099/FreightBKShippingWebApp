using FreightBKShipping.Models;
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class GstSlabService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public GstSlabService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        public async Task<List<GstSlab>> GetAllAsync()
        {
            _loadingService.Show("Loading GST slabs...");
            try
            {
                var response = await _api.GetFromJsonAsync<List<GstSlab>>("api/GstSlab?page=1&pageSize=1000");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading GST slabs: {ex.Message}");
                return new();
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<GstSlab?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading GST slab details...");
            try
            {
                return await _api.GetFromJsonAsync<GstSlab>($"api/GstSlab/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching GST slab {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> CreateAsync(GstSlab gstSlab)
        {
            _loadingService.Show("Creating GST slab...");
            try
            {
                var result = await _api.PostAsync<bool, GstSlab>("api/GstSlab", gstSlab);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating GST slab: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> UpdateAsync(GstSlab gstSlab)
        {
            _loadingService.Show("Updating GST slab...");
            try
            {
                var result = await _api.PutAsync<bool, GstSlab>($"api/GstSlab/{gstSlab.GstSlabId}", gstSlab);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating GST slab: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> DeleteAsync(int gstSlabId)
        {
            _loadingService.Show("Deleting GST slab...");
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/GstSlab/{gstSlabId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting GST slab: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
