using FreightBKShippingWebApp.Model;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

public interface ITokenProvider
{
    Task<string?> GetTokenAsync();
}


public class TokenProvider : ITokenProvider
{
    private readonly ProtectedLocalStorage _localStorage;

    public TokenProvider(ProtectedLocalStorage localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task<string?> GetTokenAsync()
    {
        var result = await _localStorage.GetAsync<LoginResponseModel>("sessionState");
        return result.Success ? result.Value?.Token : null;
    }
}
