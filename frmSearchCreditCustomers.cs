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
    public partial class frmSearchCreditCustomers : Form
    {
        public frmSearchCreditCustomers()
        {
            InitializeComponent();
        }
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        public delegate void ShareCustomerName(object sender, ShareCustomerNameArgs e);
        public event ShareCustomerName EvtSharecustname;
        string sCustomerName;

        private void frmSearchCreditCustomers_Load(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_SearchCreditCustomers";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 20).Value = GlobalClass.gsReceiptFlag;
                cmd.Parameters.Add("@FromDate",SqlDbType.VarChar,20).Value="";
                cmd.Parameters.Add("@ToDate", SqlDbType.VarChar, 20).Value = "";
                cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 20).Value = GlobalClass.gsReceiptIssueInvoice;
                cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar, 20).Value = "";
                ds = new DataSet();
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                dgvwSearchCreditCustomers.DataSource = ds.Tables["Result"];
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in frmSearchCreditCustomers_Load:" + ex.Message.ToString());
            }
        }

        private void dgvwSearchCreditCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                sCustomerName = dgvwSearchCreditCustomers.Rows[dgvwSearchCreditCustomers.CurrentCell.RowIndex].Cells["customername"].Value.ToString();
                ShareCustomerNameArgs args = new ShareCustomerNameArgs(sCustomerName);
                EvtSharecustname(this, args);
                this.Close();

            }
            catch (Exception ex)
            {
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvwSearchCreditCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public class ShareCustomerNameArgs: System.EventArgs
    {

        private string scustomername;
        public ShareCustomerNameArgs(string sCustname)
        {
            this.scustomername = sCustname;
        }
        public string CustomerName
        {
            get
            {
                return scustomername;
            }
        }


    }
}
