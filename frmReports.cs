using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SalesPurchase
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //mskdtxtToDate = dtPckrTo.Value.ToString("DD/MM/YYYY");
            string str;
            str = dtPckrTo.Value.ToString("yyyy-MM-dd");
            mskdtxtToDate.Text = str;
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            cmbReportType.Items.Add("KOT Cancelled Report");
            cmbReportType.Items.Add("Total KOT Report");
            cmbReportType.Items.Add("Invoice Modified Report");
            cmbReportType.Items.Add("Service Time Report");
            cmbReportType.Items.Add("Daily Sales Summary Report");
            //cmbReportType.Items.Add("Daily Purchase Summary Report");
            cmbReportType.Items.Add("Invoice Modified Items Added Report");
            cmbReportType.Items.Add("Invoice Modified Items Deleted Report");
            cmbReportType.Items.Add("Cancelled Item Report");
            cmbReportType.Items.Add("KOT Reprint Report");
            cmbReportType.Items.Add("Invoice Pending Report");
            cmbReportType.Items.Add("Discounted Invoice Report");

            mskdtxtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            mskdtxtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strReportType="", sFromDt, sTodt;
            try
                
            {
                //GlobalClass.gsReportType = "Sales Report";
                ////if (cmbReportType.Text=="Sales Report")
                ////{
                //    GlobalClass.gsReportType = "Sales Report";
                //    frmSalesReport fr = new frmSalesReport();
                //    fr.Show();
                ////}
                if (cmbReportType.Text == "")
                {
                    MessageBox.Show("Please select Report Type", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                
                else if (cmbReportType.Text == "KOT Cancelled Report")
                {
                    strReportType = "KOTDELETEDREPORT";
                }
                else if (cmbReportType.Text == "Total KOT Report")
                {
                    strReportType = "TOTALKOT";
                }
                else if (cmbReportType.Text == "Invoice Modified Report")
                {
                    strReportType = "INVOICEMOD";
                }
                else if (cmbReportType.Text == "Service Time Report")
                {
                    strReportType = "SERVICEREP";
                }
                else if (cmbReportType.Text == "Daily Sales Summary Report")
                {
                    strReportType = "SALESSUMMRPT";
                }
                else if (cmbReportType.Text == "Invoice Modified Items Added Report")
                {
                    strReportType = "INVOICEMODADDED";
                }
                else if (cmbReportType.Text == "Invoice Modified Items Deleted Report")
                {
                    strReportType = "INVOICEMODDEL";
                }
                else if (cmbReportType.Text == "Cancelled Item Report")
                {
                    strReportType = "INVCITEMDELSHORTREP";
                }
                else if (cmbReportType.Text == "KOT Reprint Report")
                {
                    strReportType = "KOTREPRINTREP";
                }
                else if(cmbReportType.Text == "Invoice Pending Report")
                {
                    strReportType="INVOICETOBEGENRATEDREP";
                }
                else if (cmbReportType.Text == "Discounted Invoice Report")
                {
                    strReportType = "DISCOUNTEDINVREP";
                }
                
                sFromDt=Convert.ToDateTime(mskdtxtFromDate.Text).ToString("yyyy-MM-dd");
                sTodt =Convert.ToDateTime( mskdtxtToDate.Text).ToString("yyyy-MM-dd");
                GenerateReport(strReportType,sFromDt,sTodt);
                
            }
            catch (Exception ex)
            {
            }
        }
        public void GenerateReport(string sReportType, string sFromDate, string sToDate)
        {
            try
            {
                GlobalClass.Busy();
                cmd = new SqlCommand();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_Reports";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ReportName", SqlDbType.VarChar, sReportType.Length).Value = sReportType;
                cmd.Parameters.Add("@ReportFilterOption", SqlDbType.VarChar, 20).Value = "";
                cmd.Parameters.Add("@ParticularValue", SqlDbType.VarChar, 20).Value = "";
                cmd.Parameters.Add("@FromDate", SqlDbType.VarChar, sFromDate.Length).Value = sFromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.VarChar, sToDate.Length).Value = sToDate;
                ds = new DataSet();
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                if (ds.Tables["Result"].Rows.Count == 0)
                {
                    MessageBox.Show("No Records found for Report", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    rptViewerReports.ReportSource = null;
                    GlobalClass.Free();
                    return;
                }
                //dgReports.DataSource = ds.Tables["Result"];

                switch (sReportType)
                {
                    case "KOTDELETEDREPORT":
                        SalesPurchase.Reports.KOTCancelledReport rptKOTCancelledReport = new SalesPurchase.Reports.KOTCancelledReport();
                        rptKOTCancelledReport.SetDataSource(ds.Tables["Result"]);
                        rptKOTCancelledReport.SetParameterValue("fromdate", sFromDate);
                        rptKOTCancelledReport.SetParameterValue("todate", sToDate);
                        rptViewerReports.ReportSource = rptKOTCancelledReport;
                        break;
                    case "TOTALKOT":
                        SalesPurchase.Reports.TotalKOTReport rptTotalKOTReport = new SalesPurchase.Reports.TotalKOTReport();
                        rptTotalKOTReport.SetDataSource(ds.Tables["Result"]);
                        rptTotalKOTReport.SetParameterValue("fromdate", sFromDate);
                        rptTotalKOTReport.SetParameterValue("todate", sToDate);                        
                        rptViewerReports.ReportSource = rptTotalKOTReport;
                        break;
                    case "SERVICEREP":
                        SalesPurchase.Reports.ServiceTimeReport rptServiceTimeReport = new SalesPurchase.Reports.ServiceTimeReport();
                        rptServiceTimeReport.SetDataSource(ds.Tables["Result"]);
                        rptServiceTimeReport.SetParameterValue("fromdate", sFromDate);
                        rptServiceTimeReport.SetParameterValue("todate", sToDate);                                                
                        rptViewerReports.ReportSource = rptServiceTimeReport;
                        break;
                    case "SALESSUMMRPT":
                        SalesPurchase.Reports.DailySalesSummaryrpt rptDailySalesSummaryRpt = new SalesPurchase.Reports.DailySalesSummaryrpt();
                        rptDailySalesSummaryRpt.SetDataSource(ds.Tables["Result"]);
                        rptDailySalesSummaryRpt.SetParameterValue("fromdate",sFromDate);
                        rptDailySalesSummaryRpt.SetParameterValue("todate",sToDate);                                                
                        rptViewerReports.ReportSource = rptDailySalesSummaryRpt;
                        break;
                    case "INVOICEMODADDED":
                        SalesPurchase.Reports.InvoiceModifiedItemAddedReport rptInvoiceModifiedItemAddedRpt = new SalesPurchase.Reports.InvoiceModifiedItemAddedReport();
                        rptInvoiceModifiedItemAddedRpt.SetDataSource(ds.Tables["Result"]);
                        rptInvoiceModifiedItemAddedRpt.SetParameterValue("fromdate", sFromDate );
                        rptInvoiceModifiedItemAddedRpt.SetParameterValue("todate", sToDate);                                                
                        rptViewerReports.ReportSource = rptInvoiceModifiedItemAddedRpt;
                        break;
                    case "INVOICEMODDEL":
                        SalesPurchase.Reports.InvoiceModifiedItemDeletedReport rptInvoiceModifiedItemDeletedRpt = new SalesPurchase.Reports.InvoiceModifiedItemDeletedReport();
                        rptInvoiceModifiedItemDeletedRpt.SetDataSource(ds.Tables["Result"]);
                        rptInvoiceModifiedItemDeletedRpt.SetParameterValue("fromdate", sFromDate);
                        rptInvoiceModifiedItemDeletedRpt.SetParameterValue("todate", sToDate);                                                
                        rptViewerReports.ReportSource = rptInvoiceModifiedItemDeletedRpt;
                        break;
                    case "INVOICEMOD":
                        SalesPurchase.Reports.InvoiceModifiedReport rptInvoiceModified = new SalesPurchase.Reports.InvoiceModifiedReport();
                        rptInvoiceModified.SetDataSource(ds.Tables["Result"]);
                        rptInvoiceModified.SetParameterValue("fromdate",sFromDate);
                        rptInvoiceModified.SetParameterValue("todate", sToDate);                                                
                        rptViewerReports.ReportSource = rptInvoiceModified;
                        break;
                    case "INVCITEMDELSHORTREP":
                        SalesPurchase.Reports.CancelledItemReport rptCancelledItem = new SalesPurchase.Reports.CancelledItemReport();
                        rptCancelledItem.SetDataSource(ds.Tables["Result"]);
                        rptCancelledItem.SetParameterValue("fromdate", sFromDate);
                        rptCancelledItem.SetParameterValue("todate",sToDate);                                                                        
                        rptViewerReports.ReportSource = rptCancelledItem;
                        break;
                    case "KOTREPRINTREP":
                        SalesPurchase.Reports.KOTReprintReport rptKOTReprint = new SalesPurchase.Reports.KOTReprintReport();
                        rptKOTReprint.SetDataSource(ds.Tables["Result"]);
                        rptKOTReprint.SetParameterValue("fromdate", sFromDate);
                        rptKOTReprint.SetParameterValue("todate", sToDate);
                        rptViewerReports.ReportSource = rptKOTReprint;
                        break;
                    case "INVOICETOBEGENRATEDREP":
                        SalesPurchase.Reports.InvoicePendingReport rptInvoicePending = new SalesPurchase.Reports.InvoicePendingReport();
                        rptInvoicePending.SetDataSource(ds.Tables["Result"]);
                        rptInvoicePending.SetParameterValue("fromdate", sFromDate);
                        rptInvoicePending.SetParameterValue("todate", sToDate);
                        rptViewerReports.ReportSource = rptInvoicePending;
                        break;
                    case"DISCOUNTEDINVREP":
                        SalesPurchase.Reports.DiscountedItemInvoiceReport rptDiscountedInvoice = new SalesPurchase.Reports.DiscountedItemInvoiceReport();
                        rptDiscountedInvoice.SetDataSource(ds.Tables["Result"]);
                        rptDiscountedInvoice.SetParameterValue("fromdate", sFromDate);
                        rptDiscountedInvoice.SetParameterValue("todate", sToDate);
                        rptViewerReports.ReportSource = rptDiscountedInvoice;
                        break;

                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in GenerateReport:" + ex.Message.ToString());
            }
            finally
            {
                GlobalClass.Free();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void dtPckrFrom_ValueChanged(object sender, EventArgs e)
        {
            string str;
            str=dtPckrFrom.Value.ToString("yyyy-MM-dd");
            mskdtxtFromDate.Text = str;
        }

        private void mskdtxtFromDate_Leave(object sender, EventArgs e)
        {
            if (mskdtxtFromDate.MaskFull == false)
            {
                MessageBox.Show("Please Enter From Date in yyyy-MM-dd format", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            mskdtxtFromDate.ValidatingType = typeof(System.DateTime);
        }

        private void mskdtxtFromDate_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                MessageBox.Show("The From Date is NOT in Valid date format", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void mskdtxtToDate_Leave(object sender, EventArgs e)
        {
            if (mskdtxtToDate.MaskFull == false)
            {
                MessageBox.Show("Please Enter To Date in yyyy-MM-dd format", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            mskdtxtToDate.ValidatingType = typeof(System.DateTime);
        }

        private void mskdtxtToDate_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                MessageBox.Show("The TO Date is NOT in Valid Date format", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

        }

        private void mskdtxtFromDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rptViewerReports.ReportSource = null;
            cmbReportType.SelectedIndex = -1;
        }
    }
}
