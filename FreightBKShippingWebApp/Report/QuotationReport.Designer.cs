namespace FreightBKShippingWebApp.Report
{
    partial class QuotationReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.DataAccess.Json.CustomJsonSource customJsonSource1 = new DevExpress.DataAccess.Json.CustomJsonSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuotationReport));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode1 = new DevExpress.DataAccess.Json.JsonSchemaNode("root", true);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode2 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill", true);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode3 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_ack_no", true, DevExpress.DataAccess.Json.JsonNodeType.Property);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode4 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_ack_date", true, DevExpress.DataAccess.Json.JsonNodeType.Property);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode5 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_irn_no", true, DevExpress.DataAccess.Json.JsonNodeType.Property);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode6 = new DevExpress.DataAccess.Json.JsonSchemaNode("billId", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode7 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_no", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode8 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_date", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<System.DateTime>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode9 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_duedate", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<System.DateTime>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode10 = new DevExpress.DataAccess.Json.JsonSchemaNode("account_print_name", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode11 = new DevExpress.DataAccess.Json.JsonSchemaNode("account_state", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode12 = new DevExpress.DataAccess.Json.JsonSchemaNode("account_address1", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode13 = new DevExpress.DataAccess.Json.JsonSchemaNode("account_gstno", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode14 = new DevExpress.DataAccess.Json.JsonSchemaNode("account_panno", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode15 = new DevExpress.DataAccess.Json.JsonSchemaNode("vouchername", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode16 = new DevExpress.DataAccess.Json.JsonSchemaNode("placeofSupply", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode17 = new DevExpress.DataAccess.Json.JsonSchemaNode("shipmentType", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode18 = new DevExpress.DataAccess.Json.JsonSchemaNode("cargo", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode19 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_blno", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode20 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_hblno", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode21 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_sbno", true, DevExpress.DataAccess.Json.JsonNodeType.Property);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode22 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_bldate", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<System.DateTime>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode23 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_hbldate", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<System.DateTime>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode24 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_sbdate", true, DevExpress.DataAccess.Json.JsonNodeType.Property);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode25 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_jobno", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode26 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_jobtype", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode27 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_grosswt", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode28 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_netwt", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode29 = new DevExpress.DataAccess.Json.JsonSchemaNode("vessel", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode30 = new DevExpress.DataAccess.Json.JsonSchemaNode("line", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode31 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_20ft", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode32 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_40ft", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode33 = new DevExpress.DataAccess.Json.JsonSchemaNode("shipper_invno", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode34 = new DevExpress.DataAccess.Json.JsonSchemaNode("shipper", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode35 = new DevExpress.DataAccess.Json.JsonSchemaNode("consignee", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode36 = new DevExpress.DataAccess.Json.JsonSchemaNode("pol", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode37 = new DevExpress.DataAccess.Json.JsonSchemaNode("pod", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode38 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_container_no", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode39 = new DevExpress.DataAccess.Json.JsonSchemaNode("grossAmount", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode40 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_taxableamt", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode41 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_sgst", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<double>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode42 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_cgst", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<double>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode43 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_igst", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode44 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_roundamt", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<double>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode45 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_total", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode46 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_AmountInword", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode47 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_remarks", true, DevExpress.DataAccess.Json.JsonNodeType.Property);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode48 = new DevExpress.DataAccess.Json.JsonSchemaNode("place_of_receipt", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode49 = new DevExpress.DataAccess.Json.JsonSchemaNode("place_of_delivery", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode50 = new DevExpress.DataAccess.Json.JsonSchemaNode("destination", true, DevExpress.DataAccess.Json.JsonNodeType.Property);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode51 = new DevExpress.DataAccess.Json.JsonSchemaNode("company_printname", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode52 = new DevExpress.DataAccess.Json.JsonSchemaNode("company_address1", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode53 = new DevExpress.DataAccess.Json.JsonSchemaNode("company_gstin", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode54 = new DevExpress.DataAccess.Json.JsonSchemaNode("state_Company", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode55 = new DevExpress.DataAccess.Json.JsonSchemaNode("company_mobile", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode56 = new DevExpress.DataAccess.Json.JsonSchemaNode("company_email", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode57 = new DevExpress.DataAccess.Json.JsonSchemaNode("company_panno", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode58 = new DevExpress.DataAccess.Json.JsonSchemaNode("company_website", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode59 = new DevExpress.DataAccess.Json.JsonSchemaNode("bankname", true, DevExpress.DataAccess.Json.JsonNodeType.Property);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode60 = new DevExpress.DataAccess.Json.JsonSchemaNode("bank_branch", true, DevExpress.DataAccess.Json.JsonNodeType.Property);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode61 = new DevExpress.DataAccess.Json.JsonSchemaNode("bank_accountno", true, DevExpress.DataAccess.Json.JsonNodeType.Property);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode62 = new DevExpress.DataAccess.Json.JsonSchemaNode("bank_ifsc", true, DevExpress.DataAccess.Json.JsonNodeType.Property);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode63 = new DevExpress.DataAccess.Json.JsonSchemaNode("bank_address", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode64 = new DevExpress.DataAccess.Json.JsonSchemaNode("billDetails", true, DevExpress.DataAccess.Json.JsonNodeType.Array);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode65 = new DevExpress.DataAccess.Json.JsonSchemaNode("service_printname", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode66 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_hsncode", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode67 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_exchunit", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode68 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_qty", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode69 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_rate", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode70 = new DevExpress.DataAccess.Json.JsonSchemaNode("billDetailActualRate", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode71 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_amount", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode72 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_exchrate", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode73 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_sgst", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<double>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode74 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_cgst", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<double>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode75 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_igst", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode76 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_igstper", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode77 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_taxableamt", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode78 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_total", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<double>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode79 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_sgstper", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<double>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode80 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_cgstper", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<double>));
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.table18 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow83 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell184 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell185 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell187 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow84 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell56 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell191 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell192 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell193 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow85 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell58 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell242 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell243 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell244 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow87 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell83 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell248 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell249 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell250 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow88 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell84 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell254 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell255 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell256 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow90 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell88 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell140 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell139 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell260 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell261 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell262 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow91 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell89 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell142 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell85 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell266 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.table1 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell132 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow19 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell134 = new DevExpress.XtraReports.UI.XRTableCell();
            this.table6 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow47 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell94 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell115 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell170 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell172 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell173 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell174 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell175 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell177 = new DevExpress.XtraReports.UI.XRTableCell();
            this.table5 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow20 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell169 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell95 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell97 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell98 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell100 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell101 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell141 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell146 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell147 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell154 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell155 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell156 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell163 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell166 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell164 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell167 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell165 = new DevExpress.XtraReports.UI.XRTableCell();
            this.table7 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow17 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell178 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell179 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell181 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell180 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell182 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.jsonDataSource1 = new DevExpress.DataAccess.Json.JsonDataSource(this.components);
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.table8 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow18 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell47 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell48 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell49 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow28 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell62 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell68 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow31 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell160 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell52 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell53 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow21 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell171 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow26 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell64 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell65 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell66 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow27 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell67 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell74 = new DevExpress.XtraReports.UI.XRTableCell();
            this.pictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.tableCell70 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell71 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.table4 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow42 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell81 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell188 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow33 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell183 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell186 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupFooter3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.table3 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow23 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell59 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell76 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell77 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell143 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell144 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell145 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell96 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell99 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell107 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow35 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell195 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell196 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell197 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow14 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell127 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell128 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell136 = new DevExpress.XtraReports.UI.XRTableCell();
            this.table19 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow44 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell90 = new DevExpress.XtraReports.UI.XRTableCell();
            this.table15 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow89 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell176 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrCrossBandBox1 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            this.xrCrossBandLine1 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.GroupFooter4 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrCrossBandLine2 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine3 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine4 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine5 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine6 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine7 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine8 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine9 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine10 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine11 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine12 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine13 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine14 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine15 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.DetailReport1 = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail2 = new DevExpress.XtraReports.UI.DetailBand();
            ((System.ComponentModel.ISupportInitialize)(this.table18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 20.83333F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 31.26391F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table18});
            this.GroupHeader1.HeightF = 95.112F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // table18
            // 
            this.table18.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.table18.BorderWidth = 1F;
            this.table18.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.table18.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.table18.Name = "table18";
            this.table18.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.table18.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1,
            this.xrTableRow2,
            this.tableRow83,
            this.tableRow84,
            this.tableRow85,
            this.tableRow87,
            this.tableRow88,
            this.tableRow90,
            this.tableRow91});
            this.table18.SizeF = new System.Drawing.SizeF(797.9583F, 95.112F);
            this.table18.StylePriority.UseBorders = false;
            this.table18.StylePriority.UseBorderWidth = false;
            this.table18.StylePriority.UseFont = false;
            this.table18.StylePriority.UsePadding = false;
            this.table18.StylePriority.UseTextAlignment = false;
            this.table18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 0.625D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[vouchername]")});
            this.xrTableCell1.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F, ((DevExpress.Drawing.DXFontStyle)((DevExpress.Drawing.DXFontStyle.Bold | DevExpress.Drawing.DXFontStyle.Underline))));
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.RowSpan = 2;
            this.xrTableCell1.StylePriority.UseBackColor = false;
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell1.Weight = 13.735071264711D;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell6});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 0.625D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell6.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F, ((DevExpress.Drawing.DXFontStyle)((DevExpress.Drawing.DXFontStyle.Bold | DevExpress.Drawing.DXFontStyle.Underline))));
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseBackColor = false;
            this.xrTableCell6.StylePriority.UseBorders = false;
            this.xrTableCell6.StylePriority.UseFont = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.Text = "xrTableCell6";
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell6.Weight = 13.735071264711D;
            // 
            // tableRow83
            // 
            this.tableRow83.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell37,
            this.tableCell184,
            this.tableCell185,
            this.tableCell187});
            this.tableRow83.Name = "tableRow83";
            this.tableRow83.Weight = 0.625D;
            // 
            // tableCell37
            // 
            this.tableCell37.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.tableCell37.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F, ((DevExpress.Drawing.DXFontStyle)((DevExpress.Drawing.DXFontStyle.Bold | DevExpress.Drawing.DXFontStyle.Underline))));
            this.tableCell37.Multiline = true;
            this.tableCell37.Name = "tableCell37";
            this.tableCell37.StylePriority.UseBorders = false;
            this.tableCell37.StylePriority.UseFont = false;
            this.tableCell37.StylePriority.UseTextAlignment = false;
            this.tableCell37.Text = "Customer ";
            this.tableCell37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.tableCell37.Weight = 6.7343384494952829D;
            // 
            // tableCell184
            // 
            this.tableCell184.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.tableCell184.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[vouchername]")});
            this.tableCell184.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell184.Name = "tableCell184";
            this.tableCell184.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.tableCell184.StylePriority.UseBorders = false;
            this.tableCell184.StylePriority.UseFont = false;
            this.tableCell184.StylePriority.UsePadding = false;
            this.tableCell184.TextFormatString = "{0} No. ";
            this.tableCell184.Weight = 2.353627761814101D;
            // 
            // tableCell185
            // 
            this.tableCell185.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.tableCell185.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell185.Name = "tableCell185";
            this.tableCell185.StylePriority.UseBorders = false;
            this.tableCell185.StylePriority.UseFont = false;
            this.tableCell185.StylePriority.UseTextAlignment = false;
            this.tableCell185.Text = ":";
            this.tableCell185.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell185.Weight = 0.4936166043404408D;
            // 
            // tableCell187
            // 
            this.tableCell187.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell187.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_no]")});
            this.tableCell187.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell187.Name = "tableCell187";
            this.tableCell187.StylePriority.UseBorders = false;
            this.tableCell187.StylePriority.UseFont = false;
            this.tableCell187.Text = "tableCell177";
            this.tableCell187.TextFormatString = "{0:dd/MM/yyyy}";
            this.tableCell187.Weight = 4.1534884490611743D;
            // 
            // tableRow84
            // 
            this.tableRow84.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell56,
            this.tableCell191,
            this.tableCell192,
            this.tableCell193});
            this.tableRow84.Name = "tableRow84";
            this.tableRow84.Weight = 0.625D;
            // 
            // tableCell56
            // 
            this.tableCell56.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell56.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[account_print_name]")});
            this.tableCell56.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell56.Multiline = true;
            this.tableCell56.Name = "tableCell56";
            this.tableCell56.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.tableCell56.StylePriority.UseBorders = false;
            this.tableCell56.StylePriority.UseFont = false;
            this.tableCell56.StylePriority.UsePadding = false;
            this.tableCell56.StylePriority.UseTextAlignment = false;
            this.tableCell56.Text = "tableCell56";
            this.tableCell56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.tableCell56.Weight = 6.7371844827985123D;
            // 
            // tableCell191
            // 
            this.tableCell191.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell191.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[vouchername]")});
            this.tableCell191.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell191.Name = "tableCell191";
            this.tableCell191.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.tableCell191.StylePriority.UseBorders = false;
            this.tableCell191.StylePriority.UseFont = false;
            this.tableCell191.StylePriority.UsePadding = false;
            this.tableCell191.TextFormatString = "{0} Date ";
            this.tableCell191.Weight = 2.3540674777198096D;
            // 
            // tableCell192
            // 
            this.tableCell192.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell192.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell192.Name = "tableCell192";
            this.tableCell192.StylePriority.UseBorders = false;
            this.tableCell192.StylePriority.UseFont = false;
            this.tableCell192.StylePriority.UseTextAlignment = false;
            this.tableCell192.Text = ":";
            this.tableCell192.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell192.Weight = 0.493760193871954D;
            // 
            // tableCell193
            // 
            this.tableCell193.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell193.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_date]")});
            this.tableCell193.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell193.Name = "tableCell193";
            this.tableCell193.StylePriority.UseBorders = false;
            this.tableCell193.StylePriority.UseFont = false;
            this.tableCell193.TextFormatString = "{0:dd-MM-yyyy}";
            this.tableCell193.Weight = 4.1576000126337949D;
            // 
            // tableRow85
            // 
            this.tableRow85.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell58,
            this.tableCell242,
            this.tableCell243,
            this.tableCell244});
            this.tableRow85.Name = "tableRow85";
            this.tableRow85.Weight = 0.625D;
            // 
            // tableCell58
            // 
            this.tableCell58.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell58.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[account_address1]")});
            this.tableCell58.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell58.Multiline = true;
            this.tableCell58.Name = "tableCell58";
            this.tableCell58.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.tableCell58.RowSpan = 3;
            this.tableCell58.StylePriority.UseBorders = false;
            this.tableCell58.StylePriority.UseFont = false;
            this.tableCell58.StylePriority.UsePadding = false;
            this.tableCell58.StylePriority.UseTextAlignment = false;
            this.tableCell58.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.tableCell58.Weight = 6.7371816690637889D;
            // 
            // tableCell242
            // 
            this.tableCell242.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell242.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell242.Name = "tableCell242";
            this.tableCell242.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.tableCell242.StylePriority.UseBorders = false;
            this.tableCell242.StylePriority.UseFont = false;
            this.tableCell242.StylePriority.UsePadding = false;
            this.tableCell242.Text = "Place of Supply";
            this.tableCell242.Weight = 2.3540685265004329D;
            // 
            // tableCell243
            // 
            this.tableCell243.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell243.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell243.Name = "tableCell243";
            this.tableCell243.StylePriority.UseBorders = false;
            this.tableCell243.StylePriority.UseFont = false;
            this.tableCell243.StylePriority.UseTextAlignment = false;
            this.tableCell243.Text = ":";
            this.tableCell243.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell243.Weight = 0.49376225244274558D;
            // 
            // tableCell244
            // 
            this.tableCell244.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell244.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[placeofSupply]")});
            this.tableCell244.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell244.Name = "tableCell244";
            this.tableCell244.StylePriority.UseBorders = false;
            this.tableCell244.StylePriority.UseFont = false;
            this.tableCell244.TextFormatString = "{0:dd-MM-yyyy}";
            this.tableCell244.Weight = 4.15759660972044D;
            // 
            // tableRow87
            // 
            this.tableRow87.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell83,
            this.tableCell248,
            this.tableCell249,
            this.tableCell250});
            this.tableRow87.Name = "tableRow87";
            this.tableRow87.Weight = 0.625D;
            // 
            // tableCell83
            // 
            this.tableCell83.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell83.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F);
            this.tableCell83.Multiline = true;
            this.tableCell83.Name = "tableCell83";
            this.tableCell83.StylePriority.UseBorders = false;
            this.tableCell83.StylePriority.UseFont = false;
            this.tableCell83.Weight = 6.737181669063788D;
            // 
            // tableCell248
            // 
            this.tableCell248.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell248.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell248.Name = "tableCell248";
            this.tableCell248.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.tableCell248.StylePriority.UseBorders = false;
            this.tableCell248.StylePriority.UseFont = false;
            this.tableCell248.StylePriority.UsePadding = false;
            this.tableCell248.Text = "POL";
            this.tableCell248.Weight = 2.3540685265004324D;
            // 
            // tableCell249
            // 
            this.tableCell249.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell249.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell249.Name = "tableCell249";
            this.tableCell249.StylePriority.UseBorders = false;
            this.tableCell249.StylePriority.UseFont = false;
            this.tableCell249.StylePriority.UseTextAlignment = false;
            this.tableCell249.Text = ":";
            this.tableCell249.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell249.Weight = 0.49376225370751253D;
            // 
            // tableCell250
            // 
            this.tableCell250.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell250.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[pol]")});
            this.tableCell250.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell250.Name = "tableCell250";
            this.tableCell250.StylePriority.UseBorders = false;
            this.tableCell250.StylePriority.UseFont = false;
            this.tableCell250.Weight = 4.1575966084556741D;
            // 
            // tableRow88
            // 
            this.tableRow88.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell84,
            this.tableCell254,
            this.tableCell255,
            this.tableCell256});
            this.tableRow88.Name = "tableRow88";
            this.tableRow88.Weight = 0.625D;
            // 
            // tableCell84
            // 
            this.tableCell84.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell84.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F);
            this.tableCell84.Multiline = true;
            this.tableCell84.Name = "tableCell84";
            this.tableCell84.StylePriority.UseBorders = false;
            this.tableCell84.StylePriority.UseFont = false;
            this.tableCell84.Weight = 6.7371833095353963D;
            // 
            // tableCell254
            // 
            this.tableCell254.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell254.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell254.Name = "tableCell254";
            this.tableCell254.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.tableCell254.StylePriority.UseBorders = false;
            this.tableCell254.StylePriority.UseFont = false;
            this.tableCell254.StylePriority.UsePadding = false;
            this.tableCell254.Text = "POD";
            this.tableCell254.Weight = 2.3540674328526947D;
            // 
            // tableCell255
            // 
            this.tableCell255.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell255.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell255.Name = "tableCell255";
            this.tableCell255.StylePriority.UseBorders = false;
            this.tableCell255.StylePriority.UseFont = false;
            this.tableCell255.StylePriority.UseTextAlignment = false;
            this.tableCell255.Text = ":";
            this.tableCell255.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell255.Weight = 0.49375897149953085D;
            // 
            // tableCell256
            // 
            this.tableCell256.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell256.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[pod]")});
            this.tableCell256.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell256.Name = "tableCell256";
            this.tableCell256.StylePriority.UseBorders = false;
            this.tableCell256.StylePriority.UseFont = false;
            this.tableCell256.Weight = 4.1575993438397862D;
            // 
            // tableRow90
            // 
            this.tableRow90.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell88,
            this.tableCell140,
            this.tableCell139,
            this.tableCell260,
            this.tableCell261,
            this.tableCell262});
            this.tableRow90.Name = "tableRow90";
            this.tableRow90.Weight = 0.625D;
            // 
            // tableCell88
            // 
            this.tableCell88.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell88.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell88.Multiline = true;
            this.tableCell88.Name = "tableCell88";
            this.tableCell88.StylePriority.UseBorders = false;
            this.tableCell88.StylePriority.UseFont = false;
            this.tableCell88.Text = "PAN No.";
            this.tableCell88.Weight = 1.1197202137822222D;
            // 
            // tableCell140
            // 
            this.tableCell140.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell140.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell140.Multiline = true;
            this.tableCell140.Name = "tableCell140";
            this.tableCell140.StylePriority.UseBorders = false;
            this.tableCell140.StylePriority.UseFont = false;
            this.tableCell140.StylePriority.UseTextAlignment = false;
            this.tableCell140.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.tableCell140.TextFormatString = ":{0}";
            this.tableCell140.Weight = 2.48705746981269D;
            // 
            // tableCell139
            // 
            this.tableCell139.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell139.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell139.Multiline = true;
            this.tableCell139.Name = "tableCell139";
            this.tableCell139.StylePriority.UseBorders = false;
            this.tableCell139.StylePriority.UseFont = false;
            this.tableCell139.Weight = 3.130406172764288D;
            // 
            // tableCell260
            // 
            this.tableCell260.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell260.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell260.Name = "tableCell260";
            this.tableCell260.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.tableCell260.StylePriority.UseBorders = false;
            this.tableCell260.StylePriority.UseFont = false;
            this.tableCell260.StylePriority.UsePadding = false;
            this.tableCell260.Text = "LINE";
            this.tableCell260.Weight = 2.3540685265004759D;
            // 
            // tableCell261
            // 
            this.tableCell261.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell261.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell261.Name = "tableCell261";
            this.tableCell261.StylePriority.UseBorders = false;
            this.tableCell261.StylePriority.UseFont = false;
            this.tableCell261.StylePriority.UseTextAlignment = false;
            this.tableCell261.Text = ":";
            this.tableCell261.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell261.Weight = 0.49375787911664637D;
            // 
            // tableCell262
            // 
            this.tableCell262.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell262.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[line]")});
            this.tableCell262.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell262.Name = "tableCell262";
            this.tableCell262.StylePriority.UseBorders = false;
            this.tableCell262.StylePriority.UseFont = false;
            this.tableCell262.TextFormatString = "{0}";
            this.tableCell262.Weight = 4.1575987957510847D;
            // 
            // tableRow91
            // 
            this.tableRow91.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell89,
            this.tableCell142,
            this.tableCell85,
            this.tableCell266});
            this.tableRow91.Name = "tableRow91";
            this.tableRow91.Weight = 0.625D;
            // 
            // tableCell89
            // 
            this.tableCell89.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell89.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell89.Multiline = true;
            this.tableCell89.Name = "tableCell89";
            this.tableCell89.StylePriority.UseBorders = false;
            this.tableCell89.StylePriority.UseFont = false;
            this.tableCell89.StylePriority.UseTextAlignment = false;
            this.tableCell89.Text = "GSTN ";
            this.tableCell89.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.tableCell89.Weight = 1.1191058528066944D;
            // 
            // tableCell142
            // 
            this.tableCell142.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell142.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[account_gstno]")});
            this.tableCell142.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell142.Multiline = true;
            this.tableCell142.Name = "tableCell142";
            this.tableCell142.StylePriority.UseBorders = false;
            this.tableCell142.StylePriority.UseFont = false;
            this.tableCell142.StylePriority.UseTextAlignment = false;
            this.tableCell142.Text = "tableCell142";
            this.tableCell142.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.tableCell142.TextFormatString = ":{0}";
            this.tableCell142.Weight = 2.485692887627434D;
            // 
            // tableCell85
            // 
            this.tableCell85.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell85.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'State :\'+[bill].[account_state]")});
            this.tableCell85.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell85.Multiline = true;
            this.tableCell85.Name = "tableCell85";
            this.tableCell85.StylePriority.UseBorders = false;
            this.tableCell85.StylePriority.UseFont = false;
            this.tableCell85.StylePriority.UseTextAlignment = false;
            this.tableCell85.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.tableCell85.Weight = 3.1286857848359677D;
            // 
            // tableCell266
            // 
            this.tableCell266.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell266.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell266.Name = "tableCell266";
            this.tableCell266.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.tableCell266.StylePriority.UseBorders = false;
            this.tableCell266.StylePriority.UseFont = false;
            this.tableCell266.StylePriority.UsePadding = false;
            this.tableCell266.Weight = 7.0015852346462282D;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table1});
            this.GroupHeader2.HeightF = 85.29245F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // table1
            // 
            this.table1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.table1.Name = "table1";
            this.table1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.table1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow1,
            this.tableRow2,
            this.tableRow11,
            this.tableRow19,
            this.tableRow13});
            this.table1.SizeF = new System.Drawing.SizeF(797.9583F, 85.29245F);
            this.table1.StylePriority.UseTextAlignment = false;
            this.table1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // tableRow1
            // 
            this.tableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell1});
            this.tableRow1.Name = "tableRow1";
            this.tableRow1.Weight = 0.50027765746970776D;
            // 
            // tableCell1
            // 
            this.tableCell1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[company_printname]")});
            this.tableCell1.Font = new DevExpress.Drawing.DXFont("Tahoma", 16F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell1.ForeColor = System.Drawing.Color.Red;
            this.tableCell1.Multiline = true;
            this.tableCell1.Name = "tableCell1";
            this.tableCell1.StylePriority.UseFont = false;
            this.tableCell1.StylePriority.UseForeColor = false;
            this.tableCell1.StylePriority.UseTextAlignment = false;
            this.tableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell1.Weight = 3D;
            // 
            // tableRow2
            // 
            this.tableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell4});
            this.tableRow2.Name = "tableRow2";
            this.tableRow2.Weight = 0.38922798819828652D;
            // 
            // tableCell4
            // 
            this.tableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[company_address1]")});
            this.tableCell4.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F);
            this.tableCell4.Multiline = true;
            this.tableCell4.Name = "tableCell4";
            this.tableCell4.StylePriority.UseFont = false;
            this.tableCell4.StylePriority.UseTextAlignment = false;
            this.tableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell4.Weight = 3D;
            // 
            // tableRow11
            // 
            this.tableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell132});
            this.tableRow11.Name = "tableRow11";
            this.tableRow11.Weight = 0.38922798819828652D;
            // 
            // tableCell132
            // 
            this.tableCell132.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'Contact  No:\'+[bill].[company_mobile]")});
            this.tableCell132.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F);
            this.tableCell132.Multiline = true;
            this.tableCell132.Name = "tableCell132";
            this.tableCell132.StylePriority.UseFont = false;
            this.tableCell132.StylePriority.UseTextAlignment = false;
            this.tableCell132.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell132.Weight = 3D;
            // 
            // tableRow19
            // 
            this.tableRow19.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell15});
            this.tableRow19.Name = "tableRow19";
            this.tableRow19.Weight = 0.38922798819828652D;
            // 
            // tableCell15
            // 
            this.tableCell15.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\' Email :\'+  [bill].[company_email] +\' ,  Website : \'+ [bill].[company_website]\n")});
            this.tableCell15.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F);
            this.tableCell15.Multiline = true;
            this.tableCell15.Name = "tableCell15";
            this.tableCell15.StylePriority.UseFont = false;
            this.tableCell15.StylePriority.UseTextAlignment = false;
            this.tableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell15.Weight = 3D;
            // 
            // tableRow13
            // 
            this.tableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell134});
            this.tableRow13.Name = "tableRow13";
            this.tableRow13.Weight = 0.38922798819828652D;
            // 
            // tableCell134
            // 
            this.tableCell134.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'State :\' +[bill].[state_Company]+ \'  GSTIN : \' +[bill].[company_gstin]+\'  PAN :\'" +
                    " + [bill].[company_panno]")});
            this.tableCell134.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell134.Multiline = true;
            this.tableCell134.Name = "tableCell134";
            this.tableCell134.StylePriority.UseFont = false;
            this.tableCell134.StylePriority.UseTextAlignment = false;
            this.tableCell134.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell134.Weight = 3D;
            // 
            // table6
            // 
            this.table6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.table6.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.table6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.table6.Name = "table6";
            this.table6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 4, 0, 0, 100F);
            this.table6.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow47});
            this.table6.SizeF = new System.Drawing.SizeF(799F, 8.490601F);
            this.table6.StylePriority.UseBorders = false;
            this.table6.StylePriority.UseFont = false;
            this.table6.StylePriority.UsePadding = false;
            // 
            // tableRow47
            // 
            this.tableRow47.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.tableRow47.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell35,
            this.tableCell36,
            this.tableCell41,
            this.tableCell94,
            this.tableCell38,
            this.xrTableCell4,
            this.tableCell39,
            this.tableCell115,
            this.tableCell170,
            this.xrTableCell12,
            this.xrTableCell13,
            this.tableCell172,
            this.tableCell173,
            this.tableCell174,
            this.tableCell175,
            this.tableCell177});
            this.tableRow47.Name = "tableRow47";
            this.tableRow47.StylePriority.UseBorders = false;
            this.tableRow47.StylePriority.UseTextAlignment = false;
            this.tableRow47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableRow47.Weight = 0.6D;
            // 
            // tableCell35
            // 
            this.tableCell35.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell35.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[DataSource.CurrentRowIndex]+1\n")});
            this.tableCell35.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.tableCell35.Name = "tableCell35";
            this.tableCell35.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 4, 0, 0, 100F);
            this.tableCell35.StylePriority.UseBorders = false;
            this.tableCell35.StylePriority.UseFont = false;
            this.tableCell35.StylePriority.UsePadding = false;
            this.tableCell35.StylePriority.UseTextAlignment = false;
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            this.tableCell35.Summary = xrSummary1;
            this.tableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell35.Weight = 0.32247296585491003D;
            // 
            // tableCell36
            // 
            this.tableCell36.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell36.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[service_printname]")});
            this.tableCell36.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.tableCell36.Name = "tableCell36";
            this.tableCell36.StylePriority.UseBorders = false;
            this.tableCell36.StylePriority.UseFont = false;
            this.tableCell36.StylePriority.UseTextAlignment = false;
            this.tableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.tableCell36.Weight = 2.7809718087756812D;
            // 
            // tableCell41
            // 
            this.tableCell41.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell41.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[bill_detail_hsncode]")});
            this.tableCell41.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.tableCell41.Multiline = true;
            this.tableCell41.Name = "tableCell41";
            this.tableCell41.StylePriority.UseBorders = false;
            this.tableCell41.StylePriority.UseFont = false;
            this.tableCell41.StylePriority.UseTextAlignment = false;
            this.tableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell41.Weight = 0.53455370850734019D;
            // 
            // tableCell94
            // 
            this.tableCell94.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell94.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[bill_detail_exchunit]")});
            this.tableCell94.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.tableCell94.Multiline = true;
            this.tableCell94.Name = "tableCell94";
            this.tableCell94.StylePriority.UseBorders = false;
            this.tableCell94.StylePriority.UseFont = false;
            this.tableCell94.StylePriority.UseTextAlignment = false;
            this.tableCell94.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell94.Weight = 0.49588379142144612D;
            // 
            // tableCell38
            // 
            this.tableCell38.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell38.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[bill_detail_rate]")});
            this.tableCell38.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.tableCell38.Name = "tableCell38";
            this.tableCell38.StylePriority.UseBorders = false;
            this.tableCell38.StylePriority.UseFont = false;
            this.tableCell38.StylePriority.UseTextAlignment = false;
            this.tableCell38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell38.TextFormatString = "{0:0.00}";
            this.tableCell38.Weight = 0.57193478988991275D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[billDetailActualRate]")});
            this.xrTableCell4.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseBorders = false;
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell4.TextFormatString = "{0:0.00}";
            this.xrTableCell4.Weight = 0.62984830686611593D;
            // 
            // tableCell39
            // 
            this.tableCell39.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell39.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[bill_detail_qty]")});
            this.tableCell39.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.tableCell39.Name = "tableCell39";
            this.tableCell39.StylePriority.UseBorders = false;
            this.tableCell39.StylePriority.UseFont = false;
            this.tableCell39.StylePriority.UseTextAlignment = false;
            this.tableCell39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell39.TextFormatString = "{0:0.00}";
            this.tableCell39.Weight = 0.44840418139061355D;
            // 
            // tableCell115
            // 
            this.tableCell115.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell115.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[bill_detail_amount]")});
            this.tableCell115.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.tableCell115.Name = "tableCell115";
            this.tableCell115.StylePriority.UseBorders = false;
            this.tableCell115.StylePriority.UseFont = false;
            this.tableCell115.StylePriority.UseTextAlignment = false;
            this.tableCell115.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell115.TextFormatString = "{0:0.000}";
            this.tableCell115.Weight = 0.81907072346177079D;
            // 
            // tableCell170
            // 
            this.tableCell170.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell170.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[bill_detail_exchrate]")});
            this.tableCell170.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.tableCell170.Name = "tableCell170";
            this.tableCell170.StylePriority.UseBorders = false;
            this.tableCell170.StylePriority.UseFont = false;
            this.tableCell170.StylePriority.UseTextAlignment = false;
            this.tableCell170.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell170.TextFormatString = "{0:0.00}";
            this.tableCell170.Weight = 0.53487003454165083D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell12.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[bill_detail_igstper]")});
            this.xrTableCell12.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.xrTableCell12.Multiline = true;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StylePriority.UseBorders = false;
            this.xrTableCell12.StylePriority.UseFont = false;
            this.xrTableCell12.StylePriority.UseTextAlignment = false;
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell12.Weight = 0.26788070044667861D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTableCell13.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[bill_detail_igst]")});
            this.xrTableCell13.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.xrTableCell13.Multiline = true;
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.StylePriority.UseBorders = false;
            this.xrTableCell13.StylePriority.UseFont = false;
            this.xrTableCell13.StylePriority.UseTextAlignment = false;
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell13.TextFormatString = "{0:0.00}";
            this.xrTableCell13.Weight = 0.59103691434229977D;
            // 
            // tableCell172
            // 
            this.tableCell172.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell172.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[bill_detail_cgstper]")});
            this.tableCell172.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.tableCell172.Multiline = true;
            this.tableCell172.Name = "tableCell172";
            this.tableCell172.StylePriority.UseBorders = false;
            this.tableCell172.StylePriority.UseFont = false;
            this.tableCell172.StylePriority.UseTextAlignment = false;
            this.tableCell172.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell172.Weight = 0.26429570987132689D;
            // 
            // tableCell173
            // 
            this.tableCell173.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell173.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill_detail_cgst]")});
            this.tableCell173.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.tableCell173.Multiline = true;
            this.tableCell173.Name = "tableCell173";
            this.tableCell173.StylePriority.UseBorders = false;
            this.tableCell173.StylePriority.UseFont = false;
            this.tableCell173.StylePriority.UseTextAlignment = false;
            this.tableCell173.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell173.TextFormatString = "{0:0.00}";
            this.tableCell173.Weight = 0.59703246191194748D;
            // 
            // tableCell174
            // 
            this.tableCell174.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell174.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[bill_detail_sgstper]")});
            this.tableCell174.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.tableCell174.Multiline = true;
            this.tableCell174.Name = "tableCell174";
            this.tableCell174.StylePriority.UseBorders = false;
            this.tableCell174.StylePriority.UseFont = false;
            this.tableCell174.StylePriority.UseTextAlignment = false;
            this.tableCell174.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell174.Weight = 0.33178730207291629D;
            // 
            // tableCell175
            // 
            this.tableCell175.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell175.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[bill_detail_sgst]")});
            this.tableCell175.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.tableCell175.Multiline = true;
            this.tableCell175.Name = "tableCell175";
            this.tableCell175.StylePriority.UseBorders = false;
            this.tableCell175.StylePriority.UseFont = false;
            this.tableCell175.StylePriority.UseTextAlignment = false;
            this.tableCell175.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell175.TextFormatString = "{0:0.00}";
            this.tableCell175.Weight = 0.62254960908120716D;
            // 
            // tableCell177
            // 
            this.tableCell177.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell177.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[bill_detail_total]")});
            this.tableCell177.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.tableCell177.Multiline = true;
            this.tableCell177.Name = "tableCell177";
            this.tableCell177.StylePriority.UseBorders = false;
            this.tableCell177.StylePriority.UseFont = false;
            this.tableCell177.StylePriority.UseTextAlignment = false;
            this.tableCell177.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell177.TextFormatString = "{0:0.000}";
            this.tableCell177.Weight = 0.81954495768997082D;
            // 
            // table5
            // 
            this.table5.BackColor = System.Drawing.Color.LightSkyBlue;
            this.table5.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.table5.LocationFloat = new DevExpress.Utils.PointFloat(0.5706108F, 0F);
            this.table5.Name = "table5";
            this.table5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.table5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow20,
            this.tableRow5});
            this.table5.SizeF = new System.Drawing.SizeF(798.4294F, 27.52651F);
            this.table5.StylePriority.UseBackColor = false;
            this.table5.StylePriority.UseFont = false;
            this.table5.StylePriority.UsePadding = false;
            // 
            // tableRow20
            // 
            this.tableRow20.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.tableRow20.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell22,
            this.tableCell23,
            this.tableCell40,
            this.tableCell24,
            this.tableCell25,
            this.xrTableCell2,
            this.tableCell26,
            this.tableCell27,
            this.tableCell169,
            this.xrTableCell9,
            this.tableCell95,
            this.tableCell97,
            this.tableCell98});
            this.tableRow20.Name = "tableRow20";
            this.tableRow20.StylePriority.UseBorders = false;
            this.tableRow20.StylePriority.UseTextAlignment = false;
            this.tableRow20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableRow20.Weight = 0.6D;
            // 
            // tableCell22
            // 
            this.tableCell22.BackColor = System.Drawing.Color.Transparent;
            this.tableCell22.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell22.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell22.Multiline = true;
            this.tableCell22.Name = "tableCell22";
            this.tableCell22.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 2, 0, 0, 100F);
            this.tableCell22.RowSpan = 2;
            this.tableCell22.StylePriority.UseBackColor = false;
            this.tableCell22.StylePriority.UseBorders = false;
            this.tableCell22.StylePriority.UseFont = false;
            this.tableCell22.StylePriority.UsePadding = false;
            this.tableCell22.Text = "Sr No";
            this.tableCell22.Weight = 0.2463229602110098D;
            // 
            // tableCell23
            // 
            this.tableCell23.BackColor = System.Drawing.Color.Transparent;
            this.tableCell23.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell23.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell23.Name = "tableCell23";
            this.tableCell23.RowSpan = 2;
            this.tableCell23.StylePriority.UseBackColor = false;
            this.tableCell23.StylePriority.UseBorders = false;
            this.tableCell23.StylePriority.UseFont = false;
            this.tableCell23.Text = "Description";
            this.tableCell23.Weight = 2.3709779701132656D;
            // 
            // tableCell40
            // 
            this.tableCell40.BackColor = System.Drawing.Color.Transparent;
            this.tableCell40.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell40.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell40.Multiline = true;
            this.tableCell40.Name = "tableCell40";
            this.tableCell40.RowSpan = 2;
            this.tableCell40.StylePriority.UseBackColor = false;
            this.tableCell40.StylePriority.UseBorders = false;
            this.tableCell40.StylePriority.UseFont = false;
            this.tableCell40.Text = "HSN";
            this.tableCell40.Weight = 0.45364689348137477D;
            // 
            // tableCell24
            // 
            this.tableCell24.BackColor = System.Drawing.Color.Transparent;
            this.tableCell24.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell24.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell24.Multiline = true;
            this.tableCell24.Name = "tableCell24";
            this.tableCell24.RowSpan = 2;
            this.tableCell24.StylePriority.UseBackColor = false;
            this.tableCell24.StylePriority.UseBorders = false;
            this.tableCell24.StylePriority.UseFont = false;
            this.tableCell24.Text = "Curr";
            this.tableCell24.Weight = 0.42895512465005015D;
            // 
            // tableCell25
            // 
            this.tableCell25.BackColor = System.Drawing.Color.Transparent;
            this.tableCell25.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell25.BorderWidth = 1F;
            this.tableCell25.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell25.Name = "tableCell25";
            this.tableCell25.RowSpan = 2;
            this.tableCell25.StylePriority.UseBackColor = false;
            this.tableCell25.StylePriority.UseBorders = false;
            this.tableCell25.StylePriority.UseBorderWidth = false;
            this.tableCell25.StylePriority.UseFont = false;
            this.tableCell25.StylePriority.UseTextAlignment = false;
            this.tableCell25.Text = "S.Rate";
            this.tableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell25.Weight = 0.48332577048879383D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell2.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.RowSpan = 2;
            this.xrTableCell2.StylePriority.UseBackColor = false;
            this.xrTableCell2.StylePriority.UseBorders = false;
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "P.Rate";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell2.Weight = 0.52376978501006266D;
            // 
            // tableCell26
            // 
            this.tableCell26.BackColor = System.Drawing.Color.Transparent;
            this.tableCell26.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell26.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell26.Name = "tableCell26";
            this.tableCell26.RowSpan = 2;
            this.tableCell26.StylePriority.UseBackColor = false;
            this.tableCell26.StylePriority.UseBorders = false;
            this.tableCell26.StylePriority.UseFont = false;
            this.tableCell26.Text = "Qty";
            this.tableCell26.Weight = 0.37594272534483247D;
            // 
            // tableCell27
            // 
            this.tableCell27.BackColor = System.Drawing.Color.Transparent;
            this.tableCell27.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell27.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell27.Name = "tableCell27";
            this.tableCell27.RowSpan = 2;
            this.tableCell27.StylePriority.UseBackColor = false;
            this.tableCell27.StylePriority.UseBorders = false;
            this.tableCell27.StylePriority.UseFont = false;
            this.tableCell27.StylePriority.UseTextAlignment = false;
            this.tableCell27.Text = "Amount";
            this.tableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell27.Weight = 0.69621079186857493D;
            // 
            // tableCell169
            // 
            this.tableCell169.BackColor = System.Drawing.Color.Transparent;
            this.tableCell169.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell169.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell169.Name = "tableCell169";
            this.tableCell169.RowSpan = 2;
            this.tableCell169.StylePriority.UseBackColor = false;
            this.tableCell169.StylePriority.UseBorders = false;
            this.tableCell169.StylePriority.UseFont = false;
            this.tableCell169.Text = "Ex. Rate";
            this.tableCell169.Weight = 0.45244473296062754D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell9.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell9.Multiline = true;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseBackColor = false;
            this.xrTableCell9.StylePriority.UseBorders = false;
            this.xrTableCell9.StylePriority.UseFont = false;
            this.xrTableCell9.Text = "IGST";
            this.xrTableCell9.Weight = 0.72270689730636062D;
            // 
            // tableCell95
            // 
            this.tableCell95.BackColor = System.Drawing.Color.Transparent;
            this.tableCell95.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell95.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell95.Multiline = true;
            this.tableCell95.Name = "tableCell95";
            this.tableCell95.StylePriority.UseBackColor = false;
            this.tableCell95.StylePriority.UseBorders = false;
            this.tableCell95.StylePriority.UseFont = false;
            this.tableCell95.Text = "CGST ";
            this.tableCell95.Weight = 0.72118859207817487D;
            // 
            // tableCell97
            // 
            this.tableCell97.BackColor = System.Drawing.Color.Transparent;
            this.tableCell97.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell97.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell97.Multiline = true;
            this.tableCell97.Name = "tableCell97";
            this.tableCell97.StylePriority.UseBackColor = false;
            this.tableCell97.StylePriority.UseBorders = false;
            this.tableCell97.StylePriority.UseFont = false;
            this.tableCell97.Text = "SGST";
            this.tableCell97.Weight = 0.81193879907378386D;
            // 
            // tableCell98
            // 
            this.tableCell98.BackColor = System.Drawing.Color.Transparent;
            this.tableCell98.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell98.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell98.Multiline = true;
            this.tableCell98.Name = "tableCell98";
            this.tableCell98.RowSpan = 2;
            this.tableCell98.StylePriority.UseBackColor = false;
            this.tableCell98.StylePriority.UseBorders = false;
            this.tableCell98.StylePriority.UseFont = false;
            this.tableCell98.Text = "TOTAL Amount";
            this.tableCell98.Weight = 0.699836413051498D;
            // 
            // tableRow5
            // 
            this.tableRow5.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.tableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell100,
            this.tableCell101,
            this.tableCell141,
            this.tableCell146,
            this.tableCell147,
            this.xrTableCell3,
            this.tableCell154,
            this.tableCell155,
            this.tableCell156,
            this.xrTableCell10,
            this.xrTableCell11,
            this.tableCell163,
            this.tableCell166,
            this.tableCell164,
            this.tableCell167,
            this.tableCell165});
            this.tableRow5.Name = "tableRow5";
            this.tableRow5.StylePriority.UseBorders = false;
            this.tableRow5.StylePriority.UseTextAlignment = false;
            this.tableRow5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableRow5.Weight = 0.6D;
            // 
            // tableCell100
            // 
            this.tableCell100.BackColor = System.Drawing.Color.Transparent;
            this.tableCell100.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.tableCell100.Font = new DevExpress.Drawing.DXFont("Calibri", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell100.Multiline = true;
            this.tableCell100.Name = "tableCell100";
            this.tableCell100.StylePriority.UseBackColor = false;
            this.tableCell100.StylePriority.UseBorders = false;
            this.tableCell100.StylePriority.UseFont = false;
            this.tableCell100.Text = "No";
            this.tableCell100.Weight = 0.24632296021100983D;
            // 
            // tableCell101
            // 
            this.tableCell101.BackColor = System.Drawing.Color.Transparent;
            this.tableCell101.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.tableCell101.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell101.Multiline = true;
            this.tableCell101.Name = "tableCell101";
            this.tableCell101.StylePriority.UseBackColor = false;
            this.tableCell101.StylePriority.UseBorders = false;
            this.tableCell101.StylePriority.UseFont = false;
            this.tableCell101.Weight = 2.3709777983575395D;
            // 
            // tableCell141
            // 
            this.tableCell141.BackColor = System.Drawing.Color.Transparent;
            this.tableCell141.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.tableCell141.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell141.Multiline = true;
            this.tableCell141.Name = "tableCell141";
            this.tableCell141.StylePriority.UseBackColor = false;
            this.tableCell141.StylePriority.UseBorders = false;
            this.tableCell141.StylePriority.UseFont = false;
            this.tableCell141.Text = "HSN";
            this.tableCell141.Weight = 0.45364689348137488D;
            // 
            // tableCell146
            // 
            this.tableCell146.BackColor = System.Drawing.Color.Transparent;
            this.tableCell146.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.tableCell146.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell146.Multiline = true;
            this.tableCell146.Name = "tableCell146";
            this.tableCell146.StylePriority.UseBackColor = false;
            this.tableCell146.StylePriority.UseBorders = false;
            this.tableCell146.StylePriority.UseFont = false;
            this.tableCell146.Weight = 0.4289551246500502D;
            // 
            // tableCell147
            // 
            this.tableCell147.BackColor = System.Drawing.Color.Transparent;
            this.tableCell147.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.tableCell147.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell147.Multiline = true;
            this.tableCell147.Name = "tableCell147";
            this.tableCell147.StylePriority.UseBackColor = false;
            this.tableCell147.StylePriority.UseBorders = false;
            this.tableCell147.StylePriority.UseFont = false;
            this.tableCell147.Weight = 0.4833257872387855D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell3.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell3.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseBackColor = false;
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.Text = "xrTableCell3";
            this.xrTableCell3.Weight = 0.52376978501006255D;
            // 
            // tableCell154
            // 
            this.tableCell154.BackColor = System.Drawing.Color.Transparent;
            this.tableCell154.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.tableCell154.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell154.Multiline = true;
            this.tableCell154.Name = "tableCell154";
            this.tableCell154.StylePriority.UseBackColor = false;
            this.tableCell154.StylePriority.UseBorders = false;
            this.tableCell154.StylePriority.UseFont = false;
            this.tableCell154.Weight = 0.37594272534483247D;
            // 
            // tableCell155
            // 
            this.tableCell155.BackColor = System.Drawing.Color.Transparent;
            this.tableCell155.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.tableCell155.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell155.Multiline = true;
            this.tableCell155.Name = "tableCell155";
            this.tableCell155.StylePriority.UseBackColor = false;
            this.tableCell155.StylePriority.UseBorders = false;
            this.tableCell155.StylePriority.UseFont = false;
            this.tableCell155.Weight = 0.696210791868575D;
            // 
            // tableCell156
            // 
            this.tableCell156.BackColor = System.Drawing.Color.Transparent;
            this.tableCell156.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.tableCell156.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell156.Multiline = true;
            this.tableCell156.Name = "tableCell156";
            this.tableCell156.StylePriority.UseBackColor = false;
            this.tableCell156.StylePriority.UseBorders = false;
            this.tableCell156.StylePriority.UseFont = false;
            this.tableCell156.Weight = 0.45244481588083935D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell10.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell10.Multiline = true;
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StylePriority.UseBackColor = false;
            this.xrTableCell10.StylePriority.UseBorders = false;
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.Text = "%";
            this.xrTableCell10.Weight = 0.22659939679671565D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell11.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell11.Multiline = true;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.StylePriority.UseBackColor = false;
            this.xrTableCell11.StylePriority.UseBorders = false;
            this.xrTableCell11.StylePriority.UseFont = false;
            this.xrTableCell11.Text = "Tax";
            this.xrTableCell11.Weight = 0.49995619410397829D;
            // 
            // tableCell163
            // 
            this.tableCell163.BackColor = System.Drawing.Color.Transparent;
            this.tableCell163.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.tableCell163.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell163.Multiline = true;
            this.tableCell163.Name = "tableCell163";
            this.tableCell163.StylePriority.UseBackColor = false;
            this.tableCell163.StylePriority.UseBorders = false;
            this.tableCell163.StylePriority.UseFont = false;
            this.tableCell163.StylePriority.UseTextAlignment = false;
            this.tableCell163.Text = "%";
            this.tableCell163.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell163.Weight = 0.22356757065818983D;
            // 
            // tableCell166
            // 
            this.tableCell166.BackColor = System.Drawing.Color.Transparent;
            this.tableCell166.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.tableCell166.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell166.Multiline = true;
            this.tableCell166.Name = "tableCell166";
            this.tableCell166.StylePriority.UseBackColor = false;
            this.tableCell166.StylePriority.UseBorders = false;
            this.tableCell166.StylePriority.UseFont = false;
            this.tableCell166.Text = "Tax";
            this.tableCell166.Weight = 0.49377297487250627D;
            // 
            // tableCell164
            // 
            this.tableCell164.BackColor = System.Drawing.Color.Transparent;
            this.tableCell164.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell164.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell164.Multiline = true;
            this.tableCell164.Name = "tableCell164";
            this.tableCell164.StylePriority.UseBackColor = false;
            this.tableCell164.StylePriority.UseBorders = false;
            this.tableCell164.StylePriority.UseFont = false;
            this.tableCell164.StylePriority.UseTextAlignment = false;
            this.tableCell164.Text = "%";
            this.tableCell164.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell164.Weight = 0.2919119092169502D;
            // 
            // tableCell167
            // 
            this.tableCell167.BackColor = System.Drawing.Color.Transparent;
            this.tableCell167.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell167.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell167.Multiline = true;
            this.tableCell167.Name = "tableCell167";
            this.tableCell167.StylePriority.UseBackColor = false;
            this.tableCell167.StylePriority.UseBorders = false;
            this.tableCell167.StylePriority.UseFont = false;
            this.tableCell167.Text = "Tax";
            this.tableCell167.Weight = 0.52002688326107027D;
            // 
            // tableCell165
            // 
            this.tableCell165.BackColor = System.Drawing.Color.Transparent;
            this.tableCell165.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.tableCell165.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell165.Multiline = true;
            this.tableCell165.Name = "tableCell165";
            this.tableCell165.StylePriority.UseBackColor = false;
            this.tableCell165.StylePriority.UseBorders = false;
            this.tableCell165.StylePriority.UseFont = false;
            this.tableCell165.Weight = 0.69983584468592952D;
            // 
            // table7
            // 
            this.table7.BackColor = System.Drawing.Color.LightSkyBlue;
            this.table7.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.table7.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.table7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.table7.Name = "table7";
            this.table7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.table7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow17});
            this.table7.SizeF = new System.Drawing.SizeF(799F, 19.99999F);
            this.table7.StylePriority.UseBackColor = false;
            this.table7.StylePriority.UseBorders = false;
            this.table7.StylePriority.UseFont = false;
            this.table7.StylePriority.UsePadding = false;
            this.table7.StylePriority.UseTextAlignment = false;
            this.table7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // tableRow17
            // 
            this.tableRow17.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableRow17.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell32,
            this.tableCell30,
            this.tableCell178,
            this.tableCell179,
            this.xrTableCell14,
            this.xrTableCell15,
            this.tableCell181,
            this.tableCell180,
            this.tableCell182,
            this.tableCell42});
            this.tableRow17.Name = "tableRow17";
            this.tableRow17.StylePriority.UseBorders = false;
            this.tableRow17.StylePriority.UseTextAlignment = false;
            this.tableRow17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableRow17.Weight = 0.6D;
            // 
            // tableCell32
            // 
            this.tableCell32.BackColor = System.Drawing.Color.Transparent;
            this.tableCell32.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell32.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell32.Name = "tableCell32";
            this.tableCell32.StylePriority.UseBackColor = false;
            this.tableCell32.StylePriority.UseBorders = false;
            this.tableCell32.StylePriority.UseFont = false;
            this.tableCell32.StylePriority.UseTextAlignment = false;
            this.tableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell32.Weight = 0.20181112203625018D;
            // 
            // tableCell30
            // 
            this.tableCell30.BackColor = System.Drawing.Color.Transparent;
            this.tableCell30.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell30.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell30.Multiline = true;
            this.tableCell30.Name = "tableCell30";
            this.tableCell30.StylePriority.UseBackColor = false;
            this.tableCell30.StylePriority.UseBorders = false;
            this.tableCell30.StylePriority.UseFont = false;
            this.tableCell30.StylePriority.UseTextAlignment = false;
            this.tableCell30.Text = "Total";
            this.tableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.tableCell30.Weight = 3.30836503555939D;
            // 
            // tableCell178
            // 
            this.tableCell178.BackColor = System.Drawing.Color.Transparent;
            this.tableCell178.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell178.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell178.Multiline = true;
            this.tableCell178.Name = "tableCell178";
            this.tableCell178.StylePriority.UseBackColor = false;
            this.tableCell178.StylePriority.UseBorders = false;
            this.tableCell178.StylePriority.UseFont = false;
            this.tableCell178.Weight = 0.62221158360490769D;
            // 
            // tableCell179
            // 
            this.tableCell179.BackColor = System.Drawing.Color.Transparent;
            this.tableCell179.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell179.Font = new DevExpress.Drawing.DXFont("Calibri", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell179.Multiline = true;
            this.tableCell179.Name = "tableCell179";
            this.tableCell179.StylePriority.UseBackColor = false;
            this.tableCell179.StylePriority.UseBorders = false;
            this.tableCell179.StylePriority.UseFont = false;
            this.tableCell179.Weight = 0.5023788994169035D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell14.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([bill_detail_igst])")});
            this.xrTableCell14.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell14.Multiline = true;
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.StylePriority.UseBackColor = false;
            this.xrTableCell14.StylePriority.UseBorders = false;
            this.xrTableCell14.StylePriority.UseFont = false;
            this.xrTableCell14.StylePriority.UseTextAlignment = false;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrTableCell14.Summary = xrSummary2;
            this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.xrTableCell14.TextFormatString = "{0:0.00}";
            this.xrTableCell14.Weight = 0.36703624871589158D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell15.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell15.Font = new DevExpress.Drawing.DXFont("Tahoma 8pt", 8.25F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell15.Multiline = true;
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.StylePriority.UseBackColor = false;
            this.xrTableCell15.StylePriority.UseBorders = false;
            this.xrTableCell15.StylePriority.UseFont = false;
            this.xrTableCell15.Weight = 0.16824985444384094D;
            // 
            // tableCell181
            // 
            this.tableCell181.BackColor = System.Drawing.Color.Transparent;
            this.tableCell181.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell181.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([bill_detail_cgst])")});
            this.tableCell181.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell181.Multiline = true;
            this.tableCell181.Name = "tableCell181";
            this.tableCell181.StylePriority.UseBackColor = false;
            this.tableCell181.StylePriority.UseBorders = false;
            this.tableCell181.StylePriority.UseFont = false;
            this.tableCell181.StylePriority.UseTextAlignment = false;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.tableCell181.Summary = xrSummary3;
            this.tableCell181.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell181.TextFormatString = "{0:0.00}";
            this.tableCell181.Weight = 0.37363577023342665D;
            // 
            // tableCell180
            // 
            this.tableCell180.BackColor = System.Drawing.Color.Transparent;
            this.tableCell180.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell180.Font = new DevExpress.Drawing.DXFont("Calibri", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell180.Multiline = true;
            this.tableCell180.Name = "tableCell180";
            this.tableCell180.StylePriority.UseBackColor = false;
            this.tableCell180.StylePriority.UseBorders = false;
            this.tableCell180.StylePriority.UseFont = false;
            this.tableCell180.Weight = 0.20763844339865631D;
            // 
            // tableCell182
            // 
            this.tableCell182.BackColor = System.Drawing.Color.Transparent;
            this.tableCell182.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell182.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([bill_detail_sgst])")});
            this.tableCell182.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell182.Multiline = true;
            this.tableCell182.Name = "tableCell182";
            this.tableCell182.StylePriority.UseBackColor = false;
            this.tableCell182.StylePriority.UseBorders = false;
            this.tableCell182.StylePriority.UseFont = false;
            this.tableCell182.StylePriority.UseTextAlignment = false;
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.tableCell182.Summary = xrSummary4;
            this.tableCell182.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell182.TextFormatString = "{0:0.00}";
            this.tableCell182.Weight = 0.38960548394422945D;
            // 
            // tableCell42
            // 
            this.tableCell42.BackColor = System.Drawing.Color.Transparent;
            this.tableCell42.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell42.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([bill_detail_total])")});
            this.tableCell42.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell42.Name = "tableCell42";
            this.tableCell42.StylePriority.UseBackColor = false;
            this.tableCell42.StylePriority.UseBorders = false;
            this.tableCell42.StylePriority.UseFont = false;
            this.tableCell42.StylePriority.UseTextAlignment = false;
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.tableCell42.Summary = xrSummary5;
            this.tableCell42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell42.TextFormatString = "{0:0.000}";
            this.tableCell42.Weight = 0.51288872007724584D;
            // 
            // jsonDataSource1
            // 
            this.jsonDataSource1.ConnectionName = null;
            customJsonSource1.Json = resources.GetString("customJsonSource1.Json");
            this.jsonDataSource1.JsonSource = customJsonSource1;
            this.jsonDataSource1.Name = "jsonDataSource1";
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode3);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode4);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode5);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode6);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode7);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode8);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode9);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode10);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode11);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode12);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode13);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode14);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode15);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode16);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode17);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode18);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode19);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode20);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode21);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode22);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode23);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode24);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode25);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode26);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode27);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode28);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode29);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode30);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode31);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode32);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode33);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode34);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode35);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode36);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode37);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode38);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode39);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode40);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode41);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode42);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode43);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode44);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode45);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode46);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode47);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode48);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode49);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode50);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode51);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode52);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode53);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode54);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode55);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode56);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode57);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode58);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode59);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode60);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode61);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode62);
            jsonSchemaNode2.Nodes.Add(jsonSchemaNode63);
            jsonSchemaNode64.Nodes.Add(jsonSchemaNode65);
            jsonSchemaNode64.Nodes.Add(jsonSchemaNode66);
            jsonSchemaNode64.Nodes.Add(jsonSchemaNode67);
            jsonSchemaNode64.Nodes.Add(jsonSchemaNode68);
            jsonSchemaNode64.Nodes.Add(jsonSchemaNode69);
            jsonSchemaNode64.Nodes.Add(jsonSchemaNode70);
            jsonSchemaNode64.Nodes.Add(jsonSchemaNode71);
            jsonSchemaNode64.Nodes.Add(jsonSchemaNode72);
            jsonSchemaNode64.Nodes.Add(jsonSchemaNode73);
            jsonSchemaNode64.Nodes.Add(jsonSchemaNode74);
            jsonSchemaNode64.Nodes.Add(jsonSchemaNode75);
            jsonSchemaNode64.Nodes.Add(jsonSchemaNode76);
            jsonSchemaNode64.Nodes.Add(jsonSchemaNode77);
            jsonSchemaNode64.Nodes.Add(jsonSchemaNode78);
            jsonSchemaNode64.Nodes.Add(jsonSchemaNode79);
            jsonSchemaNode64.Nodes.Add(jsonSchemaNode80);
            jsonSchemaNode1.Nodes.Add(jsonSchemaNode2);
            jsonSchemaNode1.Nodes.Add(jsonSchemaNode64);
            this.jsonDataSource1.Schema = jsonSchemaNode1;
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table8,
            this.xrLine1,
            this.table4});
            this.GroupFooter2.HeightF = 83.56089F;
            this.GroupFooter2.KeepTogether = true;
            this.GroupFooter2.Name = "GroupFooter2";
            this.GroupFooter2.PrintAtBottom = true;
            // 
            // table8
            // 
            this.table8.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8F);
            this.table8.LocationFloat = new DevExpress.Utils.PointFloat(599.9653F, 0F);
            this.table8.Name = "table8";
            this.table8.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 1, 0, 100F);
            this.table8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow18,
            this.tableRow28,
            this.tableRow31,
            this.tableRow21,
            this.tableRow26,
            this.tableRow27});
            this.table8.SizeF = new System.Drawing.SizeF(197.9929F, 81.56089F);
            this.table8.StylePriority.UseFont = false;
            this.table8.StylePriority.UsePadding = false;
            // 
            // tableRow18
            // 
            this.tableRow18.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell47,
            this.tableCell48,
            this.tableCell49});
            this.tableRow18.Name = "tableRow18";
            this.tableRow18.Weight = 0.625D;
            // 
            // tableCell47
            // 
            this.tableCell47.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell47.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell47.Name = "tableCell47";
            this.tableCell47.StylePriority.UseBorders = false;
            this.tableCell47.StylePriority.UseFont = false;
            this.tableCell47.Text = "Taxable Amount";
            this.tableCell47.Weight = 1.486545078392181D;
            // 
            // tableCell48
            // 
            this.tableCell48.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell48.Font = new DevExpress.Drawing.DXFont("Segoe UI", 9.75F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell48.Name = "tableCell48";
            this.tableCell48.StylePriority.UseBorders = false;
            this.tableCell48.StylePriority.UseFont = false;
            this.tableCell48.Text = ":";
            this.tableCell48.Weight = 0.12750305885198107D;
            // 
            // tableCell49
            // 
            this.tableCell49.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell49.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_taxableamt]")});
            this.tableCell49.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell49.Name = "tableCell49";
            this.tableCell49.StylePriority.UseBorders = false;
            this.tableCell49.StylePriority.UseFont = false;
            this.tableCell49.StylePriority.UseTextAlignment = false;
            this.tableCell49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell49.TextFormatString = "{0:0.000}";
            this.tableCell49.Weight = 1.2882821530365203D;
            // 
            // tableRow28
            // 
            this.tableRow28.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell43,
            this.tableCell62,
            this.tableCell45,
            this.tableCell68});
            this.tableRow28.Name = "tableRow28";
            this.tableRow28.Weight = 0.625D;
            // 
            // tableCell43
            // 
            this.tableCell43.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell43.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell43.Name = "tableCell43";
            this.tableCell43.StylePriority.UseBorders = false;
            this.tableCell43.StylePriority.UseFont = false;
            this.tableCell43.Text = "SGST";
            this.tableCell43.Weight = 0.74327253919609049D;
            // 
            // tableCell62
            // 
            this.tableCell62.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell62.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell62.Multiline = true;
            this.tableCell62.Name = "tableCell62";
            this.tableCell62.StylePriority.UseBorders = false;
            this.tableCell62.StylePriority.UseFont = false;
            this.tableCell62.Weight = 0.74327253919609049D;
            // 
            // tableCell45
            // 
            this.tableCell45.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell45.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell45.Name = "tableCell45";
            this.tableCell45.StylePriority.UseBorders = false;
            this.tableCell45.StylePriority.UseFont = false;
            this.tableCell45.Text = ":";
            this.tableCell45.Weight = 0.12750305885198107D;
            // 
            // tableCell68
            // 
            this.tableCell68.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell68.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_sgst]")});
            this.tableCell68.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell68.Name = "tableCell68";
            this.tableCell68.StylePriority.UseBorders = false;
            this.tableCell68.StylePriority.UseFont = false;
            this.tableCell68.StylePriority.UseTextAlignment = false;
            this.tableCell68.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell68.TextFormatString = "{0:0.000}";
            this.tableCell68.Weight = 1.2882821530365203D;
            // 
            // tableRow31
            // 
            this.tableRow31.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell51,
            this.tableCell160,
            this.tableCell52,
            this.tableCell53});
            this.tableRow31.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Visible", "Iif(Sum([billp_igst]) == 0,false ,true )\n")});
            this.tableRow31.Name = "tableRow31";
            this.tableRow31.Weight = 0.625D;
            // 
            // tableCell51
            // 
            this.tableCell51.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell51.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell51.Name = "tableCell51";
            this.tableCell51.StylePriority.UseBorders = false;
            this.tableCell51.StylePriority.UseFont = false;
            this.tableCell51.Text = "CGST";
            this.tableCell51.Weight = 0.74327253919609049D;
            // 
            // tableCell160
            // 
            this.tableCell160.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell160.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell160.Multiline = true;
            this.tableCell160.Name = "tableCell160";
            this.tableCell160.StylePriority.UseBorders = false;
            this.tableCell160.StylePriority.UseFont = false;
            this.tableCell160.Weight = 0.74327253919609049D;
            // 
            // tableCell52
            // 
            this.tableCell52.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell52.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell52.Name = "tableCell52";
            this.tableCell52.StylePriority.UseBorders = false;
            this.tableCell52.StylePriority.UseFont = false;
            this.tableCell52.Text = ":";
            this.tableCell52.Weight = 0.12750305885198107D;
            // 
            // tableCell53
            // 
            this.tableCell53.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell53.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_cgst]")});
            this.tableCell53.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell53.Name = "tableCell53";
            this.tableCell53.StylePriority.UseBorders = false;
            this.tableCell53.StylePriority.UseFont = false;
            this.tableCell53.StylePriority.UseTextAlignment = false;
            this.tableCell53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell53.TextFormatString = "{0:0.000}";
            this.tableCell53.Weight = 1.2882821530365203D;
            // 
            // tableRow21
            // 
            this.tableRow21.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell18,
            this.tableCell171,
            this.tableCell31,
            this.tableCell44});
            this.tableRow21.Name = "tableRow21";
            this.tableRow21.Weight = 0.625D;
            // 
            // tableCell18
            // 
            this.tableCell18.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell18.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell18.Multiline = true;
            this.tableCell18.Name = "tableCell18";
            this.tableCell18.StylePriority.UseBorders = false;
            this.tableCell18.StylePriority.UseFont = false;
            this.tableCell18.Text = "IGST";
            this.tableCell18.Weight = 0.74327253919609049D;
            // 
            // tableCell171
            // 
            this.tableCell171.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell171.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell171.Multiline = true;
            this.tableCell171.Name = "tableCell171";
            this.tableCell171.StylePriority.UseBorders = false;
            this.tableCell171.StylePriority.UseFont = false;
            this.tableCell171.Weight = 0.74327253919609049D;
            // 
            // tableCell31
            // 
            this.tableCell31.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell31.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell31.Multiline = true;
            this.tableCell31.Name = "tableCell31";
            this.tableCell31.StylePriority.UseBorders = false;
            this.tableCell31.StylePriority.UseFont = false;
            this.tableCell31.Text = ":";
            this.tableCell31.Weight = 0.12750305885198107D;
            // 
            // tableCell44
            // 
            this.tableCell44.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell44.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_igst]")});
            this.tableCell44.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell44.Multiline = true;
            this.tableCell44.Name = "tableCell44";
            this.tableCell44.StylePriority.UseBorders = false;
            this.tableCell44.StylePriority.UseFont = false;
            this.tableCell44.StylePriority.UseTextAlignment = false;
            this.tableCell44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell44.TextFormatString = "{0:0.000}";
            this.tableCell44.Weight = 1.2882821530365203D;
            // 
            // tableRow26
            // 
            this.tableRow26.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell64,
            this.tableCell65,
            this.tableCell66});
            this.tableRow26.Name = "tableRow26";
            this.tableRow26.Weight = 0.625D;
            // 
            // tableCell64
            // 
            this.tableCell64.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell64.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell64.Name = "tableCell64";
            this.tableCell64.StylePriority.UseBorders = false;
            this.tableCell64.StylePriority.UseFont = false;
            this.tableCell64.Text = "Round Off";
            this.tableCell64.Weight = 1.486545078392181D;
            // 
            // tableCell65
            // 
            this.tableCell65.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell65.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell65.Name = "tableCell65";
            this.tableCell65.StylePriority.UseBorders = false;
            this.tableCell65.StylePriority.UseFont = false;
            this.tableCell65.Text = ":";
            this.tableCell65.Weight = 0.12750305885198107D;
            // 
            // tableCell66
            // 
            this.tableCell66.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell66.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_roundamt]")});
            this.tableCell66.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell66.Name = "tableCell66";
            this.tableCell66.StylePriority.UseBorders = false;
            this.tableCell66.StylePriority.UseFont = false;
            this.tableCell66.StylePriority.UseTextAlignment = false;
            this.tableCell66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell66.TextFormatString = "{0:0.000}";
            this.tableCell66.Weight = 1.2882821530365203D;
            // 
            // tableRow27
            // 
            this.tableRow27.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell67,
            this.tableCell74,
            this.tableCell70,
            this.tableCell71});
            this.tableRow27.Name = "tableRow27";
            this.tableRow27.Weight = 0.625D;
            // 
            // tableCell67
            // 
            this.tableCell67.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.tableCell67.Font = new DevExpress.Drawing.DXFont("Tahoma", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell67.Name = "tableCell67";
            this.tableCell67.StylePriority.UseBorders = false;
            this.tableCell67.StylePriority.UseFont = false;
            this.tableCell67.Text = "Bill Total";
            this.tableCell67.TextFormatString = "{0} ";
            this.tableCell67.Weight = 1.0951414293342081D;
            // 
            // tableCell74
            // 
            this.tableCell74.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.tableCell74.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pictureBox2});
            this.tableCell74.Font = new DevExpress.Drawing.DXFont("Tahoma", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell74.Multiline = true;
            this.tableCell74.Name = "tableCell74";
            this.tableCell74.StylePriority.UseBorders = false;
            this.tableCell74.StylePriority.UseFont = false;
            this.tableCell74.Weight = 0.39140364905797276D;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.pictureBox2.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("pictureBox2.ImageSource"));
            this.pictureBox2.LocationFloat = new DevExpress.Utils.PointFloat(3.738953F, 0F);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.SizeF = new System.Drawing.SizeF(25.3175F, 22.43448F);
            this.pictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.pictureBox2.StylePriority.UseBorders = false;
            // 
            // tableCell70
            // 
            this.tableCell70.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.tableCell70.Font = new DevExpress.Drawing.DXFont("Segoe UI", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell70.Name = "tableCell70";
            this.tableCell70.StylePriority.UseBorders = false;
            this.tableCell70.StylePriority.UseFont = false;
            this.tableCell70.Text = ":";
            this.tableCell70.Weight = 0.12750305885198107D;
            // 
            // tableCell71
            // 
            this.tableCell71.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.tableCell71.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_total]")});
            this.tableCell71.Font = new DevExpress.Drawing.DXFont("Tahoma", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell71.Name = "tableCell71";
            this.tableCell71.StylePriority.UseBorders = false;
            this.tableCell71.StylePriority.UseFont = false;
            this.tableCell71.StylePriority.UseTextAlignment = false;
            this.tableCell71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tableCell71.TextFormatString = "{0:0.000}";
            this.tableCell71.Weight = 1.2882821530365203D;
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 81.56089F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(797.9583F, 2F);
            // 
            // table4
            // 
            this.table4.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Underline);
            this.table4.LocationFloat = new DevExpress.Utils.PointFloat(0.5706109F, 0F);
            this.table4.Name = "table4";
            this.table4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow42,
            this.tableRow33});
            this.table4.SizeF = new System.Drawing.SizeF(599.3947F, 25.73163F);
            this.table4.StylePriority.UseFont = false;
            this.table4.StylePriority.UseTextAlignment = false;
            this.table4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // tableRow42
            // 
            this.tableRow42.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell81,
            this.tableCell188});
            this.tableRow42.Name = "tableRow42";
            this.tableRow42.Weight = 1D;
            // 
            // tableCell81
            // 
            this.tableCell81.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell81.Name = "tableCell81";
            this.tableCell81.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.tableCell81.StylePriority.UseBorders = false;
            this.tableCell81.StylePriority.UseFont = false;
            this.tableCell81.StylePriority.UsePadding = false;
            this.tableCell81.StylePriority.UseTextAlignment = false;
            this.tableCell81.Text = "Amount In Word ( INR ) :";
            this.tableCell81.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.tableCell81.Weight = 0.29128770091023093D;
            // 
            // tableCell188
            // 
            this.tableCell188.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_AmountInword]")});
            this.tableCell188.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell188.Multiline = true;
            this.tableCell188.Name = "tableCell188";
            this.tableCell188.StylePriority.UseBorders = false;
            this.tableCell188.StylePriority.UseFont = false;
            this.tableCell188.StylePriority.UseTextAlignment = false;
            this.tableCell188.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.tableCell188.Weight = 0.70871229908976907D;
            // 
            // tableRow33
            // 
            this.tableRow33.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell183,
            this.tableCell186});
            this.tableRow33.Name = "tableRow33";
            this.tableRow33.Weight = 1D;
            // 
            // tableCell183
            // 
            this.tableCell183.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell183.Multiline = true;
            this.tableCell183.Name = "tableCell183";
            this.tableCell183.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.tableCell183.StylePriority.UseBorders = false;
            this.tableCell183.StylePriority.UseFont = false;
            this.tableCell183.StylePriority.UsePadding = false;
            this.tableCell183.StylePriority.UseTextAlignment = false;
            this.tableCell183.Text = "Remarks :";
            this.tableCell183.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.tableCell183.Weight = 0.11648502117147497D;
            // 
            // tableCell186
            // 
            this.tableCell186.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_detail_remarks]")});
            this.tableCell186.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell186.Multiline = true;
            this.tableCell186.Name = "tableCell186";
            this.tableCell186.StylePriority.UseBorders = false;
            this.tableCell186.StylePriority.UseFont = false;
            this.tableCell186.StylePriority.UseTextAlignment = false;
            this.tableCell186.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.tableCell186.Weight = 0.88351497882852492D;
            // 
            // GroupFooter3
            // 
            this.GroupFooter3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table3,
            this.table19,
            this.table15});
            this.GroupFooter3.HeightF = 74.59591F;
            this.GroupFooter3.KeepTogether = true;
            this.GroupFooter3.Level = 1;
            this.GroupFooter3.Name = "GroupFooter3";
            this.GroupFooter3.PrintAtBottom = true;
            // 
            // table3
            // 
            this.table3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.table3.LocationFloat = new DevExpress.Utils.PointFloat(3.041806F, 0F);
            this.table3.Name = "table3";
            this.table3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.table3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow9,
            this.tableRow23,
            this.tableRow15,
            this.xrTableRow3,
            this.tableRow10,
            this.tableRow35,
            this.tableRow14});
            this.table3.SizeF = new System.Drawing.SizeF(425.5691F, 72.1901F);
            this.table3.StylePriority.UseBorders = false;
            // 
            // tableRow9
            // 
            this.tableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell20,
            this.xrTableCell18});
            this.tableRow9.Name = "tableRow9";
            this.tableRow9.Weight = 1D;
            // 
            // tableCell20
            // 
            this.tableCell20.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, ((DevExpress.Drawing.DXFontStyle)((DevExpress.Drawing.DXFontStyle.Bold | DevExpress.Drawing.DXFontStyle.Underline))));
            this.tableCell20.Multiline = true;
            this.tableCell20.Name = "tableCell20";
            this.tableCell20.StylePriority.UseFont = false;
            this.tableCell20.StylePriority.UseTextAlignment = false;
            this.tableCell20.Text = "Bank Details";
            this.tableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell20.Weight = 1.7718686652255715D;
            // 
            // xrTableCell18
            // 
            this.xrTableCell18.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell18.Multiline = true;
            this.xrTableCell18.Name = "xrTableCell18";
            this.xrTableCell18.StylePriority.UseFont = false;
            this.xrTableCell18.StylePriority.UseTextAlignment = false;
            this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell18.Weight = 1.7718686652255715D;
            // 
            // tableRow23
            // 
            this.tableRow23.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell59,
            this.tableCell76,
            this.tableCell77});
            this.tableRow23.Name = "tableRow23";
            this.tableRow23.Weight = 1D;
            // 
            // tableCell59
            // 
            this.tableCell59.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell59.Multiline = true;
            this.tableCell59.Name = "tableCell59";
            this.tableCell59.StylePriority.UseFont = false;
            this.tableCell59.Text = "Beneficiary";
            this.tableCell59.Weight = 0.716865827932007D;
            // 
            // tableCell76
            // 
            this.tableCell76.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell76.Multiline = true;
            this.tableCell76.Name = "tableCell76";
            this.tableCell76.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.tableCell76.StylePriority.UseFont = false;
            this.tableCell76.StylePriority.UsePadding = false;
            this.tableCell76.StylePriority.UseTextAlignment = false;
            this.tableCell76.Text = ":";
            this.tableCell76.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell76.Weight = 0.081059385576884468D;
            // 
            // tableCell77
            // 
            this.tableCell77.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[company_printname]")});
            this.tableCell77.Multiline = true;
            this.tableCell77.Name = "tableCell77";
            this.tableCell77.Weight = 2.7458121169422518D;
            // 
            // tableRow15
            // 
            this.tableRow15.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell143,
            this.tableCell144,
            this.tableCell145});
            this.tableRow15.Name = "tableRow15";
            this.tableRow15.Weight = 1D;
            // 
            // tableCell143
            // 
            this.tableCell143.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell143.Multiline = true;
            this.tableCell143.Name = "tableCell143";
            this.tableCell143.StylePriority.UseFont = false;
            this.tableCell143.Text = "Bank Name ";
            this.tableCell143.Weight = 0.716865827932007D;
            // 
            // tableCell144
            // 
            this.tableCell144.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell144.Multiline = true;
            this.tableCell144.Name = "tableCell144";
            this.tableCell144.StylePriority.UseFont = false;
            this.tableCell144.Text = ":";
            this.tableCell144.Weight = 0.081059385576884468D;
            // 
            // tableCell145
            // 
            this.tableCell145.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bankname]")});
            this.tableCell145.Multiline = true;
            this.tableCell145.Name = "tableCell145";
            this.tableCell145.Weight = 2.7458121169422518D;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.xrTableCell7,
            this.xrTableCell8});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.Text = "Branch";
            this.xrTableCell5.Weight = 0.716865827932007D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.Text = ":";
            this.xrTableCell7.Weight = 0.081059385576884468D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bank_branch]")});
            this.xrTableCell8.Multiline = true;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Weight = 2.7458121169422518D;
            // 
            // tableRow10
            // 
            this.tableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell96,
            this.tableCell99,
            this.tableCell107});
            this.tableRow10.Name = "tableRow10";
            this.tableRow10.Weight = 1D;
            // 
            // tableCell96
            // 
            this.tableCell96.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell96.Multiline = true;
            this.tableCell96.Name = "tableCell96";
            this.tableCell96.StylePriority.UseFont = false;
            this.tableCell96.Text = "Account No";
            this.tableCell96.Weight = 0.716865827932007D;
            // 
            // tableCell99
            // 
            this.tableCell99.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell99.Multiline = true;
            this.tableCell99.Name = "tableCell99";
            this.tableCell99.StylePriority.UseFont = false;
            this.tableCell99.Text = ":";
            this.tableCell99.Weight = 0.081059385576884468D;
            // 
            // tableCell107
            // 
            this.tableCell107.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bank_accountno]")});
            this.tableCell107.Multiline = true;
            this.tableCell107.Name = "tableCell107";
            this.tableCell107.Weight = 2.7458121169422518D;
            // 
            // tableRow35
            // 
            this.tableRow35.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell195,
            this.tableCell196,
            this.tableCell197});
            this.tableRow35.Name = "tableRow35";
            this.tableRow35.Weight = 1D;
            // 
            // tableCell195
            // 
            this.tableCell195.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell195.Multiline = true;
            this.tableCell195.Name = "tableCell195";
            this.tableCell195.StylePriority.UseFont = false;
            this.tableCell195.Text = "Bank Address";
            this.tableCell195.Weight = 0.716865827932007D;
            // 
            // tableCell196
            // 
            this.tableCell196.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell196.Multiline = true;
            this.tableCell196.Name = "tableCell196";
            this.tableCell196.StylePriority.UseFont = false;
            this.tableCell196.Text = ":\t";
            this.tableCell196.Weight = 0.081059385576884468D;
            // 
            // tableCell197
            // 
            this.tableCell197.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bank_address]")});
            this.tableCell197.Multiline = true;
            this.tableCell197.Name = "tableCell197";
            this.tableCell197.Weight = 2.7458121169422518D;
            // 
            // tableRow14
            // 
            this.tableRow14.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell127,
            this.tableCell128,
            this.tableCell136});
            this.tableRow14.Name = "tableRow14";
            this.tableRow14.Weight = 1D;
            // 
            // tableCell127
            // 
            this.tableCell127.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell127.Multiline = true;
            this.tableCell127.Name = "tableCell127";
            this.tableCell127.StylePriority.UseFont = false;
            this.tableCell127.Text = "IFSC/RTGS";
            this.tableCell127.Weight = 0.716865827932007D;
            // 
            // tableCell128
            // 
            this.tableCell128.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell128.Multiline = true;
            this.tableCell128.Name = "tableCell128";
            this.tableCell128.StylePriority.UseFont = false;
            this.tableCell128.Text = ":";
            this.tableCell128.Weight = 0.081059385576884468D;
            // 
            // tableCell136
            // 
            this.tableCell136.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bank_ifsc]")});
            this.tableCell136.Multiline = true;
            this.tableCell136.Name = "tableCell136";
            this.tableCell136.Weight = 2.7458121169422518D;
            // 
            // table19
            // 
            this.table19.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom;
            this.table19.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.table19.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F);
            this.table19.LocationFloat = new DevExpress.Utils.PointFloat(454.7462F, 54.99258F);
            this.table19.Name = "table19";
            this.table19.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow44});
            this.table19.SizeF = new System.Drawing.SizeF(327.9999F, 17.19752F);
            this.table19.StylePriority.UseBorders = false;
            this.table19.StylePriority.UseFont = false;
            // 
            // tableRow44
            // 
            this.tableRow44.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell90});
            this.tableRow44.Name = "tableRow44";
            this.tableRow44.Weight = 4.2055169250636188D;
            // 
            // tableCell90
            // 
            this.tableCell90.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell90.CanGrow = false;
            this.tableCell90.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell90.Name = "tableCell90";
            this.tableCell90.StylePriority.UseBorders = false;
            this.tableCell90.StylePriority.UseFont = false;
            this.tableCell90.StylePriority.UseTextAlignment = false;
            this.tableCell90.Text = "Authorised Signatory";
            this.tableCell90.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell90.Weight = 0.5D;
            // 
            // table15
            // 
            this.table15.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.table15.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F);
            this.table15.LocationFloat = new DevExpress.Utils.PointFloat(407.494F, 0F);
            this.table15.Name = "table15";
            this.table15.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow89});
            this.table15.SizeF = new System.Drawing.SizeF(390.4643F, 13.50201F);
            this.table15.StylePriority.UseBorders = false;
            this.table15.StylePriority.UseFont = false;
            // 
            // tableRow89
            // 
            this.tableRow89.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableRow89.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell176});
            this.tableRow89.Name = "tableRow89";
            this.tableRow89.StylePriority.UseBorders = false;
            this.tableRow89.Weight = 1D;
            // 
            // tableCell176
            // 
            this.tableCell176.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell176.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[company_printname]")});
            this.tableCell176.Font = new DevExpress.Drawing.DXFont("Tahoma", 10F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell176.Name = "tableCell176";
            this.tableCell176.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.tableCell176.StylePriority.UseBorders = false;
            this.tableCell176.StylePriority.UseFont = false;
            this.tableCell176.StylePriority.UsePadding = false;
            this.tableCell176.StylePriority.UseTextAlignment = false;
            this.tableCell176.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell176.TextFormatString = "For   {0}";
            this.tableCell176.Weight = 1D;
            // 
            // xrCrossBandBox1
            // 
            this.xrCrossBandBox1.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandBox1.BorderWidth = 1F;
            this.xrCrossBandBox1.EndBand = this.GroupFooter3;
            this.xrCrossBandBox1.EndPointFloat = new DevExpress.Utils.PointFloat(0F, 72.19006F);
            this.xrCrossBandBox1.Name = "xrCrossBandBox1";
            this.xrCrossBandBox1.StartBand = this.GroupHeader2;
            this.xrCrossBandBox1.StartPointFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrCrossBandBox1.WidthF = 798.9999F;
            // 
            // xrCrossBandLine1
            // 
            this.xrCrossBandLine1.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine1.EndBand = this.GroupFooter4;
            this.xrCrossBandLine1.EndPointFloat = new DevExpress.Utils.PointFloat(232.2224F, 20F);
            this.xrCrossBandLine1.Name = "xrCrossBandLine1";
            this.xrCrossBandLine1.StartBand = this.GroupHeader4;
            this.xrCrossBandLine1.StartPointFloat = new DevExpress.Utils.PointFloat(232.2224F, 0F);
            this.xrCrossBandLine1.WidthF = 1F;
            // 
            // GroupFooter4
            // 
            this.GroupFooter4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table7});
            this.GroupFooter4.HeightF = 20F;
            this.GroupFooter4.KeepTogether = true;
            this.GroupFooter4.Name = "GroupFooter4";
            this.GroupFooter4.PrintAtBottom = true;
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table5});
            this.GroupHeader4.HeightF = 27.52651F;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // xrCrossBandLine2
            // 
            this.xrCrossBandLine2.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine2.EndBand = this.GroupFooter4;
            this.xrCrossBandLine2.EndPointFloat = new DevExpress.Utils.PointFloat(22.45396F, 19.99998F);
            this.xrCrossBandLine2.Name = "xrCrossBandLine2";
            this.xrCrossBandLine2.StartBand = this.GroupHeader4;
            this.xrCrossBandLine2.StartPointFloat = new DevExpress.Utils.PointFloat(22.45396F, 0F);
            this.xrCrossBandLine2.WidthF = 1F;
            // 
            // xrCrossBandLine3
            // 
            this.xrCrossBandLine3.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine3.EndBand = this.GroupFooter4;
            this.xrCrossBandLine3.EndPointFloat = new DevExpress.Utils.PointFloat(273.3938F, 19.99998F);
            this.xrCrossBandLine3.Name = "xrCrossBandLine3";
            this.xrCrossBandLine3.StartBand = this.GroupHeader4;
            this.xrCrossBandLine3.StartPointFloat = new DevExpress.Utils.PointFloat(273.3938F, 0F);
            this.xrCrossBandLine3.WidthF = 1.000031F;
            // 
            // xrCrossBandLine4
            // 
            this.xrCrossBandLine4.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine4.EndBand = this.GroupFooter4;
            this.xrCrossBandLine4.EndPointFloat = new DevExpress.Utils.PointFloat(310.6592F, 19.99998F);
            this.xrCrossBandLine4.Name = "xrCrossBandLine4";
            this.xrCrossBandLine4.StartBand = this.GroupHeader4;
            this.xrCrossBandLine4.StartPointFloat = new DevExpress.Utils.PointFloat(310.6592F, 0F);
            this.xrCrossBandLine4.WidthF = 1.000031F;
            // 
            // xrCrossBandLine5
            // 
            this.xrCrossBandLine5.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine5.EndBand = this.GroupFooter4;
            this.xrCrossBandLine5.EndPointFloat = new DevExpress.Utils.PointFloat(353.4408F, 19.99998F);
            this.xrCrossBandLine5.Name = "xrCrossBandLine5";
            this.xrCrossBandLine5.StartBand = this.GroupHeader4;
            this.xrCrossBandLine5.StartPointFloat = new DevExpress.Utils.PointFloat(353.4408F, 0F);
            this.xrCrossBandLine5.WidthF = 1.000061F;
            // 
            // xrCrossBandLine6
            // 
            this.xrCrossBandLine6.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine6.EndBand = this.GroupFooter4;
            this.xrCrossBandLine6.EndPointFloat = new DevExpress.Utils.PointFloat(399.9726F, 19.99998F);
            this.xrCrossBandLine6.Name = "xrCrossBandLine6";
            this.xrCrossBandLine6.StartBand = this.GroupHeader4;
            this.xrCrossBandLine6.StartPointFloat = new DevExpress.Utils.PointFloat(399.9726F, 0F);
            this.xrCrossBandLine6.WidthF = 1.000061F;
            // 
            // xrCrossBandLine7
            // 
            this.xrCrossBandLine7.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine7.EndBand = this.GroupFooter4;
            this.xrCrossBandLine7.EndPointFloat = new DevExpress.Utils.PointFloat(434.3714F, 19.99998F);
            this.xrCrossBandLine7.Name = "xrCrossBandLine7";
            this.xrCrossBandLine7.StartBand = this.GroupHeader4;
            this.xrCrossBandLine7.StartPointFloat = new DevExpress.Utils.PointFloat(434.3714F, 0F);
            this.xrCrossBandLine7.WidthF = 1.000031F;
            // 
            // xrCrossBandLine8
            // 
            this.xrCrossBandLine8.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine8.EndBand = this.GroupFooter4;
            this.xrCrossBandLine8.EndPointFloat = new DevExpress.Utils.PointFloat(495.2227F, 19.99998F);
            this.xrCrossBandLine8.Name = "xrCrossBandLine8";
            this.xrCrossBandLine8.StartBand = this.GroupHeader4;
            this.xrCrossBandLine8.StartPointFloat = new DevExpress.Utils.PointFloat(495.2227F, 0F);
            this.xrCrossBandLine8.WidthF = 1.000092F;
            // 
            // xrCrossBandLine9
            // 
            this.xrCrossBandLine9.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine9.EndBand = this.GroupFooter4;
            this.xrCrossBandLine9.EndPointFloat = new DevExpress.Utils.PointFloat(536.418F, 19.99998F);
            this.xrCrossBandLine9.Name = "xrCrossBandLine9";
            this.xrCrossBandLine9.StartBand = this.GroupHeader4;
            this.xrCrossBandLine9.StartPointFloat = new DevExpress.Utils.PointFloat(536.418F, 0F);
            this.xrCrossBandLine9.WidthF = 1.000061F;
            // 
            // xrCrossBandLine10
            // 
            this.xrCrossBandLine10.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine10.EndBand = this.GroupFooter4;
            this.xrCrossBandLine10.EndPointFloat = new DevExpress.Utils.PointFloat(599.9653F, 19.99998F);
            this.xrCrossBandLine10.Name = "xrCrossBandLine10";
            this.xrCrossBandLine10.StartBand = this.GroupHeader4;
            this.xrCrossBandLine10.StartPointFloat = new DevExpress.Utils.PointFloat(599.9653F, 0F);
            this.xrCrossBandLine10.WidthF = 1F;
            // 
            // xrCrossBandLine11
            // 
            this.xrCrossBandLine11.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine11.EndBand = this.GroupFooter4;
            this.xrCrossBandLine11.EndPointFloat = new DevExpress.Utils.PointFloat(664.6937F, 20F);
            this.xrCrossBandLine11.Name = "xrCrossBandLine11";
            this.xrCrossBandLine11.StartBand = this.GroupHeader4;
            this.xrCrossBandLine11.StartPointFloat = new DevExpress.Utils.PointFloat(664.6937F, 0F);
            this.xrCrossBandLine11.WidthF = 1F;
            // 
            // xrCrossBandLine12
            // 
            this.xrCrossBandLine12.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine12.EndBand = this.GroupFooter4;
            this.xrCrossBandLine12.EndPointFloat = new DevExpress.Utils.PointFloat(736.4116F, 20F);
            this.xrCrossBandLine12.Name = "xrCrossBandLine12";
            this.xrCrossBandLine12.StartBand = this.GroupHeader4;
            this.xrCrossBandLine12.StartPointFloat = new DevExpress.Utils.PointFloat(736.4116F, 0F);
            this.xrCrossBandLine12.WidthF = 1.000061F;
            // 
            // xrCrossBandLine13
            // 
            this.xrCrossBandLine13.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine13.EndBand = this.GroupFooter4;
            this.xrCrossBandLine13.EndPointFloat = new DevExpress.Utils.PointFloat(556.5491F, 19.99998F);
            this.xrCrossBandLine13.Name = "xrCrossBandLine13";
            this.xrCrossBandLine13.StartBand = this.GroupHeader4;
            this.xrCrossBandLine13.StartPointFloat = new DevExpress.Utils.PointFloat(556.5491F, 17.29F);
            this.xrCrossBandLine13.WidthF = 1F;
            // 
            // xrCrossBandLine14
            // 
            this.xrCrossBandLine14.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine14.EndBand = this.GroupFooter4;
            this.xrCrossBandLine14.EndPointFloat = new DevExpress.Utils.PointFloat(619.827F, 19.99998F);
            this.xrCrossBandLine14.Name = "xrCrossBandLine14";
            this.xrCrossBandLine14.StartBand = this.GroupHeader4;
            this.xrCrossBandLine14.StartPointFloat = new DevExpress.Utils.PointFloat(619.827F, 17.29F);
            this.xrCrossBandLine14.WidthF = 1F;
            // 
            // xrCrossBandLine15
            // 
            this.xrCrossBandLine15.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine15.EndBand = this.GroupFooter4;
            this.xrCrossBandLine15.EndPointFloat = new DevExpress.Utils.PointFloat(689.6272F, 20F);
            this.xrCrossBandLine15.Name = "xrCrossBandLine15";
            this.xrCrossBandLine15.StartBand = this.GroupHeader4;
            this.xrCrossBandLine15.StartPointFloat = new DevExpress.Utils.PointFloat(689.6272F, 17.29F);
            this.xrCrossBandLine15.WidthF = 1F;
            // 
            // DetailReport1
            // 
            this.DetailReport1.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail2,
            this.GroupHeader4,
            this.GroupFooter4});
            this.DetailReport1.DataMember = "billDetails";
            this.DetailReport1.DataSource = this.jsonDataSource1;
            this.DetailReport1.Level = 0;
            this.DetailReport1.Name = "DetailReport1";
            // 
            // Detail2
            // 
            this.Detail2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table6});
            this.Detail2.FillEmptySpace = true;
            this.Detail2.HeightF = 8.490601F;
            this.Detail2.KeepTogether = true;
            this.Detail2.Name = "Detail2";
            // 
            // QuotationReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.GroupHeader1,
            this.GroupHeader2,
            this.GroupFooter2,
            this.GroupFooter3,
            this.DetailReport1});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.jsonDataSource1});
            this.CrossBandControls.AddRange(new DevExpress.XtraReports.UI.XRCrossBandControl[] {
            this.xrCrossBandLine15,
            this.xrCrossBandLine14,
            this.xrCrossBandLine13,
            this.xrCrossBandLine12,
            this.xrCrossBandLine11,
            this.xrCrossBandLine10,
            this.xrCrossBandLine9,
            this.xrCrossBandLine8,
            this.xrCrossBandLine7,
            this.xrCrossBandLine6,
            this.xrCrossBandLine5,
            this.xrCrossBandLine4,
            this.xrCrossBandLine3,
            this.xrCrossBandLine2,
            this.xrCrossBandLine1,
            this.xrCrossBandBox1});
            this.DataSource = this.jsonDataSource1;
            this.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F);
            this.Margins = new DevExpress.Drawing.DXMargins(22F, 19F, 20.83333F, 31.26391F);
            this.Version = "24.1";
            ((System.ComponentModel.ISupportInitialize)(this.table18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter2;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter3;
        private DevExpress.XtraReports.UI.XRTable table1;
        private DevExpress.XtraReports.UI.XRTableRow tableRow1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell1;
        private DevExpress.XtraReports.UI.XRTableRow tableRow2;
        private DevExpress.XtraReports.UI.XRTableCell tableCell4;
        private DevExpress.XtraReports.UI.XRTableRow tableRow11;
        private DevExpress.XtraReports.UI.XRTableCell tableCell132;
        private DevExpress.XtraReports.UI.XRTableRow tableRow19;
        private DevExpress.XtraReports.UI.XRTableCell tableCell15;
        private DevExpress.XtraReports.UI.XRTableRow tableRow13;
        private DevExpress.XtraReports.UI.XRTableCell tableCell134;
        private DevExpress.XtraReports.UI.XRTable table18;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableRow tableRow83;
        private DevExpress.XtraReports.UI.XRTableCell tableCell37;
        private DevExpress.XtraReports.UI.XRTableCell tableCell184;
        private DevExpress.XtraReports.UI.XRTableCell tableCell185;
        private DevExpress.XtraReports.UI.XRTableCell tableCell187;
        private DevExpress.XtraReports.UI.XRTableRow tableRow84;
        private DevExpress.XtraReports.UI.XRTableCell tableCell56;
        private DevExpress.XtraReports.UI.XRTableCell tableCell191;
        private DevExpress.XtraReports.UI.XRTableCell tableCell192;
        private DevExpress.XtraReports.UI.XRTableCell tableCell193;
        private DevExpress.XtraReports.UI.XRTableRow tableRow85;
        private DevExpress.XtraReports.UI.XRTableCell tableCell58;
        private DevExpress.XtraReports.UI.XRTableCell tableCell242;
        private DevExpress.XtraReports.UI.XRTableCell tableCell243;
        private DevExpress.XtraReports.UI.XRTableCell tableCell244;
        private DevExpress.XtraReports.UI.XRTableRow tableRow87;
        private DevExpress.XtraReports.UI.XRTableCell tableCell83;
        private DevExpress.XtraReports.UI.XRTableCell tableCell248;
        private DevExpress.XtraReports.UI.XRTableCell tableCell249;
        private DevExpress.XtraReports.UI.XRTableCell tableCell250;
        private DevExpress.XtraReports.UI.XRTableRow tableRow88;
        private DevExpress.XtraReports.UI.XRTableCell tableCell84;
        private DevExpress.XtraReports.UI.XRTableCell tableCell254;
        private DevExpress.XtraReports.UI.XRTableCell tableCell255;
        private DevExpress.XtraReports.UI.XRTableCell tableCell256;
        private DevExpress.XtraReports.UI.XRTableRow tableRow90;
        private DevExpress.XtraReports.UI.XRTableCell tableCell88;
        private DevExpress.XtraReports.UI.XRTableCell tableCell140;
        private DevExpress.XtraReports.UI.XRTableCell tableCell139;
        private DevExpress.XtraReports.UI.XRTableCell tableCell260;
        private DevExpress.XtraReports.UI.XRTableCell tableCell261;
        private DevExpress.XtraReports.UI.XRTableCell tableCell262;
        private DevExpress.XtraReports.UI.XRTableRow tableRow91;
        private DevExpress.XtraReports.UI.XRTableCell tableCell89;
        private DevExpress.XtraReports.UI.XRTableCell tableCell142;
        private DevExpress.XtraReports.UI.XRTableCell tableCell85;
        private DevExpress.XtraReports.UI.XRTableCell tableCell266;
        private DevExpress.XtraReports.UI.XRTable table4;
        private DevExpress.XtraReports.UI.XRTableRow tableRow42;
        private DevExpress.XtraReports.UI.XRTableCell tableCell81;
        private DevExpress.XtraReports.UI.XRTableCell tableCell188;
        private DevExpress.XtraReports.UI.XRTableRow tableRow33;
        private DevExpress.XtraReports.UI.XRTableCell tableCell183;
        private DevExpress.XtraReports.UI.XRTableCell tableCell186;
        private DevExpress.XtraReports.UI.XRTable table8;
        private DevExpress.XtraReports.UI.XRTableRow tableRow18;
        private DevExpress.XtraReports.UI.XRTableCell tableCell47;
        private DevExpress.XtraReports.UI.XRTableCell tableCell48;
        private DevExpress.XtraReports.UI.XRTableCell tableCell49;
        private DevExpress.XtraReports.UI.XRTableRow tableRow28;
        private DevExpress.XtraReports.UI.XRTableCell tableCell43;
        private DevExpress.XtraReports.UI.XRTableCell tableCell62;
        private DevExpress.XtraReports.UI.XRTableCell tableCell45;
        private DevExpress.XtraReports.UI.XRTableCell tableCell68;
        private DevExpress.XtraReports.UI.XRTableRow tableRow31;
        private DevExpress.XtraReports.UI.XRTableCell tableCell51;
        private DevExpress.XtraReports.UI.XRTableCell tableCell160;
        private DevExpress.XtraReports.UI.XRTableCell tableCell52;
        private DevExpress.XtraReports.UI.XRTableCell tableCell53;
        private DevExpress.XtraReports.UI.XRTableRow tableRow21;
        private DevExpress.XtraReports.UI.XRTableCell tableCell18;
        private DevExpress.XtraReports.UI.XRTableCell tableCell171;
        private DevExpress.XtraReports.UI.XRTableCell tableCell31;
        private DevExpress.XtraReports.UI.XRTableCell tableCell44;
        private DevExpress.XtraReports.UI.XRTableRow tableRow26;
        private DevExpress.XtraReports.UI.XRTableCell tableCell64;
        private DevExpress.XtraReports.UI.XRTableCell tableCell65;
        private DevExpress.XtraReports.UI.XRTableCell tableCell66;
        private DevExpress.XtraReports.UI.XRTableRow tableRow27;
        private DevExpress.XtraReports.UI.XRTableCell tableCell67;
        private DevExpress.XtraReports.UI.XRTableCell tableCell74;
        private DevExpress.XtraReports.UI.XRTableCell tableCell70;
        private DevExpress.XtraReports.UI.XRTableCell tableCell71;
        private DevExpress.XtraReports.UI.XRTable table15;
        private DevExpress.XtraReports.UI.XRTableRow tableRow89;
        private DevExpress.XtraReports.UI.XRTableCell tableCell176;
        private DevExpress.XtraReports.UI.XRTable table19;
        private DevExpress.XtraReports.UI.XRTableRow tableRow44;
        private DevExpress.XtraReports.UI.XRTableCell tableCell90;
        private DevExpress.XtraReports.UI.XRTable table5;
        private DevExpress.XtraReports.UI.XRTableRow tableRow20;
        private DevExpress.XtraReports.UI.XRTableCell tableCell22;
        private DevExpress.XtraReports.UI.XRTableCell tableCell23;
        private DevExpress.XtraReports.UI.XRTableCell tableCell40;
        private DevExpress.XtraReports.UI.XRTableCell tableCell24;
        private DevExpress.XtraReports.UI.XRTableCell tableCell25;
        private DevExpress.XtraReports.UI.XRTableCell tableCell26;
        private DevExpress.XtraReports.UI.XRTableCell tableCell27;
        private DevExpress.XtraReports.UI.XRTableCell tableCell169;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell tableCell95;
        private DevExpress.XtraReports.UI.XRTableCell tableCell97;
        private DevExpress.XtraReports.UI.XRTableCell tableCell98;
        private DevExpress.XtraReports.UI.XRTableRow tableRow5;
        private DevExpress.XtraReports.UI.XRTableCell tableCell100;
        private DevExpress.XtraReports.UI.XRTableCell tableCell101;
        private DevExpress.XtraReports.UI.XRTableCell tableCell141;
        private DevExpress.XtraReports.UI.XRTableCell tableCell146;
        private DevExpress.XtraReports.UI.XRTableCell tableCell147;
        private DevExpress.XtraReports.UI.XRTableCell tableCell154;
        private DevExpress.XtraReports.UI.XRTableCell tableCell155;
        private DevExpress.XtraReports.UI.XRTableCell tableCell156;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        private DevExpress.XtraReports.UI.XRTableCell tableCell163;
        private DevExpress.XtraReports.UI.XRTableCell tableCell166;
        private DevExpress.XtraReports.UI.XRTableCell tableCell164;
        private DevExpress.XtraReports.UI.XRTableCell tableCell167;
        private DevExpress.XtraReports.UI.XRTableCell tableCell165;
        private DevExpress.XtraReports.UI.XRTable table6;
        private DevExpress.XtraReports.UI.XRTableRow tableRow47;
        private DevExpress.XtraReports.UI.XRTableCell tableCell35;
        private DevExpress.XtraReports.UI.XRTableCell tableCell36;
        private DevExpress.XtraReports.UI.XRTableCell tableCell41;
        private DevExpress.XtraReports.UI.XRTableCell tableCell94;
        private DevExpress.XtraReports.UI.XRTableCell tableCell38;
        private DevExpress.XtraReports.UI.XRTableCell tableCell39;
        private DevExpress.XtraReports.UI.XRTableCell tableCell115;
        private DevExpress.XtraReports.UI.XRTableCell tableCell170;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private DevExpress.XtraReports.UI.XRTableCell tableCell172;
        private DevExpress.XtraReports.UI.XRTableCell tableCell173;
        private DevExpress.XtraReports.UI.XRTableCell tableCell174;
        private DevExpress.XtraReports.UI.XRTableCell tableCell175;
        private DevExpress.XtraReports.UI.XRTableCell tableCell177;
        private DevExpress.XtraReports.UI.XRPictureBox pictureBox2;
        private DevExpress.XtraReports.UI.XRTable table7;
        private DevExpress.XtraReports.UI.XRTableRow tableRow17;
        private DevExpress.XtraReports.UI.XRTableCell tableCell32;
        private DevExpress.XtraReports.UI.XRTableCell tableCell30;
        private DevExpress.XtraReports.UI.XRTableCell tableCell178;
        private DevExpress.XtraReports.UI.XRTableCell tableCell179;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        private DevExpress.XtraReports.UI.XRTableCell tableCell181;
        private DevExpress.XtraReports.UI.XRTableCell tableCell180;
        private DevExpress.XtraReports.UI.XRTableCell tableCell182;
        private DevExpress.XtraReports.UI.XRTableCell tableCell42;
        private DevExpress.XtraReports.UI.XRCrossBandBox xrCrossBandBox1;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine1;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine2;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine3;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine4;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine5;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine6;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine7;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine8;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine9;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine10;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine11;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine12;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine13;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine14;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine15;
        private DevExpress.DataAccess.Json.JsonDataSource jsonDataSource1;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReport1;
        private DevExpress.XtraReports.UI.DetailBand Detail2;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader4;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter4;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTable table3;
        private DevExpress.XtraReports.UI.XRTableRow tableRow9;
        private DevExpress.XtraReports.UI.XRTableCell tableCell20;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell18;
        private DevExpress.XtraReports.UI.XRTableRow tableRow23;
        private DevExpress.XtraReports.UI.XRTableCell tableCell59;
        private DevExpress.XtraReports.UI.XRTableCell tableCell76;
        private DevExpress.XtraReports.UI.XRTableCell tableCell77;
        private DevExpress.XtraReports.UI.XRTableRow tableRow15;
        private DevExpress.XtraReports.UI.XRTableCell tableCell143;
        private DevExpress.XtraReports.UI.XRTableCell tableCell144;
        private DevExpress.XtraReports.UI.XRTableCell tableCell145;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableRow tableRow10;
        private DevExpress.XtraReports.UI.XRTableCell tableCell96;
        private DevExpress.XtraReports.UI.XRTableCell tableCell99;
        private DevExpress.XtraReports.UI.XRTableCell tableCell107;
        private DevExpress.XtraReports.UI.XRTableRow tableRow35;
        private DevExpress.XtraReports.UI.XRTableCell tableCell195;
        private DevExpress.XtraReports.UI.XRTableCell tableCell196;
        private DevExpress.XtraReports.UI.XRTableCell tableCell197;
        private DevExpress.XtraReports.UI.XRTableRow tableRow14;
        private DevExpress.XtraReports.UI.XRTableCell tableCell127;
        private DevExpress.XtraReports.UI.XRTableCell tableCell128;
        private DevExpress.XtraReports.UI.XRTableCell tableCell136;
    }
}
