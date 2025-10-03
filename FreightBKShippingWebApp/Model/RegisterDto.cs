using System.ComponentModel.DataAnnotations;
namespace FreightBKShippingWebApp.Model;
public class RegisterDto
{
    [Required(ErrorMessage = "Full name is required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string UserName { get; set; } = "";

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string UserEmail { get; set; } = "";

    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
                      ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character")]
    public string UserPassword { get; set; } = "";

    [Required(ErrorMessage = "Please confirm your password")]
    [Compare("UserPassword", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = "";

    //[Required(ErrorMessage = "Company ID is required")]
    //[Range(1, int.MaxValue, ErrorMessage = "Please enter a valid company ID")]
    //public int UserCompanyId { get; set; }

    //[Required(ErrorMessage = "You must accept the terms and conditions")]
    //[Range(typeof(bool), "true", "true", ErrorMessage = "You must accept the terms and conditions")]
    //public bool AcceptTerms { get; set; } = false;
}

public class LoginRequest
{
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
    public bool RememberMe { get; set; } = false;

}

public class EmailOnlyDto
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = string.Empty;
}
public class ServiceResponse
{
    public bool IsSuccess { get; set; }
    public string? ErrorMessage { get; set; }

    public static ServiceResponse Success() => new ServiceResponse { IsSuccess = true };
    public static ServiceResponse Fail(string error) => new ServiceResponse { IsSuccess = false, ErrorMessage = error };
}
public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
public class ResetPasswordDto
{
    public string Email { get; set; } = default!;
    public string Token { get; set; } = default!;
    public string NewPassword { get; set; } = default!;
}
public class ForgotPasswordResponse
{
    public string Message { get; set; }
    public string ResetToken { get; set; }
    public string ResetLink { get; set; }
}
