using ClosedXML.Excel;
using FreightBKShippingWebApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FreightBKShippingWebApp.Services
{
    /// <summary>
    /// GSTR-3B Excel service that uses government template and fills summary data
    /// GSTR-3B is a monthly summary return
    /// </summary>
    public class Gstr3BTemplateService
    {
        /// <summary>
        /// Generate GSTR-3B using government template file
        /// </summary>
        public byte[] GenerateFromTemplate(
            string templatePath,
            string gstin,
            string legalName,
            string year,
            string month,
            Gstr3BData data)
        {
            // Load the government template (XLSM file)
            using var workbook = new XLWorkbook(templatePath);
            var sheet = workbook.Worksheet("GSTR-3B");

            if (sheet == null)
                throw new Exception("GSTR-3B sheet not found in template");

            // Fill header information
            sheet.Cell(5, 2).Value = gstin;
            sheet.Cell(5, 5).Value = year;
            sheet.Cell(6, 2).Value = legalName;
            sheet.Cell(6, 5).Value = month;

            // 3.1 Details of Outward Supplies and inward supplies liable to reverse charge
            Fill31OutwardSupplies(sheet, data);

            // 3.1.1 Details of supplies notified under section 9(5)
            Fill311Section95Supplies(sheet, data);

            // 3.2 Of the supplies shown in 3.1 (a) above, details of inter-State supplies
            Fill32InterStateSupplies(sheet, data);

            // 4. Eligible ITC
            Fill4EligibleITC(sheet, data);

            // 5. Values of exempt, nil-rated and non-GST inward supplies
            Fill5ExemptSupplies(sheet, data);

            // 5.1 Interest and Late fee
            Fill51InterestLateFee(sheet, data);

            // 6. Payment of tax
            Fill6PaymentOfTax(sheet, data);

            // Save to memory
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        #region 3.1 Outward Supplies

        private void Fill31OutwardSupplies(IXLWorksheet sheet, Gstr3BData data)
        {
            // Row 11: (a) Outward Taxable supplies (other than zero rated, nil rated and exempted)
            sheet.Cell(11, 3).Value = (double)data.OutwardTaxableSupplies_TaxableValue;
            sheet.Cell(11, 4).Value = (double)data.OutwardTaxableSupplies_IGST;
            sheet.Cell(11, 5).Value = (double)data.OutwardTaxableSupplies_CGST;
            sheet.Cell(11, 6).Value = (double)data.OutwardTaxableSupplies_SGST;
            sheet.Cell(11, 7).Value = (double)data.OutwardTaxableSupplies_Cess;

            // Row 12: (b) Outward Taxable supplies (zero rated)
            sheet.Cell(12, 3).Value = (double)data.OutwardZeroRated_TaxableValue;
            sheet.Cell(12, 4).Value = (double)data.OutwardZeroRated_IGST;
            sheet.Cell(12, 5).Value = (double)data.OutwardZeroRated_CGST;
            sheet.Cell(12, 6).Value = (double)data.OutwardZeroRated_SGST;
            sheet.Cell(12, 7).Value = (double)data.OutwardZeroRated_Cess;

            // Row 13: (c) Other Outward supplies (Nil rated, exempted)
            sheet.Cell(13, 3).Value = (double)data.OutwardNilRated_TaxableValue;

            // Row 14: (d) Inward supplies (liable to reverse charge)
            sheet.Cell(14, 3).Value = (double)data.InwardReverseCharge_TaxableValue;
            sheet.Cell(14, 4).Value = (double)data.InwardReverseCharge_IGST;
            sheet.Cell(14, 5).Value = (double)data.InwardReverseCharge_CGST;
            sheet.Cell(14, 6).Value = (double)data.InwardReverseCharge_SGST;
            sheet.Cell(14, 7).Value = (double)data.InwardReverseCharge_Cess;

            // Row 15: (e) Non-GST outward supplies
            sheet.Cell(15, 3).Value = (double)data.NonGSTOutward_TaxableValue;

            // Note: Row 16 has formulas for totals - don't override
        }

        #endregion

        #region 3.1.1 Section 9(5) Supplies

        private void Fill311Section95Supplies(IXLWorksheet sheet, Gstr3BData data)
        {
            // Row 22: Inward supplies from ISD
            if (data.Section95_ISD_TaxableValue > 0)
            {
                sheet.Cell(22, 3).Value = (double)data.Section95_ISD_TaxableValue;
                sheet.Cell(22, 4).Value = (double)data.Section95_ISD_IGST;
                sheet.Cell(22, 5).Value = (double)data.Section95_ISD_CGST;
                sheet.Cell(22, 6).Value = (double)data.Section95_ISD_SGST;
                sheet.Cell(22, 7).Value = (double)data.Section95_ISD_Cess;
            }

            // Row 23: Supplies received from deemed supplier
            if (data.Section95_DeemedSupplier_TaxableValue > 0)
            {
                sheet.Cell(23, 3).Value = (double)data.Section95_DeemedSupplier_TaxableValue;
                sheet.Cell(23, 4).Value = (double)data.Section95_DeemedSupplier_IGST;
                sheet.Cell(23, 5).Value = (double)data.Section95_DeemedSupplier_CGST;
                sheet.Cell(23, 6).Value = (double)data.Section95_DeemedSupplier_SGST;
                sheet.Cell(23, 7).Value = (double)data.Section95_DeemedSupplier_Cess;
            }

            // Note: Row 24 has formulas for totals
        }

        #endregion

        #region 3.2 Inter-State Supplies

        private void Fill32InterStateSupplies(IXLWorksheet sheet, Gstr3BData data)
        {
            if (data.InterStateSupplies == null || !data.InterStateSupplies.Any())
                return;

            int startRow = 28;
            int currentRow = startRow;

            foreach (var supply in data.InterStateSupplies.OrderBy(s => s.PlaceOfSupply))
            {
                if (currentRow > 64) break; // Safety limit

                sheet.Cell(currentRow, 2).Value = supply.PlaceOfSupply;
                sheet.Cell(currentRow, 3).Value = (double)supply.TaxableValue;
                sheet.Cell(currentRow, 4).Value = (double)supply.IntegratedTax;

                currentRow++;
            }
        }

        #endregion

        #region 4. Eligible ITC

        private void Fill4EligibleITC(IXLWorksheet sheet, Gstr3BData data)
        {
            // (A) ITC Available

            // Row 31: (1) Import of goods
            sheet.Cell(31, 3).Value = (double)data.ITC_ImportGoods_IGST;
            sheet.Cell(31, 4).Value = (double)data.ITC_ImportGoods_CGST;
            sheet.Cell(31, 5).Value = (double)data.ITC_ImportGoods_SGST;
            sheet.Cell(31, 6).Value = (double)data.ITC_ImportGoods_Cess;

            // Row 32: (2) Import of services
            sheet.Cell(32, 3).Value = (double)data.ITC_ImportServices_IGST;
            sheet.Cell(32, 4).Value = (double)data.ITC_ImportServices_CGST;
            sheet.Cell(32, 5).Value = (double)data.ITC_ImportServices_SGST;
            sheet.Cell(32, 6).Value = (double)data.ITC_ImportServices_Cess;

            // Row 33: (3) Inward supplies liable to reverse charge
            sheet.Cell(33, 3).Value = (double)data.ITC_ReverseCharge_IGST;
            sheet.Cell(33, 4).Value = (double)data.ITC_ReverseCharge_CGST;
            sheet.Cell(33, 5).Value = (double)data.ITC_ReverseCharge_SGST;
            sheet.Cell(33, 6).Value = (double)data.ITC_ReverseCharge_Cess;

            // Row 34: (4) Inward supplies from ISD
            sheet.Cell(34, 3).Value = (double)data.ITC_ISD_IGST;
            sheet.Cell(34, 4).Value = (double)data.ITC_ISD_CGST;
            sheet.Cell(34, 5).Value = (double)data.ITC_ISD_SGST;
            sheet.Cell(34, 6).Value = (double)data.ITC_ISD_Cess;

            // Row 35: (5) All other ITC
            sheet.Cell(35, 3).Value = (double)data.ITC_Others_IGST;
            sheet.Cell(35, 4).Value = (double)data.ITC_Others_CGST;
            sheet.Cell(35, 5).Value = (double)data.ITC_Others_SGST;
            sheet.Cell(35, 6).Value = (double)data.ITC_Others_Cess;

            // (B) ITC Reversed

            // Row 37: (1) As per rules 42 & 43
            sheet.Cell(37, 3).Value = (double)data.ITC_Reversed_Rule42_43_IGST;
            sheet.Cell(37, 4).Value = (double)data.ITC_Reversed_Rule42_43_CGST;
            sheet.Cell(37, 5).Value = (double)data.ITC_Reversed_Rule42_43_SGST;
            sheet.Cell(37, 6).Value = (double)data.ITC_Reversed_Rule42_43_Cess;

            // Row 38: (2) Others
            sheet.Cell(38, 3).Value = (double)data.ITC_Reversed_Others_IGST;
            sheet.Cell(38, 4).Value = (double)data.ITC_Reversed_Others_CGST;
            sheet.Cell(38, 5).Value = (double)data.ITC_Reversed_Others_SGST;
            sheet.Cell(38, 6).Value = (double)data.ITC_Reversed_Others_Cess;

            // Note: Row 39 (C) Net ITC has formulas
        }

        #endregion

        #region 5. Exempt/Nil/Non-GST Supplies

        private void Fill5ExemptSupplies(IXLWorksheet sheet, Gstr3BData data)
        {
            // Row 42: Inter-State supplies
            sheet.Cell(42, 3).Value = (double)data.Exempt_InterState;

            // Row 43: Intra-State supplies
            sheet.Cell(43, 3).Value = (double)data.Exempt_IntraState;

            // Note: Row 44 has formula for total
        }

        #endregion

        #region 5.1 Interest and Late Fee

        private void Fill51InterestLateFee(IXLWorksheet sheet, Gstr3BData data)
        {
            // Row 64: Interest - Integrated Tax
            sheet.Cell(64, 2).Value = "Integrated Tax";
            sheet.Cell(64, 3).Value = (double)data.Interest_IGST;

            // Row 65: Interest - Central Tax
            sheet.Cell(65, 2).Value = "Central Tax";
            sheet.Cell(65, 3).Value = (double)data.Interest_CGST;

            // Row 66: Interest - State/UT Tax
            sheet.Cell(66, 2).Value = "State/UT Tax";
            sheet.Cell(66, 3).Value = (double)data.Interest_SGST;

            // Row 68: Late Fee - Integrated Tax
            if (data.LateFee_IGST > 0)
            {
                sheet.Cell(68, 2).Value = "Integrated Tax";
                sheet.Cell(68, 3).Value = (double)data.LateFee_IGST;
            }

            // Row 69: Late Fee - Central Tax
            if (data.LateFee_CGST > 0)
            {
                sheet.Cell(69, 2).Value = "Central Tax";
                sheet.Cell(69, 3).Value = (double)data.LateFee_CGST;
            }

            // Row 70: Late Fee - State/UT Tax
            if (data.LateFee_SGST > 0)
            {
                sheet.Cell(70, 2).Value = "State/UT Tax";
                sheet.Cell(70, 3).Value = (double)data.LateFee_SGST;
            }
        }

        #endregion

        #region 6. Payment of Tax

        private void Fill6PaymentOfTax(IXLWorksheet sheet, Gstr3BData data)
        {
            // Row 74: Integrated Tax
            // Tax payable is in formula (column 3)
            // Paid through ITC columns (columns 4-7)
            sheet.Cell(74, 4).Value = (double)data.Tax_IGST_PaidThrough_IGST;
            sheet.Cell(74, 5).Value = (double)data.Tax_IGST_PaidThrough_CGST;
            sheet.Cell(74, 6).Value = (double)data.Tax_IGST_PaidThrough_SGST;
            sheet.Cell(74, 7).Value = (double)data.Tax_IGST_PaidThrough_Cess;
            sheet.Cell(74, 8).Value = (double)data.Tax_IGST_PaidInCash;

            // Row 75: Central Tax
            sheet.Cell(75, 4).Value = (double)data.Tax_CGST_PaidThrough_IGST;
            sheet.Cell(75, 5).Value = (double)data.Tax_CGST_PaidThrough_CGST;
            sheet.Cell(75, 6).Value = (double)data.Tax_CGST_PaidThrough_SGST;
            sheet.Cell(75, 7).Value = (double)data.Tax_CGST_PaidThrough_Cess;
            sheet.Cell(75, 8).Value = (double)data.Tax_CGST_PaidInCash;

            // Row 76: State/UT Tax
            sheet.Cell(76, 4).Value = (double)data.Tax_SGST_PaidThrough_IGST;
            sheet.Cell(76, 5).Value = (double)data.Tax_SGST_PaidThrough_CGST;
            sheet.Cell(76, 6).Value = (double)data.Tax_SGST_PaidThrough_SGST;
            sheet.Cell(76, 7).Value = (double)data.Tax_SGST_PaidThrough_Cess;
            sheet.Cell(76, 8).Value = (double)data.Tax_SGST_PaidInCash;

            // Row 77: Cess
            sheet.Cell(77, 4).Value = (double)data.Tax_Cess_PaidThrough_IGST;
            sheet.Cell(77, 5).Value = (double)data.Tax_Cess_PaidThrough_CGST;
            sheet.Cell(77, 6).Value = (double)data.Tax_Cess_PaidThrough_SGST;
            sheet.Cell(77, 7).Value = (double)data.Tax_Cess_PaidThrough_Cess;
            sheet.Cell(77, 8).Value = (double)data.Tax_Cess_PaidInCash;
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Calculate GSTR-3B data from GSTR-1 and GSTR-2 data
        /// </summary>
        public Gstr3BData CalculateFromGSTR1And2(
            List<Bill> gstr1Sales,
            List<Bill> gstr2Purchases)
        {
            var data = new Gstr3BData();

            // Calculate from GSTR-1 (Sales/Outward Supplies)
            var normalSales = gstr1Sales.Where(b =>
                !string.IsNullOrWhiteSpace(b.BillGstNo) &&
                b.BillGstNo.Length == 15 &&
                b.Vouchname?.Contains("CREDIT NOTE") != true &&
                b.Vouchname?.Contains("DEBIT NOTE") != true).ToList();

            data.OutwardTaxableSupplies_TaxableValue = (decimal)normalSales.Sum(b => b.BillTotal);
            data.OutwardTaxableSupplies_IGST = (decimal)normalSales.Sum(b => b.BillIgst);
            data.OutwardTaxableSupplies_CGST = (decimal)normalSales.Sum(b => b.BillCgst);
            data.OutwardTaxableSupplies_SGST = (decimal)normalSales.Sum(b => b.BillSgst);

            // Calculate from GSTR-2 (Purchases/Inward Supplies)
            var normalPurchases = gstr2Purchases.Where(b =>
                !string.IsNullOrWhiteSpace(b.BillGstNo) &&
                b.BillGstNo.Length == 15 &&
                b.Vouchname?.Contains("CREDIT NOTE") != true &&
                b.Vouchname?.Contains("DEBIT NOTE") != true).ToList();

            // ITC from all other purchases
            data.ITC_Others_IGST = (decimal)normalPurchases.Sum(b => b.BillIgst);
            data.ITC_Others_CGST = (decimal)normalPurchases.Sum(b => b.BillCgst);
            data.ITC_Others_SGST = (decimal)normalPurchases.Sum(b => b.BillSgst);

            // Import of goods
            var importGoods = gstr2Purchases.Where(b =>
                b.Vouchname?.ToUpper().Contains("IMPORT") == true &&
                b.Vouchname?.ToUpper().Contains("GOODS") == true).ToList();

            data.ITC_ImportGoods_IGST = (decimal)importGoods.Sum(b => b.BillIgst);

            // Import of services
            var importServices = gstr2Purchases.Where(b =>
                b.Vouchname?.ToUpper().Contains("IMPORT") == true &&
                b.Vouchname?.ToUpper().Contains("SERVICE") == true).ToList();

            data.ITC_ImportServices_IGST = (decimal)importServices.Sum(b => b.BillIgst);

            // Reverse charge purchases
            var reverseChargePurchases = gstr2Purchases.Where(b =>
                (string.IsNullOrWhiteSpace(b.BillGstNo) || b.BillGstNo.Length != 15) &&
                b.Vouchname?.ToUpper().Contains("IMPORT") != true).ToList();

            data.InwardReverseCharge_TaxableValue = (decimal)reverseChargePurchases.Sum(b => b.BillTotal);
            data.InwardReverseCharge_IGST = (decimal)reverseChargePurchases.Sum(b => b.BillIgst);
            data.InwardReverseCharge_CGST = (decimal)reverseChargePurchases.Sum(b => b.BillCgst);
            data.InwardReverseCharge_SGST = (decimal)reverseChargePurchases.Sum(b => b.BillSgst);

            data.ITC_ReverseCharge_IGST = data.InwardReverseCharge_IGST;
            data.ITC_ReverseCharge_CGST = data.InwardReverseCharge_CGST;
            data.ITC_ReverseCharge_SGST = data.InwardReverseCharge_SGST;

            return data;
        }

        #endregion

        #region Data Models

        public class Gstr3BData
        {
            // 3.1 Outward Supplies
            public decimal OutwardTaxableSupplies_TaxableValue { get; set; }
            public decimal OutwardTaxableSupplies_IGST { get; set; }
            public decimal OutwardTaxableSupplies_CGST { get; set; }
            public decimal OutwardTaxableSupplies_SGST { get; set; }
            public decimal OutwardTaxableSupplies_Cess { get; set; }

            public decimal OutwardZeroRated_TaxableValue { get; set; }
            public decimal OutwardZeroRated_IGST { get; set; }
            public decimal OutwardZeroRated_CGST { get; set; }
            public decimal OutwardZeroRated_SGST { get; set; }
            public decimal OutwardZeroRated_Cess { get; set; }

            public decimal OutwardNilRated_TaxableValue { get; set; }

            public decimal InwardReverseCharge_TaxableValue { get; set; }
            public decimal InwardReverseCharge_IGST { get; set; }
            public decimal InwardReverseCharge_CGST { get; set; }
            public decimal InwardReverseCharge_SGST { get; set; }
            public decimal InwardReverseCharge_Cess { get; set; }

            public decimal NonGSTOutward_TaxableValue { get; set; }

            // 3.1.1 Section 9(5) Supplies
            public decimal Section95_ISD_TaxableValue { get; set; }
            public decimal Section95_ISD_IGST { get; set; }
            public decimal Section95_ISD_CGST { get; set; }
            public decimal Section95_ISD_SGST { get; set; }
            public decimal Section95_ISD_Cess { get; set; }

            public decimal Section95_DeemedSupplier_TaxableValue { get; set; }
            public decimal Section95_DeemedSupplier_IGST { get; set; }
            public decimal Section95_DeemedSupplier_CGST { get; set; }
            public decimal Section95_DeemedSupplier_SGST { get; set; }
            public decimal Section95_DeemedSupplier_Cess { get; set; }

            // 3.2 Inter-State Supplies
            public List<InterStateSupply> InterStateSupplies { get; set; } = new();

            // 4. Eligible ITC
            public decimal ITC_ImportGoods_IGST { get; set; }
            public decimal ITC_ImportGoods_CGST { get; set; }
            public decimal ITC_ImportGoods_SGST { get; set; }
            public decimal ITC_ImportGoods_Cess { get; set; }

            public decimal ITC_ImportServices_IGST { get; set; }
            public decimal ITC_ImportServices_CGST { get; set; }
            public decimal ITC_ImportServices_SGST { get; set; }
            public decimal ITC_ImportServices_Cess { get; set; }

            public decimal ITC_ReverseCharge_IGST { get; set; }
            public decimal ITC_ReverseCharge_CGST { get; set; }
            public decimal ITC_ReverseCharge_SGST { get; set; }
            public decimal ITC_ReverseCharge_Cess { get; set; }

            public decimal ITC_ISD_IGST { get; set; }
            public decimal ITC_ISD_CGST { get; set; }
            public decimal ITC_ISD_SGST { get; set; }
            public decimal ITC_ISD_Cess { get; set; }

            public decimal ITC_Others_IGST { get; set; }
            public decimal ITC_Others_CGST { get; set; }
            public decimal ITC_Others_SGST { get; set; }
            public decimal ITC_Others_Cess { get; set; }

            // ITC Reversed
            public decimal ITC_Reversed_Rule42_43_IGST { get; set; }
            public decimal ITC_Reversed_Rule42_43_CGST { get; set; }
            public decimal ITC_Reversed_Rule42_43_SGST { get; set; }
            public decimal ITC_Reversed_Rule42_43_Cess { get; set; }

            public decimal ITC_Reversed_Others_IGST { get; set; }
            public decimal ITC_Reversed_Others_CGST { get; set; }
            public decimal ITC_Reversed_Others_SGST { get; set; }
            public decimal ITC_Reversed_Others_Cess { get; set; }

            // 5. Exempt Supplies
            public decimal Exempt_InterState { get; set; }
            public decimal Exempt_IntraState { get; set; }

            // 5.1 Interest and Late Fee
            public decimal Interest_IGST { get; set; }
            public decimal Interest_CGST { get; set; }
            public decimal Interest_SGST { get; set; }

            public decimal LateFee_IGST { get; set; }
            public decimal LateFee_CGST { get; set; }
            public decimal LateFee_SGST { get; set; }

            // 6. Payment of Tax
            public decimal Tax_IGST_PaidThrough_IGST { get; set; }
            public decimal Tax_IGST_PaidThrough_CGST { get; set; }
            public decimal Tax_IGST_PaidThrough_SGST { get; set; }
            public decimal Tax_IGST_PaidThrough_Cess { get; set; }
            public decimal Tax_IGST_PaidInCash { get; set; }

            public decimal Tax_CGST_PaidThrough_IGST { get; set; }
            public decimal Tax_CGST_PaidThrough_CGST { get; set; }
            public decimal Tax_CGST_PaidThrough_SGST { get; set; }
            public decimal Tax_CGST_PaidThrough_Cess { get; set; }
            public decimal Tax_CGST_PaidInCash { get; set; }

            public decimal Tax_SGST_PaidThrough_IGST { get; set; }
            public decimal Tax_SGST_PaidThrough_CGST { get; set; }
            public decimal Tax_SGST_PaidThrough_SGST { get; set; }
            public decimal Tax_SGST_PaidThrough_Cess { get; set; }
            public decimal Tax_SGST_PaidInCash { get; set; }

            public decimal Tax_Cess_PaidThrough_IGST { get; set; }
            public decimal Tax_Cess_PaidThrough_CGST { get; set; }
            public decimal Tax_Cess_PaidThrough_SGST { get; set; }
            public decimal Tax_Cess_PaidThrough_Cess { get; set; }
            public decimal Tax_Cess_PaidInCash { get; set; }
        }

        public class InterStateSupply
        {
            public string PlaceOfSupply { get; set; }
            public decimal TaxableValue { get; set; }
            public decimal IntegratedTax { get; set; }
        }

        #endregion
    }
}