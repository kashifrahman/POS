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
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }
        SqlCommand cmd = new SqlCommand();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            try
            {
                string sflag;
                sflag = "LOADSECQUES";
                //lstDisplayUser.Items.Clear();
                SqlDataReader rdr;
                

                cmd = new SqlCommand();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_MaintainUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sflag.Length).Value = sflag.Trim();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbsecurityQues.Items.Add(rdr.GetString(0).ToString());
                }
                rdr.Close();
                rdr.Dispose();
                // this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtUserName.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Valid Username", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtUserName.Focus();
                    return;
                }
                if (txtPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Valid Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtPassword.Focus();
                    return;
                }
                if (txtConfirmPassWord.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Valid Confirmation Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtConfirmPassWord.Focus();
                    return;
                }
                if (txtPassword.Text.Trim()!=txtConfirmPassWord.Text.Trim())
                {
                    MessageBox.Show("Password does not match.Please enter same password at both boxes.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtPassword.Focus();
                    return;
                }
                if (cmbsecurityQues.Text=="")
                {
                    MessageBox.Show("Please select your security Question", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cmbsecurityQues.Focus();
                    return;
                }
                if (txtSecAns.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter your Security Answer", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtSecAns.Focus();
                    return;
                }
                string sflag,sResult;
                sflag = "CHANGEPSWD";
                cmd = new SqlCommand();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_MaintainUser";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sflag.Length).Value = sflag.Trim();
                cmd.Parameters.Add("@Username", SqlDbType.VarChar, txtUserName.Text.Length).Value = txtUserName.Text.Trim();
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, txtPassword.Text.Length).Value = txtPassword.Text.Trim();
                cmd.Parameters.Add("@SecurityQuestion", SqlDbType.VarChar, cmbsecurityQues.Text.Length).Value = cmbsecurityQues.Text;
                cmd.Parameters.Add("@SecurityAnswer", SqlDbType.VarChar, txtSecAns.Text.Length).Value = txtSecAns.Text.Trim();
                sResult = cmd.ExecuteScalar().ToString();
                MessageBox.Show(sResult, "Login", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //rdr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in change Password button1_Click:" + ex.Message.ToString());
            }
        }
    }
}
