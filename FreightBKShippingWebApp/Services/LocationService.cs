 
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class LocationService
    {
        private readonly ApiClient _api;
         

        public LocationService(ApiClient api )
        {
            _api = api;
            
        }

        public async Task<List<Location>> GetAllAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<Location>>("api/Locations?page=1&pageSize=1000", useCache: true);
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading locations: {ex.Message}");
                return new();
            }
           
           
        }

        public async Task<Location?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<Location>($"api/Locations/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching location {id}: {ex.Message}");
                return null;
            }
           
           
        }

        public async Task<bool> CreateAsync(Location location)
        {
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
           
           
        }

        public async Task<bool> UpdateAsync(Location location)
        {
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
           
           
        }

        public async Task<bool> DeleteAsync(int locationId)
        {
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
           
            
        }
    }
}
