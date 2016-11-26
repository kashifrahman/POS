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
    public partial class frmSalesReport : Form
    {
        public frmSalesReport()
        {
            InitializeComponent();
        }
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        string sParticularValue = "";
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            GlobalClass.gsSalesReportType = "REPORTBYITEMNAME";
            sParticularValue = "ALL";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                GlobalClass.gsReportType = "SALES REPORT";
                string sFromDate, sToDate;
                sFromDate =Convert.ToDateTime(dtPckrFrmDate.Value).ToString("yyyy-MM-dd");
                sToDate =Convert.ToDateTime(dtPckrToDate.Value).ToString("yyyy-MM-dd");
                if (GlobalClass.gsSalesReportType == null)
                {
                    MessageBox.Show("Please select a report option to generate", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (GlobalClass.gsSalesReportType == "REPORTBYBILLNO")
                {
                    if (txtInvoiceNo.Text != "" && txtToInvoiceNo.Text == "")
                    {
                        MessageBox.Show("Please enter To Invoice Value", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        txtToInvoiceNo.Focus();
                        return;
                    }
                    else if (txtInvoiceNo.Text == "" && txtToInvoiceNo.Text != "")
                    {
                        MessageBox.Show("Please enter From Invoice Value", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        txtInvoiceNo.Focus();
                        return;
                    }
                    else if (txtInvoiceNo.Text != "" && txtToInvoiceNo.Text != "")
                    {
                        GlobalClass.gsSalesReportType = "REPORTBYINVRANGE";
                    }
                }
                //else
                //{
                //    GlobalClass.gsSalesReportType = "REPORTBYBILLNO";
                //}
                GenerateSalesReport(GlobalClass.gsReportType, GlobalClass.gsSalesReportType, sFromDate, sToDate);

            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        public void GenerateSalesReport(string sReportType,string sSalesRptType, string sFromDate, string sToDate, string sOptionalValue = "Default")
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //dgDisplaySalesReport.DataSource = null;
                cmd = new SqlCommand();
                ds = new DataSet();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_Reports";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ReportName", SqlDbType.VarChar, GlobalClass.gsReportType.Length).Value = GlobalClass.gsReportType.Trim();
                cmd.Parameters.Add("@ReportFilterOption", SqlDbType.VarChar, sSalesRptType.Length).Value = sSalesRptType.Trim();
                cmd.Parameters.Add("@ParticularValue", SqlDbType.VarChar, sParticularValue.Length).Value = sParticularValue.Trim();
                cmd.Parameters.Add("@FromDate", SqlDbType.VarChar, sFromDate.Length).Value = sFromDate.Trim();
                cmd.Parameters.Add("@ToDate", SqlDbType.VarChar, sToDate.Length).Value = sToDate.Trim();
                //Added by Kashif on 16-May-2015 for Invoice from and To Reports
                cmd.Parameters.Add("@secondval", SqlDbType.VarChar, txtToInvoiceNo.Text.Length).Value = txtToInvoiceNo.Text;
                //till here
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                //dgDisplaySalesReport.DataSource = ds.Tables["Result"];
                //ds = new DataSet();
                //lblTotalRecords.Text = dgDisplaySalesReport.Rows.Count.ToString();
                if (ds.Tables["Result"].Rows.Count == 0)
                {
                    MessageBox.Show("No Records found for report", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    CrystalReportViewerSales.ReportSource = null;
                    Cursor.Current = Cursors.Default;
                    return;
                }
                switch (sSalesRptType)
                {
                    case "REPORTBYBILLNO":
                        SalesPurchase.Reports.ReportByInvoiceNo rptReportByInvoiceNo = new SalesPurchase.Reports.ReportByInvoiceNo();
                        rptReportByInvoiceNo.SetDataSource(ds.Tables["Result"]);
                        rptReportByInvoiceNo.SetParameterValue("fromdate",sFromDate);
                        rptReportByInvoiceNo.SetParameterValue("todate",sToDate);
                        CrystalReportViewerSales.ReportSource = rptReportByInvoiceNo;
                        break;
                    case "REPORTBYINVRANGE":
                        SalesPurchase.Reports.ReportByInvoiceNo rptReportByInvoiceNoRange = new SalesPurchase.Reports.ReportByInvoiceNo();
                        rptReportByInvoiceNoRange.SetDataSource(ds.Tables["Result"]);
                        rptReportByInvoiceNoRange.SetParameterValue("fromdate", sFromDate);
                        rptReportByInvoiceNoRange.SetParameterValue("todate", sToDate);
                        CrystalReportViewerSales.ReportSource = rptReportByInvoiceNoRange;
                        break;                    
                    case "REPORTBYITEMNAME":
                        SalesPurchase.Reports.ReportByItemName rptReportByItemName = new SalesPurchase.Reports.ReportByItemName();
                        rptReportByItemName.SetDataSource(ds.Tables["Result"]);
                        rptReportByItemName.SetParameterValue("fromdate", sFromDate);
                        rptReportByItemName.SetParameterValue("todate", sToDate);
                        CrystalReportViewerSales.ReportSource = rptReportByItemName;
                        break;
                    case "REPORTBYSALESMAN":
                        SalesPurchase.Reports.SalesManWiseReport rptSalesManWiseReport = new SalesPurchase.Reports.SalesManWiseReport();
                        rptSalesManWiseReport.SetDataSource(ds.Tables["Result"]);
                        rptSalesManWiseReport.SetParameterValue("fromdate", sFromDate);
                        rptSalesManWiseReport.SetParameterValue("todate", sToDate);
                        CrystalReportViewerSales.ReportSource = rptSalesManWiseReport;
                        break;
                    case "DEADSTOCKREP":
                        SalesPurchase.Reports.DeadStockReport rptDeadStock = new SalesPurchase.Reports.DeadStockReport();
                        rptDeadStock.SetDataSource(ds.Tables["Result"]);
                        rptDeadStock.SetParameterValue("fromdate", sFromDate);
                        rptDeadStock.SetParameterValue("todate",sToDate);
                        CrystalReportViewerSales.ReportSource = rptDeadStock;
                        break;
                    case "REPORTBYITEMGROUP":
                        SalesPurchase.Reports.rptByItemGroupName rptReportByGrpName = new SalesPurchase.Reports.rptByItemGroupName();
                        rptReportByGrpName.SetDataSource(ds.Tables["Result"]);
                        CrystalReportViewerSales.ReportSource = rptReportByGrpName;
                        break;
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in GenerateSalesReport:" + ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Reports", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void rbtnBillDate_Click(object sender, EventArgs e)
        {
            GlobalClass.gsSalesReportType = "REPORTBYBILLDATE";

        }

        private void rbtnBillNo_Click(object sender, EventArgs e)
        {
            GlobalClass.gsSalesReportType = "REPORTBYBILLNO";
        }

        private void rbtnItemCode_Click(object sender, EventArgs e)
        {
            GlobalClass.gsSalesReportType = "REPORTBYBITEMCODE";
        }

        private void rbtnItemGroup_Click(object sender, EventArgs e)
        {
            GlobalClass.gsSalesReportType = "REPORTBYITEMGROUP";
        }

        private void rbtnSalesMan_Click(object sender, EventArgs e)
        {
            GlobalClass.gsSalesReportType = "REPORTBYSALESMAN";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            GlobalClass.gsSalesReportType = "REPORTBYBILLDATE";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            GlobalClass.gsSalesReportType = "REPORTBYBILLNO";
            sParticularValue = "ALL";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            GlobalClass.gsSalesReportType = "REPORTBYSALESMAN";
            sParticularValue = "ALL";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            GlobalClass.gsSalesReportType = "REPORTBYITEMGROUP";
            sParticularValue = "ALL";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void frmSalesReport_Load(object sender, EventArgs e)
        {
            try
            {
                string sFlag;
                sFlag = "FETCHEMPNAME";
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_FetchMenuDetails";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                ds = new DataSet();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                for (int i = 0; i < ds.Tables["Result"].Rows.Count; i++)
                {
                    cmbSalesBy.Items.Add(ds.Tables["Result"].Rows[i]["Employeename"].ToString().Trim());
                    //cmbDeliveredBy.Items.Add(ds.Tables["Result"].Rows[i]["Employeename"].ToString().Trim());
                }

                ds = new DataSet();
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.CommandText = "SP_FetchItemCategory";
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "ItemCategory");
                for (int i = 0; i < ds.Tables["Itemcategory"].Rows.Count; i++)
                {
                    if (ds.Tables["Itemcategory"].Rows[i]["Type"].ToString().ToUpper() == "MAINGROUP")
                        cmbItemGroup.Items.Add(ds.Tables["itemcategory"].Rows[i]["itemcategory"].ToString());
                    //if (ds.Tables["Itemcategory"].Rows[i]["Type"].ToString().ToUpper() == "ITEMTYPE")
                    //    cmbItemType.Items.Add(ds.Tables["Itemcategory"].Rows[i]["itemcategory"].ToString());
                    //if (ds.Tables["Itemcategory"].Rows[i]["Type"].ToString().ToUpper() == "MAINGROUP")
                    //    cmbGroup.Items.Add(ds.Tables["Itemcategory"].Rows[i]["itemcategory"].ToString());
                }
                GlobalClass.WriteLog("Before Fetching Menu details in Invoice");
                sFlag = "LOAD";
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_FetchMenuDetails";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                ds = new DataSet();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                for (int i = 0; i < ds.Tables["Result"].Rows.Count; i++)
                    cmbItemCode.Items.Add(ds.Tables["Result"].Rows[i]["ItemName"].ToString());


                cmbItemGroup.SelectedIndex = -1;
                cmbSalesBy.SelectedIndex = -1;
                cmbItemCode.SelectedIndex = -1;
                cmbItemCode.Items.Add("ALL");

            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in frmSalesReport_Load:"+ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void rbtnCustomer_CheckedChanged(object sender, EventArgs e)
        {
            GlobalClass.gsSalesReportType = "DEADSTOCKREP";
        }
        public void ClearForm()
        {
            //dgDisplaySalesReport.DataSource = null;
            CrystalReportViewerSales.ReportSource = null;
            txtInvoiceNo.Text = "";
            txtToInvoiceNo.Text = "";
            cmbItemCode.SelectedIndex = -1;
            cmbItemGroup.SelectedIndex = -1;
            cmbSalesBy.SelectedIndex = -1;
        }

        private void cmbItemCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            sParticularValue = cmbItemCode.Text;
        }

        private void cmbSalesBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            sParticularValue = cmbSalesBy.Text;
            GlobalClass.gsSalesReportType = "REPORTBYSALESMAN";
        }

        private void cmbItemGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalClass.gsSalesReportType = "REPORTBYITEMGROUP";
            sParticularValue = cmbItemGroup.Text;
        }

        private void cmbDeliveredBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalClass.gsSalesReportType = "REPORTDELIVEREDBY";
            //sParticularValue = cmbDeliveredBy.Text;
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            sParticularValue = "ALL";
            GlobalClass.gsSalesReportType = "REPORTDELIVEREDBY";
        }

        private void txtInvoiceNo_Leave(object sender, EventArgs e)
        {
            if (txtInvoiceNo.Text.Trim() != "")
                sParticularValue = txtInvoiceNo.Text;
            else
                sParticularValue = "ALL";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDocumentSalesReport.Print();
        }

        private void printDocumentSalesReport_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {

                //PaintEventArgs myPaintArgs = new PaintEventArgs(e.Graphics, new Rectangle(new Point(0, 0), this.Size));
                //this.InvokePaint(dgDisplaySalesReport, myPaintArgs);
                //printPreviewDialogSalesReprt.Document = printDocumentSalesReport;
                //printPreviewDialogSalesReprt.ShowDialog();


                //Bitmap bm = new Bitmap(this.dgDisplaySalesReport.Width, this.dgDisplaySalesReport.Height);
                //dgDisplaySalesReport.DrawToBitmap(bm, new Rectangle(0, 0, this.dgDisplaySalesReport.Width, this.dgDisplaySalesReport.Height));
                //e.Graphics.DrawImage(bm,10, 10);
                //printPreviewDialogSalesReprt.Document = printDocumentSalesReport;
                //printPreviewDialogSalesReprt.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
