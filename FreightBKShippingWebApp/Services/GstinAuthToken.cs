namespace FreightBKShippingWebApp.Services
{
    using FreightBKShippingWebApp.Models;
    using System.Net.Http;
    using System.Text.Json;
    using static FreightBKShippingWebApp.Components.Pages.Company.ConfigAddEditPage;

    public class GstinAuthTokenService
    {
        private readonly ToasteService _toastService;
        private readonly LoadingService _loadingService;
        private readonly EinvConfigService _configService;

        public GstinAuthTokenService(ToasteService toastService,
                               LoadingService loadingService,
                               EinvConfigService configService)
        {
            _toastService = toastService;
            _loadingService = loadingService;
            _configService = configService;
        }

        // 👉 Main function to call publicly
        public async Task<AuthTokenResponse?> GenerateAuthTokenAsync(EinvConfig config)
        {
            if (!Validate(config)) return null;

            _loadingService.Show("Generating Auth Token...");

            try
            {
                using var httpClient = new HttpClient();

                // Headers
                httpClient.DefaultRequestHeaders.Add("aspid", config.AspUserId);
                httpClient.DefaultRequestHeaders.Add("password", config.Password);
                httpClient.DefaultRequestHeaders.Add("Gstin", config.Gstin);
                httpClient.DefaultRequestHeaders.Add("user_name", config.Username);
                httpClient.DefaultRequestHeaders.Add("eInvPwd", config.eInvPwd);

                // API call
                var response = await httpClient.GetAsync(config.AuthUrl);
                var responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception(responseBody);

                // Deserialize
                var tokenResponse = JsonSerializer.Deserialize<AuthTokenResponse>(responseBody,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (tokenResponse?.Status == 1 && tokenResponse.Data != null)
                {
                    // Populate model
                    config.AppKey = tokenResponse.Data.ClientId;
                    config.AuthToken = tokenResponse.Data.AuthToken;
                    config.Sek = tokenResponse.Data.Sek;
                    config.EInvoiceTokenExp = tokenResponse.Data.TokenExpiry;

                    // Save to DB
                    var result = await _configService.SaveAsync(config);

                    if (result)
                        _toastService.Success("Token saved to database");
                    else
                        _toastService.Error("Failed to save token to database");

                    return tokenResponse;
                }
                else
                {
                    var err = tokenResponse?.ErrorDetails?.ToString() ?? "Unknown error";
                    throw new Exception(err);
                }


            }
            catch (Exception ex)
            {
                _toastService.Error($"Token generation failed: {ex.Message}");
                return null;
            }
            finally
            {
                _loadingService.Hide();
            }
        }


        // ❗ Validation inside service (UI-independent)
        private bool Validate(EinvConfig config)
        {
            if (string.IsNullOrWhiteSpace(config.AuthUrl))
            {
                _toastService.Warning("Please enter Auth URL");
                return false;
            }

            if (string.IsNullOrWhiteSpace(config.Gstin))
            {
                _toastService.Warning("Please enter GSTIN");
                return false;
            }

            if (string.IsNullOrWhiteSpace(config.Username))
            {
                _toastService.Warning("Please enter Username");
                return false;
            }

            if (string.IsNullOrWhiteSpace(config.eInvPwd))
            {
                _toastService.Warning("Please enter eInv Password");
                return false;
            }

            if (string.IsNullOrWhiteSpace(config.AspUserId))
            {
                _toastService.Warning("Please enter ASP User ID");
                return false;
            }

            if (string.IsNullOrWhiteSpace(config.Password))
            {
                _toastService.Warning("Please enter ASP Password");
                return false;
            }

            return true;
        }
    }

}
