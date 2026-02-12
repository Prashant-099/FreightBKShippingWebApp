using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class JobService
    {
        private readonly ApiClient _api;

        public JobService(ApiClient api)
        {
            _api = api;
        }

        // Get all jobs
        public async Task<List<Job>> GetAllAsync()
        {
            try
            {
                return await _api.GetFromJsonAsync<List<Job>>("api/Job")
                       ?? new List<Job>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading jobs: {ex.Message}");
                return new List<Job>();
            }
        }

        // Get job by id
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

        // Create
        public async Task<(bool Success, string? Error)> CreateAsync(Job job)
        {
            try
            {
                var result = await _api.PostAsync<bool, Job>("api/Job", job);
                return result
                    ? (true, null)
                    : (false, "API returned failure while creating job");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating job: {ex.Message}");
                return (false, ex.Message);
            }
        }

        // Update
        public async Task<(bool Success, string? Error)> UpdateAsync(Job job)
        {
            try
            {
                var result = await _api.PutAsync<bool, Job>(
                    $"api/Job/{job.JobId}", job);

                return result
                    ? (true, null)
                    : (false, "API returned failure while updating job");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating job: {ex.Message}");
                return (false, ex.Message);
            }
        }

        // Delete
        public async Task<(bool Success, string? Error)> DeleteAsync(int jobId)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Job/{jobId}");
                return result
                    ? (true, null)
                    : (false, "API returned failure while deleting job");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting job {jobId}: {ex.Message}");
                return (false, ex.Message);
            }
        }


        // Get job with container + LRs
        public async Task<JobreportDto?> GetJobWithContainerAsync(int jobId)
        {
            try
            {
                return await _api.GetFromJsonAsync<JobreportDto>(
                    $"api/Job/getjobwithcontainer?jobid={jobId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching job report {jobId}: {ex.Message}");
                return null;
            }
        }

    }
}
