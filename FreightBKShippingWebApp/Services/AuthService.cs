using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Localization;
using FreightBKShippingWebApp.Authentication;
using FreightBKShippingWebApp.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace FreightBKShippingWebApp.Services
{
    public class AuthService
    {
      
        private readonly ApiClient _api;
        private readonly ProtectedLocalStorage _localStorage;
        private readonly NavigationManager _navigationManager;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly IBranchContext _branchContext;

        public AuthService(
            ProtectedLocalStorage localStorage,
            NavigationManager navigationManager,
            AuthenticationStateProvider authStateProvider,
            ApiClient apiClient,
            IBranchContext branchContext)
        {
            _localStorage = localStorage;
            _navigationManager = navigationManager;
            _authStateProvider = authStateProvider;
            _api = apiClient;
            _branchContext = branchContext;
        }




        public async Task<LoginResponseModel?> LoginAsync(LoginModel model)
        {
            try
            {
                if (model == null ||
                    string.IsNullOrWhiteSpace(model.UserEmail) ||
                    string.IsNullOrWhiteSpace(model.UserPassword))
                {
                    return null;
                }

                var result = await _api.PostAsync<LoginResponseModel, LoginModel>(
                    "api/Auth/login", model);

                if (result == null || string.IsNullOrWhiteSpace(result.Token))
                    return null;

                // ================= BRANCH DECISION =================
                int activeBranchId = 0;

                if (result.ActiveBranchId.HasValue && result.ActiveBranchId > 0)
                {
                    activeBranchId = result.ActiveBranchId.Value;
                }
                else if (result.Branches != null && result.Branches.Any())
                {
                    activeBranchId = result.Branches.First().BranchId;
                }

                if (activeBranchId > 0)
                {
                    Console.WriteLine($"🌿 Active Branch set to: {activeBranchId}");

                    await _localStorage.SetAsync("activeBranchId", activeBranchId);
                    _branchContext.BranchId = activeBranchId;

                    // keep response model in sync
                    result.ActiveBranchId = activeBranchId;
                }


                // 🔥 SET GLOBAL CONTEXT
                _branchContext.BranchId = activeBranchId;

                // UX only
                await _localStorage.SetAsync("activeBranchId", activeBranchId);

                // ================= TOKEN INFO =================
                var userId = BaseService.JwtHelper.GetUserIdFromToken(result.Token);
                var companyId = BaseService.JwtHelper.GetCompanyIdFromToken(result.Token);

                await _localStorage.SetAsync("loggedInUserId", userId);
                await _localStorage.SetAsync("loggedInCompanyId", companyId);

                // ================= SESSION =================
                result.ActiveBranchId = activeBranchId;
                await _localStorage.SetAsync("sessionState", result);

                // ================= AUTH STATE =================
                await ((CustomAuthStateProvider)_authStateProvider)
                    .MarkUserAsAuthenticated(result);

                _navigationManager.NavigateTo("/", true);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🔥 LoginAsync Error: {ex}");
                return null;
            }
        }
        public async Task<LoginResponseModel?> GetSessionAsync()
        {
            var result = await _localStorage.GetAsync<LoginResponseModel>("sessionState");
            var session = result.Value;

            if (session?.ActiveBranchId != null)
            {
                _branchContext.BranchId = session.ActiveBranchId.Value;
            }

            return session;
        }

        public async Task<bool> SelectBranchAsync(int branchId)
        {
            var session = (await _localStorage.GetAsync<LoginResponseModel>("sessionState")).Value;
            if (session == null) return false;

            session.ActiveBranchId = branchId;
            await _localStorage.SetAsync("sessionState", session);

            return true;
        }

        //public async Task<bool> SelectBranchAsync(int branchId)
        //{
        //    var session = (await _localStorage.GetAsync<LoginResponseModel>("sessionState")).Value;
        //    if (session == null) return false;

        //    var dto = new { UserId = session, BranchId = branchId };

        //    var result = await _api.PostAsync<object, object>("api/Auth/select-branch", dto);

        //    // update local storage with selected branch
        //    session.ActiveBranchId = branchId;
        //    await _localStorage.SetAsync("sessionState", session);

        //    return true;
        //}

        public async Task LogoutAsync()
        {
            //await _localStorage.DeleteAsync("sessionState");
            //await ((CustomAuthStateProvider)_authStateProvider).MarkUserAsLoggedOut();
            //_navigationManager.NavigateTo("/login");
            try
            {
                // 🔐 Call backend logout API (JWT goes automatically via ApiClient)
                await _api.PostAsync<object, object>("api/Auth/logout", null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logout API failed: {ex.Message}");
                // continue logout anyway
            }

            // 🧹 Clear local storage
            await _localStorage.DeleteAsync("sessionState");
            await _localStorage.DeleteAsync("loggedInUserId");
            await _localStorage.DeleteAsync("loggedInCompanyId");

            // 🔄 Update auth state
            await ((CustomAuthStateProvider)_authStateProvider)
                .MarkUserAsLoggedOut();

            // 🚀 Redirect
            _navigationManager.NavigateTo("/login", true);
        }

        public async Task<string?> GetTokenAsync()
        {
            var session = (await _localStorage.GetAsync<LoginResponseModel>("sessionState")).Value;
            return session?.Token;
        }

        public async Task<ServiceResponse> RegisterAsync(RegisterDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.UserEmail) || string.IsNullOrWhiteSpace(request.UserPassword))
                {
                    return ServiceResponse.Fail("Email and password are required.");
                }

                // ⛳ Hit the API
                var result = await _api.PostAsync<ServiceResponse, RegisterDto>("api/Auth/register", request);

                // 🛡️ Null check
                if (result == null)
                {
                    Console.WriteLine("🚫 Registration returned null.");
                    return ServiceResponse.Fail("No response received from server.");
                }

                // ❌ Handle failure
                if (!result.IsSuccess)
                {
                    Console.WriteLine($"⚠️ Registration failed: {result.ErrorMessage}");
                    return ServiceResponse.Fail(result.ErrorMessage ?? "Unknown error during registration.");
                }

                // ✅ Handle success
                Console.WriteLine("✅ Registration successful.");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🔥 Exception during registration: {ex.Message}");
                return ServiceResponse.Fail($"Exception: {ex.Message}");
            }
        }


        public async Task<ServiceResponse> ForgotPasswordAsync(string email)
        {
            try
            {
                var dto = new { Email = email };
                var result = await _api.PostAsync<ForgotPasswordResponse, object>("api/Auth/forgot-password", dto);

                if (result != null)
                    return ServiceResponse.Success();
                else
                    return ServiceResponse.Fail("No response from server.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Fail($"Exception: {ex.Message}");
            }
        }

        public async Task<ServiceResponse> ResetPasswordAsync(ResetPasswordDto request)
        {
            try
            {
                var result = await _api.PostAsync<ServiceResponse, ResetPasswordDto>("api/Auth/reset-password", request);
                return result ?? ServiceResponse.Fail("No response from server.");
            }
            catch (Exception ex)
            {
                return ServiceResponse.Fail($"Exception: {ex.Message}");
            }
        }

    }
}

//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Authorization;
//using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
//using System.Globalization;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Net.Http.Json;
//using Microsoft.AspNetCore.Localization;
//using BlazorApp.Authentication;
//using BlazorApp.Model;

//namespace BlazorApp.Services
//{
//    public class AuthService
//    {
//        private readonly HttpClient _httpClient;
//        private readonly ProtectedLocalStorage _localStorage;
//        private readonly NavigationManager _navigationManager;
//        private readonly AuthenticationStateProvider _authStateProvider;

//        public AuthService(HttpClient httpClient,
//                           ProtectedLocalStorage localStorage,
//                           NavigationManager navigationManager,
//                           AuthenticationStateProvider authStateProvider)
//        {
//            _httpClient = httpClient;
//            _localStorage = localStorage;
//            _navigationManager = navigationManager;
//            _authStateProvider = authStateProvider;
//        }

//        public async Task SetAuthorizeHeader()
//        {
//            try
//            {
//                var sessionResult = await _localStorage.GetAsync<LoginResponseModel>("sessionState");
//                var sessionState = sessionResult.Success ? sessionResult.Value : null;

//                if (sessionState == null || string.IsNullOrEmpty(sessionState.Token))
//                {
//                    await LogoutAndRedirect();
//                    return;
//                }

//                var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

//                // Token expired
//                if (sessionState.TokenExpired < now)
//                {
//                    await LogoutAndRedirect();
//                    return;
//                }

//                // Refresh token if about to expire (less than 10 mins)
//                if (sessionState.TokenExpired < now + 600)
//                {
//                    var res = await _httpClient.GetFromJsonAsync<LoginResponseModel>($"api/auth/loginByRefeshToken?refreshToken={sessionState.RefreshToken}");
//                    if (res != null)
//                    {
//                        await ((CustomAuthStateProvider)_authStateProvider).MarkUserAsAuthenticated(res);
//                        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", res.Token);
//                    }
//                    else
//                    {
//                        await LogoutAndRedirect();
//                        return;
//                    }
//                }
//                else
//                {
//                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessionState.Token);
//                }

//                // Add culture info to request headers
//                var requestCulture = new RequestCulture(CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture);
//                var cultureCookieValue = CookieRequestCultureProvider.MakeCookieValue(requestCulture);
//                _httpClient.DefaultRequestHeaders.Add("Cookie", $"{CookieRequestCultureProvider.DefaultCookieName}={cultureCookieValue}");
//            }
//            catch
//            {
//                await LogoutAndRedirect();
//            }
//        }

//        public async Task<bool> LoginAsync(string email, string password)
//        {
//            var response = await _httpClient.PostAsJsonAsync("api/Auth/login", new { Email = email, Password = password });

//            if (!response.IsSuccessStatusCode)
//                return false;

//            var result = await response.Content.ReadFromJsonAsync<LoginResponseModel>();
//            if (result?.Token != null)
//            {
//                await _localStorage.SetAsync("sessionState", result);
//                await ((CustomAuthStateProvider)_authStateProvider).MarkUserAsAuthenticated(result);
//                return true;
//            }

//            return false;
//        }

//        public async Task LogoutAsync()
//        {
//            await _localStorage.DeleteAsync("sessionState");
//            await ((CustomAuthStateProvider)_authStateProvider).MarkUserAsLoggedOut();
//            _navigationManager.NavigateTo("/login", true);
//        }

//        public async Task<string?> GetTokenAsync()
//        {
//            var sessionResult = await _localStorage.GetAsync<LoginResponseModel>("sessionState");
//            return sessionResult.Success ? sessionResult.Value?.Token : null;
//        }

//        public async Task<ServiceResponse> RegisterAsync(RegisterDto request)
//        {
//            try
//            {
//                if (string.IsNullOrWhiteSpace(request.UserEmail) || string.IsNullOrWhiteSpace(request.UserPassword))
//                {
//                    return ServiceResponse.Fail("Email and password are required.");
//                }

//                var response = await _httpClient.PostAsJsonAsync("api/Auth/register", request);
//                var responseContent = await response.Content.ReadAsStringAsync();

//                if (!response.IsSuccessStatusCode)
//                {
//                    Console.WriteLine($"⚠️ Registration failed: {responseContent}");
//                    return ServiceResponse.Fail($"Registration failed: {responseContent}");
//                }

//                Console.WriteLine($"✅ Registration successful: {responseContent}");
//                return ServiceResponse.Success();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"🔥 Exception during registration: {ex.Message}");
//                return ServiceResponse.Fail($"Exception: {ex.Message}");
//            }
//        }

//        private async Task LogoutAndRedirect()
//        {
//            await ((CustomAuthStateProvider)_authStateProvider).MarkUserAsLoggedOut();
//            await _localStorage.DeleteAsync("sessionState");
//            _navigationManager.NavigateTo("/login", true);
//        }
//    }
//}
