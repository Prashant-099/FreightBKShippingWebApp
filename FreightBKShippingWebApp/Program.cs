using FreightBKShippingWebApp;
using FreightBKShippingWebApp.Authentication;
using FreightBKShippingWebApp.Components;
using FreightBKShippingWebApp.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.ResponseCompression;
using FreightBKShippingWebApp.Services.PdfReaderAndHelperService;

using DevExpress.Drawing.Internal;

var builder = WebApplication.CreateBuilder(args);
DXDrawingEngine.ForceSkia();
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

builder.Services.AddDevExpressServerSideBlazorReportViewer();
// ✅ Add response compression
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<GzipCompressionProvider>();
    options.Providers.Add<BrotliCompressionProvider>();
});

builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = System.IO.Compression.CompressionLevel.Fastest;
});

builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
{
    options.Level = System.IO.Compression.CompressionLevel.Fastest;
});

builder.Services.AddOutputCache();
builder.Services.AddScoped<ApiClient>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<LoadingService>();
builder.Services.AddScoped<ToasteService>();
builder.Services.AddScoped<YearService>();
builder.Services.AddScoped<YearStatechangeService>();
builder.Services.AddScoped<ConfirmationDialogService>();
builder.Services.AddScoped<StateService>();
builder.Services.AddScoped<CountryService>();
builder.Services.AddScoped<BranchService>();
builder.Services.AddScoped<CurrencyService>();
builder.Services.AddScoped<VoucherService>();
builder.Services.AddScoped<UserRoleService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ServiceService>();
builder.Services.AddScoped<ServiceGroupService>();
builder.Services.AddScoped<PayTypeService>();
builder.Services.AddScoped<NotifyService>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<HsnSacService>();
builder.Services.AddScoped<GstSlabService>();
builder.Services.AddScoped<CargoService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<AccountTypeService>();
builder.Services.AddScoped<AccountGroupService>();
builder.Services.AddScoped<UnitService>();
builder.Services.AddScoped<VesselService>();
builder.Services.AddScoped<RateMasterService>();
builder.Services.AddScoped<JobService>();
builder.Services.AddScoped<ReportDataService>(); 
builder.Services.AddScoped<ReportService>();
builder.Services.AddScoped<BillService>();
builder.Services.AddScoped<GridLayoutService>();
builder.Services.AddScoped<EinvConfigService>();
builder.Services.AddScoped<GstinService>();
builder.Services.AddScoped<StatusService>();
builder.Services.AddScoped<GstinAuthTokenService>();
builder.Services.AddScoped<DashboardService>();

//pdfreder services
builder.Services.AddScoped<DataCleanupService>();
//builder.Services.AddScoped<PdfExtractionService>();
builder.Services.AddScoped<FreightBKShippingWebApp.Services.PdfReaderAndHelperService.ExportJobBuilderService>();
builder.Services.AddScoped<FreightBKShippingWebApp.Services.PdfReaderAndHelperService.ExportPdfExtractorService>(); 

builder.Services.AddScoped<FreightBKShippingWebApp.Services.PdfReaderAndHelperService.PdfDetailedExtractorService>();
builder.Services.AddScoped<JobDataCreationService>();
builder.Services.AddScoped<JobBuilderService>();

//wpmail send dhruvadmina
builder.Services.AddScoped<ChatwayService>();
builder.Services.AddScoped<SendWpMailService>();
builder.Services.AddScoped<WpMailConfigService>();
builder.Services.AddScoped<Sentwpcerti>();
builder.Services.AddScoped<BillUploadService>();
//
builder.Services.AddScoped<AuthTokenService>();
builder.Services.AddScoped<IBranchContext, BranchContext>();

//builder.Services.AddHttpClient<ApiClient>(client =>
//{
//    client.BaseAddress = new Uri("http://localhost:5003/");
//});

//builder.Services.AddHttpClient<ApiClient>(client =>
//{
//    client.BaseAddress = new Uri("https://localhost:5003/");
//});
builder.Services.AddHttpClient<ApiClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5003/");
});
//builder.Services.AddHttpClient<ApiClient>(client =>
//{
//    client.BaseAddress = new Uri("https://apihost.freightbook.in/");
//});
builder.Services.AddLocalization();
builder.Services.AddControllers();
var app = builder.Build();
// ✅ Use compression middleware (place BEFORE UseEndpoints)
app.UseResponseCompression();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
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