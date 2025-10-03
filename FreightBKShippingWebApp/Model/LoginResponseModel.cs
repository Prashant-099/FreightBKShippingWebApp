namespace FreightBKShippingWebApp.Model
{
    public class LoginResponseModel
    {
        //public string Token { get; set; }
        //public long TokenExpired { get; set; }
        //public string RefreshToken { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public long tokenExp { get; set; }
        public string RefreshToken { get; set; }

        public DateTime RefreshtokenExp  { get; set;}

    }
}
