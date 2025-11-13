using System.Text.RegularExpressions;

/// <summary>
/// Service for cleaning and normalizing extracted PDF field values
/// </summary>
public class DataCleanupService
{
    private readonly ILogger<DataCleanupService> _logger;

    public DataCleanupService(ILogger<DataCleanupService> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Cleans and normalizes a string value from PDF extraction
    /// Removes control characters, normalizes spaces and dashes, removes junk content
    /// </summary>
    /// <param name="value">Raw extracted value</param>
    /// <returns>Cleaned value or null if value is invalid/empty after cleanup</returns>
    public string CleanValue(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        try
        {
            var v = value;

            // Remove control characters and normalize dashes
            v = v.Replace("\r", "")
                 .Replace("\n", "")
                 .Replace("\u000C", "") // Form feed
                 .Replace("\u000B", "") // Vertical tab
                 .Replace("–", "-")     // En dash
                 .Replace("—", "-")     // Em dash
                 .Trim();

            // Collapse multiple spaces into one
            v = Regex.Replace(v, @"\s+", " ");

            // Replace sequences of 3+ dashes with single dash
            v = Regex.Replace(v, @"-{3,}", "-");

            // Trim dashes and spaces from edges
            v = v.Trim('-', ' ');

            // If only dashes or underscores, return null
            if (Regex.IsMatch(v, @"^[-_]+$"))
                return null;

            // Handle cases like "AS PER BL ---- INVOICE DETAILS"
            // Keep only the meaningful part before long dashes
            if (Regex.IsMatch(v, @"-{2,}") &&
                Regex.IsMatch(v, @"INVOICE|DETAIL|NUMBER|TOTAL", RegexOptions.IgnoreCase))
            {
                v = Regex.Replace(v, @"-{2,}.*", "").Trim();
            }

            // Clean up any remaining long dash sequences
            v = Regex.Replace(v, @"-{2,}", "-");

            // Final trim
            v = v.Trim();

            // If it becomes empty after cleanup, return null
            if (string.IsNullOrEmpty(v))
                return null;

            // Prevent excessively long values
            if (v.Length > 1000)
                v = v.Substring(0, 1000);

            return v;
        }
        catch (Exception ex)
        {
            _logger.LogWarning($"Error cleaning value: {ex.Message}");
            return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }
    }

    /// <summary>
    /// Cleans multiple values and returns non-null ones
    /// </summary>
    public List<string> CleanValues(params string[] values)
    {
        return values
            .Select(CleanValue)
            .Where(v => v != null)
            .ToList();
    }

    /// <summary>
    /// Parses a numeric value, handling currency symbols and formatting
    /// </summary>
    public double? ParseNumericValue(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        try
        {
            var cleaned = CleanValue(value);
            if (string.IsNullOrWhiteSpace(cleaned))
                return null;

            // Remove currency symbols and common separators
            cleaned = Regex.Replace(cleaned, @"[$€£¥₹,\s]", "");

            if (double.TryParse(cleaned, out var result))
                return result;

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogWarning($"Error parsing numeric value '{value}': {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Parses a date value in various formats
    /// </summary>
    public DateTime? ParseDateValue(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        try
        {
            var cleaned = CleanValue(value);
            if (string.IsNullOrWhiteSpace(cleaned))
                return null;

            // Try common date formats
            string[] formats = new[]
            {
                "dd/MM/yyyy",
                "d/M/yyyy",
                "dd-MM-yyyy",
                "d-M-yyyy",
                "yyyy-MM-dd",
                "yyyy/MM/dd",
                "dd MMM yyyy",
                "dd MMMM yyyy"
            };

            if (DateTime.TryParseExact(cleaned, formats, null, System.Globalization.DateTimeStyles.None, out var result))
                return result;

            // Fallback to general parsing
            if (DateTime.TryParse(cleaned, out var generalResult))
                return generalResult;

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogWarning($"Error parsing date value '{value}': {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Validates if a value appears to be a valid identifier (alphanumeric)
    /// </summary>
    public bool IsValidIdentifier(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;

        var cleaned = CleanValue(value);
        return !string.IsNullOrWhiteSpace(cleaned) &&
               Regex.IsMatch(cleaned, @"^[A-Z0-9\s\-/]+$", RegexOptions.IgnoreCase);
    }

    /// <summary>
    /// Extracts email if value contains one
    /// </summary>
    public string ExtractEmail(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        var match = Regex.Match(value, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}");
        return match.Success ? match.Value : null;
    }

    /// <summary>
    /// Extracts phone number if value contains one
    /// </summary>
    public string ExtractPhone(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        var match = Regex.Match(value, @"[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}");
        return match.Success ? match.Value : null;
    }

    /// <summary>
    /// Normalizes a container number format
    /// </summary>
    public string NormalizeContainerNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return null;

        var cleaned = CleanValue(value);
        if (string.IsNullOrWhiteSpace(cleaned))
            return null;

        // Container format: OWNER CODE (4 letters) + SERIAL (6 digits) + CHECK DIGIT (1 digit)
        cleaned = Regex.Replace(cleaned, @"\s", "").ToUpper();

        // If it looks like a valid container number
        if (Regex.IsMatch(cleaned, @"^[A-Z]{4}\d{7}$"))
            return cleaned;

        return cleaned;
    }
}
