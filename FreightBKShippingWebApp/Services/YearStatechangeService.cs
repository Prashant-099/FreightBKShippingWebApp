using FreightBKShippingWebApp.Model;
using System.ComponentModel.DataAnnotations;

namespace FreightBKShippingWebApp.Services
{
    public class YearStatechangeService
    {
        private readonly YearService _yearService;
        private readonly VoucherConfigService _VoucherConfigService;

        public YearStatechangeService(YearService yearService, VoucherConfigService VoucherConfigService)
        {
            _yearService = yearService;
            _VoucherConfigService = VoucherConfigService;
        }

        public int SelectedYearId { get;  set; }
        public List<YearModel> Years { get;  set; } = new();

        public event Action? OnYearChanged; // 🔔 notify subscribers when year changes

        public async Task<IEnumerable<YearModel>> LoadYearsAsync()
        {
            var allYears = await _yearService.GetAllAsync();

            // Filter enabled years
            Years = allYears?
                .Where(y => y.YearStatus)
                .ToList() ?? new List<YearModel>();

            // Pick default
            var defaultYear = Years.FirstOrDefault(y => y.YearIsDefault);
            if (defaultYear != null)
                SelectedYearId = defaultYear.YearId;

            return Years;
        }

        public void ChangeYear(int newYearId)
        {
            SelectedYearId = newYearId;
            OnYearChanged?.Invoke(); // 🔔 notify subscribers
        }

        // ✅ Global validation function
        public bool IsDateWithinSelectedYear(DateTime? date)
        {
            var year = Years.FirstOrDefault(y => y.YearId == SelectedYearId);
            if (year == null)
                return false;

            return date >= year.YearDateFrom && date <= year.YearDateTo;
        }
        public static ValidationResult ValidateDateWithinYear(DateTime date, ValidationContext context)
        {
            var yearService = (YearStatechangeService)context.GetService(typeof(YearStatechangeService));
            if (!yearService.IsDateWithinSelectedYear(date))
                return new ValidationResult("Date Not Valid");

            return ValidationResult.Success;
        }

        public List<VoucherConfig> VoucherConfigs { get; set; } = new();


        public async Task<(string prefix, int number, string suffix)> GenerateCertiNoAsync(int branchId, int finYearId, string phyto, string certitype)
        {
            VoucherConfigs = await _VoucherConfigService.GetAllAsync();
                      var config = VoucherConfigs
                .FirstOrDefault(x => x.VoucherConfig_Branch_Id == branchId &&
                                     x.VoucherConfig_FinYear_Id == finYearId &&
                                     x.VoucherConfig_ProdType == certitype &&
                                  string.Equals(x.VoucherConfig_Phyto?.Trim(), phyto?.Trim(), StringComparison.OrdinalIgnoreCase));

            if (config == null)
               // throw new Exception($"Voucher configuration not found for Branch={branchId}, Year={finYearId}, Phyto='{phyto}'");
              throw new Exception("Voucher configuration not found!");

            int nextNo = config.VoucherConfig_LastVoucherNo + 1;

            // update last no
           // config.VoucherConfig_LastVoucherNo = nextNo;

            // return pieces
            return (config.VoucherConfig_Prefix ?? string.Empty,
                    nextNo,
                    config.VoucherConfig_Suffix ?? string.Empty);
        }

        //public async Task<int> GenerateCertiNo(int branchId, int finYearId , string phyto)
        //{
        //    VoucherConfigs= await _VoucherConfigService.GetAllAsync();
        //    var config = VoucherConfigs
        //        .FirstOrDefault(x => x.VoucherConfig_Branch_Id == branchId && x.VoucherConfig_FinYear_Id == finYearId && x.VoucherConfig_Phyto == phyto);

        //    if (config == null)
        //        throw new Exception("Voucher configuration not found!");

        //    int nextNo = config.VoucherConfig_LastVoucherNo + 1;

        //    // update last no
        //    config.VoucherConfig_LastVoucherNo = nextNo;

        //    return nextNo;
        //}

        //public string GenerateCertiNo(int branchId, int finYearId)
        //{
        //    var config = VoucherConfigs
        //        .FirstOrDefault(x => x.VoucherConfig_Branch_Id == branchId && x.VoucherConfig_FinYear_Id == finYearId);

        //    if (config == null)
        //        throw new Exception("Voucher configuration not found!");

        //    int nextNo = config.VoucherConfig_LastVoucherNo + 1;
        //    string formattedNo = nextNo.ToString(new string('0', config.VoucherConfig_VoucherDigit));

        //    return $"{config.VoucherConfig_Prefix}{formattedNo}{config.VoucherConfig_Suffix}";
        //}


    }
}
