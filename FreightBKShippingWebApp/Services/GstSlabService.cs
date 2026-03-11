 
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class GstSlabService
    {
        private readonly ApiClient _api;
         

        public GstSlabService(ApiClient api )
        {
            _api = api;
            
        }
        public string? LastError { get; private set; }
        public async Task<List<GstSlab>> GetAllAsync()
        {
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
           
           
        }

        public async Task<GstSlab?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<GstSlab>($"api/GstSlab/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching GST slab {id}: {ex.Message}");
                return null;
            }
           
           
        }

        public async Task<bool> CreateAsync(GstSlab gstSlab)
        {
            try
            {
                LastError = null;
                var result = await _api.PostAsync<bool, GstSlab>("api/GstSlab", gstSlab);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error creating GST slab: {ex.Message}");
                return false;
            }
           
           
        }

        public async Task<bool> UpdateAsync(GstSlab gstSlab)
        {
            try
            {
                LastError = null;
                var result = await _api.PutAsync<bool, GstSlab>($"api/GstSlab/{gstSlab.GstSlabId}", gstSlab);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error updating GST slab: {ex.Message}");
                return false;
            }
           
           
        }

        public async Task<(bool Success, string Error)> DeleteAsync(int gstSlabId)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/GstSlab/{gstSlabId}");
                return (true, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting GST slab: {ex.Message}");
                return (false, ex.Message);
            }
           
           
        }
    }
}
