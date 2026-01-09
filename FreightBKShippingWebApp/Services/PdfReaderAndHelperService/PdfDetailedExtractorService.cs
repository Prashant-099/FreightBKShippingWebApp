//using iText.Kernel.Pdf;
//using iText.Kernel.Pdf.Canvas.Parser;
//using iText.Kernel.Pdf.Canvas.Parser.Listener;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace FreightBKShippingWebApp.Services.PdfReaderAndHelperService
//{
//    public class PdfDetailedExtractorService
//    {
//        private readonly ILogger<PdfDetailedExtractorService> _logger;

//        public PdfDetailedExtractorService(ILogger<PdfDetailedExtractorService> logger)
//        {
//            _logger = logger;
//        }

//        /// <summary>
//        /// Extracts all relevant fields from the PDF into a dictionary.
//        /// </summary>
//        public async Task<Dictionary<string, string>> ExtractAllFieldsFromPdfAsync(byte[] pdfBytes)
//        {
//            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

//            try
//            {
//                using var stream = new MemoryStream(pdfBytes);
//                using var reader = new PdfReader(stream);
//                using var pdf = new iText.Kernel.Pdf.PdfDocument(reader);

//                var sb = new StringBuilder();
//                for (int i = 1; i <= pdf.GetNumberOfPages(); i++)
//                {
//                    var pageText = PdfTextExtractor.GetTextFromPage(pdf.GetPage(i), new LocationTextExtractionStrategy());
//                    sb.AppendLine(pageText);
//                }

//                var text = Regex.Replace(sb.ToString(), @"\r\n|\r", "\n");

//                // ==================== BASIC FIELDS ====================
//                TryExtract(text, data, "Job No", @"Job No & Date\s*:\s*(\d+)\s*&");
//                TryExtract(text, data, "Job Date", @"Job No & Date\s*:\s*\d+\s*&\s*(\d{1,2}/\d{1,2}/\d{4})");
//                TryExtract(text, data, "File No", @"File No\s*:\s*(\d+)");
//                TryExtract(text, data, "BE Type", @"BE Type\s*:\s*([^\n]+?)(?=\s+Green Channel)");
//                TryExtract(text, data, "Transport Mode", @"Transport Mode\s*:\s*([A-Z])(?=\s+Section)");

//                // ==================== PORT & SHIPPING ====================
//                TryExtract(text, data, "Port of Filing", @"Port Of Filing\s*:\s*([^,]+)");
//                TryExtract(text, data, "Port Origin", @"Port Origin\s*:\s*([^\n-]+)(?=-)");
//                TryExtract(text, data, "Port Shipment", @"Port Shipment\s*:\s*([^\n-]+)(?=-)");
//                TryExtract(text, data, "Country Origin", @"Country Origin\s*:\s*([^\n-]+)(?=-)");
//                TryExtract(text, data, "Country Consignment", @"Country Consnmnt\s*:\s*([^\n-]+)(?=-)");

//                // ==================== IGM & BL DETAILS ====================
//                TryExtract(text, data, "IGM Number", @"IGM NO\s*:\s*(\d+)\s*/");
//                TryExtract(text, data, "IGM Date", @"IGM NO\s*:\s*\d+\s*/\s*\d+\s*/\s*(\d{1,2}-\d{1,2}-\d{4})");
//                TryExtract(text, data, "MBL/MAWB", @"MBL/MAWB\s*:\s*([A-Z0-9]+)");
//                TryExtract(text, data, "HBL/HAWB", @"HBL/HAWB\s*:\s*([A-Z0-9]+)");
//                TryExtract(text, data, "BL Date", @"MBL/MAWB\s*:\s*[^\n]*\n\s*Date\s*:\s*(\d{1,2}/\d{1,2}/\d{4})");
//                TryExtract(text, data, "HBL Date", @"HBL/HAWB\s*:\s*[A-Z0-9]+\s*\n\s*Date\s*:\s*(\d{1,2}/\d{1,2}/\d{4})");

//                // ==================== PACKAGE & WEIGHT ====================
//                TryExtract(text, data, "No of Pkgs", @"No\.\s*of\s*Pkgs\s*:\s*(\d+)");
//                TryExtract(text, data, "Package Type", @"No\.\s*of\s*Pkgs\s*:\s*\d+\s*([A-Z]+)");
//                TryExtract(text, data, "Gross Weight", @"Gross Weight\s*:\s*([\d,\.]+)");
//                TryExtract(text, data, "Marks & Nos", @"Marks & Nos\s*:\s*([^\n-]+)");
//                TryExtract(text, data, "Qty Unit", @"No\.?\s*of\s*(?:Packages|Pkgs?)\s*:\s*\d+\s+([A-Z]+)");
//                TryExtract(text, data, "Weight Unit", @"Gross\s*Weight\s*:\s*[\d,\.]+\s*([A-Z]{3})");

//                // ==================== INVOICE DETAILS ====================
//                TryExtract(text, data, "Invoice No", @"Inv\.No\s*:\s*([^\n]+)");
//                TryExtract(text, data, "Invoice Date", @"Inv\.Date\s*:\s*(\d{1,2}/\d{1,2}/\d{4})");
//                TryExtract(text, data, "Invoice Value", @"Inv\.Value\s*:\s*([\d,\.]+)");
//                TryExtract(text, data, "Invoice Currency", @"Inv\.Value\s*:\s*[\d,\.]+\s*([A-Z]{3})");
//                TryExtract(text, data, "Invoice Terms", @"Inv\.Terms\s*:\s*([^\n]+)");
//                TryExtract(text, data, "Freight", @"Freight\s*:\s*([\d,\.]+)");
//                TryExtract(text, data, "Freight Currency", @"Freight\s*:\s*[\d,\.]+\s*([A-Z]{3})");
//                TryExtract(text, data, "Insurance", @"Insurance\s*:\s*[\d\.]+%\(([^\)]+)\)");
//                TryExtract(text, data, "Exchange Rate", @"Exchange Rate\s*:\s*1\.00\s*[A-Z]{3}\s*=\s*([\d\.]+)");

//                // ==================== CODES & IDs ====================
//                TryExtract(text, data, "UCR Number", @"UCR Number\s*:\s*([^\s]+)");
//                TryExtract(text, data, "AD Code", @"AD Code\s*:\s*(\d+)");
//                TryExtract(text, data, "GSTIN", @"GSTIN\s*:\s*(\d{2}[A-Z]{5}\d{4}[A-Z]\d[A-Z\d]{3})");
//                TryExtract(text, data, "PAN", @"PAN:\s*([A-Z]{5}\d{4}[A-Z])");
//                TryExtract(text, data, "HSN Code", @"RITC\s*:\s*(\d+)");

//                // ==================== EXTRACT DETAILED SECTIONS ====================
//                TryExtract(text, data, "Cargo Type", @"Cargo\s*:\s*([^\n]+)");
//                TryExtract(text, data, "Consignee Name", @"Consignee\s*:\s*([^\n]+)");


//                ExtractDetailedSections(text, data);

//                _logger.LogInformation("Successfully extracted {Count} fields from PDF", data.Count);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error extracting fields from PDF");
//            }

//            return await Task.FromResult(data);
//        }


//        private void ExtractDetailedSections(string text, Dictionary<string, string> data)
//        {
//            ExtractCHADetails(text, data);
//            ExtractImporterDetails(text, data);
//            ExtractSupplierDetails(text, data);
//            ExtractItemDetails(text, data);
//            ExtractCargoDetails(text, data);  // ✅ CARGO EXTRACTION
//            ExtractContainerDetails(text, data);
//            ExtractDutyDetails(text, data);
//        }

//        // ==================== CARGO DETAILS - FIXED ✅ ====================
//        private void ExtractCargoDetails(string text, Dictionary<string, string> data)
//        {
//            try
//            {
//                _logger.LogInformation("🔍 Starting cargo details extraction");

//                // ✅ STEP 1: Extract Product Description (RITC Line)
//                // Format: "1 25151210 ROUGH MARBLE BLOCKS"
//                var productMatch = Regex.Match(text,
//                    @"^\d+\s+(\d+)\s+([A-Z\s]+?)(?:\n|$)",
//                    RegexOptions.Multiline);

//                string productDescription = null;

//                if (productMatch.Success)
//                {
//                    var ritcCode = productMatch.Groups[1].Value.Trim();
//                    productDescription = productMatch.Groups[2].Value.Trim();

//                    data["Product Description"] = productDescription;
//                    data["RITC Code"] = ritcCode;

//                    _logger.LogInformation($"✅ Product: {productDescription} | RITC: {ritcCode}");
//                }
//                else
//                {
//                    _logger.LogWarning("⚠️ Product description not found");
//                }

//                // ✅ STEP 2: Extract Country of Origin (COO) 
//                // Format: "165.55 200.000000 ITALY 25151210"
//                var cooMatch = Regex.Match(text,
//                    @"Unit Price\s+COO.*?\n[\d\.\s]+\s+([A-Z]+)\s+\d+",
//                    RegexOptions.Multiline | RegexOptions.IgnoreCase);

//                if (cooMatch.Success)
//                {
//                    var countryOfOrigin = cooMatch.Groups[1].Value.Trim();
//                    data["Country of Origin"] = countryOfOrigin;
//                    _logger.LogInformation($"✅ Country of Origin: {countryOfOrigin}");
//                }

//                // ✅ STEP 3: Extract Quantity and Unit
//                // Format: "165.55 200.000000 ITALY"
//                var qtyMatch = Regex.Match(text,
//                    @"(\d+[\.\d]*)\s+(\d+[\.\d]*)\s+[A-Z]+",
//                    RegexOptions.Multiline);

//                if (qtyMatch.Success)
//                {
//                    var quantity = qtyMatch.Groups[1].Value.Trim();
//                    var unitPrice = qtyMatch.Groups[2].Value.Trim();

//                    data["Product Quantity"] = quantity;
//                    data["Unit Price"] = unitPrice;

//                    _logger.LogInformation($"✅ Quantity: {quantity} | Unit Price: {unitPrice}");
//                }

//                // ✅ STEP 4: Build Complete Cargo Details String
//                if (!string.IsNullOrEmpty(productDescription))
//                {
//                    var cargoDetails = new StringBuilder();
//                    cargoDetails.Append(productDescription);

//                    if (data.TryGetValue("Country of Origin", out var coo))
//                        cargoDetails.Append($" FROM {coo}");

//                    if (data.TryGetValue("Product Quantity", out var qty))
//                        cargoDetails.Append($" | QTY: {qty}");

//                    data["Cargo Details"] = cargoDetails.ToString();
//                    _logger.LogInformation($"✅ Final Cargo Details: {data["Cargo Details"]}");
//                }
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"❌ Cargo extraction error: {ex.Message}");
//            }
//        }

//        // ==================== CHA DETAILS ====================
//        private void ExtractCHADetails(string text, Dictionary<string, string> data)
//        {
//            try
//            {
//                var chaMatch = Regex.Match(text, @"CHA Details.*?(?=UCR Number)",
//                    RegexOptions.Singleline | RegexOptions.IgnoreCase);

//                if (chaMatch.Success)
//                {
//                    var chaSection = chaMatch.Value;

//                    var codeMatch = Regex.Match(chaSection, @"^([A-Z0-9]+CH\d+)\s+Br\.Slno",
//                        RegexOptions.Multiline);
//                    if (codeMatch.Success)
//                        data["CHA Code"] = codeMatch.Groups[1].Value.Trim();

//                    var nameMatch = Regex.Match(chaSection, @"M/S\s+([^\n]+?)(?=\s*OFFICE|\s*OM MARBLE|\n)",
//                        RegexOptions.Multiline);
//                    if (nameMatch.Success)
//                        data["CHA Name"] = nameMatch.Groups[1].Value.Trim();

//                    var addressMatch = Regex.Match(chaSection,
//                        @"M/S\s+[^\n]+\n(.*?)(?=OM MARBLE|GUJARAT-\d{6})",
//                        RegexOptions.Singleline);

//                    if (addressMatch.Success)
//                    {
//                        var addressLines = addressMatch.Groups[1].Value
//                            .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
//                            .Select(line => line.Trim())
//                            .Where(line => !string.IsNullOrWhiteSpace(line) &&
//                                           !line.Contains("OM MARBLE") &&
//                                           !line.Contains("Br.Slno"))
//                            .ToList();

//                        if (addressLines.Any())
//                            data["CHA Address"] = string.Join(", ", addressLines);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"CHA extraction error: {ex.Message}");
//            }
//        }

//        // ==================== IMPORTER DETAILS ====================
//        private void ExtractImporterDetails(string text, Dictionary<string, string> data)
//        {
//            try
//            {
//                var importerCodeMatch = Regex.Match(text, @"Importer Details\s*:\s*([A-Z0-9]+)\s*\n");
//                if (importerCodeMatch.Success)
//                    data["Importer Code"] = importerCodeMatch.Groups[1].Value.Trim();

//                var panMatch = Regex.Match(text, @"Br\.Slno\s*:\s*0\s*PAN\s*:\s*([A-Z0-9]+)");
//                if (panMatch.Success)
//                    data["Importer PAN"] = panMatch.Groups[1].Value.Trim();

//                var importerNameMatch = Regex.Match(text,
//                    @"PAN\s*:\s*[A-Z0-9]+\s*\n(?:.*?\s)?([A-Z]+\s+[A-Z]+\s+COMPANY)",
//                    RegexOptions.Singleline);

//                if (importerNameMatch.Success)
//                    data["Importer Name"] = importerNameMatch.Groups[1].Value.Trim();

//                var addressMatch = Regex.Match(text,
//                    @"COMPANY\s*\n(.*?)(?=GUJARAT-\d{6})",
//                    RegexOptions.Singleline);

//                if (addressMatch.Success)
//                {
//                    var addressLines = addressMatch.Groups[1].Value
//                        .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
//                        .Select(line => line.Trim())
//                        .Where(line => !string.IsNullOrWhiteSpace(line))
//                        .ToList();

//                    if (addressLines.Any())
//                        data["Importer Address"] = string.Join(", ", addressLines);
//                }
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Importer extraction error: {ex.Message}");
//            }
//        }

//        // ==================== SUPPLIER DETAILS ====================
//        private void ExtractSupplierDetails(string text, Dictionary<string, string> data)
//        {
//            try
//            {
//                var supplierSection = Regex.Match(text,
//                    @"SUPPLIER DETAILS.*?\n-+\s*\n(.*?)(?=ITEM DETAILS|-{5,}.*?ITEM DETAILS)",
//                    RegexOptions.Singleline | RegexOptions.IgnoreCase);

//                if (supplierSection.Success)
//                {
//                    var section = supplierSection.Groups[1].Value;
//                    var lines = section.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
//                        .Select(l => l.Trim())
//                        .Where(l => !string.IsNullOrWhiteSpace(l))
//                        .ToList();

//                    var supplierLines = new List<string>();

//                    foreach (var line in lines)
//                    {
//                        var parts = Regex.Split(line, @"\s{3,}");
//                        if (parts.Length >= 2)
//                        {
//                            var rightColumn = parts[parts.Length - 1].Trim();
//                            if (!string.IsNullOrWhiteSpace(rightColumn) &&
//                                !rightColumn.Contains("Inv.") &&
//                                !rightColumn.Contains("Under SVB") &&
//                                !rightColumn.Contains("Freight") &&
//                                !rightColumn.Contains("Insurance") &&
//                                rightColumn.Length > 2)
//                            {
//                                supplierLines.Add(rightColumn);
//                            }
//                        }
//                    }

//                    if (supplierLines.Count >= 1)
//                    {
//                        data["Supplier Name"] = supplierLines[0];

//                        if (supplierLines.Count >= 2)
//                        {
//                            var addressParts = supplierLines.Skip(1)
//                                .Select(a => Regex.Replace(a, @"^E\s+", "").Trim())
//                                .Where(a => !string.IsNullOrWhiteSpace(a));

//                            data["Supplier Address"] = string.Join(", ", addressParts);
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Supplier extraction error: {ex.Message}");
//            }
//        }

//        // ==================== ITEM DETAILS ====================
//        private void ExtractItemDetails(string text, Dictionary<string, string> data)
//        {
//            try
//            {
//                var itemMatch = Regex.Match(text,
//                    @"ITEM DETAILS.*?Slno\s+RITC\s+Description.*?\n\d+\s+(\d+)\s+([^\n]+?)\n([\d\.]+)\s+([\d\.]+)",
//                    RegexOptions.Singleline);

//                if (itemMatch.Success)
//                {
//                    data["Item RITC"] = itemMatch.Groups[1].Value.Trim();
//                    data["Item Description"] = itemMatch.Groups[2].Value.Trim();
//                    data["Item Quantity"] = itemMatch.Groups[3].Value.Trim();
//                    data["Item Unit Price"] = itemMatch.Groups[4].Value.Trim();
//                }

//                var cooMatch = Regex.Match(text, @"Unit Price\s+COO.*?\n[\d\.]+\s+[\d\.]+\s+([A-Z]+)\s+", RegexOptions.Multiline);
//                if (cooMatch.Success)
//                    data["Item COO"] = cooMatch.Groups[1].Value.Trim();

//                var assValueMatch = Regex.Match(text, @"Unit\s+Ass Value.*?\n[A-Z]+\s+([\d,\.]+)", RegexOptions.Multiline);
//                if (assValueMatch.Success)
//                    data["Assessable Value"] = assValueMatch.Groups[1].Value.Trim();
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Item extraction error: {ex.Message}");
//            }
//        }

//        // ==================== CONTAINER DETAILS ====================
//        private void ExtractContainerDetails(string text, Dictionary<string, string> data)
//        {
//            try
//            {
//                var containerSection = Regex.Match(text,
//                    @"CONTAINER DETAILS.*?(?=GSTIN Details)",
//                    RegexOptions.Singleline | RegexOptions.IgnoreCase);

//                if (containerSection.Success)
//                {
//                    var section = containerSection.Value;
//                    var containerMatches = Regex.Matches(section,
//                        @"\d+\s*/\s*\d+\s+([A-Z]{4}\d{7})\s+[A-Z]\s+[A-Z]\s+(\d+)\s+Standard\s+Dry",
//                        RegexOptions.Multiline);

//                    var containers = new List<string>();
//                    var sizes = new List<int>();

//                    foreach (Match match in containerMatches)
//                    {
//                        containers.Add(match.Groups[1].Value);
//                        sizes.Add(int.Parse(match.Groups[2].Value));
//                    }

//                    if (containers.Any())
//                    {
//                        data["Container Numbers"] = string.Join(", ", containers);
//                        data["Container Count"] = containers.Count.ToString();

//                        var size20 = sizes.Count(s => s == 20);
//                        var size40 = sizes.Count(s => s == 40);
//                        var size45 = sizes.Count(s => s == 45);

//                        if (size20 > 0) data["Count 20 Ft"] = size20.ToString();
//                        if (size40 > 0) data["Count 40 Ft"] = size40.ToString();
//                        if (size45 > 0) data["Count 45 Ft"] = size45.ToString();
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Container extraction error: {ex.Message}");
//            }
//        }

//        // ==================== DUTY DETAILS ====================
//        private void ExtractDutyDetails(string text, Dictionary<string, string> data)
//        {
//            try
//            {
//                TryExtract(text, data, "Total Customs Duty", @"Total Customs Duty\s*:\s*([\d,\.]+)");
//                TryExtract(text, data, "Total IGST Duty", @"Total IGST Duty\s*:\s*([\d,\.]+)");
//                TryExtract(text, data, "Grand Total Customs", @"Grand Total Custom Duty\s*:\s*([\d,\.]+)");
//                TryExtract(text, data, "Grand Total IGST", @"Grand Total IGST Duty\s*:\s*([\d,\.]+)");

//                var netAmtMatch = Regex.Match(text, @"Net Amt\.Rs\.\s*([\d,\.]+)\s+([\d,\.]+)");
//                if (netAmtMatch.Success)
//                {
//                    data["Assessable Value Total"] = netAmtMatch.Groups[1].Value.Trim();
//                    data["Duty Payable"] = netAmtMatch.Groups[2].Value.Trim();
//                }

//                TryExtract(text, data, "Duty In Words", @"DUTY PAYABLE\s*:\s*Rupees\s+([^\n-]+)");
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError($"Duty extraction error: {ex.Message}");
//            }
//        }

//        #region HELPER

//        private void TryExtract(string text, Dictionary<string, string> data, string key, string pattern, int groupIndex = 1)
//        {
//            try
//            {
//                var match = Regex.Match(text, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
//                if (match.Success && match.Groups.Count > groupIndex)
//                {
//                    var value = match.Groups[groupIndex].Value.Trim();
//                    if (!string.IsNullOrWhiteSpace(value))
//                        data[key] = value;
//                }
//            }
//            catch (Exception ex)
//            {
//                _logger.LogWarning(ex, "Error extracting key: {Key}", key);
//            }
//        }

//        #endregion
//    }
//}


using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System.Text;
using System.Text.RegularExpressions;

namespace FreightBKShippingWebApp.Services.PdfReaderAndHelperService
{
    public class PdfDetailedExtractorService
    {
        private readonly ILogger<PdfDetailedExtractorService> _logger;

        public PdfDetailedExtractorService(ILogger<PdfDetailedExtractorService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Extracts all relevant fields from the PDF into a dictionary.
        /// Supports both Import (Bill of Entry) and Export (Shipping Bill) PDFs.
        /// </summary>
        public async Task<Dictionary<string, string>> ExtractAllFieldsFromPdfAsync(byte[] pdfBytes)
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

                // ==================== DETECT PDF TYPE ====================
                var pdfType = DetectPdfType(text);
                data["PDF Type"] = pdfType;
                _logger.LogInformation($"Detected PDF Type: {pdfType}");

                // ==================== BASIC FIELDS ====================
                TryExtract(text, data, "Job No", @"Job No & Date\s*:\s*(\d+)\s*&|Icegate Job No\s*:(\d+)");
                TryExtract(text, data, "Job Date", @"Job No & Date\s*:\s*\d+\s*&\s*(\d{1,2}/\d{1,2}/\d{4})");
                TryExtract(text, data, "File No", @"File No\s*:\s*(\d+)|File Reference No:(\d+)");
                TryExtract(text, data, "BE Type", @"BE Type\s*:\s*([^\n]+?)(?=\s+Green Channel)");
                TryExtract(text, data, "Transport Mode", @"Transport Mode\s*:\s*([A-Z])(?=\s+Section)");

                // ==================== PORT & SHIPPING ====================
                TryExtract(text, data, "Port of Filing", @"Port Of Filing\s*:\s*([^,\n]+)|Port of Loading:([^\n,]+)");
                TryExtract(text, data, "Port Origin", @"Port Origin\s*:\s*([^\n-]+)(?=-)|Port of Loading:([^\n,]+)");
                TryExtract(text, data, "Port Shipment", @"Port Shipment\s*:\s*([^\n-]+)(?=-)|Port of Discharge\s*:([^\n]+)");
                TryExtract(text, data, "Country Origin", @"Country Origin\s*:\s*([^\n-]+)(?=-)|Country of Dischrge:([^\n]+)");
                TryExtract(text, data, "Country Consignment", @"Country Consnmnt\s*:\s*([^\n-]+)(?=-)|Country Final Dest\.\s*:([^\n]+)");

                // ==================== IGM & BL DETAILS ====================
                TryExtract(text, data, "IGM Number", @"IGM NO\s*:\s*(\d+)\s*/|IGM NO\s*:\s*(\d+)");
                TryExtract(text, data, "IGM Date", @"IGM NO\s*:\s*\d+\s*/\s*\d+\s*/\s*(\d{1,2}-\d{1,2}-\d{4})");
                TryExtract(text, data, "MBL/MAWB", @"MBL/MAWB\s*:\s*([A-Z0-9]+)");
                TryExtract(text, data, "HBL/HAWB", @"HBL/HAWB\s*:\s*([A-Z0-9]+)");
                TryExtract(text, data, "BL Date", @"MBL/MAWB\s*:\s*[^\n]*\n\s*Date\s*:\s*(\d{1,2}/\d{1,2}/\d{4})");
                TryExtract(text, data, "HBL Date", @"HBL/HAWB\s*:\s*[A-Z0-9]+\s*\n\s*Date\s*:\s*(\d{1,2}/\d{1,2}/\d{4})");

                // ==================== PACKAGE & WEIGHT ====================
                TryExtract(text, data, "No of Pkgs", @"No\.\s*of\s*Pkgs\s*:\s*(\d+)|Total Packages\s*:(\d+)");
                TryExtract(text, data, "Package Type", @"No\.\s*of\s*Pkgs\s*:\s*\d+\s*([A-Z]+)|PACKAGE KIND.*?\n.*?(\w+)");
                TryExtract(text, data, "Gross Weight", @"Gross Weight\s*:\s*([\d,\.]+)");
                TryExtract(text, data, "Net Weight", @"Net Weight\s*:\s*([\d,\.]+)");
                TryExtract(text, data, "Marks & Nos", @"Marks & Nos\s*:\s*([^\n-]+)");
                TryExtract(text, data, "Qty Unit", @"No\.?\s*of\s*(?:Packages|Pkgs?)\s*:\s*\d+\s+([A-Z]+)");
                TryExtract(text, data, "Weight Unit", @"Gross\s*Weight\s*:\s*[\d,\.]+\s*([A-Z]{3})");

                // ==================== INVOICE DETAILS ====================
                TryExtract(text, data, "Invoice No", @"Inv\.No\s*:\s*([^\n]+)|Invoice Number\s*:([^\n]+)");
                TryExtract(text, data, "Invoice Date", @"Inv\.Date\s*:\s*(\d{1,2}/\d{1,2}/\d{4})|Date\s*:(\d{1,2}/\d{1,2}/\d{4})");
                TryExtract(text, data, "Invoice Value", @"Inv\.Value\s*:\s*([\d,\.]+)|Invoice Value\(FC\)\s*:([^\n]+)");
                TryExtract(text, data, "Invoice Currency", @"Inv\.Value\s*:\s*[\d,\.]+\s*([A-Z]{3})|Currency Code\s*:([A-Z]{3})");
                TryExtract(text, data, "Invoice Terms", @"Inv\.Terms\s*:\s*([^\n]+)");
                TryExtract(text, data, "Freight", @"Freight\s*:\s*([\d,\.]+)");
                TryExtract(text, data, "Freight Currency", @"Freight\s*:\s*[\d,\.]+\s*([A-Z]{3})");
                TryExtract(text, data, "Insurance", @"Insurance\s*:\s*[\d\.]+%\(([^\)]+)\)|Insurance\s+([\d\.]+)%");
                TryExtract(text, data, "Exchange Rate", @"Exchange Rate\s*:\s*1\.00\s*[A-Z]{3}\s*=\s*([\d\.]+)|Exchange Rate\s*:\s*([^\n]+)");

                // ==================== CODES & IDs ====================
                TryExtract(text, data, "UCR Number", @"UCR Number\s*:\s*([^\s]+)");
                TryExtract(text, data, "AD Code", @"AD Code\s*:\s*(\d+)");
                TryExtract(text, data, "GSTIN", @"GSTIN\s*:\s*(\d{2}[A-Z]{5}\d{4}[A-Z]\d[A-Z\d]{3})");
                TryExtract(text, data, "PAN", @"PAN:\s*([A-Z]{5}\d{4}[A-Z])|PAN:([A-Z]{5}\d{4}[A-Z])");
                TryExtract(text, data, "HSN Code", @"RITC\s*:\s*(\d+)");

                // ==================== EXPORTER/IMPORTER DETAILS ====================
                ExtractPartyDetails(text, data, pdfType);

                // ==================== EXTRACT DETAILED SECTIONS ====================
                TryExtract(text, data, "Cargo Type", @"Cargo\s*:\s*([^\n]+)|Nature Of Cargo\.\s*:([A-Z\s]+)");
                TryExtract(text, data, "Consignee Name", @"Consignee\s*:\s*([^\n]+)|CONSIGNEE DETAILS:.*?\n([^\n]+)");

                ExtractDetailedSections(text, data, pdfType);

                _logger.LogInformation("Successfully extracted {Count} fields from PDF", data.Count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error extracting fields from PDF");
            }

            return await Task.FromResult(data);
        }

        // ==================== DETECT PDF TYPE ====================
        private string DetectPdfType(string text)
        {
            if (text.Contains("BILL OF ENTRY", StringComparison.OrdinalIgnoreCase) ||
                text.Contains("CHECK LIST - BILL OF ENTRY", StringComparison.OrdinalIgnoreCase))
            {
                return "IMPORT";
            }
            else if (text.Contains("SHIPPING BILL", StringComparison.OrdinalIgnoreCase) ||
                     text.Contains("Shipping Bill Check List", StringComparison.OrdinalIgnoreCase))
            {
                return "EXPORT";
            }
            return "UNKNOWN";
        }

        // ==================== EXTRACT PARTY DETAILS (IMPORT/EXPORT) ====================
        private void ExtractPartyDetails(string text, Dictionary<string, string> data, string pdfType)
        {
            try
            {
                if (pdfType == "IMPORT")
                {
                    // ==================== IMPORTER DETAILS ====================
                    var importerCodeMatch = Regex.Match(text, @"Importer Details\s*:\s*([A-Z0-9]+)\s*\n");
                    if (importerCodeMatch.Success)
                        data["Party Code"] = importerCodeMatch.Groups[1].Value.Trim();

                    var importerNameMatch = Regex.Match(text,
                        @"PAN\s*:([A-Z0-9]+).*?\n(?:.*?\s)?([A-Z]+\s+[A-Z\s]+?)(?=\n|OFFICE|Sr No)",
                        RegexOptions.Singleline);

                    if (importerNameMatch.Success)
                        data["Party Name"] = importerNameMatch.Groups[2].Value.Trim();
                    else
                        TryExtract(text, data, "Party Name", @"Importer Details\s*:\s*[^\n]+\n.*?([A-Z]+\s+[A-Z]+\s+(?:COMPANY|TRADING))");

                    TryExtract(text, data, "Party PAN", @"PAN\s*:([A-Z0-9]+)");
                }
                else if (pdfType == "EXPORT")
                {
                    // ==================== EXPORTER DETAILS ====================
                    var exporterMatch = Regex.Match(text, @"EXPORTER DETAILS\s*:\s*.*?\n(\d+)\s+\n(.*?)(?=Branch Sr|Type of|$)", RegexOptions.Singleline);
                    if (exporterMatch.Success)
                    {
                        data["Party Code"] = exporterMatch.Groups[1].Value.Trim();
                        var nameLines = exporterMatch.Groups[2].Value.Trim().Split('\n');
                        if (nameLines.Length > 0)
                            data["Party Name"] = nameLines[0].Trim();
                    }

                    TryExtract(text, data, "Party PAN", @"GSN - GSTIN.*?\n.*?(\d{2}[A-Z]{5}\d{4}[A-Z]\d[A-Z\d]{3})");

                    // ==================== CONSIGNEE DETAILS (FOR EXPORT) ====================
                    TryExtract(text, data, "Consignee Code", @"CONSIGNEE DETAILS:.*?\n(\d+)");
                    TryExtract(text, data, "Consignee Name", @"CONSIGNEE DETAILS:.*?\n\d+\s+\n([^\n]+)");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Party extraction error: {ex.Message}");
            }
        }

        private void ExtractDetailedSections(string text, Dictionary<string, string> data, string pdfType)
        {
            ExtractCHADetails(text, data);

            if (pdfType == "IMPORT")
            {
                ExtractImporterDetails(text, data);
                ExtractCargoDetails(text, data);
            }
            else if (pdfType == "EXPORT")
            {
                ExtractExporterAddress(text, data);
                ExtractExportCargoDetails(text, data);
            }

            ExtractSupplierDetails(text, data, pdfType);
            ExtractItemDetails(text, data);
            ExtractContainerDetails(text, data);
            ExtractDutyDetails(text, data, pdfType);
        }

        // ==================== EXPORT-SPECIFIC CARGO DETAILS ====================
        private void ExtractExportCargoDetails(string text, Dictionary<string, string> data)
        {
            try
            {
                _logger.LogInformation("🔍 Starting export cargo details extraction");

                // Extract from ITEMS OF EXPORT section
                var itemMatch = Regex.Match(text,
                    @"No\s+RITC\s+CD\s+Description.*?\n.*?(\d+)\s+(\d+)\s+.*?\n([A-Z\s]+?)\s+\n([\d\.]+)\s+(\w+)",
                    RegexOptions.Singleline);

                if (itemMatch.Success)
                {
                    var ritcCode = itemMatch.Groups[2].Value.Trim();
                    var description = itemMatch.Groups[3].Value.Trim();
                    var quantity = itemMatch.Groups[4].Value.Trim();
                    var unit = itemMatch.Groups[5].Value.Trim();

                    data["Product Description"] = description;
                    data["RITC Code"] = ritcCode;
                    data["Product Quantity"] = quantity;
                    data["Qty Unit"] = unit;

                    _logger.LogInformation($"✅ Export Product: {description} | RITC: {ritcCode} | QTY: {quantity} {unit}");
                }

                var cargoTypeMatch = Regex.Match(text, @"Nature Of Cargo\.\s*:([A-Z\s]+)");
                if (cargoTypeMatch.Success)
                    data["Cargo Type"] = cargoTypeMatch.Groups[1].Value.Trim();

                if (!string.IsNullOrEmpty(data.GetValueOrDefault("Product Description")))
                {
                    var cargoDetails = new StringBuilder(data["Product Description"]);
                    if (data.TryGetValue("Product Quantity", out var qty))
                        cargoDetails.Append($" | QTY: {qty}");

                    data["Cargo Details"] = cargoDetails.ToString();
                    _logger.LogInformation($"✅ Final Export Cargo Details: {data["Cargo Details"]}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Export cargo extraction error: {ex.Message}");
            }
        }

        // ==================== EXPORT ADDRESS EXTRACTION ====================
        private void ExtractExporterAddress(string text, Dictionary<string, string> data)
        {
            try
            {
                var addressMatch = Regex.Match(text,
                    @"EXPORTER DETAILS\s*:.*?\n\d+\s+\n(.*?)(?=Branch Sr|Type of)",
                    RegexOptions.Singleline);

                if (addressMatch.Success)
                {
                    var addressLines = addressMatch.Groups[1].Value
                        .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(line => line.Trim())
                        .Where(line => !string.IsNullOrWhiteSpace(line))
                        .ToList();

                    if (addressLines.Any())
                        data["Party Address"] = string.Join(", ", addressLines);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exporter address extraction error: {ex.Message}");
            }
        }

        // ==================== CARGO DETAILS - IMPORT (ORIGINAL) ====================
        private void ExtractCargoDetails(string text, Dictionary<string, string> data)
        {
            try
            {
                _logger.LogInformation("🔍 Starting cargo details extraction");

                var productMatch = Regex.Match(text,
                    @"^\d+\s+(\d+)\s+([A-Z\s]+?)(?:\n|$)",
                    RegexOptions.Multiline);

                string productDescription = null;

                if (productMatch.Success)
                {
                    var ritcCode = productMatch.Groups[1].Value.Trim();
                    productDescription = productMatch.Groups[2].Value.Trim();

                    data["Product Description"] = productDescription;
                    data["RITC Code"] = ritcCode;

                    _logger.LogInformation($"✅ Product: {productDescription} | RITC: {ritcCode}");
                }
                else
                {
                    _logger.LogWarning("⚠️ Product description not found");
                }

                var cooMatch = Regex.Match(text,
                    @"Unit Price\s+COO.*?\n[\d\.\s]+\s+([A-Z]+)\s+\d+",
                    RegexOptions.Multiline | RegexOptions.IgnoreCase);

                if (cooMatch.Success)
                {
                    var countryOfOrigin = cooMatch.Groups[1].Value.Trim();
                    data["Country of Origin"] = countryOfOrigin;
                    _logger.LogInformation($"✅ Country of Origin: {countryOfOrigin}");
                }

                var qtyMatch = Regex.Match(text,
                    @"(\d+[\.\d]*)\s+(\d+[\.\d]*)\s+[A-Z]+",
                    RegexOptions.Multiline);

                if (qtyMatch.Success)
                {
                    var quantity = qtyMatch.Groups[1].Value.Trim();
                    var unitPrice = qtyMatch.Groups[2].Value.Trim();

                    data["Product Quantity"] = quantity;
                    data["Unit Price"] = unitPrice;

                    _logger.LogInformation($"✅ Quantity: {quantity} | Unit Price: {unitPrice}");
                }

                if (!string.IsNullOrEmpty(productDescription))
                {
                    var cargoDetails = new StringBuilder();
                    cargoDetails.Append(productDescription);

                    if (data.TryGetValue("Country of Origin", out var coo))
                        cargoDetails.Append($" FROM {coo}");

                    if (data.TryGetValue("Product Quantity", out var qty))
                        cargoDetails.Append($" | QTY: {qty}");

                    data["Cargo Details"] = cargoDetails.ToString();
                    _logger.LogInformation($"✅ Final Cargo Details: {data["Cargo Details"]}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Cargo extraction error: {ex.Message}");
            }
        }

        // ==================== CHA DETAILS ====================
     private void ExtractCHADetails(string text, Dictionary<string, string> data)
        {
            try
            {
                var chaMatch = Regex.Match(text, @"CHA Details.*?(?=UCR Number)",
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);

                if (chaMatch.Success)
                {
                    var chaSection = chaMatch.Value;

                    var codeMatch = Regex.Match(chaSection, @"^([A-Z0-9]+CH\d+)\s+Br\.Slno",
                        RegexOptions.Multiline);
                    if (codeMatch.Success)
                        data["CHA Code"] = codeMatch.Groups[1].Value.Trim();

                    var nameMatch = Regex.Match(chaSection, @"M/S\s+([^\n]+?)(?=\s*OFFICE|\s*OM MARBLE|\n)",
                        RegexOptions.Multiline);
                    if (nameMatch.Success)
                        data["CHA Name"] = nameMatch.Groups[1].Value.Trim();

                    var addressMatch = Regex.Match(chaSection,
                        @"M/S\s+[^\n]+\n(.*?)(?=OM MARBLE|GUJARAT-\d{6})",
                        RegexOptions.Singleline);

                    if (addressMatch.Success)
                    {
                        var addressLines = addressMatch.Groups[1].Value
                            .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(line => line.Trim())
                            .Where(line => !string.IsNullOrWhiteSpace(line) &&
                                           !line.Contains("OM MARBLE") &&
                                           !line.Contains("Br.Slno"))
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

        // ==================== IMPORTER DETAILS ====================
        private void ExtractImporterDetails(string text, Dictionary<string, string> data)
        {
            try
            {
                // 1. Importer Code (Yeh pehle jaisa hi hai)
                var importerCodeMatch = Regex.Match(text, @"Importer Details\s*:\s*([A-Z0-9]+)\s*\n");
                if (importerCodeMatch.Success)
                    data["Importer Code"] = importerCodeMatch.Groups[1].Value.Trim();

                // 2. Importer PAN (Yeh bhi pehle jaisa hai)
                var panMatch = Regex.Match(text, @"Br\.Slno\s*:\s*0\s*PAN\s*:\s*([A-Z0-9]+)");

                if (panMatch.Success)
                {
                    data["Importer PAN"] = panMatch.Groups[1].Value.Trim();
                    string pan = data["Importer PAN"];

                    // 3. NAYA LOGIC: Importer Name aur Address ko PAN/GSTIN se dhoondo
                    // Hum PAN ka istemal karke GSTIN line ko dhoondenge aur usse upar ka data nikalenge.

                    var blockRegex = new Regex(
                        // Group 1: Importer Name (Puri line jisme "COMPANY" ho)
                        @"^([^\r\n]*?COMPANY[^\r\n]*)\s*\r?\n" +
                        // Group 2: Address ki beech ki lines
                        @"(.*?)" +
                        // Group 3: Address ki aakhri line (GUJARAT-PIN)
                        @"(GUJARAT-\d{6})\s*\r?\n" +
                        // Anchor: Woh line jismein PAN wala GSTIN ho
                        // Regex.Escape(pan) yeh PAN number ko safe banata hai
                        @".*GSTIN\s*:\s*\d{2}" + Regex.Escape(pan) + @"\w{3}",

                        // Options: MultiLine (^) line ki shuruwaat ke liye, SingleLine (.) newline ko match karne ke liye
                        RegexOptions.Multiline | RegexOptions.Singleline
                    );

                    var blockMatch = blockRegex.Match(text);

                    if (blockMatch.Success)
                    {
                        // Group 1: Importer Name
                        data["Importer Name"] = blockMatch.Groups[1].Value.Trim(); // Jaise: "OM MARBLE COMPANY"

                        // Group 2: Beech ki address lines
                        var addressLines = blockMatch.Groups[2].Value
                            .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(line => line.Trim())
                            .Where(line => !string.IsNullOrWhiteSpace(line))
                            .ToList();

                        // Group 3: GUJARAT-PIN wali line ko bhi add karo
                        addressLines.Add(blockMatch.Groups[3].Value.Trim()); // Jaise: "GUJARAT-360110"

                        // Sabhi address lines ko jod do
                        data["Importer Address"] = string.Join(", ", addressLines);
                    }
                    else
                    {
                        // Agar naya regex fail hota hai (jo nahi hona chahiye), toh log karo
                        // _logger.LogWarning($"Importer Name/Address block nahi mila PAN: {pan} ke liye.");
                    }
                }
                else
                {
                    // _logger.LogWarning("Importer PAN nahi mila.");
                }

                
            }
            catch (Exception ex)
            {
                // _logger.LogError($"Importer extraction error: {ex.Message}");
            }
        }

        // ==================== SUPPLIER DETAILS ====================
        private void ExtractSupplierDetails(string text, Dictionary<string, string> data, string pdfType)
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

        // ==================== ITEM DETAILS ====================
        private void ExtractItemDetails(string text, Dictionary<string, string> data)
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

        // ==================== CONTAINER DETAILS ====================
        private void ExtractContainerDetails(string text, Dictionary<string, string> data)
        {
            try
            {
                var containerSection = Regex.Match(text,
                    @"CONTAINER DETAILS.*?(?=GSTIN Details|Vessel Details)",
                    RegexOptions.Singleline | RegexOptions.IgnoreCase);

                if (containerSection.Success)
                {
                    var section = containerSection.Value;
                    var containerMatches = Regex.Matches(section,
                        @"(\d+\s*/\s*\d+\s+)?([A-Z]{4}\d{7})\s+[A-Z]?\s+[A-Z]?\s+(\d+)\s+(?:Standard\s+)?Dry",
                        RegexOptions.Multiline);

                    var containers = new List<string>();
                    var sizes = new List<int>();

                    foreach (Match match in containerMatches)
                    {
                        containers.Add(match.Groups[2].Value);
                        if (int.TryParse(match.Groups[3].Value, out int size))
                            sizes.Add(size);
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

        // ==================== DUTY DETAILS ====================
        private void ExtractDutyDetails(string text, Dictionary<string, string> data, string pdfType)
        {
            try
            {
                if (pdfType == "IMPORT")
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
                else if (pdfType == "EXPORT")
                {
                    // Export duty details
                    TryExtract(text, data, "Total IGST Value", @"TOTAL IGST VALUE:\s*([\d,\.]+)");
                    TryExtract(text, data, "Total IGST Amount", @"TOTAL IGST AMOUNT:\s*([\d,\.]+)");
                    TryExtract(text, data, "Total FOB", @"TOTAL FOB:\s*([\d,\.]+)");
                    TryExtract(text, data, "Total PMV", @"TOTAL PMV:\s*([\d,\.]+)");
                    TryExtract(text, data, "FOB Value INR", @"FOB Value\(INR\)\s*:([^\n]+)");
                    TryExtract(text, data, "Exchange Rate Export", @"Exchange Rate\s*:([^\n]+)");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Duty extraction error: {ex.Message}");
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

