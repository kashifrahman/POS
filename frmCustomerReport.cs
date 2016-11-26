using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace SalesPurchase
{
    public partial class frmCustomerReport : Form
    {
        public frmCustomerReport()
        {
            InitializeComponent();
        }
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        string sCustomerReportType,sParticularValue;
        string sFromDate, sTodate, sReportName;
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmCustomerReport_Load(object sender, EventArgs e)
        {
            try
            {
                cmd = null;
                string sFlag = "";
                sFlag = "FETCHCUSTOMER";
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_FetchMenuDetails";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                ds = new DataSet();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                for (int i = 0; i < ds.Tables["Result"].Rows.Count; i++)
                {
                    cmbCustName.Items.Add(ds.Tables["Result"].Rows[i]["CustomerName"].ToString());
                    cmbCustomerName.Items.Add(ds.Tables["Result"].Rows[i]["CustomerName"].ToString());

                }

                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_ManageEventMaster";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10).Value = "SEARCH";
                ds = new DataSet();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                for (int i = 0; i < ds.Tables["Result"].Rows.Count; i++)
                    cmbEvent.Items.Add(ds.Tables["Result"].Rows[i]["EventName"].ToString());

                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_ManageEventMaster";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 20).Value = "LOADRELIGION";
                ds = new DataSet();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                for (int i = 0; i < ds.Tables["Result"].Rows.Count; i++)
                    cmbReligion.Items.Add(ds.Tables["Result"].Rows[i]["ReligionName"].ToString());


            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in frmCustomerReport_Load:" + ex.Message.ToString());
            }
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                //string sFromDate, sTodate,sReportName;
                sFromDate=Convert.ToDateTime(dtpckrFrom.Value).ToString("yyyy-MM-dd");
                sTodate = Convert.ToDateTime(dtpckrToDate.Value).ToString("yyyy-MM-dd");
                sReportName="CUSTOMERREP";
                GenerateCustomerReport(sReportName,sCustomerReportType,sFromDate,sTodate);
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in btnSearchCustomer_Click:" + ex.Message.ToString());
            }
        }
        public void GenerateCustomerReport(string sRepName, string sCustomerRepType, string sFromDt, string sToDt)
        {
            try
            {
                int iQty=0;
                Decimal dAmount = 0;
                dgDisplayCustomerRep.DataSource = null;
                cmd = new SqlCommand();
                ds = new DataSet();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_Reports";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ReportName", SqlDbType.VarChar,sRepName.Length).Value = sRepName.Trim();
                cmd.Parameters.Add("@ReportFilterOption", SqlDbType.VarChar, sCustomerRepType.Length).Value = sCustomerRepType.Trim();
                cmd.Parameters.Add("@ParticularValue", SqlDbType.VarChar, sParticularValue.Length).Value = sParticularValue.Trim();
                cmd.Parameters.Add("@FromDate", SqlDbType.VarChar, sFromDt.Length).Value = sFromDt.Trim();
                cmd.Parameters.Add("@ToDate", SqlDbType.VarChar, sToDt.Length).Value = sToDt.Trim();
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                dgDisplayCustomerRep.DataSource = ds.Tables["Result"];
                //ds = new DataSet();
                lbltotalrecord.Text = dgDisplayCustomerRep.Rows.Count.ToString();

                //Added by Kashif on 16-May-2015 to add summary for sale type report
                if (sCustomerRepType == "REPBYCUSTOMER")
                {
                    foreach (DataGridViewRow drow in dgDisplayCustomerRep.Rows)
                    {

                        iQty = iQty + Convert.ToInt16(drow.Cells["Invoice Qty"].Value);
                        dAmount = dAmount + Convert.ToDecimal(drow.Cells["Total Amount"].Value);
                    }
                    txtTotalCount.Text = iQty.ToString();
                    txtTotalAmount.Text = dAmount.ToString();
                    //DataGridViewRow newdrow = new DataGridViewRow();
                    //newdrow.CreateCells(dgDisplayCustomerRep, "", "Total", iQty.ToString(), dAmount.ToString());
                    //dgDisplayCustomerRep.Rows.Add(3, newdrow);

                    //ds.Tables["Result"].Rows[

                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in GenerateCustomerReport:" + ex.Message.ToString());
            }
        }

        private void rbtnByCustomerVisited_CheckedChanged(object sender, EventArgs e)
        {
            sCustomerReportType = "REPBYCUSTOMER";
            sParticularValue = "ALL";
            GlobalClass.gsCustReportName = "SalesType_Report.xls";
        }

        private void rbtnCustomerNotVisisted_CheckedChanged(object sender, EventArgs e)
        {
            sCustomerReportType = "REPBYCUSTNOTVISITED";
            sParticularValue = "ALL";
            GlobalClass.gsCustReportName = "Customer_Not_Visited_Report.xls";
        }

        private void rbtnByEvent_CheckedChanged(object sender, EventArgs e)
        {
            sCustomerReportType = "REPBYEVENT";
            sParticularValue = "ALL";
            GlobalClass.gsCustReportName = "Customer_Event_Report.xls";
        }

        private void rbtnReligion_CheckedChanged(object sender, EventArgs e)
        {
            sCustomerReportType = "REPBYRELIGION";
            sParticularValue = "ALL";
            GlobalClass.gsCustReportName = "Customer_Religion_Report.xls";
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCustomerName.Text=="")
            {
                sParticularValue = "ALL";
            }
            else
            {
            sParticularValue = cmbCustomerName.Text;
            }
        }

        private void cmbCustName_SelectedIndexChanged(object sender, EventArgs e)
        {
            sParticularValue = cmbCustName.Text;
        }

        private void cmbEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEvent.Text == "")
            {
                sParticularValue = "ALL";
            }
            else
            {
                sParticularValue = cmbEvent.Text;
            }
        }

        private void cmbReligion_SelectedIndexChanged(object sender, EventArgs e)
        {
            sParticularValue = cmbReligion.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSearchCustomer frm = new frmSearchCustomer();
            frm.Show();
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgDisplayCustomerRep.Rows.Count == 0)
                {
                    MessageBox.Show("Please Generate Report or No Data to Export", "Customer Report", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            
                string sDate,sReppath,sFileName,sFilePath;
                sFileName="SPLog.txt";
                sDate = DateTime.Now.ToString("dd-MM-yyyy");
                sReppath = GlobalClass.gsReportPath + "\\" + sDate;
                //sFilePath=sLogpath+"\\"+sFileName;
                if (Directory.Exists(sReppath))
                {

                }
                else
                {
                    Directory.CreateDirectory(sReppath);
                }
                ExportCustomerReport(GlobalClass.gsCustReportName, sReppath);
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in btnExportReport_Click:" + ex.Message.ToString());
            }
        }
        public void ExportCustomerReport(string sRepName,string sReportPath)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application App = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = App.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                Microsoft.Office.Interop.Excel.Range HeaderRange;
                App.Visible = false;
                worksheet =(Microsoft.Office.Interop.Excel.Worksheet) workbook.Sheets["Sheet1"];
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;
                worksheet.Name = "Sheet1";
                worksheet.Cells[2, 4] = sRepName;
                for (int i = 1; i < dgDisplayCustomerRep.Columns.Count+1; i++)
                {
                    worksheet.Cells[4, i+1] = dgDisplayCustomerRep.Columns[i-1].HeaderText;
                }
                //HeaderRange=worksheet.get_Range("B4",
                for (int i = 0; i < dgDisplayCustomerRep.Rows.Count-1; i++)
                {
                    for (int j = 0; j < dgDisplayCustomerRep.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 5, j + 2] = dgDisplayCustomerRep.Rows[i].Cells[j].Value.ToString();
                    }
                }
                //workbook.SaveAs(sRepName + "\\" + sRepName, Microsoft.Office.Interop.Excel.XlFileFormat.xlHtml, Type.Missing, Type.Missing,Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                //workbook.SaveAs(sRepName + "\\" + sRepName, Microsoft.Office.Interop.Excel.XlFileFormat.xlHtml, Type.Missing);
                workbook.SaveCopyAs(sReportPath + "\\" + sRepName);
                workbook.Close(true, Type.Missing, Type.Missing);
                App.Quit();
                


                //xlWorkBook.SaveAs("csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                //xlWorkBook.Close(true, misValue, misValue);
                //xlApp.Quit();

                releaseObject(worksheet);
                releaseObject(workbook);
                releaseObject(App);
                MessageBox.Show("Report:" + sRepName + " successfully Exported at path:" + sReportPath, "Customer Report", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in ExportCustomerReport:" + ex.Message.ToString());
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
                GlobalClass.WriteLog("Error in releaseObject:" + ex.Message.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        public void ClearForm()
        {
            try
            {
                cmbCustName.SelectedIndex = -1;
                cmbCustomerName.SelectedIndex = -1;
                cmbEvent.SelectedIndex = -1;
                cmbReligion.SelectedIndex = -1;
                dgDisplayCustomerRep.DataSource = null;
            }
            catch (Exception ex)
            {
            }
        }

        private void dgDisplayCustomerRep_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (sCustomerReportType == "REPBYCUSTNOTVISITED")
                {

                    foreach (Form form in System.Windows.Forms.Application.OpenForms)
                    {
                        if (form is frmViewCustomerVisitDetail)
                        {
                            MessageBox.Show("Customer Visit detail window is already open.Please close previous window to view other details.", "Customer Report", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                    frmViewCustomerVisitDetail frmViewCustomerDetails = new frmViewCustomerVisitDetail(dgDisplayCustomerRep.Rows[dgDisplayCustomerRep.CurrentCell.RowIndex].Cells["CustomerName"].Value.ToString(), sFromDate, sTodate, sReportName, sCustomerReportType);
                    frmViewCustomerDetails.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                    frmViewCustomerDetails.MdiParent = this.ParentForm;
                    frmViewCustomerDetails.Show();                    
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void dgDisplayCustomerRep_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
