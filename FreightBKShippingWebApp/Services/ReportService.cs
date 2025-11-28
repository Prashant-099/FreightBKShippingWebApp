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

        public async Task CreateMergedReportAsync<TItem, TDto>(
            IEnumerable<TItem> items,
            Func<TItem, TDto?> fetchData,
            byte[] layoutBytes)
            where TDto : class
        {
            XtraReport? baseRpt = null;

            await Task.Run(() =>
            {
                try
                {
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
                                // Try loading the layout
                                rpt.LoadLayoutFromXml(ms);
                            }
                            catch (NotSupportedException ex)
                            {
                                throw new InvalidOperationException(
                                    "Report layout format is not compatible with .NET Core. " +
                                    "The report contains CodeDOM serialization which is not supported. " +
                                    "Please re-save the report using DevExpress Report Designer for .NET Core/.NET 6+. " +
                                    "Steps: Open the .repx file in DevExpress Report Designer (v24.1 for .NET Core), " +
                                    "remove any scripts/calculated fields, and save it again.",
                                    ex);
                            }
                            catch (Exception ex)
                            {
                                throw new InvalidOperationException(
                                    $"Failed to load report layout: {ex.Message}", ex);
                            }
                        }

                        // Clear potentially problematic elements
                        try
                        {
                            rpt.CalculatedFields.Clear();
                            rpt.FilterString = string.Empty;

                            // Clear ComponentStorage (JsonDataSource, etc.)
                            if (rpt.ComponentStorage != null && rpt.ComponentStorage.Count > 0)
                            {
                                rpt.ComponentStorage.Clear();
                            }

                            // Clear script-based expression bindings
                            foreach (var ctrl in rpt.AllControls<XRControl>())
                            {
                                // Only clear bindings if they're causing issues
                                // Keep expression bindings that use the new expression syntax
                                var bindingsToRemove = ctrl.ExpressionBindings
                                    .Where(b => string.IsNullOrWhiteSpace(b.Expression))
                                    .ToList();

                                foreach (var binding in bindingsToRemove)
                                {
                                    ctrl.ExpressionBindings.Remove(binding);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Warning: Could not clear some report elements: {ex.Message}");
                        }

                        // Set new data source
                        try
                        {
                            var dataSource = new ObjectDataSource
                            {
                                DataSource = new List<TDto> { data }
                            };

                            rpt.DataSource = dataSource;
                            rpt.DataMember = string.Empty;
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidOperationException(
                                $"Failed to bind data source: {ex.Message}", ex);
                        }

                        // Create document
                        try
                        {
                            rpt.CreateDocument();
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidOperationException(
                                $"Failed to create report document: {ex.Message}. " +
                                "This may be caused by expression bindings or data binding issues.", ex);
                        }

                        // Merge documents
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

                    MergedReport = baseRpt;
                }
                catch (Exception ex)
                {
                    MergedReport = null;
                    Console.WriteLine($"Report merge error: {ex.Message}");
                    Console.WriteLine($"Stack trace: {ex.StackTrace}");
                    throw; // Re-throw to let caller handle it
                }
            });
        }
    }
}