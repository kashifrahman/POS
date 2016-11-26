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
    public partial class frmPurchaseMaster : Form
    {
        public frmPurchaseMaster()
        {
            InitializeComponent();
        }
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        string sFlag = "",sRetval="";

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPItemCode.Text == "")
            {
                MessageBox.Show("Item Code cannot be empty", "Purchase Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (txtPItemCode.Text == "")
            {
                MessageBox.Show("Item Name cannot be empty", "Purchase Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (txtItemUnitPrice.Text == "")
            {
                MessageBox.Show("Item Price cannot be empty", "Purchase Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            sFlag = "SAVE";
            sRetval = MaintainPurchaseMaster(sFlag);
            MessageBox.Show(sRetval, "Purchase Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

        }
        public string MaintainPurchaseMaster(string flag)
        {
            try
            {
                string sResSql;
                cmd = new SqlCommand();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_PurchaseMaster";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, flag.Length).Value = flag.Trim();
                if (flag == "SAVE" || flag=="UPDATE"|| flag=="DELETE")
                {
                    cmd.Parameters.Add("@PItemcode", SqlDbType.VarChar, txtPItemCode.Text.Length).Value = txtPItemCode.Text;
                    cmd.Parameters.Add("@PItemName", SqlDbType.VarChar, txtPItemName.Text.Length).Value = txtPItemName.Text;
                    if (txtItemUnitPrice.Text == "")
                    {
                        txtItemUnitPrice.Text = "0.00";
                    }
                    cmd.Parameters.Add("@PItemUnitPrice", SqlDbType.Decimal, txtItemUnitPrice.Text.Length).Value = txtItemUnitPrice.Text;
                    cmd.Parameters.Add("@PUnitType", SqlDbType.VarChar, cmbUnits.Text.Length).Value = cmbUnits.Text;
                    sResSql= cmd.ExecuteScalar().ToString();
                    return sResSql;
                }
                if (flag == "SEARCH")
                {
                    if (txtItemUnitPrice.Text == "")
                    {
                        txtItemUnitPrice.Text = "0.00";
                    }
                    cmd.Parameters.Add("@PItemcode", SqlDbType.VarChar, txtPItemCode.Text.Length).Value = txtPItemCode.Text;
                    cmd.Parameters.Add("@PItemName", SqlDbType.VarChar, txtPItemName.Text.Length).Value = txtPItemName.Text;
                    cmd.Parameters.Add("@PItemUnitPrice", SqlDbType.Decimal, txtItemUnitPrice.Text.Length).Value = txtItemUnitPrice.Text;
                    cmd.Parameters.Add("@PUnitType", SqlDbType.VarChar, cmbUnits.Text.Length).Value = cmbUnits.Text;
                    ds = new DataSet();
                    ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                    dgPurchaseMaster.DataSource = ds.Tables["Result"];
                    return GlobalClass.SUCCESS;
                }

                return GlobalClass.SUCCESS;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                GlobalClass.WriteLog(ex.Message.ToString());
                return GlobalClass.FAIL;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtPItemCode.Text == "")
            {
                MessageBox.Show("Item Code cannot be empty", "Purchase Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            sFlag = "DELETE";
            sRetval = MaintainPurchaseMaster(sFlag);
            MessageBox.Show(sRetval, "Purchase Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (txtPItemCode.Text == "")
            {
                MessageBox.Show("Item Code cannot be empty", "Purchase Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (txtPItemCode.Text == "")
            {
                MessageBox.Show("Item Name cannot be empty", "Purchase Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            if (txtItemUnitPrice.Text == "")
            {
                MessageBox.Show("Item Price cannot be empty", "Purchase Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            sFlag = "UPDATE";
            sRetval = MaintainPurchaseMaster(sFlag);
            MessageBox.Show(sRetval, "Purchase Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            sFlag = "SEARCH";
            sRetval = MaintainPurchaseMaster(sFlag);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearform();
        }
        public void  clearform()
        {
            try
            {
                txtItemUnitPrice.Text = "";
                txtPItemCode.Text = "";
                txtPItemName.Text = "";
                cmbUnits.SelectedIndex = -1;
                dgPurchaseMaster.DataSource = null;
            }
            catch (Exception ex)
            {
            }
        }

        private void frmPurchaseMaster_Load(object sender, EventArgs e)
        {
            try
            {
                cmbUnits.Items.Add("Kilogram");
                cmbUnits.Items.Add("Litre");
            }
            catch (Exception ex)
            {
            }
        }
    }
}
