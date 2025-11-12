using System.Text.RegularExpressions;

public class PdfDetailedExtractorService
{
    private readonly ILogger<PdfDetailedExtractorService> _logger;

    public PdfDetailedExtractorService(ILogger<PdfDetailedExtractorService> logger)
    {
        _logger = logger;
    }

    public async Task ExtractChaDetailsAsync(string text, Dictionary<string, string> data)
    {
        try
        {
            var chaMatch = Regex.Match(text, @"CHA Details.*?(?=UCR Number)",
                RegexOptions.Singleline | RegexOptions.IgnoreCase);

            if (chaMatch.Success)
            {
                var chaSection = chaMatch.Value;

                var codeMatch = Regex.Match(chaSection, @"^([A-Z0-9]+CH\d+)\s+Br\.Slno", RegexOptions.Multiline);
                if (codeMatch.Success)
                    data["CHA Code"] = codeMatch.Groups[1].Value.Trim();

                var nameMatch = Regex.Match(chaSection, @"M/S\s+([^\n]+?)(?=\s*OFFICE|\s*OM MARBLE|\n)", RegexOptions.Multiline);
                if (nameMatch.Success)
                    data["CHA Name"] = nameMatch.Groups[1].Value.Trim();

                var addressMatch = Regex.Match(chaSection,
                    @"M/S\s+[^\n]+\n(.*?)(?=OM MARBLE|GUJARAT-\d{6})", RegexOptions.Singleline);

                if (addressMatch.Success)
                {
                    var addressLines = addressMatch.Groups[1].Value
                        .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(line => line.Trim())
                        .Where(line => !string.IsNullOrWhiteSpace(line) && !line.Contains("OM MARBLE") && !line.Contains("Br.Slno"))
                        .ToList();

                    if (addressLines.Any())
                        data["CHA Address"] = string.Join(", ", addressLines);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"CHA extraction error: {ex.Message}");
        }
    }

    public async Task ExtractImporterDetailsAsync(string text, Dictionary<string, string> data)
    {
        try
        {
            var importerCodeMatch = Regex.Match(text, @"Importer Details\s*:\s*([A-Z0-9]+)\s*\n");
            if (importerCodeMatch.Success)
                data["Importer Code"] = importerCodeMatch.Groups[1].Value.Trim();

            var panMatch = Regex.Match(text, @"Br\.Slno\s*:\s*0\s*PAN\s*:\s*([A-Z0-9]+)");
            if (panMatch.Success)
                data["Importer PAN"] = panMatch.Groups[1].Value.Trim();

            var importerNameMatch = Regex.Match(text,
                @"PAN\s*:\s*[A-Z0-9]+\s*\n(?:.*?\s)?([A-Z]+\s+[A-Z]+\s+COMPANY)", RegexOptions.Singleline);

            if (importerNameMatch.Success)
                data["Importer Name"] = importerNameMatch.Groups[1].Value.Trim();

            var addressMatch = Regex.Match(text,
                @"COMPANY\s*\n(.*?)(?=GUJARAT-\d{6})", RegexOptions.Singleline);

            if (addressMatch.Success)
            {
                var addressLines = addressMatch.Groups[1].Value
                    .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(line => line.Trim())
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .ToList();

                if (addressLines.Any())
                    data["Importer Address"] = string.Join(", ", addressLines);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Importer extraction error: {ex.Message}");
        }
    }

    public async Task ExtractSupplierDetailsAsync(string text, Dictionary<string, string> data)
    {
        try
        {
            var supplierSection = Regex.Match(text,
                @"SUPPLIER DETAILS.*?\n-+\s*\n(.*?)(?=ITEM DETAILS|-{5,}.*?ITEM DETAILS)",
                RegexOptions.Singleline | RegexOptions.IgnoreCase);

            if (supplierSection.Success)
            {
                var section = supplierSection.Groups[1].Value;
                var lines = section.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(l => l.Trim())
                    .Where(l => !string.IsNullOrWhiteSpace(l))
                    .ToList();

                var supplierLines = new List<string>();

                foreach (var line in lines)
                {
                    var parts = Regex.Split(line, @"\s{3,}");
                    if (parts.Length >= 2)
                    {
                        var rightColumn = parts[parts.Length - 1].Trim();
                        if (!string.IsNullOrWhiteSpace(rightColumn) &&
                            !rightColumn.Contains("Inv.") &&
                            !rightColumn.Contains("Under SVB") &&
                            !rightColumn.Contains("Freight") &&
                            !rightColumn.Contains("Insurance") &&
                            rightColumn.Length > 2)
                        {
                            supplierLines.Add(rightColumn);
                        }
                    }
                }

                if (supplierLines.Count >= 1)
                {
                    data["Supplier Name"] = supplierLines[0];

                    if (supplierLines.Count >= 2)
                    {
                        var addressParts = supplierLines.Skip(1)
                            .Select(a => Regex.Replace(a, @"^E\s+", "").Trim())
                            .Where(a => !string.IsNullOrWhiteSpace(a));

                        data["Supplier Address"] = string.Join(", ", addressParts);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Supplier extraction error: {ex.Message}");
        }
    }

    public async Task ExtractItemDetailsAsync(string text, Dictionary<string, string> data)
    {
        try
        {
            var itemMatch = Regex.Match(text,
                @"ITEM DETAILS.*?Slno\s+RITC\s+Description.*?\n\d+\s+(\d+)\s+([^\n]+?)\n([\d\.]+)\s+([\d\.]+)",
                RegexOptions.Singleline);

            if (itemMatch.Success)
            {
                data["Item RITC"] = itemMatch.Groups[1].Value.Trim();
                data["Item Description"] = itemMatch.Groups[2].Value.Trim();
                data["Item Quantity"] = itemMatch.Groups[3].Value.Trim();
                data["Item Unit Price"] = itemMatch.Groups[4].Value.Trim();
            }

            var cooMatch = Regex.Match(text, @"Unit Price\s+COO.*?\n[\d\.]+\s+[\d\.]+\s+([A-Z]+)\s+", RegexOptions.Multiline);
            if (cooMatch.Success)
                data["Item COO"] = cooMatch.Groups[1].Value.Trim();

            var assValueMatch = Regex.Match(text, @"Unit\s+Ass Value.*?\n[A-Z]+\s+([\d,\.]+)", RegexOptions.Multiline);
            if (assValueMatch.Success)
                data["Assessable Value"] = assValueMatch.Groups[1].Value.Trim();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Item extraction error: {ex.Message}");
        }
    }

    public async Task ExtractContainerDetailsAsync(string text, Dictionary<string, string> data)
    {
        try
        {
            var containerSection = Regex.Match(text,
                @"CONTAINER DETAILS.*?(?=GSTIN Details)",
                RegexOptions.Singleline | RegexOptions.IgnoreCase);

            if (containerSection.Success)
            {
                var section = containerSection.Value;
                var containerMatches = Regex.Matches(section,
                    @"\d+\s*/\s*\d+\s+([A-Z]{4}\d{7})\s+[A-Z]\s+[A-Z]\s+(\d+)\s+Standard\s+Dry",
                    RegexOptions.Multiline);

                var containers = new List<string>();
                var sizes = new List<int>();

                foreach (Match match in containerMatches)
                {
                    containers.Add(match.Groups[1].Value);
                    sizes.Add(int.Parse(match.Groups[2].Value));
                }

                if (containers.Any())
                {
                    data["Container Numbers"] = string.Join(", ", containers);
                    data["Container Count"] = containers.Count.ToString();

                    var size20 = sizes.Count(s => s == 20);
                    var size40 = sizes.Count(s => s == 40);
                    var size45 = sizes.Count(s => s == 45);

                    if (size20 > 0) data["Count 20 Ft"] = size20.ToString();
                    if (size40 > 0) data["Count 40 Ft"] = size40.ToString();
                    if (size45 > 0) data["Count 45 Ft"] = size45.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Container extraction error: {ex.Message}");
        }
    }

    public async Task ExtractDutyDetailsAsync(string text, Dictionary<string, string> data)
    {
        try
        {
            TryExtract(text, data, "Total Customs Duty", @"Total Customs Duty\s*:\s*([\d,\.]+)");
            TryExtract(text, data, "Total IGST Duty", @"Total IGST Duty\s*:\s*([\d,\.]+)");
            TryExtract(text, data, "Grand Total Customs", @"Grand Total Custom Duty\s*:\s*([\d,\.]+)");
            TryExtract(text, data, "Grand Total IGST", @"Grand Total IGST Duty\s*:\s*([\d,\.]+)");

            var netAmtMatch = Regex.Match(text, @"Net Amt\.Rs\.\s*([\d,\.]+)\s+([\d,\.]+)");
            if (netAmtMatch.Success)
            {
                data["Assessable Value Total"] = netAmtMatch.Groups[1].Value.Trim();
                data["Duty Payable"] = netAmtMatch.Groups[2].Value.Trim();
            }

            TryExtract(text, data, "Duty In Words", @"DUTY PAYABLE\s*:\s*Rupees\s+([^\n-]+)");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Duty extraction error: {ex.Message}");
        }
    }

    private void TryExtract(string text, Dictionary<string, string> data, string key, string pattern, int groupIndex = 1)
    {
        try
        {
            var match = Regex.Match(text, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if (match.Success && match.Groups.Count > groupIndex)
            {
                var value = match.Groups[groupIndex].Value.Trim();
                if (!string.IsNullOrWhiteSpace(value))
                    data[key] = value;
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning($"Extract error for {key}: {ex.Message}");
        }
    }



}