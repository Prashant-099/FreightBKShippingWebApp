using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class JobService
    {
        private readonly ApiClient _api;
         

        public JobService(ApiClient api )
        {
            _api = api;
            
        }

        // Get all jobs
        public async Task<List<Job>> GetAllAsync(int page = 1, int pageSize = 1000)
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<Job>>(
                    $"api/Job?page={page}&pageSize={pageSize}", useCache: true);
                return response ?? new List<Job>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading jobs: {ex.Message}");
                return new List<Job>();
            }
           
            
        }

        // Get a single job by ID
        public async Task<Job?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<Job>($"api/Job/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching job {id}: {ex.Message}");
                return null;
            }
           
            
        }

        // Create a new job
        public async Task<bool> CreateAsync(Job job)
         {
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
           
           
        }

        // Update an existing job
        public async Task<bool> UpdateAsync(Job job)
        {
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
           
            
        }

        // Delete a job by ID
        public async Task<bool> DeleteAsync(int jobId)
        {
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
           

        }
    }
}
