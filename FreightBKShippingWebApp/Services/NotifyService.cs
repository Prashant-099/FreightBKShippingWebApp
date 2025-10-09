using FreightBKShippingWebApp.Models;
using System.Net.Http.Json;

namespace FreightBKShippingWebApp.Services
{
    public class NotifyService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public NotifyService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        // Get all notifies
        public async Task<List<Notify>> GetAllAsync()
        {
            _loadingService.Show("Loading notifies...");
            try
            {
                var response = await _api.GetFromJsonAsync<List<Notify>>("api/Notifies?page=1&pageSize=1000");
                return response ?? new List<Notify>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading notifies: {ex.Message}");
                return new List<Notify>();
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // Get notify by ID
        public async Task<Notify?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading notify...");
            try
            {
                return await _api.GetFromJsonAsync<Notify>($"api/Notifies/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching notify {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // Create notify
        public async Task<bool> CreateAsync(Notify notify)
        {
            _loadingService.Show("Creating notify...");
            try
            {
                var result = await _api.PostAsync<bool, Notify>("api/Notifies", notify);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating notify: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // Update notify
        public async Task<bool> UpdateAsync(Notify notify)
        {
            _loadingService.Show("Updating notify...");
            try
            {
                var result = await _api.PutAsync<bool, Notify>($"api/Notifies/{notify.NotifyId}", notify);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating notify: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // Delete notify
        public async Task<bool> DeleteAsync(int notifyId)
        {
            _loadingService.Show("Deleting notify...");
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Notifies/{notifyId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting notify: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
