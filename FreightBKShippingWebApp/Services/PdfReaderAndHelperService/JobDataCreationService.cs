using FreightBKShippingWebApp.Model;
using FreightBKShippingWebApp.Services;
using System.Text.RegularExpressions;

public class JobDataCreationService
{
    private readonly LocationService _locationService;
    private readonly AccountService _accountService;
    private readonly NotifyService _notifyService;
    private readonly AccountGroupService _accountGroupService;
    private readonly CountryService _countryService;
    private readonly CargoService _cargoService;
    private readonly VesselService _vesselService;
    private readonly DataCleanupService _cleanupService;
    private readonly ILogger<JobDataCreationService> _logger;

    public JobDataCreationService(
        LocationService locationService,
        AccountService accountService,
        NotifyService notifyService,
        AccountGroupService accountGroupService,
        CountryService countryService,
        CargoService cargoService,
        VesselService vesselService,
        DataCleanupService cleanupService,
        ILogger<JobDataCreationService> logger)
    {
        _locationService = locationService;
        _accountService = accountService;
        _notifyService = notifyService;
        _accountGroupService = accountGroupService;
        _countryService = countryService;
        _cargoService = cargoService;
        _vesselService = vesselService;
        _cleanupService = cleanupService;
        _logger = logger;
    }

    // ==================== LOCATION METHODS ====================
    public async Task<int?> GetOrCreateLocationIdAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return null;

        try
        {
            var all = await _locationService.GetAllAsync();
            var existing = all.FirstOrDefault(x =>
                string.Equals(x.LocationName?.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase));

            if (existing != null)
                return existing.LocationId;

            var newLoc = new Location { LocationName = name.Trim(), LocationType = "PORT" };
            bool created = await _locationService.CreateAsync(newLoc);

            if (created)
            {
                var refreshed = await _locationService.GetAllAsync();
                return refreshed.FirstOrDefault(x =>
                    string.Equals(x.LocationName?.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase))?.LocationId;
            }

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error creating location: {ex.Message}");
            return null;
        }
    }

    public async Task<int?> GetOrCreateLocationWithCountryAsync(string portName, string countryName = null, string locType = "PORT")
    {
        if (string.IsNullOrWhiteSpace(portName)) return null;

        try
        {
            var all = await _locationService.GetAllAsync();
            var existing = all.FirstOrDefault(x =>
                string.Equals(x.LocationName?.Trim(), portName.Trim(), StringComparison.OrdinalIgnoreCase));

            if (existing != null)
                return existing.LocationId;

            int? countryId = null;

            if (!string.IsNullOrEmpty(countryName))
            {
                countryId = await GetOrCreateCountryIdAsync(countryName);
            }
            else
            {
                var countryMatch = Regex.Match(portName, @"-([A-Z]{2})(?:[A-Z]{2,})?$");
                if (countryMatch.Success)
                {
                    var countryCode = countryMatch.Groups[1].Value;
                    countryId = await GetOrCreateCountryIdAsync(countryCode);
                }
            }

            if (countryId == null)
                countryId = await GetDefaultCountryIdAsync();

            if (countryId == null)
                return null;

            var newLoc = new Location
            {
                LocationName = portName.Trim(),
                LocationCode = portName.Trim(),
                LocationCountryId = countryId.Value,
                LocationType=locType
              
            };

            bool created = await _locationService.CreateAsync(newLoc);

            if (created)
            {
                var refreshed = await _locationService.GetAllAsync();
                return refreshed.FirstOrDefault(x =>
                    string.Equals(x.LocationName?.Trim(), portName.Trim(), StringComparison.OrdinalIgnoreCase))?.LocationId;
            }

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error creating location: {ex.Message}");
            return null;
        }
    }

    // ==================== COUNTRY METHODS ====================
    public async Task<int?> GetDefaultCountryIdAsync()
    {
        try
        {
            var countries = await _countryService.GetAllAsync();
            var india = countries.FirstOrDefault(c =>
                c.CountryName?.Equals("India", StringComparison.OrdinalIgnoreCase) == true ||
                c.CountryCode?.Equals("IN", StringComparison.OrdinalIgnoreCase) == true);

            if (india != null)
                return india.CountryId;

            var firstCountry = countries.FirstOrDefault();
            if (firstCountry != null)
                return firstCountry.CountryId;

            var newIndia = new Country { CountryName = "India", CountryCode = "IN" };
            bool created = await _countryService.CreateAsync(newIndia);

            if (created)
            {
                var refreshedCountries = await _countryService.GetAllAsync();
                return refreshedCountries.FirstOrDefault()?.CountryId;
            }

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error getting default country: {ex.Message}");
            return null;
        }
    }

    public async Task<int?> GetOrCreateCountryIdAsync(string countryNameOrCode)
    {
        if (string.IsNullOrWhiteSpace(countryNameOrCode)) return null;

        try
        {
            var countries = await _countryService.GetAllAsync();
            var existing = countries.FirstOrDefault(c =>
                string.Equals(c.CountryName?.Trim(), countryNameOrCode.Trim(), StringComparison.OrdinalIgnoreCase) ||
                string.Equals(c.CountryCode?.Trim(), countryNameOrCode.Trim(), StringComparison.OrdinalIgnoreCase));

            if (existing != null)
                return existing.CountryId;

            var newCountry = new Country
            {
                CountryName = countryNameOrCode.Trim(),
                CountryCode = countryNameOrCode.Length == 2 ?
                    countryNameOrCode.ToUpper() :
                    countryNameOrCode.Substring(0, Math.Min(2, countryNameOrCode.Length)).ToUpper()
            };

            bool created = await _countryService.CreateAsync(newCountry);

            if (created)
            {
                var refreshed = await _countryService.GetAllAsync();
                return refreshed.FirstOrDefault(c =>
                    string.Equals(c.CountryName?.Trim(), countryNameOrCode.Trim(), StringComparison.OrdinalIgnoreCase))?.CountryId;
            }

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error creating country: {ex.Message}");
            return null;
        }
    }

    // ==================== ACCOUNT METHODS ====================
    public async Task<int?> GetDefaultAccountGroupIdAsync()
    {
        try
        {
            if (_accountGroupService == null)
                return 12;

            var groups = await _accountGroupService.GetAllAsync();
            var defaultGroup = groups.FirstOrDefault(g =>
                g.AccountGroupName?.Contains("Sundry", StringComparison.OrdinalIgnoreCase) == true ||
                g.AccountGroupName?.Contains("Debtor", StringComparison.OrdinalIgnoreCase) == true ||
                g.AccountGroupName?.Contains("General", StringComparison.OrdinalIgnoreCase) == true);

            if (defaultGroup != null)
                return defaultGroup.AccountGroupId;

            var firstGroup = groups.FirstOrDefault();
            return firstGroup?.AccountGroupId ?? 12;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error getting default account group: {ex.Message}");
            return 1;
        }
    }

    //public async Task<int?> GetOrCreateAccountIdAsync(string name, Dictionary<string, string> data = null, string prefix = "")
    //{
    //    if (string.IsNullOrWhiteSpace(name)) return null;

    //    try
    //    {
    //        var all = await _accountService.GetAllAsync();
    //        var existing = all.FirstOrDefault(x =>
    //            string.Equals(x.AccountName?.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase));

    //        if (existing != null)
    //            return existing.AccountId;

    //        var defaultGroupId = await GetDefaultAccountGroupIdAsync();
    //        if (defaultGroupId == null)
    //            return null;

    //        var newAcc = new Account
    //        {
    //            AccountName = name.Trim(),
    //            AccountGroupId = defaultGroupId.Value,
    //            AccountPrintName = name.Trim(),
    //            AccountTypeId = 18
    //        };

    //        if (data != null)
    //        {
    //            var addressKey = string.IsNullOrEmpty(prefix) ? "Address" : $"{prefix} Address";
    //            var phoneKey = string.IsNullOrEmpty(prefix) ? "Phone" : $"{prefix} Phone";
    //            var emailKey = string.IsNullOrEmpty(prefix) ? "Email" : $"{prefix} Email";
    //            var gstinKey = string.IsNullOrEmpty(prefix) ? "GSTIN" : $"{prefix} GSTIN";
    //            var panKey = string.IsNullOrEmpty(prefix) ? "PAN" : $"{prefix} PAN";
    //            var codeKey = string.IsNullOrEmpty(prefix) ? "Code" : $"{prefix} Code";

    //            if (data.TryGetValue(addressKey, out var addr))
    //                newAcc.AccountAddress1 = _cleanupService.CleanValue(addr?.ToString());

    //            if (data.TryGetValue(phoneKey, out var phone))
    //                newAcc.AccountPhone = _cleanupService.CleanValue(phone?.ToString());

    //            if (data.TryGetValue(emailKey, out var email))
    //                newAcc.AccountEmail = _cleanupService.CleanValue(email?.ToString());

    //            if (data.TryGetValue(gstinKey, out var gstin))
    //                newAcc.AccountGstNo = _cleanupService.CleanValue(gstin?.ToString());

    //            if (data.TryGetValue(panKey, out var pan))
    //                newAcc.AccountPan = _cleanupService.CleanValue(pan?.ToString());

    //            if (data.TryGetValue(codeKey, out var code))
    //                newAcc.AccountCode = _cleanupService.CleanValue(code?.ToString());
    //        }

    //        var createdAcc = await _accountService.CreateAsync(newAcc);
    //        return createdAcc?.AccountId;
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError($"Error creating account '{name}': {ex.Message}");
    //        return null;
    //    }
    //}

    // ==================== CHA METHODS ====================
    public async Task<int?> GetOrCreateAccountIdAsync(string name, Dictionary<string, string> data = null, string prefix = "")
    {
        if (string.IsNullOrWhiteSpace(name)) return null;
        try
        {
            var all = await _accountService.GetAllAsync();
            var existing = all.FirstOrDefault(x =>
                string.Equals(x.AccountName?.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase));
            if (existing != null)
                return existing.AccountId;

            var defaultGroupId = await GetDefaultAccountGroupIdAsync();
            if (defaultGroupId == null)
                return null;

            var newAcc = new Account
            {
                AccountName = name.Trim(),
                AccountGroupId = defaultGroupId.Value,
                AccountPrintName = name.Trim(),
                AccountTypeId = 18
            };

            if (data != null)
            {
                // ==================== BUILD COMPLETE ADDRESS FROM MULTIPLE LINES ====================
                var addressParts = new List<string>();

                // Try single address field (old format)
                var singleAddressKey = string.IsNullOrEmpty(prefix) ? "Address" : $"{prefix} Address";
                if (data.TryGetValue(singleAddressKey, out var singleAddr) && !string.IsNullOrWhiteSpace(singleAddr))
                {
                    addressParts.Add(singleAddr.Trim());
                    _logger.LogInformation($"✅ Found single address: {singleAddr}");
                }

                // Try multi-line address fields (new format: "Exporter Address Line 1", "Exporter Address Line 2", etc.)
                int addressLineNum = 1;
                while (true)
                {
                    var multiAddressKey = string.IsNullOrEmpty(prefix)
                        ? $"Address Line {addressLineNum}"
                        : $"{prefix} Address Line {addressLineNum}";

                    if (data.TryGetValue(multiAddressKey, out var multiAddr) && !string.IsNullOrWhiteSpace(multiAddr))
                    {
                        addressParts.Add(multiAddr.Trim());
                        _logger.LogInformation($"✅ Found address line {addressLineNum}: {multiAddr}");
                        addressLineNum++;
                    }
                    else
                    {
                        break; // No more address lines
                    }
                }

                // Join all address lines
                if (addressParts.Count > 0)
                {
                    var fullAddress = string.Join(", ", addressParts);
                    newAcc.AccountAddress1 = _cleanupService.CleanValue(fullAddress);
                    _logger.LogInformation($"✅ Final address: {newAcc.AccountAddress1}");
                }

                // ==================== EXTRACT OTHER FIELDS ====================
                var phoneKey = string.IsNullOrEmpty(prefix) ? "Phone" : $"{prefix} Phone";
                if (data.TryGetValue(phoneKey, out var phone))
                    newAcc.AccountPhone = _cleanupService.CleanValue(phone?.ToString());

                var emailKey = string.IsNullOrEmpty(prefix) ? "Email" : $"{prefix} Email";
                if (data.TryGetValue(emailKey, out var email))
                    newAcc.AccountEmail = _cleanupService.CleanValue(email?.ToString());

                var gstinKey = string.IsNullOrEmpty(prefix) ? "GSTIN" : $"{prefix} GSTIN";
                if (data.TryGetValue(gstinKey, out var gstin))
                    newAcc.AccountGstNo = _cleanupService.CleanValue(gstin?.ToString());

                var panKey = string.IsNullOrEmpty(prefix) ? "PAN" : $"{prefix} PAN";
                if (data.TryGetValue(panKey, out var pan))
                    newAcc.AccountPan = _cleanupService.CleanValue(pan?.ToString());

                var codeKey = string.IsNullOrEmpty(prefix) ? "Code" : $"{prefix} Code";
                if (data.TryGetValue(codeKey, out var code))
                    newAcc.AccountCode = _cleanupService.CleanValue(code?.ToString());
            }

            var createdAcc = await _accountService.CreateAsync(newAcc);
            _logger.LogInformation($"✅ Account created: {name} (ID: {createdAcc?.AccountId})");
            return createdAcc?.AccountId;
        }
        catch (Exception ex)
        {
            _logger.LogError($"❌ Error creating account '{name}': {ex.Message}");
            return null;
        }
    }
    public async Task<int?> GetOrCreateChaIdAsync(string name, Dictionary<string, string> data = null)
    {
        if (string.IsNullOrWhiteSpace(name)) return null;

        try
        {
            var all = await _notifyService.GetAllAsync();
            var existing = all.FirstOrDefault(x =>
                string.Equals(x.NotifyName?.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase) &&
                x.NotifyType == "CHA");

            if (existing != null)
                return existing.NotifyId;

            var newCha = new Notify { NotifyName = name.Trim(), NotifyType = "CHA" };

            if (data != null)
            {
                if (data.TryGetValue("CHA Address", out var addr))
                    newCha.NotifyAddress1 = _cleanupService.CleanValue(addr?.ToString());

                if (data.TryGetValue("CHA Phone", out var phone))
                    newCha.NotifyContactNo = _cleanupService.CleanValue(phone?.ToString());

                if (data.TryGetValue("CHA Email", out var email))
                    newCha.NotifyEmail = _cleanupService.CleanValue(email?.ToString());

                if (data.TryGetValue("CHA GSTIN", out var gstin))
                    newCha.NotifyGstNo = _cleanupService.CleanValue(gstin?.ToString());

                if (data.TryGetValue("CHA PAN", out var pan))
                    newCha.NotifyPan = _cleanupService.CleanValue(pan?.ToString());
            }

            var created = await _notifyService.CreateAsync(newCha);
            if (created != null)
                return created.NotifyId;

            var refreshed = await _notifyService.GetAllAsync();
            return refreshed.FirstOrDefault(x =>
                string.Equals(x.NotifyName?.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase) &&
                x.NotifyType == "CHA")?.NotifyId;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error creating CHA '{name}': {ex.Message}");
            return null;
        }
    }

    // ==================== LINE METHODS ====================
    public async Task<int?> GetOrCreateLineIdAsync(string name, Dictionary<string, string> data = null)
    {
        if (string.IsNullOrWhiteSpace(name)) return null;

        try
        {
            var all = await _notifyService.GetAllAsync();
            var existing = all.FirstOrDefault(x =>
                string.Equals(x.NotifyName?.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase) &&
                x.NotifyType == "LINE");

            if (existing != null)
                return existing.NotifyId;

            var newLine = new Notify { NotifyName = name.Trim(), NotifyType = "LINE" };

            if (data != null)
            {
                if (data.TryGetValue("Line Address", out var addr))
                    newLine.NotifyAddress1 = _cleanupService.CleanValue(addr?.ToString());

                if (data.TryGetValue("Line Phone", out var phone))
                    newLine.NotifyContactNo = _cleanupService.CleanValue(phone?.ToString());

                if (data.TryGetValue("Line Email", out var email))
                    newLine.NotifyEmail = _cleanupService.CleanValue(email?.ToString());
            }

            var created = await _notifyService.CreateAsync(newLine);
            if (created != null)
                return created.NotifyId;

            var refreshed = await _notifyService.GetAllAsync();
            return refreshed.FirstOrDefault(x =>
                string.Equals(x.NotifyName?.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase) &&
                x.NotifyType == "LINE")?.NotifyId;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error creating line '{name}': {ex.Message}");
            return null;
        }
    }

    // ==================== CARGO & VESSEL METHODS ====================
    public async Task<int?> GetOrCreateCargoIdAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return null;

        try
        {
            var all = await _cargoService.GetAllAsync();
            var existing = all.FirstOrDefault(x =>
                string.Equals(x.CargoName?.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase));

            if (existing != null)
                return existing.CargoId;

            var newCargo = new Cargo { CargoName = name.Trim() };
            bool created = await _cargoService.CreateAsync(newCargo);

            if (created)
            {
                var refreshed = await _cargoService.GetAllAsync();
                return refreshed.FirstOrDefault(x =>
                    string.Equals(x.CargoName?.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase))?.CargoId;
            }

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error creating cargo '{name}': {ex.Message}");
            return await GetOrCreateAccountIdAsync(name);
        }
    }

    public async Task<int?> GetOrCreateVesselIdAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return null;

        try
        {
            var all = await _vesselService.GetAllAsync();
            var existing = all.FirstOrDefault(x =>
                string.Equals(x.VesselName?.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase));

            if (existing != null)
                return existing.VesselId;

            var newVessel = new Vessel { VesselName = name.Trim() };
            bool created = await _vesselService.CreateAsync(newVessel);

            if (created)
            {
                var refreshed = await _vesselService.GetAllAsync();
                return refreshed.FirstOrDefault(x =>
                    string.Equals(x.VesselName?.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase))?.VesselId;
            }

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error creating vessel '{name}': {ex.Message}");
            return await GetOrCreateAccountIdAsync(name);
        }
    }

    public async Task<int?> GetOrCreateConsigneeIdAsync(string name, Dictionary<string, string> data = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            return null;

        try
        {
            // Step 1: Check if consignee already exists
            var all = await _notifyService.GetAllAsync();
            var existing = all.FirstOrDefault(x =>
                string.Equals(x.NotifyName?.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase) &&
                x.NotifyType == "CONSIGNEE");

            if (existing != null)
                return existing.NotifyId;

            // Step 2: Create new Consignee
            var newConsignee = new Notify
            {
                NotifyName = name.Trim(),
                NotifyType = "CONSIGNEE"
            };

            // Step 3: Optional details from dictionary (address, phone, email, etc.)
            if (data != null)
            {
                if (data.TryGetValue("Consignee Address Line 1", out var addr1))
                    newConsignee.NotifyAddress1 = _cleanupService.CleanValue(addr1?.ToString());

                if (data.TryGetValue("Consignee Address Line 2", out var addr2))
                    newConsignee.NotifyAddress2 = _cleanupService.CleanValue(addr2?.ToString());

                if (data.TryGetValue("Consignee Address Line 3", out var addr3))
                    newConsignee.NotifyAddress3 = _cleanupService.CleanValue(addr3?.ToString());

             

                if (data.TryGetValue("Consignee Phone", out var phone))
                    newConsignee.NotifyContactNo = _cleanupService.CleanValue(phone?.ToString());

                if (data.TryGetValue("Consignee Email", out var email))
                    newConsignee.NotifyEmail = _cleanupService.CleanValue(email?.ToString());
            }

            // Step 4: Create in DB/service
            var created = await _notifyService.CreateAsync(newConsignee);
            if (created != null)
                return created.NotifyId;

            // Step 5: Retry fetch if creation didn’t return ID
            var refreshed = await _notifyService.GetAllAsync();
            return refreshed.FirstOrDefault(x =>
                string.Equals(x.NotifyName?.Trim(), name.Trim(), StringComparison.OrdinalIgnoreCase) &&
                x.NotifyType == "CONSIGNEE")?.NotifyId;
        }
        catch (Exception ex)
        {
            _logger.LogError($"❌ Error creating consignee '{name}': {ex.Message}");
            return null;
        }
    }

}
