using FreightBKShippingWebApp.Model;
using FreightBKShippingWebApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreightBKShippingWebApp.Services
{
    public class JournalService
    {
        private readonly ApiClient _api;

        public JournalService(ApiClient api)
        {
            _api = api;
        }

        public string? LastError { get; private set; }

        // ✅ Get all journals
        public async Task<List<Journal>> GetAllAsync()
        {
            try
            {
                var response = await _api.GetFromJsonAsync<List<Journal>>("api/Journals");
                return response ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading journals: {ex.Message}");
                return new();
            }
        }

        // ✅ Get journal by ID
        public async Task<Journal?> GetByIdAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<Journal>($"api/Journals/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching journal {id}: {ex.Message}");
                return null;
            }
        }

        // ✅ Create journal
        public async Task<bool> CreateAsync(Journal journal)
        {
            try
            {
                LastError = null;
                var result = await _api.PostAsync<bool, Journal>("api/Journals", journal);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error creating journal: {ex.Message}");
                return false;
            }
        }

        // ✅ Update journal
        public async Task<bool> UpdateAsync(Journal journal)
        {
            try
            {
                LastError = null;
                var result = await _api.PutAsync<bool, Journal>($"api/Journals/{journal.JournalId}", journal);
                return result;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error updating journal {journal.JournalId}: {ex.Message}");
                return false;
            }
        }

        // ✅ Delete journal 
        public async Task<(bool Success, string Error)> DeleteAsync(int journalId)
        {
            try
            {
                var result = await _api.DeleteAsync<bool>($"api/Journals/{journalId}");
                return (true, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting journal {journalId}: {ex.Message}");
                return (false, ex.Message);
            }
        }

        // ✅ Toggle lock / unlock
        public async Task<bool> ToggleLockAsync(int journalId)
        {
            try
            {
                var response = await _api.PostAsync<bool, object>($"api/Journals/{journalId}/lock", null);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error toggling journal lock: {ex.Message}");
                return false;
            }
        }
        public async Task<PrintJournalFullDto?> GetPrintableBillAsync(int id)
        {
            try
            {
                return await _api.GetFromJsonAsync<PrintJournalFullDto>($"api/Journals/print/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching printable bill {id}: {ex.Message}");
                return null;
            }
        }

        // ✅ Get BillRefDetails for a Journal
        public async Task<List<BillRefDetail>> GetBillRefDetailsAsync(int journalId)
        {
            try
            {
                var journal = await GetByIdAsync(journalId);
                return journal?.BillRefDetails?.ToList() ?? new List<BillRefDetail>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching bill ref details: {ex.Message}");
                return new List<BillRefDetail>();
            }
        }

        public async Task<bool> ExistsAsync(    string journalNo,    int? branchId,    int? voucherId,    int yearId)
        {
            try
            {
                return await _api.GetFromJsonAsync<bool>(
                    $"api/Journals/exists?" +
                    $"journalNo={Uri.EscapeDataString(journalNo)}" +
                    $"&branchId={branchId}" +
                    $"&voucherId={voucherId}" +
                    $"&yearId={yearId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error checking journal exists: {ex.Message}");
                return false;
            }
        }

        public async Task<BulkJournalImportResultDto?> BulkCreateAsync(List<Journal> journals)
        {
            try
            {
                LastError = null;

                return await _api.PostAsync<BulkJournalImportResultDto, List<Journal>>(
                    "api/Journals/bulk",
                    journals);
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                Console.WriteLine($"❌ Error bulk creating journals: {ex.Message}");
                return null;
            }
        }
        public class BulkJournalImportResultDto
        {
            public int TotalCount { get; set; }
            public int SuccessCount { get; set; }
            public int FailCount { get; set; }
            public List<BulkJournalResultItemDto> Items { get; set; } = new();
        }

        public class BulkJournalResultItemDto
        {
            public string? JournalNoInput { get; set; }   // Excel se aaya Receipt No (match ke liye)
            public bool Success { get; set; }
            public int JournalId { get; set; }
            public string? JournalNo { get; set; }
            public string? Error { get; set; }
        }
    }
}
