using FreightBKShippingWebApp.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http;
using FreightBKShippingWebApp.Model;
using System.Text.Json;
namespace FreightBKShippingWebApp
{
    public class ApiClient(HttpClient httpClient, ProtectedLocalStorage localStorage, NavigationManager navigationManager, AuthenticationStateProvider authStateProvider)
    {
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public async Task SetAuthorizeHeader()
        {
            try
            {
                var result = await localStorage.GetAsync<LoginResponseModel>("sessionState");
                
                var sessionState = result.Success ? result.Value : null;

                if (sessionState == null || string.IsNullOrEmpty(sessionState.Token))
                {
                    //await ((CustomAuthStateProvider)authStateProvider).MarkUserAsLoggedOut();
                    //navigationManager.NavigateTo("/login");
                    return;
                }

                var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                // Token expired → logout
                if (sessionState.tokenExp <= now)
                {
                    //await ((CustomAuthStateProvider)authStateProvider).MarkUserAsLoggedOut();
                    //navigationManager.NavigateTo("/login");
                    return;
                }

                // Token will expire in < 5 minutes → refresh
                if (sessionState.tokenExp - now < 300)
                {
                    var res = await httpClient.PostAsJsonAsync("api/Auth/refresh-token", new
                    {
                        refreshToken = sessionState.RefreshToken
                    });

                    if (res.IsSuccessStatusCode)
                    {
                        var newSession = await res.Content.ReadFromJsonAsync<LoginResponseModel>();
                        if (newSession != null && !string.IsNullOrEmpty(newSession.Token))
                        {
                            await ((CustomAuthStateProvider)authStateProvider).MarkUserAsAuthenticated(newSession);
                            httpClient.DefaultRequestHeaders.Authorization =
                                new AuthenticationHeaderValue("Bearer", newSession.Token);

                            await localStorage.SetAsync("sessionState", newSession);
                        }
                    }
                    else
                    {
                        //await ((CustomAuthStateProvider)authStateProvider).MarkUserAsLoggedOut();
                        //navigationManager.NavigateTo("/login");
                        return;
                    }
                }
                else
                {
                    // Token still valid
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", sessionState.Token);
                }
                // Check refresh token expiration
                var refreshExpUnix = new DateTimeOffset(sessionState.RefreshtokenExp).ToUnixTimeSeconds();
                if (refreshExpUnix <= now)
                {
                    // Refresh token expired → clear everything & go to login
                    //await ((CustomAuthStateProvider)authStateProvider).MarkUserAsLoggedOut();
                    //navigationManager.NavigateTo("/login");
                    return;
                }

                // Add culture info
                var requestCulture = new RequestCulture(CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture);
                var cultureCookieValue = CookieRequestCultureProvider.MakeCookieValue(requestCulture);
                httpClient.DefaultRequestHeaders.Add(
                    "Cookie",
                    $"{CookieRequestCultureProvider.DefaultCookieName}={cultureCookieValue}"
                );
            }
            catch (Exception)
            {
                navigationManager.NavigateTo("/login");
            }
        }

        public async Task<T?> GetFromJsonAsync<T>(string path)
        {
            await SetAuthorizeHeader();
            Console.WriteLine("=== HTTP Request ===");
            Console.WriteLine("Path: " + path);
            Console.WriteLine("Auth Header: " + httpClient.DefaultRequestHeaders.Authorization);
            try
            {
                return await httpClient.GetFromJsonAsync<T>(path, _jsonOptions);
            }
            catch (HttpRequestException ex)
            {
                // network error, 4xx, 5xx, etc.
                throw new Exception($"Request to '{path}' failed: {ex.Message}", ex);
            }
            catch (NotSupportedException ex)
            {
                // content type isn’t valid JSON
                throw new Exception($"Unsupported content type when calling '{path}'", ex);
            }
            catch (System.Text.Json.JsonException ex)
            {
                // invalid JSON, can’t map to T
                throw new Exception($"Invalid JSON from '{path}'", ex);
            }
        }


        public async Task<T1?> PostAsync<T1, T2>(string path, T2 postModel)
        {
            await SetAuthorizeHeader();

            var res = await httpClient.PostAsJsonAsync(path, postModel, _jsonOptions);
            var content = await res.Content.ReadAsStringAsync();

            Console.WriteLine($"📤 POST {path} => {res.StatusCode}");
            Console.WriteLine($"📥 Raw Content: '{content}'");
            Console.WriteLine($"📥 Content Length: {content?.Length}");
            Console.WriteLine($"📥 Expected Type: {typeof(T1).Name}");

            if (!res.IsSuccessStatusCode)
            {
                Console.WriteLine($"❌ API Error: {res.StatusCode}");
                return default;
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                Console.WriteLine("⚠️ Empty response");
                if (typeof(T1) == typeof(bool))
                    return (T1)(object)true;
                return default;
            }

            // ✅ Handle different return types
            if (typeof(T1) == typeof(bool))
            {
                Console.WriteLine("🔄 Converting to bool");
                return (T1)(object)true;
            }

            if (typeof(T1) == typeof(string))
            {
                return (T1)(object)content;
            }

            try
            {
                // ✅ Use System.Text.Json instead of Newtonsoft
                var result = System.Text.Json.JsonSerializer.Deserialize<T1>(content, _jsonOptions);
                Console.WriteLine($"✅ Deserialization successful: {result != null}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Deserialization failed: {ex.Message}");
                Console.WriteLine($"❌ Content was: '{content}'");

                // If content is "true" but we expected an object
                if (content.Trim().Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("⚠️ Got 'true' string response");
                    if (typeof(T1) == typeof(bool))
                        return (T1)(object)true;
                }

                return default;
            }
        }


        // FOR MULTIFDATA FORM  NOT AS PostAsJsonAsync 
        public async Task<T1?> PostAsync<T1>(string path, HttpContent content)
        {
            await SetAuthorizeHeader();

            var res = await httpClient.PostAsync(path, content);
            var responseContent = await res.Content.ReadAsStringAsync();

            Console.WriteLine($"📤 POST {path} => {res.StatusCode}");
            Console.WriteLine($"📥 Content: {responseContent}");

            if (!res.IsSuccessStatusCode)
                return default;

            try
            {
                // If T1 is string, just return the raw JSON response
                if (typeof(T1) == typeof(string))
                    return (T1)(object)responseContent;

                // Otherwise, deserialize normally
                return System.Text.Json.JsonSerializer.Deserialize<T1>(responseContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Deserialization failed: {ex.Message}");
                return default;
            }
        }

        public async Task<T1> PutAsync<T1>(string path, HttpContent content)
        {
            await SetAuthorizeHeader();
            var res = await httpClient.PutAsync(path, content);
            var responseContent = await res.Content.ReadAsStringAsync();

            Console.WriteLine($"📤 POST {path} => {res.StatusCode}");
            Console.WriteLine($"📥 Content: {responseContent}");

            if (!res.IsSuccessStatusCode)
                return default;

            if (string.IsNullOrWhiteSpace(responseContent))
            {
                if (typeof(T1) == typeof(bool))
                    return (T1)(object)true;
                return default;
            }

            try
            {
                return JsonConvert.DeserializeObject<T1>(responseContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Deserialization failed: {ex.Message}");
                return default;
            }
        }


        public async Task<T1?> PutAsync<T1, T2>(string path, T2 postModel)
        {
            try
            {
                await SetAuthorizeHeader();

                var response = await httpClient.PutAsJsonAsync(path, postModel, _jsonOptions);
                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"📤 PUT {path} => {response.StatusCode}");
                Console.WriteLine($"📥 Content: '{content}'");

                if (response.IsSuccessStatusCode)
                {
                    if (string.IsNullOrWhiteSpace(content))
                    {
                        if (typeof(T1) == typeof(bool))
                            return (T1)(object)true;
                        return default;
                    }

                    if (typeof(T1) == typeof(bool))
                    {
                        return (T1)(object)true;
                    }

                    return System.Text.Json.JsonSerializer.Deserialize<T1>(content, _jsonOptions);
                }
                else
                {
                    Console.WriteLine($"⚠️ PUT failed: {response.StatusCode} - {content}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error in PUT: {ex.Message}");
            }

            return default;
        }


        public async Task<T> DeleteAsync<T>(string path)
        {
            await SetAuthorizeHeader();
            return await httpClient.DeleteFromJsonAsync<T>(path);
        }


        //added by dhruv

        public async Task<T?> SafeGetFromJsonAsync<T>(string path)
        {
            await SetAuthorizeHeader();
            try
            {
                Console.WriteLine($"🔍 Requesting: GET {path}");
                using var response = await httpClient.GetAsync(path, HttpCompletionOption.ResponseHeadersRead);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"❌ HTTP {(int)response.StatusCode}: {response.ReasonPhrase}");
                    return default;
                }

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"📦 Response JSON: {content}");

                if (string.IsNullOrWhiteSpace(content))
                {
                    Console.WriteLine("⚠️ Empty response body.");
                    return default;
                }

                T? result = System.Text.Json.JsonSerializer.Deserialize<T>(content, _jsonOptions);
                Console.WriteLine($"✅ Deserialized type {typeof(T).Name}, result null? {result == null}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Unexpected error: {ex.Message}");
                return default;
            }
        }



        public async Task<byte[]?> SafeGetBytesAsync(string path)
        {
            await SetAuthorizeHeader();
            try
            {
                using var response = await httpClient.GetAsync(path, HttpCompletionOption.ResponseHeadersRead);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"❌ HTTP {(int)response.StatusCode}: {response.ReasonPhrase}");
                    return null;
                }

                return await response.Content.ReadAsByteArrayAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error in SafeGetBytesAsync: {ex.Message}");
                return null;
            }
        }

    }
}