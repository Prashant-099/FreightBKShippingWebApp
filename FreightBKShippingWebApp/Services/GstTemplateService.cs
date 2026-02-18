using ClosedXML.Excel;
using FreightBKShippingWebApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FreightBKShippingWebApp.Services
{
    /// <summary>
    /// GSTR-1 Excel service that uses government template and fills data
    /// Includes HSN summary for B2B and B2C invoices
    /// </summary>
    public class GstTemplateService
    {
        private const int HEADER_ROW = 4;
        private const int DATA_START_ROW = 5;

        /// <summary>
        /// Generate GSTR-1 using government template file with HSN summaries
        /// </summary>
        public byte[] GenerateFromTemplate(
            string templatePath,
            List<Bill> b2bInvoices,
            List<Bill> b2cLargeInvoices,
            List<Bill> b2cSmallInvoices,
            List<B2CSmallSummary> b2cSmallSummary,
            List<Bill> creditDebitNotes,
            DateTime? fromDate,
            DateTime? toDate)
        {
            // Load the government template
            using var workbook = new XLWorkbook(templatePath);

            // Fill each sheet
            FillB2BSheet(workbook, b2bInvoices);
            FillB2CLSheet(workbook, b2cLargeInvoices);
            FillB2CSSheet(workbook, b2cSmallSummary);
            FillCDNRSheet(workbook, creditDebitNotes);

            // Fill HSN summaries
            FillHSNB2BSheet(workbook, b2bInvoices);

            // Combine B2C Large and Small for B2C HSN summary
            var allB2CInvoices = b2cLargeInvoices.Concat(b2cSmallInvoices).ToList();
            FillHSNB2CSheet(workbook, allB2CInvoices);

            // Fill Document Summary Sheet
            FillDocsSheet(workbook, b2bInvoices, b2cLargeInvoices, b2cSmallInvoices, creditDebitNotes);


            // Save to memory
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        #region B2B Sheet

        private void FillB2BSheet(IXLWorkbook workbook, List<Bill> invoices)
        {
            var sheet = workbook.Worksheet("b2b,sez,de");
            if (sheet == null) return;

            ClearDataRows(sheet, DATA_START_ROW);

            var titleCell = sheet.Cell(1, 1);
            titleCell.Value = $"Summary For B2B({invoices?.Count ?? 0})";

            if (invoices != null && invoices.Any())
            {
                int row = DATA_START_ROW;
                foreach (var invoice in invoices)
                {
                    sheet.Cell(row, 1).Value = invoice.BillGstNo ?? "";
                    sheet.Cell(row, 2).Value = invoice.partyname ?? "";
                    sheet.Cell(row, 3).Value = invoice.BillNo ?? "";
                    sheet.Cell(row, 4).Value = invoice.BillDate;
                    sheet.Cell(row, 4).Style.DateFormat.Format = "dd-MM-yyyy";

                    sheet.Cell(row, 5).Value = (double)invoice.BillNetAmount;
                    sheet.Cell(row, 5).Style.NumberFormat.Format = "#,##0.00";

                    sheet.Cell(row, 6).Value = invoice.posname ?? "";
                    sheet.Cell(row, 7).Value = "N";
                    sheet.Cell(row, 8).Value = "";
                    sheet.Cell(row, 9).Value = "Regular B2B";
                    sheet.Cell(row, 10).Value = "";

                    double taxRate = DetermineTaxRate(invoice);
                    sheet.Cell(row, 11).Value = taxRate;
                    sheet.Cell(row, 11).Style.NumberFormat.Format = "0.00";

                    sheet.Cell(row, 12).Value = (double)invoice.BillTotal;
                    sheet.Cell(row, 12).Style.NumberFormat.Format = "#,##0.00";

                    sheet.Cell(row, 13).Value = 0;
                    sheet.Cell(row, 13).Style.NumberFormat.Format = "0.00";

                    ApplyBordersToRow(sheet, row, 13);
                    row++;
                }
            }
        }

        #endregion

        #region B2CL Sheet

        private void FillB2CLSheet(IXLWorkbook workbook, List<Bill> invoices)
        {
            var sheet = workbook.Worksheet("b2cl");
            if (sheet == null) return;

            ClearDataRows(sheet, DATA_START_ROW);

            var titleCell = sheet.Cell(1, 1);
            titleCell.Value = $"Summary For B2CL({invoices?.Count ?? 0})";

            if (invoices != null && invoices.Any())
            {
                int row = DATA_START_ROW;
                foreach (var invoice in invoices)
                {
                    sheet.Cell(row, 1).Value = invoice.BillNo ?? "";
                    sheet.Cell(row, 2).Value = invoice.BillDate;
                    sheet.Cell(row, 2).Style.DateFormat.Format = "dd-MM-yyyy";

                    sheet.Cell(row, 3).Value = (double)invoice.BillNetAmount;
                    sheet.Cell(row, 3).Style.NumberFormat.Format = "#,##0.00";

                    sheet.Cell(row, 4).Value = invoice.posname ?? "";
                    sheet.Cell(row, 5).Value = "";

                    double taxRate = DetermineTaxRate(invoice);
                    sheet.Cell(row, 6).Value = taxRate;
                    sheet.Cell(row, 6).Style.NumberFormat.Format = "0.00";

                    sheet.Cell(row, 7).Value = (double)invoice.BillTotal;
                    sheet.Cell(row, 7).Style.NumberFormat.Format = "#,##0.00";

                    sheet.Cell(row, 8).Value = 0;
                    sheet.Cell(row, 8).Style.NumberFormat.Format = "0.00";

                    sheet.Cell(row, 9).Value = "";

                    ApplyBordersToRow(sheet, row, 9);
                    row++;
                }
            }
        }

        #endregion

        #region B2CS Sheet

        private void FillB2CSSheet(IXLWorkbook workbook, List<B2CSmallSummary> summary)
        {
            var sheet = workbook.Worksheet("b2cs");
            if (sheet == null) return;

            ClearDataRows(sheet, DATA_START_ROW);

            var titleCell = sheet.Cell(1, 1);
            titleCell.Value = $"Summary For B2CS({summary?.Count ?? 0})";

            if (summary != null && summary.Any())
            {
                int row = DATA_START_ROW;
                foreach (var item in summary)
                {
                    sheet.Cell(row, 1).Value = "OE";
                    sheet.Cell(row, 2).Value = item.PlaceOfSupply ?? "";
                    sheet.Cell(row, 3).Value = "";

                    double rate = CalculateRateFromTax(item.TaxableValue, item.CGST + item.SGST);
                    sheet.Cell(row, 4).Value = rate;
                    sheet.Cell(row, 4).Style.NumberFormat.Format = "0.00";

                    sheet.Cell(row, 5).Value = (double)item.TaxableValue;
                    sheet.Cell(row, 5).Style.NumberFormat.Format = "#,##0.00";

                    sheet.Cell(row, 6).Value = 0;
                    sheet.Cell(row, 6).Style.NumberFormat.Format = "0.00";

                    sheet.Cell(row, 7).Value = "";

                    ApplyBordersToRow(sheet, row, 7);
                    row++;
                }
            }
        }

        #endregion

        #region CDNR Sheet

        private void FillCDNRSheet(IXLWorkbook workbook, List<Bill> notes)
        {
            var sheet = workbook.Worksheet("cdnr");
            if (sheet == null) return;

            ClearDataRows(sheet, DATA_START_ROW);

            var titleCell = sheet.Cell(1, 1);
            titleCell.Value = $"Summary For CDNR({notes?.Count ?? 0})";

            if (notes != null && notes.Any())
            {
                int row = DATA_START_ROW;
                foreach (var note in notes)
                {
                    string noteType = note.Vouchname?.ToUpper().Contains("CREDIT") == true ? "C" : "D";

                    sheet.Cell(row, 1).Value = note.BillGstNo ?? "";
                    sheet.Cell(row, 2).Value = note.partyname ?? "";
                    sheet.Cell(row, 3).Value = note.BillNo ?? "";
                    sheet.Cell(row, 4).Value = note.BillDate;
                    sheet.Cell(row, 4).Style.DateFormat.Format = "dd-MM-yyyy";

                    sheet.Cell(row, 5).Value = noteType;
                    sheet.Cell(row, 6).Value = note.posname ?? "";
                    sheet.Cell(row, 7).Value = "N";
                    sheet.Cell(row, 8).Value = "Regular";

                    sheet.Cell(row, 9).Value = (double)note.BillNetAmount;
                    sheet.Cell(row, 9).Style.NumberFormat.Format = "#,##0.00";

                    sheet.Cell(row, 10).Value = "";

                    double taxRate = DetermineTaxRate(note);
                    sheet.Cell(row, 11).Value = taxRate;
                    sheet.Cell(row, 11).Style.NumberFormat.Format = "0.00";

                    sheet.Cell(row, 12).Value = (double)note.BillTotal;
                    sheet.Cell(row, 12).Style.NumberFormat.Format = "#,##0.00";

                    sheet.Cell(row, 13).Value = 0;
                    sheet.Cell(row, 13).Style.NumberFormat.Format = "0.00";

                    ApplyBordersToRow(sheet, row, 13);
                    row++;
                }
            }
        }

        #endregion

        #region HSN Sheets

        private void FillHSNB2BSheet(IXLWorkbook workbook, List<Bill> b2bInvoices)
        {
            var sheet = workbook.Worksheet("hsn(b2b)");
            if (sheet == null) return;

            ClearDataRows(sheet, DATA_START_ROW);

            // Calculate HSN summary from BillDetails
            var hsnSummary = CalculateHSNSummaryFromBills(b2bInvoices);

            // Update title
            sheet.Cell(1, 1).Value = $"HSN-Wise Summary of outward supplies (B2B) ({hsnSummary.Count})";

            if (hsnSummary.Any())
            {
                int row = DATA_START_ROW;
                foreach (var hsn in hsnSummary)
                {
                    sheet.Cell(row, 1).Value = hsn.HSNCode ?? "";
                    sheet.Cell(row, 2).Value = hsn.Description ?? "";
                    sheet.Cell(row, 3).Value = hsn.UQC ?? "NOS";

                    sheet.Cell(row, 4).Value = hsn.TotalQuantity;
                    sheet.Cell(row, 4).Style.NumberFormat.Format = "#,##0.00";

                    sheet.Cell(row, 5).Value = (double)hsn.TotalValue;
                    sheet.Cell(row, 5).Style.NumberFormat.Format = "#,##0.00";

                    sheet.Cell(row, 6).Value = hsn.TaxRate;
                    sheet.Cell(row, 6).Style.NumberFormat.Format = "0.00";

                    sheet.Cell(row, 7).Value = (double)hsn.TaxableValue;
                    sheet.Cell(row, 7).Style.NumberFormat.Format = "#,##0.00";

                    sheet.Cell(row, 8).Value = (double)hsn.IGSTAmount;
                    sheet.Cell(row, 8).Style.NumberFormat.Format = "#,##0.00";

                    sheet.Cell(row, 9).Value = (double)hsn.CGSTAmount;
                    sheet.Cell(row, 9).Style.NumberFormat.Format = "#,##0.00";

                    sheet.Cell(row, 10).Value = (double)hsn.SGSTAmount;
                    sheet.Cell(row, 10).Style.NumberFormat.Format = "#,##0.00";

                    ApplyBordersToRow(sheet, row, 10);
                    row++;
                }
            }
        }

        private void FillHSNB2CSheet(IXLWorkbook workbook, List<Bill> b2cInvoices)
        {
            var sheet = workbook.Worksheet("hsn(b2c)");
            if (sheet == null) return;

            ClearDataRows(sheet, DATA_START_ROW);

            // Calculate HSN summary
            var hsnSummary = CalculateHSNSummaryFromBills(b2cInvoices);

            // Update title
            sheet.Cell(1, 1).Value = $"HSN-Wise Summary of outward supplies (B2C) ({hsnSummary.Count})";

            if (hsnSummary.Any())
            {
                int row = DATA_START_ROW;
                foreach (var hsn in hsnSummary)
                {
                    sheet.Cell(row, 1).Value = hsn.HSNCode ?? "";
                    sheet.Cell(row, 2).Value = hsn.Description ?? "";
                    sheet.Cell(row, 3).Value = hsn.UQC ?? "NOS";

                    sheet.Cell(row, 4).Value = hsn.TotalQuantity;
                    sheet.Cell(row, 4).Style.NumberFormat.Format = "#,##0.00";

                    sheet.Cell(row, 5).Value = (double)hsn.TotalValue;
                    sheet.Cell(row, 5).Style.NumberFormat.Format = "#,##0.00";

                    sheet.Cell(row, 6).Value = hsn.TaxRate;
                    sheet.Cell(row, 6).Style.NumberFormat.Format = "0.00";

                    sheet.Cell(row, 7).Value = (double)hsn.TaxableValue;
                    sheet.Cell(row, 7).Style.NumberFormat.Format = "#,##0.00";

                    sheet.Cell(row, 8).Value = (double)hsn.IGSTAmount;
                    sheet.Cell(row, 8).Style.NumberFormat.Format = "#,##0.00";

                    sheet.Cell(row, 9).Value = (double)hsn.CGSTAmount;
                    sheet.Cell(row, 9).Style.NumberFormat.Format = "#,##0.00";

                    sheet.Cell(row, 10).Value = (double)hsn.SGSTAmount;
                    sheet.Cell(row, 10).Style.NumberFormat.Format = "#,##0.00";

                    ApplyBordersToRow(sheet, row, 10);
                    row++;
                }
            }
        }

        /// <summary>
        /// Calculate HSN summary from Bills using their BillDetails
        /// </summary>
        private List<HSNSummary> CalculateHSNSummaryFromBills(List<Bill> bills)
        {
            if (bills == null || !bills.Any())
                return new List<HSNSummary>();

            // Collect all BillDetails from all Bills
            var allDetails = new List<BillDetailWithParent>();

            foreach (var bill in bills)
            {
                if (bill.BillDetails != null && bill.BillDetails.Any())
                {
                    // Use BillDetails for HSN data
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
                    // If no BillDetails, create a virtual detail from Bill data
                    allDetails.Add(new BillDetailWithParent
                    {
                        Detail = null, // No detail
                        ParentBill = bill
                    });
                }
            }

            // Group by HSN code and aggregate
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
                    SGSTAmount = g.Sum(item => GetSGSTFromDetail(item)),
                    TaxRate = CalculateTaxRateFromGroup(g.First())
                })
                .OrderBy(h => h.HSNCode)
                .ToList();

            return summary;
        }

        // Helper class to link BillDetail with parent Bill
        private class BillDetailWithParent
        {
            public BillDetail Detail { get; set; }
            public Bill ParentBill { get; set; }
        }

        // Helper methods to extract data from BillDetail or Bill
        private string GetHSNCodeFromDetail(BillDetailWithParent item)
        {
            if (item.Detail != null && !string.IsNullOrWhiteSpace(item.Detail.BillDetailHsnCode))
                return item.Detail.BillDetailHsnCode;

            return "9997"; // Default: Transport services
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

        private double CalculateTaxRateFromGroup(BillDetailWithParent item)
        {
            var taxableValue = GetTaxableValueFromDetail(item);
            if (taxableValue == 0) return 0;

            var igst = GetIGSTFromDetail(item);
            if (igst > 0)
                return Math.Round((igst / taxableValue) * 100, 2);

            var cgst = GetCGSTFromDetail(item);
            var sgst = GetSGSTFromDetail(item);
            if (cgst > 0 || sgst > 0)
            {
                var totalGst = cgst + sgst;
                return Math.Round((totalGst / taxableValue) * 100, 2);
            }

            return 0;
        }

        #endregion

        #region Docs Sheet

        private void FillDocsSheet(IXLWorkbook workbook, List<Bill> b2bInvoices, List<Bill> b2cLargeInvoices, List<Bill> b2cSmallInvoices, List<Bill> creditDebitNotes)
        {
            var sheet = workbook.Worksheet("docs");
            if (sheet == null) return;

            // Combine all invoices
            var allInvoices = new List<Bill>();
            allInvoices.AddRange(b2bInvoices);
            allInvoices.AddRange(b2cLargeInvoices);
            allInvoices.AddRange(b2cSmallInvoices);

            // Get invoice range    
            if (allInvoices.Any())
            {
                var sortedInvoices = allInvoices.OrderBy(b => b.BillId).ToList();
                var firstInvoice = sortedInvoices.First();
                var lastInvoice = sortedInvoices.Last();

                int totalInvoices = allInvoices.Count;

                // Row 5: Invoices for outward supply
                sheet.Cell(5, 1).Value = "Invoices for outward supply";
                sheet.Cell(5, 2).Value = firstInvoice.BillNo ?? "";
                sheet.Cell(5, 3).Value = lastInvoice.BillNo ?? "";
                sheet.Cell(5, 4).Value = totalInvoices;
                sheet.Cell(5, 5).Value = 0; // Cancelled - you can calculate this if you track cancelled invoices
            }

            // Get credit note range
            if (creditDebitNotes.Any())
            {
                var creditNotes = creditDebitNotes
                    .Where(b => b.Vouchname?.ToUpper().Contains("CREDIT") == true)
                    .OrderBy(b => b.BillNo)
                    .ToList();

                if (creditNotes.Any())
                {
                    var firstCreditNote = creditNotes.First();
                    var lastCreditNote = creditNotes.Last();
                    int totalCreditNotes = creditNotes.Count;

                    // Row 6: Credit Note
                    sheet.Cell(6, 1).Value = "Credit Note";
                    sheet.Cell(6, 2).Value = firstCreditNote.BillNo ?? "";
                    sheet.Cell(6, 3).Value = lastCreditNote.BillNo ?? "";
                    sheet.Cell(6, 4).Value = totalCreditNotes;
                    sheet.Cell(6, 5).Value = 0; // Cancelled
                }

                // Get debit note range
                var debitNotes = creditDebitNotes
                    .Where(b => b.Vouchname?.ToUpper().Contains("DEBIT") == true)
                    .OrderBy(b => b.BillNo)
                    .ToList();

                if (debitNotes.Any())
                {
                    var firstDebitNote = debitNotes.First();
                    var lastDebitNote = debitNotes.Last();
                    int totalDebitNotes = debitNotes.Count;

                    // Row 7: Debit Note (if row 6 was credit note)
                    int debitNoteRow = creditNotes.Any() ? 7 : 6;
                    sheet.Cell(debitNoteRow, 1).Value = "Debit Note";
                    sheet.Cell(debitNoteRow, 2).Value = firstDebitNote.BillNo ?? "";
                    sheet.Cell(debitNoteRow, 3).Value = lastDebitNote.BillNo ?? "";
                    sheet.Cell(debitNoteRow, 4).Value = totalDebitNotes;
                    sheet.Cell(debitNoteRow, 5).Value = 0; // Cancelled
                }
            }

            // Calculate totals for row 2
            int totalDocs = allInvoices.Count + creditDebitNotes.Count;
            sheet.Cell(2, 4).Value = totalDocs;
            sheet.Cell(2, 5).Value = 0; // Total cancelled
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

        private double DetermineTaxRate(Bill invoice)
        {
            if (invoice.BillTotal == 0) return 0;

            if (invoice.BillIgst > 0)
            {
                return Math.Round((double)(invoice.BillIgst / invoice.BillTotal * 100), 2);
            }

            if (invoice.BillCgst > 0 || invoice.BillSgst > 0)
            {
                double totalGst = (double)(invoice.BillCgst + invoice.BillSgst);
                return Math.Round(totalGst / (double)invoice.BillTotal * 100, 2);
            }

            return 0;
        }

        private double CalculateRateFromTax(decimal taxableValue, decimal taxAmount)
        {
            if (taxableValue == 0) return 0;
            return Math.Round((double)(taxAmount / taxableValue * 100), 2);
        }

        #endregion

        #region Data Models

        public class B2CSmallSummary
        {
            public string PlaceOfSupply { get; set; }
            public decimal TaxableValue { get; set; }
            public decimal IGST { get; set; }
            public decimal CGST { get; set; }
            public decimal SGST { get; set; }
            public decimal InvoiceValue { get; set; }
        }

        public class HSNSummary
        {
            public string HSNCode { get; set; }
            public string Description { get; set; }
            public string UQC { get; set; }
            public double TotalQuantity { get; set; }
            public double TotalValue { get; set; }
            public double TaxRate { get; set; }
            public double TaxableValue { get; set; }
            public double IGSTAmount { get; set; }
            public double CGSTAmount { get; set; }
            public double SGSTAmount { get; set; }
        }

        #endregion
    }
}