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
    public partial class frmChangeEODTime : Form
    {
        public frmChangeEODTime()
        {
            InitializeComponent();
        }
        SqlCommand cmd = new SqlCommand();

        private void frmChangeEODTime_Load(object sender, EventArgs e)
        {
            try
            {
                cmbAMPM.Items.Add("AM");
                cmbAMPM.Items.Add("PM");

                string sRetVal = "";

                cmd = new SqlCommand();
                cmd.CommandText = "SP_MaintainDayEnd";
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 20).Value = "GETEODTIME";
                cmd.Parameters.Add("@EODDate", SqlDbType.VarChar, 20).Value = " ";
                cmd.Parameters.Add("@EODTime", SqlDbType.VarChar, 20).Value = mskdboxTime.Text + ":00" + cmbAMPM.Text;
                sRetVal = cmd.ExecuteScalar().ToString();
                lblEODTime.Text = sRetVal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception in form load:"+ex.Message.ToString(), "Change Time", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {   string sRetVal;

                if (mskdboxTime.Text == "00:00")
                {
                    MessageBox.Show("Please enter proper date", "Change Time", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (cmbAMPM.Text == "")
                {
                    MessageBox.Show("Please enter AM/PM date", "Change Time", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MaintainDayEnd";
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 20).Value = "CHANGE";
                cmd.Parameters.Add("@EODDate", SqlDbType.VarChar, 20).Value = " ";
                cmd.Parameters.Add("@EODTime", SqlDbType.VarChar, 20).Value =mskdboxTime.Text +":00"+cmbAMPM.Text;
                sRetVal = cmd.ExecuteScalar().ToString();
                MessageBox.Show(sRetVal, "Change EOD Time", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception Ex)
            {
                GlobalClass.WriteLog("Error in btnChange_Click:" + Ex.Message.ToString());
            }

        }

        private void mskdboxTime_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                MessageBox.Show("The Time is NOT in Valid format", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
