using Newtonsoft.Json;

namespace FreightBKShippingWebApp.Model
{
    // API Settings
    public class eInvoiceAPISetting
    {
        public string AuthUrl { get; set; } = "https://gstsandbox.charteredinfo.com/eivital/dec/v1.04/auth";
        public string GspName { get; set; } = "TaxPro_Sandbox";
        public string aspid { get; set; } = "1656691121";
        public string Password { get; set; } = "Rajesh@123";
        public string user_name { get; set; } = "TaxProEnvPON";
        public string eInvPwd { get; set; } = "abc34*";
        public string BaseUrl { get; set; } = "https://gstsandbox.charteredinfo.com/eivital/dec/v1.04/";
        //public string EwbByIRN { get; set; } = "https://gstsandbox.charteredinfo.com/eiewb/v1.03";
        //public string CancelEwbUrl { get; set; } = "https://gstsandbox.charteredinfo.com/v1.03";
    }

    // API Login Details
    public class eInvoiceAPILoginDetails
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gstin { get; set; }
        public string AppKey { get; set; }
    }

    // Session Container
    public class eInvoiceSession
    {
        public eInvoiceAPISetting eInvApiSetting { get; set; }
        public eInvoiceAPILoginDetails eInvApiLoginDetails { get; set; }
    }

    // Auth Token Response (matches API response format)
    public class AuthTokenResponse
    {
        [JsonProperty("Status")]
        public int Status { get; set; }

        [JsonProperty("Data")]
        public AuthTokenData Data { get; set; }

        [JsonProperty("ErrorDetails")]
        public object ErrorDetails { get; set; }

        [JsonProperty("InfoDtls")]
        public object InfoDtls { get; set; }
    }

    public class AuthTokenData
    {
        [JsonProperty("ClientId")]
        public string ClientId { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("AuthToken")]
        public string AuthToken { get; set; }

        [JsonProperty("Sek")]
        public string Sek { get; set; }

        [JsonProperty("TokenExpiry")]
        public string TokenExpiry { get; set; }
    }
}