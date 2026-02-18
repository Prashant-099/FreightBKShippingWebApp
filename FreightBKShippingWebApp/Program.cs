using DevExpress.Drawing.Internal;
using FreightBKShipping.Client.Services;
using FreightBKShippingWebApp;
using FreightBKShippingWebApp.Authentication;
using FreightBKShippingWebApp.Components;
using FreightBKShippingWebApp.Services;
using FreightBKShippingWebApp.Services.PdfReaderAndHelperService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.ResponseCompression;



var builder = WebApplication.CreateBuilder(args);
DXDrawingEngine.ForceSkia();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
///do not change the path connected on the server where the app is hosted, as it is used to store the data protection keys for the application.
///Changing this path may result in issues with data protection and authentication. If you need to change the path,
///make sure to update it in both the code and the server configuration to ensure that the application can access the keys properly.     by DHruv Hadiya
string keysPath;
if (builder.Environment.IsDevelopment())
{
    // Local dev folder
    keysPath = Path.Combine(builder.Environment.ContentRootPath, "DataProtectionKeys");
}
else
{
    // Production server folder
    keysPath = "/var/lib/freightbkshipping/dataprotection-keys";
}

Directory.CreateDirectory(keysPath); // ensure it exists

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(keysPath))
    .SetApplicationName("FreightBKShippingWebApp")
    .SetDefaultKeyLifetime(TimeSpan.FromDays(90));

///end of data protection configuration
///

//builder.Services.AddDataProtection()
//    .PersistKeysToFileSystem(new DirectoryInfo(
//        Path.Combine(builder.Environment.ContentRootPath, "DataProtectionKeys")))
//    .SetApplicationName("FreightBKShippingWebApp");


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
builder.Services.AddHttpClient<ApiClient>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<BranchService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<LoadingService>();
builder.Services.AddScoped<ToasteService>();
builder.Services.AddScoped<YearService>();
builder.Services.AddScoped<YearStatechangeService>();
builder.Services.AddScoped<ConfirmationDialogService>();
builder.Services.AddScoped<StateService>();
builder.Services.AddScoped<CountryService>();
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
builder.Services.AddScoped<AuditLogService>();
builder.Services.AddScoped<ContainerAddServices>();
builder.Services.AddScoped<GstTemplateService>();
builder.Services.AddScoped<GstExcelService>();
builder.Services.AddScoped<Gstr2TemplateService>();
builder.Services.AddScoped<Gstr3BTemplateService>();
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
builder.Services.AddScoped<FileUploadService>();
builder.Services.AddScoped<JournalService>();
builder.Services.AddScoped<LrApiService>();

//
builder.Services.AddScoped<AuthTokenService>();
builder.Services.AddScoped<IBranchContext, BranchContext>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IGenericReportManager, GenericReportManager>();

//builder.Services.AddHttpClient<ApiClient>(client =>
//{
//    client.BaseAddress = new Uri("http://localhost:5003/");
//});

builder.Services.AddHttpClient<ApiClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:5003/");
});

//builder.Services.AddHttpClient<ApiClient>(client =>
//{
//    client.BaseAddress = new Uri("https://apihost.freightbook.in/");
//});
//builder.Services.AddHttpClient<ApiClient>(client =>
//{
//    client.BaseAddress = new Uri("http://apihost.freightbook.in/");
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