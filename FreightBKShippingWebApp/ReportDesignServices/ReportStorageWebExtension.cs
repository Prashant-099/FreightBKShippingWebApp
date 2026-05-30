
using FreightBKShippingWebApp.Services;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web.Extensions;
using System.Text;
using System.Text.Json;
using FreightBKShippingWebApp.ReportDesignServices;
using FreightBKShippingWebApp.Model;

public class CustomReportStorageWebExtension : ReportStorageWebExtension
{
    private readonly ReportContextService _context;
    private readonly ReportDataService _reportDataService;
    private readonly ILogger<CustomReportStorageWebExtension> _logger;
    private readonly Dictionary<string, string> _layoutCache = new();
    private readonly SemaphoreSlim _cacheLock = new(1, 1);

    public CustomReportStorageWebExtension(
        ReportContextService context,
        ReportDataService reportDataService,
        ILogger<CustomReportStorageWebExtension> logger)
    {
        _context = context;
        _reportDataService = reportDataService;
        _logger = logger;
    }

    public override bool CanSetData(string url) => true;
    public override bool IsValidUrl(string url) => true;

    // Preload layouts into memory cache
    public async Task PreloadLayoutsAsync()
    {
        await _cacheLock.WaitAsync();
        try
        {
            _layoutCache.Clear();
            var reports = await _reportDataService.GetAllAsync();

            foreach (var report in reports)
            {
                if (report?.ReportDataId != null)
                {
                    var bytes = await _reportDataService.GetLayoutBytesAsync(report.ReportDataId);
                    if (bytes != null)
                        _layoutCache[report.ReportDataId.ToString()] = Encoding.UTF8.GetString(bytes);
                }
            }

            _logger.LogInformation("✅ Preloaded {Count} report layouts into cache", _layoutCache.Count);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to preload layouts");
        }
        finally
        {
            _cacheLock.Release();
        }
    }

    // Load layout (sync wrapper for async operations)
    //public override byte[] GetData(string url)
    //{
    //    try
    //    {
    //        // Use Task.Run to avoid deadlocks
    //        return Task.Run(() => GetDataAsync(url)).GetAwaiter().GetResult();
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "❌ GetData failed for URL: {Url}", url);
    //        throw;
    //    }
    //}

    //private async Task<byte[]> GetDataAsync(string url)
    //{
    //    var key = url.TrimStart('/');

    //    // 1. Check cache first
    //    if (_layoutCache.TryGetValue(key, out string? xml))
    //    {
    //        _logger.LogDebug("✅ Cache hit for: {Key}", key);
    //        return Encoding.UTF8.GetBytes(xml);
    //    }

    //    // 2. Try to parse metadata from base64
    //    ReportData? metadata = TryDecodeMetadata(key);

    //    if (metadata != null)
    //    {
    //        if (metadata.ReportDataId > 0)
    //        {
    //            // Existing report - load from DB
    //            if (!string.IsNullOrEmpty(metadata.LayoutData))
    //            {
    //                return Encoding.UTF8.GetBytes(metadata.LayoutData);
    //            }

    //            var bytes = await _reportDataService.GetLayoutBytesAsync(metadata.ReportDataId);
    //            if (bytes != null)
    //            {
    //                // Update cache
    //                await UpdateCacheAsync(metadata.ReportDataId.ToString(), Encoding.UTF8.GetString(bytes));
    //                return bytes;
    //            }

    //            throw new Exception($"❌ No layout data found for ID: {metadata.ReportDataId}");
    //        }
    //        else
    //        {
    //            // New report - return blank template
    //            _logger.LogInformation("📄 Creating blank report template");
    //            using var ms = new MemoryStream();
    //            new XtraReport().SaveLayoutToXml(ms);
    //            return ms.ToArray();
    //        }
    //    }

    //    // 3. Try direct numeric ID
    //    if (int.TryParse(key, out int reportId))
    //    {
    //        var bytes = await _reportDataService.GetLayoutBytesAsync(reportId);
    //        if (bytes != null)
    //        {
    //            await UpdateCacheAsync(reportId.ToString(), Encoding.UTF8.GetString(bytes));
    //            return bytes;
    //        }
    //    }

    //    throw new Exception($"❌ Report layout not found for URL: {url}");
    //}
    public override byte[] GetData(string url)
    {
        try
        {
            // ✅ Task.Run से deadlock avoid होगा
            return Task.Run(async () => await GetDataInternalAsync(url))
                .GetAwaiter()
                .GetResult();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetData failed for: {Url}", url);
            throw;
        }
    }

    private async Task<byte[]> GetDataInternalAsync(string url)
    {
        var key = url.TrimStart('/');

        // Cache check
        if (_layoutCache.TryGetValue(key, out string? xml))
        {
            return Encoding.UTF8.GetBytes(xml);
        }

        // Try base64 decode
        try
        {
            var metadata = JsonSerializer.Deserialize<ReportData>(
                Encoding.UTF8.GetString(Convert.FromBase64String(key)));

            if (metadata != null)
            {
                if (metadata.ReportDataId > 0)
                {
                    var bytes = await _reportDataService.GetLayoutBytesAsync(metadata.ReportDataId);
                    if (bytes != null) return bytes;
                }
                else
                {
                    // New report
                    using var ms = new MemoryStream();
                    new XtraReport().SaveLayoutToXml(ms);
                    return ms.ToArray();
                }
            }
        }
        catch
        {
            // Fallback to numeric ID
            if (int.TryParse(key, out int reportId))
            {
                var bytes = await _reportDataService.GetLayoutBytesAsync(reportId);
                if (bytes != null) return bytes;
            }
        }

        throw new Exception($"Report not found: {url}");
    }

    public override void SetData(XtraReport report, string url)
    {
        try
        {
            Task.Run(async () => await SetOrCreateDataInternalAsync(report, url))
                .GetAwaiter()
                .GetResult();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "SetOrCreateData failed");
            throw;
        }
    }

    private async Task SetOrCreateDataInternalAsync(XtraReport report, string url)
    {
        var key = url.TrimStart('/');

        ReportData? metadata = null;

        // Decode metadata
        try
        {
            metadata = JsonSerializer.Deserialize<ReportData>(
                Encoding.UTF8.GetString(Convert.FromBase64String(key)));

            if (metadata?.ReportDataId > 0)
                key = metadata.ReportDataId.ToString();
        }
        catch { }

        // Try parse ID
        int reportId = 0;
        int.TryParse(key, out reportId);

        // Save current layout
        using var ms = new MemoryStream();
        report.SaveLayoutToXml(ms);
        var layoutXml = Encoding.UTF8.GetString(ms.ToArray());

        // Ensure metadata exists
        if (metadata == null)
            metadata = new ReportData();

        metadata.LayoutData = layoutXml;

        // Determine whether to create or update
        bool success;
        if (metadata.ReportDataId > 0 || reportId > 0)
        {
            // Existing → Update
            metadata.ReportDataId = metadata.ReportDataId > 0 ? metadata.ReportDataId : reportId;
            success = await _reportDataService.UpdateAsync(metadata);
            if (!success)
                throw new Exception("Update failed");

            _layoutCache[metadata.ReportDataId.ToString()] = layoutXml;
        }
        else
        {
            // New → Create
            var newId = await _reportDataService.CreateAsync(metadata);
            if (!newId.HasValue)
                throw new Exception("Create failed");

            metadata.ReportDataId = newId.Value;
            _layoutCache[newId.Value.ToString()] = layoutXml;
        }
    }
    // Save report layout
    //public override void SetData(XtraReport report, string url)
    //{
    //    try
    //    {
    //        // Use Task.Run to avoid deadlocks
    //        Task.Run(() => SetDataAsync(report, url)).GetAwaiter().GetResult();
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "❌ SetData failed for URL: {Url}", url);
    //        throw;
    //    }
    //}

    //private async Task SetDataAsync(XtraReport report, string url)
    //{
    //    var key = url.TrimStart('/');

    //    // Try to extract ID from metadata
    //    var metadata = TryDecodeMetadata(key);
    //    if (metadata?.ReportDataId > 0)
    //    {
    //        key = metadata.ReportDataId.ToString();
    //    }

    //    if (!int.TryParse(key, out int reportId))
    //    {
    //        throw new Exception($"❌ Invalid report ID: {key}");
    //    }

    //    // Serialize report layout
    //    using var ms = new MemoryStream();
    //    report.SaveLayoutToXml(ms);
    //    var layoutXml = Encoding.UTF8.GetString(ms.ToArray());

    //    // Save to database
    //    var reportData = new ReportData
    //    {
    //        ReportDataId = reportId,
    //        LayoutData = layoutXml
    //    };

    //    bool success = await _reportDataService.UpdateAsync(reportData);

    //    if (success)
    //    {
    //        // Update cache
    //        await UpdateCacheAsync(reportId.ToString(), layoutXml);
    //        _logger.LogInformation("✅ Saved report ID: {ReportId}", reportId);
    //    }
    //    else
    //    {
    //        throw new Exception($"❌ Failed to save report ID: {reportId}");
    //    }
    //}

    //second attempt strted here===============================================================
    //public override void SetData(XtraReport report, string url)
    //{
    //    try
    //    {
    //        Task.Run(async () => await SetDataInternalAsync(report, url))
    //            .GetAwaiter()
    //            .GetResult();

    //     }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "SetData failed");
    //        throw;
    //    }
    //}

    //private async Task SetDataInternalAsync(XtraReport report, string url)
    //{
    //    var key = url.TrimStart('/');

    //    ReportData? metadata = null;

    //    // Decode metadata
    //    try
    //    {
    //        metadata = JsonSerializer.Deserialize<ReportData>(
    //            Encoding.UTF8.GetString(Convert.FromBase64String(key)));

    //        if (metadata?.ReportDataId > 0)
    //            key = metadata.ReportDataId.ToString();
    //    }
    //    catch { }

    //    if (!int.TryParse(key, out int reportId))
    //        throw new Exception($"Invalid ID: {key}");

    //    // Save layout
    //    using var ms = new MemoryStream();
    //    report.SaveLayoutToXml(ms);
    //    var layoutXml = Encoding.UTF8.GetString(ms.ToArray());

    //    // ⚡ Yahan fix kiya hai
    //    ReportData reportData;

    //    if (metadata != null)
    //    {
    //        // Use existing metadata object
    //        reportData = metadata;
    //        reportData.LayoutData = layoutXml; // sirf layout update karo
    //    }
    //    else
    //    {
    //        // fallback in case metadata not found
    //        reportData = new ReportData
    //        {
    //            ReportDataId = reportId,
    //            LayoutData = layoutXml
    //        };
    //    }

    //    bool success = await _reportDataService.UpdateAsync(reportData);
    //    if (!success)
    //        throw new Exception("Update failed");

    //    // Update cache
    //    _layoutCache[reportId.ToString()] = layoutXml;
    //}




    //public override string SetNewData(XtraReport report, string defaultUrl)
    //{
    //    try
    //    {
    //        return Task.Run(async () => await SetNewDataInternalAsync(report, defaultUrl))
    //            .GetAwaiter()
    //            .GetResult() ?? throw new Exception("Create failed");
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "SetNewData failed");
    //        throw;
    //    }
    //}

    //private async Task<string?> SetNewDataInternalAsync(XtraReport report, string defaultUrl)
    //{
    //    var metadata = _context.CurrentReportData;
    //    if (metadata == null)
    //        throw new Exception("No metadata in context");

    //    using var ms = new MemoryStream();
    //    report.SaveLayoutToXml(ms);
    //    metadata.LayoutData = Encoding.UTF8.GetString(ms.ToArray());

    //    var newId = await _reportDataService.CreateAsync(metadata);
    //    if (newId.HasValue)
    //    {
    //        _layoutCache[newId.Value.ToString()] = metadata.LayoutData;
    //        return newId.Value.ToString();
    //    }

    //    return null;
    //}
    //second attempt done here ====================================================================

    //
    // Create new report
    //public override string SetNewData(XtraReport report, string defaultUrl)
    //{
    //    try
    //    {
    //        // Use Task.Run to avoid deadlocks
    //        return Task.Run(() => SetNewDataAsync(report, defaultUrl)).GetAwaiter().GetResult()
    //            ?? throw new Exception("❌ Failed to create new report");
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex, "❌ SetNewData failed");
    //        throw;
    //    }
    //}

    //private async Task<string?> SetNewDataAsync(XtraReport report, string defaultUrl)
    //{
    //    // Get metadata from context
    //    var metadata = _context.CurrentReportData;
    //    if (metadata == null)
    //    {
    //        throw new Exception("⚠️ No report metadata available in context");
    //    }

    //    // Serialize layout
    //    using var ms = new MemoryStream();
    //    report.SaveLayoutToXml(ms);
    //    metadata.LayoutData = Encoding.UTF8.GetString(ms.ToArray());

    //    // Save to database
    //    var newId = await _reportDataService.CreateAsync(metadata);

    //    if (newId.HasValue)
    //    {
    //        // Update cache
    //        await UpdateCacheAsync(newId.Value.ToString(), metadata.LayoutData);
    //        _logger.LogInformation("✅ Created new report ID: {ReportId}", newId.Value);

    //        // Return the new ID as the URL
    //        return newId.Value.ToString();
    //    }

    //    return null;
    //}

    // Get list of reports for designer
    public override async Task<Dictionary<string, string>> GetUrlsAsync()
    {
        try
        {
            _logger.LogInformation("🔍 GetUrlsAsync called");

            var dict = await _reportDataService.GetDesignerReportsListAsync();

            _logger.LogInformation("✅ Returned {Count} reports", dict?.Count ?? 0);

            return dict ?? new Dictionary<string, string>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "GetUrlsAsync failed");
            return new Dictionary<string, string>();
        }
    }

    // Helper: Try to decode base64 metadata
    private ReportData? TryDecodeMetadata(string key)
    {
        try
        {
            var json = Encoding.UTF8.GetString(Convert.FromBase64String(key));
            return JsonSerializer.Deserialize<ReportData>(json);
        }
        catch
        {
            return null;
        }
    }

    // Helper: Update cache safely
    private async Task UpdateCacheAsync(string key, string value)
    {
        await _cacheLock.WaitAsync();
        try
        {
            _layoutCache[key] = value;
        }
        finally
        {
            _cacheLock.Release();
        }
    }
}
