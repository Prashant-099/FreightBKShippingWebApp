using Newtonsoft.Json;
using System.Net.Http.Headers;
using FreightBKShippingWebApp.Model;

namespace FreightBKShippingWebApp.Services
{
    public class AuthTokenService
    {
        private readonly HttpClient _http;

        public AuthTokenService(HttpClient http)
        {
            _http = http;
        }

        public async Task<AuthTokenResponse> GetAuthTokenAsync(eInvoiceSession session)
        {
            try
            {
                // Create a NEW HttpRequestMessage to avoid header conflicts
                var request = new HttpRequestMessage(HttpMethod.Get, session.eInvApiSetting.AuthUrl);

                // Add headers in correct order (same as Postman)
                request.Headers.Add("GSTIN", session.eInvApiLoginDetails.Gstin);
                request.Headers.Add("User_Name", session.eInvApiSetting.user_name);
                request.Headers.Add("eInvPwd", session.eInvApiSetting.eInvPwd);
                request.Headers.Add("aspid", session.eInvApiSetting.aspid);
                request.Headers.Add("Password", session.eInvApiSetting.Password);

                // Add GSPName if available
                if (!string.IsNullOrEmpty(session.eInvApiSetting.GspName))
                {
                    request.Headers.Add("GSPName", session.eInvApiSetting.GspName);
                }

                // Set Accept header
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



                // Send request
                var response = await _http.SendAsync(request);

                // Read response content
                var result = await response.Content.ReadAsStringAsync();


                // Check status code
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"API Error {response.StatusCode}: {result}");
                }

                // Deserialize response
                var tokenResponse = JsonConvert.DeserializeObject<AuthTokenResponse>(result);

                if (tokenResponse == null)
                {
                    throw new Exception("Failed to parse response");
                }

                return tokenResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAuthToken Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw;
            }
        }

    }
}