 
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class LocationService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public LocationService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        public async Task<List<Location>> GetAllAsync()
        {
            _loadingService.Show("Loading locations...");
            try
            {
                var response = await _api.GetFromJsonAsync<List<Location>>("api/Locations?page=1&pageSize=1000");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading locations: {ex.Message}");
                return new();
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<Location?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading location...");
            try
            {
                return await _api.GetFromJsonAsync<Location>($"api/Locations/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching location {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> CreateAsync(Location location)
        {
            _loadingService.Show("Creating location...");
            try
            {
                var result = await _api.PostAsync<bool, Location>("api/Locations", location);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating location: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> UpdateAsync(Location location)
        {
            _loadingService.Show("Updating location...");
            try
            {
                var result = await _api.PutAsync<bool, Location>($"api/Locations/{location.LocationId}", location);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating location: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> DeleteAsync(int locationId)
        {
            _loadingService.Show("Deleting location...");
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Locations/{locationId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting location: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
