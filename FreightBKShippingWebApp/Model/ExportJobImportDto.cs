namespace FreightBKShippingWebApp.Model
{
    public class ExportJobImportDto
    {
        public int RowNo { get; set; }

        public string JobNo { get; set; } = "";

        public DateTime? JobDate { get; set; }

        public string Exporter { get; set; } = "";

        public string Consignee { get; set; } = "";

        public string POL { get; set; } = "";

        public string POD { get; set; } = "";

        public string Vessel { get; set; } = "";

        public string Cargo { get; set; } = "";

        public string SBNo { get; set; } = "";

        public DateTime? SBDate { get; set; }

        public string BLNo { get; set; } = "";

        public DateTime? BLDate { get; set; }

        public string Remarks { get; set; } = "";
    }
    
    public class ExcelColumnMap
    {
        public Dictionary<string, int> Columns { get; set; } = new();

        public bool Has(string name)
        {
            return Columns.ContainsKey(name);
        }

        public int this[string name]
        {
            get
            {
                return Columns[name];
            }
        }
    }
}
