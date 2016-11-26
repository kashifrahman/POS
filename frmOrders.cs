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
//using Microsoft.PointOfService;


namespace SalesPurchase
{
    public partial class frmOrders : Form
    {
        public frmOrders()
        {
            InitializeComponent();
        }
        SqlCommand cmd=new SqlCommand();
        DataSet ds=new DataSet();

        int ReprintCount = 0;

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                int iCounter;
                string sFlag;
                sFlag="LOAD";
                //txtBillNo.Text = DateTime.Now.ToString("yyMMddHHmmss");
                txtBillNo.ReadOnly = true;
                GlobalClass.gsBillNo = txtBillNo.Text;
                txtTimeDate.Text = DateTime.Now.ToString();
                cmbOrderType.Items.Add("Order Type");

                GlobalClass.FetchTableNames();
                
                for (iCounter = 0; iCounter < GlobalClass.arrTablenames.GetUpperBound(0)&& GlobalClass.arrTablenames[iCounter]!=null ; iCounter++)
                {
                    cmbOrderType.Items.Add(GlobalClass.arrTablenames[iCounter].ToString());
                }
                //cmbOrderType.Items.Add("TA");
                //cmbOrderType.Items.Add("T1");
                //cmbOrderType.Items.Add("T2");
                //cmbOrderType.Items.Add("T3");
                //cmbOrderType.Items.Add("T4");

                GlobalClass.WriteLog("Before Fetching Menu Details");
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_FetchMenuDetails";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                ds = new DataSet();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                for (int i=0;i<ds.Tables["Result"].Rows.Count;i++)
                    cmbItems.Items.Add(ds.Tables["Result"].Rows[i]["ItemName"].ToString());

                GlobalClass.WriteLog("Menu  details Fetched successfully");
                GlobalClass.WriteLog("Before Fetching Customer Details");
                cmd = null;
                sFlag = "FETCHCUSTOMER";
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_FetchMenuDetails";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                ds = new DataSet();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                for (int i = 0; i < ds.Tables["Result"].Rows.Count; i++)
                    cmbCustomerDetails.Items.Add(ds.Tables["Result"].Rows[i]["CustomerName"].ToString());
                GlobalClass.WriteLog("Customer Details fetched successfully");
                GlobalClass.WriteLog("Before Fetching Employee details");
                sFlag = "FETCHEMPNAME";
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_FetchMenuDetails";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                ds = new DataSet();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                for (int i = 0; i < ds.Tables["Result"].Rows.Count; i++)
                    cmbSalesBy.Items.Add(ds.Tables["Result"].Rows[i]["Employeename"].ToString().Trim());
                GlobalClass.WriteLog("Employee Details fetched successfully");

                cmbCustomerDetails.SelectedIndex = -1;
                cmbSalesBy.SelectedIndex = -1;
                KOTNumberGenerator();

                this.Focus();
            }
            
            catch (Exception Ex)
            {
                GlobalClass.WriteLog("Error in Form KOT Load:"+Ex.Message.ToString());
                MessageBox.Show(Ex.Message.ToString(), "Error in KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        public void KOTNumberGenerator()
        {
            try
            {
                GlobalClass.WriteLog("Before Fetching KOT Numbers");
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_GetInvoiceCounter";
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10).Value = "KOT";
                txtBillNo.Text = "K"+GlobalClass.gsCounterNo + cmd.ExecuteScalar().ToString().PadLeft(7, '0');

                GlobalClass.WriteLog("KOT Number Fetched Successfully. Invoice No:" + txtBillNo.Text);
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in KOTNumberGenerator:" + ex.Message.ToString());
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbOrderType.Text.Trim() == "" || cmbOrderType.Text=="Order Type")
                {
                    MessageBox.Show("Please select Order Type", "KOT Manage", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cmbOrderType.Focus();
                    return;
                }
                if (cmbCustomerDetails.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Customer Name", "KOT Manage", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cmbCustomerDetails.Focus();
                    return;
                }
                if (txtCustAddress.Text.Trim() == "" && cmbOrderType.Text=="Home Delivery")
                {
                    MessageBox.Show("Please Enter Customer Address", "KOT Manage", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtCustAddress.Focus();
                    return;
                }
                if (cmbSalesBy.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Salesman Name", "KOT Manage", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cmbSalesBy.Focus();
                    return;
                }
                if (cmbItems.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Item Name", "KOT Manage", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    cmbItems.Focus();
                    return;
                }
                int i, iResult;
                i = dgview.Rows.Count;
                if (i == 0)
                {
                    MessageBox.Show("No Items to add for KOT,Please Take Orders", "KOT Manage", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                string sql,sFlag,stempstr;
                decimal dKotAmount;
                dKotAmount = 0;
                sFlag="SAVE";
                //cmd = new SqlCommand();
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Connection = GlobalClass.gCon;
                //cmd.CommandText = "SP_MaintainKOTCUstomer";
                //cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                //cmd.Parameters.Add("@KOTID", SqlDbType.VarChar, txtBillNo.TextLength).Value = txtBillNo.Text.Trim();
                //cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar, cmbCustomerDetails.Text.ToString().Length).Value = cmbCustomerDetails.Text.ToString().Trim();
                //cmd.Parameters.Add("@CustomerAddress", SqlDbType.VarChar, txtCustAddress.Text.Length).Value = txtCustAddress.Text.ToString().Trim();
                //cmd.Parameters.Add("@CustomerRemarks", SqlDbType.VarChar, txtCustRemarks.Text.ToString().Length).Value = txtCustRemarks.Text.ToString().Trim();
                //cmd.Parameters.Add("@SalesBy", SqlDbType.VarChar, cmbSalesBy.Text.ToString().Length).Value = cmbSalesBy.Text.ToString().Trim();
                //cmd.Parameters.Add("@CustPhoneNo", SqlDbType.VarChar, txtCustPhoneNo.Text.ToString().Length).Value = txtCustPhoneNo.Text.ToString().Trim();
                //i = cmd.ExecuteNonQuery();

                i = dgview.Rows.Count;
                if (i == 0)
                {
                    MessageBox.Show("No Items to add for KOT", "KOT Manage", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                for (int j = 0; j < i; j++)
                {
                    cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = GlobalClass.gCon;
                    cmd.CommandText = "SP_MaintainKOT";
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                    cmd.Parameters.Add("@itemcode", SqlDbType.VarChar, dgview.Rows[j].Cells["ItemCode"].Value.ToString().Length).Value = dgview.Rows[j].Cells["ItemCode"].Value.ToString().Trim();
                    cmd.Parameters.Add("@KOTID", SqlDbType.VarChar, txtBillNo.TextLength).Value = txtBillNo.Text.Trim();
                    cmd.Parameters.Add("@Itemname", SqlDbType.VarChar, dgview.Rows[j].Cells["ItemName"].Value.ToString().Length).Value = dgview.Rows[j].Cells["ItemName"].Value.ToString().Trim();
                    cmd.Parameters.Add("@Quantity", SqlDbType.VarChar, dgview.Rows[j].Cells["Quantity"].Value.ToString().Length).Value = dgview.Rows[j].Cells["Quantity"].Value.ToString().Trim();
                    cmd.Parameters.Add("@UnitPrice", SqlDbType.VarChar, dgview.Rows[j].Cells["UnitPrice"].Value.ToString().Length).Value = dgview.Rows[j].Cells["UnitPrice"].Value.ToString().Trim();
                    cmd.Parameters.Add("@Amount", SqlDbType.VarChar, dgview.Rows[j].Cells["Amount"].Value.ToString().Length).Value = dgview.Rows[j].Cells["Amount"].Value.ToString().Trim();
                    cmd.Parameters.Add("@Ordertype", SqlDbType.VarChar, cmbOrderType.Text.ToString().Length).Value = cmbOrderType.Text.ToString().Trim();
                    dKotAmount = dKotAmount + Convert.ToDecimal( dgview.Rows[j].Cells["Amount"].Value);
                    iResult=cmd.ExecuteNonQuery();
                    cmd = null;    
                 }

                if (i>= 1)
                {
                    MessageBox.Show("Values added successfully", "KOT Manage", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    GlobalClass.WriteLog("Values Added Successfully");
                    //button2_Click(sender, e);
                    //PrintKOT();
                    //ClearForm();
                    //txtBillNo.Text = DateTime.Now.ToString("yyMMddHHmmss");
                    //txtBillNo.ReadOnly = true;
                    
                }
                sFlag = "SAVE";
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_MaintainKOTCUstomer";
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                cmd.Parameters.Add("@KOTID", SqlDbType.VarChar, txtBillNo.TextLength).Value = txtBillNo.Text.Trim();
                cmd.Parameters.Add("@CustomerName", SqlDbType.VarChar, cmbCustomerDetails.Text.ToString().Length).Value = cmbCustomerDetails.Text.ToString().Trim();
                cmd.Parameters.Add("@CustomerAddress", SqlDbType.VarChar, txtCustAddress.Text.Length).Value = txtCustAddress.Text.ToString().Trim();
                cmd.Parameters.Add("@CustomerRemarks", SqlDbType.VarChar, txtCustRemarks.Text.ToString().Length).Value = txtCustRemarks.Text.ToString().Trim();
                cmd.Parameters.Add("@SalesBy", SqlDbType.VarChar, cmbSalesBy.Text.ToString().Length).Value = cmbSalesBy.Text.ToString().Trim();
                cmd.Parameters.Add("@CustPhoneNo", SqlDbType.VarChar, txtCustPhoneNo.Text.ToString().Length).Value = txtCustPhoneNo.Text.ToString().Trim();
                cmd.Parameters.Add("@KotAmount", SqlDbType.VarChar, 10).Value = dKotAmount;
                i = cmd.ExecuteNonQuery();

                //PrintKOTValues();
                PrintKOT();
                //Added by Kashif on 21st Aug 2015


                ClearForm();
                //txtBillNo.Text = DateTime.Now.ToString("yyMMddHHmmss");
                KOTNumberGenerator();
                txtBillNo.ReadOnly = true;

                //j = 0;
                //sql = "select * from orders";
                //cmd = new SqlCommand();
                //cmd.Connection = GlobalClass.gCon;
                //cmd.CommandType = CommandType.Text;
                //cmd.CommandText = sql;
                //ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, ds.Tables["Result"]);

            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(),"Error in KOT",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            //MessageBox.Show("Page Cleared", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            
        }
        public void PrintKOTValues()
        {
            GlobalClass.gsKOTIDforPrint = txtBillNo.Text;
            GlobalClass.gsOrderTypeforPrint = cmbOrderType.Text;
            GlobalClass.gsCustomerAddressforPrint = txtCustAddress.Text;
            GlobalClass.gsCustomerNameforPrint = cmbCustomerDetails.Text;

            //frmKOTPrint fr = new frmKOTPrint();
            //fr.Show();
            frmPrintKOT fr = new frmPrintKOT();
            fr.MdiParent = this.ParentForm;
            fr.Show();
            
        }
        public void ClearForm()
        {
            //txtItemName.Clear();
            try
            {

                txtQuantity.Clear();
                //txtUnits.Clear();
                txtItemPrice.Clear();
                txtAmount.Clear();
                dgview.Rows.Clear();
                cmbItems.SelectedIndex = -1;
                txtItemcode.Clear();
                cmbOrderType.SelectedIndex = -1;
                cmbSalesBy.SelectedIndex = -1;
                txtCustAddress.Text = "";
                txtCustRemarks.Text = "";
                cmbCustomerDetails.Text ="";
                txtCustPhoneNo.Text = "";
                btnOK.Enabled = true;
                btnKOTReprint.Enabled = false;
                dgview.AllowUserToDeleteRows = true;
                txtItemRemarks.Text = "";
                KOTNumberGenerator();
            }
            catch (Exception Ex)
            {
                GlobalClass.WriteLog(Ex.Message.ToString());
                MessageBox.Show(Ex.Message.ToString(), "Error in KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTimeDate.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sFlag;
                sFlag = "GETREPRINTCOUNT";
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_MaintainKOT";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                GlobalClass.cmd.Parameters.Add("@KOTID", SqlDbType.VarChar, txtBillNo.Text.Length).Value = txtBillNo.Text.ToString().Trim();
                ds = new DataSet();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                //if (ds.Tables["Result"].Rows.Count == 0)
                //{
                //    MessageBox.Show("No Customer found for given name", "Orders", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //    return;
                //}
                ReprintCount = Convert.ToInt32(ds.Tables["Result"].Rows[0]["Count"].ToString());
                //button2_Click(sender, e);
                PrintKOT();

                // string sFlag;
                sFlag = "UPDATEREPRINTCOUNT";
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_MaintainKOT";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                GlobalClass.cmd.Parameters.Add("@KOTID", SqlDbType.VarChar, txtBillNo.Text.Length).Value = txtBillNo.Text.ToString().Trim();
                ds = new DataSet();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                

                //PrintKOT();
                //PrintKOTValues();
                //button1_Click(sender, e);
                //printDialog1.Document = printKOTDOC;
                //if (printDialog1.ShowDialog() == DialogResult.OK)
                //{
                //    printPreviewDialog1.Document = printKOTDOC;
                //    printPreviewDialog1.Width = 200;
                //    printPreviewDialog1.MinimumSize = new Size(375, 250);
                //    printPreviewDialog1.SetBounds(100, -550, 800, 800);

                //    printPreviewDialog1.ShowDialog();
                //    //printPreviewDialog1.ClientSize = new System.Drawing.Size(800, 700);
                //    printKOTDOC.Print();
                //}
            
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Orders", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        public void PrintInvoice()
        {
        }
        public void PrintKOT()
        {
            try{
                printDialog1.Document = printKOTDOC;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printPreviewDialog1.Document = printKOTDOC;
                    //printPreviewDialog1.Width = 300;
                    //printPreviewDialog1.MinimumSize = new Size(375, 250);

                    
                  
                    //printPreviewDialog1.SetBounds(100, -550, 3000, 3000);
                    //printPreviewDialog1.SetBounds(100, -50, 300, 400);
                    //printPreviewControl1.Document = printKOTDOC;
                    //printPreviewControl1.Visible = true;
                    //printPreviewControl1.Dock=DockStyle.
                    
                    pageSetupDialog.Document = printKOTDOC;
                    
                   // pageSetupDialog.ShowDialog();

                    //Commented by KAshif on 15th Nov 2014
                    ////////if (pageSetupDialog.ShowDialog() == DialogResult.OK)

                    ////////{
                    ////////   // printKOTDOC.DefaultPageSettings= pageSetupDialog.PageSettings.Margins;
                    ////////    //printKOTDOC. = pageSetupDialog.PageSettings.Margins;
                    ////////    printKOTDOC.DefaultPageSettings = pageSetupDialog.PageSettings;
                    ////////    //printKOTDOC.DefaultPageSettings.Margins.Bottom = pageSetupDialog.PageSettings.Margins.Bottom;
                    ////////    //printKOTDOC.DefaultPageSettings.Margins.Top = pageSetupDialog.PageSettings.Margins.Top;
                    ////////    //printKOTDOC.DefaultPageSettings.Margins.Left = pageSetupDialog.PageSettings.Margins.Left;
                    ////////    //printKOTDOC.DefaultPageSettings.Margins.Right = pageSetupDialog.PageSettings.Margins.Right;
                    ////////    printKOTDOC.PrinterSettings = pageSetupDialog.PrinterSettings;
                    ////////    //printKOTDOC.DefaultPageSettings.Margins.Left = pageSetupDialog.PageSettings.Margins.Left;
                    ////////}
                    //Till here

                    //Commented by Kashif on 15th Nov 2014
                    ////if (printPreviewDialog1.ShowDialog() == DialogResult.Cancel)//Commenetd by Kashif on 12th Feb 2013
                    ////{
                    ////    return;
                    ////}
                    //printPreviewDialog1.ClientSize = new System.Drawing.Size(800, 700);

                    //StandardPrintController printcontroller = new StandardPrintController();
                    //printKOTDOC.PrintController = printcontroller;
                    
                    printKOTDOC.Print();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Orders", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSearchedKOT fr = new frmSearchedKOT();
            fr.KOTdetailsshared+=new frmSearchedKOT.ShareKOTDetails(fr_KOTdetailsshared);

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmSearchedKOT)
                {
                    MessageBox.Show("Searched KOT Window is already open", "KOT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            fr.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            fr.MdiParent = this.ParentForm;
            fr.Show();
        }
        private void fr_KOTdetailsshared(object sender, KOTDetailsArgs e)
        {
            try
            {
             //   DataSet dsLocal = new DataSet();
                int i, count;
            txtBillNo.Text = e.KOTid.ToString();
            
            cmbCustomerDetails.Text = e.CustomerName.ToString();
            txtCustAddress.Text = e.CustomerAddress.ToString();
            txtCustRemarks.Text = e.CustomerRemarks.ToString();
            cmbSalesBy.Text = e.SalesBy.ToString();
            cmbOrderType.Text = e.OrderType.ToString();

            ds = new DataSet();
            string sFlag,sKotid;
            sKotid = txtBillNo.Text.Trim();
            sFlag = "FETCHKOT";
            cmd = null;
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = GlobalClass.gCon;
            cmd.CommandText = "SP_MaintainKOTCUstomer";
            cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
            cmd.Parameters.Add("@KOTID", SqlDbType.VarChar, sKotid.Length).Value = sKotid.Trim();
            
            ds.Load(cmd.ExecuteReader(),LoadOption.OverwriteChanges,"Result");
            //dgview.DataSource=ds.Tables["Result"];
            dgview.Rows.Clear();
            for (i = 0; i < ds.Tables["Result"].Rows.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dgview,ds.Tables["Result"].Rows[i]["Itemcode"].ToString(), ds.Tables["Result"].Rows[i]["KOTItem"].ToString(),ds.Tables["Result"].Rows[i]["KOTItemQty"].ToString(), ds.Tables["Result"].Rows[i]["KOTItemunitprice"].ToString(),ds.Tables["result"].Rows[i]["Amount"].ToString()," ");
                this.dgview.Rows.Add(row);
            }
            btnOK.Enabled = false;
            btnKOTReprint.Enabled = true;
            dgview.ReadOnly = true;
            dgview.AllowUserToDeleteRows = false;
            cmd = null;

            }
            catch(Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Error in KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }


        }

        private void cmbItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cmbCustomerDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void txtItemcode_TextChanged(object sender, EventArgs e)
        {
           /* try
            {
                string sItemCode,flag;
                ds = new DataSet();
                flag="TYPEMENU";
                sItemCode=txtItemcode.Text.Trim();
                cmd = new SqlCommand();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_MaintainKOT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@flag", SqlDbType.VarChar, flag.Length).Value = flag;
                cmd.Parameters.Add("@Itemcode", SqlDbType.VarChar, sItemCode.Length).Value = sItemCode;
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                if (ds.Tables["Result"].Rows.Count == 0)
                {
                    MessageBox.Show("No Items found for the code", "Menu Items", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                cmbItems.Text = ds.Tables["Result"].Rows[0]["ItemName"].ToString();
                txtAmount.Text = ds.Tables["Result"].Rows[0]["ItemPrice"].ToString();




            }
            catch (Exception ex)
            {
            }*/
        }

        private void txtItemcode_Leave(object sender, EventArgs e)
        {
            try
            {
                string sItemCode, flag;
                ds = new DataSet();
                flag = "TYPEMENU";
                sItemCode = txtItemcode.Text.Trim();
                if (sItemCode != "")
                {
                    cmd = new SqlCommand();
                    cmd.Connection = GlobalClass.gCon;
                    cmd.CommandText = "SP_MaintainKOT";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@flag", SqlDbType.VarChar, flag.Length).Value = flag;
                    cmd.Parameters.Add("@Itemcode", SqlDbType.VarChar, sItemCode.Length).Value = sItemCode;
                    ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                    if (ds.Tables["Result"].Rows.Count == 0)
                    {
                        MessageBox.Show("No Items found for the code", "Menu Items", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    cmbItems.Text = ds.Tables["Result"].Rows[0]["ItemName"].ToString();
                    txtItemPrice.Text = ds.Tables["Result"].Rows[0]["ItemPrice"].ToString();
                }

            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Error in KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    Decimal dc;
            //    dc =Convert.ToDecimal(txtItemPrice.Text) * Convert.ToDecimal(txtQuantity.Text);
            //    txtAmount.Text = dc.ToString();

            //    DataGridViewRow row = new DataGridViewRow();
            //    row.CreateCells(this.dgview, cmbItems.Text, txtQuantity.Text,txtItemPrice.Text,txtAmount.Text);
            //    this.dgview.Rows.Add(row);
            //}
            //catch (Exception Ex)
            //{
            //    MessageBox.Show(Ex.Message.ToString(), "Error in KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            string s;
        }

        private void cmbItems_Leave(object sender, EventArgs e)
        {
            try
            {
                string sFlag;
                sFlag = "FETCHITEM";
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_FetchMenuDetails";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                GlobalClass.cmd.Parameters.Add("@ItemName", SqlDbType.VarChar,cmbItems.Text.Length).Value =cmbItems.Text.ToString().Trim();
                ds = new DataSet();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                txtItemcode.Text = ds.Tables["Result"].Rows[0]["ItemCode"].ToString();
                txtItemPrice.Text = ds.Tables["Result"].Rows[0]["ItemPrice"].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error in KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                GlobalClass.WriteLog("Error in cmbItems_Leave:"+ex.Message.ToString());
            }
        }

        private void cmbCustomerDetails_Leave(object sender, EventArgs e)
        {

            try
            {
                
                string sFlag;
                sFlag = "FETCHCUSTOMERDET";
                if (cmbCustomerDetails.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter Customer Name", "Error in KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_FetchMenuDetails";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                GlobalClass.cmd.Parameters.Add("@ItemName", SqlDbType.VarChar, cmbCustomerDetails.Text.Length).Value = cmbCustomerDetails.Text.ToString().Trim();
                ds = new DataSet();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                if (ds.Tables["Result"].Rows.Count == 0)
                {
                    MessageBox.Show("No Customer found for given name", "Orders", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

                txtCustAddress.Text = ds.Tables["Result"].Rows[0]["addressline1"].ToString() + "," + ds.Tables["Result"].Rows[0]["City"].ToString();
                txtCustPhoneNo.Text = ds.Tables["Result"].Rows[0]["MobilePhone"].ToString().Trim();
                //txtItemPrice.Text = ds.Tables["Result"].Rows[0]["ItemPrice"].ToString();

            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Error in KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnManualAddress_Click(object sender, EventArgs e)
        {
            frmCustMaster fr = new frmCustMaster();
            fr.MdiParent = this.ParentForm;
            fr.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //cmbCustomerDetails_Leave(sender, e);
                frmSearchCustomer frm =new  frmSearchCustomer();
                
                frm.CustomerDetUpdated+=new frmSearchCustomer.UpdateCustomerDetails(frm_CustomerDetUpdated);
                frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                frm.MdiParent = this.ParentForm;
                frm.Show();
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Orders", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        private void frm_CustomerDetUpdated(object sender, CustomerDetUpdateArgs e)
        {
            cmbCustomerDetails.Text = e.CustomerName.ToString();
            txtCustAddress.Text = e.CustomerAddress.ToString();
            txtCustPhoneNo.Text = e.CustomerPhone.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //string sFlag;
                //sFlag = "GETREPRINTCOUNT";                
                //GlobalClass.cmd = new SqlCommand();
                //GlobalClass.cmd.Connection = GlobalClass.gCon;
                //GlobalClass.cmd.CommandText = "SP_MaintainKOT";
                //GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                //GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                //GlobalClass.cmd.Parameters.Add("@KOTID", SqlDbType.VarChar, txtBillNo.Text.Length).Value = txtBillNo.Text.ToString().Trim();
                //ds = new DataSet();
                //ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                ////if (ds.Tables["Result"].Rows.Count == 0)
                ////{
                ////    MessageBox.Show("No Customer found for given name", "Orders", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                ////    return;
                ////}
                //ReprintCount = Convert.ToInt32(ds.Tables["Result"].Rows[0]["Count"].ToString());
                button2_Click(sender, e);

               // string sFlag;
                //sFlag = "UPDATEREPRINTCOUNT";
                //GlobalClass.cmd = new SqlCommand();
                //GlobalClass.cmd.Connection = GlobalClass.gCon;
                //GlobalClass.cmd.CommandText = "SP_MaintainKOT";
                //GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                //GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                //GlobalClass.cmd.Parameters.Add("@KOTID", SqlDbType.VarChar, txtBillNo.Text.Length).Value = txtBillNo.Text.ToString().Trim();
                //ds = new DataSet();
                //ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                

            }
            catch (Exception ex)
            {

            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string sCustAddress = "",sCustRemarks="";
            string[] sSplitAddress = new string[10];
            int rowheight,count;
            float xleft, ytop;
            try
            {
                //sCustAddress=

                e.Graphics.PageUnit = GraphicsUnit.Millimeter;
                
                //printKOTDOC.DefaultPageSettings.Margins.Left = e.PageSettings.Margins.Left;
                //printKOTDOC.DefaultPageSettings.Margins.Left = (int)e.MarginBounds.Left;
                //printKOTDOC.DefaultPageSettings.Margins.Left = e.MarginBounds.Left;
                xleft = e.MarginBounds.Left/50;
                ytop = e.MarginBounds.Top / 50;


                e.Graphics.DrawString(GlobalClass.gsCompanyName, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 1 + xleft, 2 + ytop);
                e.Graphics.DrawString("KOT", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 20 + xleft, 8 + ytop);

                //Added by Kashif on 21st Aug 2015
                e.Graphics.DrawString("RP:", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 35 + xleft, 8 + ytop);
                e.Graphics.DrawString(ReprintCount.ToString(), new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 45 + xleft, 8 + ytop);
                //e.Graphics.DrawString(GlobalClass.gsCompanyAddress, new Font("Arial", 11, FontStyle.Regular), Brushes.Black, 10 + xleft, 2 + ytop);

                e.Graphics.DrawString("KOTID:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 3+xleft, 13+ytop);
                e.Graphics.DrawString(txtBillNo.Text, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 15+xleft, 13+ytop);

                e.Graphics.DrawString("Order Type:",new Font("Arial",9,FontStyle.Bold) , Brushes.Black, 32+xleft, 13+ytop);
                e.Graphics.DrawString(cmbOrderType.Text,new Font("Arial",9, FontStyle.Regular) , Brushes.Black, 50+xleft, 13+ytop);

                e.Graphics.DrawString("DateTime:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 3+xleft, 18+ytop);
                e.Graphics.DrawString(txtTimeDate.Text,new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 25+xleft, 18+ytop);

                e.Graphics.DrawString("Customer:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 3+xleft, 23+ytop);
                e.Graphics.DrawString(cmbCustomerDetails.Text, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 20+xleft, 23+ytop);

                sCustAddress = WordWrap(txtCustAddress.Text, 30);
                e.Graphics.DrawString("Address:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 3+xleft, 28+ytop);
                e.Graphics.DrawString(sCustAddress, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 20+xleft, 28+ytop);
                rowheight =Convert.ToInt16( 33+ytop);

                if(sCustAddress.Contains("\r\n"))
                {
                    sSplitAddress = sCustAddress.Split('\r');
                    count=Convert.ToInt32(sSplitAddress.GetLength(0));
                    count = count - 1;
                    if (count == 1)
                        rowheight = 38;
                    else if (count == 2)
                        rowheight = 43;
                    else if (count == 3)
                        rowheight = 48;
                    else if (count == 4)
                        rowheight = 53;
                    else
                        rowheight = 58;
                }

                rowheight = rowheight + 5;
                e.Graphics.DrawString("Item Details:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 0+xleft, rowheight+ytop);
                //e.Graphics.DrawString(txtCustAddress.Text, txtCustAddress.Font, Brushes.Black, 200, 140);
                e.Graphics.DrawString("Qty:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black,35+xleft, rowheight+ytop);
                e.Graphics.DrawString("Price:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 40+xleft, rowheight+ytop);
                e.Graphics.DrawString("Remarks:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 55 + xleft, rowheight + ytop);
                //e.Graphics.DrawString(txtCustAddress.Text, txtCustAddress.Font, Brushes.Black, 200, 140);
                rowheight = rowheight + 5;
                e.Graphics.DrawLine(new Pen(Color.Black,0), new Point(Convert.ToInt16( 3+xleft),Convert.ToInt16(rowheight+ytop)), new Point(Convert.ToInt16( 70+xleft),Convert.ToInt16(rowheight+ytop)));
                
                int i, height;
                height = rowheight+5;
                string sWrapItemName = "";
                int counter, iNewLineCounter;                
                string[] sSplitItemName = new string[10];
                for (i = 0; i < dgview.Rows.Count; i++)
                {
                    //Added by Kashif on 15th Nov 2014 to Wrap text
                    sWrapItemName = WordWrap(dgview.Rows[i].Cells["ItemName"].Value.ToString(), 20);
                    e.Graphics.DrawString(sWrapItemName, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 0 + xleft, height + ytop);                    //till here

                    //e.Graphics.DrawString(dgview.Rows[i].Cells["ItemName"].Value.ToString(), txtCustAddress.Font, Brushes.Black, 3+xleft, height+ytop); //commented by Kashif on 15th Nov 2014
                    e.Graphics.DrawString(dgview.Rows[i].Cells["Quantity"].Value.ToString(), txtCustAddress.Font, Brushes.Black, 35+xleft, height+ytop);
                    //e.Graphics.DrawString(dgview.Rows[i].Cells["Amount"].Value.ToString(), txtCustAddress.Font, Brushes.Black, 40+xleft, height+ytop);
                    //CHanged on 15th Nov 2014 as dicussed with Nisar Bhai to show only item unit price
                    e.Graphics.DrawString(dgview.Rows[i].Cells["UnitPrice"].Value.ToString(), txtCustAddress.Font, Brushes.Black, 40 + xleft, height + ytop);
                    sCustRemarks = dgview.Rows[i].Cells["ItemRemarks"].Value.ToString();
                    if (sCustRemarks=="")
                    {
                        sCustRemarks = "";
                    }
                    e.Graphics.DrawString(sCustRemarks, txtCustAddress.Font, Brushes.Black, 55 + xleft, height + ytop);

                    if (sWrapItemName.Contains("\r\n"))
                    {
                        sSplitItemName = sWrapItemName.Split('\r');
                        iNewLineCounter = sSplitItemName.GetLength(0);
                        iNewLineCounter = iNewLineCounter - 2;
                        if (iNewLineCounter == 0)
                            height = height + 5;
                        else if (iNewLineCounter == 1)
                            height = height + 10;
                        else if (iNewLineCounter == 2)
                            height = height + 15;
                        else if (iNewLineCounter == 3)
                            height = height + 20;
                        else if (iNewLineCounter == 4)
                            height = height + 25;
                        else
                            height = height + 30;
                    }
                    //height = height + 5;
                }
                e.Graphics.DrawLine(new Pen(Color.Black, 0), new Point(Convert.ToInt16(3 + xleft), Convert.ToInt16(height + ytop)), new Point(Convert.ToInt16(70 + xleft), Convert.ToInt16(height + ytop)));

                /*e.Graphics.DrawString("Email:", txtEmail.Font, Brushes.Black, 100, 140);
                e.Graphics.DrawString(txtEmail.Text, txtEmail.Font, Brushes.Black, 200, 140);

                e.Graphics.DrawString("Address Line 1:", txtAddressLine1.Font, Brushes.Black, 100, 160);
                e.Graphics.DrawString(txtAddressLine1.Text, txtAddressLine1.Font, Brushes.Black, 200, 160);

                e.Graphics.DrawString("Address Line 2:", txtAddressLine2.Font, Brushes.Black, 100, 180);
                e.Graphics.DrawString(txtAddressLine2.Text, txtAddressLine2.Font, Brushes.Black, 200, 180);

                e.Graphics.DrawString("Emirates:", cmbEmirate.Font, Brushes.Black, 100, 200);
                e.Graphics.DrawString(cmbEmirate.Text, txtAddressLine2.Font, Brushes.Black, 200, 200);*/

                //e.Graphics.PageUnit = GraphicsUnit.Inch;
                //e.Graphics.PageUnit = GraphicsUnit.Point;
                
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Orders", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

        }
        public static string WordWrap(string text, int width)
        {
            int pos, next;
            StringBuilder sb = new StringBuilder();

            // Lucidity check
            if (width < 1)
                return text;

            // Parse each line of text
            for (pos = 0; pos < text.Length; pos = next)
            {
                // Find end of
                int eol = text.IndexOf(Environment.NewLine, pos);
                if (eol == -1)
                    next = eol = text.Length;
                else
                    next = eol + Environment.NewLine.Length;

                // Copy this line of text, breaking into smaller lines as needed
                if (eol > pos)
                {
                    do
                    {
                        int len = eol - pos;
                        if (len > width)
                            len = BreakLine(text, pos, width);
                        sb.Append(text, pos, len);
                        sb.Append(Environment.NewLine);

                        // Trim whitespace following break
                        pos += len;
                        while (pos < eol && Char.IsWhiteSpace(text[pos]))
                            pos++;
                    } while (eol > pos);
                }
                else sb.Append(Environment.NewLine); // Empty line
            }
            return sb.ToString();
        }
        private static int BreakLine(string text, int pos, int max)
        {
            // Find last whitespace in line
            int i = max;
            while (i >= 0 && !Char.IsWhiteSpace(text[pos + i]))
                i--;

            // If no whitespace found, break at maximum length
            if (i < 0)
                return max;

            // Find start of whitespace
            while (i >= 0 && Char.IsWhiteSpace(text[pos + i]))
                i--;

            // Return length of text before whitespace
            return i + 1;
        }

        private void frmOrders_KeyPress(object sender, KeyPressEventArgs e)
       
       {
            //if (e.KeyChar ==Convert.ToChar(Keys.F5))
            //{
            //    btnSearch_Click(sender, e);
            //}
        }

        private void frmOrders_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form is frmSearchCustomer)
                        {
                            MessageBox.Show("Search Customer Window is already open", "Orders", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }

                    btnSearch_Click(sender, e);
                }
                if (e.KeyCode == Keys.F10)
                {
                    button1_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in frmOrders_KeyDown:"+ex.Message.ToString());
            }

        }

        private void txtItemcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtItemcode.Text.Trim() != "")
                {
                    txtItemcode_Leave(sender, e);
                    txtQuantity.Focus();
                    txtQuantity.SelectAll();
                }
                else
                {
                    //GlobalClass.WriteLog(ex.Message.ToString());
                    MessageBox.Show("Please Enter Item Code", "Orders", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtItemcode.Focus();
                }
                
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == Convert.ToChar(Keys.Enter))
            //{
            //    //txtQuantity_Leave(sender, e);
            //}
            int i;
            string sItemname;
            
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    if (btnOK.Enabled == false)
                    {
                        MessageBox.Show("This KOT is already Saved. Modification is NOT allowed.", "KOT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    Decimal dc;
                    dc = Convert.ToDecimal(txtItemPrice.Text) * Convert.ToDecimal(txtQuantity.Text);
                    txtAmount.Text = dc.ToString();

                    sItemname = cmbItems.Text.ToString();
                    GlobalClass.WriteLog("Before Removing Already added items from datagrid");
                    for (i = 0; i < dgview.Rows.Count; i++)
                    {
                        if (sItemname == dgview.Rows[i].Cells["ItemName"].Value.ToString().Trim())
                        {
                            dgview.Rows.RemoveAt(i);
                        }
                    }

                    //if (GlobalClass.gsMenuItemSelected == cmbItems.Text.ToString().Trim())
                    //{
                    //    dgview.Rows.RemoveAt(GlobalClass.giMenuItemRowSelectedIndex);
                    //}

                    DataGridViewRow row = new DataGridViewRow();
                    if (txtItemRemarks.Text == "")
                        txtItemRemarks.Text = " ";

                    row.CreateCells(dgview, txtItemcode.Text, cmbItems.Text, txtQuantity.Text, txtItemPrice.Text, txtAmount.Text,txtItemRemarks.Text);
                    //row.ReadOnly = false;
                    //row.ReadOnly = true;
                    
                    //this.dgview.Rows.Add(row);
                    dgview.Rows.Add(row);

                    txtItemcode.Focus();

                    txtItemcode.Clear();
                    txtQuantity.Clear();

                    cmbItems.SelectedIndex = 0;
                    txtItemPrice.Text = "";
                    txtAmount.Text = "";
                    txtItemRemarks.Text = "";
                    txtQuantity.Text = "1";
                    //dgview.ReadOnly = false;
                    //dgview.AllowUserToDeleteRows = true;
                }
            }
            catch (Exception Ex)
            {
                GlobalClass.WriteLog("Error in txtQuantity_KeyPress:"+Ex.Message.ToString());
                MessageBox.Show(Ex.Message.ToString(), "Error in KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgview_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgview.Rows.Count >= 1)
                {
                    GlobalClass.giMenuItemRowSelectedIndex = 0;
                    GlobalClass.gsMenuItemSelected = "";

                    GlobalClass.giMenuItemRowSelectedIndex = dgview.CurrentCell.RowIndex;
                    GlobalClass.gsMenuItemSelected = dgview.Rows[GlobalClass.giMenuItemRowSelectedIndex].Cells["ItemName"].Value.ToString();

                    cmbItems.Text = dgview.Rows[GlobalClass.giMenuItemRowSelectedIndex].Cells["ItemName"].Value.ToString();
                    txtQuantity.Text = dgview.Rows[GlobalClass.giMenuItemRowSelectedIndex].Cells["Quantity"].Value.ToString();
                    txtItemPrice.Text = dgview.Rows[GlobalClass.giMenuItemRowSelectedIndex].Cells["UnitPrice"].Value.ToString();
                    txtAmount.Text = dgview.Rows[GlobalClass.giMenuItemRowSelectedIndex].Cells["Amount"].Value.ToString();
                    txtItemcode.Text = dgview.Rows[GlobalClass.giMenuItemRowSelectedIndex].Cells["ItemCode"].Value.ToString();
                }
                //txtQuantity.Focus();
                //txtQuantity.SelectAll();
            }
                catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Error in KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void groupBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void txtBillNo_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void cmbOrderType_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == Convert.ToChar(Keys.F5))
            //{
            //    btnSearch_Click(sender, e);
            //}
        }

        private void cmbItems_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    if (e.KeyChar == Convert.ToChar(Keys.Enter))
            //    {
            //        txtQuantity.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
        }

        private void btnCancelKOT_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (dgview.Rows.Count == 0)
                {
                    MessageBox.Show("Please select KOT to cancel", "KOT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (MessageBox.Show("Are you sure to cancel KOT", "KOT", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                {
                    return;
                }

                int iResult;
                string sFlag = "CANCELKOT";
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_MaintainKOT";
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                cmd.Parameters.Add("@itemcode", SqlDbType.VarChar, txtItemcode.TextLength).Value = txtItemcode.Text.Trim();
                cmd.Parameters.Add("@KOTID", SqlDbType.VarChar, txtBillNo.TextLength).Value = txtBillNo.Text.Trim();
                cmd.Parameters.Add("@Itemname", SqlDbType.VarChar, GlobalClass.gsLoggedInUser.Length).Value = GlobalClass.gsLoggedInUser.Trim();
                //cmd.Parameters.Add("@Quantity", SqlDbType.VarChar, dgview.Rows[j].Cells[1].Value.ToString().Length).Value = dgview.Rows[j].Cells[1].Value.ToString().Trim();
                //cmd.Parameters.Add("@UnitPrice", SqlDbType.VarChar, dgview.Rows[j].Cells[2].Value.ToString().Length).Value = dgview.Rows[j].Cells[2].Value.ToString().Trim();
                //cmd.Parameters.Add("@Amount", SqlDbType.VarChar, dgview.Rows[j].Cells[3].Value.ToString().Length).Value = dgview.Rows[j].Cells[3].Value.ToString().Trim();
                //cmd.Parameters.Add("@Ordertype", SqlDbType.VarChar, cmbOrderType.Text.ToString().Length).Value = cmbOrderType.Text.ToString().Trim();

                iResult = cmd.ExecuteNonQuery();
                if (iResult>= 0)
                {
                    MessageBox.Show("KOT Cancelled Successfully", "KOT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    ClearForm();
                }

            }
            catch (Exception ex)
            {
                    GlobalClass.WriteLog("Error in btnCancelKOT_Click:"+ex.Message.ToString());
                    MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cmbCustomerDetails_Click(object sender, EventArgs e)
        {


            //try
            //{
            //    string sFlag;
            //    sFlag = "FETCHCUSTOMER";
            //    cmbCustomerDetails.Items.Clear();
            //    GlobalClass.cmd = new SqlCommand();
            //    GlobalClass.cmd.Connection = GlobalClass.gCon;
            //    GlobalClass.cmd.CommandText = "SP_FetchMenuDetails";
            //    GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
            //    GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
            //    ds = new DataSet();
            //    ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
            //    for (int i = 0; i < ds.Tables["Result"].Rows.Count; i++)
            //        cmbCustomerDetails.Items.Add(ds.Tables["Result"].Rows[i]["CustomerName"].ToString());
            //}
            //catch (Exception ex)
            //{
            //}
        }

        private void cmbCustomerDetails_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    if (e.KeyChar == Convert.ToChar(Keys.Enter))
            //    {
            //        cmbCustomerDetails_Leave(sender, e);
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
        }

        private void cmbCustomerDetails_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbCustomerDetails_Leave(sender, e);
                    //txtItemcode.Focus();
                    cmbSalesBy.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cmbOrderType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbCustomerDetails.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cmbSalesBy_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    txtItemcode.Focus();
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cmbItems_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbItems_Leave(sender, e);
                    txtQuantity.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtBillNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCustAddress_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    txtCustRemarks.Focus();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtCustRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    cmbSalesBy.Focus();
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
            }
        }

        private void txtCustPhoneNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    txtCustRemarks.Focus();
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
            }
        }

        private void txtCustPhoneNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgview_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //try
            //{
            //    if (btnOK.Enabled == true)
            //    {
            //        dgview.Rows.RemoveAt(e.Row.Index);

            //    }
            //}
            //catch (Exception ex)
            //{
            //}
        }

        private void dgview_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //try
            //{
            //    if (btnOK.Enabled == true)
            //    {
            //        dgview.Rows.RemoveAt(e.Row.Index);

            //    }
            //}
            //catch (Exception ex)
            //{
            //}
        }

        private void dgview_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //try
            //{
            //    if (btnOK.Enabled == true)
            //    {
            //        dgview.Rows.RemoveAt(e.RowIndex);

            //    }
            //}
            //catch (Exception ex)
            //{
            //}
            //GlobalClass.CaptureAuditTrail("
        }

        private void dgview_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dgview_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgview_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }

        private void cmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrderType.Text == "TA" || cmbOrderType.Text=="Take Away")
            {
                cmbCustomerDetails.Text = "Take Away";
            }
            else if (cmbOrderType.Text == "HD" || cmbOrderType.Text=="Home Delivery")
            {
                cmbCustomerDetails.Text = "Home Delivery";
            }
            else
            {
                cmbCustomerDetails.Text = "Table";
            }
        }

        private void cmbOrderType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbOrderType.Text == "TA" || cmbOrderType.Text.Replace(" ", "").ToUpper() == "TAKEAWAY")
            {
                cmbCustomerDetails.Text = "Take Away";
            }
            else if (cmbOrderType.Text == "HD" || cmbOrderType.Text.Replace(" ", "").ToUpper() == "HOMEDELIVERY")
            {
                cmbCustomerDetails.Text = "Home Delivery";
            }
            else
            {
                cmbCustomerDetails.Text = "Table";
            }
        }

        private void cmbOrderType_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            frmViewKOT fr = new frmViewKOT();
            fr.KOTdetailsshared += new frmViewKOT.ShareKOTDetails(fr_KOTdetailsshared);

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmViewKOT)
                {
                    MessageBox.Show("View KOT Window is already open", "KOT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            fr.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            fr.MdiParent = this.ParentForm;
            fr.Show();
        }
    }
}
