using FreightBKShippingWebApp.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreightBKShippingWebApp.Services
{
    public class BillService
    {
        private readonly ApiClient _api;
        private readonly LoadingService _loadingService;

        public BillService(ApiClient api, LoadingService loadingService)
        {
            _api = api;
            _loadingService = loadingService;
        }

        // ✅ Get all bills (with optional paging)
        public async Task<List<Bill>> GetAllAsync(int page = 1, int pageSize = 100)
        {
            _loadingService.Show("Loading bills...");
            try
            {
                var response = await _api.GetFromJsonAsync<List<Bill>>($"api/Bills?page={page}&pageSize={pageSize}");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading bills: {ex.Message}");
                return new();
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ Get single bill by ID
        public async Task<Bill?> GetByIdAsync(int id)
        {
            _loadingService.Show("Loading bill...");
            try
            {
                return await _api.GetFromJsonAsync<Bill>($"api/Bills/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching bill {id}: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ Create new bill
        public async Task<bool> CreateAsync(Bill bill)
        {
            _loadingService.Show("Creating bill...");
            try
            {
                var result = await _api.PostAsync<bool, Bill>("api/Bills", bill);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating bill: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ Update existing bill
        public async Task<bool> UpdateAsync(Bill bill)
        {
            _loadingService.Show("Updating bill...");
            try
            {
                var result = await _api.PutAsync<bool, Bill>($"api/Bills/{bill.BillId}", bill);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating bill {bill.BillId}: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ Delete bill by ID
        public async Task<bool> DeleteAsync(int billId)
        {
            _loadingService.Show("Deleting bill...");
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Bills/{billId}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting bill {billId}: {ex.Message}");
                return false;
            }
            finally
            {
                _loadingService.Hide();
            }
        }

        // ✅ Get bill details for a specific bill
        public async Task<List<BillDetail>> GetBillDetailsAsync(int billId)
        {
            try
            {
                var bill = await GetByIdAsync(billId);
                return bill?.BillDetails?.ToList() ?? new List<BillDetail>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching bill details: {ex.Message}");
                return new List<BillDetail>();
            }
        }
        public async Task<PrintBillFullDto?> GetPrintableBillAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<PrintBillFullDto>($"api/Bills/print/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching printable bill {id}: {ex.Message}");
                return null;
            }
        }



    }
}
