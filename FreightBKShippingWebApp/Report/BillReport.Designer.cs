namespace FreightBKShippingWebApp.Report
{
    partial class BillReport
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
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode1 = new DevExpress.DataAccess.Json.JsonSchemaNode("root", true);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode2 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill", true);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode3 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_ack_no", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode4 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_ack_date", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode5 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_irn_no", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode6 = new DevExpress.DataAccess.Json.JsonSchemaNode("billId", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode7 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_no", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode8 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_date", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<System.DateTime>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode9 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_duedate", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<System.DateTime>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode10 = new DevExpress.DataAccess.Json.JsonSchemaNode("account_print_name", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode11 = new DevExpress.DataAccess.Json.JsonSchemaNode("account_state", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode12 = new DevExpress.DataAccess.Json.JsonSchemaNode("account_address1", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode13 = new DevExpress.DataAccess.Json.JsonSchemaNode("account_gstno", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode14 = new DevExpress.DataAccess.Json.JsonSchemaNode("placeofSupply", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode15 = new DevExpress.DataAccess.Json.JsonSchemaNode("shipmentType", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode16 = new DevExpress.DataAccess.Json.JsonSchemaNode("cargo", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode17 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_blno", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode18 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_hblno", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode19 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_hbldate", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<System.DateTime>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode20 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_sbno", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode21 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_bldate", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<System.DateTime>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode22 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_sbdate", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<System.DateTime>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode23 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_jobno", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode24 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_jobtype", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode25 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_grosswt", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode26 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_netwt", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode27 = new DevExpress.DataAccess.Json.JsonSchemaNode("vessel", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode28 = new DevExpress.DataAccess.Json.JsonSchemaNode("line", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode29 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_20ft", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode30 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_40ft", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode31 = new DevExpress.DataAccess.Json.JsonSchemaNode("shipper_invno", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode32 = new DevExpress.DataAccess.Json.JsonSchemaNode("shipper", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode33 = new DevExpress.DataAccess.Json.JsonSchemaNode("consignee", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode34 = new DevExpress.DataAccess.Json.JsonSchemaNode("pol", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode35 = new DevExpress.DataAccess.Json.JsonSchemaNode("pod", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode36 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_container_no", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode37 = new DevExpress.DataAccess.Json.JsonSchemaNode("grossAmount", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode38 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_taxableamt", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode39 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_sgst", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<double>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode40 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_cgst", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<double>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode41 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_igst", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode42 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_roundamt", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode43 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_total", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<double>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode44 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_AmountInword", true, DevExpress.DataAccess.Json.JsonNodeType.Property);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode45 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_remarks", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode46 = new DevExpress.DataAccess.Json.JsonSchemaNode("company_printname", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode47 = new DevExpress.DataAccess.Json.JsonSchemaNode("company_address1", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode48 = new DevExpress.DataAccess.Json.JsonSchemaNode("company_gstin", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode49 = new DevExpress.DataAccess.Json.JsonSchemaNode("state_Company", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode50 = new DevExpress.DataAccess.Json.JsonSchemaNode("company_mobile", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode51 = new DevExpress.DataAccess.Json.JsonSchemaNode("company_email", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode52 = new DevExpress.DataAccess.Json.JsonSchemaNode("company_panno", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode53 = new DevExpress.DataAccess.Json.JsonSchemaNode("company_website", true, DevExpress.DataAccess.Json.JsonNodeType.Property);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode54 = new DevExpress.DataAccess.Json.JsonSchemaNode("bankname", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode55 = new DevExpress.DataAccess.Json.JsonSchemaNode("bank_branch", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode56 = new DevExpress.DataAccess.Json.JsonSchemaNode("bank_accountno", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode57 = new DevExpress.DataAccess.Json.JsonSchemaNode("bank_ifsc", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode58 = new DevExpress.DataAccess.Json.JsonSchemaNode("bank_address", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode59 = new DevExpress.DataAccess.Json.JsonSchemaNode("place_of_receipt", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode60 = new DevExpress.DataAccess.Json.JsonSchemaNode("place_of_delivery", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode61 = new DevExpress.DataAccess.Json.JsonSchemaNode("destination", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode62 = new DevExpress.DataAccess.Json.JsonSchemaNode("billDetails", true, DevExpress.DataAccess.Json.JsonNodeType.Array);
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode63 = new DevExpress.DataAccess.Json.JsonSchemaNode("service_printname", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode64 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_hsncode", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode65 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_qty", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode66 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_rate", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode67 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_amount", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode68 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_exchrate", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode69 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_sgst", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<double>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode70 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_cgst", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<double>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode71 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_sgstper", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode72 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_cgstper", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode73 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_igstper", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode74 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_taxableamt", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<long>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode75 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_total", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<double>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode76 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_igst", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(System.Nullable<double>));
            DevExpress.DataAccess.Json.JsonSchemaNode jsonSchemaNode77 = new DevExpress.DataAccess.Json.JsonSchemaNode("bill_detail_exchunit", true, DevExpress.DataAccess.Json.JsonNodeType.Property, typeof(string));
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillReport));
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.table5 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow20 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell169 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell87 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell95 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell97 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell98 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell100 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell101 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell141 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell146 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell147 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell154 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell155 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell156 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell162 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell163 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell166 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell164 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell167 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell165 = new DevExpress.XtraReports.UI.XRTableCell();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.table6 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow47 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell94 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell115 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell170 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell168 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell172 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell173 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell174 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell175 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell177 = new DevExpress.XtraReports.UI.XRTableCell();
            this.table7 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow17 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell178 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell179 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell181 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell180 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell182 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.pictureBox3 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.table10 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.table1 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell132 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow19 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow13 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell134 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell190 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow34 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell189 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell194 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.table18 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow83 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell184 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell185 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell187 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
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
            this.tableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell50 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell54 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell55 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell60 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell61 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell63 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell69 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell72 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow16 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell73 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell75 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell78 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell79 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell80 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell82 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell86 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell91 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell93 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow22 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell102 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell103 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell104 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell105 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell106 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell108 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell109 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell110 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell111 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow24 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell112 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell113 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell114 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell116 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell117 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell118 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell119 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell120 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell121 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow25 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell122 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell123 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell124 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell130 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell131 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell133 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow29 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell135 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell137 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell138 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell148 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell149 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell150 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow30 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell151 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell152 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell153 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell157 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell158 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell159 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow32 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell125 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell129 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell126 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.table3 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow23 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell59 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell76 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell77 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow15 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell143 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell144 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell145 = new DevExpress.XtraReports.UI.XRTableCell();
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
            this.GroupFooter3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.table4 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow42 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell81 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell188 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableRow33 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell183 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell186 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupFooter4 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.table19 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow44 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell90 = new DevExpress.XtraReports.UI.XRTableCell();
            this.table15 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow89 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell176 = new DevExpress.XtraReports.UI.XRTableCell();
            this.label6 = new DevExpress.XtraReports.UI.XRLabel();
            this.label3 = new DevExpress.XtraReports.UI.XRLabel();
            this.label4 = new DevExpress.XtraReports.UI.XRLabel();
            this.jsonDataSource1 = new DevExpress.DataAccess.Json.JsonDataSource(this.components);
            this.xrCrossBandBox1 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            this.xrCrossBandLine1 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine2 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.GroupFooter6 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter7 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrCrossBandLine12 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter5 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrCrossBandLine13 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine4 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine5 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine6 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine7 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine8 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine9 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine10 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine11 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrCrossBandLine3 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.table5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 23.33333F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 35.97514F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table5});
            this.GroupHeader1.HeightF = 28F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // table5
            // 
            this.table5.BackColor = System.Drawing.Color.LightSkyBlue;
            this.table5.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.table5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.table5.Name = "table5";
            this.table5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.table5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow20,
            this.tableRow5});
            this.table5.SizeF = new System.Drawing.SizeF(804.9999F, 27.52651F);
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
            this.tableCell26,
            this.tableCell27,
            this.tableCell169,
            this.tableCell87,
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
            this.tableCell22.Font = new DevExpress.Drawing.DXFont("Calibri", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell22.Multiline = true;
            this.tableCell22.Name = "tableCell22";
            this.tableCell22.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 2, 0, 0, 100F);
            this.tableCell22.RowSpan = 2;
            this.tableCell22.StylePriority.UseBackColor = false;
            this.tableCell22.StylePriority.UseBorders = false;
            this.tableCell22.StylePriority.UseFont = false;
            this.tableCell22.StylePriority.UsePadding = false;
            this.tableCell22.Text = "Sr No";
            this.tableCell22.Weight = 0.28441010394084876D;
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
            this.tableCell23.Weight = 1.9017904416703728D;
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
            this.tableCell40.Weight = 0.5255606131160403D;
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
            this.tableCell24.Text = "Cur";
            this.tableCell24.Weight = 0.35623875152638573D;
            // 
            // tableCell25
            // 
            this.tableCell25.BackColor = System.Drawing.Color.Transparent;
            this.tableCell25.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell25.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell25.Name = "tableCell25";
            this.tableCell25.RowSpan = 2;
            this.tableCell25.StylePriority.UseBackColor = false;
            this.tableCell25.StylePriority.UseBorders = false;
            this.tableCell25.StylePriority.UseFont = false;
            this.tableCell25.Text = "Rate";
            this.tableCell25.Weight = 0.42024194169791235D;
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
            this.tableCell26.Weight = 0.38739501182312591D;
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
            this.tableCell27.Text = "Amount(Cur)";
            this.tableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.tableCell27.Weight = 0.66999358992294034D;
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
            this.tableCell169.Weight = 0.60241122630022814D;
            // 
            // tableCell87
            // 
            this.tableCell87.BackColor = System.Drawing.Color.Transparent;
            this.tableCell87.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell87.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell87.Multiline = true;
            this.tableCell87.Name = "tableCell87";
            this.tableCell87.RowSpan = 2;
            this.tableCell87.StylePriority.UseBackColor = false;
            this.tableCell87.StylePriority.UseBorders = false;
            this.tableCell87.StylePriority.UseFont = false;
            this.tableCell87.Text = "Taxable";
            this.tableCell87.Weight = 1.1657435577836754D;
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
            this.tableCell95.Weight = 0.96574086211784826D;
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
            this.tableCell97.Weight = 0.89250619032518874D;
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
            this.tableCell98.Text = "TOTAL (INR)";
            this.tableCell98.Weight = 0.70434679674027667D;
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
            this.tableCell154,
            this.tableCell155,
            this.tableCell156,
            this.tableCell162,
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
            this.tableCell100.Weight = 0.28441010394084876D;
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
            this.tableCell101.Weight = 1.9017904416703728D;
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
            this.tableCell141.Weight = 0.52556061311604019D;
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
            this.tableCell146.Weight = 0.35623875152638573D;
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
            this.tableCell147.Weight = 0.42024194169791224D;
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
            this.tableCell154.Weight = 0.38739501182312591D;
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
            this.tableCell155.Weight = 0.66999358992294056D;
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
            this.tableCell156.Weight = 0.60241122630022814D;
            // 
            // tableCell162
            // 
            this.tableCell162.BackColor = System.Drawing.Color.Transparent;
            this.tableCell162.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)));
            this.tableCell162.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell162.Multiline = true;
            this.tableCell162.Name = "tableCell162";
            this.tableCell162.StylePriority.UseBackColor = false;
            this.tableCell162.StylePriority.UseBorders = false;
            this.tableCell162.StylePriority.UseFont = false;
            this.tableCell162.Weight = 1.1657435577836752D;
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
            this.tableCell163.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell163.Weight = 0.30879525332355784D;
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
            this.tableCell166.Weight = 0.64923298095888493D;
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
            this.tableCell164.Weight = 0.32740281936353011D;
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
            this.tableCell167.Weight = 0.57281532578927963D;
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
            this.tableCell165.Weight = 0.70434746974806139D;
            // 
            // Detail
            // 
            this.Detail.Expanded = false;
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("bill.billId", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
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
            this.table6.SizeF = new System.Drawing.SizeF(803.9583F, 18.49059F);
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
            this.tableCell39,
            this.tableCell115,
            this.tableCell170,
            this.tableCell168,
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
            this.tableCell35.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
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
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[service_printname]")});
            this.tableCell36.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell36.Name = "tableCell36";
            this.tableCell36.StylePriority.UseBorders = false;
            this.tableCell36.StylePriority.UseFont = false;
            this.tableCell36.StylePriority.UseTextAlignment = false;
            this.tableCell36.Text = "Description";
            this.tableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.tableCell36.Weight = 2.2600519404714143D;
            // 
            // tableCell41
            // 
            this.tableCell41.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell41.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill_detail_hsncode]")});
            this.tableCell41.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell41.Multiline = true;
            this.tableCell41.Name = "tableCell41";
            this.tableCell41.StylePriority.UseBorders = false;
            this.tableCell41.StylePriority.UseFont = false;
            this.tableCell41.StylePriority.UseTextAlignment = false;
            this.tableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell41.Weight = 0.63418900034637127D;
            // 
            // tableCell94
            // 
            this.tableCell94.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell94.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill_detail_exchunit]")});
            this.tableCell94.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell94.Multiline = true;
            this.tableCell94.Name = "tableCell94";
            this.tableCell94.StylePriority.UseBorders = false;
            this.tableCell94.StylePriority.UseFont = false;
            this.tableCell94.StylePriority.UseTextAlignment = false;
            this.tableCell94.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.tableCell94.Weight = 0.4074677676416445D;
            // 
            // tableCell38
            // 
            this.tableCell38.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell38.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill_detail_rate]")});
            this.tableCell38.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell38.Name = "tableCell38";
            this.tableCell38.StylePriority.UseBorders = false;
            this.tableCell38.StylePriority.UseFont = false;
            this.tableCell38.StylePriority.UseTextAlignment = false;
            this.tableCell38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell38.Weight = 0.49521646885064585D;
            // 
            // tableCell39
            // 
            this.tableCell39.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell39.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill_detail_qty]")});
            this.tableCell39.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell39.Name = "tableCell39";
            this.tableCell39.StylePriority.UseBorders = false;
            this.tableCell39.StylePriority.UseFont = false;
            this.tableCell39.StylePriority.UseTextAlignment = false;
            this.tableCell39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell39.Weight = 0.45883213572094328D;
            // 
            // tableCell115
            // 
            this.tableCell115.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell115.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill_detail_amount]")});
            this.tableCell115.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell115.Name = "tableCell115";
            this.tableCell115.StylePriority.UseBorders = false;
            this.tableCell115.StylePriority.UseFont = false;
            this.tableCell115.StylePriority.UseTextAlignment = false;
            this.tableCell115.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell115.Weight = 0.79145360109792451D;
            // 
            // tableCell170
            // 
            this.tableCell170.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell170.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill_detail_exchrate]")});
            this.tableCell170.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell170.Name = "tableCell170";
            this.tableCell170.StylePriority.UseBorders = false;
            this.tableCell170.StylePriority.UseFont = false;
            this.tableCell170.StylePriority.UseTextAlignment = false;
            this.tableCell170.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell170.TextFormatString = "{0:#.00}";
            this.tableCell170.Weight = 0.71161919705050747D;
            // 
            // tableCell168
            // 
            this.tableCell168.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell168.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill_detail_taxableamt]")});
            this.tableCell168.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell168.Multiline = true;
            this.tableCell168.Name = "tableCell168";
            this.tableCell168.StylePriority.UseBorders = false;
            this.tableCell168.StylePriority.UseFont = false;
            this.tableCell168.StylePriority.UseTextAlignment = false;
            this.tableCell168.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell168.TextFormatString = "{0:#.00}";
            this.tableCell168.Weight = 1.418047898617707D;
            // 
            // tableCell172
            // 
            this.tableCell172.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell172.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill_detail_cgstper]")});
            this.tableCell172.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell172.Multiline = true;
            this.tableCell172.Name = "tableCell172";
            this.tableCell172.StylePriority.UseBorders = false;
            this.tableCell172.StylePriority.UseFont = false;
            this.tableCell172.StylePriority.UseTextAlignment = false;
            this.tableCell172.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell172.Weight = 0.35306553186887035D;
            // 
            // tableCell173
            // 
            this.tableCell173.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell173.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill_detail_cgst]")});
            this.tableCell173.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell173.Multiline = true;
            this.tableCell173.Name = "tableCell173";
            this.tableCell173.StylePriority.UseBorders = false;
            this.tableCell173.StylePriority.UseFont = false;
            this.tableCell173.StylePriority.UseTextAlignment = false;
            this.tableCell173.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell173.TextFormatString = "{0:#.00}";
            this.tableCell173.Weight = 0.778941855112032D;
            // 
            // tableCell174
            // 
            this.tableCell174.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell174.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill_detail_sgstper]")});
            this.tableCell174.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell174.Multiline = true;
            this.tableCell174.Name = "tableCell174";
            this.tableCell174.StylePriority.UseBorders = false;
            this.tableCell174.StylePriority.UseFont = false;
            this.tableCell174.StylePriority.UseTextAlignment = false;
            this.tableCell174.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell174.Weight = 0.38842217746651614D;
            // 
            // tableCell175
            // 
            this.tableCell175.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell175.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill_detail_sgst]")});
            this.tableCell175.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell175.Multiline = true;
            this.tableCell175.Name = "tableCell175";
            this.tableCell175.StylePriority.UseBorders = false;
            this.tableCell175.StylePriority.UseFont = false;
            this.tableCell175.StylePriority.UseTextAlignment = false;
            this.tableCell175.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell175.TextFormatString = "{0:#.00}";
            this.tableCell175.Weight = 0.64947414690886551D;
            // 
            // tableCell177
            // 
            this.tableCell177.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell177.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill_detail_total]")});
            this.tableCell177.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell177.Multiline = true;
            this.tableCell177.Name = "tableCell177";
            this.tableCell177.StylePriority.UseBorders = false;
            this.tableCell177.StylePriority.UseFont = false;
            this.tableCell177.StylePriority.UseTextAlignment = false;
            this.tableCell177.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell177.TextFormatString = "{0:#.00}";
            this.tableCell177.Weight = 0.84187956255407215D;
            // 
            // table7
            // 
            this.table7.BackColor = System.Drawing.Color.LightSkyBlue;
            this.table7.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.table7.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.table7.LocationFloat = new DevExpress.Utils.PointFloat(1.041499F, 0F);
            this.table7.Name = "table7";
            this.table7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.table7.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow17});
            this.table7.SizeF = new System.Drawing.SizeF(803.9584F, 14.92067F);
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
            this.tableCell32.Text = "Sub Total";
            this.tableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell32.Weight = 3.2918422200230424D;
            // 
            // tableCell30
            // 
            this.tableCell30.BackColor = System.Drawing.Color.Transparent;
            this.tableCell30.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell30.Font = new DevExpress.Drawing.DXFont("Calibri", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell30.Multiline = true;
            this.tableCell30.Name = "tableCell30";
            this.tableCell30.StylePriority.UseBackColor = false;
            this.tableCell30.StylePriority.UseBorders = false;
            this.tableCell30.StylePriority.UseFont = false;
            this.tableCell30.Weight = 0.50683180965184493D;
            // 
            // tableCell178
            // 
            this.tableCell178.BackColor = System.Drawing.Color.Transparent;
            this.tableCell178.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell178.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([bill_detail_taxableamt])")});
            this.tableCell178.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell178.Multiline = true;
            this.tableCell178.Name = "tableCell178";
            this.tableCell178.StylePriority.UseBackColor = false;
            this.tableCell178.StylePriority.UseBorders = false;
            this.tableCell178.StylePriority.UseFont = false;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.tableCell178.Summary = xrSummary2;
            this.tableCell178.TextFormatString = "{0:#.00}";
            this.tableCell178.Weight = 0.88776866992702863D;
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
            this.tableCell179.Weight = 0.2295615366647285D;
            // 
            // tableCell181
            // 
            this.tableCell181.BackColor = System.Drawing.Color.Transparent;
            this.tableCell181.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell181.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([bill_detail_cgst])")});
            this.tableCell181.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell181.Multiline = true;
            this.tableCell181.Name = "tableCell181";
            this.tableCell181.StylePriority.UseBackColor = false;
            this.tableCell181.StylePriority.UseBorders = false;
            this.tableCell181.StylePriority.UseFont = false;
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.tableCell181.Summary = xrSummary3;
            this.tableCell181.TextFormatString = "{0:#.00}";
            this.tableCell181.Weight = 0.48731631705271283D;
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
            this.tableCell180.Weight = 0.23764946298600409D;
            // 
            // tableCell182
            // 
            this.tableCell182.BackColor = System.Drawing.Color.Transparent;
            this.tableCell182.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell182.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([bill_detail_sgst])")});
            this.tableCell182.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell182.Multiline = true;
            this.tableCell182.Name = "tableCell182";
            this.tableCell182.StylePriority.UseBackColor = false;
            this.tableCell182.StylePriority.UseBorders = false;
            this.tableCell182.StylePriority.UseFont = false;
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.tableCell182.Summary = xrSummary4;
            this.tableCell182.TextFormatString = "{0:#.00}";
            this.tableCell182.Weight = 0.41668070867125467D;
            // 
            // tableCell42
            // 
            this.tableCell42.BackColor = System.Drawing.Color.Transparent;
            this.tableCell42.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell42.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([bill_detail_total])")});
            this.tableCell42.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell42.Name = "tableCell42";
            this.tableCell42.StylePriority.UseBackColor = false;
            this.tableCell42.StylePriority.UseBorders = false;
            this.tableCell42.StylePriority.UseFont = false;
            this.tableCell42.StylePriority.UseTextAlignment = false;
            xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.tableCell42.Summary = xrSummary5;
            this.tableCell42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell42.TextFormatString = "{0:#.00}";
            this.tableCell42.Weight = 0.52284408160237417D;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pictureBox3,
            this.table10,
            this.table1,
            this.xrPictureBox1});
            this.ReportHeader.HeightF = 131F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // pictureBox3
            // 
            this.pictureBox3.LocationFloat = new DevExpress.Utils.PointFloat(694.0165F, 0F);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.SizeF = new System.Drawing.SizeF(109.9418F, 117.5678F);
            this.pictureBox3.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // table10
            // 
            this.table10.LocationFloat = new DevExpress.Utils.PointFloat(3.041808F, 117.5678F);
            this.table10.Name = "table10";
            this.table10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.table10.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow4});
            this.table10.SizeF = new System.Drawing.SizeF(801.9583F, 13.22915F);
            // 
            // tableRow4
            // 
            this.tableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell5,
            this.tableCell10,
            this.tableCell19});
            this.tableRow4.Name = "tableRow4";
            this.tableRow4.Weight = 1D;
            // 
            // tableCell5
            // 
            this.tableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_ack_no]")});
            this.tableCell5.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.tableCell5.Multiline = true;
            this.tableCell5.Name = "tableCell5";
            this.tableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.tableCell5.StylePriority.UseFont = false;
            this.tableCell5.StylePriority.UsePadding = false;
            this.tableCell5.Text = "tableCell5";
            this.tableCell5.TextFormatString = "AKN No : {0}";
            this.tableCell5.Weight = 0.77151584174298415D;
            // 
            // tableCell10
            // 
            this.tableCell10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_ack_date]")});
            this.tableCell10.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.tableCell10.Multiline = true;
            this.tableCell10.Name = "tableCell10";
            this.tableCell10.StylePriority.UseFont = false;
            this.tableCell10.Text = "tableCell10";
            this.tableCell10.TextFormatString = "AKN Date : {0}";
            this.tableCell10.Weight = 0.61239216777858119D;
            // 
            // tableCell19
            // 
            this.tableCell19.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_irn_no]")});
            this.tableCell19.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.tableCell19.Multiline = true;
            this.tableCell19.Name = "tableCell19";
            this.tableCell19.StylePriority.UseFont = false;
            this.tableCell19.Text = "tableCell19";
            this.tableCell19.TextFormatString = "IRN No : {0}";
            this.tableCell19.Weight = 1.5682372241558418D;
            // 
            // table1
            // 
            this.table1.LocationFloat = new DevExpress.Utils.PointFloat(153.625F, 0F);
            this.table1.Name = "table1";
            this.table1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.table1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow1,
            this.tableRow2,
            this.tableRow7,
            this.tableRow11,
            this.tableRow19,
            this.tableRow13,
            this.tableRow34});
            this.table1.SizeF = new System.Drawing.SizeF(540.3915F, 117.5678F);
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
            this.tableCell1.Multiline = true;
            this.tableCell1.Name = "tableCell1";
            this.tableCell1.StylePriority.UseFont = false;
            this.tableCell1.StylePriority.UseTextAlignment = false;
            this.tableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.tableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell4.Weight = 3D;
            // 
            // tableRow7
            // 
            this.tableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell3});
            this.tableRow7.Name = "tableRow7";
            this.tableRow7.Weight = 0.38922798819828652D;
            // 
            // tableCell3
            // 
            this.tableCell3.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F);
            this.tableCell3.Multiline = true;
            this.tableCell3.Name = "tableCell3";
            this.tableCell3.StylePriority.UseFont = false;
            this.tableCell3.StylePriority.UseTextAlignment = false;
            this.tableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell3.Weight = 3D;
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
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'Contact  No:\'+[bill].[company_mobile] ")});
            this.tableCell132.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F);
            this.tableCell132.Multiline = true;
            this.tableCell132.Name = "tableCell132";
            this.tableCell132.StylePriority.UseFont = false;
            this.tableCell132.StylePriority.UseTextAlignment = false;
            this.tableCell132.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\' Email :\'+ [bill].[company_email]+\' ,  Website : \'+ [bill].[company_website]\n\n")});
            this.tableCell15.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F);
            this.tableCell15.Multiline = true;
            this.tableCell15.Name = "tableCell15";
            this.tableCell15.StylePriority.UseFont = false;
            this.tableCell15.StylePriority.UseTextAlignment = false;
            this.tableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell15.Weight = 3D;
            // 
            // tableRow13
            // 
            this.tableRow13.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell134,
            this.tableCell190});
            this.tableRow13.Name = "tableRow13";
            this.tableRow13.Weight = 0.38922798819828652D;
            // 
            // tableCell134
            // 
            this.tableCell134.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[company_gstin]")});
            this.tableCell134.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell134.Multiline = true;
            this.tableCell134.Name = "tableCell134";
            this.tableCell134.StylePriority.UseFont = false;
            this.tableCell134.StylePriority.UseTextAlignment = false;
            this.tableCell134.Text = "GSTIN";
            this.tableCell134.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.tableCell134.TextFormatString = "GSTIN   : {0}";
            this.tableCell134.Weight = 1.4392771438990157D;
            // 
            // tableCell190
            // 
            this.tableCell190.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[state_Company]")});
            this.tableCell190.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell190.Multiline = true;
            this.tableCell190.Name = "tableCell190";
            this.tableCell190.StylePriority.UseFont = false;
            this.tableCell190.StylePriority.UseTextAlignment = false;
            this.tableCell190.Text = "State : ";
            this.tableCell190.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.tableCell190.TextFormatString = "State :  {0}";
            this.tableCell190.Weight = 1.5607228561009843D;
            // 
            // tableRow34
            // 
            this.tableRow34.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell189,
            this.tableCell194});
            this.tableRow34.Name = "tableRow34";
            this.tableRow34.Weight = 0.38922798819828652D;
            // 
            // tableCell189
            // 
            this.tableCell189.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[company_panno]")});
            this.tableCell189.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell189.Multiline = true;
            this.tableCell189.Name = "tableCell189";
            this.tableCell189.StylePriority.UseFont = false;
            this.tableCell189.StylePriority.UseTextAlignment = false;
            this.tableCell189.Text = "PAN No  : ";
            this.tableCell189.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.tableCell189.TextFormatString = "PAN No  :  {0}";
            this.tableCell189.Weight = 1.4392771438990157D;
            // 
            // tableCell194
            // 
            this.tableCell194.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell194.Multiline = true;
            this.tableCell194.Name = "tableCell194";
            this.tableCell194.StylePriority.UseFont = false;
            this.tableCell194.StylePriority.UseTextAlignment = false;
            this.tableCell194.Text = "CIN :  U63012RJ2011PTC035399";
            this.tableCell194.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.tableCell194.Weight = 1.5607228561009843D;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table18});
            this.GroupHeader2.HeightF = 213.7393F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
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
            this.tableRow83,
            this.xrTableRow1,
            this.tableRow85,
            this.tableRow87,
            this.tableRow88,
            this.tableRow90,
            this.tableRow91,
            this.tableRow3,
            this.tableRow8,
            this.tableRow6,
            this.tableRow16,
            this.tableRow22,
            this.tableRow24,
            this.tableRow25,
            this.tableRow29,
            this.tableRow30,
            this.tableRow32});
            this.table18.SizeF = new System.Drawing.SizeF(803.9584F, 213.7393F);
            this.table18.StylePriority.UseBorders = false;
            this.table18.StylePriority.UseBorderWidth = false;
            this.table18.StylePriority.UseFont = false;
            this.table18.StylePriority.UsePadding = false;
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
            this.tableCell37.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
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
            this.tableCell184.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell184.Name = "tableCell184";
            this.tableCell184.StylePriority.UseBorders = false;
            this.tableCell184.StylePriority.UseFont = false;
            this.tableCell184.Text = "Bill No.";
            this.tableCell184.TextFormatString = "{0} No. ";
            this.tableCell184.Weight = 2.67404000824327D;
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
            this.tableCell185.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell185.Weight = 0.17320435791127195D;
            // 
            // tableCell187
            // 
            this.tableCell187.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.tableCell187.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_no]")});
            this.tableCell187.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell187.Name = "tableCell187";
            this.tableCell187.StylePriority.UseBorders = false;
            this.tableCell187.StylePriority.UseFont = false;
            this.tableCell187.Text = "tableCell177";
            this.tableCell187.Weight = 4.1534884490611743D;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 0.625D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[account_print_name]")});
            this.xrTableCell1.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "xrTableCell1";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell1.Weight = 6.7343384494952829D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
            this.xrTableCell2.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseBorders = false;
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.Text = "Date";
            this.xrTableCell2.Weight = 2.67404000824327D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell3.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = ":";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell3.Weight = 0.17320435791127195D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_date]")});
            this.xrTableCell4.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseBorders = false;
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.Text = "xrTableCell4";
            this.xrTableCell4.TextFormatString = "{0:dd-MM-yyyy}";
            this.xrTableCell4.Weight = 4.1534884490611743D;
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
            this.tableCell58.Borders = DevExpress.XtraPrinting.BorderSide.Left;
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
            this.tableCell58.Weight = 6.7371816690637889D;
            // 
            // tableCell242
            // 
            this.tableCell242.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell242.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell242.Name = "tableCell242";
            this.tableCell242.StylePriority.UseBorders = false;
            this.tableCell242.StylePriority.UseFont = false;
            this.tableCell242.Text = "Due Date";
            this.tableCell242.Weight = 2.6746560859750694D;
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
            this.tableCell243.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell243.Weight = 0.17317469296810931D;
            // 
            // tableCell244
            // 
            this.tableCell244.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell244.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_duedate]")});
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
            this.tableCell248.StylePriority.UseBorders = false;
            this.tableCell248.StylePriority.UseFont = false;
            this.tableCell248.Text = "Place of Supply";
            this.tableCell248.Weight = 2.674656085975069D;
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
            this.tableCell249.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell249.Weight = 0.17317469423287626D;
            // 
            // tableCell250
            // 
            this.tableCell250.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell250.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[placeofSupply]")});
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
            this.tableCell254.StylePriority.UseBorders = false;
            this.tableCell254.StylePriority.UseFont = false;
            this.tableCell254.Text = "Shipment No.";
            this.tableCell254.Weight = 2.6746560500605217D;
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
            this.tableCell255.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell255.Weight = 0.1731703542917038D;
            // 
            // tableCell256
            // 
            this.tableCell256.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell256.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_jobno]")});
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
            this.tableCell88.Borders = DevExpress.XtraPrinting.BorderSide.Left;
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
            this.tableCell260.StylePriority.UseBorders = false;
            this.tableCell260.StylePriority.UseFont = false;
            this.tableCell260.Text = "Shipment Type";
            this.tableCell260.Weight = 2.6746560859751125D;
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
            this.tableCell261.Weight = 0.1731703196420101D;
            // 
            // tableCell262
            // 
            this.tableCell262.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell262.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_jobtype]")});
            this.tableCell262.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell262.Name = "tableCell262";
            this.tableCell262.StylePriority.UseBorders = false;
            this.tableCell262.StylePriority.UseFont = false;
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
            this.tableCell89.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell89.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell89.Multiline = true;
            this.tableCell89.Name = "tableCell89";
            this.tableCell89.StylePriority.UseBorders = false;
            this.tableCell89.StylePriority.UseFont = false;
            this.tableCell89.Text = "GSTN ";
            this.tableCell89.Weight = 1.1191058528066944D;
            // 
            // tableCell142
            // 
            this.tableCell142.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.tableCell142.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[account_gstno]")});
            this.tableCell142.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell142.Multiline = true;
            this.tableCell142.Name = "tableCell142";
            this.tableCell142.StylePriority.UseBorders = false;
            this.tableCell142.StylePriority.UseFont = false;
            this.tableCell142.Text = "tableCell142";
            this.tableCell142.TextFormatString = ":{0}";
            this.tableCell142.Weight = 2.485692887627434D;
            // 
            // tableCell85
            // 
            this.tableCell85.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.tableCell85.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'State :\'+[bill].[account_state]")});
            this.tableCell85.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell85.Multiline = true;
            this.tableCell85.Name = "tableCell85";
            this.tableCell85.StylePriority.UseBorders = false;
            this.tableCell85.StylePriority.UseFont = false;
            this.tableCell85.Weight = 3.1295384580865844D;
            // 
            // tableCell266
            // 
            this.tableCell266.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell266.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell266.Name = "tableCell266";
            this.tableCell266.StylePriority.UseBorders = false;
            this.tableCell266.StylePriority.UseFont = false;
            this.tableCell266.Weight = 7.0007325613956111D;
            // 
            // tableRow3
            // 
            this.tableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell2,
            this.tableCell6,
            this.tableCell7,
            this.tableCell8,
            this.tableCell28,
            this.tableCell21});
            this.tableRow3.Name = "tableRow3";
            this.tableRow3.Weight = 0.625D;
            // 
            // tableCell2
            // 
            this.tableCell2.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell2.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell2.Multiline = true;
            this.tableCell2.Name = "tableCell2";
            this.tableCell2.StylePriority.UseBorders = false;
            this.tableCell2.StylePriority.UseFont = false;
            this.tableCell2.Text = "Cargo Type";
            this.tableCell2.Weight = 1.6102404479088539D;
            // 
            // tableCell6
            // 
            this.tableCell6.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell6.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell6.Multiline = true;
            this.tableCell6.Name = "tableCell6";
            this.tableCell6.StylePriority.UseBorders = false;
            this.tableCell6.StylePriority.UseFont = false;
            this.tableCell6.StylePriority.UseTextAlignment = false;
            this.tableCell6.Text = ":";
            this.tableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell6.Weight = 0.1984609918383185D;
            // 
            // tableCell7
            // 
            this.tableCell7.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[cargo]")});
            this.tableCell7.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell7.Multiline = true;
            this.tableCell7.Name = "tableCell7";
            this.tableCell7.StylePriority.UseBorders = false;
            this.tableCell7.StylePriority.UseFont = false;
            this.tableCell7.Weight = 4.92563575877354D;
            // 
            // tableCell8
            // 
            this.tableCell8.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell8.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell8.Multiline = true;
            this.tableCell8.Name = "tableCell8";
            this.tableCell8.StylePriority.UseBorders = false;
            this.tableCell8.StylePriority.UseFont = false;
            this.tableCell8.Text = "Shipper Ref.";
            this.tableCell8.Weight = 2.6723373220826985D;
            // 
            // tableCell28
            // 
            this.tableCell28.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell28.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell28.Multiline = true;
            this.tableCell28.Name = "tableCell28";
            this.tableCell28.StylePriority.UseBorders = false;
            this.tableCell28.StylePriority.UseFont = false;
            this.tableCell28.StylePriority.UseTextAlignment = false;
            this.tableCell28.Text = ":";
            this.tableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell28.Weight = 0.17490778490706702D;
            // 
            // tableCell21
            // 
            this.tableCell21.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell21.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[shipper_invno]")});
            this.tableCell21.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell21.Multiline = true;
            this.tableCell21.Name = "tableCell21";
            this.tableCell21.StylePriority.UseBorders = false;
            this.tableCell21.StylePriority.UseFont = false;
            this.tableCell21.Weight = 4.1534874544058455D;
            // 
            // tableRow8
            // 
            this.tableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell9,
            this.tableCell11,
            this.tableCell12,
            this.tableCell14,
            this.tableCell17,
            this.tableCell16,
            this.tableCell13,
            this.tableCell33,
            this.tableCell29});
            this.tableRow8.Name = "tableRow8";
            this.tableRow8.Weight = 0.625D;
            // 
            // tableCell9
            // 
            this.tableCell9.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell9.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell9.Multiline = true;
            this.tableCell9.Name = "tableCell9";
            this.tableCell9.StylePriority.UseBorders = false;
            this.tableCell9.StylePriority.UseFont = false;
            this.tableCell9.Text = "MBL No.";
            this.tableCell9.Weight = 1.6102404479088539D;
            // 
            // tableCell11
            // 
            this.tableCell11.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell11.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell11.Multiline = true;
            this.tableCell11.Name = "tableCell11";
            this.tableCell11.StylePriority.UseBorders = false;
            this.tableCell11.StylePriority.UseFont = false;
            this.tableCell11.StylePriority.UseTextAlignment = false;
            this.tableCell11.Text = ":";
            this.tableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell11.Weight = 0.19846099183831839D;
            // 
            // tableCell12
            // 
            this.tableCell12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell12.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_blno]")});
            this.tableCell12.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell12.Multiline = true;
            this.tableCell12.Name = "tableCell12";
            this.tableCell12.StylePriority.UseBorders = false;
            this.tableCell12.StylePriority.UseFont = false;
            this.tableCell12.Weight = 2.3814958778854538D;
            // 
            // tableCell14
            // 
            this.tableCell14.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell14.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell14.Multiline = true;
            this.tableCell14.Name = "tableCell14";
            this.tableCell14.StylePriority.UseBorders = false;
            this.tableCell14.StylePriority.UseFont = false;
            this.tableCell14.Text = "Date";
            this.tableCell14.Weight = 0.63603497022202171D;
            // 
            // tableCell17
            // 
            this.tableCell17.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell17.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell17.Multiline = true;
            this.tableCell17.Name = "tableCell17";
            this.tableCell17.StylePriority.UseBorders = false;
            this.tableCell17.StylePriority.UseFont = false;
            this.tableCell17.StylePriority.UseTextAlignment = false;
            this.tableCell17.Text = ":";
            this.tableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell17.Weight = 0.63603497022202171D;
            // 
            // tableCell16
            // 
            this.tableCell16.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell16.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_bldate]")});
            this.tableCell16.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell16.Multiline = true;
            this.tableCell16.Name = "tableCell16";
            this.tableCell16.StylePriority.UseBorders = false;
            this.tableCell16.StylePriority.UseFont = false;
            this.tableCell16.TextFormatString = "{0:dd-MM-yyyy}";
            this.tableCell16.Weight = 1.2720699404440434D;
            // 
            // tableCell13
            // 
            this.tableCell13.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell13.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell13.Multiline = true;
            this.tableCell13.Name = "tableCell13";
            this.tableCell13.StylePriority.UseBorders = false;
            this.tableCell13.StylePriority.UseFont = false;
            this.tableCell13.Text = "Inco Terms";
            this.tableCell13.Weight = 2.6723362290349435D;
            // 
            // tableCell33
            // 
            this.tableCell33.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell33.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell33.Multiline = true;
            this.tableCell33.Name = "tableCell33";
            this.tableCell33.StylePriority.UseBorders = false;
            this.tableCell33.StylePriority.UseFont = false;
            this.tableCell33.StylePriority.UseTextAlignment = false;
            this.tableCell33.Text = ":";
            this.tableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell33.Weight = 0.174907784907067D;
            // 
            // tableCell29
            // 
            this.tableCell29.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell29.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell29.Multiline = true;
            this.tableCell29.Name = "tableCell29";
            this.tableCell29.StylePriority.UseBorders = false;
            this.tableCell29.StylePriority.UseFont = false;
            this.tableCell29.Weight = 4.1534885474536D;
            // 
            // tableRow6
            // 
            this.tableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell46,
            this.tableCell50,
            this.tableCell54,
            this.tableCell55,
            this.tableCell60,
            this.tableCell61,
            this.tableCell63,
            this.tableCell69,
            this.tableCell72});
            this.tableRow6.Name = "tableRow6";
            this.tableRow6.Weight = 0.625D;
            // 
            // tableCell46
            // 
            this.tableCell46.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell46.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell46.Multiline = true;
            this.tableCell46.Name = "tableCell46";
            this.tableCell46.StylePriority.UseBorders = false;
            this.tableCell46.StylePriority.UseFont = false;
            this.tableCell46.Text = "HBL No.";
            this.tableCell46.Weight = 1.6102404479088539D;
            // 
            // tableCell50
            // 
            this.tableCell50.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell50.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell50.Multiline = true;
            this.tableCell50.Name = "tableCell50";
            this.tableCell50.StylePriority.UseBorders = false;
            this.tableCell50.StylePriority.UseFont = false;
            this.tableCell50.StylePriority.UseTextAlignment = false;
            this.tableCell50.Text = ":";
            this.tableCell50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell50.Weight = 0.19846099183831839D;
            // 
            // tableCell54
            // 
            this.tableCell54.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell54.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_hblno]")});
            this.tableCell54.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell54.Multiline = true;
            this.tableCell54.Name = "tableCell54";
            this.tableCell54.StylePriority.UseBorders = false;
            this.tableCell54.StylePriority.UseFont = false;
            this.tableCell54.Weight = 2.3814958778854538D;
            // 
            // tableCell55
            // 
            this.tableCell55.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell55.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell55.Multiline = true;
            this.tableCell55.Name = "tableCell55";
            this.tableCell55.StylePriority.UseBorders = false;
            this.tableCell55.StylePriority.UseFont = false;
            this.tableCell55.Text = "Date";
            this.tableCell55.Weight = 0.63603497022202171D;
            // 
            // tableCell60
            // 
            this.tableCell60.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell60.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell60.Multiline = true;
            this.tableCell60.Name = "tableCell60";
            this.tableCell60.StylePriority.UseBorders = false;
            this.tableCell60.StylePriority.UseFont = false;
            this.tableCell60.StylePriority.UseTextAlignment = false;
            this.tableCell60.Text = ":";
            this.tableCell60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell60.Weight = 0.63603497022202171D;
            // 
            // tableCell61
            // 
            this.tableCell61.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell61.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_hbldate]")});
            this.tableCell61.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell61.Multiline = true;
            this.tableCell61.Name = "tableCell61";
            this.tableCell61.StylePriority.UseBorders = false;
            this.tableCell61.StylePriority.UseFont = false;
            this.tableCell61.TextFormatString = "{0:dd-MM-yyyy}";
            this.tableCell61.Weight = 1.2720699404440434D;
            // 
            // tableCell63
            // 
            this.tableCell63.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell63.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell63.Multiline = true;
            this.tableCell63.Name = "tableCell63";
            this.tableCell63.StylePriority.UseBorders = false;
            this.tableCell63.StylePriority.UseFont = false;
            this.tableCell63.Text = "Shipper";
            this.tableCell63.Weight = 2.6723362290349435D;
            // 
            // tableCell69
            // 
            this.tableCell69.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell69.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell69.Multiline = true;
            this.tableCell69.Name = "tableCell69";
            this.tableCell69.StylePriority.UseBorders = false;
            this.tableCell69.StylePriority.UseFont = false;
            this.tableCell69.StylePriority.UseTextAlignment = false;
            this.tableCell69.Text = ":";
            this.tableCell69.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell69.Weight = 0.174907784907067D;
            // 
            // tableCell72
            // 
            this.tableCell72.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell72.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[shipper]")});
            this.tableCell72.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell72.Multiline = true;
            this.tableCell72.Name = "tableCell72";
            this.tableCell72.StylePriority.UseBorders = false;
            this.tableCell72.StylePriority.UseFont = false;
            this.tableCell72.Weight = 4.1534885474536D;
            // 
            // tableRow16
            // 
            this.tableRow16.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell73,
            this.tableCell75,
            this.tableCell78,
            this.tableCell79,
            this.tableCell80,
            this.tableCell82,
            this.tableCell86,
            this.tableCell91,
            this.tableCell93});
            this.tableRow16.Name = "tableRow16";
            this.tableRow16.Weight = 0.625D;
            // 
            // tableCell73
            // 
            this.tableCell73.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell73.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell73.Multiline = true;
            this.tableCell73.Name = "tableCell73";
            this.tableCell73.StylePriority.UseBorders = false;
            this.tableCell73.StylePriority.UseFont = false;
            this.tableCell73.Text = "SB No.";
            this.tableCell73.Weight = 1.6102404479088539D;
            // 
            // tableCell75
            // 
            this.tableCell75.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell75.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell75.Multiline = true;
            this.tableCell75.Name = "tableCell75";
            this.tableCell75.StylePriority.UseBorders = false;
            this.tableCell75.StylePriority.UseFont = false;
            this.tableCell75.StylePriority.UseTextAlignment = false;
            this.tableCell75.Text = ":";
            this.tableCell75.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell75.Weight = 0.19846099183831839D;
            // 
            // tableCell78
            // 
            this.tableCell78.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell78.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_sbno]")});
            this.tableCell78.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell78.Multiline = true;
            this.tableCell78.Name = "tableCell78";
            this.tableCell78.StylePriority.UseBorders = false;
            this.tableCell78.StylePriority.UseFont = false;
            this.tableCell78.Weight = 2.3814958778854538D;
            // 
            // tableCell79
            // 
            this.tableCell79.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell79.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell79.Multiline = true;
            this.tableCell79.Name = "tableCell79";
            this.tableCell79.StylePriority.UseBorders = false;
            this.tableCell79.StylePriority.UseFont = false;
            this.tableCell79.Text = "Date";
            this.tableCell79.Weight = 0.63603497022202171D;
            // 
            // tableCell80
            // 
            this.tableCell80.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell80.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell80.Multiline = true;
            this.tableCell80.Name = "tableCell80";
            this.tableCell80.StylePriority.UseBorders = false;
            this.tableCell80.StylePriority.UseFont = false;
            this.tableCell80.StylePriority.UseTextAlignment = false;
            this.tableCell80.Text = ":";
            this.tableCell80.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell80.Weight = 0.63603497022202171D;
            // 
            // tableCell82
            // 
            this.tableCell82.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell82.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_sbdate]")});
            this.tableCell82.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell82.Multiline = true;
            this.tableCell82.Name = "tableCell82";
            this.tableCell82.StylePriority.UseBorders = false;
            this.tableCell82.StylePriority.UseFont = false;
            this.tableCell82.TextFormatString = "{0:dd-MM-yyyy}";
            this.tableCell82.Weight = 1.2720699404440434D;
            // 
            // tableCell86
            // 
            this.tableCell86.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell86.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell86.Multiline = true;
            this.tableCell86.Name = "tableCell86";
            this.tableCell86.StylePriority.UseBorders = false;
            this.tableCell86.StylePriority.UseFont = false;
            this.tableCell86.Text = "Consignee";
            this.tableCell86.Weight = 2.6723362290349435D;
            // 
            // tableCell91
            // 
            this.tableCell91.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell91.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell91.Multiline = true;
            this.tableCell91.Name = "tableCell91";
            this.tableCell91.StylePriority.UseBorders = false;
            this.tableCell91.StylePriority.UseFont = false;
            this.tableCell91.StylePriority.UseTextAlignment = false;
            this.tableCell91.Text = ":";
            this.tableCell91.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell91.Weight = 0.174907784907067D;
            // 
            // tableCell93
            // 
            this.tableCell93.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell93.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[consignee]")});
            this.tableCell93.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell93.Multiline = true;
            this.tableCell93.Name = "tableCell93";
            this.tableCell93.StylePriority.UseBorders = false;
            this.tableCell93.StylePriority.UseFont = false;
            this.tableCell93.Weight = 4.1534885474536D;
            // 
            // tableRow22
            // 
            this.tableRow22.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell102,
            this.tableCell103,
            this.tableCell104,
            this.tableCell105,
            this.tableCell106,
            this.tableCell108,
            this.tableCell109,
            this.tableCell110,
            this.tableCell111});
            this.tableRow22.Name = "tableRow22";
            this.tableRow22.Weight = 0.625D;
            // 
            // tableCell102
            // 
            this.tableCell102.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell102.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell102.Multiline = true;
            this.tableCell102.Name = "tableCell102";
            this.tableCell102.StylePriority.UseBorders = false;
            this.tableCell102.StylePriority.UseFont = false;
            this.tableCell102.Text = "Packages";
            this.tableCell102.Weight = 1.6102404479088539D;
            // 
            // tableCell103
            // 
            this.tableCell103.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell103.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell103.Multiline = true;
            this.tableCell103.Name = "tableCell103";
            this.tableCell103.StylePriority.UseBorders = false;
            this.tableCell103.StylePriority.UseFont = false;
            this.tableCell103.StylePriority.UseTextAlignment = false;
            this.tableCell103.Text = ":";
            this.tableCell103.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell103.Weight = 0.19846099183831839D;
            // 
            // tableCell104
            // 
            this.tableCell104.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell104.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell104.Multiline = true;
            this.tableCell104.Name = "tableCell104";
            this.tableCell104.StylePriority.UseBorders = false;
            this.tableCell104.StylePriority.UseFont = false;
            this.tableCell104.Weight = 2.0176214416107667D;
            // 
            // tableCell105
            // 
            this.tableCell105.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell105.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell105.Multiline = true;
            this.tableCell105.Name = "tableCell105";
            this.tableCell105.StylePriority.UseBorders = false;
            this.tableCell105.StylePriority.UseFont = false;
            this.tableCell105.StylePriority.UseTextAlignment = false;
            this.tableCell105.Text = "Gross Wt.";
            this.tableCell105.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell105.Weight = 0.99990940649670834D;
            // 
            // tableCell106
            // 
            this.tableCell106.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell106.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell106.Multiline = true;
            this.tableCell106.Name = "tableCell106";
            this.tableCell106.StylePriority.UseBorders = false;
            this.tableCell106.StylePriority.UseFont = false;
            this.tableCell106.StylePriority.UseTextAlignment = false;
            this.tableCell106.Text = ":";
            this.tableCell106.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell106.Weight = 0.63603497022202171D;
            // 
            // tableCell108
            // 
            this.tableCell108.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell108.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_grosswt]")});
            this.tableCell108.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell108.Multiline = true;
            this.tableCell108.Name = "tableCell108";
            this.tableCell108.StylePriority.UseBorders = false;
            this.tableCell108.StylePriority.UseFont = false;
            this.tableCell108.Weight = 1.2720699404440434D;
            // 
            // tableCell109
            // 
            this.tableCell109.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell109.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell109.Multiline = true;
            this.tableCell109.Name = "tableCell109";
            this.tableCell109.StylePriority.UseBorders = false;
            this.tableCell109.StylePriority.UseFont = false;
            this.tableCell109.Text = "Place of Receipt";
            this.tableCell109.Weight = 2.6723362290349435D;
            // 
            // tableCell110
            // 
            this.tableCell110.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell110.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell110.Multiline = true;
            this.tableCell110.Name = "tableCell110";
            this.tableCell110.StylePriority.UseBorders = false;
            this.tableCell110.StylePriority.UseFont = false;
            this.tableCell110.StylePriority.UseTextAlignment = false;
            this.tableCell110.Text = ":";
            this.tableCell110.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell110.Weight = 0.17490778490706702D;
            // 
            // tableCell111
            // 
            this.tableCell111.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell111.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[place_of_receipt]")});
            this.tableCell111.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell111.Multiline = true;
            this.tableCell111.Name = "tableCell111";
            this.tableCell111.StylePriority.UseBorders = false;
            this.tableCell111.StylePriority.UseFont = false;
            this.tableCell111.Weight = 4.1534885474536D;
            // 
            // tableRow24
            // 
            this.tableRow24.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell112,
            this.tableCell113,
            this.tableCell114,
            this.tableCell116,
            this.tableCell117,
            this.tableCell118,
            this.tableCell119,
            this.tableCell120,
            this.tableCell121});
            this.tableRow24.Name = "tableRow24";
            this.tableRow24.Weight = 0.625D;
            // 
            // tableCell112
            // 
            this.tableCell112.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell112.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell112.Multiline = true;
            this.tableCell112.Name = "tableCell112";
            this.tableCell112.StylePriority.UseBorders = false;
            this.tableCell112.StylePriority.UseFont = false;
            this.tableCell112.Text = "Volume";
            this.tableCell112.Weight = 1.6102404479088539D;
            // 
            // tableCell113
            // 
            this.tableCell113.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell113.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell113.Multiline = true;
            this.tableCell113.Name = "tableCell113";
            this.tableCell113.StylePriority.UseBorders = false;
            this.tableCell113.StylePriority.UseFont = false;
            this.tableCell113.StylePriority.UseTextAlignment = false;
            this.tableCell113.Text = ":";
            this.tableCell113.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell113.Weight = 0.19846099183831839D;
            // 
            // tableCell114
            // 
            this.tableCell114.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell114.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell114.Multiline = true;
            this.tableCell114.Name = "tableCell114";
            this.tableCell114.StylePriority.UseBorders = false;
            this.tableCell114.StylePriority.UseFont = false;
            this.tableCell114.Weight = 2.0176214416107667D;
            // 
            // tableCell116
            // 
            this.tableCell116.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell116.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell116.Multiline = true;
            this.tableCell116.Name = "tableCell116";
            this.tableCell116.StylePriority.UseBorders = false;
            this.tableCell116.StylePriority.UseFont = false;
            this.tableCell116.StylePriority.UseTextAlignment = false;
            this.tableCell116.Text = "Net Wt.";
            this.tableCell116.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell116.Weight = 0.99990940649670834D;
            // 
            // tableCell117
            // 
            this.tableCell117.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell117.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell117.Multiline = true;
            this.tableCell117.Name = "tableCell117";
            this.tableCell117.StylePriority.UseBorders = false;
            this.tableCell117.StylePriority.UseFont = false;
            this.tableCell117.StylePriority.UseTextAlignment = false;
            this.tableCell117.Text = ":";
            this.tableCell117.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell117.Weight = 0.63603497022202171D;
            // 
            // tableCell118
            // 
            this.tableCell118.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell118.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_netwt]")});
            this.tableCell118.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell118.Multiline = true;
            this.tableCell118.Name = "tableCell118";
            this.tableCell118.StylePriority.UseBorders = false;
            this.tableCell118.StylePriority.UseFont = false;
            this.tableCell118.Weight = 1.2720699404440434D;
            // 
            // tableCell119
            // 
            this.tableCell119.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell119.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell119.Multiline = true;
            this.tableCell119.Name = "tableCell119";
            this.tableCell119.StylePriority.UseBorders = false;
            this.tableCell119.StylePriority.UseFont = false;
            this.tableCell119.Text = "Loading port";
            this.tableCell119.Weight = 2.6723362290349435D;
            // 
            // tableCell120
            // 
            this.tableCell120.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell120.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell120.Multiline = true;
            this.tableCell120.Name = "tableCell120";
            this.tableCell120.StylePriority.UseBorders = false;
            this.tableCell120.StylePriority.UseFont = false;
            this.tableCell120.StylePriority.UseTextAlignment = false;
            this.tableCell120.Text = ":";
            this.tableCell120.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell120.Weight = 0.17490778490706702D;
            // 
            // tableCell121
            // 
            this.tableCell121.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell121.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[pol]")});
            this.tableCell121.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell121.Multiline = true;
            this.tableCell121.Name = "tableCell121";
            this.tableCell121.StylePriority.UseBorders = false;
            this.tableCell121.StylePriority.UseFont = false;
            this.tableCell121.Weight = 4.1534885474536D;
            // 
            // tableRow25
            // 
            this.tableRow25.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell122,
            this.tableCell123,
            this.tableCell124,
            this.tableCell130,
            this.tableCell131,
            this.tableCell133});
            this.tableRow25.Name = "tableRow25";
            this.tableRow25.Weight = 0.625D;
            // 
            // tableCell122
            // 
            this.tableCell122.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell122.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell122.Multiline = true;
            this.tableCell122.Name = "tableCell122";
            this.tableCell122.StylePriority.UseBorders = false;
            this.tableCell122.StylePriority.UseFont = false;
            this.tableCell122.Text = "Vessel/Voy";
            this.tableCell122.Weight = 1.6102404479088539D;
            // 
            // tableCell123
            // 
            this.tableCell123.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell123.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell123.Multiline = true;
            this.tableCell123.Name = "tableCell123";
            this.tableCell123.StylePriority.UseBorders = false;
            this.tableCell123.StylePriority.UseFont = false;
            this.tableCell123.StylePriority.UseTextAlignment = false;
            this.tableCell123.Text = ":";
            this.tableCell123.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell123.Weight = 0.19846099183831839D;
            // 
            // tableCell124
            // 
            this.tableCell124.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell124.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[vessel]")});
            this.tableCell124.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell124.Multiline = true;
            this.tableCell124.Name = "tableCell124";
            this.tableCell124.StylePriority.UseBorders = false;
            this.tableCell124.StylePriority.UseFont = false;
            this.tableCell124.Weight = 4.92563575877354D;
            // 
            // tableCell130
            // 
            this.tableCell130.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell130.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell130.Multiline = true;
            this.tableCell130.Name = "tableCell130";
            this.tableCell130.StylePriority.UseBorders = false;
            this.tableCell130.StylePriority.UseFont = false;
            this.tableCell130.Text = "Discharge Port";
            this.tableCell130.Weight = 2.6723362290349435D;
            // 
            // tableCell131
            // 
            this.tableCell131.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell131.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell131.Multiline = true;
            this.tableCell131.Name = "tableCell131";
            this.tableCell131.StylePriority.UseBorders = false;
            this.tableCell131.StylePriority.UseFont = false;
            this.tableCell131.StylePriority.UseTextAlignment = false;
            this.tableCell131.Text = ":";
            this.tableCell131.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell131.Weight = 0.17490778490706702D;
            // 
            // tableCell133
            // 
            this.tableCell133.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell133.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[pod]")});
            this.tableCell133.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell133.Multiline = true;
            this.tableCell133.Name = "tableCell133";
            this.tableCell133.StylePriority.UseBorders = false;
            this.tableCell133.StylePriority.UseFont = false;
            this.tableCell133.Weight = 4.1534885474536D;
            // 
            // tableRow29
            // 
            this.tableRow29.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell135,
            this.tableCell137,
            this.tableCell138,
            this.tableCell148,
            this.tableCell149,
            this.tableCell150});
            this.tableRow29.Name = "tableRow29";
            this.tableRow29.Weight = 0.625D;
            // 
            // tableCell135
            // 
            this.tableCell135.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell135.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell135.Multiline = true;
            this.tableCell135.Name = "tableCell135";
            this.tableCell135.StylePriority.UseBorders = false;
            this.tableCell135.StylePriority.UseFont = false;
            this.tableCell135.Text = "Shipping Line";
            this.tableCell135.Weight = 1.6102404479088539D;
            // 
            // tableCell137
            // 
            this.tableCell137.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell137.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell137.Multiline = true;
            this.tableCell137.Name = "tableCell137";
            this.tableCell137.StylePriority.UseBorders = false;
            this.tableCell137.StylePriority.UseFont = false;
            this.tableCell137.StylePriority.UseTextAlignment = false;
            this.tableCell137.Text = ":";
            this.tableCell137.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell137.Weight = 0.19846099183831839D;
            // 
            // tableCell138
            // 
            this.tableCell138.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell138.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[line]")});
            this.tableCell138.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell138.Multiline = true;
            this.tableCell138.Name = "tableCell138";
            this.tableCell138.StylePriority.UseBorders = false;
            this.tableCell138.StylePriority.UseFont = false;
            this.tableCell138.Weight = 4.92563575877354D;
            // 
            // tableCell148
            // 
            this.tableCell148.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell148.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell148.Multiline = true;
            this.tableCell148.Name = "tableCell148";
            this.tableCell148.StylePriority.UseBorders = false;
            this.tableCell148.StylePriority.UseFont = false;
            this.tableCell148.Text = "Place of Delivery";
            this.tableCell148.Weight = 2.6723362290349435D;
            // 
            // tableCell149
            // 
            this.tableCell149.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell149.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell149.Multiline = true;
            this.tableCell149.Name = "tableCell149";
            this.tableCell149.StylePriority.UseBorders = false;
            this.tableCell149.StylePriority.UseFont = false;
            this.tableCell149.StylePriority.UseTextAlignment = false;
            this.tableCell149.Text = ":";
            this.tableCell149.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell149.Weight = 0.17490778490706702D;
            // 
            // tableCell150
            // 
            this.tableCell150.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell150.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[place_of_delivery]")});
            this.tableCell150.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell150.Multiline = true;
            this.tableCell150.Name = "tableCell150";
            this.tableCell150.StylePriority.UseBorders = false;
            this.tableCell150.StylePriority.UseFont = false;
            this.tableCell150.Weight = 4.1534885474536D;
            // 
            // tableRow30
            // 
            this.tableRow30.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell151,
            this.tableCell152,
            this.tableCell153,
            this.xrTableCell8,
            this.tableCell157,
            this.tableCell158,
            this.tableCell159});
            this.tableRow30.Name = "tableRow30";
            this.tableRow30.Weight = 0.625D;
            // 
            // tableCell151
            // 
            this.tableCell151.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell151.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell151.Multiline = true;
            this.tableCell151.Name = "tableCell151";
            this.tableCell151.StylePriority.UseBorders = false;
            this.tableCell151.StylePriority.UseFont = false;
            this.tableCell151.Text = "No. of Containers";
            this.tableCell151.Weight = 1.9877866571875364D;
            // 
            // tableCell152
            // 
            this.tableCell152.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.tableCell152.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell152.Multiline = true;
            this.tableCell152.Name = "tableCell152";
            this.tableCell152.StylePriority.UseBorders = false;
            this.tableCell152.StylePriority.UseFont = false;
            this.tableCell152.StylePriority.UseTextAlignment = false;
            this.tableCell152.Text = ":";
            this.tableCell152.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell152.Weight = 0.21732685945856745D;
            // 
            // tableCell153
            // 
            this.tableCell153.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.tableCell153.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "Iif(IsNullOrEmpty([bill].[bill_20ft]),[bill].[bill_20ft]+\' X 20FT  \' ,\' \')")});
            this.tableCell153.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell153.Multiline = true;
            this.tableCell153.Name = "tableCell153";
            this.tableCell153.StylePriority.UseBorders = false;
            this.tableCell153.StylePriority.UseFont = false;
            this.tableCell153.Weight = 2.2646118409373042D;
            // 
            // tableCell157
            // 
            this.tableCell157.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell157.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell157.Multiline = true;
            this.tableCell157.Name = "tableCell157";
            this.tableCell157.StylePriority.UseBorders = false;
            this.tableCell157.StylePriority.UseFont = false;
            this.tableCell157.Text = "Destination";
            this.tableCell157.Weight = 2.6723362290349435D;
            // 
            // tableCell158
            // 
            this.tableCell158.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.tableCell158.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell158.Multiline = true;
            this.tableCell158.Name = "tableCell158";
            this.tableCell158.StylePriority.UseBorders = false;
            this.tableCell158.StylePriority.UseFont = false;
            this.tableCell158.StylePriority.UseTextAlignment = false;
            this.tableCell158.Text = ":";
            this.tableCell158.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell158.Weight = 0.174907784907067D;
            // 
            // tableCell159
            // 
            this.tableCell159.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.tableCell159.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[destination]")});
            this.tableCell159.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell159.Multiline = true;
            this.tableCell159.Name = "tableCell159";
            this.tableCell159.StylePriority.UseBorders = false;
            this.tableCell159.StylePriority.UseFont = false;
            this.tableCell159.Weight = 4.1534885474536D;
            // 
            // tableRow32
            // 
            this.tableRow32.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell125,
            this.tableCell129,
            this.tableCell126});
            this.tableRow32.Name = "tableRow32";
            this.tableRow32.Weight = 0.625D;
            // 
            // tableCell125
            // 
            this.tableCell125.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.tableCell125.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell125.Multiline = true;
            this.tableCell125.Name = "tableCell125";
            this.tableCell125.StylePriority.UseBorders = false;
            this.tableCell125.StylePriority.UseFont = false;
            this.tableCell125.Text = "Conatiners";
            this.tableCell125.Weight = 1.6102403452101708D;
            // 
            // tableCell129
            // 
            this.tableCell129.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell129.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell129.Multiline = true;
            this.tableCell129.Name = "tableCell129";
            this.tableCell129.StylePriority.UseBorders = false;
            this.tableCell129.StylePriority.UseFont = false;
            this.tableCell129.StylePriority.UseTextAlignment = false;
            this.tableCell129.Text = ":";
            this.tableCell129.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.tableCell129.Weight = 0.37754631197736555D;
            // 
            // tableCell126
            // 
            this.tableCell126.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell126.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_container_no]")});
            this.tableCell126.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell126.Multiline = true;
            this.tableCell126.Name = "tableCell126";
            this.tableCell126.StylePriority.UseBorders = false;
            this.tableCell126.StylePriority.UseFont = false;
            this.tableCell126.StylePriority.UseTextAlignment = false;
            this.tableCell126.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.tableCell126.Weight = 11.747283102728789D;
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1,
            this.table3,
            this.table8});
            this.GroupFooter2.HeightF = 85.32435F;
            this.GroupFooter2.KeepTogether = true;
            this.GroupFooter2.Level = 2;
            this.GroupFooter2.Name = "GroupFooter2";
            this.GroupFooter2.PrintAtBottom = true;
            // 
            // xrLine1
            // 
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 81.56087F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(804.9999F, 3.763451F);
            // 
            // table3
            // 
            this.table3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.table3.LocationFloat = new DevExpress.Utils.PointFloat(3.04181F, 1.767654F);
            this.table3.Name = "table3";
            this.table3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.table3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow9,
            this.tableRow23,
            this.tableRow15,
            this.xrTableRow2,
            this.tableRow10,
            this.tableRow35,
            this.tableRow14});
            this.table3.SizeF = new System.Drawing.SizeF(425.5691F, 74.59591F);
            this.table3.StylePriority.UseBorders = false;
            // 
            // tableRow9
            // 
            this.tableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell20});
            this.tableRow9.Name = "tableRow9";
            this.tableRow9.Weight = 1D;
            // 
            // tableCell20
            // 
            this.tableCell20.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell20.Multiline = true;
            this.tableCell20.Name = "tableCell20";
            this.tableCell20.StylePriority.UseFont = false;
            this.tableCell20.Text = "Bank Details";
            this.tableCell20.Weight = 3.543737330451143D;
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
            this.tableCell59.Weight = 1D;
            // 
            // tableCell76
            // 
            this.tableCell76.Multiline = true;
            this.tableCell76.Name = "tableCell76";
            this.tableCell76.Text = ":";
            this.tableCell76.Weight = 0.13541671752929685D;
            // 
            // tableCell77
            // 
            this.tableCell77.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[company_printname]")});
            this.tableCell77.Multiline = true;
            this.tableCell77.Name = "tableCell77";
            this.tableCell77.Weight = 2.4083206129218464D;
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
            this.tableCell143.Weight = 1D;
            // 
            // tableCell144
            // 
            this.tableCell144.Multiline = true;
            this.tableCell144.Name = "tableCell144";
            this.tableCell144.Text = ":";
            this.tableCell144.Weight = 0.13541671752929685D;
            // 
            // tableCell145
            // 
            this.tableCell145.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bankname]")});
            this.tableCell145.Multiline = true;
            this.tableCell145.Name = "tableCell145";
            this.tableCell145.Weight = 2.4083206129218464D;
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
            this.tableCell96.Weight = 1D;
            // 
            // tableCell99
            // 
            this.tableCell99.Multiline = true;
            this.tableCell99.Name = "tableCell99";
            this.tableCell99.Text = ":";
            this.tableCell99.Weight = 0.13541671752929685D;
            // 
            // tableCell107
            // 
            this.tableCell107.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bank_accountno]")});
            this.tableCell107.Multiline = true;
            this.tableCell107.Name = "tableCell107";
            this.tableCell107.Weight = 2.4083206129218464D;
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
            this.tableCell195.Weight = 1D;
            // 
            // tableCell196
            // 
            this.tableCell196.Multiline = true;
            this.tableCell196.Name = "tableCell196";
            this.tableCell196.Text = ":\t";
            this.tableCell196.Weight = 0.13541671752929685D;
            // 
            // tableCell197
            // 
            this.tableCell197.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bank_address]")});
            this.tableCell197.Multiline = true;
            this.tableCell197.Name = "tableCell197";
            this.tableCell197.Weight = 2.4083206129218464D;
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
            this.tableCell127.Weight = 1D;
            // 
            // tableCell128
            // 
            this.tableCell128.Multiline = true;
            this.tableCell128.Name = "tableCell128";
            this.tableCell128.Text = ":";
            this.tableCell128.Weight = 0.13541671752929685D;
            // 
            // tableCell136
            // 
            this.tableCell136.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bank_ifsc]")});
            this.tableCell136.Multiline = true;
            this.tableCell136.Name = "tableCell136";
            this.tableCell136.Weight = 2.4083206129218464D;
            // 
            // table8
            // 
            this.table8.Font = new DevExpress.Drawing.DXFont("Segoe UI", 8F);
            this.table8.LocationFloat = new DevExpress.Utils.PointFloat(574.468F, 0F);
            this.table8.Name = "table8";
            this.table8.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 1, 0, 100F);
            this.table8.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow18,
            this.tableRow28,
            this.tableRow31,
            this.tableRow21,
            this.tableRow26,
            this.tableRow27});
            this.table8.SizeF = new System.Drawing.SizeF(229.4904F, 81.56089F);
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
            this.tableCell49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.tableCell62.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[bill_detail_sgstper]")});
            this.tableCell62.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell62.Multiline = true;
            this.tableCell62.Name = "tableCell62";
            this.tableCell62.StylePriority.UseBorders = false;
            this.tableCell62.StylePriority.UseFont = false;
            this.tableCell62.TextFormatString = "{0}  %";
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
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[bill_detail_sgst]")});
            this.tableCell68.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell68.Name = "tableCell68";
            this.tableCell68.StylePriority.UseBorders = false;
            this.tableCell68.StylePriority.UseFont = false;
            this.tableCell68.StylePriority.UseTextAlignment = false;
            this.tableCell68.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell68.TextFormatString = "{0:#.00}";
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
            this.tableCell160.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[bill_detail_cgstper]")});
            this.tableCell160.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell160.Multiline = true;
            this.tableCell160.Name = "tableCell160";
            this.tableCell160.StylePriority.UseBorders = false;
            this.tableCell160.StylePriority.UseFont = false;
            this.tableCell160.TextFormatString = "{0}  %";
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
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[bill_detail_cgst]")});
            this.tableCell53.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell53.Name = "tableCell53";
            this.tableCell53.StylePriority.UseBorders = false;
            this.tableCell53.StylePriority.UseFont = false;
            this.tableCell53.StylePriority.UseTextAlignment = false;
            this.tableCell53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell53.TextFormatString = "{0:#.00}";
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
            this.tableCell171.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[bill_detail_igstper]")});
            this.tableCell171.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell171.Multiline = true;
            this.tableCell171.Name = "tableCell171";
            this.tableCell171.StylePriority.UseBorders = false;
            this.tableCell171.StylePriority.UseFont = false;
            this.tableCell171.TextFormatString = "{0}  %";
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
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[billDetails].[bill_detail_igst]")});
            this.tableCell44.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell44.Multiline = true;
            this.tableCell44.Name = "tableCell44";
            this.tableCell44.StylePriority.UseBorders = false;
            this.tableCell44.StylePriority.UseFont = false;
            this.tableCell44.StylePriority.UseTextAlignment = false;
            this.tableCell44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell44.TextFormatString = "{0:#.00}";
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
            this.tableCell66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
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
            this.pictureBox2.LocationFloat = new DevExpress.Utils.PointFloat(6.103516E-05F, 0F);
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
            this.tableCell71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell71.TextFormatString = "{0:#.00}";
            this.tableCell71.Weight = 1.2882821530365203D;
            // 
            // GroupFooter3
            // 
            this.GroupFooter3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table4});
            this.GroupFooter3.HeightF = 27.73162F;
            this.GroupFooter3.KeepTogether = true;
            this.GroupFooter3.Level = 3;
            this.GroupFooter3.Name = "GroupFooter3";
            this.GroupFooter3.PrintAtBottom = true;
            // 
            // table4
            // 
            this.table4.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Underline);
            this.table4.LocationFloat = new DevExpress.Utils.PointFloat(1.041657F, 1.999966F);
            this.table4.Name = "table4";
            this.table4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow42,
            this.tableRow33});
            this.table4.SizeF = new System.Drawing.SizeF(803.9584F, 25.73164F);
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
            this.tableCell81.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.tableCell81.StylePriority.UseBorders = false;
            this.tableCell81.StylePriority.UseFont = false;
            this.tableCell81.StylePriority.UsePadding = false;
            this.tableCell81.StylePriority.UseTextAlignment = false;
            this.tableCell81.Text = "Amount In Word ( INR ) :";
            this.tableCell81.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.tableCell81.Weight = 0.21554433450050439D;
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
            this.tableCell188.Weight = 0.78445566549949564D;
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
            this.tableCell183.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.tableCell183.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell183.Multiline = true;
            this.tableCell183.Name = "tableCell183";
            this.tableCell183.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.tableCell183.StylePriority.UseBorders = false;
            this.tableCell183.StylePriority.UseFont = false;
            this.tableCell183.StylePriority.UsePadding = false;
            this.tableCell183.StylePriority.UseTextAlignment = false;
            this.tableCell183.Text = "Remarks :";
            this.tableCell183.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.tableCell183.Weight = 0.0936096516866072D;
            // 
            // tableCell186
            // 
            this.tableCell186.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.tableCell186.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bill_detail_remarks]")});
            this.tableCell186.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.tableCell186.Multiline = true;
            this.tableCell186.Name = "tableCell186";
            this.tableCell186.StylePriority.UseBorders = false;
            this.tableCell186.StylePriority.UseFont = false;
            this.tableCell186.StylePriority.UseTextAlignment = false;
            this.tableCell186.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.tableCell186.Weight = 0.90639034831339271D;
            // 
            // GroupFooter4
            // 
            this.GroupFooter4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table19,
            this.table15,
            this.label6,
            this.label3,
            this.label4});
            this.GroupFooter4.HeightF = 119F;
            this.GroupFooter4.KeepTogether = true;
            this.GroupFooter4.Level = 4;
            this.GroupFooter4.Name = "GroupFooter4";
            this.GroupFooter4.PrintAtBottom = true;
            // 
            // table19
            // 
            this.table19.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom;
            this.table19.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.table19.Font = new DevExpress.Drawing.DXFont("Tahoma", 9F);
            this.table19.LocationFloat = new DevExpress.Utils.PointFloat(478.6667F, 100.5504F);
            this.table19.Name = "table19";
            this.table19.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow44});
            this.table19.SizeF = new System.Drawing.SizeF(311.3333F, 18.44958F);
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
            this.table15.LocationFloat = new DevExpress.Utils.PointFloat(488.7084F, 4.083315F);
            this.table15.Name = "table15";
            this.table15.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow89});
            this.table15.SizeF = new System.Drawing.SizeF(313.2916F, 13.50201F);
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
            this.tableCell176.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.tableCell176.Name = "tableCell176";
            this.tableCell176.StylePriority.UseBorders = false;
            this.tableCell176.StylePriority.UseFont = false;
            this.tableCell176.StylePriority.UseTextAlignment = false;
            this.tableCell176.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell176.TextFormatString = "For   {0}";
            this.tableCell176.Weight = 1D;
            // 
            // label6
            // 
            this.label6.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.label6.LocationFloat = new DevExpress.Utils.PointFloat(6.749996F, 101.8935F);
            this.label6.Multiline = true;
            this.label6.Name = "label6";
            this.label6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label6.SizeF = new System.Drawing.SizeF(146.875F, 17.10441F);
            this.label6.StylePriority.UseFont = false;
            this.label6.Text = "E & O.E";
            // 
            // label3
            // 
            this.label3.Font = new DevExpress.Drawing.DXFont("Tahoma", 7F);
            this.label3.LocationFloat = new DevExpress.Utils.PointFloat(6.75F, 10.00001F);
            this.label3.Multiline = true;
            this.label3.Name = "label3";
            this.label3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label3.SizeF = new System.Drawing.SizeF(478.6667F, 91.89352F);
            this.label3.StylePriority.UseFont = false;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label4
            // 
            this.label4.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.label4.LocationFloat = new DevExpress.Utils.PointFloat(6.749996F, 0F);
            this.label4.Multiline = true;
            this.label4.Name = "label4";
            this.label4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label4.SizeF = new System.Drawing.SizeF(146.875F, 9.375F);
            this.label4.StylePriority.UseFont = false;
            this.label4.Text = "Terms & Conditions : ";
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
            jsonSchemaNode62.Nodes.Add(jsonSchemaNode63);
            jsonSchemaNode62.Nodes.Add(jsonSchemaNode64);
            jsonSchemaNode62.Nodes.Add(jsonSchemaNode65);
            jsonSchemaNode62.Nodes.Add(jsonSchemaNode66);
            jsonSchemaNode62.Nodes.Add(jsonSchemaNode67);
            jsonSchemaNode62.Nodes.Add(jsonSchemaNode68);
            jsonSchemaNode62.Nodes.Add(jsonSchemaNode69);
            jsonSchemaNode62.Nodes.Add(jsonSchemaNode70);
            jsonSchemaNode62.Nodes.Add(jsonSchemaNode71);
            jsonSchemaNode62.Nodes.Add(jsonSchemaNode72);
            jsonSchemaNode62.Nodes.Add(jsonSchemaNode73);
            jsonSchemaNode62.Nodes.Add(jsonSchemaNode74);
            jsonSchemaNode62.Nodes.Add(jsonSchemaNode75);
            jsonSchemaNode62.Nodes.Add(jsonSchemaNode76);
            jsonSchemaNode62.Nodes.Add(jsonSchemaNode77);
            jsonSchemaNode1.Nodes.Add(jsonSchemaNode2);
            jsonSchemaNode1.Nodes.Add(jsonSchemaNode62);
            this.jsonDataSource1.Schema = jsonSchemaNode1;
            // 
            // xrCrossBandBox1
            // 
            this.xrCrossBandBox1.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandBox1.BorderWidth = 1F;
            this.xrCrossBandBox1.EndBand = this.GroupFooter4;
            this.xrCrossBandBox1.EndPointFloat = new DevExpress.Utils.PointFloat(0F, 118.9979F);
            this.xrCrossBandBox1.Name = "xrCrossBandBox1";
            this.xrCrossBandBox1.StartBand = this.ReportHeader;
            this.xrCrossBandBox1.StartPointFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrCrossBandBox1.WidthF = 805F;
            // 
            // xrCrossBandLine1
            // 
            this.xrCrossBandLine1.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine1.EndBand = this.GroupFooter7;
            this.xrCrossBandLine1.EndPointFloat = new DevExpress.Utils.PointFloat(197.5279F, 0F);
            this.xrCrossBandLine1.Name = "xrCrossBandLine1";
            this.xrCrossBandLine1.StartBand = this.GroupHeader1;
            this.xrCrossBandLine1.StartPointFloat = new DevExpress.Utils.PointFloat(197.5279F, 0F);
            this.xrCrossBandLine1.WidthF = 1F;
            // 
            // xrCrossBandLine2
            // 
            this.xrCrossBandLine2.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine2.EndBand = this.GroupFooter7;
            this.xrCrossBandLine2.EndPointFloat = new DevExpress.Utils.PointFloat(24.55F, 0F);
            this.xrCrossBandLine2.Name = "xrCrossBandLine2";
            this.xrCrossBandLine2.StartBand = this.GroupHeader1;
            this.xrCrossBandLine2.StartPointFloat = new DevExpress.Utils.PointFloat(24.55F, 0F);
            this.xrCrossBandLine2.WidthF = 1.12841F;
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.GroupFooter6,
            this.GroupFooter7});
            this.DetailReport.DataMember = "billDetails";
            this.DetailReport.DataSource = this.jsonDataSource1;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table6});
            this.Detail1.HeightF = 18.49059F;
            this.Detail1.Name = "Detail1";
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F, DevExpress.Drawing.DXFontStyle.Bold);
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.Text = "Branch";
            this.xrTableCell5.Weight = 1D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Text = ":";
            this.xrTableCell6.Weight = 0.13541671752929685D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[bill].[bank_branch]")});
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Weight = 2.4083206129218464D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrTableCell8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "Iif(([bill].[bill_40ft])>0,[bill].[bill_40ft]+\' X 40FT \' ,\' \') ")});
            this.xrTableCell8.Font = new DevExpress.Drawing.DXFont("Tahoma", 8F);
            this.xrTableCell8.Multiline = true;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseBorders = false;
            this.xrTableCell8.StylePriority.UseFont = false;
            this.xrTableCell8.Text = "xrTableCell8";
            this.xrTableCell8.Weight = 2.2646118409373042D;
            // 
            // GroupFooter6
            // 
            this.GroupFooter6.HeightF = 2F;
            this.GroupFooter6.Name = "GroupFooter6";
            // 
            // GroupFooter7
            // 
            this.GroupFooter7.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table7});
            this.GroupFooter7.HeightF = 15.26131F;
            this.GroupFooter7.KeepTogether = true;
            this.GroupFooter7.Level = 1;
            this.GroupFooter7.Name = "GroupFooter7";
            this.GroupFooter7.PrintAtBottom = true;
            // 
            // xrCrossBandLine12
            // 
            this.xrCrossBandLine12.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine12.EndBand = this.GroupFooter7;
            this.xrCrossBandLine12.EndPointFloat = new DevExpress.Utils.PointFloat(600.6027F, 15.26131F);
            this.xrCrossBandLine12.Name = "xrCrossBandLine12";
            this.xrCrossBandLine12.StartBand = this.GroupHeader1;
            this.xrCrossBandLine12.StartPointFloat = new DevExpress.Utils.PointFloat(600.6027F, 16.76F);
            this.xrCrossBandLine12.WidthF = 1.000032F;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.HeightF = 0F;
            this.GroupFooter1.Level = 1;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.Visible = false;
            // 
            // GroupFooter5
            // 
            this.GroupFooter5.HeightF = 2F;
            this.GroupFooter5.Name = "GroupFooter5";
            this.GroupFooter5.Visible = false;
            // 
            // xrCrossBandLine13
            // 
            this.xrCrossBandLine13.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine13.EndBand = this.GroupFooter7;
            this.xrCrossBandLine13.EndPointFloat = new DevExpress.Utils.PointFloat(689.1739F, 15.2613F);
            this.xrCrossBandLine13.Name = "xrCrossBandLine13";
            this.xrCrossBandLine13.StartBand = this.GroupHeader1;
            this.xrCrossBandLine13.StartPointFloat = new DevExpress.Utils.PointFloat(689.1739F, 16.76F);
            this.xrCrossBandLine13.WidthF = 1.000016F;
            // 
            // xrCrossBandLine4
            // 
            this.xrCrossBandLine4.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine4.EndBand = this.GroupFooter7;
            this.xrCrossBandLine4.EndPointFloat = new DevExpress.Utils.PointFloat(277.2373F, 0F);
            this.xrCrossBandLine4.Name = "xrCrossBandLine4";
            this.xrCrossBandLine4.StartBand = this.GroupHeader1;
            this.xrCrossBandLine4.StartPointFloat = new DevExpress.Utils.PointFloat(277.2373F, 0F);
            this.xrCrossBandLine4.WidthF = 1F;
            // 
            // xrCrossBandLine5
            // 
            this.xrCrossBandLine5.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine5.EndBand = this.GroupFooter7;
            this.xrCrossBandLine5.EndPointFloat = new DevExpress.Utils.PointFloat(315.3491F, 0F);
            this.xrCrossBandLine5.Name = "xrCrossBandLine5";
            this.xrCrossBandLine5.StartBand = this.GroupHeader1;
            this.xrCrossBandLine5.StartPointFloat = new DevExpress.Utils.PointFloat(315.3491F, 0F);
            this.xrCrossBandLine5.WidthF = 1F;
            // 
            // xrCrossBandLine6
            // 
            this.xrCrossBandLine6.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine6.EndBand = this.GroupFooter7;
            this.xrCrossBandLine6.EndPointFloat = new DevExpress.Utils.PointFloat(349.1721F, 0F);
            this.xrCrossBandLine6.Name = "xrCrossBandLine6";
            this.xrCrossBandLine6.StartBand = this.GroupHeader1;
            this.xrCrossBandLine6.StartPointFloat = new DevExpress.Utils.PointFloat(349.1721F, 0F);
            this.xrCrossBandLine6.WidthF = 1F;
            // 
            // xrCrossBandLine7
            // 
            this.xrCrossBandLine7.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine7.EndBand = this.GroupFooter7;
            this.xrCrossBandLine7.EndPointFloat = new DevExpress.Utils.PointFloat(411.8827F, 0F);
            this.xrCrossBandLine7.Name = "xrCrossBandLine7";
            this.xrCrossBandLine7.StartBand = this.GroupHeader1;
            this.xrCrossBandLine7.StartPointFloat = new DevExpress.Utils.PointFloat(411.8827F, 0F);
            this.xrCrossBandLine7.WidthF = 1F;
            // 
            // xrCrossBandLine8
            // 
            this.xrCrossBandLine8.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine8.EndBand = this.GroupFooter7;
            this.xrCrossBandLine8.EndPointFloat = new DevExpress.Utils.PointFloat(465.8765F, 0F);
            this.xrCrossBandLine8.Name = "xrCrossBandLine8";
            this.xrCrossBandLine8.StartBand = this.GroupHeader1;
            this.xrCrossBandLine8.StartPointFloat = new DevExpress.Utils.PointFloat(465.8765F, 0F);
            this.xrCrossBandLine8.WidthF = 1F;
            // 
            // xrCrossBandLine9
            // 
            this.xrCrossBandLine9.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine9.EndBand = this.GroupFooter7;
            this.xrCrossBandLine9.EndPointFloat = new DevExpress.Utils.PointFloat(572.598F, 0F);
            this.xrCrossBandLine9.Name = "xrCrossBandLine9";
            this.xrCrossBandLine9.StartBand = this.GroupHeader1;
            this.xrCrossBandLine9.StartPointFloat = new DevExpress.Utils.PointFloat(572.598F, 0F);
            this.xrCrossBandLine9.WidthF = 1F;
            // 
            // xrCrossBandLine10
            // 
            this.xrCrossBandLine10.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine10.EndBand = this.GroupFooter7;
            this.xrCrossBandLine10.EndPointFloat = new DevExpress.Utils.PointFloat(660.1811F, 0F);
            this.xrCrossBandLine10.Name = "xrCrossBandLine10";
            this.xrCrossBandLine10.StartBand = this.GroupHeader1;
            this.xrCrossBandLine10.StartPointFloat = new DevExpress.Utils.PointFloat(660.1811F, 0F);
            this.xrCrossBandLine10.WidthF = 1F;
            // 
            // xrCrossBandLine11
            // 
            this.xrCrossBandLine11.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine11.EndBand = this.GroupFooter7;
            this.xrCrossBandLine11.EndPointFloat = new DevExpress.Utils.PointFloat(741.1226F, 0F);
            this.xrCrossBandLine11.Name = "xrCrossBandLine11";
            this.xrCrossBandLine11.StartBand = this.GroupHeader1;
            this.xrCrossBandLine11.StartPointFloat = new DevExpress.Utils.PointFloat(741.1226F, 0F);
            this.xrCrossBandLine11.WidthF = 1.041565F;
            // 
            // xrCrossBandLine3
            // 
            this.xrCrossBandLine3.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrCrossBandLine3.EndBand = this.GroupFooter7;
            this.xrCrossBandLine3.EndPointFloat = new DevExpress.Utils.PointFloat(244.9299F, 0F);
            this.xrCrossBandLine3.Name = "xrCrossBandLine3";
            this.xrCrossBandLine3.StartBand = this.GroupHeader1;
            this.xrCrossBandLine3.StartPointFloat = new DevExpress.Utils.PointFloat(244.9299F, 0F);
            this.xrCrossBandLine3.WidthF = 1.104767F;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox1.ImageSource"));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1.430153F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(153.625F, 116.1376F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // BillReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.GroupHeader1,
            this.GroupFooter1,
            this.ReportHeader,
            this.GroupHeader2,
            this.GroupFooter2,
            this.GroupFooter3,
            this.GroupFooter4,
            this.GroupFooter5,
            this.DetailReport});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.jsonDataSource1});
            this.CrossBandControls.AddRange(new DevExpress.XtraReports.UI.XRCrossBandControl[] {
            this.xrCrossBandLine3,
            this.xrCrossBandLine11,
            this.xrCrossBandLine10,
            this.xrCrossBandLine9,
            this.xrCrossBandLine8,
            this.xrCrossBandLine7,
            this.xrCrossBandLine6,
            this.xrCrossBandLine5,
            this.xrCrossBandLine4,
            this.xrCrossBandLine13,
            this.xrCrossBandLine12,
            this.xrCrossBandLine2,
            this.xrCrossBandLine1,
            this.xrCrossBandBox1});
            this.DataSource = this.jsonDataSource1;
            this.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F);
            this.Margins = new DevExpress.Drawing.DXMargins(17F, 18F, 23.33333F, 35.97514F);
            this.Version = "24.1";
            ((System.ComponentModel.ISupportInitialize)(this.table5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
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
        private DevExpress.XtraReports.UI.XRTableCell tableCell168;
        private DevExpress.XtraReports.UI.XRTableCell tableCell172;
        private DevExpress.XtraReports.UI.XRTableCell tableCell173;
        private DevExpress.XtraReports.UI.XRTableCell tableCell174;
        private DevExpress.XtraReports.UI.XRTableCell tableCell175;
        private DevExpress.XtraReports.UI.XRTableCell tableCell177;
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
        private DevExpress.XtraReports.UI.XRTableCell tableCell87;
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
        private DevExpress.XtraReports.UI.XRTableCell tableCell162;
        private DevExpress.XtraReports.UI.XRTableCell tableCell163;
        private DevExpress.XtraReports.UI.XRTableCell tableCell166;
        private DevExpress.XtraReports.UI.XRTableCell tableCell164;
        private DevExpress.XtraReports.UI.XRTableCell tableCell167;
        private DevExpress.XtraReports.UI.XRTableCell tableCell165;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRTable table1;
        private DevExpress.XtraReports.UI.XRTableRow tableRow1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell1;
        private DevExpress.XtraReports.UI.XRTableRow tableRow2;
        private DevExpress.XtraReports.UI.XRTableCell tableCell4;
        private DevExpress.XtraReports.UI.XRTableRow tableRow7;
        private DevExpress.XtraReports.UI.XRTableCell tableCell3;
        private DevExpress.XtraReports.UI.XRTableRow tableRow11;
        private DevExpress.XtraReports.UI.XRTableCell tableCell132;
        private DevExpress.XtraReports.UI.XRTableRow tableRow19;
        private DevExpress.XtraReports.UI.XRTableCell tableCell15;
        private DevExpress.XtraReports.UI.XRTableRow tableRow13;
        private DevExpress.XtraReports.UI.XRTableCell tableCell134;
        private DevExpress.XtraReports.UI.XRTableCell tableCell190;
        private DevExpress.XtraReports.UI.XRTableRow tableRow34;
        private DevExpress.XtraReports.UI.XRTableCell tableCell189;
        private DevExpress.XtraReports.UI.XRTableCell tableCell194;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader2;
        private DevExpress.XtraReports.UI.XRTable table18;
        private DevExpress.XtraReports.UI.XRTableRow tableRow83;
        private DevExpress.XtraReports.UI.XRTableCell tableCell37;
        private DevExpress.XtraReports.UI.XRTableCell tableCell184;
        private DevExpress.XtraReports.UI.XRTableCell tableCell185;
        private DevExpress.XtraReports.UI.XRTableCell tableCell187;
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
        private DevExpress.XtraReports.UI.XRTableRow tableRow3;
        private DevExpress.XtraReports.UI.XRTableCell tableCell2;
        private DevExpress.XtraReports.UI.XRTableCell tableCell6;
        private DevExpress.XtraReports.UI.XRTableCell tableCell7;
        private DevExpress.XtraReports.UI.XRTableCell tableCell8;
        private DevExpress.XtraReports.UI.XRTableCell tableCell28;
        private DevExpress.XtraReports.UI.XRTableCell tableCell21;
        private DevExpress.XtraReports.UI.XRTableRow tableRow8;
        private DevExpress.XtraReports.UI.XRTableCell tableCell9;
        private DevExpress.XtraReports.UI.XRTableCell tableCell11;
        private DevExpress.XtraReports.UI.XRTableCell tableCell12;
        private DevExpress.XtraReports.UI.XRTableCell tableCell14;
        private DevExpress.XtraReports.UI.XRTableCell tableCell17;
        private DevExpress.XtraReports.UI.XRTableCell tableCell16;
        private DevExpress.XtraReports.UI.XRTableCell tableCell13;
        private DevExpress.XtraReports.UI.XRTableCell tableCell33;
        private DevExpress.XtraReports.UI.XRTableCell tableCell29;
        private DevExpress.XtraReports.UI.XRTableRow tableRow6;
        private DevExpress.XtraReports.UI.XRTableCell tableCell46;
        private DevExpress.XtraReports.UI.XRTableCell tableCell50;
        private DevExpress.XtraReports.UI.XRTableCell tableCell54;
        private DevExpress.XtraReports.UI.XRTableCell tableCell55;
        private DevExpress.XtraReports.UI.XRTableCell tableCell60;
        private DevExpress.XtraReports.UI.XRTableCell tableCell61;
        private DevExpress.XtraReports.UI.XRTableCell tableCell63;
        private DevExpress.XtraReports.UI.XRTableCell tableCell69;
        private DevExpress.XtraReports.UI.XRTableCell tableCell72;
        private DevExpress.XtraReports.UI.XRTableRow tableRow16;
        private DevExpress.XtraReports.UI.XRTableCell tableCell73;
        private DevExpress.XtraReports.UI.XRTableCell tableCell75;
        private DevExpress.XtraReports.UI.XRTableCell tableCell78;
        private DevExpress.XtraReports.UI.XRTableCell tableCell79;
        private DevExpress.XtraReports.UI.XRTableCell tableCell80;
        private DevExpress.XtraReports.UI.XRTableCell tableCell82;
        private DevExpress.XtraReports.UI.XRTableCell tableCell86;
        private DevExpress.XtraReports.UI.XRTableCell tableCell91;
        private DevExpress.XtraReports.UI.XRTableCell tableCell93;
        private DevExpress.XtraReports.UI.XRTableRow tableRow22;
        private DevExpress.XtraReports.UI.XRTableCell tableCell102;
        private DevExpress.XtraReports.UI.XRTableCell tableCell103;
        private DevExpress.XtraReports.UI.XRTableCell tableCell104;
        private DevExpress.XtraReports.UI.XRTableCell tableCell105;
        private DevExpress.XtraReports.UI.XRTableCell tableCell106;
        private DevExpress.XtraReports.UI.XRTableCell tableCell108;
        private DevExpress.XtraReports.UI.XRTableCell tableCell109;
        private DevExpress.XtraReports.UI.XRTableCell tableCell110;
        private DevExpress.XtraReports.UI.XRTableCell tableCell111;
        private DevExpress.XtraReports.UI.XRTableRow tableRow24;
        private DevExpress.XtraReports.UI.XRTableCell tableCell112;
        private DevExpress.XtraReports.UI.XRTableCell tableCell113;
        private DevExpress.XtraReports.UI.XRTableCell tableCell114;
        private DevExpress.XtraReports.UI.XRTableCell tableCell116;
        private DevExpress.XtraReports.UI.XRTableCell tableCell117;
        private DevExpress.XtraReports.UI.XRTableCell tableCell118;
        private DevExpress.XtraReports.UI.XRTableCell tableCell119;
        private DevExpress.XtraReports.UI.XRTableCell tableCell120;
        private DevExpress.XtraReports.UI.XRTableCell tableCell121;
        private DevExpress.XtraReports.UI.XRTableRow tableRow25;
        private DevExpress.XtraReports.UI.XRTableCell tableCell122;
        private DevExpress.XtraReports.UI.XRTableCell tableCell123;
        private DevExpress.XtraReports.UI.XRTableCell tableCell124;
        private DevExpress.XtraReports.UI.XRTableCell tableCell130;
        private DevExpress.XtraReports.UI.XRTableCell tableCell131;
        private DevExpress.XtraReports.UI.XRTableCell tableCell133;
        private DevExpress.XtraReports.UI.XRTableRow tableRow29;
        private DevExpress.XtraReports.UI.XRTableCell tableCell135;
        private DevExpress.XtraReports.UI.XRTableCell tableCell137;
        private DevExpress.XtraReports.UI.XRTableCell tableCell138;
        private DevExpress.XtraReports.UI.XRTableCell tableCell148;
        private DevExpress.XtraReports.UI.XRTableCell tableCell149;
        private DevExpress.XtraReports.UI.XRTableCell tableCell150;
        private DevExpress.XtraReports.UI.XRTableRow tableRow30;
        private DevExpress.XtraReports.UI.XRTableCell tableCell151;
        private DevExpress.XtraReports.UI.XRTableCell tableCell152;
        private DevExpress.XtraReports.UI.XRTableCell tableCell153;
        private DevExpress.XtraReports.UI.XRTableCell tableCell157;
        private DevExpress.XtraReports.UI.XRTableCell tableCell158;
        private DevExpress.XtraReports.UI.XRTableCell tableCell159;
        private DevExpress.XtraReports.UI.XRTableRow tableRow32;
        private DevExpress.XtraReports.UI.XRTableCell tableCell125;
        private DevExpress.XtraReports.UI.XRTableCell tableCell129;
        private DevExpress.XtraReports.UI.XRTableCell tableCell126;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter2;
        private DevExpress.XtraReports.UI.XRTable table3;
        private DevExpress.XtraReports.UI.XRTableRow tableRow9;
        private DevExpress.XtraReports.UI.XRTableCell tableCell20;
        private DevExpress.XtraReports.UI.XRTableRow tableRow23;
        private DevExpress.XtraReports.UI.XRTableCell tableCell59;
        private DevExpress.XtraReports.UI.XRTableCell tableCell76;
        private DevExpress.XtraReports.UI.XRTableCell tableCell77;
        private DevExpress.XtraReports.UI.XRTableRow tableRow15;
        private DevExpress.XtraReports.UI.XRTableCell tableCell143;
        private DevExpress.XtraReports.UI.XRTableCell tableCell144;
        private DevExpress.XtraReports.UI.XRTableCell tableCell145;
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
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter3;
        private DevExpress.XtraReports.UI.XRTable table4;
        private DevExpress.XtraReports.UI.XRTableRow tableRow42;
        private DevExpress.XtraReports.UI.XRTableCell tableCell81;
        private DevExpress.XtraReports.UI.XRTableCell tableCell188;
        private DevExpress.XtraReports.UI.XRTableRow tableRow33;
        private DevExpress.XtraReports.UI.XRTableCell tableCell183;
        private DevExpress.XtraReports.UI.XRTableCell tableCell186;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter4;
        private DevExpress.XtraReports.UI.XRTable table19;
        private DevExpress.XtraReports.UI.XRTableRow tableRow44;
        private DevExpress.XtraReports.UI.XRTableCell tableCell90;
        private DevExpress.XtraReports.UI.XRTable table15;
        private DevExpress.XtraReports.UI.XRTableRow tableRow89;
        private DevExpress.XtraReports.UI.XRTableCell tableCell176;
        private DevExpress.XtraReports.UI.XRLabel label6;
        private DevExpress.XtraReports.UI.XRLabel label3;
        private DevExpress.XtraReports.UI.XRLabel label4;
        private DevExpress.DataAccess.Json.JsonDataSource jsonDataSource1;
        private DevExpress.XtraReports.UI.XRTable table10;
        private DevExpress.XtraReports.UI.XRTableRow tableRow4;
        private DevExpress.XtraReports.UI.XRTableCell tableCell5;
        private DevExpress.XtraReports.UI.XRTableCell tableCell10;
        private DevExpress.XtraReports.UI.XRTableCell tableCell19;
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
        private DevExpress.XtraReports.UI.XRPictureBox pictureBox2;
        private DevExpress.XtraReports.UI.XRTableCell tableCell70;
        private DevExpress.XtraReports.UI.XRTableCell tableCell71;
        private DevExpress.XtraReports.UI.XRTable table7;
        private DevExpress.XtraReports.UI.XRTableRow tableRow17;
        private DevExpress.XtraReports.UI.XRTableCell tableCell32;
        private DevExpress.XtraReports.UI.XRTableCell tableCell30;
        private DevExpress.XtraReports.UI.XRTableCell tableCell178;
        private DevExpress.XtraReports.UI.XRTableCell tableCell179;
        private DevExpress.XtraReports.UI.XRTableCell tableCell181;
        private DevExpress.XtraReports.UI.XRTableCell tableCell180;
        private DevExpress.XtraReports.UI.XRTableCell tableCell182;
        private DevExpress.XtraReports.UI.XRTableCell tableCell42;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRPictureBox pictureBox3;
        private DevExpress.XtraReports.UI.XRCrossBandBox xrCrossBandBox1;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine1;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine2;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
        private DevExpress.XtraReports.UI.DetailBand Detail1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter6;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter7;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine12;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter5;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine13;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine4;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine5;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine6;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine7;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine8;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine9;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine10;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine11;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine3;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
    }
}
