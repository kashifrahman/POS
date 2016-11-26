using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;


namespace SalesPurchase
{
    public partial class frmCompanyMaster : Form
    {
        public frmCompanyMaster()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCompanyName.Text.Trim() == "")
                {
                    MessageBox.Show("Company Name is empty.Please Enter it.", "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtCompanyName.Focus();
                    return;
                }
                int iresult;
                string sresult;
                GlobalClass.gsFlag = "CHECK";
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_MaintainCompanyMaster";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, GlobalClass.gsFlag.Length).Value = GlobalClass.gsFlag;
                GlobalClass.cmd.Parameters.Add("@companyname", SqlDbType.VarChar, txtCompanyName.Text.Length).Value = txtCompanyName.Text;
                sresult = GlobalClass.cmd.ExecuteScalar().ToString();
                if (sresult!="0")
                {
                    MessageBox.Show("Company with this name already exists.Please change company name to proceed", "Company Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                
                GlobalClass.gsFlag = "ADD";
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_MaintainCompanyMaster";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, GlobalClass.gsFlag.Length).Value=GlobalClass.gsFlag;
                GlobalClass.cmd.Parameters.Add("@companyname", SqlDbType.VarChar, txtCompanyName.Text.Length).Value=txtCompanyName.Text;
                GlobalClass.cmd.Parameters.Add("@Activity", SqlDbType.VarChar, txtActivity.Text.Length).Value= txtActivity.Text;
                GlobalClass.cmd.Parameters.Add("@Tel1", SqlDbType.VarChar, txtTel1.Text.Length).Value= txtTel1.Text;
                GlobalClass.cmd.Parameters.Add("@tel2", SqlDbType.VarChar, txtTel2.Text.Length).Value= txtTel2.Text;
                GlobalClass.cmd.Parameters.Add("@fax", SqlDbType.VarChar, txtFax.Text.Length).Value= txtFax.Text;
                GlobalClass.cmd.Parameters.Add("@email", SqlDbType.VarChar, txtEmail.Text.Length).Value=txtEmail.Text;
                GlobalClass.cmd.Parameters.Add("@Address1", SqlDbType.VarChar, txtAddressLine1.Text.Length).Value=txtAddressLine1.Text;
                GlobalClass.cmd.Parameters.Add("@address2", SqlDbType.VarChar, txtAddressLine2.Text.Length).Value= txtAddressLine2.Text;
                GlobalClass.cmd.Parameters.Add("@city", SqlDbType.VarChar, cmbEmirate.SelectedText.Length).Value= cmbEmirate.Text.ToString();
                iresult=GlobalClass.cmd.ExecuteNonQuery();
                if (iresult ==1){
                    MessageBox.Show("Values added successfully", "Company Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ClearForm();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Company Master", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void frmCompanyMaster_Load(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader rdr;
                int i = 0;
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_FetchEmirateMaster";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                rdr = GlobalClass.cmd.ExecuteReader();

                while (rdr.Read())
                {
                    GlobalClass.EmirateArray[i] = rdr.GetString(0).ToString();
                    cmbEmirate.Items.Add(GlobalClass.EmirateArray[i].ToString());
                    ++i;
                //    rdr.Read();
                    
                }
                rdr.Dispose();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Company Master", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        public void ClearForm()
        {
            txtCompanyName.Text = "";
            txtAddressLine1.Text = "";
            txtActivity.Text = "";
            txtAddressLine2.Text = "";
            txtTel1.Text = "";
            txtTel2.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            dgCompanyMaster.DataSource = null;
            cmbEmirate.BringToFront();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                GlobalClass.gsFlag = "SEARCH";
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_MaintainCompanyMaster";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, GlobalClass.gsFlag.Length).Value = GlobalClass.gsFlag;
                GlobalClass.cmd.Parameters.Add("@companyname", SqlDbType.VarChar, txtCompanyName.Text.Length).Value = txtCompanyName.Text;
                GlobalClass.cmd.Parameters.Add("@Activity", SqlDbType.VarChar, txtActivity.Text.Length).Value = txtActivity.Text;
                GlobalClass.cmd.Parameters.Add("@Tel1", SqlDbType.VarChar, txtTel1.Text.Length).Value = txtTel1.Text;
                GlobalClass.cmd.Parameters.Add("@tel2", SqlDbType.VarChar, txtTel2.Text.Length).Value = txtTel2.Text;
                GlobalClass.cmd.Parameters.Add("@fax", SqlDbType.VarChar, txtFax.Text.Length).Value = txtFax.Text;
                GlobalClass.cmd.Parameters.Add("@email", SqlDbType.VarChar, txtEmail.Text.Length).Value = txtEmail.Text;
                GlobalClass.cmd.Parameters.Add("@Address1", SqlDbType.VarChar, txtAddressLine1.Text.Length).Value = txtAddressLine1.Text;
                GlobalClass.cmd.Parameters.Add("@address2", SqlDbType.VarChar, txtAddressLine2.Text.Length).Value = txtAddressLine2.Text;
                GlobalClass.cmd.Parameters.Add("@city", SqlDbType.VarChar, cmbEmirate.SelectedText.Length).Value = cmbEmirate.SelectedText;
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                dgCompanyMaster.DataSource = ds.Tables["Result"];

        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Company Master", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //prtDoc.Print();
                printDialog1.Document = prtDoc;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printPreviewDialog1.Document = prtDoc;
                    printPreviewDialog1.ShowDialog();
                    
                    prtDoc.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Company Master", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void prtDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawString("Company Name:" ,txtCompanyName.Font , Brushes.Black, 100, 40);
                e.Graphics.DrawString(txtCompanyName.Text, txtCompanyName.Font, Brushes.Black, 200, 40);

                e.Graphics.DrawString("Activity:", txtActivity.Font, Brushes.Black, 100, 60);
                e.Graphics.DrawString(txtActivity.Text, txtActivity.Font, Brushes.Black, 200, 60);

                e.Graphics.DrawString("Telephone 1:", txtTel1.Font, Brushes.Black, 100, 80);
                e.Graphics.DrawString(txtTel1.Text, txtTel1.Font, Brushes.Black, 200, 80);

                e.Graphics.DrawString("Telephone 2:", txtTel2.Font, Brushes.Black, 100, 100);
                e.Graphics.DrawString(txtTel2.Text, txtTel2.Font, Brushes.Black, 200, 100);

                e.Graphics.DrawString("Fax:", txtFax.Font, Brushes.Black, 100, 120);
                e.Graphics.DrawString(txtFax.Text, txtFax.Font, Brushes.Black, 200, 120);

                e.Graphics.DrawString("Email:", txtEmail.Font, Brushes.Black, 100, 140);
                e.Graphics.DrawString(txtEmail.Text, txtEmail.Font, Brushes.Black, 200, 140);

                e.Graphics.DrawString("Address Line 1:", txtAddressLine1.Font, Brushes.Black, 100, 160);
                e.Graphics.DrawString(txtAddressLine1.Text, txtAddressLine1.Font, Brushes.Black, 200, 160);

                e.Graphics.DrawString("Address Line 2:", txtAddressLine2.Font, Brushes.Black, 100, 180);
                e.Graphics.DrawString(txtAddressLine2.Text, txtAddressLine2.Font, Brushes.Black, 200, 180);

                e.Graphics.DrawString("Emirates:", cmbEmirate.Font, Brushes.Black, 100, 200);
                e.Graphics.DrawString(cmbEmirate.Text, txtAddressLine2.Font, Brushes.Black, 200, 200);

                e.Graphics.PageUnit = GraphicsUnit.Inch;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Company Master", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void dgCompanyMaster_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                i = dgCompanyMaster.CurrentCell.RowIndex;
                txtCompanyName.Text = dgCompanyMaster.Rows[i].Cells[0].Value.ToString();
                txtActivity.Text = dgCompanyMaster.Rows[i].Cells[1].Value.ToString();
                txtTel1.Text = dgCompanyMaster.Rows[i].Cells[2].Value.ToString();
                txtTel2.Text = dgCompanyMaster.Rows[i].Cells[3].Value.ToString();
                txtFax.Text = dgCompanyMaster.Rows[i].Cells[4].Value.ToString();
                txtEmail.Text = dgCompanyMaster.Rows[i].Cells[5].Value.ToString();
                txtAddressLine1.Text = dgCompanyMaster.Rows[i].Cells[6].Value.ToString();
                txtAddressLine2.Text = dgCompanyMaster.Rows[i].Cells[7].Value.ToString();
                cmbEmirate.Text = dgCompanyMaster.Rows[i].Cells[8].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Company Master", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void frmCompanyMaster_Shown(object sender, EventArgs e)
        {

        }

        }
    }
