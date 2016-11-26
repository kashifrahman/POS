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
    public partial class frmEmployeeMaster : Form
    {
        public frmEmployeeMaster()
        {
            InitializeComponent();
        }
        string sFlag;
        int iResult;
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();

        private void txtNationality_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmpName.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Employee Name", "Employee Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtEmpName.Focus();
                    return;
                }
                if (txtEmpDesignation.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Employee Designation", "Employee Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtEmpDesignation.Focus();
                    return;
                }

                
                sFlag = "ADD";
                string sResult;
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_MaintainEmployeeMaster";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                GlobalClass.cmd.Parameters.Add("@EmpName", SqlDbType.VarChar, txtEmpName.Text.Trim().Length).Value = txtEmpName.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@EmpDesig", SqlDbType.VarChar, txtEmpDesignation.Text.Trim().Length).Value = txtEmpDesignation.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@EmpDept", SqlDbType.VarChar, cmbEmpDept.Text.Trim().Length).Value = cmbEmpDept.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@EmpAddress", SqlDbType.VarChar, txtEmpAddress.Text.Trim().Length).Value = txtEmpAddress.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Nationality", SqlDbType.VarChar, txtNationality.Text.Trim().Length).Value = txtNationality.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@MobileNo", SqlDbType.VarChar, txtEmpMobNo.Text.Trim().Length).Value = txtEmpMobNo.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@Address1", SqlDbType.VarChar, txtAddress1.Text.Trim().Length).Value = txtAddress1.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@Address2", SqlDbType.VarChar, txtAddress2.Text.Trim().Length).Value = txtAddress2.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@City", SqlDbType.VarChar, txtCity.Text.Trim().Length).Value = txtCity.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@POBox", SqlDbType.VarChar, txtPOBox.Text.Trim().Length).Value = txtPOBox.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@CustCode", SqlDbType.VarChar, txtFirstName.Text.Trim().Substring(0, 3).Length).Value = txtFirstName.Text.Substring(0, 3).Trim();
                sResult = GlobalClass.cmd.ExecuteScalar().ToString();
                //if (iResult == 1)
                //{
                MessageBox.Show(sResult, "Employee Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                ClearForm();
                txtEmpName.Focus();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Employee Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    
            }
        }
        public void ClearForm()
        {
            txtEmpName.Text = "";
            txtEmpDept.Text = "";
            txtEmpDesignation.Text = "";
            txtEmpMobNo.Text = "";
            txtEmpAddress.Text = "";
            txtNationality.Text = "";
            dgEmpMaster.DataSource=null;
            txtEmployeeCode.Text = "";
            cmbEmpDept.SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearForm();
            }
            catch (Exception Ex)
            {
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmpName.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Employee Name", "Employee Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtEmpName.Focus();
                    return;
                }
                if (txtEmpDesignation.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Employee Designation", "Employee Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtEmpDesignation.Focus();
                    return;
                }


                sFlag = "UPDATE";
                //int iResult;
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_MaintainEmployeeMaster";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                GlobalClass.cmd.Parameters.Add("@EmpName", SqlDbType.VarChar, txtEmpName.Text.Trim().Length).Value = txtEmpName.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@EmpDesig", SqlDbType.VarChar, txtEmpDesignation.Text.Trim().Length).Value = txtEmpDesignation.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@EmpDept", SqlDbType.VarChar, cmbEmpDept.Text.Trim().Length).Value = cmbEmpDept.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@EmpAddress", SqlDbType.VarChar, txtEmpAddress.Text.Trim().Length).Value = txtEmpAddress.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Nationality", SqlDbType.VarChar, txtNationality.Text.Trim().Length).Value = txtNationality.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@MobileNo", SqlDbType.VarChar, txtEmpMobNo.Text.Trim().Length).Value = txtEmpMobNo.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Empid", SqlDbType.VarChar, txtEmployeeCode.Text.Trim().Length).Value = txtEmployeeCode.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@Address1", SqlDbType.VarChar, txtAddress1.Text.Trim().Length).Value = txtAddress1.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@Address2", SqlDbType.VarChar, txtAddress2.Text.Trim().Length).Value = txtAddress2.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@City", SqlDbType.VarChar, txtCity.Text.Trim().Length).Value = txtCity.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@POBox", SqlDbType.VarChar, txtPOBox.Text.Trim().Length).Value = txtPOBox.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@CustCode", SqlDbType.VarChar, txtFirstName.Text.Trim().Substring(0, 3).Length).Value = txtFirstName.Text.Substring(0, 3).Trim();
                iResult = GlobalClass.cmd.ExecuteNonQuery();
                if (iResult >= 1)
                {
                    MessageBox.Show("Employee Details updated successfully", "Employee Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ClearForm();
                    txtEmpName.Focus();
                    Search_Click(sender,e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Employee Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmpName.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Employee Name", "Employee Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (txtEmpDesignation.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Employee Designation", "Employee Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (MessageBox.Show("Are you sure to delete Employee Details", "Employee Master", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                {
                    return;
                }

                sFlag = "DELETE";
                //int iResult;
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_MaintainEmployeeMaster";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                GlobalClass.cmd.Parameters.Add("@EmpName", SqlDbType.VarChar, txtEmpName.Text.Trim().Length).Value = txtEmpName.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@EmpDesig", SqlDbType.VarChar, txtEmpDesignation.Text.Trim().Length).Value = txtEmpDesignation.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@EmpDept", SqlDbType.VarChar, cmbEmpDept.Text.Trim().Length).Value = cmbEmpDept.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@EmpAddress", SqlDbType.VarChar, txtEmpAddress.Text.Trim().Length).Value = txtEmpAddress.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Nationality", SqlDbType.VarChar, txtNationality.Text.Trim().Length).Value = txtNationality.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@MobileNo", SqlDbType.VarChar, txtEmpMobNo.Text.Trim().Length).Value = txtEmpMobNo.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Empid", SqlDbType.VarChar, txtEmployeeCode.Text.Trim().Length).Value = txtEmployeeCode.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@Address1", SqlDbType.VarChar, txtAddress1.Text.Trim().Length).Value = txtAddress1.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@Address2", SqlDbType.VarChar, txtAddress2.Text.Trim().Length).Value = txtAddress2.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@City", SqlDbType.VarChar, txtCity.Text.Trim().Length).Value = txtCity.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@POBox", SqlDbType.VarChar, txtPOBox.Text.Trim().Length).Value = txtPOBox.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@CustCode", SqlDbType.VarChar, txtFirstName.Text.Trim().Substring(0, 3).Length).Value = txtFirstName.Text.Substring(0, 3).Trim();
                iResult = GlobalClass.cmd.ExecuteNonQuery();
                if (iResult >= 1)
                {
                    MessageBox.Show("Employee Details deleted successfully", "Employee Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ClearForm();
                    txtEmpName.Focus();
                    Search_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Employee Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                KeyEventArgs ke = e as KeyEventArgs;
                dgEmpMaster_KeyDown(sender,ke);
            }
            catch (Exception ex)
            {
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                sFlag = "SEARCH";
                ds = new DataSet();
                //int iResult;
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_MaintainEmployeeMaster";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                GlobalClass.cmd.Parameters.Add("@EmpName", SqlDbType.VarChar, txtEmpName.Text.Trim().Length).Value = txtEmpName.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@EmpDesig", SqlDbType.VarChar, txtEmpDesignation.Text.Trim().Length).Value = txtEmpDesignation.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@EmpDept", SqlDbType.VarChar, cmbEmpDept.Text.Trim().Length).Value = cmbEmpDept.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@EmpAddress", SqlDbType.VarChar, txtEmpAddress.Text.Trim().Length).Value = txtEmpAddress.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@Nationality", SqlDbType.VarChar, txtNationality.Text.Trim().Length).Value = txtNationality.Text.Trim();
                GlobalClass.cmd.Parameters.Add("@MobileNo", SqlDbType.VarChar, txtEmpMobNo.Text.Trim().Length).Value = txtEmpMobNo.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@Address1", SqlDbType.VarChar, txtAddress1.Text.Trim().Length).Value = txtAddress1.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@Address2", SqlDbType.VarChar, txtAddress2.Text.Trim().Length).Value = txtAddress2.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@City", SqlDbType.VarChar, txtCity.Text.Trim().Length).Value = txtCity.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@POBox", SqlDbType.VarChar, txtPOBox.Text.Trim().Length).Value = txtPOBox.Text.Trim();
                //GlobalClass.cmd.Parameters.Add("@CustCode", SqlDbType.VarChar, txtFirstName.Text.Trim().Substring(0, 3).Length).Value = txtFirstName.Text.Substring(0, 3).Trim();
                //iResult = GlobalClass.cmd.ExecuteNonQuery();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                if (ds.Tables["Result"].Rows.Count==0)
                {
                    MessageBox.Show("No records found for searched criteria", "Employee Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ClearForm();
                    txtEmpName.Focus();
                }
                //MessageBox.Show(ds.Tables["Result"].Rows.Count.ToString()+" Records found", "Employee Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                dgEmpMaster.DataSource = ds.Tables["Result"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Employee Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                ClearForm();
                txtEmpName.Focus();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtEmpAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgEmpMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgEmpMaster_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                i = dgEmpMaster.CurrentCell.RowIndex;
                txtEmployeeCode.Text = dgEmpMaster.Rows[i].Cells[0].Value.ToString();
                txtEmpName.Text = dgEmpMaster.Rows[i].Cells[1].Value.ToString();
                txtEmpDesignation.Text = dgEmpMaster.Rows[i].Cells[2].Value.ToString();
                txtEmpDept.Text = dgEmpMaster.Rows[i].Cells[3].Value.ToString();
                txtEmpAddress.Text = dgEmpMaster.Rows[i].Cells[4].Value.ToString();
                txtNationality.Text = dgEmpMaster.Rows[i].Cells[5].Value.ToString();
                txtEmpMobNo.Text = dgEmpMaster.Rows[i].Cells[6].Value.ToString();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "Employee Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    
            }
        }

        private void dgEmpMaster_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int i;
                i = dgEmpMaster.CurrentCell.RowIndex;
                txtEmployeeCode.Text = dgEmpMaster.Rows[i].Cells[0].Value.ToString();
                txtEmpName.Text = dgEmpMaster.Rows[i].Cells[1].Value.ToString();
                txtEmpDesignation.Text = dgEmpMaster.Rows[i].Cells[2].Value.ToString();
                txtEmpDept.Text = dgEmpMaster.Rows[i].Cells[3].Value.ToString();
                txtEmpAddress.Text = dgEmpMaster.Rows[i].Cells[4].Value.ToString();
                txtNationality.Text = dgEmpMaster.Rows[i].Cells[5].Value.ToString();
                txtEmpMobNo.Text = dgEmpMaster.Rows[i].Cells[6].Value.ToString();
            }
            catch (Exception Ex)
            {
            }
        }

        private void dgEmpMaster_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int i;
                i = dgEmpMaster.CurrentCell.RowIndex;
                txtEmployeeCode.Text = dgEmpMaster.Rows[i].Cells[0].Value.ToString();
                txtEmpName.Text = dgEmpMaster.Rows[i].Cells[1].Value.ToString();
                txtEmpDesignation.Text = dgEmpMaster.Rows[i].Cells[2].Value.ToString();
                cmbEmpDept.Text = dgEmpMaster.Rows[i].Cells[3].Value.ToString();
                txtEmpAddress.Text = dgEmpMaster.Rows[i].Cells[4].Value.ToString();
                txtNationality.Text = dgEmpMaster.Rows[i].Cells[5].Value.ToString();
                txtEmpMobNo.Text = dgEmpMaster.Rows[i].Cells[6].Value.ToString();
            }
            catch (Exception Ex)
            {
            }
        }

        private void frmEmployeeMaster_Load(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.CommandText = "SP_MaintainEmployeeMaster";
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10).Value = "LOAD";
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                for (int i = 0; i < ds.Tables["Result"].Rows.Count; i++)
                {
                        cmbEmpDept.Items.Add(ds.Tables["Result"].Rows[i]["Department"].ToString());
                }

                cmbEmpDept.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
            }
        }
    }
}
