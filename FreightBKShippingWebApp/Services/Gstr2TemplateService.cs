using ClosedXML.Excel;
using FreightBKShippingWebApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FreightBKShippingWebApp.Services
{
    /// <summary>
    /// GSTR-2 Excel service that uses government template and fills purchase data
    /// Includes HSN summary for inward supplies
    /// </summary>
    public class Gstr2TemplateService
    {
        private const int HEADER_ROW = 4;
        private const int DATA_START_ROW = 5;

        /// <summary>
        /// Generate GSTR-2 using government template file
        /// </summary>
        public byte[] GenerateFromTemplate(
            string templatePath,
            List<Bill> b2bPurchases,
            List<Bill> b2burPurchases,
            List<Bill> importsServices,
            List<Bill> importsGoods,
            List<Bill> creditDebitNotes,
            List<Bill> creditDebitNotesUnreg,
            List<ExemptPurchaseSummary> exemptPurchases,
            List<ITCReversalSummary> itcReversals,
            DateTime? fromDate,
            DateTime? toDate)
        {
            // Load the government template
            using var workbook = new XLWorkbook(templatePath);

            // Fill each sheet
            FillB2BSheet(workbook, b2bPurchases);
            FillB2BURSheet(workbook, b2burPurchases);
            FillIMPSSheet(workbook, importsServices);
            FillIMPGSheet(workbook, importsGoods);
            FillCDNRSheet(workbook, creditDebitNotes);
            FillCDNURSheet(workbook, creditDebitNotesUnreg);
            FillExemptSheet(workbook, exemptPurchases);
            FillITCRSheet(workbook, itcReversals);

            // Fill HSN summary combining all purchases
            var allPurchases = new List<Bill>();
            allPurchases.AddRange(b2bPurchases);
            allPurchases.AddRange(b2burPurchases);
            allPurchases.AddRange(importsServices);
            allPurchases.AddRange(importsGoods);
            FillHSNSheet(workbook, allPurchases);

            // Save to memory
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        #region B2B Sheet (Registered Suppliers)

        private void FillB2BSheet(IXLWorkbook workbook, List<Bill> purchases)
        {
            var sheet = workbook.Worksheet("b2b");
            if (sheet == null) return;

            ClearDataRows(sheet, DATA_START_ROW);

            // Update summary title
            var titleCell = sheet.Cell(1, 1);
            titleCell.Value = $"Summary Of Supplies From Registered Suppliers B2B(3) ({purchases?.Count ?? 0})";

            if (purchases != null && purchases.Any())
            {
                int row = DATA_START_ROW;
                foreach (var purchase in purchases)
                {
                    // GSTIN of Supplier
                    sheet.Cell(row, 1).Value = purchase.BillGstNo ?? "";

                    // Invoice Number
                    sheet.Cell(row, 2).Value = purchase.BillNo ?? "";

                    // Invoice date
                    sheet.Cell(row, 3).Value = purchase.BillDate;
                    sheet.Cell(row, 3).Style.DateFormat.Format = "yyyy-MM-dd hh:mm:ss";

                    // Invoice Value
                    sheet.Cell(row, 4).Value = (double)purchase.BillNetAmount;
                    sheet.Cell(row, 4).Style.NumberFormat.Format = "#,##0.00";

                    // Place Of Supply
                    sheet.Cell(row, 5).Value = purchase.posname ?? "";

                    // Reverse Charge
                    sheet.Cell(row, 6).Value = "N";

                    // Invoice Type
                    sheet.Cell(row, 7).Value = "Regular";

                    // Rate
                    double taxRate = DetermineTaxRate(purchase);
                    sheet.Cell(row, 8).Value = taxRate;
                    sheet.Cell(row, 8).Style.NumberFormat.Format = "0.00";

                    // Taxable Value
                    sheet.Cell(row, 9).Value = (double)purchase.BillTotal;
                    sheet.Cell(row, 9).Style.NumberFormat.Format = "#,##0.00";

                    // Integrated Tax Paid
                    sheet.Cell(row, 10).Value = (double)purchase.BillIgst;
                    sheet.Cell(row, 10).Style.NumberFormat.Format = "#,##0.00";

                    // Central Tax Paid
                    sheet.Cell(row, 11).Value = (double)purchase.BillCgst;
                    sheet.Cell(row, 11).Style.NumberFormat.Format = "#,##0.00";

                    // State/UT Tax Paid
                    sheet.Cell(row, 12).Value = (double)purchase.BillSgst;
                    sheet.Cell(row, 12).Style.NumberFormat.Format = "#,##0.00";

                    // Cess Paid
                    sheet.Cell(row, 13).Value = 0;
                    sheet.Cell(row, 13).Style.NumberFormat.Format = "0.00";

                    // Eligibility For ITC
                    sheet.Cell(row, 14).Value = "Inputs";

                    // Availed ITC Integrated Tax
                    sheet.Cell(row, 15).Value = (double)purchase.BillIgst;
                    sheet.Cell(row, 15).Style.NumberFormat.Format = "#,##0.00";

                    // Availed ITC Central Tax
                    sheet.Cell(row, 16).Value = (double)purchase.BillCgst;
                    sheet.Cell(row, 16).Style.NumberFormat.Format = "#,##0.00";

                    // Availed ITC State/UT Tax
                    sheet.Cell(row, 17).Value = (double)purchase.BillSgst;
                    sheet.Cell(row, 17).Style.NumberFormat.Format = "#,##0.00";

                    // Availed ITC Cess
                    sheet.Cell(row, 18).Value = 0;
                    sheet.Cell(row, 18).Style.NumberFormat.Format = "0.00";

                    ApplyBordersToRow(sheet, row, 18);
                    row++;
                }
            }
        }

        #endregion

        #region B2BUR Sheet (Unregistered Suppliers)

        private void FillB2BURSheet(IXLWorkbook workbook, List<Bill> purchases)
        {
            var sheet = workbook.Worksheet("b2bur");
            if (sheet == null) return;

            ClearDataRows(sheet, DATA_START_ROW);

            var titleCell = sheet.Cell(1, 1);
            titleCell.Value = $"Summary Of Supplies From Unregistered Suppliers B2BUR(4B) ({purchases?.Count ?? 0})";

            if (purchases != null && purchases.Any())
            {
                int row = DATA_START_ROW;
                foreach (var purchase in purchases)
                {
                    // Supplier Name
                    sheet.Cell(row, 1).Value = purchase.partyname ?? "";

                    // Invoice Number
                    sheet.Cell(row, 2).Value = purchase.BillNo ?? "";

                    // Invoice date
                    sheet.Cell(row, 3).Value = purchase.BillDate;
                    sheet.Cell(row, 3).Style.DateFormat.Format = "yyyy-MM-dd hh:mm:ss";

                    // Invoice Value
                    sheet.Cell(row, 4).Value = (double)purchase.BillNetAmount;
                    sheet.Cell(row, 4).Style.NumberFormat.Format = "#,##0.00";

                    // Place Of Supply
                    sheet.Cell(row, 5).Value = purchase.posname ?? "";

                    // Supply Type
                    sheet.Cell(row, 6).Value = DetermineSupplyType(purchase);

                    // Rate
                    double taxRate = DetermineTaxRate(purchase);
                    sheet.Cell(row, 7).Value = taxRate;
                    sheet.Cell(row, 7).Style.NumberFormat.Format = "0.00";

                    // Taxable Value
                    sheet.Cell(row, 8).Value = (double)purchase.BillTotal;
                    sheet.Cell(row, 8).Style.NumberFormat.Format = "#,##0.00";

                    // Integrated Tax Paid
                    sheet.Cell(row, 9).Value = (double)purchase.BillIgst;
                    sheet.Cell(row, 9).Style.NumberFormat.Format = "#,##0.00";

                    // Central Tax Paid
                    sheet.Cell(row, 10).Value = (double)purchase.BillCgst;
                    sheet.Cell(row, 10).Style.NumberFormat.Format = "#,##0.00";

                    // State/UT Tax Paid
                    sheet.Cell(row, 11).Value = (double)purchase.BillSgst;
                    sheet.Cell(row, 11).Style.NumberFormat.Format = "#,##0.00";

                    // Cess Paid
                    sheet.Cell(row, 12).Value = 0;
                    sheet.Cell(row, 12).Style.NumberFormat.Format = "0.00";

                    // Eligibility For ITC
                    sheet.Cell(row, 13).Value = "Inputs";

                    // Availed ITC Integrated Tax
                    sheet.Cell(row, 14).Value = (double)purchase.BillIgst;
                    sheet.Cell(row, 14).Style.NumberFormat.Format = "#,##0.00";

                    // Availed ITC Central Tax
                    sheet.Cell(row, 15).Value = (double)purchase.BillCgst;
                    sheet.Cell(row, 15).Style.NumberFormat.Format = "#,##0.00";

                    // Availed ITC State/UT Tax
                    sheet.Cell(row, 16).Value = (double)purchase.BillSgst;
                    sheet.Cell(row, 16).Style.NumberFormat.Format = "#,##0.00";

                    // Availed ITC Cess
                    sheet.Cell(row, 17).Value = 0;
                    sheet.Cell(row, 17).Style.NumberFormat.Format = "0.00";

                    ApplyBordersToRow(sheet, row, 17);
                    row++;
                }
            }
        }

        #endregion

        #region IMPS Sheet (Import of Services)

        private void FillIMPSSheet(IXLWorkbook workbook, List<Bill> imports)
        {
            var sheet = workbook.Worksheet("imps");
            if (sheet == null) return;

            ClearDataRows(sheet, DATA_START_ROW);

            var titleCell = sheet.Cell(1, 1);
            titleCell.Value = $"Summary For IMPS (4C) ({imports?.Count ?? 0})";

            if (imports != null && imports.Any())
            {
                int row = DATA_START_ROW;
                foreach (var import in imports)
                {
                    // Invoice Number of Reg Recipient
                    sheet.Cell(row, 1).Value = import.BillNo ?? "";

                    // Invoice Date
                    sheet.Cell(row, 2).Value = import.BillDate;
                    sheet.Cell(row, 2).Style.DateFormat.Format = "yyyy-MM-dd hh:mm:ss";

                    // Invoice Value
                    sheet.Cell(row, 3).Value = (double)import.BillNetAmount;
                    sheet.Cell(row, 3).Style.NumberFormat.Format = "#,##0.00";

                    // Place Of Supply
                    sheet.Cell(row, 4).Value = import.posname ?? "";

                    // Rate
                    double taxRate = DetermineTaxRate(import);
                    sheet.Cell(row, 5).Value = taxRate;
                    sheet.Cell(row, 5).Style.NumberFormat.Format = "0.00";

                    // Taxable Value
                    sheet.Cell(row, 6).Value = (double)import.BillTotal;
                    sheet.Cell(row, 6).Style.NumberFormat.Format = "#,##0.00";

                    // Integrated Tax Paid
                    sheet.Cell(row, 7).Value = (double)import.BillIgst;
                    sheet.Cell(row, 7).Style.NumberFormat.Format = "#,##0.00";

                    // Cess Paid
                    sheet.Cell(row, 8).Value = 0;
                    sheet.Cell(row, 8).Style.NumberFormat.Format = "0.00";

                    // Eligibility For ITC
                    sheet.Cell(row, 9).Value = "Input services";

                    // Availed ITC Integrated Tax
                    sheet.Cell(row, 10).Value = (double)import.BillIgst;
                    sheet.Cell(row, 10).Style.NumberFormat.Format = "#,##0.00";

                    // Availed ITC Cess
                    sheet.Cell(row, 11).Value = 0;
                    sheet.Cell(row, 11).Style.NumberFormat.Format = "0.00";

                    ApplyBordersToRow(sheet, row, 11);
                    row++;
                }
            }
        }

        #endregion

        #region IMPG Sheet (Import of Goods)

        private void FillIMPGSheet(IXLWorkbook workbook, List<Bill> imports)
        {
            var sheet = workbook.Worksheet("impg");
            if (sheet == null) return;

            ClearDataRows(sheet, DATA_START_ROW);

            var titleCell = sheet.Cell(1, 1);
            titleCell.Value = $"Summary For IMPG (5) ({imports?.Count ?? 0})";

            if (imports != null && imports.Any())
            {
                int row = DATA_START_ROW;
                foreach (var import in imports)
                {
                    // Port Code
                    sheet.Cell(row, 1).Value = "";

                    // Bill Of Entry Number
                    sheet.Cell(row, 2).Value = import.BillNo ?? "";

                    // Bill Of Entry Date
                    sheet.Cell(row, 3).Value = import.BillDate;
                    sheet.Cell(row, 3).Style.DateFormat.Format = "yyyy-MM-dd hh:mm:ss";

                    // Bill Of Entry Value
                    sheet.Cell(row, 4).Value = (double)import.BillNetAmount;
                    sheet.Cell(row, 4).Style.NumberFormat.Format = "#,##0.00";

                    // Document type
                    sheet.Cell(row, 5).Value = "Imports";

                    // GSTIN Of SEZ Supplier
                    sheet.Cell(row, 6).Value = "";

                    // Rate
                    double taxRate = DetermineTaxRate(import);
                    sheet.Cell(row, 7).Value = taxRate;
                    sheet.Cell(row, 7).Style.NumberFormat.Format = "0.00";

                    // Taxable Value
                    sheet.Cell(row, 8).Value = (double)import.BillTotal;
                    sheet.Cell(row, 8).Style.NumberFormat.Format = "#,##0.00";

                    // Integrated Tax Paid
                    sheet.Cell(row, 9).Value = (double)import.BillIgst;
                    sheet.Cell(row, 9).Style.NumberFormat.Format = "#,##0.00";

                    // Cess Paid
                    sheet.Cell(row, 10).Value = 0;
                    sheet.Cell(row, 10).Style.NumberFormat.Format = "0.00";

                    // Eligibility For ITC
                    sheet.Cell(row, 11).Value = "Inputs";

                    // Availed ITC Integrated Tax
                    sheet.Cell(row, 12).Value = (double)import.BillIgst;
                    sheet.Cell(row, 12).Style.NumberFormat.Format = "#,##0.00";

                    // Availed ITC Cess
                    sheet.Cell(row, 13).Value = 0;
                    sheet.Cell(row, 13).Style.NumberFormat.Format = "0.00";

                    ApplyBordersToRow(sheet, row, 13);
                    row++;
                }
            }
        }

        #endregion

        #region CDNR Sheet (Credit/Debit Notes - Registered)

        private void FillCDNRSheet(IXLWorkbook workbook, List<Bill> notes)
        {
            var sheet = workbook.Worksheet("cdnr");
            if (sheet == null) return;

            ClearDataRows(sheet, DATA_START_ROW);

            var titleCell = sheet.Cell(1, 1);
            titleCell.Value = $"Summary For CDNR(6C) ({notes?.Count ?? 0})";

            if (notes != null && notes.Any())
            {
                int row = DATA_START_ROW;
                foreach (var note in notes)
                {
                    string noteType = note.Vouchname?.ToUpper().Contains("CREDIT") == true ? "C" : "D";

                    // GSTIN of Supplier
                    sheet.Cell(row, 1).Value = note.BillGstNo ?? "";

                    // Note/Refund Voucher Number
                    sheet.Cell(row, 2).Value = note.BillNo ?? "";

                    // Note/Refund Voucher date
                    sheet.Cell(row, 3).Value = note.BillDate;
                    sheet.Cell(row, 3).Style.DateFormat.Format = "yyyy-MM-dd hh:mm:ss";

                    // Invoice/Advance Payment Voucher Number
                    sheet.Cell(row, 4).Value = "";

                    // Invoice/Advance Payment Voucher date
                    sheet.Cell(row, 5).Value = "";

                    // Pre GST
                    sheet.Cell(row, 6).Value = "N";

                    // Document Type
                    sheet.Cell(row, 7).Value = noteType;

                    // Reason For Issuing document
                    sheet.Cell(row, 8).Value = "01-Sales Return";

                    // Supply Type
                    sheet.Cell(row, 9).Value = DetermineSupplyType(note);

                    // Note/Refund Voucher Value
                    sheet.Cell(row, 10).Value = (double)note.BillNetAmount;
                    sheet.Cell(row, 10).Style.NumberFormat.Format = "#,##0.00";

                    // Rate
                    double taxRate = DetermineTaxRate(note);
                    sheet.Cell(row, 11).Value = taxRate;
                    sheet.Cell(row, 11).Style.NumberFormat.Format = "0.00";

                    // Taxable Value
                    sheet.Cell(row, 12).Value = (double)note.BillTotal;
                    sheet.Cell(row, 12).Style.NumberFormat.Format = "#,##0.00";

                    // Integrated Tax Paid
                    sheet.Cell(row, 13).Value = (double)note.BillIgst;
                    sheet.Cell(row, 13).Style.NumberFormat.Format = "#,##0.00";

                    // Central Tax Paid
                    sheet.Cell(row, 14).Value = (double)note.BillCgst;
                    sheet.Cell(row, 14).Style.NumberFormat.Format = "#,##0.00";

                    // State/UT Tax Paid
                    sheet.Cell(row, 15).Value = (double)note.BillSgst;
                    sheet.Cell(row, 15).Style.NumberFormat.Format = "#,##0.00";

                    // Cess Paid
                    sheet.Cell(row, 16).Value = 0;
                    sheet.Cell(row, 16).Style.NumberFormat.Format = "0.00";

                    // Eligibility For ITC
                    sheet.Cell(row, 17).Value = "Inputs";

                    // Availed ITC Integrated Tax
                    sheet.Cell(row, 18).Value = (double)note.BillIgst;
                    sheet.Cell(row, 18).Style.NumberFormat.Format = "#,##0.00";

                    // Availed ITC Central Tax
                    sheet.Cell(row, 19).Value = (double)note.BillCgst;
                    sheet.Cell(row, 19).Style.NumberFormat.Format = "#,##0.00";

                    ApplyBordersToRow(sheet, row, 19);
                    row++;
                }
            }
        }

        #endregion

        #region CDNUR Sheet (Credit/Debit Notes - Unregistered)

        private void FillCDNURSheet(IXLWorkbook workbook, List<Bill> notes)
        {
            var sheet = workbook.Worksheet("cdnur");
            if (sheet == null) return;

            ClearDataRows(sheet, DATA_START_ROW);

            var titleCell = sheet.Cell(1, 1);
            titleCell.Value = $"Summary For CDNUR(6C) ({notes?.Count ?? 0})";

            if (notes != null && notes.Any())
            {
                int row = DATA_START_ROW;
                foreach (var note in notes)
                {
                    string noteType = note.Vouchname?.ToUpper().Contains("CREDIT") == true ? "C" : "D";

                    // Note/Voucher Number
                    sheet.Cell(row, 1).Value = note.BillNo ?? "";

                    // Note/Voucher date
                    sheet.Cell(row, 2).Value = note.BillDate;
                    sheet.Cell(row, 2).Style.DateFormat.Format = "yyyy-MM-dd hh:mm:ss";

                    // Invoice/Advance Payment Voucher number
                    sheet.Cell(row, 3).Value = "";

                    // Invoice/Advance Payment Voucher date
                    sheet.Cell(row, 4).Value = "";

                    // Pre GST
                    sheet.Cell(row, 5).Value = "N";

                    // Document Type
                    sheet.Cell(row, 6).Value = noteType;

                    // Reason For Issuing document
                    sheet.Cell(row, 7).Value = "01-Sales Return";

                    // Supply Type
                    sheet.Cell(row, 8).Value = DetermineSupplyType(note);

                    // Invoice Type
                    sheet.Cell(row, 9).Value = "B2BUR";

                    // Note/Voucher Value
                    sheet.Cell(row, 10).Value = (double)note.BillNetAmount;
                    sheet.Cell(row, 10).Style.NumberFormat.Format = "#,##0.00";

                    // Rate
                    double taxRate = DetermineTaxRate(note);
                    sheet.Cell(row, 11).Value = taxRate;
                    sheet.Cell(row, 11).Style.NumberFormat.Format = "0.00";

                    // Taxable Value
                    sheet.Cell(row, 12).Value = (double)note.BillTotal;
                    sheet.Cell(row, 12).Style.NumberFormat.Format = "#,##0.00";

                    // Integrated Tax Paid
                    sheet.Cell(row, 13).Value = (double)note.BillIgst;
                    sheet.Cell(row, 13).Style.NumberFormat.Format = "#,##0.00";

                    // Central Tax Paid
                    sheet.Cell(row, 14).Value = (double)note.BillCgst;
                    sheet.Cell(row, 14).Style.NumberFormat.Format = "#,##0.00";

                    // State/UT Tax Paid
                    sheet.Cell(row, 15).Value = (double)note.BillSgst;
                    sheet.Cell(row, 15).Style.NumberFormat.Format = "#,##0.00";

                    // Cess Paid
                    sheet.Cell(row, 16).Value = 0;
                    sheet.Cell(row, 16).Style.NumberFormat.Format = "0.00";

                    // Eligibility For ITC
                    sheet.Cell(row, 17).Value = "Inputs";

                    // Availed ITC Integrated Tax
                    sheet.Cell(row, 18).Value = (double)note.BillIgst;
                    sheet.Cell(row, 18).Style.NumberFormat.Format = "#,##0.00";

                    // Availed ITC Central Tax
                    sheet.Cell(row, 19).Value = (double)note.BillCgst;
                    sheet.Cell(row, 19).Style.NumberFormat.Format = "#,##0.00";

                    ApplyBordersToRow(sheet, row, 19);
                    row++;
                }
            }
        }

        #endregion

        #region Exempt Sheet

        private void FillExemptSheet(IXLWorkbook workbook, List<ExemptPurchaseSummary> exemptData)
        {
            var sheet = workbook.Worksheet("exemp");
            if (sheet == null) return;

            if (exemptData != null && exemptData.Any())
            {
                int row = 5; // Data starts at row 5 for exempt sheet
                foreach (var item in exemptData)
                {
                    // Description
                    sheet.Cell(row, 1).Value = item.Description ?? "";

                    // Composition taxable person
                    sheet.Cell(row, 2).Value = (double)item.CompositionValue;
                    sheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00";

                    // Nil Rated Supplies
                    sheet.Cell(row, 3).Value = (double)item.NilRatedValue;
                    sheet.Cell(row, 3).Style.NumberFormat.Format = "#,##0.00";

                    // Exempted (other than nil rated/non GST supply)
                    sheet.Cell(row, 4).Value = (double)item.ExemptedValue;
                    sheet.Cell(row, 4).Style.NumberFormat.Format = "#,##0.00";

                    // Non-GST supplies
                    sheet.Cell(row, 5).Value = (double)item.NonGSTValue;
                    sheet.Cell(row, 5).Style.NumberFormat.Format = "#,##0.00";

                    ApplyBordersToRow(sheet, row, 5);
                    row++;
                }
            }
        }

        #endregion

        #region ITCR Sheet (ITC Reversal/Reclaim)

        private void FillITCRSheet(IXLWorkbook workbook, List<ITCReversalSummary> itcData)
        {
            var sheet = workbook.Worksheet("itcr");
            if (sheet == null) return;

            if (itcData != null && itcData.Any())
            {
                int row = 5; // Data starts at row 5
                foreach (var item in itcData)
                {
                    // Description for reversal of ITC
                    sheet.Cell(row, 1).Value = item.Description ?? "";

                    // To be added or reduced from output liability
                    sheet.Cell(row, 2).Value = item.AddOrReduce ?? "To be added";

                    // ITC Integrated Tax Amount
                    sheet.Cell(row, 3).Value = (double)item.IGSTAmount;
                    sheet.Cell(row, 3).Style.NumberFormat.Format = "#,##0.00";

                    // ITC Central Tax Amount
                    sheet.Cell(row, 4).Value = (double)item.CGSTAmount;
                    sheet.Cell(row, 4).Style.NumberFormat.Format = "#,##0.00";

                    // ITC State/UT Tax Amount
                    sheet.Cell(row, 5).Value = (double)item.SGSTAmount;
                    sheet.Cell(row, 5).Style.NumberFormat.Format = "#,##0.00";

                    // ITC Cess Amount
                    sheet.Cell(row, 6).Value = (double)item.CessAmount;
                    sheet.Cell(row, 6).Style.NumberFormat.Format = "#,##0.00";

                    ApplyBordersToRow(sheet, row, 6);
                    row++;
                }
            }
        }

        #endregion

        #region HSN Sheet

        private void FillHSNSheet(IXLWorkbook workbook, List<Bill> purchases)
        {
            var sheet = workbook.Worksheet("hsnsum");
            if (sheet == null) return;

            ClearDataRows(sheet, DATA_START_ROW);

            // Calculate HSN summary from BillDetails
            var hsnSummary = CalculateHSNSummaryFromBills(purchases);

            // Update title
            sheet.Cell(1, 1).Value = $"Summary For HSN(13) ({hsnSummary.Count})";

            if (hsnSummary.Any())
            {
                int row = DATA_START_ROW;
                foreach (var hsn in hsnSummary)
                {
                    // HSN
                    sheet.Cell(row, 1).Value = hsn.HSNCode ?? "";

                    // Description
                    sheet.Cell(row, 2).Value = hsn.Description ?? "";

                    // UQC
                    sheet.Cell(row, 3).Value = hsn.UQC ?? "NOS";

                    // Total Quantity
                    sheet.Cell(row, 4).Value = hsn.TotalQuantity;
                    sheet.Cell(row, 4).Style.NumberFormat.Format = "#,##0.00";

                    // Total Value
                    sheet.Cell(row, 5).Value = (double)hsn.TotalValue;
                    sheet.Cell(row, 5).Style.NumberFormat.Format = "#,##0.00";

                    // Taxable Value
                    sheet.Cell(row, 6).Value = (double)hsn.TaxableValue;
                    sheet.Cell(row, 6).Style.NumberFormat.Format = "#,##0.00";

                    // Integrated Tax Amount
                    sheet.Cell(row, 7).Value = (double)hsn.IGSTAmount;
                    sheet.Cell(row, 7).Style.NumberFormat.Format = "#,##0.00";

                    // Central Tax Amount
                    sheet.Cell(row, 8).Value = (double)hsn.CGSTAmount;
                    sheet.Cell(row, 8).Style.NumberFormat.Format = "#,##0.00";

                    // State/UT Tax Amount
                    sheet.Cell(row, 9).Value = (double)hsn.SGSTAmount;
                    sheet.Cell(row, 9).Style.NumberFormat.Format = "#,##0.00";

                    // Cess Amount
                    sheet.Cell(row, 10).Value = 0;
                    sheet.Cell(row, 10).Style.NumberFormat.Format = "0.00";

                    ApplyBordersToRow(sheet, row, 10);
                    row++;
                }
            }
        }

        private List<HSNSummary> CalculateHSNSummaryFromBills(List<Bill> bills)
        {
            if (bills == null || !bills.Any())
                return new List<HSNSummary>();

            var allDetails = new List<BillDetailWithParent>();

            foreach (var bill in bills)
            {
                if (bill.BillDetails != null && bill.BillDetails.Any())
                {
                    foreach (var detail in bill.BillDetails)
                    {
                        allDetails.Add(new BillDetailWithParent
                        {
                            Detail = detail,
                            ParentBill = bill
                        });
                    }
                }
                else
                {
                    allDetails.Add(new BillDetailWithParent
                    {
                        Detail = null,
                        ParentBill = bill
                    });
                }
            }

            var summary = allDetails
                .GroupBy(item => new
                {
                    HSN = GetHSNCodeFromDetail(item),
                    Description = GetDescriptionFromDetail(item),
                    UQC = GetUQCFromDetail(item)
                })
                .Select(g => new HSNSummary
                {
                    HSNCode = g.Key.HSN,
                    Description = g.Key.Description,
                    UQC = g.Key.UQC,
                    TotalQuantity = g.Sum(item => GetQuantityFromDetail(item)),
                    TotalValue = g.Sum(item => GetValueFromDetail(item)),
                    TaxableValue = g.Sum(item => GetTaxableValueFromDetail(item)),
                    IGSTAmount = g.Sum(item => GetIGSTFromDetail(item)),
                    CGSTAmount = g.Sum(item => GetCGSTFromDetail(item)),
                    SGSTAmount = g.Sum(item => GetSGSTFromDetail(item))
                })
                .OrderBy(h => h.HSNCode)
                .ToList();

            return summary;
        }

        private class BillDetailWithParent
        {
            public BillDetail Detail { get; set; }
            public Bill ParentBill { get; set; }
        }

        private string GetHSNCodeFromDetail(BillDetailWithParent item)
        {
            if (item.Detail != null && !string.IsNullOrWhiteSpace(item.Detail.BillDetailHsnCode))
                return item.Detail.BillDetailHsnCode;
            return "9997";
        }

        private string GetDescriptionFromDetail(BillDetailWithParent item)
        {
            if (item.Detail != null && !string.IsNullOrWhiteSpace(item.Detail.BillDetailRemarks))
                return item.Detail.BillDetailRemarks;
            return "Freight and Transport Services";
        }

        private string GetUQCFromDetail(BillDetailWithParent item)
        {
            if (item.Detail != null && !string.IsNullOrWhiteSpace(item.Detail.BillDetailUnit))
                return item.Detail.BillDetailUnit;
            return "NOS";
        }

        private double GetQuantityFromDetail(BillDetailWithParent item)
        {
            if (item.Detail != null && item.Detail.BillDetailQty > 0)
                return item.Detail.BillDetailQty;
            return 1;
        }

        private double GetValueFromDetail(BillDetailWithParent item)
        {
            if (item.Detail != null)
                return item.Detail.BillDetailAmount;
            return (double)item.ParentBill.BillNetAmount;
        }

        private double GetTaxableValueFromDetail(BillDetailWithParent item)
        {
            if (item.Detail != null)
                return item.Detail.BillDetailAmount;
            return (double)item.ParentBill.BillTotal;
        }

        private double GetIGSTFromDetail(BillDetailWithParent item)
        {
            if (item.Detail != null)
                return item.Detail.BillDetailIgst;
            return (double)item.ParentBill.BillIgst;
        }

        private double GetCGSTFromDetail(BillDetailWithParent item)
        {
            if (item.Detail != null)
                return item.Detail.BillDetailCgst;
            return (double)item.ParentBill.BillCgst;
        }

        private double GetSGSTFromDetail(BillDetailWithParent item)
        {
            if (item.Detail != null)
                return item.Detail.BillDetailSgst;
            return (double)item.ParentBill.BillSgst;
        }

        #endregion

        #region Helper Methods

        private void ClearDataRows(IXLWorksheet sheet, int startRow)
        {
            int maxRow = sheet.LastRowUsed()?.RowNumber() ?? startRow;
            if (maxRow >= startRow)
            {
                sheet.Rows(startRow, maxRow).Delete();
            }
        }

        private void ApplyBordersToRow(IXLWorksheet sheet, int row, int columnCount)
        {
            var range = sheet.Range(row, 1, row, columnCount);
            range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            range.Style.Border.OutsideBorderColor = XLColor.Black;
        }

        private double DetermineTaxRate(Bill bill)
        {
            if (bill.BillTotal == 0) return 0;

            if (bill.BillIgst > 0)
            {
                return Math.Round((double)(bill.BillIgst / bill.BillTotal * 100), 2);
            }

            if (bill.BillCgst > 0 || bill.BillSgst > 0)
            {
                double totalGst = (double)(bill.BillCgst + bill.BillSgst);
                return Math.Round(totalGst / (double)bill.BillTotal * 100, 2);
            }

            return 0;
        }

        private string DetermineSupplyType(Bill bill)
        {
            // Determine if Inter State or Intra State based on IGST
            return bill.BillIgst > 0 ? "Inter State" : "Intra State";
        }

        #endregion

        #region Data Models

        public class ExemptPurchaseSummary
        {
            public string Description { get; set; }
            public decimal CompositionValue { get; set; }
            public decimal NilRatedValue { get; set; }
            public decimal ExemptedValue { get; set; }
            public decimal NonGSTValue { get; set; }
        }

        public class ITCReversalSummary
        {
            public string Description { get; set; }
            public string AddOrReduce { get; set; } // "To be added" or "To be reduced"
            public decimal IGSTAmount { get; set; }
            public decimal CGSTAmount { get; set; }
            public decimal SGSTAmount { get; set; }
            public decimal CessAmount { get; set; }
        }

        public class HSNSummary
        {
            public string HSNCode { get; set; }
            public string Description { get; set; }
            public string UQC { get; set; }
            public double TotalQuantity { get; set; }
            public double TotalValue { get; set; }
            public double TaxableValue { get; set; }
            public double IGSTAmount { get; set; }
            public double CGSTAmount { get; set; }
            public double SGSTAmount { get; set; }
        }

        #endregion
    }
}