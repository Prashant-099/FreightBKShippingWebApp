
using FreightBKShippingWebApp;
using FreightBKShippingWebApp.Model;
using System.Net;
using System.Net.Mail;

namespace FreightBKShippingWebApp.Services
{
    public class SendWpMailService
    {
        private readonly ApiClient _apiClient;

        public SendWpMailService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<SendWpMail>> GetAllAsync()
        {
            try
            {
                var response = await _apiClient.GetFromJsonAsync<PagedResponseDto<SendWpMail>>("api/SendWpMail?page=1&pageSize=1000");
                return response?.Data ?? new();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading mails: {ex.Message}");
                return new();
            }
        }
        public async Task<SendWpMail?> GetByIdAsync(int id)
        {
            try
            {
                var result = await _apiClient.GetFromJsonAsync<SendWpMail>($"api/SendWpMail/{id}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching SendWpMail by Id: {ex.Message}");
                return null;
            }
        }
        public async Task<List<SendWpMail>> GetByCompanyAsync()
        {
            try
            {
                var response = await _apiClient.GetFromJsonAsync<List<SendWpMail>>("api/SendWpMail/company");
                return response ?? new List<SendWpMail>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching company data: {ex.Message}");
                return new List<SendWpMail>();
            }
           
        }
        public async Task<bool> CreateAsync(SendWpMail mail)
        {
           
            try
            {
                var result = await _apiClient.PostAsync<SendWpMail, SendWpMail>("api/SendWpMail", mail);
                return result != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating mail: {ex.Message}");
                return false;
            }
          
        }

        public async Task<bool> UpdateAsync(SendWpMail mail)
        {
          
            try
            {
                var result = await _apiClient.PutAsync<SendWpMail, SendWpMail>($"api/SendWpMail/{mail.SendWpMailId}", mail);
                return result != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error updating mail: {ex.Message}");
                return false;
            }
           
        }

        public async Task<bool> DeleteAsync(int id)
        {
          
            try
            {
                var result = await _apiClient.DeleteAsync<bool>($"api/SendWpMail/{id}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting mail: {ex.Message}");
                return false;
            }
            
        }

        // ================= New: Config =================
        public async Task<SendWpMailConfigDto?> GetConfigAsync()
        {
            try
            {
                return await _apiClient.GetFromJsonAsync<SendWpMailConfigDto>("api/SendWpMail/config");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error fetching config: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> SaveConfigAsync(SendWpMailConfigDto config)
        {
          
            try
            {
                var result = await _apiClient.PostAsync<SendWpMailConfigDto, SendWpMailConfigDto>("api/SendWpMail/config", config);
                return result != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error saving config: {ex.Message}");
                return false;
            }
          
        }

        // ================= New: Send Email =================
        public async Task<bool> SendEmailAsync(SendEmailRequestDto dto)
        {
           
            try
            {
                var result = await _apiClient.PostAsync<string, SendEmailRequestDto>("api/SendWpMail/send", dto);
                return result != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error sending email: {ex.Message}");
                return false;
            }
           
        }


    }

}
