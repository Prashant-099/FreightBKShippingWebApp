using FreightBKShippingWebApp.Model;
using DevExpress.XtraPrinting.Native;


namespace FreightBKShippingWebApp.Services
{
    public class CompanyService
    {
        private readonly ApiClient _api;
         
        public CompanyService(ApiClient api )
        {
            _api = api;
            
        }

        public async Task<List<Company>> GetAllAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<PagedResponseDto<Company>>("api/Company?page=1&pageSize=1000", useCache: true);
                return response?.Data ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading users: {ex.Message}");
                return new();
            }
           
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<Company>($"api/Company/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching company {id}: {ex.Message}");
                return null;
            }
           
            
        }


        public async Task<bool> CreateAsync(Company company)
        {
            try
            {
                var result = await _api.PostAsync<bool, Company>("api/Company", company);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating company: {ex.Message}");
                return false;
            }
           
           
        }


        public async Task<bool> UpdateAsync(Company company)
        {
            try
            {
                var result = await _api.PutAsync<bool, Company>($"api/Company/{company.CompanyId}", company);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating company: {ex.Message}");
                return false;
            }
           
           
        }

        public async Task<bool> DeleteAsync(int companyId)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Company/{companyId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting company: {ex.Message}");
                return false;
            }
           
           
        }
    }

}