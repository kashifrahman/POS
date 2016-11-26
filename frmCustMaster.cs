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
    public partial class frmCustMaster : Form
    {
        public frmCustMaster()
        {
            InitializeComponent();
        }
        string sflag;
        //string test;
        DataSet ds = new DataSet();

        private void btnclear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        public void ClearForm()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMobile.Text = "";
            txtLandLine.Text = "";
            txtPOBox.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            txtCity.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtFirstName.Focus();
            dgCustomerMaster.DataSource = null;
            txtCustomerCode.Text = "";
            dtPickerCustEvent.Text = "";
            //cmbEventName.SelectedIndex = 0;
            txtCustReligion.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFirstName.Text.Trim() == "")
                {
                    MessageBox.Show("Customer Name is empty" , "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtFirstName.Focus();
                    return;
                }
                //if (txtMobile.Text.Trim() == "")
                //{
                //    MessageBox.Show("Mobile No is empty", "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //    txtMobile.Focus();
                //    return;
                //}
                
                sflag = "ADD";
                string sResult;
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_MaintainCustomerMaster";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sflag.Length).Value = sflag.Trim();
                GlobalClass.cmd.Parameters.Add("@FName", SqlDbType.VarChar, txtFirstName.Text.Trim().Length).Value = txtFirstName.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@LName", SqlDbType.VarChar, txtLastName.Text.Trim().Length).Value = txtLastName.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Mobile", SqlDbType.VarChar, txtMobile.Text.Trim().Length).Value = txtMobile.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@LandLine", SqlDbType.VarChar, txtLandLine.Text.Trim().Length).Value = txtLandLine.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Fax", SqlDbType.VarChar, txtFax.Text.Trim().Length).Value = txtFax.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Email", SqlDbType.VarChar, txtEmail.Text.Trim().Length).Value = txtEmail.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Address1", SqlDbType.VarChar, txtAddress1.Text.Trim().Length).Value = txtAddress1.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Address2", SqlDbType.VarChar, txtAddress2.Text.Trim().Length).Value = txtAddress2.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@City", SqlDbType.VarChar, txtCity.Text.Trim().Length).Value = txtCity.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@POBox", SqlDbType.VarChar, txtPOBox.Text.Trim().Length).Value = txtPOBox.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@CustCode", SqlDbType.VarChar, txtFirstName.Text.Trim().Substring(0, 3).Length).Value = txtFirstName.Text.Substring(0, 3).Trim();
                GlobalClass.cmd.Parameters.Add("@EventName", SqlDbType.VarChar, cmbEventName.Text.Trim().Length).Value = cmbEventName.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@EventDate", SqlDbType.DateTime, dtPickerCustEvent.Value.ToString().Length).Value = dtPickerCustEvent.Value;
                GlobalClass.cmd.Parameters.Add("@Religion", SqlDbType.VarChar, txtCustReligion.Text.Length).Value = txtCustReligion.Text.Trim();
                sResult = GlobalClass.cmd.ExecuteScalar().ToString();
                if (sResult == "1")
                {
                    MessageBox.Show("Customer Details added successfully", "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ClearForm();
                    txtFirstName.Focus();
                }
                else
                {
                    MessageBox.Show(sResult, "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                sflag = "SEARCH";
                int iResult;
                GlobalClass.cmd = new SqlCommand();
                ds = new DataSet();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_MaintainCustomerMaster";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sflag.Length).Value = sflag.Trim();
                GlobalClass.cmd.Parameters.Add("@FName", SqlDbType.VarChar, txtFirstName.Text.Trim().Length).Value = txtFirstName.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@LName", SqlDbType.VarChar, txtLastName.Text.Trim().Length).Value = txtLastName.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Mobile", SqlDbType.VarChar, txtMobile.Text.Trim().Length).Value = txtMobile.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@LandLine", SqlDbType.VarChar, txtLandLine.Text.Trim().Length).Value = txtLandLine.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Fax", SqlDbType.VarChar, txtFax.Text.Trim().Length).Value = txtFax.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Email", SqlDbType.VarChar, txtEmail.Text.Trim().Length).Value = txtEmail.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Address1", SqlDbType.VarChar, txtAddress1.Text.Trim().Length).Value = txtAddress1.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Address2", SqlDbType.VarChar, txtAddress2.Text.Trim().Length).Value = txtAddress2.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@City", SqlDbType.VarChar, txtCity.Text.Trim().Length).Value = txtCity.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@POBox", SqlDbType.VarChar, txtPOBox.Text.Trim().Length).Value = txtPOBox.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@CustCode", SqlDbType.VarChar, txtFirstName.Text.Trim().Substring(0, 3).Length).Value = txtFirstName.Text.Substring(0, 3).Trim();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                dgCustomerMaster.DataSource = ds.Tables["Result"];
                if (ds.Tables["Result"].Rows.Count== 0)
                {
                    MessageBox.Show("No Customer Found for the searched criteria", "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ClearForm();
                    txtFirstName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgCustomerMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //txtFirstName.Text = dgCustomerMaster.Rows[1].Cells[0].Value.ToString();
                int i;
                i = dgCustomerMaster.CurrentCell.RowIndex;
                txtFirstName.Text = dgCustomerMaster.Rows[i].Cells["CustomerFirstName"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgCustomerMaster_Click(object sender, EventArgs e)
        {

            try
            {
                int i;
                GlobalClass.gbCustMasterDgClick = true;
                i = dgCustomerMaster.CurrentCell.RowIndex;
                txtCustomerCode.Text = dgCustomerMaster.Rows[i].Cells["CustomerCode"].Value.ToString();
                txtFirstName.Text = dgCustomerMaster.Rows[i].Cells["CustomerFirstName"].Value.ToString();
                txtLastName.Text = dgCustomerMaster.Rows[i].Cells["CustomerLastName"].Value.ToString();
                txtAddress1.Text = dgCustomerMaster.Rows[i].Cells["AddressLine1"].Value.ToString();
                txtAddress2.Text = dgCustomerMaster.Rows[i].Cells["AddressLine2"].Value.ToString();
                txtCity.Text = dgCustomerMaster.Rows[i].Cells["City"].Value.ToString();
                txtMobile.Text = dgCustomerMaster.Rows[i].Cells["MobilePhone"].Value.ToString();
                txtLandLine.Text = dgCustomerMaster.Rows[i].Cells["LandLinePhone"].Value.ToString();
                txtPOBox.Text = dgCustomerMaster.Rows[i].Cells["POBox"].Value.ToString();
                txtFax.Text = dgCustomerMaster.Rows[i].Cells["Fax"].Value.ToString();
                txtEmail.Text = dgCustomerMaster.Rows[i].Cells["Email"].Value.ToString();
                txtCustReligion.Text = dgCustomerMaster.Rows[i].Cells["Religion"].Value.ToString();
                cmbEventName.Text = dgCustomerMaster.Rows[i].Cells["EventName"].Value.ToString();
                dtPickerCustEvent.Text = dgCustomerMaster.Rows[i].Cells["EventDate"].Value.ToString();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

        }

        private void dgCustomerMaster_KeyDown(object sender, KeyEventArgs e)
        {

            int i;
            i = dgCustomerMaster.CurrentCell.RowIndex;
            txtCustomerCode.Text = dgCustomerMaster.Rows[i].Cells[0].Value.ToString();
            txtFirstName.Text = dgCustomerMaster.Rows[i].Cells[1].Value.ToString();
            txtLastName.Text = dgCustomerMaster.Rows[i].Cells[2].Value.ToString();
            txtAddress1.Text = dgCustomerMaster.Rows[i].Cells[3].Value.ToString();
            txtAddress2.Text = dgCustomerMaster.Rows[i].Cells[4].Value.ToString();
            txtCity.Text = dgCustomerMaster.Rows[i].Cells[5].Value.ToString();
            txtMobile.Text = dgCustomerMaster.Rows[i].Cells[6].Value.ToString();
            txtLandLine.Text = dgCustomerMaster.Rows[i].Cells[7].Value.ToString();
            txtPOBox.Text = dgCustomerMaster.Rows[i].Cells[9].Value.ToString();
            txtFax.Text = dgCustomerMaster.Rows[i].Cells[10].Value.ToString();
            txtEmail.Text = dgCustomerMaster.Rows[i].Cells[11].Value.ToString();
        }

        private void dgCustomerMaster_KeyUp(object sender, KeyEventArgs e)
        {

            int i;
            i = dgCustomerMaster.CurrentCell.RowIndex;
            txtCustomerCode.Text = dgCustomerMaster.Rows[i].Cells[0].Value.ToString();
            txtFirstName.Text = dgCustomerMaster.Rows[i].Cells[1].Value.ToString();
            txtLastName.Text = dgCustomerMaster.Rows[i].Cells[2].Value.ToString();
            txtAddress1.Text = dgCustomerMaster.Rows[i].Cells[3].Value.ToString();
            txtAddress2.Text = dgCustomerMaster.Rows[i].Cells[4].Value.ToString();
            txtCity.Text = dgCustomerMaster.Rows[i].Cells[5].Value.ToString();
            txtMobile.Text = dgCustomerMaster.Rows[i].Cells[6].Value.ToString();
            txtLandLine.Text = dgCustomerMaster.Rows[i].Cells[7].Value.ToString();
            txtPOBox.Text = dgCustomerMaster.Rows[i].Cells[9].Value.ToString();
            txtFax.Text = dgCustomerMaster.Rows[i].Cells[10].Value.ToString();
            txtEmail.Text = dgCustomerMaster.Rows[i].Cells[11].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!GlobalClass.gbCustMasterDgClick || dgCustomerMaster.Rows.Count == 0)
                {
                    MessageBox.Show("Please select Customer Details to Update !!!", "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                GlobalClass.gbCustMasterDgClick = false;
                sflag = "UPDATE";
                int iResult;
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_MaintainCustomerMaster";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sflag.Length).Value = sflag.Trim();
                GlobalClass.cmd.Parameters.Add("@FName", SqlDbType.VarChar, txtFirstName.Text.Trim().Length).Value = txtFirstName.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@LName", SqlDbType.VarChar, txtLastName.Text.Trim().Length).Value = txtLastName.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Mobile", SqlDbType.VarChar, txtMobile.Text.Trim().Length).Value = txtMobile.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@LandLine", SqlDbType.VarChar, txtLandLine.Text.Trim().Length).Value = txtLandLine.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Fax", SqlDbType.VarChar, txtFax.Text.Trim().Length).Value = txtFax.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Email", SqlDbType.VarChar, txtEmail.Text.Trim().Length).Value = txtEmail.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Address1", SqlDbType.VarChar, txtAddress1.Text.Trim().Length).Value = txtAddress1.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Address2", SqlDbType.VarChar, txtAddress2.Text.Trim().Length).Value = txtAddress2.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@City", SqlDbType.VarChar, txtCity.Text.Trim().Length).Value = txtCity.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@POBox", SqlDbType.VarChar, txtPOBox.Text.Trim().Length).Value = txtPOBox.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@CustCode", SqlDbType.VarChar, txtCustomerCode.Text.Length).Value = txtCustomerCode.Text.Trim();
                iResult = GlobalClass.cmd.ExecuteNonQuery();
                if (iResult >= 1)
                {
                    MessageBox.Show("Customer Details Updated successfully", "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ClearForm();
                    txtFirstName.Focus();
                    btnSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!GlobalClass.gbCustMasterDgClick || dgCustomerMaster.Rows.Count==0)
                {
                    MessageBox.Show("Please select Customer Details to Delete", "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    dgCustomerMaster.Focus();
                    return;
                }
                if (MessageBox.Show("Are you sure to Delete Customer Details", "Customer Master", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                {
                    return;
                }
                GlobalClass.gbCustMasterDgClick = false;
                sflag = "DELETE";
                int iResult;
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_MaintainCustomerMaster";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sflag.Length).Value = sflag.Trim();
                GlobalClass.cmd.Parameters.Add("@FName", SqlDbType.VarChar, txtFirstName.Text.Trim().Length).Value = txtFirstName.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@LName", SqlDbType.VarChar, txtLastName.Text.Trim().Length).Value = txtLastName.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Mobile", SqlDbType.VarChar, txtMobile.Text.Trim().Length).Value = txtMobile.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@LandLine", SqlDbType.VarChar, txtLandLine.Text.Trim().Length).Value = txtLandLine.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Fax", SqlDbType.VarChar, txtFax.Text.Trim().Length).Value = txtFax.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Email", SqlDbType.VarChar, txtEmail.Text.Trim().Length).Value = txtEmail.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Address1", SqlDbType.VarChar, txtAddress1.Text.Trim().Length).Value = txtAddress1.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Address2", SqlDbType.VarChar, txtAddress2.Text.Trim().Length).Value = txtAddress2.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@City", SqlDbType.VarChar, txtCity.Text.Trim().Length).Value = txtCity.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@POBox", SqlDbType.VarChar, txtPOBox.Text.Trim().Length).Value = txtPOBox.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@CustCode", SqlDbType.VarChar, txtCustomerCode.Text.Length).Value = txtCustomerCode.Text.Trim();
                iResult = GlobalClass.cmd.ExecuteNonQuery();
                if (iResult >= 1)
                {
                    MessageBox.Show("Customer Details Deleted successfully", "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ClearForm();
                    txtFirstName.Focus();
                    btnSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    sflag = "SEARCH";
            //    //int iResult;
            //    GlobalClass.cmd = new SqlCommand();
            //    ds = new DataSet();
            //    GlobalClass.cmd.Connection = GlobalClass.gCon;
            //    GlobalClass.cmd.CommandText = "SP_MaintainCustomerMaster";
            //    GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
            //    GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sflag.Length).Value = sflag.Trim();
            //    GlobalClass.cmd.Parameters.Add("@FName", SqlDbType.VarChar, txtFirstName.Text.Trim().Length).Value = txtFirstName.Text.Trim();
            //    GlobalClass.cmd.Parameters.Add("@LName", SqlDbType.VarChar, txtLastName.Text.Trim().Length).Value = txtLastName.Text.Trim();
            //    GlobalClass.cmd.Parameters.Add("@Mobile", SqlDbType.VarChar, txtMobile.Text.Trim().Length).Value = txtMobile.Text.Trim();
            //    GlobalClass.cmd.Parameters.Add("@LandLine", SqlDbType.VarChar, txtLandLine.Text.Trim().Length).Value = txtLandLine.Text.Trim();
            //    GlobalClass.cmd.Parameters.Add("@Fax", SqlDbType.VarChar, txtFax.Text.Trim().Length).Value = txtFax.Text.Trim();
            //    GlobalClass.cmd.Parameters.Add("@Email", SqlDbType.VarChar, txtEmail.Text.Trim().Length).Value = txtEmail.Text.Trim();
            //    GlobalClass.cmd.Parameters.Add("@Address1", SqlDbType.VarChar, txtAddress1.Text.Trim().Length).Value = txtAddress1.Text.Trim();
            //    GlobalClass.cmd.Parameters.Add("@Address2", SqlDbType.VarChar, txtAddress2.Text.Trim().Length).Value = txtAddress2.Text.Trim();
            //    GlobalClass.cmd.Parameters.Add("@City", SqlDbType.VarChar, txtCity.Text.Trim().Length).Value = txtCity.Text.Trim();
            //    GlobalClass.cmd.Parameters.Add("@POBox", SqlDbType.VarChar, txtPOBox.Text.Trim().Length).Value = txtPOBox.Text.Trim();
            //    //GlobalClass.cmd.Parameters.Add("@CustCode", SqlDbType.VarChar, txtFirstName.Text.Trim().Substring(0, 3).Length).Value = txtFirstName.Text.Substring(0, 3).Trim();
            //    ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
            //    dgCustomerMaster.DataSource = ds.Tables["Result"];
            //    //if (ds.Tables["Result"].Rows.Count == 0)
            //    //{
            //    //    MessageBox.Show("No Customer Found for the searched criteria", "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            //    //    ClearForm();
            //    //    txtFirstName.Focus();
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString(), "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            //}
            
        }

        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            txtFirstName.SelectAll();
        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {
            txtLastName.SelectAll();
        }

        private void txtMobile_Enter(object sender, EventArgs e)
        {
            txtMobile.SelectAll();
        }

        private void txtLandLine_Enter(object sender, EventArgs e)
        {
            txtLandLine.SelectAll();
        }

        private void txtFax_Enter(object sender, EventArgs e)
        {
            txtFax.SelectAll();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {

        }

        private void frmCustMaster_Load(object sender, EventArgs e)
        {
            GlobalClass.cmd = new SqlCommand();
            GlobalClass.cmd.Connection = GlobalClass.gCon;
            GlobalClass.cmd.CommandText = "SP_ManageEventMaster";
            GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
            GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10).Value = "SEARCH";
            ds = new DataSet();
            ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
            for (int i = 0; i < ds.Tables["Result"].Rows.Count; i++)
                cmbEventName.Items.Add(ds.Tables["Result"].Rows[i]["EventName"].ToString());
        }

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLastName.Focus();
                    }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtLastName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMobile.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtFax.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtFax_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLandLine.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtLandLine_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtEmail.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAddress1.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtAddress1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAddress2.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtAddress2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCity.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtCity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPOBox.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void frmCustMaster_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    frmSearchCustomer frm = new frmSearchCustomer();
                    frm.Show();
                }
            }
            catch (Exception Ex)
            {
            }
        }

    }
}
