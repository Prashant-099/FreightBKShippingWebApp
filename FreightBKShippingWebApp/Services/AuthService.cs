using DevExpress.PivotGrid.PivotTable;

using FreightBKShippingWebApp.Authentication;
using FreightBKShippingWebApp.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Security.Cryptography;
using static FreightBKShippingWebApp.Services.BaseService;

namespace FreightBKShippingWebApp.Services
{
    public class AuthService
    {
      
        private readonly ApiClient _api;
        private readonly ProtectedLocalStorage _localStorage;
        private readonly NavigationManager _navigationManager;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly BranchService _branchService;
        private readonly IBranchContext _branchContext;

        public AuthService(
            ProtectedLocalStorage localStorage,
            NavigationManager navigationManager,
            AuthenticationStateProvider authStateProvider,
            ApiClient apiClient,
            IBranchContext branchContext,BranchService branchService)
        {
             _localStorage = localStorage;
            _navigationManager = navigationManager;
            _authStateProvider = authStateProvider;
            _api = apiClient;
            _branchService = branchService;
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
                int activeBranchId = ResolveActiveBranch(result);

                if (activeBranchId > 0)
                {
                    // 🔥 SINGLE SOURCE OF TRUTH
                    _branchContext.SetBranch(activeBranchId);

                    result.ActiveBranchId = activeBranchId;

                    await _localStorage.SetAsync("activeBranchId", activeBranchId);

                    Console.WriteLine($"🌿 Active Branch Selected: {activeBranchId}");
                }

                // ================= TOKEN INFO =================
                var userId = BaseService.JwtHelper.GetUserIdFromToken(result.Token);
                var branches = await _branchService.GetBranchesForCurrentUserAsync();
                _branchContext.SetUserBranches(branches);

                if (branches.Any())
                {
                    _branchContext.SetBranch(branches.First().BranchId);
                }
                var companyId = BaseService.JwtHelper.GetCompanyIdFromToken(result.Token);

                await _localStorage.SetAsync("loggedInUserId", userId);
                await _localStorage.SetAsync("loggedInCompanyId", companyId);

                // ================= SESSION =================
                await _localStorage.SetAsync("sessionState", result);

                // ================= AUTH =================
                await ((CustomAuthStateProvider)_authStateProvider)
                    .MarkUserAsAuthenticated(result);

                // 🚀 Redirect only AFTER branch is set
                _navigationManager.NavigateTo("/", true);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🔥 LoginAsync Error: {ex}");
                return null;
            }
        }

        //public async Task<LoginResponseModel?> LoginAsync(LoginModel model)
        //{
        //    try
        //    {
        //        if (model == null ||
        //            string.IsNullOrWhiteSpace(model.UserEmail) ||
        //            string.IsNullOrWhiteSpace(model.UserPassword))
        //        {
        //            return null;
        //        }

        //        // 1️⃣ LOGIN
        //        var result = await _api.PostAsync<LoginResponseModel, LoginModel>(
        //            "api/Auth/login", model);

        //        if (result == null || string.IsNullOrWhiteSpace(result.Token))
        //            return null;

        //        // 2️⃣ SAVE FULL SESSION FIRST 🔥🔥
        //        await _localStorage.SetAsync("sessionState", result);

        //        // 3️⃣ MARK AUTHENTICATED
        //        await ((CustomAuthStateProvider)_authStateProvider)
        //            .MarkUserAsAuthenticated(result);

        //        // ⬆️ yahin se ApiClient token read kar sakta hai

        //        // 4️⃣ TOKEN INFO
        //        var userId = JwtHelper.GetUserIdFromToken(result.Token);
        //        var companyId = JwtHelper.GetCompanyIdFromToken(result.Token);

        //        await _localStorage.SetAsync("loggedInUserId", userId);
        //        await _localStorage.SetAsync("loggedInCompanyId", companyId);

        //        // 5️⃣ NOW SAFE: secured APIs
        //        var branches = await _branchService.GetBranchesByUserIdAsync(userId);
        //        _branchContext.SetUserBranches(branches);

        //        if (branches.Any())
        //        {
        //            var branchId = branches.First().BranchId;

        //            _branchContext.SetBranch(branchId);
        //            result.ActiveBranchId = branchId;

        //            await _localStorage.SetAsync("activeBranchId", branchId);

        //            // update session with branch
        //            await _localStorage.SetAsync("sessionState", result);
        //        }

        //        // 6️⃣ REDIRECT
        //        _navigationManager.NavigateTo("/", true);


        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"🔥 LoginAsync Error: {ex}");
        //        return null;
        //    }
        //}


        private int ResolveActiveBranch(LoginResponseModel result)
        {
            if (result.ActiveBranchId.HasValue && result.ActiveBranchId.Value > 0)
                return result.ActiveBranchId.Value;

            if (result.Branches != null && result.Branches.Any())
                return result.Branches.First().BranchId;

            return 0;
        }
        public async Task<LoginResponseModel?> GetSessionAsync()
        {
            var result =
                await _localStorage.GetAsync<LoginResponseModel>("sessionState");

            return result.Success ? result.Value : null;
        }


        // ✅ SELECTED BRANCH
        public async Task<int?> GetSelectedBranchAsync()
        {
            var result = await _localStorage.GetAsync<int?>("activeBranchId");
            return result.Success ? result.Value : null;
        }


        // ✅ WHEN USER CHANGES BRANCH

        //public async Task<LoginResponseModel?> GetSessionAsync()
        //{
        //    var result = await _localStorage.GetAsync<LoginResponseModel>("sessionState");
        //    var session = result.Value;

        //    if (session?.ActiveBranchId is > 0)
        //    {
        //        // 🔥 CORRECT WAY
        //        int initialBranchId = session.ActiveBranchId ?? session.Branches.First().BranchId;
        //        _branchContext.SetBranch(initialBranchId);
        //    }

        //    return session;
        //}

        //public async Task<int?> GetSelectedBranchAsync()
        //{
        //    var result = await _localStorage.GetAsync<int?>("branchId");
        //    return result.Value;
        //}

public async Task<bool> SelectBranchAsync(int branchId)
    {
        try
        {
            var result = await _localStorage.GetAsync<LoginResponseModel>("sessionState");

            if (!result.Success || result.Value == null)
                return false;

            var session = result.Value;
            session.ActiveBranchId = branchId;

            await _localStorage.SetAsync("sessionState", session);
            return true;
        }
        catch (CryptographicException)
        {
            // 🔥 Corrupted or old encrypted payload
            await _localStorage.DeleteAsync("sessionState");
            return false;
        }
        catch
        {
            // 🧯 Any other unexpected issue
            return false;
        }
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
