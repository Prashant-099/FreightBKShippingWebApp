using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class JobService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public JobService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        // Get all jobs
        public async Task<List<Job>> GetAllAsync(int page = 1, int pageSize = 1000)
        {
            _loadingService.Show("Loading jobs...");
            try
            {
                var response = await _api.GetFromJsonAsync<List<Job>>(
                    $"api/Job?page={page}&pageSize={pageSize}");
                return response ?? new List<Job>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading jobs: {ex.Message}");
                return new List<Job>();
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // Get a single job by ID
        public async Task<Job?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading job...");
            try
            {
                return await _api.GetFromJsonAsync<Job>($"api/Job/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching job {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // Create a new job
        public async Task<bool> CreateAsync(Job job)
         {
            _loadingService.Show("Creating job...");
            try
            {
                var result = await _api.PostAsync<bool, Job>("api/Job", job);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating job: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // Update an existing job
        public async Task<bool> UpdateAsync(Job job)
        {
            _loadingService.Show("Updating job...");
            try
            {
                var result = await _api.PutAsync<bool, Job>($"api/Job/{job.JobId}", job);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating job: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // Delete a job by ID
        public async Task<bool> DeleteAsync(int jobId)
        {
            _loadingService.Show("Deleting job...");
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Job/{jobId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting job {jobId}: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
