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
    public partial class frmSearchCustomer : Form
    {
        public frmSearchCustomer()
        {
            InitializeComponent();
        }
        string sFlag, sSearchedCriteria;
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();

        public delegate void UpdateCustomerDetails(object sender, CustomerDetUpdateArgs e);
        public event UpdateCustomerDetails CustomerDetUpdated;

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            sFlag = "CUSTPHONE";
            sSearchedCriteria = txtSearchCustMob.Text;
            SearchCustomer(sFlag, sSearchedCriteria);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearchCustCode_TextChanged(object sender, EventArgs e)
        {
            sFlag = "CUSTCODE";
            sSearchedCriteria = txtSearchCustCode.Text;
            SearchCustomer(sFlag, sSearchedCriteria);
        }
        public void SearchCustomer(string sFlag, string sSearchedCrit)
        {
            try
            {
                cmd = new SqlCommand();
                ds = new DataSet();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_SearchCustomer";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                cmd.Parameters.Add("@SearchedCrit", SqlDbType.VarChar, sSearchedCrit.Length).Value = sSearchedCrit.Trim();
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                dgSearchCustomer.DataSource = ds.Tables["Result"];
            }
            catch (Exception ex)
            {
                
            }
           
        }

        private void txtSearchCustName_TextChanged(object sender, EventArgs e)
        {
            sFlag = "CUSTNAME";
            sSearchedCriteria = txtSearchCustName.Text;
            SearchCustomer(sFlag, sSearchedCriteria);

        }

        private void txtsearchCustAddress_TextChanged(object sender, EventArgs e)
        {
            sFlag = "CUSTADDRESS";
            sSearchedCriteria = txtsearchCustAddress.Text;
            SearchCustomer(sFlag, sSearchedCriteria);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgSearchCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgSearchCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                i = dgSearchCustomer.CurrentCell.RowIndex;
                GlobalClass.gsCustomerName = dgSearchCustomer.Rows[i].Cells["CustomerFirstName"].Value.ToString();
                GlobalClass.gsCustomerAddress = dgSearchCustomer.Rows[i].Cells["AddressLine1"].Value.ToString() + " , " + dgSearchCustomer.Rows[i].Cells["AddressLine2"].Value.ToString();
                GlobalClass.gsPhoneNo = dgSearchCustomer.Rows[i].Cells["MobilePhone"].Value.ToString();
                CustomerDetUpdateArgs args = new CustomerDetUpdateArgs(GlobalClass.gsCustomerName, GlobalClass.gsCustomerAddress,GlobalClass.gsPhoneNo);
                CustomerDetUpdated(this, args);
                //frmOrders fr = new frmOrders();
                //fr.txtCustAddress.Text = GlobalClass.gsCustomerAddress;
             //   this.Close();
            }
            catch (Exception Ex)
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ClearForm();
            }
            catch (Exception ex)
            {
            }
        }
        public void ClearForm()
        {
            txtSearchCustCode.Text = "";
            txtSearchCustName.Text = "";
            txtsearchCustAddress.Text = "";
            txtSearchCustMob.Text = "";
            dgSearchCustomer.DataSource = null;
        }

        private void dgSearchCustomer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }


    }
    public class CustomerDetUpdateArgs : System.EventArgs
    {
        private string sCustName,sCustAddress,sCustPhone;
        public CustomerDetUpdateArgs(string sCustomerName, string sCustomerAddress, string sCustomerPhone)
        {
            this.sCustName = sCustomerName;
            this.sCustAddress = sCustomerAddress;
            this.sCustPhone = sCustomerPhone;
        }
        public string CustomerName
        {
            get
            {
                return sCustName;
            }
        }
        public string CustomerAddress
        {
            get
            {
                return sCustAddress;
            }
        }
        public string CustomerPhone
        {
            get
            {
                return sCustPhone;
            }
        }
        


    }
}
