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
    public partial class frmMaintainGroups : Form
    {
        public frmMaintainGroups()
        {
            InitializeComponent();
        }
        string sFlag="",sGroupTypetobeAdded="",sText="";
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        int iResult;

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();

        }

        private void frmMaintainGroups_Load(object sender, EventArgs e)
        {

        }

        private void btnGroupSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMainGroup.Text.Trim() == "" && sGroupTypetobeAdded == "MAINGROUP")
                {
                    MessageBox.Show("Please Enter Main Group Name", "Group Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (txtGroup.Text.Trim() == "" && sGroupTypetobeAdded == "GROUP")
                {
                    MessageBox.Show("Please Enter Group Name", "Group Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (txtSubGroup.Text.Trim() == "" && sGroupTypetobeAdded == "SUBGROUP")
                {
                    MessageBox.Show("Please Enter Main Group Name", "Group Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if ( sGroupTypetobeAdded == null)
                {
                    MessageBox.Show("Please Enter Any Group Name", "Group Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

                sFlag = "SAVE";
                MaintainDiffGroup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Group Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        public void MaintainDiffGroup()
        {
            try
            {
                ds = new DataSet();
                cmd = new SqlCommand();

                cmd.Connection = GlobalClass.gCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MaintainGroups";
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 20).Value = sFlag.Trim();
                cmd.Parameters.Add("@GroupType", SqlDbType.VarChar, sGroupTypetobeAdded.Length).Value = sGroupTypetobeAdded.Trim();
                if (sText.Trim()!="" || sText!=null)
                cmd.Parameters.Add("@Texttobesent", SqlDbType.VarChar, sText.Length).Value = sText.Trim();
                if (sFlag == "SAVE" )
                {
                    iResult = cmd.ExecuteNonQuery();
                    if (iResult >= 1)
                    {
                        MessageBox.Show("Value added successfully", "Group Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("No Values added", "Group Master", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else if(sFlag == "DELETE")
                {

                    iResult = cmd.ExecuteNonQuery();
                    if (iResult >= 1)
                    {
                        MessageBox.Show("Value deleted successfully", "Group Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("No Values Deleted", "Group Master", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                    MessageBox.Show(ds.Tables["result"].Rows.Count.ToString() +" records found", "Group Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    
                    dgGroupMaster.DataSource = ds.Tables["Result"];

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Group Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

        }

        private void txtMainGroup_TextChanged(object sender, EventArgs e)
        {
            sText = txtMainGroup.Text.Trim();
            sGroupTypetobeAdded = "MAINGROUP";
        }

        private void txtGroup_TextChanged(object sender, EventArgs e)
        {
            sText = txtGroup.Text.Trim();
            sGroupTypetobeAdded = "GROUP";
        }

        private void txtSubGroup_TextChanged(object sender, EventArgs e)
        {
            sText = txtSubGroup.Text.Trim();
            sGroupTypetobeAdded = "SUBGROUP";
        }

        private void rbtnSearchMainGroup_CheckedChanged(object sender, EventArgs e)
        {
            rbtnSearchGroup.Checked = false;
            rbtnSearchSubgroup.Checked = false;

            ds = null;
            sGroupTypetobeAdded = "MAINGROUP";
            sFlag = "SEARCH";
            MaintainDiffGroup();
        }

        private void rbtnSearchGroup_CheckedChanged(object sender, EventArgs e)
        {
            rbtnSearchMainGroup.Checked = false;
            rbtnSearchSubgroup.Checked = false;
            
            ds = null;
            sGroupTypetobeAdded = "GROUP";
            sFlag = "SEARCH";
            MaintainDiffGroup();
        }

        private void rbtnSearchSubgroup_CheckedChanged(object sender, EventArgs e)
        {
            rbtnSearchMainGroup.Checked = false;
            rbtnSearchGroup.Checked = false;
            ds = null;
            sGroupTypetobeAdded = "SUBGROUP";
            sFlag = "SEARCH";
            MaintainDiffGroup();
        }

        private void btnGroupDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //sGroupTypetobeAdded = "SUBGROUP";
                if (txtMainGroup.Text.Trim() == "" && sGroupTypetobeAdded == "MAINGROUP")
                {
                    MessageBox.Show("Please Enter Main Group Name to delete", "Group Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (txtGroup.Text.Trim() == "" && sGroupTypetobeAdded == "GROUP")
                {
                    MessageBox.Show("Please Enter Group Name to delete", "Group Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (txtSubGroup.Text.Trim() == "" && sGroupTypetobeAdded == "SUBGROUP")
                {
                    MessageBox.Show("Please Enter Main SubGroup Name to delete", "Group Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (sGroupTypetobeAdded == null)
                {
                    MessageBox.Show("Please Enter Any Group Name to delete", "Group Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

                sFlag = "DELETE";
                MaintainDiffGroup();
                ClearForm();
            }
            catch (Exception ex)
            {
            }
        }

        private void dgGroupMaster_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                i=dgGroupMaster.CurrentCell.RowIndex;
                if (sGroupTypetobeAdded == "MAINGROUP")
                {
                    txtMainGroup.Text = dgGroupMaster.Rows[i].Cells["GroupName"].Value.ToString();
                }
                if (sGroupTypetobeAdded == "GROUP")
                {
                    txtGroup.Text = dgGroupMaster.Rows[i].Cells["GroupName"].Value.ToString();
                }
                if (sGroupTypetobeAdded == "SUBGROUP")
                {
                    txtSubGroup.Text = dgGroupMaster.Rows[i].Cells["GroupName"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Group Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnGroupClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        
        public void ClearForm()
        {
            txtMainGroup.Text = "";
            txtGroup.Text = "";
            txtSubGroup.Text = "";
            dgGroupMaster.DataSource = null;

        }
    }
}
