using DevExpress.Drawing.Internal;
using FreightBKShipping.Client.Services;
using FreightBKShippingWebApp;
using FreightBKShippingWebApp.Authentication;
using FreightBKShippingWebApp.Components;
using FreightBKShippingWebApp.Extensions;
using FreightBKShippingWebApp.Services;
using FreightBKShippingWebApp.Services.PdfReaderAndHelperService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.AspNetCore.HttpOverrides;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

DXDrawingEngine.ForceSkia(); // DevExpress drawing engine

// ==========================================================
// 1?? RAZOR + BLAZOR SERVER
// ==========================================================
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAntiforgery(options =>
{
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.Name = "__Host-Antiforgery-FreightBK"; // Extra credit: Use __Host- prefix for better security
});
// Protect SignalR payload size (VERY IMPORTANT FOR SaaS)
builder.Services.AddSignalR(options =>
{
    options.MaximumReceiveMessageSize = 1024 * 50; // 50KB
});

// ==========================================================
// 2?? DATA PROTECTION (DO NOT CHANGE PATH IN PRODUCTION)
// ==========================================================
string keysPath;

if (builder.Environment.IsDevelopment())
{
    keysPath = Path.Combine(builder.Environment.ContentRootPath, "DataProtectionKeys");
}
else
{
    // ?? Production path (Linux VPS)
    keysPath = "/var/lib/freightbkshipping/dataprotection-keys";
}

Directory.CreateDirectory(keysPath);

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(keysPath))
    .SetApplicationName("FreightBKShippingWebApp")
    .SetDefaultKeyLifetime(TimeSpan.FromDays(90));

// ==========================================================
// 3?? DEVEXPRESS
// ==========================================================
builder.Services.AddDevExpressBlazor(options =>
{
    options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
    options.SizeMode = DevExpress.Blazor.SizeMode.Medium;
});

builder.Services.AddDevExpressServerSideBlazorReportViewer();

// ==========================================================
// 4?? AUTHENTICATION
// ==========================================================
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "BlazorCookies";
    options.DefaultChallengeScheme = "BlazorCookies";
})
.AddCookie("BlazorCookies", options =>
{
    options.LoginPath = "/login";
    options.AccessDeniedPath = "/403";
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Strict;
}); builder.Services.AddCascadingAuthenticationState();

//builder.Services.ConfigureApplicationCookie(options =>
//{
//    options.Cookie.HttpOnly = true;
//    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // HTTPS only
//    options.Cookie.SameSite = SameSiteMode.Strict;
//});

// ==========================================================
// 5?? RESPONSE COMPRESSION
// ==========================================================
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<GzipCompressionProvider>();
    options.Providers.Add<BrotliCompressionProvider>();
});

builder.Services.Configure<GzipCompressionProviderOptions>(o =>
{
    o.Level = System.IO.Compression.CompressionLevel.Fastest;
});

builder.Services.Configure<BrotliCompressionProviderOptions>(o =>
{
    o.Level = System.IO.Compression.CompressionLevel.Fastest;
});

// ==========================================================
// 6?? OUTPUT CACHE
// ==========================================================
builder.Services.AddOutputCache();

// ==========================================================
// 7?? RATE LIMITING (GLOBAL SaaS PROTECTION)
// ==========================================================
builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
    {
        var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";

        return RateLimitPartition.GetSlidingWindowLimiter(ip, _ =>
            new SlidingWindowRateLimiterOptions
            {
                PermitLimit = 60, // 60 req per minute per IP
                Window = TimeSpan.FromMinutes(1),
                SegmentsPerWindow = 6,
                QueueLimit = 5,
                QueueProcessingOrder = QueueProcessingOrder.OldestFirst
            });
    });

    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
});

// ==========================================================
// 8?? FORWARDED HEADERS (NGINX / LINUX VPS)
// ==========================================================
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor |
        ForwardedHeaders.XForwardedProto;

    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

// ==========================================================
// 9?? HTTP CLIENT
// ==========================================================

// ?? Local API
var apiBaseUrl = builder.Configuration["Api:BaseUrl"]
    ?? throw new InvalidOperationException("Api:BaseUrl is not configured.");
//builder.Services.AddHttpClient<ApiClient>(client =>
//{
//    client.BaseAddress = new Uri("https://localhost:5003/");
//});

// ?? Production API (Uncomment in production)
//builder.Services.AddHttpClient<ApiClient>(client =>
//{
//    client.BaseAddress = new Uri("https://apihost.freightbook.in/");
//});
builder.Services.AddHttpClient<ApiClient>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});


// ==========================================================
// ?? LOCALIZATION
// ==========================================================
builder.Services.AddLocalization();
builder.Services.AddControllers();
builder.Services.AddMvc();

// ==========================================================
// 1??1?? YOUR SCOPED SERVICES (UNCHANGED)
// ==========================================================

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
builder.Services.AddScoped<VehicleService>();
builder.Services.AddSingleton<ShippingManagementService>();

// PDF Services
builder.Services.AddScoped<DataCleanupService>();
builder.Services.AddScoped<ExportJobBuilderService>();
builder.Services.AddScoped<ExportPdfExtractorService>();
builder.Services.AddScoped<FreightBKShippingWebApp.Services.PdfReaderAndHelperService.PdfDetailedExtractorService>(); 
builder.Services.AddScoped<JobDataCreationService>();
builder.Services.AddScoped<JobBuilderService>();

// Mail + Other Services
builder.Services.AddScoped<ChatwayService>();
builder.Services.AddScoped<SendWpMailService>();
builder.Services.AddScoped<WpMailConfigService>();
builder.Services.AddScoped<Sentwpcerti>();
builder.Services.AddScoped<FileUploadService>();
builder.Services.AddScoped<JournalService>();
builder.Services.AddScoped<LrApiService>();
builder.Services.AddScoped<AuthTokenService>();
builder.Services.AddScoped<IBranchContext, BranchContext>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IGenericReportManager, GenericReportManager>();

// ==========================================================
// ?? BUILD APP
// ==========================================================
var app = builder.Build();

// ==========================================================
// ?? MIDDLEWARE ORDER (VERY IMPORTANT)
// ==========================================================

// 1?? Forwarded headers FIRST (Linux VPS)
app.UseForwardedHeaders();

// 2?? Exception + HSTS (Production only)
if (!app.Environment.IsDevelopment())
{
    // 500 — unhandled server errors
    app.UseExceptionHandler("/500");
    app.UseHsts();
}
else
{
    // Development mein bhi 500 page show karo
    app.UseExceptionHandler("/500");
}

app.UseStatusCodePages(async context =>
{
    var code = context.HttpContext.Response.StatusCode;
    if (code == 403)
    {
        context.HttpContext.Response.Redirect("/403");
    }
    else if (code == 404)
    {
        context.HttpContext.Response.Redirect("/404");
    }
    else if (code == 500)
    {
        context.HttpContext.Response.Redirect("/500");
    }
});
// 3?? HTTPS
app.UseHttpsRedirection();

// 4?? Compression
app.UseResponseCompression();

// 5?? Security Headers (CSP)
app.UseSecurityHeaders();

// 6?? Static files
app.UseStaticFiles();

// 7?? Anti-forgery
app.UseAntiforgery();

// 8?? Rate limiter (BEFORE endpoints)
app.UseRateLimiter();

// 9?? Output Cache
app.UseOutputCache();

// ?? Map Blazor
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapControllers();
app.Run();

