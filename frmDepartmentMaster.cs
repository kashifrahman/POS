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
    public partial class frmDepartmentMaster : Form
    {
        public frmDepartmentMaster()
        {
            InitializeComponent();
        }
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        string sFlag,sRetVal;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDepttCode.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Department Code", "Department Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtDepttCode.Focus();
                    return;
                }
                if (txtDepttName.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Department Name", "Department Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtDepttName.Focus();
                    return;
                }
                sFlag = "SAVE";
                sRetVal = ManageDepartment(sFlag);

            }
            catch (Exception ex)
            {
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        public string ManageDepartment(string Flag)
        {
            try
            {
                string sRetVal;
                cmd = new SqlCommand();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_MaintainDepttMaster";
                cmd.CommandType = CommandType.StoredProcedure;
                if (Flag == "SAVE" || Flag=="UPDATE" || Flag=="DELETE")
                {
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                    cmd.Parameters.Add("@DepttCode", SqlDbType.VarChar, txtDepttCode.Text.Length).Value = txtDepttCode.Text.Trim();
                    cmd.Parameters.Add("@DepttName", SqlDbType.VarChar, txtDepttName.Text.Length).Value = txtDepttName.Text.Trim();
                    sRetVal=cmd.ExecuteScalar().ToString();
                    if (Flag == "SAVE" && sRetVal == "1")
                    {
                        MessageBox.Show("Department details Added successfully", "Department Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else if(Flag == "UPDATE" && sRetVal == "1")
                    {
                        MessageBox.Show("Department details Updated successfully", "Department Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else if (Flag == "DELETE" && sRetVal == "1")
                    {
                        MessageBox.Show("Department details Deleted successfully", "Department Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show(sRetVal, "Department Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }                    
                }
                if (Flag == "SEARCH")
                {
                    ds=new DataSet();
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                    cmd.Parameters.Add("@DepttCode", SqlDbType.VarChar, txtDepttCode.Text.Length).Value = txtDepttCode.Text.Trim();
                    cmd.Parameters.Add("@DepttName", SqlDbType.VarChar, txtDepttName.Text.Length).Value = txtDepttName.Text.Trim();
                    ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                    dgDepttMaster.DataSource = ds.Tables["Result"];
                }

                return GlobalClass.SUCCESS;
            }
            catch (Exception ex)
            {
                return GlobalClass.FAIL;
            }
        }

        private void btnDepttModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDepttCode.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Department Code", "Department Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtDepttCode.Focus();
                    return;
                }
                if (txtDepttName.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Department Name", "Department Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtDepttName.Focus();
                    return;
                }
                sFlag = "UPDATE";
                sRetVal = ManageDepartment(sFlag);

            }
            catch (Exception ex)
            {
            }
        }

        private void btnDepttDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDepttCode.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Department Code", "Department Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtDepttCode.Focus();
                    return;
                }
                if (txtDepttName.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Department Name", "Department Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtDepttName.Focus();
                    return;
                }
                sFlag = "DELETE";
                sRetVal = ManageDepartment(sFlag);

            }
            catch (Exception ex)
            {
            }
        }

        private void btnDepttSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txtDepttCode.Text.Trim() == "")
                //{
                //    MessageBox.Show("Please Enter Department Code", "Department Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //    txtDepttCode.Focus();
                //    return;
                //}
                //if (txtDepttName.Text.Trim() == "")
                //{
                //    MessageBox.Show("Please Enter Department Name", "Department Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //    txtDepttName.Focus();
                //    return;
                //}
                sFlag = "SEARCH";
                sRetVal = ManageDepartment(sFlag);

            }
            catch (Exception ex)
            {
            }
        }

        private void btnDepttClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void frmDepartmentMaster_Load(object sender, EventArgs e)
        {

        }
        public void ClearForm()
        {
            try
            {
                txtDepttCode.Text = "";
                txtDepttName.Text = "";
                dgDepttMaster.DataSource = null;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
