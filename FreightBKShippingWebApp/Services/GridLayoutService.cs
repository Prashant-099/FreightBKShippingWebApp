using FreightBKShippingWebApp.Model;
using System.Text.Json;

namespace FreightBKShippingWebApp.Services
{
    public class GridLayoutService
    {
        private readonly ApiClient _api;
         

        public GridLayoutService(ApiClient api )
        {
            _api = api;
            
        }

        // Get all layouts
        public async Task<List<GridLayoutDto>> GetAllAsync(int page = 1, int pageSize = 1000)
        {
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
           
           
        }

        // Get layout by ID
        public async Task<GridLayoutDto?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<GridLayoutDto>($"api/GridLayout/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching grid layout {id}: {ex.Message}");
                return null;
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
           
           
        }

        // Update existing layout
        public async Task<bool> UpdateAsync(int layoutId, SaveGridLayoutRequest layout)
        {
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
           
            
        }

        // Set layout as default
        public async Task<bool> SetAsDefaultAsync(int layoutId)
        {
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
           
        }

        // Delete layout
        public async Task<bool> DeleteAsync(int layoutId)
        {
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























        public async Task<List<GridColumnLayout>?> GetLayoutAsync(string voucherType)
        {
            try
            {
                var dto = await GetDefaultLayoutAsync(voucherType);
                if (dto == null || string.IsNullOrWhiteSpace(dto.GridLayoutData))
                    return null;

                return DeserializeColumnLayout(dto.GridLayoutData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ GetLayoutAsync error for {voucherType}: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Persist columns for a VoucherType.
        /// Creates a new record if none exists, updates if one already exists.
        /// </summary>
        public async Task<bool> SaveLayoutAsync(string voucherType, List<GridColumnLayout> columns)
        {
            try
            {
                var json = SerializeColumnLayout(columns);

                // Check if a layout already exists for this voucherType
                var existing = await GetDefaultLayoutAsync(voucherType);

                if (existing == null || existing.GridLayoutId == 0)
                {
                    // Create new
                    var request = new SaveGridLayoutRequest
                    {
                        GridLayoutVoucherType = voucherType,
                        GridLayoutName = voucherType,   // use voucherType as default name
                        GridLayoutData = json,
                        GridLayoutDefault = true
                    };
                    return await CreateAsync(request);
                }
                else
                {
                    // Update existing
                    var request = new SaveGridLayoutRequest
                    {
                        GridLayoutVoucherType = voucherType,
                        GridLayoutName = existing.GridLayoutName ?? voucherType,
                        GridLayoutData = json,
                        GridLayoutDefault = true
                    };
                    return await UpdateAsync(existing.GridLayoutId, request);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ SaveLayoutAsync error for {voucherType}: {ex.Message}");
                return false;
            }
        }

    }
}
