using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class ContainerAddServices
    {
        private readonly ApiClient _api;

        public ContainerAddServices(ApiClient api)
        {
            _api = api;
        }

        // =========================
        // GET ALL LRs
        // =========================
        public async Task<List<Lr>> GetAllAsync(int page = 1, int pageSize = 1000)
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<Lr>>(
                    $"api/ContainerAdd?page={page}&pageSize={pageSize}");

                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading LRs: {ex.Message}");
                return new();
            }
        }

        // =========================
        // GET LR BY ID
        // =========================
        public async Task<Lr?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<Lr>($"api/ContainerAdd/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching LR {id}: {ex.Message}");
                return null;
            }
        }

        // =========================

        public async Task<List<Lr>> GetByJobIdAsync(int jobId)
        {
            try
            {
                // 🔹 Call API endpoint that returns all LR rows for this JobId
                return await _api.GetFromJsonAsync<List<Lr>>($"api/ContainerAdd/job/{jobId}")
                       ?? new List<Lr>(); // agar null aaye to empty list return
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching LR list for Job {jobId}: {ex.Message}");
                return new List<Lr>();
            }
        }

        // CREATE LR
        // =========================
        public async Task<Lr?> CreateAsync(Lr lr)
        {
            try
            {
                var created = await _api.PostAsync<Lr, Lr>(
                    "api/ContainerAdd", lr);

                return created;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating LR: {ex.Message}");
                return null;
            }
        }

        // =========================
        // UPDATE LR
        // =========================
        public async Task<Lr?> UpdateAsync(Lr lr)
        {
            try
            {
                var result = await _api.PutAsync<Lr, Lr>(
                    $"api/ContainerAdd/{lr.LrId}", lr);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating LR: {ex.Message}");
                return null;
            }
        }

        // =========================
        // DELETE LR
        // =========================
        public async Task<(bool Success, string? Error)> DeleteAsync(int lrId)
        {
            try
            {
                await _api.DeleteAsync<bool>($"api/ContainerAdd/{lrId}");
                return (true, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting LR: {ex.Message}");
                return (false, ex.Message);
            }
        }
    }
}
