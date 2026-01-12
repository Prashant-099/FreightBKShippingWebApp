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
        public List<UserBranchDto> Branches { get; set; } = new List<UserBranchDto>();

        // 🔹 NEW: Active branch selected by user
        public int? ActiveBranchId { get; set; }
        public DateTime RefreshtokenExp  { get; set;}

    }

    public class UserBranchDto
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;
    }
}
