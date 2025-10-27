using FreightBKShippingWebApp.Model;
using System.Text.Json;

namespace FreightBKShippingWebApp.Services
{
    public class GridLayoutService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public GridLayoutService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        // Get all layouts
        public async Task<List<GridLayoutDto>> GetAllAsync(int page = 1, int pageSize = 1000)
        {
            _loadingService.Show("Loading grid layouts...");
            try
            {
                var response = await _api.GetFromJsonAsync<List<GridLayoutDto>>(
                    $"api/GridLayout?page={page}&pageSize={pageSize}");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading grid layouts: {ex.Message}");
                return new();
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // Get layout by ID
        public async Task<GridLayoutDto?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading grid layout...");
            try
            {
                return await _api.GetFromJsonAsync<GridLayoutDto>($"api/GridLayout/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching grid layout {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // Get layouts by voucher type
        public async Task<List<GridLayoutDto>> GetLayoutsByVoucherTypeAsync(string voucherType)
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<GridLayoutDto>>(
                    $"api/GridLayout/ByVoucherType/{voucherType}");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading layouts for {voucherType}: {ex.Message}");
                return new();
            }
        }

        // Get default layout for voucher type
        public async Task<GridLayoutDto?> GetDefaultLayoutAsync(string voucherType)
        {
            try
            {
                return await _api.GetFromJsonAsync<GridLayoutDto>(
                    $"api/GridLayout/Default/{voucherType}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching default layout for {voucherType}: {ex.Message}");
                return null;
            }
        }

        // Create new layout
        public async Task<bool> CreateAsync(SaveGridLayoutRequest layout)
        {
            _loadingService.Show("Creating grid layout...");
            try
            {
                var result = await _api.PostAsync<bool, SaveGridLayoutRequest>("api/GridLayout", layout);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating grid layout: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // Update existing layout
        public async Task<bool> UpdateAsync(int layoutId, SaveGridLayoutRequest layout)
        {
            _loadingService.Show("Updating grid layout...");
            try
            {
                var result = await _api.PutAsync<bool, SaveGridLayoutRequest>(
                    $"api/GridLayout/{layoutId}", layout);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating grid layout: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // Set layout as default
        public async Task<bool> SetAsDefaultAsync(int layoutId)
        {
            _loadingService.Show("Setting default layout...");
            try
            {
                var result = await _api.PutAsync<bool, object>(
                    $"api/GridLayout/SetDefault/{layoutId}", null);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error setting default layout: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // Delete layout
        public async Task<bool> DeleteAsync(int layoutId)
        {
            _loadingService.Show("Deleting grid layout...");
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/GridLayout/{layoutId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting grid layout: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // Helper: Serialize column layout to JSON
        public string SerializeColumnLayout(List<GridColumnLayout> columns)
        {
            return JsonSerializer.Serialize(columns);
        }

        // Helper: Deserialize JSON to column layout
        public List<GridColumnLayout>? DeserializeColumnLayout(string? jsonData)
        {
            if (string.IsNullOrEmpty(jsonData))
                return null;

            try
            {
                return JsonSerializer.Deserialize<List<GridColumnLayout>>(jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deserializing column layout: {ex.Message}");
                return null;
            }
        }
    }
}
