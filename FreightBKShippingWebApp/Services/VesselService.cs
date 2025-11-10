using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class VesselService
    {
        private readonly ApiClient _api;
         

        public VesselService(ApiClient api )
        {
            _api = api;
            
        }

        // 🔹 GET ALL
        public async Task<List<Vessel>> GetAllAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<Vessel>>("api/Vessels?page=1&pageSize=1000");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading vessels: {ex.Message}");
                return new();
            }
           
           
        }

        // 🔹 GET BY ID
        public async Task<Vessel?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<Vessel>($"api/Vessels/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching vessel {id}: {ex.Message}");
                return null;
            }
           
           
        }

        // 🔹 CREATE
        public async Task<bool> CreateAsync(Vessel vessel)
        {
            try
            {
                var result = await _api.PostAsync<bool, Vessel>("api/Vessels", vessel);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating vessel: {ex.Message}");
                return false;
            }
           
           
        }

        // 🔹 UPDATE
        public async Task<bool> UpdateAsync(Vessel vessel)
        {
            try
            {
                var result = await _api.PutAsync<bool, Vessel>($"api/Vessels/{vessel.VesselId}", vessel);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating vessel: {ex.Message}");
                return false;
            }
           
          
        }

        // 🔹 DELETE
        public async Task<bool> DeleteAsync(int vesselId)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Vessels/{vesselId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting vessel: {ex.Message}");
                return false;
            }
           
         
        }
    }
}
