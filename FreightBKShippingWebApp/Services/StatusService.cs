using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class StatusService
    {
        private readonly ApiClient _api;

        public StatusService(ApiClient api)
        {
            _api = api;
        }

        public async Task<List<Status>> GetAllAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<Status>>("api/Status");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading status list: {ex.Message}");
                return new();
            }
        }

        public async Task<Status?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<Status>($"api/Status/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching status {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> CreateAsync(Status status)
        {
            try
            {
                var result = await _api.PostAsync<bool, Status>("api/Status", status);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating status: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Status status)
        {
            try
            {
                var result = await _api.PutAsync<bool, Status>($"api/Status/{status.StatusId}", status);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating status: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int statusId)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Status/{statusId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting status: {ex.Message}");
                return false;
            }
        }
    }
}
