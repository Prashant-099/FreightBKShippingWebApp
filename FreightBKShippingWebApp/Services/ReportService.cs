using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FreightBKShippingWebApp.Model;
using FreightBKShippingWebApp.Services;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraReports.UI;

namespace FreightBKShippingWebApp.Services
{
    public class ReportService
    {


        public XtraReport? MergedReport { get; private set; }

        public ReportService(LoadingService loadingService)
        {
        }

        public async Task CreateMergedReportAsync<TItem, TDto>(
        IEnumerable<TItem> items,
        Func<TItem, TDto?> fetchData,
        byte[] layoutBytes)
        where TDto : class
        {
            XtraReport? baseRpt = null;

            try
            {
                foreach (var item in items)
                {
                    var data = fetchData(item);
                    if (data == null) continue;

                    var rpt = new XtraReport();

                    using (var ms = new MemoryStream(layoutBytes))
                    {
                        rpt.LoadLayout(ms);
                    }

                    rpt.DataSource = new ObjectDataSource
                    {
                        DataSource = new List<TDto> { data }
                    };

                    rpt.CreateDocument();

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
                Console.WriteLine("Merge error: " + ex.Message);
            }
            finally
            {
            }
        }

    }

}
