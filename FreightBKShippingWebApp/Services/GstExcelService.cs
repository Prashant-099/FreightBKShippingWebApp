using ClosedXML.Excel;
using FreightBKShippingWebApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FreightBKShippingWebApp.Services
{
    /// <summary>
    /// Professional GSTR-1 Excel generation service following government format standards
    /// </summary>
    public class GstExcelService
    {
        //        #region Government Format Constants

        //        private const string SHEET_B2B = "b2b,sez,de";
        //        private const string SHEET_B2BA = "b2ba";
        //        private const string SHEET_B2CL = "b2cl";
        //        private const string SHEET_B2CLA = "b2cla";
        //        private const string SHEET_B2CS = "b2cs";
        //        private const string SHEET_B2CSA = "b2csa";
        //        private const string SHEET_CDNR = "cdnr";
        //        private const string SHEET_CDNRA = "cdnra";
        //        private const string SHEET_HSN_B2B = "hsn(b2b)";
        //        private const string SHEET_HSN_B2C = "hsn(b2c)";
        //        private const string SHEET_HELP = "Help Instruction";

        //        private const int HEADER_ROW = 4;
        //        private const int DATA_START_ROW = 5;

        //        #endregion

        //        #region B2B Invoice Generation

        //        /// <summary>
        //        /// Generate complete GSTR-1 Excel in government format
        //        /// </summary>
        //        public byte[] GenerateGSTR1Excel(
        //            List<Bill> b2bInvoices,
        //            List<Bill> b2cLargeInvoices,
        //            List<B2CSmallSummary> b2cSmallSummary,
        //            List<Bill> creditDebitNotes,
        //            DateTime? fromDate,
        //            DateTime? toDate,
        //            string gstin)
        //        {
        //            using var workbook = new XLWorkbook();

        //            // Create sheets in government order
        //            AddHelpInstructionSheet(workbook);
        //            AddB2BSheet(workbook, b2bInvoices);
        //            AddB2BASheet(workbook); // Amendment sheet
        //            AddB2CLSheet(workbook, b2cLargeInvoices);
        //            AddB2CLASheet(workbook); // Amendment sheet
        //            AddB2CSSheet(workbook, b2cSmallSummary);
        //            AddB2CSASheet(workbook); // Amendment sheet
        //            AddCDNRSheet(workbook, creditDebitNotes);
        //            AddCDNRASheet(workbook); // Amendment sheet
        //            AddHSNSheets(workbook); // HSN summary sheets

        //            using var stream = new MemoryStream();
        //            workbook.SaveAs(stream);
        //            return stream.ToArray();
        //        }

        //        #endregion

        //        #region B2B Sheet (Main Invoice Sheet)

        //        private void AddB2BSheet(IXLWorkbook workbook, List<Bill> invoices)
        //        {
        //            var sheet = workbook.Worksheets.Add(SHEET_B2B);

        //            // Title
        //            var titleCell = sheet.Cell(1, 1);
        //            titleCell.Value = $"Summary For B2B({invoices?.Count ?? 0})";
        //            titleCell.Style.Font.Bold = true;
        //            titleCell.Style.Font.FontSize = 12;

        //            // Headers (Row 4)
        //            var headers = new[]
        //            {
        //                "GSTIN/UIN of Recipient",
        //                "Receiver Name",
        //                "Invoice Number",
        //                "Invoice date",
        //                "Invoice Value",
        //                "Place Of Supply",
        //                "Reverse Charge",
        //                "Applicable % of Tax Rate",
        //                "Invoice Type",
        //                "E-Commerce GSTIN",
        //                "Rate",
        //                "Taxable Value",
        //                "Cess Amount"
        //            };

        //            for (int i = 0; i < headers.Length; i++)
        //            {
        //                var headerCell = sheet.Cell(HEADER_ROW, i + 1);
        //                headerCell.Value = headers[i];
        //                headerCell.Style.Font.Bold = true;
        //                headerCell.Style.Fill.BackgroundColor = XLColor.LightGray;
        //                headerCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        //                headerCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        //                headerCell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        //            }

        //            // Data rows
        //            if (invoices != null && invoices.Any())
        //            {
        //                int row = DATA_START_ROW;
        //                foreach (var invoice in invoices)
        //                {
        //                    sheet.Cell(row, 1).Value = invoice.BillGstNo ?? "";
        //                    sheet.Cell(row, 2).Value = invoice.partyname ?? "";
        //                    sheet.Cell(row, 3).Value = invoice.BillNo ?? "";
        //                    sheet.Cell(row, 4).Value = invoice.BillDate;
        //                    sheet.Cell(row, 4).Style.DateFormat.Format = "dd-MM-yyyy";

        //                    sheet.Cell(row, 5).Value = (double)invoice.BillNetAmount;
        //                    sheet.Cell(row, 5).Style.NumberFormat.Format = "#,##0.00";

        //                    sheet.Cell(row, 6).Value = invoice.posname ?? "";
        //                    sheet.Cell(row, 7).Value = "N"; // Reverse Charge
        //                    sheet.Cell(row, 8).Value = ""; // Applicable % of Tax Rate
        //                    sheet.Cell(row, 9).Value = "Regular B2B";
        //                    sheet.Cell(row, 10).Value = ""; // E-Commerce GSTIN

        //                    // Determine tax rate (assuming from IGST or CGST+SGST)
        //                    double taxRate = DetermineTaxRate(invoice);
        //                    sheet.Cell(row, 11).Value = taxRate;

        //                    sheet.Cell(row, 12).Value = (double)invoice.BillTotal;
        //                    sheet.Cell(row, 12).Style.NumberFormat.Format = "#,##0.00";

        //                    sheet.Cell(row, 13).Value = 0; // Cess Amount

        //                    // Apply borders
        //                    sheet.Range(row, 1, row, 13).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

        //                    row++;
        //                }
        //            }

        //            // Auto-fit columns
        //            sheet.Columns().AdjustToContents();

        //            // Set specific column widths for better readability
        //            sheet.Column(1).Width = 20; // GSTIN
        //            sheet.Column(2).Width = 30; // Receiver Name
        //            sheet.Column(3).Width = 15; // Invoice Number
        //            sheet.Column(6).Width = 18; // Place of Supply
        //        }

        //        #endregion

        //        #region B2CL Sheet (B2C Large > 2.5L)

        //        private void AddB2CLSheet(IXLWorkbook workbook, List<Bill> invoices)
        //        {
        //            var sheet = workbook.Worksheets.Add(SHEET_B2CL);

        //            // Title
        //            var titleCell = sheet.Cell(1, 1);
        //            titleCell.Value = $"Summary For B2CL({invoices?.Count ?? 0})";
        //            titleCell.Style.Font.Bold = true;
        //            titleCell.Style.Font.FontSize = 12;

        //            // Headers (Row 4)
        //            var headers = new[]
        //            {
        //                "Invoice Number",
        //                "Invoice date",
        //                "Invoice Value",
        //                "Place Of Supply",
        //                "Applicable % of Tax Rate",
        //                "Rate",
        //                "Taxable Value",
        //                "Cess Amount",
        //                "E-Commerce GSTIN"
        //            };

        //            for (int i = 0; i < headers.Length; i++)
        //            {
        //                var headerCell = sheet.Cell(HEADER_ROW, i + 1);
        //                headerCell.Value = headers[i];
        //                headerCell.Style.Font.Bold = true;
        //                headerCell.Style.Fill.BackgroundColor = XLColor.LightGray;
        //                headerCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        //                headerCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        //            }

        //            // Data rows
        //            if (invoices != null && invoices.Any())
        //            {
        //                int row = DATA_START_ROW;
        //                foreach (var invoice in invoices)
        //                {
        //                    sheet.Cell(row, 1).Value = invoice.BillNo ?? "";
        //                    sheet.Cell(row, 2).Value = invoice.BillDate;
        //                    sheet.Cell(row, 2).Style.DateFormat.Format = "dd-MM-yyyy";

        //                    sheet.Cell(row, 3).Value = (double)invoice.BillNetAmount;
        //                    sheet.Cell(row, 3).Style.NumberFormat.Format = "#,##0.00";

        //                    sheet.Cell(row, 4).Value = invoice.posname ?? "";
        //                    sheet.Cell(row, 5).Value = "";

        //                    double taxRate = DetermineTaxRate(invoice);
        //                    sheet.Cell(row, 6).Value = taxRate;

        //                    sheet.Cell(row, 7).Value = (double)invoice.BillTotal;
        //                    sheet.Cell(row, 7).Style.NumberFormat.Format = "#,##0.00";

        //                    sheet.Cell(row, 8).Value = 0; // Cess
        //                    sheet.Cell(row, 9).Value = ""; // E-Commerce GSTIN

        //                    sheet.Range(row, 1, row, 9).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        //                    row++;
        //                }
        //            }

        //            sheet.Columns().AdjustToContents();
        //        }

        //        #endregion

        //        #region B2CS Sheet (B2C Small Summary)

        //        private void AddB2CSSheet(IXLWorkbook workbook, List<B2CSmallSummary> summary)
        //        {
        //            var sheet = workbook.Worksheets.Add(SHEET_B2CS);

        //            // Title
        //            var titleCell = sheet.Cell(1, 1);
        //            titleCell.Value = $"Summary For B2CS({summary?.Count ?? 0})";
        //            titleCell.Style.Font.Bold = true;
        //            titleCell.Style.Font.FontSize = 12;

        //            // Headers (Row 4)
        //            var headers = new[]
        //            {
        //                "Type",
        //                "Place Of Supply",
        //                "Applicable % of Tax Rate",
        //                "Rate",
        //                "Taxable Value",
        //                "Cess Amount",
        //                "E-Commerce GSTIN"
        //            };

        //            for (int i = 0; i < headers.Length; i++)
        //            {
        //                var headerCell = sheet.Cell(HEADER_ROW, i + 1);
        //                headerCell.Value = headers[i];
        //                headerCell.Style.Font.Bold = true;
        //                headerCell.Style.Fill.BackgroundColor = XLColor.LightGray;
        //                headerCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        //                headerCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        //            }

        //            // Data rows
        //            if (summary != null && summary.Any())
        //            {
        //                int row = DATA_START_ROW;
        //                foreach (var item in summary)
        //                {
        //                    sheet.Cell(row, 1).Value = "OE"; // Type: OE = Others
        //                    sheet.Cell(row, 2).Value = item.PlaceOfSupply ?? "";
        //                    sheet.Cell(row, 3).Value = "";

        //                    // Calculate rate from CGST + SGST
        //                    double rate = CalculateRateFromTax(item.TaxableValue, item.CGST + item.SGST);
        //                    sheet.Cell(row, 4).Value = rate;

        //                    sheet.Cell(row, 5).Value = (double)item.TaxableValue;
        //                    sheet.Cell(row, 5).Style.NumberFormat.Format = "#,##0.00";

        //                    sheet.Cell(row, 6).Value = 0; // Cess
        //                    sheet.Cell(row, 7).Value = "";

        //                    sheet.Range(row, 1, row, 7).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        //                    row++;
        //                }
        //            }

        //            sheet.Columns().AdjustToContents();
        //        }

        //        #endregion

        //        #region CDNR Sheet (Credit/Debit Notes Registered)

        //        private void AddCDNRSheet(IXLWorkbook workbook, List<Bill> notes)
        //        {
        //            var sheet = workbook.Worksheets.Add(SHEET_CDNR);

        //            // Title
        //            var titleCell = sheet.Cell(1, 1);
        //            titleCell.Value = $"Summary For CDNR({notes?.Count ?? 0})";
        //            titleCell.Style.Font.Bold = true;
        //            titleCell.Style.Font.FontSize = 12;

        //            // Headers (Row 4)
        //            var headers = new[]
        //            {
        //                "GSTIN/UIN of Recipient",
        //                "Receiver Name",
        //                "Note Number",
        //                "Note date",
        //                "Note Type",
        //                "Place Of Supply",
        //                "Reverse Charge",
        //                "Note Supply Type",
        //                "Note Value",
        //                "Applicable % of Tax Rate",
        //                "Rate",
        //                "Taxable Value",
        //                "Cess Amount"
        //            };

        //            for (int i = 0; i < headers.Length; i++)
        //            {
        //                var headerCell = sheet.Cell(HEADER_ROW, i + 1);
        //                headerCell.Value = headers[i];
        //                headerCell.Style.Font.Bold = true;
        //                headerCell.Style.Fill.BackgroundColor = XLColor.LightGray;
        //                headerCell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        //                headerCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        //            }

        //            // Data rows
        //            if (notes != null && notes.Any())
        //            {
        //                int row = DATA_START_ROW;
        //                foreach (var note in notes)
        //                {
        //                    string noteType = note.Vouchname?.ToUpper().Contains("CREDIT") == true ? "C" : "D";

        //                    sheet.Cell(row, 1).Value = note.BillGstNo ?? "";
        //                    sheet.Cell(row, 2).Value = note.partyname ?? "";
        //                    sheet.Cell(row, 3).Value = note.BillNo ?? "";
        //                    sheet.Cell(row, 4).Value = note.BillDate;
        //                    sheet.Cell(row, 4).Style.DateFormat.Format = "dd-MM-yyyy";

        //                    sheet.Cell(row, 5).Value = noteType;
        //                    sheet.Cell(row, 6).Value = note.posname ?? "";
        //                    sheet.Cell(row, 7).Value = "N";
        //                    sheet.Cell(row, 8).Value = "Regular";

        //                    sheet.Cell(row, 9).Value = (double)note.BillNetAmount;
        //                    sheet.Cell(row, 9).Style.NumberFormat.Format = "#,##0.00";

        //                    sheet.Cell(row, 10).Value = "";

        //                    double taxRate = DetermineTaxRate(note);
        //                    sheet.Cell(row, 11).Value = taxRate;

        //                    sheet.Cell(row, 12).Value = (double)note.BillTotal;
        //                    sheet.Cell(row, 12).Style.NumberFormat.Format = "#,##0.00";

        //                    sheet.Cell(row, 13).Value = 0;

        //                    sheet.Range(row, 1, row, 13).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        //                    row++;
        //                }
        //            }

        //            sheet.Columns().AdjustToContents();
        //        }

        //        #endregion

        //        #region Amendment Sheets (Empty Templates)

        //        private void AddB2BASheet(IXLWorkbook workbook)
        //        {
        //            var sheet = workbook.Worksheets.Add(SHEET_B2BA);

        //            var titleCell = sheet.Cell(1, 1);
        //            titleCell.Value = "Summary For B2BA";
        //            titleCell.Style.Font.Bold = true;

        //            sheet.Cell(1, 4).Value = "Original details";
        //            sheet.Cell(1, 4).Style.Font.Bold = true;
        //            sheet.Cell(1, 5).Value = "Revised Details";
        //            sheet.Cell(1, 5).Style.Font.Bold = true;

        //            var headers = new[]
        //            {
        //                "GSTIN/UIN of Recipient", "Receiver Name",
        //                "Original Invoice Number", "Original Invoice date",
        //                "Revised Invoice Number", "Revised Invoice date",
        //                "Invoice Value", "Place Of Supply", "Reverse Charge",
        //                "Applicable % of Tax Rate", "Invoice Type", "E-Commerce GSTIN",
        //                "Rate", "Taxable Value", "Cess Amount"
        //            };

        //            for (int i = 0; i < headers.Length; i++)
        //            {
        //                var cell = sheet.Cell(HEADER_ROW, i + 1);
        //                cell.Value = headers[i];
        //                cell.Style.Font.Bold = true;
        //                cell.Style.Fill.BackgroundColor = XLColor.LightGray;
        //            }

        //            sheet.Columns().AdjustToContents();
        //        }

        //        private void AddB2CLASheet(IXLWorkbook workbook)
        //        {
        //            var sheet = workbook.Worksheets.Add(SHEET_B2CLA);

        //            var titleCell = sheet.Cell(1, 1);
        //            titleCell.Value = "Summary For B2CLA";
        //            titleCell.Style.Font.Bold = true;

        //            var headers = new[]
        //            {
        //                "Original Invoice Number", "Original Invoice date", "Original Place Of Supply",
        //                "Revised Invoice Number", "Revised Invoice date", "Invoice Value",
        //                "Applicable % of Tax Rate", "Rate", "Taxable Value", "Cess Amount", "E-Commerce GSTIN"
        //            };

        //            for (int i = 0; i < headers.Length; i++)
        //            {
        //                var cell = sheet.Cell(HEADER_ROW, i + 1);
        //                cell.Value = headers[i];
        //                cell.Style.Font.Bold = true;
        //                cell.Style.Fill.BackgroundColor = XLColor.LightGray;
        //            }

        //            sheet.Columns().AdjustToContents();
        //        }

        //        private void AddB2CSASheet(IXLWorkbook workbook)
        //        {
        //            var sheet = workbook.Worksheets.Add(SHEET_B2CSA);

        //            var titleCell = sheet.Cell(1, 1);
        //            titleCell.Value = "Summary For B2CSA";
        //            titleCell.Style.Font.Bold = true;

        //            var headers = new[]
        //            {
        //                "Financial Year", "Original Month", "Type", "Place Of Supply",
        //                "Applicable % of Tax Rate", "Rate", "Taxable Value", "Cess Amount", "E-Commerce GSTIN"
        //            };

        //            for (int i = 0; i < headers.Length; i++)
        //            {
        //                var cell = sheet.Cell(HEADER_ROW, i + 1);
        //                cell.Value = headers[i];
        //                cell.Style.Font.Bold = true;
        //                cell.Style.Fill.BackgroundColor = XLColor.LightGray;
        //            }

        //            sheet.Columns().AdjustToContents();
        //        }

        //        private void AddCDNRASheet(IXLWorkbook workbook)
        //        {
        //            var sheet = workbook.Worksheets.Add(SHEET_CDNRA);

        //            var titleCell = sheet.Cell(1, 1);
        //            titleCell.Value = "Summary For CDNRA";
        //            titleCell.Style.Font.Bold = true;

        //            var headers = new[]
        //            {
        //                "GSTIN/UIN of Recipient", "Receiver Name",
        //                "Original Note Number", "Original Note date",
        //                "Revised Note Number", "Revised Note date",
        //                "Note Type", "Place Of Supply", "Reverse Charge",
        //                "Note Supply Type", "Note Value", "Applicable % of Tax Rate",
        //                "Rate", "Taxable Value", "Cess Amount"
        //            };

        //            for (int i = 0; i < headers.Length; i++)
        //            {
        //                var cell = sheet.Cell(HEADER_ROW, i + 1);
        //                cell.Value = headers[i];
        //                cell.Style.Font.Bold = true;
        //                cell.Style.Fill.BackgroundColor = XLColor.LightGray;
        //            }

        //            sheet.Columns().AdjustToContents();
        //        }

        //        #endregion

        //        #region HSN Sheets

        //        private void AddHSNSheets(IXLWorkbook workbook)
        //        {
        //            // HSN for B2B
        //            var b2bSheet = workbook.Worksheets.Add(SHEET_HSN_B2B);
        //            SetupHSNSheet(b2bSheet, "HSN-Wise Summary of outward supplies (B2B)");

        //            // HSN for B2C
        //            var b2cSheet = workbook.Worksheets.Add(SHEET_HSN_B2C);
        //            SetupHSNSheet(b2cSheet, "HSN-Wise Summary of outward supplies (B2C)");
        //        }

        //        private void SetupHSNSheet(IXLWorksheet sheet, string title)
        //        {
        //            var titleCell = sheet.Cell(1, 1);
        //            titleCell.Value = title;
        //            titleCell.Style.Font.Bold = true;
        //            titleCell.Style.Font.FontSize = 12;

        //            var headers = new[]
        //            {
        //                "HSN", "Description", "UQC", "Total Quantity",
        //                "Total Value", "Taxable Value", "Integrated Tax Amount",
        //                "Central Tax Amount", "State/UT Tax Amount", "Cess Amount"
        //            };

        //            for (int i = 0; i < headers.Length; i++)
        //            {
        //                var cell = sheet.Cell(HEADER_ROW, i + 1);
        //                cell.Value = headers[i];
        //                cell.Style.Font.Bold = true;
        //                cell.Style.Fill.BackgroundColor = XLColor.LightGray;
        //                cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        //            }

        //            sheet.Columns().AdjustToContents();
        //        }

        //        #endregion

        //        #region Help Instruction Sheet

        //        private void AddHelpInstructionSheet(IXLWorkbook workbook)
        //        {
        //            var sheet = workbook.Worksheets.Add(SHEET_HELP);

        //            var row = 5;
        //            sheet.Cell(row++, 1).Value = "Help Instructions";
        //            sheet.Cell(row - 1, 1).Style.Font.Bold = true;
        //            sheet.Cell(row - 1, 1).Style.Font.FontSize = 14;

        //            row++;
        //            sheet.Cell(row++, 1).Value = "1. The offline tool for generating the JSON file will not take the data available in the sheets exemp and docs.";
        //            sheet.Cell(row++, 1).Value = "2. The values in these sheets are in the same order as in the portal.";
        //            sheet.Cell(row++, 1).Value = "3. You can manually enter the data from these sheets directly into the GSTN portal.";

        //            row++;
        //            sheet.Cell(row++, 1).Value = "Visit https://help.tallysolutions.com for more information on:";
        //            sheet.Cell(row - 1, 1).Style.Font.Bold = true;

        //            sheet.Cell(row++, 1).Value = "• How to use the GSTR-1 offline tool";
        //            sheet.Cell(row++, 1).Value = "• Understanding GSTR-1 return filing";
        //            sheet.Cell(row++, 1).Value = "• Troubleshooting common issues";

        //            sheet.Column(1).Width = 100;
        //        }

        //        #endregion

        //        #region Helper Methods

        //        /// <summary>
        //        /// Determine tax rate from invoice amounts
        //        /// </summary>
        //        private double DetermineTaxRate(Bill invoice)
        //        {
        //            if (invoice.BillTotal == 0) return 0;

        //            // If IGST is used
        //            if (invoice.BillIgst > 0)
        //            {
        //                return Math.Round((double)(invoice.BillIgst / invoice.BillTotal * 100), 2);
        //            }

        //            // If CGST + SGST is used
        //            if (invoice.BillCgst > 0 || invoice.BillSgst > 0)
        //            {
        //                double totalGst = (double)(invoice.BillCgst + invoice.BillSgst);
        //                return Math.Round(totalGst / (double)invoice.BillTotal * 100, 2);
        //            }

        //            return 0;
        //        }

        //        /// <summary>
        //        /// Calculate tax rate from taxable value and tax amount
        //        /// </summary>
        //        private double CalculateRateFromTax(decimal taxableValue, decimal taxAmount)
        //        {
        //            if (taxableValue == 0) return 0;
        //            return Math.Round((double)(taxAmount / taxableValue * 100), 2);
        //        }

        //        #endregion

        //        #region Data Models

        //        public class B2CSmallSummary
        //        {
        //            public string PlaceOfSupply { get; set; }
        //            public decimal TaxableValue { get; set; }
        //            public decimal CGST { get; set; }
        //            public decimal SGST { get; set; }
        //            public decimal InvoiceValue { get; set; }
        //        }

        //        #endregion
    }
}