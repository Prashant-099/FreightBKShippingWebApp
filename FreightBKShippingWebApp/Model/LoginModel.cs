using System.ComponentModel.DataAnnotations;

namespace FreightBKShippingWebApp.Model
{

    public class LoginModel
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public bool RememberMe { get; set; } = false;
    }
    public class RefreshTokenRequest
    {
        // ✅ CRITICAL: Must match API parameter name exactly
        public string RefreshToken { get; set; }
    }
}
