namespace FreightBKShippingWebApp.Services
{
    using System;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    // Model for API response
    public class ChatwayResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Number { get; set; }

        public bool Success => Status?.Equals("success", StringComparison.OrdinalIgnoreCase) == true;
    }

    public class ChatwayService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://int.chatway.in/api/";

        public ChatwayService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ChatwayResponse> SendFileAsync(
            string username,
            string number,
            string message,
            string token,
            string fileUrl,
            string fileName)
        {
            string responseContent = string.Empty;

            try
            {
                // Build query params
                var requestUrl = $"{_baseUrl}send-file?username={Uri.EscapeDataString(username)}" +
                                 $"&number={Uri.EscapeDataString(number)}" +
                                 $"&message={Uri.EscapeDataString(message)}" +
                                 $"&token={Uri.EscapeDataString(token)}" +
                                 $"&file_url={Uri.EscapeDataString(fileUrl)}" +
                                 $"&file_name={Uri.EscapeDataString(fileName)}";

                var response = await _httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

                responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent); // Inspect API response

                // Deserialize JSON into single object
                var result = JsonSerializer.Deserialize<ChatwayResponse>(
                    responseContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                 
                // If API returns null or invalid object, return error
                return result ?? new ChatwayResponse
                {
                    Status = "error",
                    Message = "Invalid response from API",
                    Number = number
                };
            }
            catch (JsonException jex)
            {
                // Handle JSON parse errors
                return new ChatwayResponse
                {
                    Status = "error",
                    Message = $"JSON parse error: {jex.Message}. Response: {responseContent}",
                    Number = number
                };
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                return new ChatwayResponse
                {
                    Status = "error",
                    Message = $"Exception occurred: {ex.Message}",
                    Number = number
                };
            }
        }

        public class ChatwayBalanceResponse
        {
            public string Status { get; set; }
            public string Message { get; set; }
            public decimal? Balance { get; set; } // depends on actual API structure

            public bool Success => Status?.Equals("success", StringComparison.OrdinalIgnoreCase) == true;
        }
        // 🔹 NEW FUNCTION: Check Balance
        public async Task<string> CheckBalanceAsync(string username, string token)
        {
            try
            {
                var requestUrl = $"{_baseUrl}credits?username={Uri.EscapeDataString(username)}" +
                                 $"&token={Uri.EscapeDataString(token)}";

                var response = await _httpClient.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Balance API Response: {responseContent}");

                using var jsonDoc = JsonDocument.Parse(responseContent);
                var root = jsonDoc.RootElement;

                if (root.TryGetProperty("status", out var statusElem) &&
                    statusElem.GetString()?.ToLower() == "success" &&
                    root.TryGetProperty("credits", out var creditsElem) &&
                    creditsElem.ValueKind == JsonValueKind.Array &&
                    creditsElem.GetArrayLength() > 0)
                {
                    var firstCredit = creditsElem[0];
                    if (firstCredit.TryGetProperty("credits_bal", out var balanceElem))
                    {
                        return balanceElem.GetRawText(); // returns "1855"
                    }
                }

                return "0"; // fallback agar kuch na mile
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }


    }
}
