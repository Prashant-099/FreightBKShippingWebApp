//using FreightBKShippingWebApp.Model;

//public class JobBuilderService
//{
//    private readonly JobDataCreationService _dataService;
//    private readonly DataCleanupService _cleanupService;
//    private readonly ILogger<JobBuilderService> _logger;

//    public JobBuilderService(
//        JobDataCreationService dataService,
//        DataCleanupService cleanupService,
//        ILogger<JobBuilderService> logger)
//    {
//        _dataService = dataService;
//        _cleanupService = cleanupService;
//        _logger = logger;
//    }

//    public async Task<Job> BuildJobFromExtractedDataAsync(
//        Dictionary<string, string> extractedData,
//        string jobType,
//        int? yearId)
//    {
//        if (extractedData == null || extractedData.Count == 0)
//        {
//            _logger.LogWarning("No extracted data provided to BuildJobFromExtractedDataAsync");
//            return null;
//        }

//        var j = new Job
//        {
//            JobType = jobType ?? "IMPORT",
//            JobDate = DateTime.Now,
//            JobYearId = yearId?.ToString()
//        };

//        try
//        {
//            // ==================== BASIC JOB INFO ====================
//            if (TryGetValue(extractedData, "Job No", out var jobNo))
//                j.JobNo = _cleanupService.CleanValue(jobNo);

//            if (TryGetValue(extractedData, "Job Date", out var jobDate) &&
//                DateTime.TryParse(_cleanupService.CleanValue(jobDate), out var parsedJobDate))
//                j.JobDate = parsedJobDate;

//            // ==================== BILL OF LADING INFO ====================
//            if (TryGetValue(extractedData, "MBL/MAWB", out var mbl))
//                j.JobBlNo = _cleanupService.CleanValue(mbl);

//            if (TryGetValue(extractedData, "HBL/HAWB", out var hbl))
//                j.JobHblNo = _cleanupService.CleanValue(hbl);

//            if (TryGetValue(extractedData, "BL Date", out var blDate) &&
//                DateTime.TryParse(_cleanupService.CleanValue(blDate), out var parsedBlDate))
//                j.JobBlDate = parsedBlDate;

//            if (TryGetValue(extractedData, "HBL Date", out var hblDate) &&
//                DateTime.TryParse(_cleanupService.CleanValue(hblDate), out var parsedHblDate))
//                j.JobHblDate = parsedHblDate;

//            // ==================== INVOICE INFO ====================
//            if (TryGetValue(extractedData, "Invoice No", out var invNo))
//                j.JobShipperInvNo = _cleanupService.CleanValue(invNo);

//            if (TryGetValue(extractedData, "Invoice Date", out var invDate) &&
//                DateTime.TryParse(_cleanupService.CleanValue(invDate), out var parsedInvDate))
//                j.JobShipperInvDate = parsedInvDate;

//            // ==================== WEIGHT & QUANTITY ====================
//            if (TryGetValue(extractedData, "Gross Weight", out var grossWeight) &&
//                double.TryParse(_cleanupService.CleanValue(grossWeight)?.Replace(",", ""), out var gwParsed))
//                j.JobGrossWt = gwParsed;

//            if (TryGetValue(extractedData, "No of Pkgs", out var pkgs) &&
//                double.TryParse(_cleanupService.CleanValue(pkgs)?.Replace(",", ""), out var pkgsParsed))
//                j.JobQty = pkgsParsed;

//            if (TryGetValue(extractedData, "Weight Unit", out var weightUnit))
//                j.JobGrossUnit = _cleanupService.CleanValue(weightUnit);

//            if (TryGetValue(extractedData, "Qty Unit", out var qtyUnit))
//                j.JobQtyUnit = _cleanupService.CleanValue(qtyUnit);

//            if (TryGetValue(extractedData, "CBM", out var cbm) &&
//                float.TryParse(_cleanupService.CleanValue(cbm)?.Replace(",", ""), out var cbmParsed))
//                j.JobCbm = cbmParsed;

//            if (TryGetValue(extractedData, "Item RITC", out var hsn))
//                j.JobHsnCode = _cleanupService.CleanValue(hsn);

//            // ==================== LOCATION/PORT INFO ====================
//            if (TryGetValue(extractedData, "Port Origin", out var portOrigin))
//            {
//                string countryOrigin = extractedData.ContainsKey("Country Origin") ?
//                    extractedData["Country Origin"] : null;

//                var polId = await _dataService.GetOrCreateLocationWithCountryAsync(
//                    _cleanupService.CleanValue(portOrigin),
//                    _cleanupService.CleanValue(countryOrigin));

//                if (polId.HasValue)
//                    j.JobPolId = polId.Value;
//            }

//            if (TryGetValue(extractedData, "Country Origin", out var country))
//                j.JobCountryOrigin = country;

//            if (TryGetValue(extractedData, "Port Shipment", out var portShipment))
//            {
//                string countryConsignment = extractedData.ContainsKey("Country Consignment") ?
//                    extractedData["Country Consignment"] : null;

//                var podId = await _dataService.GetOrCreateLocationWithCountryAsync(
//                    _cleanupService.CleanValue(portShipment),
//                    _cleanupService.CleanValue(countryConsignment));

//                if (podId.HasValue)
//                    j.JobPodId = podId.Value;
//            }

//            // ==================== SHIPPING PARTIES ====================
//            if (TryGetValue(extractedData, "Importer Name", out var importerName))
//            {
//                var importerId = await _dataService.GetOrCreateAccountIdAsync(
//                    _cleanupService.CleanValue(importerName), extractedData, "Importer");

//                if (importerId.HasValue)
//                {
//                    j.JobPartyId = importerId.Value;

//                    if (TryGetValue(extractedData, "Importer Address", out var importerAddr))
//                        j.JobPartyAddress = _cleanupService.CleanValue(importerAddr);
//                }
//            }

//            if (TryGetValue(extractedData, "Consignee Name", out var consignee))
//            {
//                var consigneeId = await _dataService.GetOrCreateAccountIdAsync(
//                    _cleanupService.CleanValue(consignee));

//                if (consigneeId.HasValue)
//                    j.JobConsigneeId = consigneeId.Value;
//            }

//            if (TryGetValue(extractedData, "Supplier Name", out var supplier))
//            {
//                var supplierId = await _dataService.GetOrCreateAccountIdAsync(
//                    _cleanupService.CleanValue(supplier), extractedData, "Supplier");

//                if (supplierId.HasValue)
//                    j.JobSupplierId = supplierId.Value;
//            }

//            // ==================== CONTAINER INFO ====================
//            if (TryGetValue(extractedData, "Container Numbers", out var containerNumbers))
//                j.JobContainer20Ft = _cleanupService.CleanValue(containerNumbers);

//            if (TryGetValue(extractedData, "Count 20 Ft", out var count20))
//                j.Job20Ft = _cleanupService.CleanValue(count20);

//            if (TryGetValue(extractedData, "Count 40 Ft", out var count40))
//                j.Job40Ft = _cleanupService.CleanValue(count40);

//            // ==================== CUSTOMS & DOCUMENTATION ====================
//            if (TryGetValue(extractedData, "IGM Number", out var igmNo))
//                j.JobIgmNo = _cleanupService.CleanValue(igmNo);

//            if (TryGetValue(extractedData, "IGM Date", out var igmDate) &&
//                DateTime.TryParse(_cleanupService.CleanValue(igmDate), out var parsedIgmDate))
//                j.JobIgmDate = parsedIgmDate;

//            if (TryGetValue(extractedData, "HSN Code", out var hsnCode))
//                j.JobHsnCode = _cleanupService.CleanValue(hsnCode);

//            if (TryGetValue(extractedData, "Marks & Nos", out var marks))
//                j.JobMarks = _cleanupService.CleanValue(marks);

//            // ==================== CARGO DETAILS - ✅ FIXED ====================
//            // ✅ Use Product Description (from ITEM DETAILS section)
//            if (TryGetValue(extractedData, "Cargo Details", out var productDesc))
//            {
//                j.JobGoodsDesc = _cleanupService.CleanValue(productDesc);
//                _logger.LogInformation($"✅ Set JobGoodsDesc: {productDesc}");
//            }

//            // ✅ Use Cargo Details (complete string with product + country + qty)
//            //if (TryGetValue(extractedData, "", out var cargoDetails))
//            //{
//            //    j.JobGoodsDesc1 = _cleanupService.CleanValue(cargoDetails);
//            //    _logger.LogInformation($"✅ Set JobGoodsDesc1 (Cargo Details): {cargoDetails}");
//            //}

//            // ✅ Store Country of Origin in separate field
//            if (TryGetValue(extractedData, "Country of Origin", out var countryOfOrigin))
//            {
//                j.JobGoodsDesc2 = _cleanupService.CleanValue(countryOfOrigin);
//                _logger.LogInformation($"✅ Set JobGoodsDesc2 (Country of Origin): {countryOfOrigin}");
//            }

//            // ✅ Store Quantity information
//            if (TryGetValue(extractedData, "Product Quantity", out var productQty))
//            {
//                j.JobVolume = _cleanupService.CleanValue(productQty);
//                _logger.LogInformation($"✅ Set JobVolume (Quantity): {productQty}");
//            }

//            // ✅ Store RITC Code (HSN equivalent)
//            if (TryGetValue(extractedData, "RITC Code", out var ritcCode))
//            {
//                j.JobMtdNo = _cleanupService.CleanValue(ritcCode); // या अन्य suitable field
//                _logger.LogInformation($"✅ Set JobMtdNo (RITC Code): {ritcCode}");
//            }

//            // ==================== CARGO TYPE (from Cargo field) ====================
//            if (TryGetValue(extractedData, "Cargo Type", out var cargoType))
//            {
//                var cargoId = await _dataService.GetOrCreateCargoIdAsync(
//                    _cleanupService.CleanValue(cargoType));

//                if (cargoId.HasValue)
//                    j.JobCargoId = cargoId.Value;
//            }

//            // ==================== SHIPPING PARTIES ====================
//            if (TryGetValue(extractedData, "Shipping Line", out var line))
//            {
//                var lineId = await _dataService.GetOrCreateLineIdAsync(
//                    _cleanupService.CleanValue(line), extractedData);

//                if (lineId.HasValue)
//                    j.JobLineId = lineId.Value;
//            }

//            if (TryGetValue(extractedData, "CHA Name", out var chaText))
//            {
//                var chaId = await _dataService.GetOrCreateChaIdAsync(
//                    _cleanupService.CleanValue(chaText), extractedData);

//                if (chaId.HasValue)
//                    j.JobChaId = chaId.Value;
//            }

//            // ==================== DUTY DETAILS ====================

//            _logger.LogInformation($"✅ Job built successfully with {extractedData.Count} fields mapped");
//            return j;
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError($"❌ Error building job from extracted data: {ex.Message}");
//            return j;
//        }
//    }

//    private bool TryGetValue(Dictionary<string, string> dict, string key, out string value)
//    {
//        return dict.TryGetValue(key, out value) && !string.IsNullOrWhiteSpace(value);
//    }
//}

using FreightBKShippingWebApp.Model;

public class JobBuilderService
{
    private readonly JobDataCreationService _dataService;
    private readonly DataCleanupService _cleanupService;
    private readonly ILogger<JobBuilderService> _logger;
    private readonly IBranchContext _BranchContext;
    public JobBuilderService(
        JobDataCreationService dataService,
        DataCleanupService cleanupService,
        IBranchContext Branchcontext,
        ILogger<JobBuilderService> logger)
    {
        _dataService = dataService;
        _cleanupService = cleanupService;
        _logger = logger;
        _BranchContext = Branchcontext;
    }

    public async Task<Job> BuildJobFromExtractedDataAsync(
        Dictionary<string, string> extractedData,
        string jobType,
        int? yearId)
    {
        if (extractedData == null || extractedData.Count == 0)
        {
            _logger.LogWarning("No extracted data provided to BuildJobFromExtractedDataAsync");
            return null;
        }

        // ==================== DETECT PDF TYPE (IMPORT/EXPORT) ====================
        var pdfType = extractedData.GetValueOrDefault("PDF Type", "IMPORT");
        if (string.IsNullOrEmpty(jobType) || jobType == "AUTO")
            jobType = pdfType;

        var j = new Job
        {
            JobType = jobType,
            JobDate = DateTime.Now,
            JobYearId = yearId?.ToString(),
            JobBranchId= _BranchContext.BranchId,
        };

        try
        {
            // ==================== BASIC JOB INFO ====================
            if (TryGetValue(extractedData, "Job No", out var jobNo))
                j.JobNo = _cleanupService.CleanValue(jobNo);

            if (TryGetValue(extractedData, "Job Date", out var jobDate) &&
                DateTime.TryParse(_cleanupService.CleanValue(jobDate), out var parsedJobDate))
                j.JobDate = parsedJobDate;

            // ==================== BILL OF LADING INFO ====================
            if (TryGetValue(extractedData, "MBL/MAWB", out var mbl))
                j.JobBlNo = _cleanupService.CleanValue(mbl);

            if (TryGetValue(extractedData, "HBL/HAWB", out var hbl))
                j.JobHblNo = _cleanupService.CleanValue(hbl);

            if (TryGetValue(extractedData, "BL Date", out var blDate) &&
                DateTime.TryParse(_cleanupService.CleanValue(blDate), out var parsedBlDate))
                j.JobBlDate = parsedBlDate;

            if (TryGetValue(extractedData, "HBL Date", out var hblDate) &&
                DateTime.TryParse(_cleanupService.CleanValue(hblDate), out var parsedHblDate))
                j.JobHblDate = parsedHblDate;

            // ==================== INVOICE INFO ====================
            if (TryGetValue(extractedData, "Invoice No", out var invNo))
                j.JobShipperInvNo = _cleanupService.CleanValue(invNo);

            if (TryGetValue(extractedData, "Invoice Date", out var invDate) &&
                DateTime.TryParse(_cleanupService.CleanValue(invDate), out var parsedInvDate))
                j.JobShipperInvDate = parsedInvDate;

            // ==================== WEIGHT & QUANTITY ====================
            if (TryGetValue(extractedData, "Gross Weight", out var grossWeight) &&
                double.TryParse(_cleanupService.CleanValue(grossWeight)?.Replace(",", ""), out var gwParsed))
                j.JobGrossWt = gwParsed;

            if (TryGetValue(extractedData, "Net Weight", out var netWeight) &&
                double.TryParse(_cleanupService.CleanValue(netWeight)?.Replace(",", ""), out var nwParsed))
                j.JobNetWt = nwParsed;

            if (TryGetValue(extractedData, "No of Pkgs", out var pkgs) &&
                double.TryParse(_cleanupService.CleanValue(pkgs)?.Replace(",", ""), out var pkgsParsed))
                j.JobQty = pkgsParsed;

            if (TryGetValue(extractedData, "Weight Unit", out var weightUnit))
                j.JobGrossUnit = _cleanupService.CleanValue(weightUnit);

            if (TryGetValue(extractedData, "Qty Unit", out var qtyUnit))
                j.JobQtyUnit = _cleanupService.CleanValue(qtyUnit);

            if (TryGetValue(extractedData, "CBM", out var cbm) &&
                float.TryParse(_cleanupService.CleanValue(cbm)?.Replace(",", ""), out var cbmParsed))
                j.JobCbm = cbmParsed;

            if (TryGetValue(extractedData, "Item RITC", out var hsn))
                j.JobHsnCode = _cleanupService.CleanValue(hsn);

            // ==================== LOCATION/PORT INFO ====================
            if (pdfType == "IMPORT")
            {
                // IMPORT: Port Origin = POL, Port Shipment = POD
                if (TryGetValue(extractedData, "Port Origin", out var portOrigin))
                {
                    string countryOrigin = extractedData.ContainsKey("Country Origin") ?
                        extractedData["Country Origin"] : null;

                    var polId = await _dataService.GetOrCreateLocationWithCountryAsync(
                        _cleanupService.CleanValue(portOrigin),
                        _cleanupService.CleanValue(countryOrigin));

                    if (polId.HasValue)
                        j.JobPolId = polId.Value;
                }

                if (TryGetValue(extractedData, "Port Shipment", out var portShipment))
                {
                    string countryConsignment = extractedData.ContainsKey("Country Consignment") ?
                        extractedData["Country Consignment"] : null;

                    var podId = await _dataService.GetOrCreateLocationWithCountryAsync(
                        _cleanupService.CleanValue(portShipment),
                        _cleanupService.CleanValue(countryConsignment));

                    if (podId.HasValue)
                        j.JobPodId = podId.Value;
                }
            }
            else if (pdfType == "EXPORT")
            {
                // EXPORT: Port of Filing = POL (Origin), Port of Discharge = POD (Destination)
                if (TryGetValue(extractedData, "Port of Filing", out var portOfFiling))
                {
                    string countryOrigin = extractedData.ContainsKey("Country Origin") ?
                        extractedData["Country Origin"] : "INDIA";

                    var polId = await _dataService.GetOrCreateLocationWithCountryAsync(
                        _cleanupService.CleanValue(portOfFiling),
                        _cleanupService.CleanValue(countryOrigin));

                    if (polId.HasValue)
                        j.JobPolId = polId.Value;
                }

                if (TryGetValue(extractedData, "Port Shipment", out var portDischarge))
                {
                    string countryDischarge = extractedData.ContainsKey("Country Consignment") ?
                        extractedData["Country Consignment"] : null;

                    var podId = await _dataService.GetOrCreateLocationWithCountryAsync(
                        _cleanupService.CleanValue(portDischarge),
                        _cleanupService.CleanValue(countryDischarge));

                    if (podId.HasValue)
                        j.JobPodId = podId.Value;
                }
            }

            if (TryGetValue(extractedData, "Country Origin", out var country))
                j.JobCountryOrigin = country;

            // ==================== SHIPPING PARTIES ====================
            if (pdfType == "IMPORT")
            {
                // ==================== IMPORT: IMPORTER (Main Party) ====================
                if (TryGetValue(extractedData, "Party Name", out var importerName) ||
                    TryGetValue(extractedData, "Importer Name", out importerName))
                {
                    var importerId = await _dataService.GetOrCreateAccountIdAsync(
                        _cleanupService.CleanValue(importerName), extractedData, "Importer");

                    if (importerId.HasValue)
                    {
                        j.JobPartyId = importerId.Value;

                        if (TryGetValue(extractedData, "Party Address", out var importerAddr) ||
                            TryGetValue(extractedData, "Importer Address", out importerAddr))
                            j.JobPartyAddress = _cleanupService.CleanValue(importerAddr);
                    }
                }

                // SUPPLIER (Exporter in Import scenario)
                if (TryGetValue(extractedData, "Supplier Name", out var supplier))
                {
                    var supplierId = await _dataService.GetOrCreateAccountIdAsync(
                        _cleanupService.CleanValue(supplier), extractedData, "Supplier");

                    if (supplierId.HasValue)
                        j.JobSupplierId = supplierId.Value;
                }

                // CONSIGNEE
                if (TryGetValue(extractedData, "Consignee Name", out var consignee))
                {
                    var consigneeId = await _dataService.GetOrCreateAccountIdAsync(
                        _cleanupService.CleanValue(consignee));

                    if (consigneeId.HasValue)
                        j.JobConsigneeId = consigneeId.Value;
                }
            }
            else if (pdfType == "EXPORT")
            {
                // ==================== EXPORT: EXPORTER (Main Party) ====================
                if (TryGetValue(extractedData, "Party Name", out var exporterName))
                {
                    var exporterId = await _dataService.GetOrCreateAccountIdAsync(
                        _cleanupService.CleanValue(exporterName), extractedData, "Exporter");

                    if (exporterId.HasValue)
                    {
                        j.JobPartyId = exporterId.Value;

                        if (TryGetValue(extractedData, "Party Address", out var exporterAddr))
                            j.JobPartyAddress = _cleanupService.CleanValue(exporterAddr);
                    }
                }

                // CONSIGNEE (Buyer in Export scenario)
                if (TryGetValue(extractedData, "Consignee Name", out var consignee))
                {
                    var consigneeId = await _dataService.GetOrCreateAccountIdAsync(
                        _cleanupService.CleanValue(consignee));

                    if (consigneeId.HasValue)
                        j.JobConsigneeId = consigneeId.Value;
                }
            }

            // ==================== CONTAINER INFO ====================
            if (TryGetValue(extractedData, "Container Numbers", out var containerNumbers))
                j.JobContainer20Ft = _cleanupService.CleanValue(containerNumbers);

            if (TryGetValue(extractedData, "Count 20 Ft", out var count20))
                j.Job20Ft = _cleanupService.CleanValue(count20);

            if (TryGetValue(extractedData, "Count 40 Ft", out var count40))
                j.Job40Ft = _cleanupService.CleanValue(count40);

            // ==================== CUSTOMS & DOCUMENTATION ====================
            if (TryGetValue(extractedData, "IGM Number", out var igmNo))
                j.JobIgmNo = _cleanupService.CleanValue(igmNo);

            if (TryGetValue(extractedData, "IGM Date", out var igmDate) &&
                DateTime.TryParse(_cleanupService.CleanValue(igmDate), out var parsedIgmDate))
                j.JobIgmDate = parsedIgmDate;

            if (TryGetValue(extractedData, "HSN Code", out var hsnCode))
                j.JobHsnCode = _cleanupService.CleanValue(hsnCode);

            if (TryGetValue(extractedData, "Marks & Nos", out var marks))
                j.JobMarks = _cleanupService.CleanValue(marks);

            // ==================== CARGO DETAILS ====================
            if (TryGetValue(extractedData, "Cargo Details", out var cargoDetails))
            {
                j.JobGoodsDesc = _cleanupService.CleanValue(cargoDetails);
                _logger.LogInformation($"✅ Set JobGoodsDesc: {cargoDetails}");
            }

            if (TryGetValue(extractedData, "Country of Origin", out var countryOfOrigin))
            {
                j.JobGoodsDesc2 = _cleanupService.CleanValue(countryOfOrigin);
                _logger.LogInformation($"✅ Set JobGoodsDesc2 (Country of Origin): {countryOfOrigin}");
            }

            if (TryGetValue(extractedData, "Product Quantity", out var productQty))
            {
                j.JobVolume = _cleanupService.CleanValue(productQty);
                _logger.LogInformation($"✅ Set JobVolume (Quantity): {productQty}");
            }

            if (TryGetValue(extractedData, "RITC Code", out var ritcCode))
            {
                j.JobMtdNo = _cleanupService.CleanValue(ritcCode);
                _logger.LogInformation($"✅ Set JobMtdNo (RITC Code): {ritcCode}");
            }

            // ==================== CARGO TYPE ====================
            if (TryGetValue(extractedData, "Cargo Type", out var cargoType))
            {
                var cargoId = await _dataService.GetOrCreateCargoIdAsync(
                    _cleanupService.CleanValue(cargoType));

                if (cargoId.HasValue)
                    j.JobCargoId = cargoId.Value;
            }

            // ==================== SHIPPING PARTIES ====================
            if (TryGetValue(extractedData, "Shipping Line", out var line))
            {
                var lineId = await _dataService.GetOrCreateLineIdAsync(
                    _cleanupService.CleanValue(line), extractedData);

                if (lineId.HasValue)
                    j.JobLineId = lineId.Value;
            }

            if (TryGetValue(extractedData, "CHA Name", out var chaText))
            {
                var chaId = await _dataService.GetOrCreateChaIdAsync(
                    _cleanupService.CleanValue(chaText), extractedData);

                if (chaId.HasValue)
                    j.JobChaId = chaId.Value;
            }

            // ==================== TYPE-SPECIFIC MAPPING ====================
            if (pdfType == "IMPORT")
            {
                // IMPORT Duty Details
                if (TryGetValue(extractedData, "Total Customs Duty", out var customsDuty) &&
                    double.TryParse(_cleanupService.CleanValue(customsDuty)?.Replace(",", ""), out var cdParsed))
                    j.JobCust1 = cdParsed.ToString();

                if (TryGetValue(extractedData, "Total IGST Duty", out var igstDuty) &&
                    double.TryParse(_cleanupService.CleanValue(igstDuty)?.Replace(",", ""), out var igstParsed))
                    j.JobCust2 = igstParsed.ToString();

                if (TryGetValue(extractedData, "Grand Total Customs", out var grandTotal) &&
                    double.TryParse(_cleanupService.CleanValue(grandTotal)?.Replace(",", ""), out var gtParsed))
                    j.JobCust3 = gtParsed.ToString();

                if (TryGetValue(extractedData, "Duty Payable", out var dutyPayable) &&
                    double.TryParse(_cleanupService.CleanValue(dutyPayable)?.Replace(",", ""), out var dpParsed))
                    j.JobCust4 = dpParsed.ToString();

                if (TryGetValue(extractedData, "Assessable Value Total", out var assValue) &&
                    double.TryParse(_cleanupService.CleanValue(assValue)?.Replace(",", ""), out var avParsed))
                    j.JobCust5 = avParsed.ToString();

                // Use cust6 for file no
                if (TryGetValue(extractedData, "File No", out var fileNo))
                    j.JobCust6 = _cleanupService.CleanValue(fileNo);

                // Use cust7 for BE Type
                if (TryGetValue(extractedData, "BE Type", out var beType))
                    j.JobCust7 = _cleanupService.CleanValue(beType);

                // Use cust8 for UCR Number
                if (TryGetValue(extractedData, "UCR Number", out var ucr))
                    j.JobCust8 = _cleanupService.CleanValue(ucr);

                // Use cust9 for AD Code
                if (TryGetValue(extractedData, "AD Code", out var adCode))
                    j.JobCust9 = _cleanupService.CleanValue(adCode);

                // BE Number
                if (TryGetValue(extractedData, "BE No", out var beNo))
                    j.JobBeNo = _cleanupService.CleanValue(beNo);

                // BE Date
                if (TryGetValue(extractedData, "BE Date", out var beDate) &&
                    DateTime.TryParse(_cleanupService.CleanValue(beDate), out var parsedBeDate))
                    j.JobBeDate = parsedBeDate;
            }
            else if (pdfType == "EXPORT")
            {
                // EXPORT Duty Details using custom fields
                if (TryGetValue(extractedData, "FOB Value INR", out var fobValue) &&
                    double.TryParse(_cleanupService.CleanValue(fobValue)?.Replace(",", ""), out var fobParsed))
                    j.JobCust1 = fobParsed.ToString();

                if (TryGetValue(extractedData, "Total IGST Amount", out var totalIgst) &&
                    double.TryParse(_cleanupService.CleanValue(totalIgst)?.Replace(",", ""), out var tiParsed))
                    j.JobCust2 = tiParsed.ToString();

                if (TryGetValue(extractedData, "Total PMV", out var pmv) &&
                    double.TryParse(_cleanupService.CleanValue(pmv)?.Replace(",", ""), out var pmvParsed))
                    j.JobCust3 = pmvParsed.ToString();

                if (TryGetValue(extractedData, "Exchange Rate Export", out var exRate))
                    j.JobCust4 = _cleanupService.CleanValue(exRate);

                // Use cust5 for Invoice Currency
                if (TryGetValue(extractedData, "Invoice Currency", out var invCurr))
                    j.JobCust5 = _cleanupService.CleanValue(invCurr);

                // Use cust6 for Invoice Terms
                if (TryGetValue(extractedData, "Invoice Terms", out var invTerms))
                    j.JobCust6 = _cleanupService.CleanValue(invTerms);

                // Use cust7 for Freight
                if (TryGetValue(extractedData, "Freight", out var freight))
                    j.JobCust7 = _cleanupService.CleanValue(freight);

                // Use cust8 for Insurance
                if (TryGetValue(extractedData, "Insurance", out var insurance))
                    j.JobCust8 = _cleanupService.CleanValue(insurance);

                // Use cust9 for Transport Mode
                if (TryGetValue(extractedData, "Transport Mode", out var transMode))
                    j.JobCust9 = _cleanupService.CleanValue(transMode);

                // SB No
                if (TryGetValue(extractedData, "SB No", out var sbNo))
                    j.JobSbNo = _cleanupService.CleanValue(sbNo);

                // SB Date
                if (TryGetValue(extractedData, "SB Date", out var sbDate) &&
                    DateTime.TryParse(_cleanupService.CleanValue(sbDate), out var parsedSbDate))
                    j.JobSbDate = parsedSbDate;


            }

            _logger.LogInformation($"✅ Job built successfully (Type: {pdfType}) with {extractedData.Count} fields mapped");
            return j;
        }
        catch (Exception ex)
        {
            _logger.LogError($"❌ Error building job from extracted data: {ex.Message}");
            return j;
        }
    }

    private bool TryGetValue(Dictionary<string, string> dict, string key, out string value)
    {
        return dict.TryGetValue(key, out value) && !string.IsNullOrWhiteSpace(value);
    }
}