using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FreightBKShippingWebApp.Services
{
    public class ReportService
    {
        public XtraReport? MergedReport { get; set; }
            
        public ReportService()
        {
        }
        private static byte[] DecompressIfGzip(byte[] input)
        {
            // GZIP files always start with: 1F 8B
            if (input is { Length: > 2 } && input[0] == 0x1F && input[1] == 0x8B)
            {
                using var compressed = new MemoryStream(input);
                using var gzip = new System.IO.Compression.GZipStream(compressed, System.IO.Compression.CompressionMode.Decompress);
                using var result = new MemoryStream();
                gzip.CopyTo(result);
                return result.ToArray();
            }

            return input;
        }

        public async Task<XtraReport?> CreateMergedReportAsync<TItem, TDto>(
    IEnumerable<TItem> items,
    Func<TItem, TDto?> fetchData,
    byte[] layoutBytes)
    where TDto : class
        {
            XtraReport? baseRpt = null;

            foreach (var item in items)
            {
                var data = fetchData(item);
                if (data == null) continue;

                var rpt = new XtraReport();
                var xmlBytes = DecompressIfGzip(layoutBytes);

                using (var ms = new MemoryStream(xmlBytes))
                {
                    try
                    {
                        rpt.LoadLayoutFromXml(ms);
                    }
                    catch (NotSupportedException ex)
                    {
                        throw new InvalidOperationException(
                            "Report layout format is not compatible with .NET Core. " +
                            "Please re-save the report using DevExpress .NET Core designer.",
                            ex);
                    }
                }

                // Clean problematic elements
                rpt.CalculatedFields.Clear();
                rpt.FilterString = string.Empty;

                if (rpt.ComponentStorage != null && rpt.ComponentStorage.Count > 0)
                    rpt.ComponentStorage.Clear();

                foreach (var ctrl in rpt.AllControls<XRControl>())
                {
                    var bindingsToRemove = ctrl.ExpressionBindings
                        .Where(b => string.IsNullOrWhiteSpace(b.Expression))
                        .ToList();

                    foreach (var binding in bindingsToRemove)
                        ctrl.ExpressionBindings.Remove(binding);
                }

                // Bind data
                rpt.DataSource = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource
                {
                    DataSource = new List<TDto> { data }
                };

                rpt.DataMember = string.Empty;

                rpt.CreateDocument();

                // Merge
                if (baseRpt == null)
                {
                    baseRpt = rpt;
                    baseRpt.PrintingSystem.ContinuousPageNumbering = true;
                }
                else
                {
                    baseRpt.ModifyDocument(mod => mod.AddPages(rpt.Pages));
                }
            }

            return baseRpt;
        }

    }
}