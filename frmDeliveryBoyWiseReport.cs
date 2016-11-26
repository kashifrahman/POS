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
    public partial class frmDeliveryBoyWiseReport : Form
    {
        public frmDeliveryBoyWiseReport()
        {
            InitializeComponent();
        }
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        string sParticularValue = "";
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            GlobalClass.gsSalesReportType = "REPORTBYITEMNAME";
            //sParticularValue = "ALL";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDeliveredBy.Text == "")
                {
                    sParticularValue = "ALL";
                }
                else
                {
                    sParticularValue = cmbDeliveredBy.Text;
                }
                
                GlobalClass.gsSalesReportType = "REPORTDELIVEREDBY";
                GlobalClass.gsReportType = "SALES REPORT";
                string sFromDate, sToDate;
                sFromDate =Convert.ToDateTime(dtPckrFrmDate.Value).ToString("yyyy-MM-dd");
                sToDate =Convert.ToDateTime(dtPckrToDate.Value).ToString("yyyy-MM-dd");
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
                SalesPurchase.Reports.rptDeliveryBoyWise rptDeliveryBoywise = new SalesPurchase.Reports.rptDeliveryBoyWise();
                string strfromDate = "", strToDate = "";

                //dgDisplaySalesReport.DataSource = null;
                GlobalClass.Busy();
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
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");


                if (ds.Tables["Result"].Rows.Count == 0)
                {
                    MessageBox.Show("No Records found for the searched criteria", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ds = new DataSet();
                    GlobalClass.Free();
                    return;
                }
                else
                {

                    //dgDisplaySalesReport.DataSource = ds.Tables["Result"];
                    //ds = new DataSet();
                    //lblTotalRecords.Text = dgDisplaySalesReport.Rows.Count.ToString();
                }
                rptDeliveryBoywise.SetDataSource(ds.Tables["Result"]);

                rptDeliveryBoywise.SetParameterValue("fromDate", Convert.ToDateTime(dtPckrFrmDate.Value).ToString("dd/MM/yyyy"));
                rptDeliveryBoywise.SetParameterValue("ToDate", Convert.ToDateTime(dtPckrToDate.Value).ToString("dd/MM/yyyy"));
                crystalReportViewer.ReportSource = rptDeliveryBoywise;

            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in GenerateSalesReport:" + ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Reports", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                GlobalClass.Free();
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
                    //cmbSalesBy.Items.Add(ds.Tables["Result"].Rows[i]["Employeename"].ToString().Trim());
                    cmbDeliveredBy.Items.Add(ds.Tables["Result"].Rows[i]["Employeename"].ToString().Trim());
                }

                ds = new DataSet();
                //GlobalClass.cmd = new SqlCommand();
                //GlobalClass.cmd.CommandText = "SP_FetchItemCategory";
                //GlobalClass.cmd.Connection = GlobalClass.gCon;
                //GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                //ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "ItemCategory");
                //for (int i = 0; i < ds.Tables["Itemcategory"].Rows.Count; i++)
                //{
                //    if (ds.Tables["Itemcategory"].Rows[i]["Type"].ToString().ToUpper() == "MAINGROUP")
                //        //cmbItemGroup.Items.Add(ds.Tables["itemcategory"].Rows[i]["itemcategory"].ToString());
                //    //if (ds.Tables["Itemcategory"].Rows[i]["Type"].ToString().ToUpper() == "ITEMTYPE")
                //    //    cmbItemType.Items.Add(ds.Tables["Itemcategory"].Rows[i]["itemcategory"].ToString());
                //    //if (ds.Tables["Itemcategory"].Rows[i]["Type"].ToString().ToUpper() == "MAINGROUP")
                //    //    cmbGroup.Items.Add(ds.Tables["Itemcategory"].Rows[i]["itemcategory"].ToString());
                //}
                GlobalClass.WriteLog("Before Fetching Menu details in Invoice");
                sFlag = "LOAD";
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_FetchMenuDetails";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                ds = new DataSet();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                //for (int i = 0; i < ds.Tables["Result"].Rows.Count; i++)
                //    cmbItemCode.Items.Add(ds.Tables["Result"].Rows[i]["ItemName"].ToString());


                //cmbItemGroup.SelectedIndex = -1;
                //cmbSalesBy.SelectedIndex = -1;
                //cmbItemCode.SelectedIndex = -1;
                //cmbItemCode.Items.Add("ALL");

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
            crystalReportViewer.ReportSource = null;
            cmbDeliveredBy.SelectedIndex = -1;
        }

        private void cmbItemCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sParticularValue = cmbItemCode.Text;
        }

        private void cmbSalesBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sParticularValue = cmbSalesBy.Text;
            GlobalClass.gsSalesReportType = "REPORTBYSALESMAN";
        }

        private void cmbItemGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalClass.gsSalesReportType = "REPORTBYITEMGROUP";
            //sParticularValue = cmbItemGroup.Text;
        }

        private void cmbDeliveredBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalClass.gsSalesReportType = "REPORTDELIVEREDBY";
            sParticularValue = cmbDeliveredBy.Text;
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            sParticularValue = "ALL";
            GlobalClass.gsSalesReportType = "REPORTDELIVEREDBY";
        }

        private void txtInvoiceNo_Leave(object sender, EventArgs e)
        {
            //if (txtInvoiceNo.Text.Trim() != "")
            //    sParticularValue = txtInvoiceNo.Text;
            //else
            //    sParticularValue = "ALL";
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

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                       
                if (cmbDeliveredBy.Text == "")
                {
                    sParticularValue = "ALL";
                }
                else
                {
                    sParticularValue = cmbDeliveredBy.Text;
                }
                
                GlobalClass.gsSalesReportType = "REPORTDELIVEREDBY";
                GlobalClass.gsReportType = "SALES REPORT";
                string sFromDate, sToDate;
                sFromDate =Convert.ToDateTime(dtPckrFrmDate.Value).ToString("yyyy-MM-dd");
                sToDate =Convert.ToDateTime(dtPckrToDate.Value).ToString("yyyy-MM-dd");
                GenerateSalesReport(GlobalClass.gsReportType, GlobalClass.gsSalesReportType, sFromDate, sToDate);                
            }
            catch (Exception ex)
            {

            }
        }

        private void dgDisplaySalesReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
