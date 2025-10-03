using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FreightBKShippingWebApp.Services
{
    public abstract class BaseService
    {
        protected readonly HttpClient _http;

        public BaseService(HttpClient http)
        {
            _http = http;
        }


        public static class JwtHelper
        {
            public static string? GetUserIdFromToken(string token) =>
                GetClaimValue(token, "UserId")
                ?? GetClaimValue(token, ClaimTypes.NameIdentifier)
                ?? GetClaimValue(token, "sub");

            public static string? GetBranchIdFromToken(string token) =>
                GetClaimValue(token, "BranchId");

            public static string? GetCompanyIdFromToken(string token) =>
                GetClaimValue(token, "CompanyId");

            public static string? GetEmailFromToken(string token) =>
                GetClaimValue(token, ClaimTypes.Email);

            public static string? GetRoleFromToken(string token) =>
                GetClaimValue(token, ClaimTypes.Role);

            public static string? GetClaimValue(string token, string claimType)
            {
                if (string.IsNullOrWhiteSpace(token))
                    return null;

                var handler = new JwtSecurityTokenHandler();
                if (!handler.CanReadToken(token))
                    return null;

                var jwtToken = handler.ReadJwtToken(token);
                return jwtToken.Claims.FirstOrDefault(c => c.Type == claimType)?.Value;
            }
        }

    }
}
