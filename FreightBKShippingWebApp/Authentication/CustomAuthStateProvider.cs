using FreightBKShippingWebApp.Model;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FreightBKShippingWebApp.Authentication
{
    public class CustomAuthStateProvider(ProtectedLocalStorage localStorage) : AuthenticationStateProvider
    {
        private readonly JwtSecurityTokenHandler _tokenHandler = new();
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var result = await localStorage.GetAsync<LoginResponseModel>("sessionState");
                var sessionModel = result.Success ? result.Value : null;

                if (sessionModel == null || string.IsNullOrWhiteSpace(sessionModel.Token))
                {
                    Console.WriteLine("⚠️ No session state found");
                    return CreateAnonymousState();
                }

                // Validate token expiration
                if (!IsTokenValid(sessionModel.Token, out var jwtToken))
                {
                    Console.WriteLine("❌ Token is invalid or expired, clearing session");
                    await MarkUserAsLoggedOut();
                    return CreateAnonymousState();
                }

                // Additional check: verify tokenExp from session matches JWT exp
                var tokenExpFromSession = sessionModel.tokenExp;
                var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                if (tokenExpFromSession <= now)
                {
                    Console.WriteLine($"❌ Token expired (session exp: {tokenExpFromSession}, now: {now})");
                    await MarkUserAsLoggedOut();
                    return CreateAnonymousState();
                }

                // Check refresh token expiration
                var refreshExpUnix = new DateTimeOffset(sessionModel.RefreshtokenExp).ToUnixTimeSeconds();
                if (refreshExpUnix <= now)
                {
                    Console.WriteLine("❌ Refresh token expired, clearing session");
                    await MarkUserAsLoggedOut();
                    return CreateAnonymousState();
                }

                Console.WriteLine($"✅ Token valid, expires in {(tokenExpFromSession - now) / 60} minutes");

                var identity = GetClaimsIdentity(jwtToken);
                var user = new ClaimsPrincipal(identity);
                return new AuthenticationState(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error in GetAuthenticationStateAsync: {ex.Message}");
                await MarkUserAsLoggedOut();
                return CreateAnonymousState();
            }
        }

        public async Task MarkUserAsAuthenticated(LoginResponseModel model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.Token))
            {
                throw new ArgumentException("Invalid login response model");
            }

            // Validate the token before storing
            if (!IsTokenValid(model.Token, out var jwtToken))
            {
                throw new ArgumentException("Invalid or expired token");
            }

            await localStorage.SetAsync("sessionState", model);

            var identity = GetClaimsIdentity(jwtToken);
            var user = new ClaimsPrincipal(identity);

            Console.WriteLine($"✅ User authenticated: {identity.Name}");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        private ClaimsIdentity GetClaimsIdentity(string token)
        {
            if (IsTokenValid(token, out var jwtToken))
            {
                return GetClaimsIdentity(jwtToken);
            }

            return new ClaimsIdentity(); // Anonymous identity
        }

        public async Task MarkUserAsLoggedOut()
        {
            try
            {
                await localStorage.DeleteAsync("sessionState");
                Console.WriteLine("✅ Session cleared, user logged out");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Error clearing session: {ex.Message}");
            }

            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        private bool IsTokenValid(string token, out JwtSecurityToken jwtToken)
        {
            jwtToken = null;

            try
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    return false;
                }

                // Read and validate the token
                if (!_tokenHandler.CanReadToken(token))
                {
                    Console.WriteLine("❌ Cannot read token format");
                    return false;
                }

                jwtToken = _tokenHandler.ReadJwtToken(token);

                // Check token expiration
                var exp = jwtToken.ValidTo;
                var now = DateTime.UtcNow;

                if (exp <= now)
                {
                    Console.WriteLine($"❌ JWT token expired at {exp}, now is {now}");
                    return false;
                }

                // Check if token is not yet valid (nbf claim)
                if (jwtToken.ValidFrom > now)
                {
                    Console.WriteLine($"❌ JWT token not yet valid until {jwtToken.ValidFrom}");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Token validation error: {ex.Message}");
                return false;
            }
        }
        private ClaimsIdentity GetClaimsIdentity(JwtSecurityToken jwtToken)
        {
            if (jwtToken == null)
            {
                throw new ArgumentNullException(nameof(jwtToken));
            }

            var claims = jwtToken.Claims.ToList();

            // Add expiration claim for reference
            claims.Add(new Claim("exp", jwtToken.ValidTo.ToString("O")));

            return new ClaimsIdentity(claims, "jwt");
        }

        private AuthenticationState CreateAnonymousState()
        {
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            return new AuthenticationState(user);
        }

        /// <summary>
        /// Check if current user session is still valid
        /// </summary>
        public async Task<bool> IsUserAuthenticated()
        {
            try
            {
                var result = await localStorage.GetAsync<LoginResponseModel>("sessionState");
                var sessionModel = result.Success ? result.Value : null;

                if (sessionModel == null || string.IsNullOrWhiteSpace(sessionModel.Token))
                {
                    return false;
                }

                return IsTokenValid(sessionModel.Token, out _);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Get current session model if valid
        /// </summary>
        public async Task<LoginResponseModel?> GetCurrentSession()
        {
            try
            {
                var result = await localStorage.GetAsync<LoginResponseModel>("sessionState");
                var sessionModel = result.Success ? result.Value : null;

                if (sessionModel == null || string.IsNullOrWhiteSpace(sessionModel.Token))
                {
                    return null;
                }

                if (!IsTokenValid(sessionModel.Token, out _))
                {
                    await MarkUserAsLoggedOut();
                    return null;
                }

                return sessionModel;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Update session after token refresh
        /// </summary>
        public async Task UpdateSession(LoginResponseModel newSession)
        {
            if (newSession == null || string.IsNullOrWhiteSpace(newSession.Token))
            {
                throw new ArgumentException("Invalid session model");
            }

            await localStorage.SetAsync("sessionState", newSession);
            Console.WriteLine("✅ Session updated with new tokens");
        }
    }
}
