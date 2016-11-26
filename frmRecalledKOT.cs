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
    public partial class frmRecalledKOT : Form
    {
        string sSalesOrderType;
        public frmRecalledKOT( string sOrderType)
        {
            sSalesOrderType = sOrderType;
            InitializeComponent();
        }
        string sFlag;
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        public delegate void ShareRecalledKOT(object sender,ShareRecalledKOTArgs e);
        public event ShareRecalledKOT EvtKOTRecalled;
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRecalledKOT_Load(object sender, EventArgs e)
        {
            try
            {

                sFlag = "SEARCH";
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_MaintainKOT";
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                /*cmd.Parameters.Add("@itemcode", SqlDbType.VarChar, txtItemcode.TextLength).Value = txtItemcode.Text.Trim();
                cmd.Parameters.Add("@KOTID", SqlDbType.VarChar, txtBillNo.TextLength).Value = txtBillNo.Text.Trim();
                cmd.Parameters.Add("@Itemname", SqlDbType.VarChar, dgview.Rows[j].Cells[0].Value.ToString().Length).Value = dgview.Rows[j].Cells[0].Value.ToString().Trim();
                cmd.Parameters.Add("@Quantity", SqlDbType.VarChar, dgview.Rows[j].Cells[1].Value.ToString().Length).Value = dgview.Rows[j].Cells[1].Value.ToString().Trim();
                cmd.Parameters.Add("@UnitPrice", SqlDbType.VarChar, dgview.Rows[j].Cells[2].Value.ToString().Length).Value = dgview.Rows[j].Cells[2].Value.ToString().Trim();
                cmd.Parameters.Add("@Amount", SqlDbType.VarChar, dgview.Rows[j].Cells[3].Value.ToString().Length).Value = dgview.Rows[j].Cells[3].Value.ToString().Trim();*/
                //cmd.Parameters.Add("@Ordertype", SqlDbType.VarChar, cmbOrderType.Text.ToString().Length).Value = cmbOrderType.Text.ToString().Trim();
                cmd.Parameters.Add("@Ordertype", SqlDbType.VarChar, sSalesOrderType.Length).Value = sSalesOrderType.ToString().Trim();
                ds = new DataSet();
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                if (ds.Tables["Result"].Rows.Count > 0)
                    dgRecalledKOT.DataSource = ds.Tables["Result"];
                //MessageBox.Show(ds.Tables["Result"].Rows.Count.ToString() +" KOT Recalled", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                cmd = null;
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgRecalledKOT_Click(object sender, EventArgs e)
        {
            try
            {
                int i, j;
                string sCustomerName, sCustAddress, sCustRemarks, sSalesBy,sKOTID,sOrderType,sCustomerPhone;
                i = dgRecalledKOT.CurrentCell.ColumnIndex;
                j = dgRecalledKOT.CurrentCell.RowIndex;
                sKOTID = dgRecalledKOT.Rows[j].Cells["KOTID"].Value.ToString();
                sCustAddress = dgRecalledKOT.Rows[j].Cells["Customeraddress"].Value.ToString();
                sCustomerName = dgRecalledKOT.Rows[j].Cells["Customername"].Value.ToString();
                sCustomerPhone = dgRecalledKOT.Rows[j].Cells["Customerphoneno"].Value.ToString();
                sOrderType = dgRecalledKOT.Rows[j].Cells["Ordertype"].Value.ToString();
                sSalesBy = dgRecalledKOT.Rows[j].Cells["SalesBy"].Value.ToString();
                sCustRemarks = dgRecalledKOT.Rows[j].Cells["CustomerRemarks"].Value.ToString();
                GlobalClass.gbNewOrder = false;

                ShareRecalledKOTArgs args = new ShareRecalledKOTArgs(sKOTID, sCustomerName, sCustAddress, sCustomerPhone, sCustRemarks, sOrderType, sSalesBy);
                EvtKOTRecalled(this, args);

            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgRecalledKOT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgRecalledKOT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    public class ShareRecalledKOTArgs : System.EventArgs
    {
        private string sKotid, sCustName, sCustadd, scustphone, scustRemarks, sOdrType, sslsby;
        public ShareRecalledKOTArgs(string sid, string scustname, string scustadd, string scustph, string scustrem, string sodrtype, string sslsby)
        {
            this.sKotid = sid;
            this.sCustName = scustname;
            this.sCustadd = scustadd;
            this.scustphone = scustph;
            this.scustRemarks = scustrem;
            this.sOdrType = sodrtype;
            this.sslsby = sslsby;
        }
        public string KOTID
        {
            get
            {
                return sKotid;
            }
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
                return sCustadd;
              
            }
        }
        public string CustomerPhone
        {
            get
            {
                return scustphone;

            }
        }
        public string CustomerRemarks
        {
            get
            {
                return scustRemarks;

            }
        }
        public string OrderType
        {
            get
            {
                return sOdrType;

            }
        }
        public string SalesBy
        {
            get
            {
                return sslsby;

            }
        }






    }
}
