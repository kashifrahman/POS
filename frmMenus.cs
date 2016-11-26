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
    public partial class frmMenus : Form
    {
        public frmMenus()
        {
            InitializeComponent();
        }
        string sFlag,sItemId;
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();

        private void button1_Click(object sender, EventArgs e)
        {
            try            
            {
                if (txtItemCode.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Item Code", "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtItemCode.Focus();
                    return;

                }
                if (txtItemName.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Item Name !!!", "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtItemName.Focus();
                    return;
                }
                if (txtUnitPrice.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Item Unit Price !!!", "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtUnitPrice.Focus();
                    return;
                }

                string sResult;
                sFlag = "ADD";
                cmd = new SqlCommand();
                cmd.CommandText = "SP_MaintainMenu";
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                cmd.Parameters.Add("@ItemCode", SqlDbType.VarChar, txtItemCode.Text.Length).Value = txtItemCode.Text.Trim();
                cmd.Parameters.Add("@ItemName", SqlDbType.VarChar, txtItemName.Text.Length).Value = txtItemName.Text.Trim();
                cmd.Parameters.Add("@MainGroup", SqlDbType.VarChar,cmbGroup.Text.Length).Value = cmbGroup.Text.Trim();
                cmd.Parameters.Add("@ItemType", SqlDbType.VarChar, cmbItemType.Text.Length).Value = cmbItemType.Text.Trim();
                cmd.Parameters.Add("@UnitPrice", SqlDbType.VarChar, txtUnitPrice.Text.Length).Value = txtUnitPrice.Text.Trim();
                cmd.Parameters.Add("@ItemCategory", SqlDbType.VarChar, cmbItemCategory.Text.Length).Value = cmbItemCategory.Text.Trim();
                if (chbPromotionalItem.Checked == true)
                {
                    txtPromotionalItem.Text = "True";

                }
                else
                {
                    txtPromotionalItem.Text = "False";
                }
                cmd.Parameters.Add("@PromoItem", SqlDbType.VarChar, txtPromotionalItem.Text.Length).Value = txtPromotionalItem.Text.Trim();
                sResult  = cmd.ExecuteScalar().ToString();
                if (sResult == "1")
                {
                    MessageBox.Show("Menu Item added successfully", "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    //btnMenuSearch_Click(sender, e);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show(sResult, "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmMenus_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds=new DataSet();
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.CommandText = "SP_FetchItemCategory";
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "ItemCategory");
                for (int i = 0; i < ds.Tables["Itemcategory"].Rows.Count; i++)
                {
                    if (ds.Tables["Itemcategory"].Rows[i]["Type"].ToString().ToUpper()=="CATEGORY")
                        cmbItemCategory.Items.Add(ds.Tables["itemcategory"].Rows[i]["itemcategory"].ToString());
                    if (ds.Tables["Itemcategory"].Rows[i]["Type"].ToString().ToUpper() == "ITEMTYPE")
                        cmbItemType.Items.Add(ds.Tables["Itemcategory"].Rows[i]["itemcategory"].ToString());
                    if (ds.Tables["Itemcategory"].Rows[i]["Type"].ToString().ToUpper()=="MAINGROUP")
                        cmbGroup.Items.Add(ds.Tables["Itemcategory"].Rows[i]["itemcategory"].ToString());
                }   

                cmbItemCategory.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message.ToString(), "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void cmbItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMenuSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int iResult;
                sFlag = "SEARCH";
                cmd = new SqlCommand();
                ds = new DataSet();
                cmd.CommandText = "SP_MaintainMenu";
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                cmd.Parameters.Add("@ItemCode", SqlDbType.VarChar, txtItemCode.Text.Length).Value = txtItemCode.Text.Trim();
                cmd.Parameters.Add("@ItemName", SqlDbType.VarChar, txtItemName.Text.Length).Value = txtItemName.Text.Trim();
                cmd.Parameters.Add("@MainGroup", SqlDbType.VarChar, cmbGroup.Text.Length).Value = cmbGroup.Text.Trim();
                cmd.Parameters.Add("@ItemType", SqlDbType.VarChar, cmbItemType.Text.Length).Value = cmbItemType.Text.Trim();
                cmd.Parameters.Add("@UnitPrice", SqlDbType.VarChar, txtUnitPrice.Text.Length).Value = txtUnitPrice.Text.Trim();
                cmd.Parameters.Add("@ItemCategory", SqlDbType.VarChar, cmbItemCategory.Text.Length).Value = cmbItemCategory.Text.Trim();
                cmd.Parameters.Add("@PromoItem", SqlDbType.VarChar, txtPromotionalItem.Text.Length).Value = txtPromotionalItem.Text.Trim();
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                if (ds.Tables["Result"].Rows.Count == 0)
                {
                    MessageBox.Show("No Menu Items found for serached criteria", "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                //MessageBox.Show(ds.Tables["Result"].Rows.Count.ToString()+" Menu Items found", "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                dgMenuItems.DataSource = ds.Tables["Result"];
                dgMenuItems.Focus();    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!GlobalClass.gbMenudgClick)
                {
                    MessageBox.Show("Please select Menu Item to Delete", "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (MessageBox.Show("Are you sure to delete this menu Item", "Menu Master", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                {
                    return;
                }

                int iResult;
                sFlag = "DELETE";
                cmd = new SqlCommand();
                ds = new DataSet();
                cmd.CommandText = "SP_MaintainMenu";
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                cmd.Parameters.Add("@ItemCode", SqlDbType.VarChar, txtItemCode.Text.Length).Value = txtItemCode.Text.Trim();
                cmd.Parameters.Add("@ItemName", SqlDbType.VarChar, txtItemName.Text.Length).Value = txtItemName.Text.Trim();
                cmd.Parameters.Add("@MainGroup", SqlDbType.VarChar, cmbGroup.Text.Length).Value = cmbGroup.Text.Trim();
                cmd.Parameters.Add("@ItemType", SqlDbType.VarChar, cmbItemType.Text.Length).Value = cmbItemType.Text.Trim();
                cmd.Parameters.Add("@UnitPrice", SqlDbType.VarChar, txtUnitPrice.Text.Length).Value = txtUnitPrice.Text.Trim();
                cmd.Parameters.Add("@ItemCategory", SqlDbType.VarChar, cmbItemCategory.Text.Length).Value = cmbItemCategory.Text.Trim();
                if (chbPromotionalItem.Checked == true)
                {
                    txtPromotionalItem.Text = "True";

                }
                else
                {
                    txtPromotionalItem.Text = "False";
                }
                cmd.Parameters.Add("@PromoItem", SqlDbType.VarChar, txtPromotionalItem.Text.Length).Value = txtPromotionalItem.Text.Trim();
                cmd.Parameters.Add("@ItemID", SqlDbType.VarChar, sItemId.Length).Value = sItemId.Trim();
                iResult = cmd.ExecuteNonQuery();
                if (iResult == 1)
                {
                    MessageBox.Show("Menu Item Deleted successfully", "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ClearForm();

                }
                GlobalClass.gbMenudgClick = false;
                btnMenuSearch_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgMenuItems_Click(object sender, EventArgs e)
        {
            int i;
            try
            {
                GlobalClass.gbMenudgClick = true;
                i = dgMenuItems.CurrentCell.RowIndex;
                sItemId = dgMenuItems.Rows[i].Cells["Itemid"].Value.ToString().Trim();
                txtItemName.Text = dgMenuItems.Rows[i].Cells["ItemName"].Value.ToString().Trim();
                txtUnitPrice.Text = dgMenuItems.Rows[i].Cells["ItemPrice"].Value.ToString().Trim();
                txtItemCode.Text = dgMenuItems.Rows[i].Cells["ItemCode"].Value.ToString().Trim();
                cmbGroup.Text=dgMenuItems.Rows[i].Cells["Maingroup"].Value.ToString().Trim();
                cmbItemType.Text = dgMenuItems.Rows[i].Cells["ItemType"].Value.ToString().Trim();
                cmbItemCategory.Text = dgMenuItems.Rows[i].Cells["ItemCategory"].Value.ToString().Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

        }

        private void btnMenuClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearForm();
                //MessageBox.Show("Page Cleared", "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtItemName.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgMenuItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMenuModify_Click(object sender, EventArgs e)
        {
            try
            {

                if (!GlobalClass.gbMenudgClick)
                {
                    MessageBox.Show("Please select Menu Item to Update", "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    dgMenuItems.Focus();
                    return;
                }
                int iResult;
                sFlag = "UPDATE";
                cmd = new SqlCommand();
                ds = new DataSet();
                cmd.CommandText = "SP_MaintainMenu";
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                cmd.Parameters.Add("@ItemCode", SqlDbType.VarChar, txtItemCode.Text.Length).Value = txtItemCode.Text.Trim();
                cmd.Parameters.Add("@ItemName", SqlDbType.VarChar, txtItemName.Text.Length).Value = txtItemName.Text.Trim();
                cmd.Parameters.Add("@MainGroup", SqlDbType.VarChar, cmbGroup.Text.Length).Value = cmbGroup.Text.Trim();
                cmd.Parameters.Add("@ItemType", SqlDbType.VarChar, cmbItemType.Text.Length).Value = cmbItemType.Text.Trim();
                cmd.Parameters.Add("@UnitPrice", SqlDbType.VarChar, txtUnitPrice.Text.Length).Value = txtUnitPrice.Text.Trim();
                cmd.Parameters.Add("@ItemCategory", SqlDbType.VarChar, cmbItemCategory.Text.Length).Value = cmbItemCategory.Text.Trim();
                if (chbPromotionalItem.Checked == true)
                {
                    txtPromotionalItem.Text = "True";
                }
                else
                {
                    txtPromotionalItem.Text = "False";
                }
                cmd.Parameters.Add("@PromoItem", SqlDbType.VarChar, txtPromotionalItem.Text.Length).Value = txtPromotionalItem.Text.Trim();
                cmd.Parameters.Add("@ItemID", SqlDbType.VarChar, sItemId.Length).Value = sItemId.Trim();
                iResult = cmd.ExecuteNonQuery();
                if (iResult == 1)
                {
                    MessageBox.Show("Menu Item Updated successfully", "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ClearForm();

                }
                GlobalClass.gbMenudgClick = false;
                btnMenuSearch_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        public void ClearForm()
        {
            try
            {
                txtItemCode.Focus();
                txtItemCode.Text = "";
                txtItemName.Text = "";
                txtPromotionalItem.Text = "";
                txtUnitPrice.Text = "";
                dgMenuItems.DataSource = null;
                cmbGroup.SelectedIndex = -1;
                cmbItemCategory.SelectedIndex = -1;
                cmbItemType.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Menu Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtItemCode_Enter(object sender, EventArgs e)
        {
            txtItemCode.SelectAll();
        }

        private void txtItemName_Enter(object sender, EventArgs e)
        {
            txtItemName.SelectAll();
        }

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Boolean bflag;
                if (e.KeyCode == Keys.Enter)
                {
                    
                    sFlag = "CHECKITEMCODE";
                    cmd = new SqlCommand();
                    cmd.CommandText = "SP_MaintainMenu";
                    cmd.Connection = GlobalClass.gCon;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                    cmd.Parameters.Add("@ItemCode", SqlDbType.VarChar, txtItemCode.Text.Length).Value = txtItemCode.Text.Trim();
                    //cmd.Parameters.Add("@ItemName", SqlDbType.VarChar, txtItemName.Text.Length).Value = txtItemName.Text.Trim();
                    //cmd.Parameters.Add("@MainGroup", SqlDbType.VarChar,cmbGroup.Text.Length).Value = cmbGroup.Text.Trim();
                    //cmd.Parameters.Add("@ItemType", SqlDbType.VarChar, cmbItemType.Text.Length).Value = cmbItemType.Text.Trim();
                    //cmd.Parameters.Add("@UnitPrice", SqlDbType.VarChar, txtUnitPrice.Text.Length).Value = txtUnitPrice.Text.Trim();
                    //cmd.Parameters.Add("@ItemCategory", SqlDbType.VarChar, cmbItemCategory.Text.Length).Value = cmbItemCategory.Text.Trim();
                    //cmd.Parameters.Add("@PromoItem", SqlDbType.VarChar, txtPromotionalItem.Text.Length).Value = txtPromotionalItem.Text.Trim();
                    bflag = Convert.ToBoolean(cmd.ExecuteScalar().ToString());
                    if (bflag)
                    {
                        MessageBox.Show("This Item Code Already exists.", "Product Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    txtItemName.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cmbGroup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbItemCategory.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cmbItemCategory_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbItemType.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cmbItemType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtUnitPrice.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtUnitPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnAdd.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    Boolean bflag;
            //    sFlag = "CHECKITEMCODE";
            //    cmd = new SqlCommand();
            //    cmd.CommandText = "SP_MaintainMenu";
            //    cmd.Connection = GlobalClass.gCon;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
            //    cmd.Parameters.Add("@ItemCode", SqlDbType.VarChar, txtItemCode.Text.Length).Value = txtItemCode.Text.Trim();
            //    //cmd.Parameters.Add("@ItemName", SqlDbType.VarChar, txtItemName.Text.Length).Value = txtItemName.Text.Trim();
            //    //cmd.Parameters.Add("@MainGroup", SqlDbType.VarChar,cmbGroup.Text.Length).Value = cmbGroup.Text.Trim();
            //    //cmd.Parameters.Add("@ItemType", SqlDbType.VarChar, cmbItemType.Text.Length).Value = cmbItemType.Text.Trim();
            //    //cmd.Parameters.Add("@UnitPrice", SqlDbType.VarChar, txtUnitPrice.Text.Length).Value = txtUnitPrice.Text.Trim();
            //    //cmd.Parameters.Add("@ItemCategory", SqlDbType.VarChar, cmbItemCategory.Text.Length).Value = cmbItemCategory.Text.Trim();
            //    //cmd.Parameters.Add("@PromoItem", SqlDbType.VarChar, txtPromotionalItem.Text.Length).Value = txtPromotionalItem.Text.Trim();
            //    bflag  =Convert.ToBoolean(cmd.ExecuteScalar().ToString());
            //    if (bflag)
            //    {
            //        MessageBox.Show("This Item Code Already exists.", "Product Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            //    }
                

            //}
            //catch (Exception ex)
            //{
            //}
        }

    }
}
