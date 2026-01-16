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
        // ✅ In-memory cache for dropdown data
        private readonly Dictionary<string, (object Data, DateTime CachedAt)> _cache = new();
        private readonly TimeSpan _cacheExpiry = TimeSpan.FromMinutes(5);
        private bool _isRefreshing = false; // Prevent concurrent refresh attempts
        private readonly SemaphoreSlim _refreshSemaphore = new(1, 1);
        private readonly IBranchContext branchContext;
        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public async Task SetAuthorizeHeader()
        { // Enable compression
            if (!httpClient.DefaultRequestHeaders.AcceptEncoding.Any())
            {
                httpClient.DefaultRequestHeaders.AcceptEncoding.Add(
                    new System.Net.Http.Headers.StringWithQualityHeaderValue("gzip"));
                httpClient.DefaultRequestHeaders.AcceptEncoding.Add(
                    new System.Net.Http.Headers.StringWithQualityHeaderValue("deflate"));
            }
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

                var refreshExpUnix = new DateTimeOffset(sessionState.RefreshtokenExp).ToUnixTimeSeconds();
                if (refreshExpUnix <= now)
                {
                    Console.WriteLine("🔴 Refresh token expired, logging out");
                    await ((CustomAuthStateProvider)authStateProvider).MarkUserAsLoggedOut();
                    navigationManager.NavigateTo("/login", true);
                    return;
                }
                // 2. Check if access token is expired
                if (sessionState.tokenExp <= now)
                {
                    Console.WriteLine("🔄 Access token expired, attempting refresh");
                    await RefreshAccessToken(sessionState);
                    return;
                }

                // 3. Proactively refresh if expiring soon (< 5 minutes)
                if (sessionState.tokenExp - now < 300)
                {
                    Console.WriteLine($"⚠️ Access token expiring soon ({(sessionState.tokenExp - now) / 60:F1} min), refreshing...");
                    await RefreshAccessToken(sessionState);
                    return;
                }

                // 4. Token is still valid, set authorization header
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", sessionState.Token);


                // 🔹 7️⃣ **HERE ADD THE BRANCH AUTO-SELECT CODE**
                if (sessionState.Branches != null && sessionState.Branches.Count == 1 && !sessionState.ActiveBranchId.HasValue)
                {
                    sessionState.ActiveBranchId = sessionState.Branches.First().BranchId;
                    await localStorage.SetAsync("sessionState", sessionState);
                }

                // Add culture info
                AddCultureHeader();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error in SetAuthorizeHeader: {ex.Message}");
                navigationManager.NavigateTo("/login");
            }
        }

        private void SetBranchHeader()
        {
            httpClient.DefaultRequestHeaders.Remove("X-Branch-Id");

            if (branchContext.BranchId > 0)
            {
                httpClient.DefaultRequestHeaders.Add(
                    "X-Branch-Id",
                    branchContext.BranchId.ToString()
                );

                Console.WriteLine($"🌿 X-Branch-Id set: {branchContext.BranchId}");
            }
        }

        private async Task RefreshAccessToken(LoginResponseModel sessionState)
        {
            // Use semaphore to prevent concurrent refresh attempts
            if (!await _refreshSemaphore.WaitAsync(0))
            {
                Console.WriteLine("⏳ Already refreshing, waiting...");
                await _refreshSemaphore.WaitAsync(); // Wait for the ongoing refresh
                _refreshSemaphore.Release();

                // Re-fetch session after refresh completes
                var result = await localStorage.GetAsync<LoginResponseModel>("sessionState");
                if (result.Success && result.Value != null)
                {
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", result.Value.Token);
                }
                return;
            }

            try
            {
                Console.WriteLine("🔄 Sending refresh token request");

                // Create a new HttpClient instance without auth header for refresh
                using var refreshClient = new HttpClient { BaseAddress = httpClient.BaseAddress };

                var refreshRequest = new { refreshToken = sessionState.RefreshToken };
                var response = await refreshClient.PostAsJsonAsync("api/Auth/refresh-token", refreshRequest, _jsonOptions);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"✅ Refresh successful");

                    var newSession = System.Text.Json.JsonSerializer.Deserialize<LoginResponseModel>(content, _jsonOptions);

                    if (newSession != null && !string.IsNullOrEmpty(newSession.Token))
                    {
                        // Update session state in storage
                        //await ((CustomAuthStateProvider)authStateProvider).UpdateSession(newSession);

                        // Update auth state provider
                        await ((CustomAuthStateProvider)authStateProvider).MarkUserAsAuthenticated(newSession);

                        // Set new authorization header
                        httpClient.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", newSession.Token);

                        var expiresAt = DateTimeOffset.FromUnixTimeSeconds(newSession.tokenExp);
                        Console.WriteLine($"✅ New token expires at: {expiresAt:yyyy-MM-dd HH:mm:ss} UTC");
                    }
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"❌ Refresh failed: {response.StatusCode} - {errorContent}");

                    await ((CustomAuthStateProvider)authStateProvider).MarkUserAsLoggedOut();
                    navigationManager.NavigateTo("/login", true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Refresh token error: {ex.Message}");
                await ((CustomAuthStateProvider)authStateProvider).MarkUserAsLoggedOut();
                navigationManager.NavigateTo("/login", true);
            }
            finally
            {
                _refreshSemaphore.Release();
            }
        }

        private void AddCultureHeader()
        {
            // Remove existing Cookie header if present
            httpClient.DefaultRequestHeaders.Remove("Cookie");

            var requestCulture = new RequestCulture(CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture);
            var cultureCookieValue = CookieRequestCultureProvider.MakeCookieValue(requestCulture);
            httpClient.DefaultRequestHeaders.Add(
                "Cookie",
                $"{CookieRequestCultureProvider.DefaultCookieName}={cultureCookieValue}"
            );
        }
        public async Task<T?> GetFromJsonAsync<T>(string path, bool useCache = false)
        {
            await SetAuthorizeHeader();

            Console.WriteLine("=== HTTP Request ===");
            Console.WriteLine("Path: " + path);
            Console.WriteLine("Auth Header: " + httpClient.DefaultRequestHeaders.Authorization);
            // ✅ Check cache first
            if (useCache && _cache.TryGetValue(path, out var cached))
            { 
                if (DateTime.UtcNow - cached.CachedAt < _cacheExpiry)
                {
                    Console.WriteLine($"✅ Cache hit: {path}");
                    return (T)cached.Data;
                }
                _cache.Remove(path); // Expired
            }

            Console.WriteLine($"🔍 GET {path}");
            try
            {
                var res = await httpClient.GetAsync(path);

               // Console.WriteLine("=== HTTP Response ===");
               // Console.WriteLine("Status Code: " + res.StatusCode);

                var content = await res.Content.ReadAsStringAsync();
                //  Console.WriteLine("Raw JSON Response:");
                //  Console.WriteLine(content);
                if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"ℹ️ 404 Not Found for {path} → returning null/default");
                    return default;
                }
                res.EnsureSuccessStatusCode(); // Throws HttpRequestException for non-success codes

                if (string.IsNullOrWhiteSpace(content))
                {
                    Console.WriteLine("⚠️ Response content is empty.");
                    return default;
                }

                try
                {
                    using var doc = System.Text.Json.JsonDocument.Parse(content);

                    // Handle paged responses with "data" property
                    if (doc.RootElement.ValueKind == System.Text.Json.JsonValueKind.Object &&
                        doc.RootElement.TryGetProperty("data", out var dataProp))
                    {
                        var rawData = dataProp.GetRawText();

                        // If T is a paged wrapper, deserialize the full response
                        if (typeof(T).IsGenericType &&
                            typeof(T).GetGenericTypeDefinition() == typeof(PagedResponseDto<>))
                        {
                            var result = System.Text.Json.JsonSerializer.Deserialize<T>(content, _jsonOptions);

                            // ✅ Cache result
                            if (useCache && result != null)
                            {
                                _cache[path] = (result, DateTime.UtcNow);
                            }

                            return result;
                        }

                        // Otherwise, deserialize only the "data" array
                        var dataResult = System.Text.Json.JsonSerializer.Deserialize<T>(rawData, _jsonOptions);

                        // ✅ Cache result
                        if (useCache && dataResult != null)
                        {
                            _cache[path] = (dataResult, DateTime.UtcNow);
                        }

                        return dataResult;
                    }

                    // Fallback: deserialize full content (plain array or object)
                    var finalResult = System.Text.Json.JsonSerializer.Deserialize<T>(content, _jsonOptions);

                    // ✅ Cache result
                    if (useCache && finalResult != null)
                    {
                        _cache[path] = (finalResult, DateTime.UtcNow);
                    }

                    return finalResult;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Error: {ex.Message}");
                    throw;
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Request to '{path}' failed: {ex.Message}", ex);
            }
            catch (NotSupportedException ex)
            {
                throw new Exception($"Unsupported content type when calling '{path}'", ex);
            }
            catch (System.Text.Json.JsonException ex)
            {
                throw new Exception($"JSON deserialization error from '{path}': {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error when calling '{path}': {ex.Message}", ex);
            }
        }

        // ✅ Clear cache (call on logout or data changes)
        public void ClearCache()
        {
            _cache.Clear();
        }

        public void ClearCache(string path)
        {
            _cache.Remove(path);
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
                throw new Exception(content);
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
            try
            {
                await SetAuthorizeHeader();
               
                var response = await httpClient.PostAsync(path, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"📤 POST {path} => {response.StatusCode}");
                Console.WriteLine($"📥 Content: {responseContent}");

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    throw new UnauthorizedAccessException("Token expired");

                if (!response.IsSuccessStatusCode)
                    return default;

                try
                {
                    if (typeof(T1) == typeof(string))
                        return (T1)(object)responseContent;

                    return System.Text.Json.JsonSerializer.Deserialize<T1>(responseContent);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Deserialization failed: {ex.Message}");
                    return default;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ POST failed: {ex.Message}");
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
            try
            {
                var response = await httpClient.DeleteAsync(path);
                var content = await response.Content.ReadAsStringAsync(); // ✅ added line for debugging/logging

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<T>();
                }
                else
                {
                    Console.WriteLine($"❌ Delete failed: {response.StatusCode} - {content}");
                    throw new Exception(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Exception during DELETE: {ex.Message}");
                throw;
            }
        }


        

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
        public async Task<string?> GetRawStringAsync(string path)
        {
            await SetAuthorizeHeader(); // token apply hoga

            try
            {
                return await httpClient.GetStringAsync(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ GetRawStringAsync Error: {ex.Message}");
                return null;
            }
        }



        //private static string ExtractCleanError(string raw)
        //{
        //    if (string.IsNullOrWhiteSpace(raw))
        //        return "Operation failed.";

        //    // Trim stack trace
        //    var atIndex = raw.IndexOf(" line ");
        //    if (atIndex > 0)
        //        raw = raw.Substring(0, atIndex);

        //    // First line only
        //    raw = raw.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)[0];

        //    return raw.Length > 200 ? raw.Substring(0, 200) + "..." : raw;
        //}

    }
}