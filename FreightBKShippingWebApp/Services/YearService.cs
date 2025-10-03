using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class YearService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public YearService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        public async Task<List<YearModel>> GetAllAsync()
        {
            _loadingService.Show("Loading years...");
            try
            {
                var response = await _api.GetFromJsonAsync<List<YearModel>>("api/Years?page=1&pageSize=1000");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading years: {ex.Message}");
                return new();
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<YearModel?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading year...");
            try
            {
                return await _api.GetFromJsonAsync<YearModel>($"api/Years/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching year {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> CreateAsync(YearModel year)
        {
            _loadingService.Show("Creating year...");
            try
            {
                var result = await _api.PostAsync<bool, YearModel>("api/Years", year);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating year: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> UpdateAsync(YearModel year)
        {
            _loadingService.Show("Updating year...");
            try
            {
                var result = await _api.PutAsync<bool, YearModel>($"api/Years/{year.YearId}", year);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating year: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        public async Task<bool> DeleteAsync(int yearId)
        {
            _loadingService.Show("Deleting year...");
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Years/{yearId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting year: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }
    }
}
