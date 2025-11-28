using FreightBKShippingWebApp.Models;
using FreightBKShippingWebApp.Services;
using System.Net.Http;
using System.Text.Json;
using static FreightBKShippingWebApp.Components.Pages.Account.AccountAddEditPage;

public class GstinService
{
    private readonly ToasteService _toastService;
    private readonly LoadingService _loadingService;

    public GstinService(ToasteService toastService, LoadingService loadingService)
    {
        _toastService = toastService;
        _loadingService = loadingService;
    }

    public async Task<GstinData?> FetchGstinDetails(string gstin, EinvConfig einvConfig)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(gstin))
        {
            _toastService.Warning("Please enter GST Number");
            return null;
        }

        if (einvConfig == null)
        {
            _toastService.Warning("E-Invoice configuration not loaded");
            return null;
        }

        if (string.IsNullOrWhiteSpace(einvConfig.AuthToken))
        {
            _toastService.Warning("Auth Token not found. Please generate token first.");
            return null;
        }

        _loadingService.Show("Fetching GSTIN details...");

        try
        {
            using var httpClient = new HttpClient();

            string apiUrl = $"{einvConfig.BaseUrl}Master/gstin/{gstin}";

            httpClient.DefaultRequestHeaders.Add("aspid", einvConfig.AspUserId);
            httpClient.DefaultRequestHeaders.Add("password", einvConfig.Password);
            httpClient.DefaultRequestHeaders.Add("Gstin", einvConfig.Gstin);
            httpClient.DefaultRequestHeaders.Add("user_name", einvConfig.Username);
            httpClient.DefaultRequestHeaders.Add("AuthToken", einvConfig.AuthToken);

            var response = await httpClient.GetAsync(apiUrl);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API Error {response.StatusCode}: {responseBody}");
            }

            using var doc = JsonDocument.Parse(responseBody);
            var root = doc.RootElement;

            string statusStr = root.GetProperty("Status").GetString() ?? "0";
            int status = int.Parse(statusStr);

            if (status != 1)
            {
                var errorDetails = root.TryGetProperty("ErrorDetails", out var err)
                    ? err.ToString()
                    : "Unknown error";
                _toastService.Error($"Failed to fetch GSTIN: {errorDetails}");
                return null;
            }

            string dataJson = root.GetProperty("Data").GetString() ?? "{}";

            var gstinData = JsonSerializer.Deserialize<GstinData>(dataJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return gstinData;
        }
        catch (Exception ex)
        {
            _toastService.Error($"Error: {ex.Message}");
            Console.WriteLine($"GSTIN Fetch Error: {ex}");
            return null;
        }
        finally
        {
            _loadingService.Hide();
        }
    }
}
