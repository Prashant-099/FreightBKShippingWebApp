using DevExpress.XtraRichEdit.Import.Html;
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
        public async Task<List<Job>> GetAllAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<Job>>("api/Job");
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
        public async Task<(bool Success, string Error)> CreateAsync(Job job)
         {
            try
            {
                var result = await _api.PostAsync<bool, Job>("api/Job", job);
                return (true, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating job: {ex.Message}");
                return (false, ex.Message);
            }
           
           
        }

        // Update an existing job
        public async Task<(bool Success, string Error)> UpdateAsync(Job job)
        {
            try
            {
                var result = await _api.PutAsync<bool, Job>($"api/Job/{job.JobId}", job);
                return (true, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating job: {ex.Message}");
                return (false, ex.Message);
            }
           
            
        }

        // Delete a job by ID
        public async Task<(bool Success, string Error)> DeleteAsync(int jobId)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Job/{jobId}");
                return (true, null);
            }   
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting job {jobId}: {ex.Message}");
                return (false, ex.Message);
            }
           

        }
    }
}
