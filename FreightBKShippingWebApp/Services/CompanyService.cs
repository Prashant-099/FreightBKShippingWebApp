using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class CompanyService
    {
        private readonly ApiClient _api;

        public CompanyService(ApiClient api)
        {
            _api = api;
        }

        // ===============================
        // GET ALL
        // ===============================
        public async Task<List<Company>> GetAllAsync()
        {
            try
            {
                var response = await _api
                    .GetFromJsonAsync<PagedResponseDto<Company>>(
                        "api/Company?page=1&pageSize=1000");

                return response?.Data ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading companies: {ex.Message}");
                return new();
            }
        }

        // ===============================
        // GET BY ID
        // ===============================
        public async Task<Company?> GetByIdAsync(int id)
        {
            try
            {
                return await _api
                    .GetFromJsonAsync<Company>($"api/Company/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching company {id}: {ex.Message}");
                return null;
            }
        }

        // ===============================
        // CREATE
        // ===============================
        public async Task<(bool Success, int? CompanyId, string? Error)> CreateAsync(Company company)
        {
            try
            {
                var result = await _api
                    .PostAsync<IdResponseDto, Company>(
                        "api/Company", company);

                return (true, result.CompanyId, null);
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"❌ Error creating company: {ex.Message}");
                return (false, null, ex.Message);
            }
        }

        // ===============================
        // UPDATE (Company User)
        // ===============================
        public async Task<(bool Success, int? CompanyId, string? Error)> UpdateAsync(Company company)
        {
            try
            {
                var result = await _api
                    .PutAsync<IdResponseDto, Company>(
                        $"api/Company/{company.CompanyId}", company);
                return (true, result.CompanyId, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating company: {ex.Message}");
                return (false, null, ex.Message);
            }
        }

        // ===============================
        // UPDATE (Super Admin)
        // ===============================
        public async Task<(bool Success, int? CompanyId, string? Error)> UpdateByAdminAsync(Company company)
        {
            try
            {
                var result = await _api
                    .PutAsync<IdResponseDto, Company>(
                        $"api/Company/{company.CompanyId}/admin",
                        company);
                return (true, result.CompanyId, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating company (admin): {ex.Message}");
                return (false, null, ex.Message);
            }
        }

        // ===============================
        // DELETE
        // ===============================
        public async Task<bool> DeleteAsync(int companyId)
        {
            try
            {
                return await _api
                    .DeleteAsync<bool>($"api/Company/{companyId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting company: {ex.Message}");
                return false;
            }
        }
    }
    public class IdResponseDto
    {
        public int CompanyId { get; set; }
    }

}
