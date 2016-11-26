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
    public partial class frmEventMaster : Form
    {
        public frmEventMaster()
        {
            InitializeComponent();
        }
        public string sFlag,sRetVal;
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();

        private void btnEventExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnEventAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEventName.Text.Trim() == "")
                {
                    MessageBox.Show("Event Name is empty,Please enter event name", "Event Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtEventName.Focus();
                    return;
                }
                sFlag = "ADD";
                sRetVal = ManageEventMaster(sFlag);
                if (sRetVal == GlobalClass.SUCCESS)
                {
                    MessageBox.Show("Event Name saved successfully", "Event Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ClearForm();
                }
            }
            catch (Exception ex)
            {

            }

        }
        public string ManageEventMaster(string Flag)
        {
            try
            {
                int i;
                cmd = new SqlCommand();
                cmd.CommandText = "SP_ManageEventMaster";
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, Flag.Length).Value = Flag.Trim();
                cmd.Parameters.Add("@Eventname", SqlDbType.VarChar, txtEventName.Text.Length).Value = txtEventName.Text.Trim();
                    if (Flag == "ADD" || Flag == "DELETE")
                {

                    i=cmd.ExecuteNonQuery();
                    if (i >= 1)
                        return GlobalClass.SUCCESS;
                    else
                        return GlobalClass.FAIL;
                }
                else
                {
                    ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                    dgEventMaster.DataSource = ds.Tables["Result"];
                    return GlobalClass.SUCCESS;
                }
                //return GlobalClass.SUCCESS;
            }
            catch (Exception ex)
                {
                return GlobalClass.FAIL;
                MessageBox.Show(ex.Message.ToString(), "Event Master", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnEventDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEventName.Text.Trim() == "")
                {
                    MessageBox.Show("Event Name is empty,Please enter event name", "Event Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtEventName.Focus();
                    return;
                }
                sFlag = "DELETE";
                sRetVal = ManageEventMaster(sFlag);
                if (sRetVal == GlobalClass.SUCCESS)
                {
                    MessageBox.Show("Event Name Deleted successfully", "Event Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Event Master", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnEventSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtEventName.Text.Trim() == "")
                //{
                //    MessageBox.Show("Event Name is empty,Please enter event name", "Event Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //    txtEventName.Focus();
                //    return;
                //}
                ds = new DataSet();
                sFlag = "SEARCH";
                sRetVal = ManageEventMaster(sFlag);
                //if (sRetVal == GlobalClass.SUCCESS)
                //{
                //    MessageBox.Show("Event Name Deleted successfully", "Event Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Event Master", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        public void  ClearForm()
        {
            txtEventName.Text="";
            dgEventMaster.DataSource=null;
        }
    }
}
