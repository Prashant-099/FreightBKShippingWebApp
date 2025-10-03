using FreightBKShippingWebApp.Model;
using DevExpress.XtraPrinting.Native;


namespace FreightBKShippingWebApp.Services
{
    public class CompanyService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;
        public CompanyService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            _loadingService.Show("Loading companies...");
            try
            {
                var response = await _api.GetFromJsonAsync<PagedResponseDto<Company>>("api/Company?page=1&pageSize=1000");
                return response?.Data ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading users: {ex.Message}");
                return new();
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading company...");
            try
            {
                return await _api.GetFromJsonAsync<Company>($"api/Company/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching company {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }


        public async Task<bool> CreateAsync(Company company)
        {
            _loadingService.Show("Creating company...");
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
            finally
            {
                _loadingService.Hide();
            }
        }


        public async Task<bool> UpdateAsync(Company company)
        {
            _loadingService.Show("Updating company...");
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
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> DeleteAsync(int companyId)
        {
            _loadingService.Show("Deleting company...");
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
            finally
            {
                _loadingService.Hide();
            }
        }
    }

}