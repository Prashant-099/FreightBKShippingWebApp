using FreightBKShippingWebApp.Models;

namespace FreightBKShippingWebApp.Services
{
    public class VesselService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public VesselService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        // 🔹 GET ALL
        public async Task<List<Vessel>> GetAllAsync()
        {
            _loadingService.Show("Loading vessels...");
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
            finally
            {
                _loadingService.Hide();
            }
        }

        // 🔹 GET BY ID
        public async Task<Vessel?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading vessel...");
            try
            {
                return await _api.GetFromJsonAsync<Vessel>($"api/Vessels/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching vessel {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // 🔹 CREATE
        public async Task<bool> CreateAsync(Vessel vessel)
        {
            _loadingService.Show("Creating vessel...");
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
            finally
            {
                _loadingService.Hide();
            }
        }

        // 🔹 UPDATE
        public async Task<bool> UpdateAsync(Vessel vessel)
        {
            _loadingService.Show("Updating vessel...");
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
            finally
            {
                _loadingService.Hide();
            }
        }

        // 🔹 DELETE
        public async Task<bool> DeleteAsync(int vesselId)
        {
            _loadingService.Show("Deleting vessel...");
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
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
