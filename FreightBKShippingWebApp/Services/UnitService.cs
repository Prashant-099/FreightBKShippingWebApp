
using FreightBKShippingWebApp.Models;
using System.Net.Http.Json;

namespace FreightBKShippingWebApp.Services
{
    public class UnitService
    {
        private readonly ApiClient _api; 
         

        public UnitService(ApiClient api )
        {
            _api = api;
            
        }

        // GET: All Units
        public async Task<List<Unit>> GetAllAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<Unit>>("api/Units?page=1&pageSize=1000");
                return response ?? new List<Unit>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading units: {ex.Message}");
                return new List<Unit>();
            }
           
            
        }

        // GET: Unit by Id
        public async Task<Unit?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<Unit>($"api/Units/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching unit {id}: {ex.Message}");
                return null;
            }
           
           
        }

        // POST: Create Unit
        public async Task<bool> CreateAsync(Unit unit)
        {
            try
            {
                var result = await _api.PostAsync<bool, Unit>("api/Units", unit);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating unit: {ex.Message}");
                return false;
            }
           
        }

        // PUT: Update Unit
        public async Task<bool> UpdateAsync(Unit unit)
        {
            try
            {
                var result = await _api.PutAsync<bool, Unit>($"api/Units/{unit.UnitId}", unit);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating unit: {ex.Message}");
                return false;
            }
           
           
        }

        // DELETE: Delete Unit
        public async Task<bool> DeleteAsync(int unitId)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Units/{unitId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting unit: {ex.Message}");
                return false;
            }
           
           
        }
    }
}
