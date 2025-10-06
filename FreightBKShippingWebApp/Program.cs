using FreightBKShippingWebApp;
using FreightBKShippingWebApp.Authentication;
using FreightBKShippingWebApp.Components;
using FreightBKShippingWebApp.Services;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDevExpressBlazor(options => {
    options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
    options.SizeMode = DevExpress.Blazor.SizeMode.Medium;
});

builder.Services.AddMvc();
builder.Services.AddAuthenticationCore();
builder.Services.AddCascadingAuthenticationState();


builder.Services.AddOutputCache();
builder.Services.AddScoped<ApiClient>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<LoadingService>();
builder.Services.AddScoped<ToasteService>();
builder.Services.AddScoped<VoucherConfigService>();
builder.Services.AddScoped<YearService>();
builder.Services.AddScoped<YearStatechangeService>();
builder.Services.AddScoped<ConfirmationDialogService>();
builder.Services.AddScoped<StateService>();
builder.Services.AddScoped<CountryService>();
builder.Services.AddScoped<BranchService>();
builder.Services.AddScoped<CurrencyService>();

builder.Services.AddHttpClient<ApiClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5004/");
});

builder.Services.AddLocalization();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseOutputCache();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();