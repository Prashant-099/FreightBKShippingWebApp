using FreightBKShippingWebApp.Model;
using System.Net.Http.Json;

namespace FreightBKShippingWebApp.Services
{
    public class NotifyService
    {
        private readonly ApiClient _api;
         

        public NotifyService(ApiClient api )
        {
            _api = api;
            
        }
        public string? LastError { get; private set; }
        // Get all notifies
        public async Task<List<Notify>> GetAllAsync()
        {
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
           
        }

        // Get notify by ID
        public async Task<Notify?> GetByIdAsync(int id)
        {
           
            try
            {
                return await _api.GetFromJsonAsync<Notify>($"api/Notifies/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching notify {id}: {ex.Message}");
                return null;
            }
           
           
        }

        // Create notify
        public async Task<Notify?> CreateAsync(Notify notify)
        {
            try
            {
                LastError = null;
                var result = await _api.PostAsync<Notify, Notify>("api/Notifies", notify);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error creating notify: {ex.Message}");
                return null;
            }
           
        }

        // Update notify
        public async Task<Notify?> UpdateAsync(Notify notify)
        {
            try
            {
                LastError = null;
                var result = await _api.PutAsync<Notify, Notify>($"api/Notifies/{notify.NotifyId}", notify);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error updating notify: {ex.Message}");
                return null;
            }
           
           
        }

        // Delete notify
        public async Task<(bool Success, string Error)> DeleteAsync(int notifyId)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Notifies/{notifyId}");
                return (true, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting notify: {ex.Message}");
                return (false, ex.Message);
            }
           
        }
    }
}
