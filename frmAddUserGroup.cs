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
    public partial class frmAddUserGroup : Form
    {
        public frmAddUserGroup()
        {
            InitializeComponent();
        }
        string sflag="";
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAddUsername.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter user name", "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtAddUsername.Focus();
                    return;
                }
                if (txtaddPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter Password", "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtaddPassword.Focus();
                    return;
                }
                if (txtAddConfirmPass.Text.Trim() == "")
                {
                    MessageBox.Show("Please Confirm Password", "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtAddConfirmPass.Focus();
                    return;
                }
                if (txtAddConfirmPass.Text.Trim() != txtaddPassword.Text.Trim())
                {
                    MessageBox.Show("Password does not match. Please enter same Password in both places.", "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtaddPassword.Focus();
                    return;
                }
                sflag = "ADD";
                ManageUser(sflag);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtAddConfirmPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Tab))
                {
                    if (txtaddPassword.Text.Trim() != txtAddConfirmPass.Text.Trim())
                    {
                        MessageBox.Show("Please Enter Same Password.Password Does not Match", "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        txtAddConfirmPass.SelectAll();
                        txtAddConfirmPass.Focus();
                        return;
                    }
                    btnAddUser.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void frmAddUserGroup_Load(object sender, EventArgs e)
        {
            
            
            txtAddUsername.Focus();
            sflag = "LOADSECQUES";
            //lstDisplayUser.Items.Clear();
            SqlDataReader newrdr;

            cmd = new SqlCommand();
            cmd.Connection = GlobalClass.gCon;
            cmd.CommandText = "SP_MaintainUser";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sflag.Length).Value = sflag.Trim();
            newrdr = cmd.ExecuteReader();
            while (newrdr.Read())
            {
                cmbSecurityQuestion.Items.Add(newrdr.GetString(0).ToString());
            }
            newrdr.Close();
            newrdr.Dispose();
        }
        public void ManageUser(string sFlag)
        {
            try
            {
                int iResult;
                cmd = new SqlCommand();   
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_MaintainUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag;
                cmd.Parameters.Add("@Username", SqlDbType.VarChar, txtAddUsername.Text.Length).Value = txtAddUsername.Text.Trim();
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, txtaddPassword.Text.Length).Value = txtaddPassword.Text.Trim();
                cmd.Parameters.Add("@SecurityQuestion", SqlDbType.VarChar, cmbSecurityQuestion.Text.Length).Value = cmbSecurityQuestion.Text.Trim();
                cmd.Parameters.Add("@SecurityAnswer", SqlDbType.VarChar, txtSecurityAns.Text.Length).Value = txtSecurityAns.Text.Trim();
                if (sFlag == "ADD" || sFlag == "UPDATE" || sFlag == "DELETE")
                {
                    iResult = cmd.ExecuteNonQuery();
                    if (iResult >= 1)
                    {
                        MessageBox.Show("User Details Updated Successfully", "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        //btnSearchUser_Click(sender, e);
                        Clearform();
                    }
                }
                else
                {
                    ds = new DataSet();
                    ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                    dgManageUser.DataSource = ds.Tables["Result"];
                }
                //Clearform();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                GlobalClass.WriteLog(ex.Message.ToString());
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAddUsername.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter user name", "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtAddUsername.Focus();
                    return;
                }
                if (MessageBox.Show("Are you sure to delete user", "User Deletion Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                {
                    return;
                }
                sflag = "DELETE";
                ManageUser(sflag);
            }
            catch (Exception ex)
            {
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAddUsername.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter user name", "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtAddUsername.Focus();
                    return;
                }
                if (txtaddPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter Password", "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtaddPassword.Focus();
                    return;
                }
                if (txtAddConfirmPass.Text.Trim() == "")
                {
                    MessageBox.Show("Please Confirm Password", "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtAddConfirmPass.Focus();
                    return;
                }

                sflag = "UPDATE";
                ManageUser(sflag);
            }
            catch (Exception ex)
            {
            }

        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {

            try
            {
                sflag = "SEARCH";
                ManageUser(sflag);
            }
            catch (Exception ex)
            {
            }
        }

        private void btnExitAddUser_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
        public void Clearform()
        {
            txtAddUsername.Text = "";
            txtaddPassword.Text = "";
            txtAddConfirmPass.Text = "";
            dgManageUser.DataSource = null;
            txtSecurityAns.Text = "";
            cmbSecurityQuestion.SelectedIndex = -1;
        }

        private void btnClearUser_Click(object sender, EventArgs e)
        {
            Clearform();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rbtnListUsers_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                sflag = "SEARCHUSER";
                lstDisplayUser.Items.Clear();
                SqlDataReader rdr;
                 
                 cmd = new SqlCommand();
                 cmd.Connection = GlobalClass.gCon;
                 cmd.CommandText = "SP_MaintainUser";
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sflag.Length).Value = sflag.Trim();
                 rdr=cmd.ExecuteReader();
                 while(rdr.Read())
                 {
                    lstDisplayUser.Items.Add(rdr.GetString(0).ToString());
                 }
                 rdr.Close();
                 rdr.Dispose();
            }
            catch (Exception ex)
            {
            }
        }

        private void rbtnListGroups_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                sflag = "SEARCHGROUP";
                SqlDataReader rdr;
                lstDisplayGroup.Items.Clear();
                cmd = new SqlCommand();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_MaintainUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sflag.Length).Value = sflag.Trim();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lstDisplayGroup.Items.Add(rdr.GetString(0).ToString());
                }
                rdr.Close();
                rdr.Dispose();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnaddgrouptouser_Click(object sender, EventArgs e)
        {
            try
            {
                lstDisplayAddGroups.Items.Add(lstDisplayGroup.SelectedItem.ToString());
                lstDisplayGroup.Items.Remove(lstDisplayGroup.SelectedItem.ToString());    

            }
            catch (Exception ex)
            {
            }
        }

        private void btnremovegroupfromuser_Click(object sender, EventArgs e)
        {
            try
            {
                lstDisplayGroup.Items.Add(lstDisplayAddGroups.SelectedItem.ToString());
                lstDisplayAddGroups.Items.Remove(lstDisplayAddGroups.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            string sReTval = "" ;
            try
            {
                int iResult;
                
                if (!GlobalClass.gbUserSelected)
                {
                    MessageBox.Show("Please Select User", "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (lstDisplayAddGroups.Items.Count == 0)
                {
                    MessageBox.Show("Please Select Groups", "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                for (int i = 0; i < lstDisplayAddGroups.Items.Count; i++)
                {
                    cmd = new SqlCommand();
                    cmd.Connection = GlobalClass.gCon;
                    cmd.CommandText = "SP_ManageGroup";
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10).Value = "RIGHTS";
                    cmd.Parameters.Add("@Groupname", SqlDbType.VarChar, lstDisplayAddGroups.Items[i].ToString().Length).Value = lstDisplayAddGroups.Items[i].ToString();
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, lstDisplayUser.SelectedItem.ToString().Length).Value = lstDisplayUser.SelectedItem.ToString();
                    sReTval = cmd.ExecuteScalar().ToString();
                    MessageBox.Show(sReTval, "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in btnDone_Click:" + ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void lstDisplayGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                lstDisplayAddGroups.Items.Add(lstDisplayGroup.SelectedItem.ToString());
                lstDisplayGroup.Items.Remove(lstDisplayGroup.SelectedItem.ToString());

            }
            catch (Exception ex)
            {
            }
        }

        private void lstDisplayAddGroups_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                lstDisplayGroup.Items.Add(lstDisplayAddGroups.SelectedItem.ToString());
                lstDisplayAddGroups.Items.Remove(lstDisplayAddGroups.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
            }
        }

        private void lstDisplayUser_Click(object sender, EventArgs e)
        {
            GlobalClass.gbUserSelected = true;
        }

        private void btnExitGroup_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
                try
                {
                    lstGrpDisplay.Items.Clear();
                    sflag = "SEARCHGROUP";
                    SqlDataReader rdr;
                    lstDisplayGroup.Items.Clear();
                    cmd = new SqlCommand();
                    cmd.Connection = GlobalClass.gCon;
                    cmd.CommandText = "SP_MaintainUser";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sflag.Length).Value = sflag.Trim();
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        lstGrpDisplay.Items.Add(rdr.GetString(0).ToString());
                    }
                    rdr.Close();
                    rdr.Dispose();
                }
                catch (Exception ex)
                {
                }
            
        }

        private void rbtnQueuedet_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lstQueueDetails.Items.Clear();
                sflag = "QUEUEDET";
                SqlDataReader rdr;
                lstDisplayGroup.Items.Clear();
                cmd = new SqlCommand();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_MaintainUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sflag.Length).Value = sflag.Trim();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lstQueueDetails.Items.Add(rdr.GetString(0).ToString());
                }
                rdr.Close();
                rdr.Dispose();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                lstSelectedQueues.Items.Add(lstQueueDetails.SelectedItem.ToString());
                lstQueueDetails.Items.Remove(lstQueueDetails.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void lstQueueDetails_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                lstSelectedQueues.Items.Add(lstQueueDetails.SelectedItem.ToString());
                lstQueueDetails.Items.Remove(lstQueueDetails.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
            }
        }

        private void lstSelectedQueues_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                lstQueueDetails.Items.Add(lstSelectedQueues.SelectedItem.ToString());
                lstSelectedQueues.Items.Remove(lstSelectedQueues.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                lstQueueDetails.Items.Add(lstSelectedQueues.SelectedItem.ToString());
                lstSelectedQueues.Items.Remove(lstSelectedQueues.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
            }
        }

        private void btnDoneGrpQueue_Click(object sender, EventArgs e)
        {
            string sReTval = "";
            try
            {
                for (int i = 0; i < lstSelectedQueues.Items.Count; i++)
                {
                    cmd = new SqlCommand();
                    cmd.Connection = GlobalClass.gCon;
                    cmd.CommandText = "SP_ManageGroupQueueRights";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 20).Value = "GROUPQUEUERIGHTS";
                    cmd.Parameters.Add("@Queuename", SqlDbType.VarChar, lstSelectedQueues.Items[i].ToString().Length).Value = lstSelectedQueues.Items[i].ToString();
                    cmd.Parameters.Add("@GroupName", SqlDbType.VarChar, lstGrpDisplay.SelectedItem.ToString().Length).Value = lstGrpDisplay.SelectedItem.ToString();
                    sReTval = cmd.ExecuteScalar().ToString();
                    MessageBox.Show(sReTval, "Group Queue Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in btnDoneGrpQueue_Click:"+ex.Message.ToString());
            }
        }

        private void lstDisplayUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dgManageUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                string sReTval="",sDialogueResult;
                if (!GlobalClass.gbUserSelected)
                {
                    MessageBox.Show("Please Select User", "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (lstDisplayAddGroups.Items.Count == 0)
                {
                    MessageBox.Show("Please Select Groups", "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (MessageBox.Show("Are you sure to remove user from selected group?", "User Master", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
                for (int i = 0; i < lstDisplayAddGroups.Items.Count; i++)
                {
                    cmd = new SqlCommand();
                    cmd.Connection = GlobalClass.gCon;
                    cmd.CommandText = "SP_ManageGroup";
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, "REMOVEUSERFROMGROUP".Length).Value = "REMOVEUSERFROMGROUP";
                    cmd.Parameters.Add("@Groupname", SqlDbType.VarChar, lstDisplayAddGroups.Items[i].ToString().Length).Value = lstDisplayAddGroups.Items[i].ToString();
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, lstDisplayUser.SelectedItem.ToString().Length).Value = lstDisplayUser.SelectedItem.ToString();
                    sReTval = cmd.ExecuteScalar().ToString();
                    MessageBox.Show(sReTval, "User Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void btnClearGroup_Click(object sender, EventArgs e)
        {
            txtGroupName.Text = "";
        }
    }
}
