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
    public partial class frmSearchedInvoices : Form
    {
        public frmSearchedInvoices()
        {
            InitializeComponent();
        }
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        public delegate void ShareInvoiceno(object sender, ShareInvoiceArgs e);
        string sInvoiceNo = "";
        public event ShareInvoiceno EvtShareInvoice;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sInvoiceNo = "";
                sInvoiceNo = txtInvoiceNo.Text.Trim();
                cmd = new SqlCommand();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_SearchInvoices";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 20).Value = "SEARCH";
                cmd.Parameters.Add("@sfromdate", SqlDbType.VarChar, 20).Value ="";
                cmd.Parameters.Add("@sTodate", SqlDbType.VarChar, 20).Value = "";
                //cmd.Parameters.Add("@sInvoiceNo", SqlDbType.VarChar, sInvoiceNo.Length).Value =sInvoiceNo;
                if (sInvoiceNo.Length < 7 && sInvoiceNo!="")
                {
                    sInvoiceNo ="I1"+ sInvoiceNo.PadLeft(7, '0');
                }
                cmd.Parameters.Add("@sInvoiceNo", SqlDbType.VarChar, sInvoiceNo.Length).Value = sInvoiceNo.Trim();
                ds = new DataSet();
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                dgSearchedInvoices.DataSource = ds.Tables["Result"];
                
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in Searching Invoice button1_Click: " + ex.Message.ToString());
            }
        }

        private void frmSearchedInvoices_Load(object sender, EventArgs e)
        {
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void dgSearchedInvoices_Click(object sender, EventArgs e)
        {
            try
            {
                sInvoiceNo = dgSearchedInvoices.Rows[dgSearchedInvoices.CurrentCell.RowIndex].Cells["InvoiceNo"].Value.ToString();
                ShareInvoiceArgs args = new ShareInvoiceArgs(sInvoiceNo);
                EvtShareInvoice(this, args);
                //this.Close();
               // this.Dispose();
            }
            catch (Exception ex)
            {
            }
        }

        private void dgSearchedInvoices_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ClearForm();
        }
        public void ClearForm()
        {
            try
            {
                txtInvoiceNo.Text = "";
                dgSearchedInvoices.DataSource = null;
            }
            catch (Exception ex)
            {
            }
        }

        private void dgSearchedInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    public class ShareInvoiceArgs : System.EventArgs
    {
        private string sInvNo;

        public ShareInvoiceArgs(string sInvoiceNo)
        {
            this.sInvNo = sInvoiceNo;
        }
        public string InvoiceNo
        {
            get
            {
                return sInvNo;
            }
        }


    }

}
