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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        SqlCommand cmd = new SqlCommand();

        private void button1_Click(object sender, EventArgs e)
        {
            
           if (txtUsername.Text.Trim()=="")
           {
               MessageBox.Show("Please Enter Valid Username","Login",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
               txtUsername.Focus();
               return;
           }
           if (txtPassword.Text.Trim() == "")
           {
               MessageBox.Show("Please Enter Valid Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
               txtPassword.Focus();
               return;
           }
            cmd = new SqlCommand();
            cmd.Connection = GlobalClass.gCon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_MaintainUser";
            cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10).Value = "AUTH";
            cmd.Parameters.Add("@Username", SqlDbType.VarChar, txtUsername.Text.Trim().Length).Value = txtUsername.Text.Trim();
            cmd.Parameters.Add("@Password", SqlDbType.VarChar, txtPassword.Text.Trim().Length).Value = txtPassword.Text.Trim();
            GlobalClass.gbValidateUser =Convert.ToBoolean(cmd.ExecuteScalar().ToString());
            GlobalClass.WriteLog("User Validated Flag:"+GlobalClass.gbValidateUser.ToString());
            if (!GlobalClass.gbValidateUser)
            {
                MessageBox.Show("Username/Password is not Correct", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cmd = null;
                txtUsername.Focus();
                return;
            }
           
           GlobalClass.gsLoggedInUser = txtUsername.Text.Trim();
           GlobalClass.WriteLog("Login SUccessful for user" + GlobalClass.gsLoggedInUser);
           GlobalClass.CaptureAuditTrail("LOGIN", "LOGIN", GlobalClass.gsLoggedInUser, "", "", "", "", "", "","");
           frmMain fr = new frmMain();
           fr.Show();
           this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            try
            {
                txtUsername.Focus();
                GlobalClass.lretval = GlobalClass.ReadConfigValues();
                GlobalClass.lretval = GlobalClass.ConnectToDB(GlobalClass.gsDBIP, GlobalClass.gsDBname, GlobalClass.gsDbUSer, GlobalClass.gsDBPassword);
               // lblLoggedinusername.Text = GlobalClass.gsLoggedInUser;
            }
            catch (Exception ex)
            {
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            txtUsername.SelectAll();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.SelectAll();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==Convert.ToChar(Keys.Enter))
            {
                button1_Click(sender, e);
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.SelectAll();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.Show();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }
    }
}
