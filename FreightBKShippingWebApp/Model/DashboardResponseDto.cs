using System.Text.Json.Serialization;

namespace FreightBKShippingWebApp.Model
{
    public class DashboardResponseDto
    {
        public DashboardStats Stats { get; set; } = new();

        public List<JobTypeData> JobStatusChart { get; set; } = new();

        public List<JobTypeData> JobTypeChart { get; set; } = new();



        public List<MonthlyRevenueDto> MonthlyRevenue { get; set; }


        public class DashboardStats
        {
            public int TotalImportJobs { get; set; }
            public int TotalExportJobs { get; set; }
            public int PendingJobs { get; set; }
            public int CompletedJobs { get; set; }
            public int CancelledJobs { get; set; }
            public int TotalBills { get; set; }
            public float TotalRevenue { get; set; }
            public int ImportJobsThisMonth { get; set; }
            public int ExportJobsThisMonth { get; set; }
            public int BillsThisMonth { get; set; }
            public float RevenueThisMonth { get; set; }
            public int CompletionRate { get; set; }
            public int CancellationRate { get; set; }
        }

        //public class JobStatusData
        //{
        //    public string Label { get; set; } = "";
        //    public int Count { get; set; }
        //}

        public class JobTypeData
        {
            public string Label { get; set; } = "";
            public int Count { get; set; }
        }

        public class MonthlyRevenueDto
        {
            public int Month { get; set; }
            public decimal Amount { get; set; }
            public string MonthName { get; set; }
            public int MonthOrder { get; set; }
        }
    }
}
