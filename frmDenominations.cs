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
    public partial class frmDenominations : Form
    {
        public frmDenominations()
        {
            InitializeComponent();
        }
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt1000Cnt_Leave(object sender, EventArgs e)
        {
            //txt1000Mult.Text =(Convert.ToDecimal( txt1000.Text) *Convert.ToDecimal( txt1000Cnt.Text)).ToString();
        }

        private void txt500Cnt_Leave(object sender, EventArgs e)
        {
            //txt500Mult.Text = (Convert.ToDecimal(txt500.Text) * Convert.ToDecimal(txt500Cnt.Text)).ToString();
        }

        private void txt200Cnt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt200Cnt_Leave(object sender, EventArgs e)
        {
            //txt200Mult.Text = (Convert.ToDecimal(txt200.Text) * Convert.ToDecimal(txt200Cnt.Text)).ToString();
        }

        private void txt100Cnt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt100Cnt_Leave(object sender, EventArgs e)
        {
            //txt100Mult.Text = (Convert.ToDecimal(txt100.Text) * Convert.ToDecimal(txt100Cnt.Text)).ToString();
        }

        private void txt50Cnt_Leave(object sender, EventArgs e)
        {
            //txt50Mult.Text = (Convert.ToDecimal(txt50.Text) * Convert.ToDecimal(txt50Cnt.Text)).ToString();
        }

        private void txt20Cnt_Leave(object sender, EventArgs e)
        {
            //txt20Mult.Text = (Convert.ToDecimal(txt20.Text) * Convert.ToDecimal(txt20Cnt.Text)).ToString();
        }

        private void txt10Cnt_Leave(object sender, EventArgs e)
        {
            //txt10Mult.Text = (Convert.ToDecimal(txt10.Text) * Convert.ToDecimal(txt10Cnt.Text)).ToString();
        }

        private void txt5Cnt_Leave(object sender, EventArgs e)
        {
            //txt5Mult.Text = (Convert.ToDecimal(txt5.Text) * Convert.ToDecimal(txt5Cnt.Text)).ToString();
        }

        private void txt1Cnt_Leave(object sender, EventArgs e)
        {
            //txt1Mult.Text = (Convert.ToDecimal(txt1.Text) * Convert.ToDecimal(txt1Cnt.Text)).ToString();
        }

        private void txt50FlsCnt_Leave(object sender, EventArgs e)
        {
            //txt50FlsMult.Text = (Convert.ToDecimal(txt50Fls.Text) * Convert.ToDecimal(txt50FlsCnt.Text)).ToString();
        }

        private void txt25FlsCnt_Leave(object sender, EventArgs e)
        {
            //txt25FlsMult.Text = (Convert.ToDecimal(txt25Fls.Text) * Convert.ToDecimal(txt25FlsCnt.Text)).ToString();

            //txtTotal.Text = (Convert.ToDecimal(txt1000Mult.Text) + Convert.ToDecimal(txt500Mult.Text) + Convert.ToDecimal(txt200Mult.Text) + Convert.ToDecimal(txt100Mult.Text) + Convert.ToDecimal(txt50Mult.Text) + Convert.ToDecimal(txt20Mult.Text) + Convert.ToDecimal(txt10Mult.Text) + Convert.ToDecimal(txt5Mult.Text) + Convert.ToDecimal(txt1Mult.Text) + Convert.ToDecimal(txt50FlsMult.Text) + Convert.ToDecimal(txt25FlsMult.Text)).ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        public void ClearForm()
        {
            try
            {
                ////txt1000Cnt.Text = "0";
                //txt500Cnt.Text = "0";
                //txt200Cnt.Text = "0";
                //txt100Cnt.Text = "0";
                //txt50Cnt.Text = "0";
                //txt20Cnt.Text = "0";
                //txt10Cnt.Text = "0";
                //txt5Cnt.Text = "0";
                //txt1Cnt.Text = "0";
                //txt50FlsCnt.Text = "0";
                //txt25FlsCnt.Text = "0";
                txtTotal.Text = "0.00";
                txtFloatCash.Text = "0.00";
                txtAdjustment.Text = "0.00";

                dgDenominations.Rows.Clear();
                //txt1000Mult.Text = "";
                //txt500Mult.Text = "";
                //txt200Mult.Text = "";
                //txt100Mult.Text = "";
                //txt50Mult.Text = "";
                //txt20Mult.Text = "";
                //txt10Mult.Text = "";
                //txt5Mult.Text = "";
                //txt1Mult.Text = "";
                //txt50FlsMult.Text = "";
                //txt25FlsMult.Text = "";
                
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sFlag,sEODDate,sDenominationType,sDenominationCount,sDenominationResult;
                sEODDate = dtpckrDatetime.Value.ToString("yyyy-MM-dd");
                int iResult;
                if (MessageBox.Show("Are you sure to add Denominations,please confirm", "Denominations", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                {
                    return;
                }
                for (int i = 0; i < dgDenominations.Rows.Count; i++)
                {
                    sFlag = "SAVE";
                    cmd = new SqlCommand();
                    cmd.Connection = GlobalClass.gCon;
                    cmd.CommandText = "SP_MaintainDenomination";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag;
                    cmd.Parameters.Add("@DenDate", SqlDbType.VarChar, sEODDate.Length).Value = sEODDate;

                    sDenominationType=dgDenominations.Rows[i].Cells["Denomination"].Value.ToString();
                    cmd.Parameters.Add("@DenominationType", SqlDbType.VarChar, sDenominationType.Length).Value = sDenominationType;

                    sDenominationCount = dgDenominations.Rows[i].Cells["DenominationCount"].Value.ToString();
                    cmd.Parameters.Add("@DenominationCount", SqlDbType.VarChar, sDenominationCount.Length).Value = sDenominationCount;

                    sDenominationResult = dgDenominations.Rows[i].Cells["Result"].Value.ToString();
                    cmd.Parameters.Add("@DenTypeIntoCount", SqlDbType.VarChar, sDenominationResult.Length).Value = sDenominationResult;

                    cmd.Parameters.Add("@TotalDenomination", SqlDbType.VarChar, txtTotal.Text.Length).Value = txtTotal.Text.Trim();
                    cmd.Parameters.Add("@DenFloatCash", SqlDbType.Decimal, txtFloatCash.Text.Length).Value =Convert.ToDecimal(txtFloatCash.Text);
                    cmd.Parameters.Add("@DenAdjustment", SqlDbType.Decimal, txtAdjustment.Text.Length).Value =Convert.ToDecimal(txtAdjustment.Text);

                    iResult = cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Denominations added successfully", "Denominations", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in Denominations btnSave_Click:" + ex.Message.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmDenominations_Load(object sender, EventArgs e)
        {
            try
            {
                dgDenominations.Rows.Add("1000.00");
                dgDenominations.Rows.Add("500.00");
                dgDenominations.Rows.Add("200.00");
                dgDenominations.Rows.Add("100.00");
                dgDenominations.Rows.Add("50.00");
                dgDenominations.Rows.Add("20.00");
                dgDenominations.Rows.Add("10.00");
                dgDenominations.Rows.Add("5.00");
                dgDenominations.Rows.Add("1.00");
                dgDenominations.Rows.Add("0.50");
                dgDenominations.Rows.Add("0.25");
            }
            catch (Exception ex)
            {

            }
        }

        private void dgDenominations_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
             //   dgDenominations.Rows[e.RowIndex].Cells["Result"].Value = Convert.ToDecimal(dgDenominations.Rows[e.RowIndex].Cells["Denomination"].Value) * Convert.ToDecimal(dgDenominations.Rows[e.RowIndex].Cells["DenominationCount"].Value);
            }
            catch (Exception ex)
            {

            }
        }

        private void dgDenominations_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgDenominations_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Decimal dcTotalAMount = 0;
            try
            {
                if(e.RowIndex>=0)
                dgDenominations.Rows[e.RowIndex].Cells["Result"].Value = Convert.ToDecimal(dgDenominations.Rows[e.RowIndex].Cells["Denomination"].Value) * Convert.ToDecimal(dgDenominations.Rows[e.RowIndex].Cells["DenominationCount"].Value);

                for( int i=0;i<dgDenominations.Rows.Count;i++)
                {
                    dcTotalAMount=dcTotalAMount+Convert.ToDecimal(dgDenominations.Rows[i].Cells["Result"].Value);
                }
                txtTotal.Text=dcTotalAMount.ToString();
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in dgDenominations_CellValueChanged:" + ex.Message.ToString());
            }
        }

    }
}
