
using DevExpress.PivotGrid.PivotTable;
using FreightBKShippingWebApp.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FreightBKShippingWebApp.Services
{
    public class Sentwpcerti
    {
        private readonly ReportDataService _reportDataService;
        private readonly ReportService _reportService;
        private readonly BillService _billService;
        private readonly BranchService _branchService;
        private readonly BillUploadService BillUploadService;
        // Added branch service

        public Sentwpcerti(ReportDataService reportDataService,
                           ReportService reportService,
                           BillService billService,
                           BranchService branchService,
                           BillUploadService billUploadService) // Inject branch service
        {
            _reportDataService = reportDataService;
            _reportService = reportService;
            _billService = billService;
            _branchService = branchService;
            BillUploadService = billUploadService;
        }

        public async Task<(byte[] PdfBytes, string FileName, string BlobUrl)>
            GenerateAndUploadReportAsync(
                IEnumerable<Bill> certList,
                int reportId,
                bool uploadOnAzure = false)
        {
            if (!certList.Any())
                throw new Exception("No certificates selected.");

            // --- Prepare report layout ---
            var layoutBytes = await _reportDataService.GetLayoutBytesAsync(reportId);
            if (layoutBytes == null || layoutBytes.Length == 0)
                throw new Exception("Failed to load report layout.");

            // --- Prepare data ---
            var dtoList = new List<PrintBillFullDto?>();
            foreach (var cert in certList)
                dtoList.Add(await _billService.GetPrintableBillAsync(cert.BillId));

            var dtoDict = certList.Select((cert, i) => new { cert, dto = dtoList[i] })
                                  .ToDictionary(x => x.cert, x => x.dto);

            // --- Generate merged report ---
            //await _reportService.CreateMergedReportAsync(certList,
            //    cert => dtoDict.ContainsKey(cert) ? dtoDict[cert] : null,
            //    layoutBytes);

            try
            {
                await _reportService.CreateMergedReportAsync(certList,
                    cert => dtoDict.ContainsKey(cert) ? dtoDict[cert] : null,
                    layoutBytes);
            }
            catch (Exception ex)
            {
                throw new Exception("Report generation failed: " + ex.ToString());
            }


            // --- Export PDF ---
            byte[] pdfBytes;
            using (var ms = new MemoryStream())
            {
               

     
                await _reportService.MergedReport.ExportToPdfAsync(
                   ms,
                   new DevExpress.XtraPrinting.PdfExportOptions()
                );
                pdfBytes = ms.ToArray();
            }

            // --- Build file name (branch + cert no + prefix/suffix) ---
            var firstCert = certList.First();

            string Safe(string input) =>
                string.Concat(input.Split(Path.GetInvalidFileNameChars())).Replace(" ", "_");

            var safeCertType = Safe(firstCert.BillType); // Your existing safe wrapper for CertiType
            var branchName = await _branchService.GetByIdAsync(firstCert.BillBranchId); // Fetch Branch object
            var safeBranch = Safe(branchName?.BranchName ?? $"Branch{firstCert.BillBranchId}"); // Null-safe branch name

            var safeCertiNo = Safe(firstCert.BillNo.ToString() ?? "0");
            var safePrefix = Safe(firstCert.BillPrefix ?? "");
            var safeSuffix = Safe(firstCert.BillPostfix ?? "");

            var fileName =
                $"{safeCertType}_{safeBranch}_{safePrefix}-{safeCertiNo}-{safeSuffix}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            // --- Upload to blob if needed ---
            string? blobUrl = null;
            if (uploadOnAzure)
            {
                var billlId = firstCert.BillId.ToString();
                blobUrl = await BillUploadService.UploadBillPdfAsync(pdfBytes, fileName, billlId, safeCertType);
            }

            return (pdfBytes, fileName, blobUrl ?? string.Empty);
        }
    }
}
