using FreightBKShippingWebApp.Model;
using System.Text;
namespace FreightBKShippingWebApp.Services.PdfReaderAndHelperService
{
    public class ExportJobBuilderService
    {
        private readonly JobDataCreationService _dataService;
        private readonly DataCleanupService _cleanupService;
        private readonly ILogger<ExportJobBuilderService> _logger;

        public ExportJobBuilderService(
            JobDataCreationService dataService,
            DataCleanupService cleanupService,
            ILogger<ExportJobBuilderService> logger)
        {
            _dataService = dataService;
            _cleanupService = cleanupService;
            _logger = logger;
        }

        public async Task<Job> BuildExportJobAsync(
            Dictionary<string, string> extractedData,
            int? yearId)
        {
            if (extractedData == null || extractedData.Count == 0)
            {
                _logger.LogWarning("No extracted export data provided");
                return null;
            }

            var job = new Job
            {
                JobType = "EXPORT",
                JobDate = DateTime.Now,
                JobYearId = yearId?.ToString()
            };

            try
            {
                // ==================== HEADER INFO (4 fields) ====================
                if (TryGetValue(extractedData, "Job No", out var jobNo))
                    job.JobNo = _cleanupService.CleanValue(jobNo);

                if (TryGetValue(extractedData, "File No", out var fileNo))
                    job.JobBeNo = _cleanupService.CleanValue(fileNo); // Use JobBeNo for reference

                if (TryGetValue(extractedData, "Job Date", out var jobDate) &&
                    DateTime.TryParse(_cleanupService.CleanValue(jobDate), out var parsedDate))
                    job.JobDate = parsedDate;

                if (TryGetValue(extractedData, "Printed On", out var printedOn) &&
                    DateTime.TryParse(_cleanupService.CleanValue(printedOn), out var parsedPrint))
                    job.JobUpdated = parsedPrint;

                // ==================== CHA DETAILS (4 fields) ====================
                if (TryGetValue(extractedData, "CHA Code", out var chaCode))
                    job.JobCust8 = _cleanupService.CleanValue(chaCode);

                if (TryGetValue(extractedData, "CHA Name", out var chaName))
                {
                    var chaId = await _dataService.GetOrCreateChaIdAsync(
                        _cleanupService.CleanValue(chaName), extractedData);
                    if (chaId.HasValue)
                        job.JobChaId = chaId.Value;
                }

                if (TryGetValue(extractedData, "Port of Loading", out var portLoading))
                {
                    var polId = await _dataService.GetOrCreateLocationWithCountryAsync(
                        _cleanupService.CleanValue(portLoading), "INDIA");
                    if (polId.HasValue)
                        job.JobPolId = polId.Value;
                }

                //if (TryGetValue(extractedData, "State of Origin Code", out var stateOrigin))
                //    job.JobActive = _cleanupService.CleanValue(stateOrigin);

                // ==================== EXPORTER DETAILS (7 fields) ====================
                if (TryGetValue(extractedData, "Exporter Code", out var exporterCode))
                    job.JobCust9 = _cleanupService.CleanValue(exporterCode);

                if (TryGetValue(extractedData, "Exporter Name", out var exporterName))
                {
                    var exporterId = await _dataService.GetOrCreateAccountIdAsync(
                        _cleanupService.CleanValue(exporterName), extractedData, "Exporter");
                    if (exporterId.HasValue)
                        job.JobPartyId = exporterId.Value;
                }
                var addressParts = new List<string>();

                foreach (var key in new[] { "Exporter Address Line 1", "Exporter Address Line 2", "Exporter Address Line 3" })
                {
                    if (TryGetValue(extractedData, key, out var line))
                        addressParts.Add(_cleanupService.CleanValue(line));
                }

                var fullAddress = string.Join(", ", addressParts);
                if (fullAddress.Length <= 300)
                    job.JobPartyAddress = fullAddress;


                if (TryGetValue(extractedData, "Exporter Type", out var exporterType))
                    job.JobRemarks = _cleanupService.CleanValue(exporterType);

                if (TryGetValue(extractedData, "Adcode", out var adCode))
                    job.JobCust6 = _cleanupService.CleanValue(adCode);

                //if (TryGetValue(extractedData, "Forex Bank Account", out var forexAcc))
                //    job.JobCrust1 = _cleanupService.CleanValue(forexAcc);

                // ==================== CONSIGNEE DETAILS (8 fields) ====================
                if (TryGetValue(extractedData, "Consignee Code", out var consigneeCode))
                    job.JobAgent = _cleanupService.CleanValue(consigneeCode);

                if (TryGetValue(extractedData, "Consignee Name", out var consigneeName))
                {
                    var consigneeId = await _dataService.GetOrCreateConsigneeIdAsync(
                        _cleanupService.CleanValue(consigneeName));
                    if (consigneeId.HasValue)
                        job.JobConsigneeId = consigneeId.Value;
                }

                if (TryGetValue(extractedData, "Consignee Address Line 1", out var consAddr1))
                    job.JobConsigneeAddress = _cleanupService.CleanValue(consAddr1);

                if (TryGetValue(extractedData, "Consignee Address Line 2", out var consAddr2))
                {
                    var sb = new StringBuilder(job.JobConsigneeAddress);
                    sb.Append(", ");
                    sb.Append(_cleanupService.CleanValue(consAddr2));

                    var combinedAddr = sb.ToString();
                    job.JobConsigneeAddress = combinedAddr.Length > 300 ? job.JobConsigneeAddress : combinedAddr;
                }


                if (TryGetValue(extractedData, "Port of Discharge", out var portDischarge))
                {
                    var podId = await _dataService.GetOrCreateLocationWithCountryAsync(
                        _cleanupService.CleanValue(portDischarge),
                        extractedData.GetValueOrDefault("Country of Discharge", null));
                    if (podId.HasValue)
                        job.JobPodId = podId.Value;
                }

                if (TryGetValue(extractedData, "Country of Discharge", out var countryDischarge))
                    job.JobCountryDischarge = _cleanupService.CleanValue(countryDischarge);

                if (TryGetValue(extractedData, "Port of Final Destination", out var portFinal))
                    job.JobPlaceOfDelivery = _cleanupService.CleanValue(portFinal);

                if (TryGetValue(extractedData, "Country Final Destination", out var countryFinal))
                    job.JobCountryOrigin = _cleanupService.CleanValue(countryFinal);

                // ==================== CARGO DETAILS (9 fields) ====================
                if (TryGetValue(extractedData, "Total Packages", out var pkgs) &&
                    double.TryParse(_cleanupService.CleanValue(pkgs), out var pkgsParsed))
                    job.JobQty = pkgsParsed;

                if (TryGetValue(extractedData, "Net Weight", out var netWt) &&
                    double.TryParse(_cleanupService.CleanValue(netWt)?.Replace(",", ""), out var nwParsed))
                    job.JobNetWt = nwParsed;

                if (TryGetValue(extractedData, "Gross Weight", out var grossWt) &&
                    double.TryParse(_cleanupService.CleanValue(grossWt)?.Replace(",", ""), out var gwParsed))
                    job.JobGrossWt = gwParsed;

                if (TryGetValue(extractedData, "Number of Containers", out var numContainers) &&
                    int.TryParse(_cleanupService.CleanValue(numContainers), out var numCParsed))
                    job.JobCbm = numCParsed;

                if (TryGetValue(extractedData, "Cargo Nature", out var cargoNature))
                    job.JobCargoId = 1; // You can enhance this with GetOrCreateCargoIdAsync

                if (TryGetValue(extractedData, "Marks and Numbers", out var marks))
                    job.JobMarks = _cleanupService.CleanValue(marks);

                if (TryGetValue(extractedData, "Seal Type", out var sealType))
                    job.JobPrecarriedBy = _cleanupService.CleanValue(sealType);

                if (TryGetValue(extractedData, "FOB Value INR", out var fobValue) &&
                    double.TryParse(_cleanupService.CleanValue(fobValue), out var fobParsed))
                    job.JobCust1 = fobParsed.ToString();

                if (TryGetValue(extractedData, "Drawback INR", out var drawback) &&
                    double.TryParse(_cleanupService.CleanValue(drawback), out var dbParsed))
                    job.JobCust2 = dbParsed.ToString();

                // ==================== INVOICE DETAILS (12 fields) ====================
                if (TryGetValue(extractedData, "Number of Invoices", out var numInv))
                    job.JobNoOfBl = _cleanupService.CleanValue(numInv);

                if (TryGetValue(extractedData, "Invoice Number", out var invNo))
                    job.JobShipperInvNo = _cleanupService.CleanValue(invNo);

                if (TryGetValue(extractedData, "Invoice Date", out var invDate) &&
                    DateTime.TryParse(_cleanupService.CleanValue(invDate), out var invDateParsed))
                    job.JobShipperInvDate = invDateParsed;

                if (TryGetValue(extractedData, "Invoice Value FC", out var invValFc))
                    job.JobVolume = _cleanupService.CleanValue(invValFc);

                if (TryGetValue(extractedData, "Invoice Value INR", out var invValInr) &&
                    double.TryParse(_cleanupService.CleanValue(invValInr), out var invParsed))
                    job.JobExchRate = invParsed;

                if (TryGetValue(extractedData, "Currency Code", out var currency))
                    job.JobCust5 = _cleanupService.CleanValue(currency);

                if (TryGetValue(extractedData, "Exchange Rate", out var exRate))
                    job.JobCust4 = _cleanupService.CleanValue(exRate);

                if (TryGetValue(extractedData, "Nature of Contract", out var natContract))
                    job.JobCust7 = _cleanupService.CleanValue(natContract);

                if (TryGetValue(extractedData, "Nature of Payment", out var natPayment))
                    job.JobFreightBy = _cleanupService.CleanValue(natPayment);

                if (TryGetValue(extractedData, "Buyer Details", out var buyerDetails))
                    job.JobNotifyAddress = _cleanupService.CleanValue(buyerDetails);

                if (TryGetValue(extractedData, "DBK Value INR", out var dbkValue))
                    job.JobCust3 = _cleanupService.CleanValue(dbkValue);

                if (TryGetValue(extractedData, "Unit Price Includes", out var unitPrice))
                    job.JobMeasurement = _cleanupService.CleanValue(unitPrice);

                // ==================== CHARGES & DEDUCTIONS (8 fields) ====================
                if (TryGetValue(extractedData, "Insurance Amount", out var insurAmount))
                    job.JobCust8 = _cleanupService.CleanValue(insurAmount);

                if (TryGetValue(extractedData, "Freight Amount", out var freightAmount))
                    job.JobFreightRemarks = _cleanupService.CleanValue(freightAmount);

                if (TryGetValue(extractedData, "Commission Amount", out var commAmount))
                    job.JobForwarder = _cleanupService.CleanValue(commAmount);

                if (TryGetValue(extractedData, "Discount Amount", out var discAmount))
                    job.JobPtaFta = _cleanupService.CleanValue(discAmount);

                // ==================== ITEMS OF EXPORT (6 fields) ====================
                if (TryGetValue(extractedData, "RITC Code", out var ritcCode))
                    job.JobMtdNo = _cleanupService.CleanValue(ritcCode);

                if (TryGetValue(extractedData, "Item Description", out var itemDesc))
                    job.JobGoodsDesc = _cleanupService.CleanValue(itemDesc);

                if (TryGetValue(extractedData, "Item Quantity", out var itemQty))
                    job.JobGoodsDesc1 = _cleanupService.CleanValue(itemQty);

                if (TryGetValue(extractedData, "Item Unit", out var itemUnit))
                    job.JobQtyUnit = _cleanupService.CleanValue(itemUnit);

                if (TryGetValue(extractedData, "Item FOB Value", out var itemFob))
                    job.JobGoodsDesc2 = _cleanupService.CleanValue(itemFob);

                // ==================== DUTY & TAX (4 fields) ====================
                if (TryGetValue(extractedData, "Total IGST Value", out var igstVal) &&
                    double.TryParse(_cleanupService.CleanValue(igstVal), out var igstParsed))
                    job.JobCust2 = igstParsed.ToString();

                //if (TryGetValue(extractedData, "Total IGST Amount", out var igstAmt))
                //    job.JobCrust1 = _cleanupService.CleanValue(igstAmt);

                //if (TryGetValue(extractedData, "Total FOB", out var totalFob))
                //    job.JobCrust2 = _cleanupService.CleanValue(totalFob);

                //if (TryGetValue(extractedData, "Total PMV", out var pmv))
                //    job.JobCrust3 = _cleanupService.CleanValue(pmv);

                // ==================== CONTAINER DETAILS (5 fields) ====================
                if (TryGetValue(extractedData, "Container Number", out var containerNo))
                    job.JobContainer20Ft = _cleanupService.CleanValue(containerNo);

                if (TryGetValue(extractedData, "Container Size", out var containerSize))
                    job.Job20Ft = _cleanupService.CleanValue(containerSize);

                if (TryGetValue(extractedData, "Container Type", out var containerType))
                    job.JobContainerType = _cleanupService.CleanValue(containerType);

                if (TryGetValue(extractedData, "Seal Number", out var sealNo))
                    job.JobSealNo = _cleanupService.CleanValue(sealNo);

                if (TryGetValue(extractedData, "Seal Date", out var sealDate) &&
                    DateTime.TryParse(_cleanupService.CleanValue(sealDate), out var sealDateParsed))
                    job.JobIgmDate = sealDateParsed;

                // ==================== PACKING DETAILS (3 fields) ====================
                if (TryGetValue(extractedData, "Package From", out var pkgFrom))
                    job.JobDoNo = _cleanupService.CleanValue(pkgFrom);

                if (TryGetValue(extractedData, "Package To", out var pkgTo))
                    job.JobCrono = _cleanupService.CleanValue(pkgTo);

                if (TryGetValue(extractedData, "Package Kind", out var pkgKind))
                    job.JobBlType = _cleanupService.CleanValue(pkgKind);

                // ==================== ADDITIONAL INFO (2 fields) ====================
                if (TryGetValue(extractedData, "Factory Stuffed", out var factoryStuffed))
                    job.JobGoodsStuffed = _cleanupService.CleanValue(factoryStuffed);

                if (TryGetValue(extractedData, "Preferential Trade", out var prefTrade))
                    job.JobTransTime = _cleanupService.CleanValue(prefTrade);

                _logger.LogInformation($"✅ Export Job built successfully with {extractedData.Count} fields");
                return job;
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error building export job: {ex.Message}");
                return job;
            }
        }

        private bool TryGetValue(Dictionary<string, string> dict, string key, out string value)
        {
            return dict.TryGetValue(key, out value) && !string.IsNullOrWhiteSpace(value);
        }
    }

}