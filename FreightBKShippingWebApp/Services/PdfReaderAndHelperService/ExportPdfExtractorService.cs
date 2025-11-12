using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System.Text;
using System.Text.RegularExpressions;

namespace FreightBKShippingWebApp.Services.PdfReaderAndHelperService
{
    public class ExportPdfExtractorService
    {
        private readonly ILogger<ExportPdfExtractorService> _logger;

        public ExportPdfExtractorService(ILogger<ExportPdfExtractorService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Extracts all EXPORT PDF fields (72 matching fields)
        /// </summary>
        public async Task<Dictionary<string, string>> ExtractExportFieldsAsync(byte[] pdfBytes)
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            try
            {
                using var stream = new MemoryStream(pdfBytes);
                using var reader = new PdfReader(stream);
                using var pdf = new iText.Kernel.Pdf.PdfDocument(reader);

                var sb = new StringBuilder();
                for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
                {
                    var pageText = PdfTextExtractor.GetTextFromPage(pdf.GetPage(i), new LocationTextExtractionStrategy());
                    sb.AppendLine(pageText);
                }

                var text = Regex.Replace(sb.ToString(), @"\r\n|\r", "\n");

                data["PDF Type"] = "EXPORT";
                _logger.LogInformation("🔍 Starting EXPORT PDF extraction...");

                // ==================== 1. HEADER & IDENTIFICATION (4 fields) ====================
                ExtractHeaderFields(text, data);

                // ==================== 2. CHA DETAILS (4 fields) ====================
                ExtractChaDetails(text, data);

                // ==================== 3. EXPORTER DETAILS (7 fields) ====================
                ExtractExporterDetails(text, data);

                // ==================== 4. CONSIGNEE DETAILS (8 fields) ====================
                ExtractConsigneeDetails(text, data);

                // ==================== 5. CARGO DETAILS (9 fields) ====================
                ExtractCargoDetails(text, data);

                // ==================== 6. INVOICE DETAILS (12 fields) ====================
                ExtractInvoiceDetails(text, data);

                // ==================== 7. CHARGES & DEDUCTIONS (8 fields) ====================
                ExtractChargesDeductions(text, data);

                // ==================== 8. ITEMS OF EXPORT (6 fields) ====================
                ExtractItemsOfExport(text, data);

                // ==================== 9. DUTY & TAX DETAILS (4 fields) ====================
                ExtractDutyTaxDetails(text, data);

                // ==================== 10. CONTAINER DETAILS (5 fields) ====================
                ExtractContainerDetails(text, data);

                // ==================== 11. PACKING DETAILS (3 fields) ====================
                ExtractPackingDetails(text, data);

                // ==================== 12. ADDITIONAL INFO (2 fields) ====================
                ExtractAdditionalInfo(text, data);

                _logger.LogInformation($"✅ EXPORT extraction complete! Total fields: {data.Count}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error extracting EXPORT PDF");
            }

            return await Task.FromResult(data);
        }

        // ==================== 1. HEADER FIELDS ====================
        private void ExtractHeaderFields(string text, Dictionary<string, string> data)
        {
            try
            {
                TryExtract(text, data, "Job No", @"Icegate Job No\s*:(\d+)");
                TryExtract(text, data, "File No", @"File Reference No:(\d+)");
                TryExtract(text, data, "Job Date", @"Date:(\d{1,2}/\d{1,2}/\d{4})");
                TryExtract(text, data, "Printed On", @"Printed On:(\d{1,2}/\d{1,2}/\d{4})");

                _logger.LogInformation("✅ Header fields extracted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Header extraction: {ex.Message}");
            }
        }

        // ==================== 2. CHA DETAILS ====================
        private void ExtractChaDetails(string text, Dictionary<string, string> data)
        {
            try
            {
                TryExtract(text, data, "CHA Code", @"CHA\s*:([A-Z0-9]+NCH\d+)");
                TryExtract(text, data, "CHA Name", @"CHA\s*:[A-Z0-9]+NCH\d+\s+Name\s*:([^\n]+)");
                TryExtract(text, data, "Port of Loading", @"Port of Loading:([^\n]+)");
                TryExtract(text, data, "State of Origin Code", @"State of Origin,Code\s*:([^\n]+)");

                _logger.LogInformation("✅ CHA details extracted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ CHA extraction: {ex.Message}");
            }
        }

        // ==================== 3. EXPORTER DETAILS ====================
        private void ExtractExporterDetails(string text, Dictionary<string, string> data)
        {
            try
            {
                // Extract Exporter Code & Name
                var exporterMatch = Regex.Match(text, @"EXPORTER DETAILS\s*:\s*(\d+)\s*\n(.*?)(?=Branch Sr|Type of)", RegexOptions.Singleline);
                if (exporterMatch.Success)
                {
                    data["Exporter Code"] = exporterMatch.Groups[1].Value.Trim();
                    var nameLines = exporterMatch.Groups[2].Value.Trim().Split('\n');
                    if (nameLines.Length > 0)
                        data["Exporter Name"] = nameLines[0].Trim();
                }

                // Extract Address Lines
                var addressMatch = Regex.Match(text, @"EXPORTER DETAILS\s*:.*?\n\d+\s+\n(.*?)(?=Branch Sr)", RegexOptions.Singleline);
                if (addressMatch.Success)
                {
                    var lines = addressMatch.Groups[1].Value.Split('\n').Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
                    if (lines.Count >= 2)
                    {
                        data["Exporter Address Line 1"] = lines[1].Trim();
                    }
                    if (lines.Count >= 3)
                    {
                        data["Exporter Address Line 2"] = lines[2].Trim();
                    }
                }

                TryExtract(text, data, "Exporter Type", @"Type of Exporter\s*:\[([^\]]+)\]");
                TryExtract(text, data, "Adcode", @"Adcode\s*:(\d+)");
                TryExtract(text, data, "Forex Bank Account", @"Forex Bank A/c No\s*:(\d+)");

                _logger.LogInformation("✅ Exporter details extracted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Exporter extraction: {ex.Message}");
            }
        }

        // ==================== 4. CONSIGNEE DETAILS ====================
        private void ExtractConsigneeDetails(string text, Dictionary<string, string> data)
        {
            try
            {
                // Step 1: Extract the full CONSIGNEE block safely
                var consigneeBlockMatch = Regex.Match(
                    text,
                    @"CONSIGNEE DETAILS:\s*(?<block>[\s\S]*?)(?=\n\s*(?:Port of |EXPORTER DETAILS|NOTIFY PARTY|SHIPPER|CHA|Type of Exporter|$))",
                    RegexOptions.IgnoreCase
                );

                if (!consigneeBlockMatch.Success)
                {
                    _logger.LogWarning("⚠️ Consignee section not found");
                    return;
                }

                var block = consigneeBlockMatch.Groups["block"].Value;

                // Step 2: Extract Code + Name (first line)
                var codeNameMatch = Regex.Match(block, @"^\s*(\d+)\s+([^\n]+)", RegexOptions.Multiline);
                if (codeNameMatch.Success)
                {
                    data["Consignee Code"] = codeNameMatch.Groups[1].Value.Trim();
                    data["Consignee Name"] = CleanSpaces(codeNameMatch.Groups[2].Value);
                }

                // Step 3: Extract Address lines after Code+Name
                var afterNamePart = block.Substring(codeNameMatch.Success ? codeNameMatch.Index + codeNameMatch.Length : 0);

                var addressLines = afterNamePart
                    .Split('\n')
                    .Select(l => CleanSpaces(l))
                    .Where(l =>
                        !string.IsNullOrWhiteSpace(l) &&
                        !Regex.IsMatch(l, @"^(Branch|GSN|Type of Exporter|Port of|Exporter|CHA|Shipper)", RegexOptions.IgnoreCase)
                    )
                    .ToList();

                // Step 4: Save top 5 address lines
                for (int i = 0; i < Math.Min(addressLines.Count, 5); i++)
                    data[$"Consignee Address Line {i + 1}"] = addressLines[i];

                // Step 5: Combine into full address
                var fullAddress = string.Join(", ", addressLines);
                data["Consignee Full Address"] = CleanSpaces(fullAddress);

                _logger.LogInformation("✅ Consignee details extracted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Consignee extraction failed: {ex.Message}");
            }
        }
        /// <summary>
        /// Replace multiple spaces/tabs with single space and trim line.
        /// </summary>
        private static string CleanSpaces(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Collapse multiple spaces/tabs into one
            return Regex.Replace(input.Trim(), @"\s{2,}", " ");
        }



        // ==================== 5. CARGO DETAILS ====================
        private void ExtractCargoDetails(string text, Dictionary<string, string> data)
        {
            try
            {
                TryExtract(text, data, "Total Packages", @"Total Packages\s*:(\d+)");
                TryExtract(text, data, "Net Weight", @"Net Weight\s*:([\d,\.]+)\s*KGS");
                TryExtract(text, data, "Gross Weight", @"Gross Weight\s*:([\d,\.]+)\s*KGS");
                TryExtract(text, data, "Number of Containers", @"Number of Ctrs\s*:(\d+)");
                TryExtract(text, data, "Cargo Nature", @"Nature Of Cargo\.\s*:([C])\s+([^\n]+)");
                TryExtract(text, data, "Marks and Numbers", @"Marks and Nos\.\s*:([^\n]+)");
                TryExtract(text, data, "Seal Type", @"Seal Type\s*:([^\n]+)");
                TryExtract(text, data, "FOB Value INR", @"FOB Value\(INR\)\s*:(\d+)");
                TryExtract(text, data, "Drawback INR", @"DRAWBACK\(INR\)\s*:(\d+)");

                _logger.LogInformation("✅ Cargo details extracted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Cargo extraction: {ex.Message}");
            }
        }

        // ==================== 6. INVOICE DETAILS ====================
        private void ExtractInvoiceDetails(string text, Dictionary<string, string> data)
        {
            try
            {
                TryExtract(text, data, "Number of Invoices", @"Number of Invoices\s*:\s*(\d+)");
                TryExtract(text, data, "Invoice Number", @"Invoice Number\s*:([^\n]+)");
                TryExtract(text, data, "Invoice Date", @"Inv\.Date\s*:(\d{1,2}/\d{1,2}/\d{4})");
                TryExtract(text, data, "Invoice Value FC", @"Invoice Value\(FC\)\s*:(\d+)");
                TryExtract(text, data, "Invoice Value INR", @"Invoice Value\(INR\)\s*:(\d+)");
                TryExtract(text, data, "Currency Code", @"Currency Code\s*:([A-Z]{3})");
                TryExtract(text, data, "Exchange Rate", @"Exchange Rate\s*:(\d+)");
                TryExtract(text, data, "Nature of Contract", @"Nature Of Contract\s*:([^\n]+)");
                TryExtract(text, data, "Nature of Payment", @"Nature Of Payment\s*:([^\n]+)");
                TryExtract(text, data, "Buyer Details", @"Buyer Details\s*:([^\n]+)");
                TryExtract(text, data, "DBK Value INR", @"DBK Value\(INR\)\s*:(\d+)");
                TryExtract(text, data, "Unit Price Includes", @"Whether Unit Price Includes\s*:([^\n]+)");

                _logger.LogInformation("✅ Invoice details extracted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Invoice extraction: {ex.Message}");
            }
        }

        // ==================== 7. CHARGES & DEDUCTIONS ====================
        private void ExtractChargesDeductions(string text, Dictionary<string, string> data)
        {
            try
            {
                var chargesSection = Regex.Match(text, @"Insurance.*?\n(.*?)(?=Packing|ITEMS OF)", RegexOptions.Singleline);
                if (chargesSection.Success)
                {
                    var section = chargesSection.Value;
                    TryExtract(section, data, "Insurance Percentage", @"Insurance\s+(\d+)\s+");
                    TryExtract(section, data, "Insurance Currency", @"Insurance\s+\d+\s+([A-Z]{3})");
                    TryExtract(section, data, "Insurance Amount", @"Insurance\s+\d+\s+[A-Z]{3}\s+(\d+)");
                    TryExtract(section, data, "Freight Amount", @"Freight\s+\d+\s+([A-Z]{3})\s+(\d+)");
                    TryExtract(section, data, "Commission Amount", @"Commission\s+\d+\s+([A-Z]{3})\s+(\d+)");
                }

                TryExtract(text, data, "Freight Amount", @"Freight\s+\d+\s+USD\s+(\d+)");
                TryExtract(text, data, "Discount Amount", @"Discount\s+\d+\s+USD\s+(\d+)");
                TryExtract(text, data, "Packing Charges", @"Packing Charges\s+\d+\s+USD\s+(\d+)");

                _logger.LogInformation("✅ Charges & deductions extracted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Charges extraction: {ex.Message}");
            }
        }

        // ==================== 8. ITEMS OF EXPORT ====================
        private void ExtractItemsOfExport(string text, Dictionary<string, string> data)
        {
            try
            {
                var itemMatch = Regex.Match(text, @"No\s+RITC.*?\n\s*(\d+)\s+(\d+).*?\n([A-Z\s]+?)\s+\n(\d+)\s+(\w+)", RegexOptions.Singleline);
                if (itemMatch.Success)
                {
                    data["Item Number"] = itemMatch.Groups[1].Value.Trim();
                    data["RITC Code"] = itemMatch.Groups[2].Value.Trim();
                    data["Item Description"] = itemMatch.Groups[3].Value.Trim();
                    data["Item Quantity"] = itemMatch.Groups[4].Value.Trim();
                    data["Item Unit"] = itemMatch.Groups[5].Value.Trim();
                }

                TryExtract(text, data, "Item FOB Value", @"FOB\(INR\)\s+(\d+)");

                _logger.LogInformation("✅ Items of export extracted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Items extraction: {ex.Message}");
            }
        }

        // ==================== 9. DUTY & TAX DETAILS ====================
        private void ExtractDutyTaxDetails(string text, Dictionary<string, string> data)
        {
            try
            {
                TryExtract(text, data, "Total IGST Value", @"TOTAL IGST VALUE:\s+(\d+)");
                TryExtract(text, data, "Total IGST Amount", @"TOTAL IGST AMOUNT:\s+(\d+)");
                TryExtract(text, data, "Total FOB", @"TOTAL FOB:\s+(\d+)");
                TryExtract(text, data, "Total PMV", @"TOTAL PMV:\s+(\d+)");

                _logger.LogInformation("✅ Duty & tax details extracted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Duty extraction: {ex.Message}");
            }
        }

        // ==================== 10. CONTAINER DETAILS ====================
        private void ExtractContainerDetails(string text, Dictionary<string, string> data)
        {
            try
            {
                var containerMatch = Regex.Match(text, @"CONTAINER NUMBER\s+SIZE\s+TYPE.*?\n([A-Z0-9]+)\s+(\d+)\s+([A-Z]+)\s+(\d+)", RegexOptions.Singleline);
                if (containerMatch.Success)
                {
                    data["Container Number"] = containerMatch.Groups[1].Value.Trim();
                    data["Container Size"] = containerMatch.Groups[2].Value.Trim();
                    data["Container Type"] = containerMatch.Groups[3].Value.Trim();
                    data["Seal Number"] = containerMatch.Groups[4].Value.Trim();
                }

                TryExtract(text, data, "Seal Date", @"SEAL DATE\s+(\d{1,2}/\d{1,2}/\d{4})");

                _logger.LogInformation("✅ Container details extracted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Container extraction: {ex.Message}");
            }
        }

        // ==================== 11. PACKING DETAILS ====================
        private void ExtractPackingDetails(string text, Dictionary<string, string> data)
        {
            try
            {
                TryExtract(text, data, "Package From", @"PACKAGE FROM\s+(\d+)");
                TryExtract(text, data, "Package To", @"PACKAGE TO\s+(\d+)");
                TryExtract(text, data, "Package Kind", @"PACKAGE KIND\s+([A-Z]+)");

                _logger.LogInformation("✅ Packing details extracted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Packing extraction: {ex.Message}");
            }
        }

        // ==================== 12. ADDITIONAL INFO ====================
        private void ExtractAdditionalInfo(string text, Dictionary<string, string> data)
        {
            try
            {
                TryExtract(text, data, "Factory Stuffed", @"Factory Stuffed\s+([YN])");
                TryExtract(text, data, "Preferential Trade", @"PREFERENTIAL TRADE.*?:\s*([^\n]+)");

                _logger.LogInformation("✅ Additional info extracted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Additional info extraction: {ex.Message}");
            }
        }

        #region HELPER

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
                _logger.LogWarning(ex, "Error extracting key: {Key}", key);
            }
        }

        #endregion
    }
}