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
    public partial class frmReceiptIssue : Form
    {
        public frmReceiptIssue()
        {
            InitializeComponent();
        }
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        string strFlag = "",sPaymentMode;

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        public void ClearForm()
        {
            dgvwdisplayinvoice.DataSource = null;
            txtAcNo.Text = "";
            txtTotalAMount.Text = "0.00";
            txtTotalBalAmt.Text = "0.00";
            txtTotalPaidAmt.Text = "0.00";
            rbtnCash.Checked = true;
            txtChequeDt.Text = "";
            txtChequeNo.Text = "";
            txtBankName.Text = "";
            txtChqAmount.Text = "";
            cmbCreditCardType.Text = "";
            RINumberGenerator();

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalClass.gsReceiptFlag = "SEARCH";
                GlobalClass.gsReceiptIssueInvoice = txtInvoiceNo.Text.Trim();
                frmSearchCreditCustomers fr = new frmSearchCreditCustomers();
                fr.EvtSharecustname+=new frmSearchCreditCustomers.ShareCustomerName(fr_EvtSharecustname);
                fr.MdiParent = this.ParentForm;
                fr.Show();
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
            }
        }
        private void fr_EvtSharecustname(object sender, ShareCustomerNameArgs e)
        {
            try
            {
                string sCustomerName;
                sCustomerName = e.CustomerName.ToString();
                PopulateCreditCustomers(sCustomerName);
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
            }
        }
        public void PopulateCreditCustomers(string sCustName)
        {
            try
            {
                GlobalClass.gsReceiptFlag = "LOAD";
                cmd = new SqlCommand();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_SearchCreditCustomers";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 20).Value = GlobalClass.gsReceiptFlag;
                cmd.Parameters.Add("@FromDate", SqlDbType.VarChar, 20).Value = "";
                cmd.Parameters.Add("@ToDate", SqlDbType.VarChar, 20).Value = "";
                cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 20).Value = GlobalClass.gsReceiptIssueInvoice;
                cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar, 20).Value = sCustName;
                ds = new DataSet();
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                dgvwdisplayinvoice.DataSource = ds.Tables["Result"];
            }
            catch (Exception Ex)
            {
                GlobalClass.WriteLog(Ex.Message.ToString());
            }
        }

        private void frmReceiptIssue_Load(object sender, EventArgs e)
        {
            try
            {
                cmbCreditCardType.Items.Add("VISA");
                cmbCreditCardType.Items.Add("MASTERCARD");
                cmbCreditCardType.Items.Add("AMEX");
                cmbCreditCardType.Items.Add("DINERS");
                cmbCreditCardType.Items.Add("OTHERS");
                rbtnCash.Checked = true;
                RINumberGenerator();
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
            }
        }
        public void RINumberGenerator()
        {
            try
            {
                GlobalClass.WriteLog("Before Fetching Receipt Issue Numbers");
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_GetInvoiceCounter";
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10).Value = "RINO";
                txtRINumber.Text = "RI" + GlobalClass.gsCounterNo + cmd.ExecuteScalar().ToString().PadLeft(7, '0');

                GlobalClass.WriteLog(" Receipt Issue Fetched Successfully. Invoice No:" + txtRINumber.Text);
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in RINumberGenerator:" + ex.Message.ToString());
            }
        }

        private void rbtnCash_CheckedChanged(object sender, EventArgs e)
        {
            cmbCreditCardType.Enabled = false;
            grpboxChequeDetails.Enabled = false;
            sPaymentMode = "CASH";
        }

        private void rbtnCheque_CheckedChanged(object sender, EventArgs e)
        {
            cmbCreditCardType.Enabled = false;
            grpboxChequeDetails.Enabled = true;
            sPaymentMode = "CHEQUE";
        }

        private void rbtnCreditCard_CheckedChanged(object sender, EventArgs e)
        {
            cmbCreditCardType.Enabled = true;
            grpboxChequeDetails.Enabled = false;
            sPaymentMode = "CREDITCARD";
        }

        private void dgvwdisplayinvoice_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateTotal();
        }
        public void CalculateTotal()
        {
            try
            {
                //int iSum,iAmount;
                Decimal dAmount, iSum,dpaidAmt,dBalAmount;
                // string sAmt;
                iSum = 0;
                dpaidAmt = 0; dBalAmount = 0;
                for (int j = 0; j < dgvwdisplayinvoice.Rows.Count; j++)
                {
                    //iSum = iSum + Convert.ToInt16(ds.Tables["Result"].Rows[j]["Amount"]);
                    //sAmt =dgDisplayKOTDetails.Rows[j].Cells["Amount"].Value.ToString();
                    //iAmount = Convert.ToDecimal(sAmt);
                    iSum = iSum + Convert.ToDecimal(dgvwdisplayinvoice.Rows[j].Cells["Amount"].Value);
                    dpaidAmt = dpaidAmt + Convert.ToDecimal(dgvwdisplayinvoice.Rows[j].Cells["Paid Amount"].Value);
                    dBalAmount  = dBalAmount + Convert.ToDecimal(dgvwdisplayinvoice.Rows[j].Cells["Balance Amount"].Value);
                    //GlobalClass.gbOrderChanged = true;
                    //MessageBox.Show(ds.Tables["Result"].Rows[i]["Amount"].ToString(),"Saels",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                }
                txtTotalAMount.Text = iSum.ToString("0,0.00");
                txtTotalPaidAmt.Text = dpaidAmt.ToString("0,0.00");
                txtTotalBalAmt.Text = dBalAmount.ToString("0,0.00");
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Error in Sales", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvwdisplayinvoice.Rows.Count == 0)
                {
                    MessageBox.Show("No Records for Receipt Issue", "Receipt Issue", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }                
                strFlag = "SAVE";
                ManageReceiptIssue(strFlag);
                ClearForm();
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
            }
        }

        private void dgvwdisplayinvoice_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateTotal();
        }
        public void ManageReceiptIssue(string sFlag)
        {
            try
            {
                string sResult;
                if (sFlag == "SAVE")
                {
                    cmd = new SqlCommand();
                    cmd.Connection = GlobalClass.gCon;
                    cmd.CommandText = "SP_MaintainReceiptIssue";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 20).Value = sFlag;
                    cmd.Parameters.Add("@RINo", SqlDbType.VarChar, 20).Value = txtRINumber.Text;
                    cmd.Parameters.Add("@Remarks", SqlDbType.VarChar, txtremarks.Text.Trim().Length).Value = txtremarks.Text;
                    cmd.Parameters.Add("@SalesMan", SqlDbType.VarChar, txtsalesman.Text.Trim().Length).Value = txtsalesman.Text;
                    cmd.Parameters.Add("@TotalAmount", SqlDbType.VarChar, txtTotalAMount.Text.Trim().Length).Value = txtTotalAMount.Text.Replace(",","");
                    cmd.Parameters.Add("@TotalPaidAmt", SqlDbType.VarChar, txtTotalPaidAmt.Text.Trim().Length).Value = txtTotalPaidAmt.Text.Replace(",","");
                    cmd.Parameters.Add("@TotalBalAmt", SqlDbType.VarChar, txtTotalBalAmt.Text.Trim().Length).Value = txtTotalBalAmt.Text.Replace(",","");
                    cmd.Parameters.Add("@PaymentMode", SqlDbType.VarChar, sPaymentMode.Length).Value = sPaymentMode;
                    cmd.Parameters.Add("@CCType", SqlDbType.VarChar, cmbCreditCardType.Text.Trim().Length).Value = cmbCreditCardType.Text;
                    cmd.Parameters.Add("@Bankname", SqlDbType.VarChar, txtBankName.Text.Trim().Length).Value = txtBankName.Text;
                    cmd.Parameters.Add("@AcNo", SqlDbType.VarChar, txtAcNo.Text.Trim().Length).Value = txtAcNo.Text;
                    cmd.Parameters.Add("@Chequeno", SqlDbType.VarChar, txtChequeNo.Text.Trim().Length).Value = txtChequeNo.Text;
                    cmd.Parameters.Add("@ChequeDate", SqlDbType.VarChar, txtChequeDt.Text.Trim().Length).Value = txtChequeDt.Text;
                    if (txtChqAmount.Text == "")
                        txtChqAmount.Text = "0.00";
                    cmd.Parameters.Add("@ChequeAmt", SqlDbType.VarChar, txtChqAmount.Text.Trim().Length).Value = txtChqAmount.Text.Replace(",","");
                    sResult= cmd.ExecuteScalar().ToString();

                    cmd = new SqlCommand();
                    cmd.Connection = GlobalClass.gCon;
                    cmd.CommandText = "SP_UpdateReceiptMaster";
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < dgvwdisplayinvoice.Rows.Count; i++)
                    {
                        cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10).Value = "UPDATE";
                        cmd.Parameters.Add("@RINo", SqlDbType.VarChar, 20).Value = txtRINumber.Text;
                        cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, dgvwdisplayinvoice.Rows[i].Cells["InvoiceNo"].Value.ToString().Length).Value = dgvwdisplayinvoice.Rows[i].Cells["InvoiceNo"].Value.ToString();
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand();
                    }
                    MessageBox.Show(sResult, "Receipt Issue", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
            }
        }
    }
}
