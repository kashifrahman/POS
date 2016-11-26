using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace SalesPurchase
{
    public partial class frmDayEndReport : Form
    {
        public frmDayEndReport()
        {
            InitializeComponent();
        }

        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        private void frmDayEndReport_Load(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandText = "SP_FetchCashierDetails";
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 20).Value = "CASHIERLIST";
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                for (int i = 0; i < ds.Tables["Result"].Rows.Count; i++)
                {
                    cmbCashier.Items.Add(ds.Tables["Result"].Rows[i]["Cashier"].ToString());
                }
                cmbCashier.Items.Add("ALL");


            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in frmDayEndReport_Load:"+ex.Message.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sCashSalesCount="", sCashSalesAmt="", sDiscountcount="", sDiscountamt="";
            string sSalesretCount="", sSalesRetAmt="", sNetCashSalesCnt="", sNetcashSalesAmt="",sCreditcardsalescnt="",screditcardsalesamt="";
            string sTotalretailsalescnt = "", stotalretailsalesamt = "", screditsalescnt = "", screditsalesamt = "";
            string screditsalesreturncnt = "", screditsalesreturnamt = "", stotalcnt="", stotalamt = "";
            string sVisaCnt = "", sVisaAmt = "", sMasterCnt = "", sMasterAmt = "", sAmexCnt = "", sAmexAmt = "", sDinersCnt = "", sDinersAmt = "", sOthersCnt = "", sOthersAmt = "";
            try
            {
                //reportViewer1.Visible = false;
                //cmd = new SqlCommand();
                //cmd.Connection = GlobalClass.gCon;
                //cmd.CommandText = "SP_DayEndReport";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 20).Value = "DAYENDREPORT";
                //ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                ////ds=Sqlhelper.
                //reportViewer1.Reset();
                //reportViewer1.LocalReport.ReportPath = "rptDayEndSales.rdlc";
                ////reportViewer1.ProcessingMode = ProcessingMode.Local;
                
                ////reportViewer1.LocalReport.LoadReportDefinition();
                ////reportViewer1.Dock = DockStyle.Fill;
                //ReportDataSource rds = new ReportDataSource("Tab", ds.Tables["Result"]);
                //reportViewer1.LocalReport.DataSources.Clear();
                //reportViewer1.LocalReport.DataSources.Add(rds);
                //reportViewer1.LocalReport.Refresh();
                //reportViewer1.Visible = true;
                //reportViewer1.ZoomMode = ZoomMode.Percent;
                this.datasetDayEndReport.Clear();
                //reportViewer1.Reset();
                string sFromDate, sToDate, sFromTime, sToTime, sCashier,sOpeningInvNo,sClosingInvNo;
                
                sFromDate = dtPckrFromDate.Value.ToString("yyyy-MM-dd");
                sToDate = dtPckrToDate.Value.ToString("yyyy-MM-dd");
                sFromTime = mskdTxtfromTime.Text;
                sToTime = mskdTxtToTime.Text;
                sCashier = cmbCashier.Text.Trim();

                if (cmbCashier.Text == "")
                {
                    MessageBox.Show("Please select a Cashier Name or 'ALL' Option to generate Report", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                cmd = new SqlCommand();
                ds = new DataSet();
                cmd.CommandText = "SP_FetchCashierDetails";
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 30).Value = "CASHIERCLOSING";
                cmd.Parameters.Add("@CashierName", SqlDbType.VarChar, 30).Value = sCashier;
                cmd.Parameters.Add("@OrderFromdate", SqlDbType.VarChar, 30).Value = sFromDate;
                cmd.Parameters.Add("@OrderToDate", SqlDbType.VarChar, 30).Value = sToDate;
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                sOpeningInvNo = ds.Tables["Result"].Rows[0]["OpeningInvNo"].ToString();
                sClosingInvNo = ds.Tables["Result"].Rows[0]["ClosingInvNo"].ToString();


                GlobalClass.WriteLog("Before Executing Procedure");
                //this.SP_DayEndReportTableAdapter.Fill(this.datasetDayEndReport.SP_DayEndReport, "DAYENDREPORT",sFromDate,sToDate,sFromTime,sToTime,sCashier);
                cmd = new SqlCommand();
                ds = new DataSet();
                cmd.CommandText = "SP_DayEndReport_NEW";
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 30).Value = "DAYENDREPORT";
                cmd.Parameters.Add("@sFromDate", SqlDbType.VarChar, 30).Value = sFromDate;
                cmd.Parameters.Add("@sToDate", SqlDbType.VarChar, 30).Value = sToDate;
                cmd.Parameters.Add("@sFromTime", SqlDbType.VarChar, 30).Value =sFromTime;
                cmd.Parameters.Add("@sToTime", SqlDbType.VarChar, 30).Value = sToTime;
                cmd.Parameters.Add("@sCashier", SqlDbType.VarChar, 30).Value = sCashier;
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                GlobalClass.WriteLog("After Executing Procedure");
                for (int i = 0; i < ds.Tables["Result"].Rows.Count; i++)
                {
                    if (ds.Tables["Result"].Rows[i]["Narration"].ToString() == "CASHSALES")
                    {
                        sCashSalesCount = ds.Tables["Result"].Rows[i]["Count"].ToString();
                        sCashSalesAmt = ds.Tables["Result"].Rows[i]["Amount"].ToString();
                    }

                    if (ds.Tables["Result"].Rows[i]["Narration"].ToString() == "DISCOUNT")
                    {
                        sDiscountcount = ds.Tables["Result"].Rows[i]["Count"].ToString();
                        sDiscountamt = ds.Tables["Result"].Rows[i]["Amount"].ToString();
                    }

                    if (ds.Tables["Result"].Rows[i]["Narration"].ToString() == "SALESRETURN")
                    {
                        sSalesretCount = ds.Tables["Result"].Rows[i]["Count"].ToString();
                        sSalesRetAmt = ds.Tables["Result"].Rows[i]["Amount"].ToString();
                    }
                    if (ds.Tables["Result"].Rows[i]["Narration"].ToString() == "NETCASHSALES(A)")
                    {
                        sNetCashSalesCnt = ds.Tables["Result"].Rows[i]["Count"].ToString();
                        sNetcashSalesAmt = ds.Tables["Result"].Rows[i]["Amount"].ToString();
                    }
                    if (ds.Tables["Result"].Rows[i]["Narration"].ToString() == "CREDITCARDSALES")
                    {
                        sCreditcardsalescnt = ds.Tables["Result"].Rows[i]["Count"].ToString();
                        screditcardsalesamt = ds.Tables["Result"].Rows[i]["Amount"].ToString();
                    }
                    if (ds.Tables["Result"].Rows[i]["Narration"].ToString() == "TOTALRETAILSALES")
                    {
                        sTotalretailsalescnt = ds.Tables["Result"].Rows[i]["Count"].ToString();
                        stotalretailsalesamt = ds.Tables["Result"].Rows[i]["Amount"].ToString();
                    }
                    if (ds.Tables["Result"].Rows[i]["Narration"].ToString() == "CREDITSALES")
                    {
                        screditsalescnt = ds.Tables["Result"].Rows[i]["Count"].ToString();
                        screditsalesamt = ds.Tables["Result"].Rows[i]["Amount"].ToString();
                    }
                    if (ds.Tables["Result"].Rows[i]["Narration"].ToString() == "CREDITSALESRETURN")
                    {
                        screditsalesreturncnt = ds.Tables["Result"].Rows[i]["Count"].ToString();
                        screditsalesreturnamt = ds.Tables["Result"].Rows[i]["Amount"].ToString();
                    }
                    if (ds.Tables["Result"].Rows[i]["Narration"].ToString() == "TOTALSALES")
                    {
                        stotalcnt = ds.Tables["Result"].Rows[i]["Count"].ToString();
                        stotalamt = ds.Tables["Result"].Rows[i]["Amount"].ToString();
                    }
                    if (ds.Tables["Result"].Rows[i]["Narration"].ToString() == "VISA")
                    {
                        sVisaCnt = ds.Tables["Result"].Rows[i]["Count"].ToString();
                        sVisaAmt = ds.Tables["Result"].Rows[i]["Amount"].ToString();
                    }
                    if (ds.Tables["Result"].Rows[i]["Narration"].ToString() == "MASTERCARD")
                    {
                        sMasterCnt = ds.Tables["Result"].Rows[i]["Count"].ToString();
                        sMasterAmt = ds.Tables["Result"].Rows[i]["Amount"].ToString();
                    }
                    if (ds.Tables["Result"].Rows[i]["Narration"].ToString() == "AMEX")
                    {
                        sAmexCnt = ds.Tables["Result"].Rows[i]["Count"].ToString();
                        sAmexAmt = ds.Tables["Result"].Rows[i]["Amount"].ToString();
                    }
                    if (ds.Tables["Result"].Rows[i]["Narration"].ToString() == "DINERS")
                    {
                        sDinersCnt = ds.Tables["Result"].Rows[i]["Count"].ToString();
                        sDinersAmt = ds.Tables["Result"].Rows[i]["Amount"].ToString();
                    }
                    if (ds.Tables["Result"].Rows[i]["Narration"].ToString() == "OTHERS")
                    {
                        sOthersCnt = ds.Tables["Result"].Rows[i]["Count"].ToString();
                        sOthersAmt = ds.Tables["Result"].Rows[i]["Amount"].ToString();
                    }
                }
                ReportParameterCollection CashSalesCount = new ReportParameterCollection();

                CashSalesCount.Add(new ReportParameter("CashSalesCount", sCashSalesCount));
                reportViewer1.LocalReport.SetParameters(CashSalesCount);
                //reportViewer1.LocalReport.SetParameters(CashSalesCount);

                ReportParameterCollection CashSalesAmount = new ReportParameterCollection();
                CashSalesAmount.Add(new ReportParameter("CashSalesAmount", sCashSalesAmt));
                reportViewer1.LocalReport.SetParameters(CashSalesAmount);

                ReportParameterCollection CashDiscountCnt = new ReportParameterCollection();
                CashDiscountCnt.Add(new ReportParameter("CashDiscountCnt", sDiscountcount));
                reportViewer1.LocalReport.SetParameters(CashDiscountCnt);

                ReportParameterCollection DiscountAmt = new ReportParameterCollection();
                DiscountAmt.Add(new ReportParameter("DiscountAmt", sDiscountamt));
                reportViewer1.LocalReport.SetParameters(DiscountAmt);

                //
                ReportParameterCollection SalesRetCount = new ReportParameterCollection();
                SalesRetCount.Add(new ReportParameter("SalesRetCount", sSalesretCount));
                reportViewer1.LocalReport.SetParameters(SalesRetCount);

                ReportParameterCollection SalesRetAmt = new ReportParameterCollection();
                SalesRetAmt.Add(new ReportParameter("SalesRetAmt", sSalesRetAmt));
                reportViewer1.LocalReport.SetParameters(SalesRetAmt);

                ReportParameterCollection NetCashSalesCnt = new ReportParameterCollection();
                NetCashSalesCnt.Add(new ReportParameter("NetCashSalesCnt", sNetCashSalesCnt));
                reportViewer1.LocalReport.SetParameters(NetCashSalesCnt);

                ReportParameterCollection NetCashSalesAmt = new ReportParameterCollection();
                NetCashSalesAmt.Add(new ReportParameter("NetCashSalesAmt", sNetcashSalesAmt));
                reportViewer1.LocalReport.SetParameters(NetCashSalesAmt);

                ReportParameterCollection CreditCardSalesCnt = new ReportParameterCollection();
                CreditCardSalesCnt.Add(new ReportParameter("CreditCardSalesCnt", sCreditcardsalescnt));
                reportViewer1.LocalReport.SetParameters(CreditCardSalesCnt);

                ReportParameterCollection CreditCardSalesAmt = new ReportParameterCollection();
                CreditCardSalesAmt.Add(new ReportParameter("CreditCardSalesAmt", screditcardsalesamt));
                reportViewer1.LocalReport.SetParameters(CreditCardSalesAmt);

                ReportParameterCollection TotalRetailSalesCnt = new ReportParameterCollection();
                TotalRetailSalesCnt.Add(new ReportParameter("TotalRetailSalesCnt", sTotalretailsalescnt));
                reportViewer1.LocalReport.SetParameters(TotalRetailSalesCnt);

                ReportParameterCollection TotalRetailSalesAmt = new ReportParameterCollection();
                TotalRetailSalesAmt.Add(new ReportParameter("TotalRetailSalesAmt", stotalretailsalesamt));
                reportViewer1.LocalReport.SetParameters(TotalRetailSalesAmt);


                ReportParameterCollection CreditSalesCnt = new ReportParameterCollection();
                CreditSalesCnt.Add(new ReportParameter("CreditSalesCnt", screditsalescnt));
                reportViewer1.LocalReport.SetParameters(CreditSalesCnt);

                ReportParameterCollection CreditSalesAmt = new ReportParameterCollection();
                CreditSalesAmt.Add(new ReportParameter("CreditSalesAmt", screditsalesamt));
                reportViewer1.LocalReport.SetParameters(CreditSalesAmt);

                ReportParameterCollection CreditSalesReturnCnt = new ReportParameterCollection();
                CreditSalesReturnCnt.Add(new ReportParameter("CreditSalesReturnCnt", screditsalesreturncnt));
                reportViewer1.LocalReport.SetParameters(CreditSalesReturnCnt);

                ReportParameterCollection CreditSalesReturnAmt = new ReportParameterCollection();
                CreditSalesReturnAmt.Add(new ReportParameter("CreditSalesReturnAmt", screditsalesreturnamt));
                reportViewer1.LocalReport.SetParameters(CreditSalesReturnAmt);

                ReportParameterCollection TotalSalesCnt = new ReportParameterCollection();
                TotalSalesCnt.Add(new ReportParameter("TotalSalesCnt", stotalcnt));
                reportViewer1.LocalReport.SetParameters(TotalSalesCnt);

                ReportParameterCollection TotalSalesAmt = new ReportParameterCollection();
                TotalSalesAmt.Add(new ReportParameter("TotalSalesAmt", stotalamt));
                reportViewer1.LocalReport.SetParameters(TotalSalesAmt);

                ReportParameterCollection VisaCnt = new ReportParameterCollection();
                VisaCnt.Add(new ReportParameter("VisaCnt", sVisaCnt));
                reportViewer1.LocalReport.SetParameters(VisaCnt);

                ReportParameterCollection VisaAmt = new ReportParameterCollection();
                VisaAmt.Add(new ReportParameter("VisaAmt", sVisaAmt));
                reportViewer1.LocalReport.SetParameters(VisaAmt);

                ReportParameterCollection MasterCnt = new ReportParameterCollection();
                MasterCnt.Add(new ReportParameter("MasterCnt", sMasterCnt));
                reportViewer1.LocalReport.SetParameters(MasterCnt);

                ReportParameterCollection MasterAmt = new ReportParameterCollection();
                MasterAmt.Add(new ReportParameter("MasterAmt", sMasterAmt));
                reportViewer1.LocalReport.SetParameters(MasterAmt);

                ReportParameterCollection AmexCnt = new ReportParameterCollection();
                AmexCnt.Add(new ReportParameter("AmexCnt", sAmexCnt));
                reportViewer1.LocalReport.SetParameters(AmexCnt);

                ReportParameterCollection AmexAmt = new ReportParameterCollection();
                AmexAmt.Add(new ReportParameter("AmexAmt", sAmexAmt));
                reportViewer1.LocalReport.SetParameters(AmexAmt);                

                ReportParameterCollection repparams = new ReportParameterCollection();
                repparams.Add(new ReportParameter("FromDate",dtPckrFromDate.Value.ToString()) );
                reportViewer1.LocalReport.SetParameters(repparams);

                ReportParameterCollection repparams1 = new ReportParameterCollection();
                repparams1.Add(new ReportParameter("ToDate", dtPckrToDate.Value.ToString()));
                reportViewer1.LocalReport.SetParameters(repparams1);
                

                ReportParameterCollection repparams2 = new ReportParameterCollection();
                repparams2.Add(new ReportParameter("Cashier", cmbCashier.Text.ToString()));
                reportViewer1.LocalReport.SetParameters(repparams2);


                ReportParameterCollection OpeningInvNo = new ReportParameterCollection();
                OpeningInvNo.Add(new ReportParameter("OpeningInvNo", sOpeningInvNo));
                reportViewer1.LocalReport.SetParameters(OpeningInvNo);

                ReportParameterCollection ClosingInvNo = new ReportParameterCollection();
                ClosingInvNo.Add(new ReportParameter("ClosingInvNo", sClosingInvNo));
                reportViewer1.LocalReport.SetParameters(ClosingInvNo);
                
                //Added By Kashif on 28-Aug-2015
                ReportParameterCollection HotelName = new ReportParameterCollection();
                HotelName.Add(new ReportParameter("HotelName", GlobalClass.gsCompanyName));
                reportViewer1.LocalReport.SetParameters(HotelName);
                

                this.reportViewer1.RefreshReport();
               
               
                
                //this.SP_DayEndReport1TableAdapter.Fill(this.datasetDayEndReport.SP_DayEndReport, "CREDITCARDREPORT", "", "", "", "", "");
                
                
            }
            catch (Exception ex)
            {
                   GlobalClass.WriteLog("Error in button1_Click:"+ex.Message.ToString());
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
