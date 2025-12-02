using FreightBKShippingWebApp.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FreightBKShippingWebApp.Services
{
    public class BillService
    {
        private readonly ApiClient _api;

        public BillService(ApiClient api)
        {
            _api = api;
        }

        // ✅ Get all bills (with optional paging)
        public async Task<List<Bill>> GetAllAsync(int page = 1, int pageSize = 100)
        {
         
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
           
        }

        // ✅ Get single bill by ID
        public async Task<Bill?> GetByIdAsync(int id)
        {
         
            try
            {
                return await _api.GetFromJsonAsync<Bill>($"api/Bills/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching bill {id}: {ex.Message}");
                return null;
            }
           
        }

        // ✅ Create new bill
        public async Task<bool> CreateAsync(Bill bill)
        {
           
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
       
        }

        // ✅ Update existing bill
        public async Task<bool> UpdateAsync(Bill bill)
        {
            
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
           
        }

        // ✅ Delete bill by ID
        public async Task<bool> DeleteAsync(int billId)
        {
           
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

        public async Task<bool> ToggleLockAsync(int billId)
        {
            try
            {
                var response = await _api.PostAsync<bool, object>($"api/Bills/{billId}/lock", null);
                return response ;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error toggling bill lock: {ex.Message}");
                return false;
            }
        }
        public async Task<string?> GetEInvoiceRawAsync(int billId)
        {
            try
            {
                return await _api.GetRawStringAsync($"api/Bills/einvoice/{billId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching raw E-Invoice JSON for bill {billId}: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> SaveEInvoiceDataAsync(
       int billId,
       string irn,
       string? ackNo = null,
       DateTime? ackDate = null,
       string? signedInvoice = null,
       string? signedQrCode = null)
        {
            try
            {
                // First, get the existing bill
                var bill = await _api.GetFromJsonAsync<Bill>($"api/Bills/{billId}");
                if (bill == null)
                {
                    Console.WriteLine($"❌ Bill not found: {billId}");
                    return false;
                }

                // Update E-Invoice fields
                bill.BillIrnNo = irn;
                bill.BillAckNo = ackNo;
                bill.BillAckDate = ackDate?.ToString("dd/MM/yyyy HH:mm:ss");
                // Safely handle Base64 QR code
                if (!string.IsNullOrWhiteSpace(signedQrCode))
                {
                    // Convert JWT or any string to bytes
                    bill.BillQRCode = Encoding.UTF8.GetBytes(signedQrCode);
                }
                // Mark as E-Invoice generated
                bill.BillAckDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                //bill.IsEInvoiceGenerated = true;

                // Save the updated bill
                var result = await _api.PutAsync<bool, Bill>($"api/Bills/{billId}", bill);

                if (result)
                    Console.WriteLine($"✅ E-Invoice data saved for Bill {billId}");
                else
                    Console.WriteLine($"❌ Failed to save E-Invoice data for Bill {billId}");

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error saving E-Invoice data for Bill {billId}: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> CancelEInvoiceAsync(int billId)
        {
            try
            {
                var bill = await _api.GetFromJsonAsync<Bill>($"api/Bills/{billId}");
                if (bill == null)
                {
                    Console.WriteLine($"❌ Bill not found: {billId}");
                    return false;
                }

                // Clear IRN fields
                bill.BillIrnNo = null;
                bill.BillAckNo = null;
                bill.BillAckDate = null;
                bill.BillQRCode = null;

                var result = await _api.PutAsync<bool, Bill>($"api/Bills/{billId}", bill);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
                return false;
            }
        }
    }
}
