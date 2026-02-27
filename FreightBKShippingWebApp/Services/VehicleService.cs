using FreightBKShippingWebApp.Model;


namespace FreightBKShippingWebApp.Services
{
    public class VehicleService : BaseService
    {
        private readonly ApiClient _api;

        public VehicleService(
            HttpClient http,
            ApiClient api,
            ITokenProvider tokenProvider) : base(http, tokenProvider)
        {
            _api = api;
        }

        // ✅ Get All Vehicles
        public async Task<List<Vehicle>> GetAllAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<Vehicle>>("api/Vehicles");
                return response ?? new List<Vehicle>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading vehicles: {ex.Message}");
                return new List<Vehicle>();
            }
        }

        // ✅ Get Vehicle By Id
        public async Task<Vehicle?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<Vehicle>($"api/Vehicles/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching vehicle {id}: {ex.Message}");
                return null;
            }
        }

        // ✅ Create Vehicle
        public async Task<bool> CreateAsync(Vehicle vehicle)
        {
            try
            {
                return await _api.PostAsync<bool, Vehicle>("api/Vehicles", vehicle);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating vehicle: {ex.Message}");
                return false;
            }
        }

        // ✅ Update Vehicle
        public async Task<bool> UpdateAsync(Vehicle vehicle)
        {
            try
            {
                return await _api.PutAsync<bool, Vehicle>($"api/Vehicles/{vehicle.VehicleId}", vehicle);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating vehicle: {ex.Message}");
                return false;
            }
        }

        // ✅ Delete Vehicle (Soft delete in backend)
        public async Task<bool> DeleteAsync(int vehicleId)
        {
            try
            {
                return await _api.DeleteAsync<bool>($"api/Vehicles/{vehicleId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting vehicle: {ex.Message}");
                return false;
            }
        }
    }
}