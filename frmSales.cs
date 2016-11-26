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
    public partial class frmSales : Form
    {
        public frmSales()
        {
            InitializeComponent();
        }

        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        DataTable dtNewItem = new DataTable();
        DataTable dtNewOrder = new DataTable();
        DataGridViewCheckBoxCell ch = new DataGridViewCheckBoxCell();
        string sFlag;
        string sKotid,sOrderType,sItemNameDeleted;
        private void timer1_Tick(object sender, EventArgs e)
        {
                lblDatetime.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
        }

        private void btnManualAddress_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustMaster fr = new frmCustMaster();
                fr.MdiParent = this.ParentForm;
                fr.Show();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                frmSearchedInvoices fr = new frmSearchedInvoices();
                fr.EvtShareInvoice += new frmSearchedInvoices.ShareInvoiceno(fr_EvtShareInvoice);
                //this.IsMdiContainer = true;
                //this.TopLevel = true;
                //fr.MdiParent =this;
                fr.MdiParent = this.ParentForm;
                fr.Show();
            }
            catch (Exception ex)
            {
            }
        }
        private void fr_EvtShareInvoice(object sender, ShareInvoiceArgs e)
        {
            try
            {
                string sInvoiceNo = e.InvoiceNo.ToString();
                PopulateSalesForm(sInvoiceNo);
            }
            catch (Exception ex)
            {
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void PopulateSalesForm(string sInvoiceNo = "Default")
        {
            try
            {
                string sInvoiceType = "";
                cmd = new SqlCommand();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_FetchInvoiceDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 30).Value = "FETCHINVOICEHEADER";
                cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, sInvoiceNo.Length).Value = sInvoiceNo;
                ds = new DataSet();
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                txtInvoiceNo.Text = sInvoiceNo;
                txtOrdersCustName.Text = ds.Tables["Result"].Rows[0]["CustomerName"].ToString();
                txtOrdersCustAddress.Text = ds.Tables["Result"].Rows[0]["CustomerAddress"].ToString();
                txtOrderssalesman.Text = ds.Tables["Result"].Rows[0]["Ordersalesby"].ToString();
                cmbDeliveredBy.Text = ds.Tables["Result"].Rows[0]["OrderDeliveredby"].ToString();
                txtOrdersCustRemarks.Text = ds.Tables["Result"].Rows[0]["CustomerRemarks"].ToString();
                txtOrdersCustomerPhone.Text = ds.Tables["Result"].Rows[0]["CustomerPhoneNo"].ToString();
                cmbOrderType.Text = ds.Tables["Result"].Rows[0]["OrderType"].ToString();
                sInvoiceType = ds.Tables["Result"].Rows[0]["InvoiceType"].ToString();
                if (sInvoiceType == "CASH" || sInvoiceType == "CREDIT")
                {
                    EnableDisableRadioButton(false);
                }
                else if (sInvoiceType == "CASHRETURN" || sInvoiceType == "CREDITRETURN")
                {
                    EnableDisableRadioButton(true);
                }
                cmd = new SqlCommand();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_FetchInvoiceDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 30).Value = "FETCHINVOICEDETAIL";
                cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, sInvoiceNo.Length).Value = sInvoiceNo;
                ds = new DataSet();
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                dgDisplayKOTDetails.DataSource = ds.Tables["Result"];
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in PopulateSalesForm:" + ex.Message.ToString());
            }
        }
        public void EnableDisableRadioButton(Boolean flag)

        {
            try
            {
                if (!flag)
                {
                    rbtnCrInvReturn.Enabled = flag;
                    rbtnInvReturn.Enabled = flag;
                }
                else
                {
                    rbtnInvCash.Enabled = false;
                    rbtnInvCr.Enabled = false;
                }
                btnSave.Enabled = false;
                txtSalesQuantity.Enabled = false;
                dgDisplayKOTDetails.ReadOnly = true;
            }
            catch (Exception ex)
            {
            }

        }

        private void btnRecallKOT_Click(object sender, EventArgs e)
        {
            /*try
            {
                //frmSearchedKOT fr = new frmSearchedKOT();
                //fr.Show();
            }
            catch (Exception ex)
            {
            }*/
            try
            {
                Boolean bformfound = false;
                string sOrderType;
                foreach (Form form in Application.OpenForms)
                {
                    if (form is frmRecalledKOT)
                    {
                        bformfound = true;
                        MessageBox.Show("Recalled KOT window is already Open", "KOT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }
                sOrderType = cmbOrderType.Text.ToString();
                if (!bformfound)
                {
                    frmRecalledKOT frm = new frmRecalledKOT(sOrderType);
                    frm.EvtKOTRecalled+=new frmRecalledKOT.ShareRecalledKOT(frm_EvtKOTRecalled);
                    //this.IsMdiContainer = true;
                    //frm.MdiParent = this;
                    frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                    //frm.TopLevel = false;
                    frm.MdiParent = this.ParentForm;
                    frm.Show();
                }

                ////Commented By Kashif on 18th Jan 2013 to execute it on Recalled KOT form Load
                //sFlag = "SEARCH";
                //cmd = new SqlCommand();
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Connection = GlobalClass.gCon;
                //cmd.CommandText = "SP_MaintainKOT";
                //cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                ///*cmd.Parameters.Add("@itemcode", SqlDbType.VarChar, txtItemcode.TextLength).Value = txtItemcode.Text.Trim();
                //cmd.Parameters.Add("@KOTID", SqlDbType.VarChar, txtBillNo.TextLength).Value = txtBillNo.Text.Trim();
                //cmd.Parameters.Add("@Itemname", SqlDbType.VarChar, dgview.Rows[j].Cells[0].Value.ToString().Length).Value = dgview.Rows[j].Cells[0].Value.ToString().Trim();
                //cmd.Parameters.Add("@Quantity", SqlDbType.VarChar, dgview.Rows[j].Cells[1].Value.ToString().Length).Value = dgview.Rows[j].Cells[1].Value.ToString().Trim();
                //cmd.Parameters.Add("@UnitPrice", SqlDbType.VarChar, dgview.Rows[j].Cells[2].Value.ToString().Length).Value = dgview.Rows[j].Cells[2].Value.ToString().Trim();
                //cmd.Parameters.Add("@Amount", SqlDbType.VarChar, dgview.Rows[j].Cells[3].Value.ToString().Length).Value = dgview.Rows[j].Cells[3].Value.ToString().Trim();*/
                //cmd.Parameters.Add("@Ordertype", SqlDbType.VarChar, cmbOrderType.Text.ToString().Length).Value = cmbOrderType.Text.ToString().Trim();
                //ds = new DataSet();
                //ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                //if(ds.Tables["Result"].Rows.Count>0)
                //    dgInvSearchedKOT.DataSource = ds.Tables["Result"];
                ////MessageBox.Show(ds.Tables["Result"].Rows.Count.ToString() +" KOT Recalled", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //cmd = null;
                ////till here
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

        }
        private void frm_EvtKOTRecalled(object sender, ShareRecalledKOTArgs e)
        {

            try
            {
                int i, iRowIndex;
                if (!GlobalClass.gbNewOrder)
                {
                    GlobalClass.gbOrderSelectedToPrint = true;
                    //i = e.ColumnIndex;
                    //if (i != 0)
                    //{
                    //    MessageBox.Show("Please Select Order to print Invoice", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    //    return;
                    //}
                    //iRowIndex = dgInvSearchedKOT.CurrentCell.RowIndex;

                    //sKotid = dgInvSearchedKOT.Rows[iRowIndex].Cells["KOTID"].Value.ToString().Trim();
                    ////txtInvoiceNo.Text = dgInvSearchedKOT.Rows[iRowIndex].Cells["OrderNo"].Value.ToString().Trim();
                    //txtOrdersCustName.Text = dgInvSearchedKOT.Rows[iRowIndex].Cells["Customername"].Value.ToString().Trim();
                    //txtOrdersCustAddress.Text = dgInvSearchedKOT.Rows[iRowIndex].Cells["Customeraddress"].Value.ToString().Trim();
                    //txtOrdersCustRemarks.Text = dgInvSearchedKOT.Rows[iRowIndex].Cells["CustomerRemarks"].Value.ToString().Trim();
                    //txtOrderssalesman.Text = dgInvSearchedKOT.Rows[iRowIndex].Cells["Salesby"].Value.ToString().Trim();
                    //txtOrdersCustomerPhone.Text = dgInvSearchedKOT.Rows[iRowIndex].Cells["CustomerPhoneNo"].Value.ToString().Trim();
                    //sOrderType = dgInvSearchedKOT.Rows[iRowIndex].Cells["OrderType"].Value.ToString().Trim();

                    sKotid = e.KOTID.ToString().Trim();
                    //txtInvoiceNo.Text = dgInvSearchedKOT.Rows[iRowIndex].Cells["OrderNo"].Value.ToString().Trim();
                    txtOrdersCustName.Text = e.CustomerName.ToString().Trim();
                    txtOrdersCustAddress.Text = e.CustomerAddress.ToString().Trim();
                    txtOrdersCustRemarks.Text = e.CustomerRemarks.ToString().Trim();
                    txtOrderssalesman.Text = e.SalesBy.ToString().Trim();
                    txtOrdersCustomerPhone.Text = e.CustomerPhone.ToString().Trim();
                    sOrderType = e.OrderType.ToString().Trim();
                    cmbOrderType.Text = e.OrderType.ToString().Trim();

                    GlobalClass.WriteLog("Before Fetching Invoice Numbers");
                    //cmd = new SqlCommand();
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Connection = GlobalClass.gCon;
                    //cmd.CommandText = "SP_GetInvoiceCounter";
                    //txtInvoiceNo.Text = cmd.ExecuteScalar().ToString().PadLeft(7, '0');
                    InvoiceGenerator();

                    GlobalClass.WriteLog("Invoice Number Fetched Successfully. Invoice No:" + txtInvoiceNo.Text);

                    GlobalClass.gbOrderSelected = true;

                    sFlag = "FETCHKOT";
                    cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = GlobalClass.gCon;
                    cmd.CommandText = "SP_MaintainKOTCUstomer";
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();

                    if (sOrderType != "Home Delivery" && sOrderType != "Take Away")
                    {
                        cmd.Parameters.Add("@Ordertype", SqlDbType.VarChar, sOrderType.Length).Value = sOrderType.Trim();
                    }
                    else
                    {
                        cmd.Parameters.Add("@KOTID", SqlDbType.VarChar, sKotid.Length).Value = sKotid.Trim();

                    }
                    //cmd.Parameters.Add("@KOTID", SqlDbType.VarChar, sKotid.Length).Value =sKotid.Trim();
                    /*cmd.Parameters.Add("@Itemname", SqlDbType.VarChar, dgview.Rows[j].Cells[0].Value.ToString().Length).Value = dgview.Rows[j].Cells[0].Value.ToString().Trim();
                    cmd.Parameters.Add("@Quantity", SqlDbType.VarChar, dgview.Rows[j].Cells[1].Value.ToString().Length).Value = dgview.Rows[j].Cells[1].Value.ToString().Trim();
                    cmd.Parameters.Add("@UnitPrice", SqlDbType.VarChar, dgview.Rows[j].Cells[2].Value.ToString().Length).Value = dgview.Rows[j].Cells[2].Value.ToString().Trim();
                    cmd.Parameters.Add("@Amount", SqlDbType.VarChar, dgview.Rows[j].Cells[3].Value.ToString().Length).Value = dgview.Rows[j].Cells[3].Value.ToString().Trim();
                    cmd.Parameters.Add("@Ordertype", SqlDbType.VarChar, cmbOrderType.Text.ToString().Length).Value = cmbOrderType.Text.ToString().Trim();*/
                    ds = new DataSet();
                    dtNewItem = new DataTable();
                    ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                    dgDisplayKOTDetails.DataSource = ds.Tables["Result"];

                    dtNewItem = ds.Tables["Result"].Copy();

                    cmd = null;

                    Decimal dSum;
                    dSum = 0;
                    for (int j = 0; j < ds.Tables["Result"].Rows.Count; j++)
                    {
                        dSum = dSum + Convert.ToDecimal(ds.Tables["Result"].Rows[j]["Amount"]);
                        //MessageBox.Show(ds.Tables["Result"].Rows[i]["Amount"].ToString(),"Saels",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                    }
                    txtNetAmount.Text = dSum.ToString("0,0.00");
                    dgDisplayKOTDetails.Columns["KotItemUnitPrice"].ReadOnly = true;
                    dgDisplayKOTDetails.Columns["KotItem"].ReadOnly = true;
                    dgDisplayKOTDetails.Columns["Amount"].ReadOnly = true;

                }
            }

            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }


        private void frmSales_Load(object sender, EventArgs e)
        {
            try
            {
                int iCounter;
                GlobalClass.FetchTableNames();
                for (iCounter = 0; iCounter < GlobalClass.arrTablenames.GetUpperBound(0) && GlobalClass.arrTablenames[iCounter] != null; iCounter++)
                {
                    cmbOrderType.Items.Add(GlobalClass.arrTablenames[iCounter].ToString());
                }
                GlobalClass.WriteLog("Before Fetching Menu details in Invoice");
                sFlag = "LOAD";
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_FetchMenuDetails";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                ds = new DataSet();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                for (int i = 0; i < ds.Tables["Result"].Rows.Count; i++)
                    cmbSalesItemName.Items.Add(ds.Tables["Result"].Rows[i]["ItemName"].ToString());

                GlobalClass.WriteLog("Menu details fetched successfully in Invoice");
                sFlag = "FETCHEMPNAME";
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_FetchMenuDetails";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                ds = new DataSet();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                for (int i = 0; i < ds.Tables["Result"].Rows.Count; i++)
                    cmbDeliveredBy.Items.Add(ds.Tables["Result"].Rows[i]["Employeename"].ToString().Trim());


                cmbCreditCardType.Items.Add("VISA");
                cmbCreditCardType.Items.Add("MASTERCARD");
                cmbCreditCardType.Items.Add("AMEX");
                cmbCreditCardType.Items.Add("DINERS");
                cmbCreditCardType.Items.Add("OTHERS");

                rbtnInvCash.Checked = true;
                GlobalClass.gsInvoiceType = "CASH";

                rbtnPayCash.Checked = true;
                GlobalClass.gsInvPaymentOptions = "CASH";

                cmbDeliveredBy.SelectedIndex = -1;
                InvoiceGenerator();
                txtEODDate.Text = GlobalClass.MaintainEOD("LOAD");
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in frmSales_Load:"+ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgInvSearchedKOT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i;
                string sKotid;    
                //ch = (DataGridViewCheckBoxCell)dgInvSearchedKOT.Rows[dgInvSearchedKOT.CurrentCell.RowIndex].Cells[0];
                
                //if (ch.Selected )
                  //  MessageBox.Show("Not Checked", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                //i = dgInvSearchedKOT.CurrentCell.RowIndex;
                //sKotid = dgInvSearchedKOT.Rows[dgInvSearchedKOT.CurrentCell.RowIndex].Cells[1].ToString().Trim();
                
            }
            catch(Exception ex)

            {
                GlobalClass.WriteLog(ex.Message.ToString());
            }

        }

        private void dgInvSearchedKOT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ////try
            ////{
            ////    int i,iRowIndex;
            ////    GlobalClass.gbOrderSelectedToPrint = true;
            ////    i = e.ColumnIndex;
            ////    //if (i != 0)
            ////    //{
            ////    //    MessageBox.Show("Please Select Order to print Invoice", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            ////    //    return;
            ////    //}
            ////    iRowIndex = dgInvSearchedKOT.CurrentCell.RowIndex;

            ////    sKotid = dgInvSearchedKOT.Rows[iRowIndex].Cells["KOTID"].Value.ToString().Trim();
            ////    //txtInvoiceNo.Text = dgInvSearchedKOT.Rows[iRowIndex].Cells["OrderNo"].Value.ToString().Trim();
            ////    txtOrdersCustName.Text = dgInvSearchedKOT.Rows[iRowIndex].Cells["Customername"].Value.ToString().Trim();
            ////    txtOrdersCustAddress.Text = dgInvSearchedKOT.Rows[iRowIndex].Cells["Customeraddress"].Value.ToString().Trim();
            ////    txtOrdersCustRemarks.Text=dgInvSearchedKOT.Rows[iRowIndex].Cells["CustomerRemarks"].Value.ToString().Trim();
            ////    txtOrderssalesman.Text = dgInvSearchedKOT.Rows[iRowIndex].Cells["Salesby"].Value.ToString().Trim();
            ////    txtOrdersCustomerPhone.Text = dgInvSearchedKOT.Rows[iRowIndex].Cells["CustomerPhoneNo"].Value.ToString().Trim();
            ////    sOrderType = dgInvSearchedKOT.Rows[iRowIndex].Cells["OrderType"].Value.ToString().Trim();

            ////    GlobalClass.WriteLog("Before Fetching Invoice Numbers");
            ////    cmd = new SqlCommand();
            ////    cmd.CommandType = CommandType.StoredProcedure;
            ////    cmd.Connection = GlobalClass.gCon;
            ////    cmd.CommandText = "SP_GetInvoiceCounter";
            ////    txtInvoiceNo.Text = cmd.ExecuteScalar().ToString().PadLeft(7,'0');

            ////    GlobalClass.WriteLog("Invoice Number Fetched Successfully. Invoice No:" + txtInvoiceNo.Text);
                
            ////    GlobalClass.gbOrderSelected = true;

            ////    sFlag = "FETCHKOT";
            ////    cmd = new SqlCommand();
            ////    cmd.CommandType = CommandType.StoredProcedure;
            ////    cmd.Connection = GlobalClass.gCon;
            ////    cmd.CommandText = "SP_MaintainKOTCUstomer";
            ////    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();

            ////    if (sOrderType != "Home Delivery" && sOrderType != "Take Away")
            ////    {
            ////        cmd.Parameters.Add("@Ordertype", SqlDbType.VarChar, sOrderType.Length).Value = sOrderType.Trim();
            ////    }
            ////    else
            ////    {
            ////        cmd.Parameters.Add("@KOTID", SqlDbType.VarChar, sKotid.Length).Value = sKotid.Trim();

            ////    }
            ////    //cmd.Parameters.Add("@KOTID", SqlDbType.VarChar, sKotid.Length).Value =sKotid.Trim();
            ////    /*cmd.Parameters.Add("@Itemname", SqlDbType.VarChar, dgview.Rows[j].Cells[0].Value.ToString().Length).Value = dgview.Rows[j].Cells[0].Value.ToString().Trim();
            ////    cmd.Parameters.Add("@Quantity", SqlDbType.VarChar, dgview.Rows[j].Cells[1].Value.ToString().Length).Value = dgview.Rows[j].Cells[1].Value.ToString().Trim();
            ////    cmd.Parameters.Add("@UnitPrice", SqlDbType.VarChar, dgview.Rows[j].Cells[2].Value.ToString().Length).Value = dgview.Rows[j].Cells[2].Value.ToString().Trim();
            ////    cmd.Parameters.Add("@Amount", SqlDbType.VarChar, dgview.Rows[j].Cells[3].Value.ToString().Length).Value = dgview.Rows[j].Cells[3].Value.ToString().Trim();
            ////    cmd.Parameters.Add("@Ordertype", SqlDbType.VarChar, cmbOrderType.Text.ToString().Length).Value = cmbOrderType.Text.ToString().Trim();*/
            ////    ds = new DataSet();
            ////    dtNewItem = new DataTable();
            ////    ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
            ////    dgDisplayKOTDetails.DataSource = ds.Tables["Result"];

            ////    dtNewItem = ds.Tables["Result"].Copy();

            ////    cmd = null;

            ////    int iSum;
            ////    iSum = 0;
            ////    for (int j = 0; j < ds.Tables["Result"].Rows.Count; j++)
            ////    {
            ////        iSum = iSum + Convert.ToInt16(ds.Tables["Result"].Rows[j]["Amount"]);
            ////        //MessageBox.Show(ds.Tables["Result"].Rows[i]["Amount"].ToString(),"Saels",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            ////    }
            ////    txtNetAmount.Text = iSum.ToString("0,0.00");
            ////    dgDisplayKOTDetails.Columns["KotItemUnitPrice"].ReadOnly = true;
            ////    dgDisplayKOTDetails.Columns["KotItem"].ReadOnly = true;
            ////    dgDisplayKOTDetails.Columns["Amount"].ReadOnly = true;
                           
            ////}
            ////catch (Exception ex)
            ////{
            ////    GlobalClass.WriteLog(ex.Message.ToString());
            ////    MessageBox.Show(ex.Message.ToString(), "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            ////}
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearForm();
                //MessageBox.Show("Page Cleared ", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        public void ClearForm()
        {
            try
            {
                dgDisplayKOTDetails.DataSource = null;
                dgInvSearchedKOT.DataSource = null;
                txtInvoiceNo.Text = "";
                txtOrdersCustAddress.Text = "";
                txtOrdersCustName.Text = "";
                txtOrdersCustRemarks.Text = "";
                txtOrdersCustomerPhone.Text = "";
                txtOrderssalesman.Text = "";
                txtNetAmount.Text = "";
                txtDiscAmount.Text = "";
                txtDiscountPer.Text = "";
                txtSalesAmount.Text = "";
                txtSalesPrice.Text = "";
                txtSalesItemCode.Text = "";
                cmbSalesItemName.SelectedIndex = 0;
                txtSalesQuantity.Text = "";
                txtPaidAmount.Text = "";
                GlobalClass.gbNewOrder = true; ;
                cmbOrderType.SelectedIndex = -1;
                cmbSalesItemName.SelectedIndex = -1;
                cmbDeliveredBy.SelectedIndex = -1;

                btnSave.Enabled = true;
                txtSalesQuantity.Enabled = true;
                dgDisplayKOTDetails.ReadOnly = false;
                rbtnPayCash.Checked = true;
                rbtnInvCash.Checked = true;
                cmbCreditCardType.SelectedIndex = -1;
                txtInvoiceNo.Enabled = false;
                txtInvoiceNo.ReadOnly = true;
                cmbCreditCardType.Enabled = false;
                dtNewItem = new DataTable();
                InvoiceGenerator();
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgDisplayKOTDetails.Rows.Count == 0)
                {
                    MessageBox.Show("No Items for Invoice Reprint", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                //PrintInvoiceInCrystalReport();
                PrintInvoice();
                ClearForm();
                InvoiceGenerator();   
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if ( dgInvSearchedKOT.Rows.Count==0)
                //{
                //    MessageBox.Show("Please Recall KOT to Print Invoice", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //    btnRecallKOT.Focus();
                //    return;
                //}
                //if (!GlobalClass.gbOrderSelectedToPrint)
                //{
                //    MessageBox.Show("Please Select KOT to Print Invoice", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //    dgInvSearchedKOT.Focus();
                //    return;
                //}
                int i;
                int iResult;
                i = dgDisplayKOTDetails.Rows.Count;

                //i = dgview.Rows.Count;
                if (i == 0)
                {
                    MessageBox.Show("No Items for Invoice", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (GlobalClass.gsInvPaymentOptions == "CREDITCARD" && cmbCreditCardType.Text == "")
                {
                    MessageBox.Show("Please Select Credit Card Type", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                
                //if (GlobalClass.gbOrderChanged)
                //{
                //    sFlag = "ORDERCHANGE";
                //    cmd = new SqlCommand();
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Connection = GlobalClass.gCon;
                //    cmd.CommandText = "SP_MaintainKOT";
                //    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                //    //cmd.Parameters.Add("@itemcode", SqlDbType.VarChar, dgDisplayKOTDetails.Rows[j].Cells["ItemCode"].Value.ToString().Length).Value = dgDisplayKOTDetails.Rows[j].Cells["ItemCode"].Value.ToString().Trim();
                //    cmd.Parameters.Add("@KOTID", SqlDbType.VarChar, sKotid.Length).Value = sKotid.Trim();
                //    iResult = cmd.ExecuteNonQuery();
                cmd = null;
                sOrderType = cmbOrderType.Text.ToString();
                sFlag = "ADD";
                for (int j = 0; j < i; j++)
                {
                    cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = GlobalClass.gCon;
                    cmd.CommandText = "SP_MaintainInvoiceItems";
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                    cmd.Parameters.Add("@itemcode", SqlDbType.VarChar, dgDisplayKOTDetails.Rows[j].Cells["ItemCode"].Value.ToString().Length).Value = dgDisplayKOTDetails.Rows[j].Cells["ItemCode"].Value.ToString().Trim();
                    //cmd.Parameters.Add("@KOTID", SqlDbType.VarChar, sKotid.Length).Value = sKotid.Trim();
                    
                    cmd.Parameters.Add("@Itemname", SqlDbType.VarChar, dgDisplayKOTDetails.Rows[j].Cells["KOTItem"].Value.ToString().Length).Value = dgDisplayKOTDetails.Rows[j].Cells["KOTItem"].Value.ToString().Trim();
                    cmd.Parameters.Add("@Quantity", SqlDbType.VarChar, dgDisplayKOTDetails.Rows[j].Cells["KotItemQty"].Value.ToString().Length).Value = dgDisplayKOTDetails.Rows[j].Cells["KotItemQty"].Value.ToString().Trim();
                    cmd.Parameters.Add("@UnitPrice", SqlDbType.VarChar, dgDisplayKOTDetails.Rows[j].Cells["KotItemUnitPrice"].Value.ToString().Length).Value = dgDisplayKOTDetails.Rows[j].Cells["KotItemUnitPrice"].Value.ToString().Trim();
                    cmd.Parameters.Add("@Amount", SqlDbType.VarChar, dgDisplayKOTDetails.Rows[j].Cells["Amount"].Value.ToString().Length).Value = dgDisplayKOTDetails.Rows[j].Cells["Amount"].Value.ToString().Trim();
                    cmd.Parameters.Add("@Ordertype", SqlDbType.VarChar, sOrderType.Length).Value = sOrderType.Trim();
                    cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, txtInvoiceNo.Text.Length).Value = txtInvoiceNo.Text.Trim();
                    cmd.Parameters.Add("@InvoiceCreatedby", SqlDbType.VarChar, GlobalClass.gsLoggedInUser.Length).Value = GlobalClass.gsLoggedInUser.Trim();
                    
                    iResult = cmd.ExecuteNonQuery();
                    cmd = null;
                }
                //    GlobalClass.gbOrderChanged = false;
                //}
                
                sFlag = "SAVE";
                cmd = new SqlCommand();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_MaintainOrders";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                if (GlobalClass.gbNewOrder)
                    sKotid = "";

                cmd.Parameters.Add("@KOtid", SqlDbType.VarChar, sKotid.Length).Value = sKotid.Trim();
                cmd.Parameters.Add("@CustName", SqlDbType.VarChar, txtOrdersCustName.Text.Length).Value = txtOrdersCustName.Text.Trim();
                cmd.Parameters.Add("@CustAddress", SqlDbType.VarChar, txtOrdersCustAddress.Text.Length).Value = txtOrdersCustAddress.Text.Trim();
                cmd.Parameters.Add("@Salesby", SqlDbType.VarChar, txtOrderssalesman.Text.Length).Value = txtOrderssalesman.Text.Trim();
                cmd.Parameters.Add("@Deliveredby", SqlDbType.VarChar, cmbDeliveredBy.Text.Length).Value = cmbDeliveredBy.Text.Trim();
                cmd.Parameters.Add("@TotalAmount", SqlDbType.VarChar, txtNetAmount.Text.Length).Value = txtNetAmount.Text.Replace(",","").Trim();
                //cmd.Parameters.Add("@Discount", SqlDbType.VarChar, txtDiscAmount.Text.Length).Value = txtDiscAmount.Text.Trim();
                //Commented and added by Kashif on 26th April 2015 to save discount percentage
                cmd.Parameters.Add("@Discount", SqlDbType.VarChar, txtDiscountPer.Text.Length).Value = txtDiscountPer.Text.Trim();
                cmd.Parameters.Add("@CustRemarks", SqlDbType.VarChar, txtOrdersCustRemarks.Text.Length).Value = txtOrdersCustRemarks.Text.Trim();
                cmd.Parameters.Add("@Ordertype", SqlDbType.VarChar, sOrderType.Length).Value = sOrderType.Trim();
                cmd.Parameters.Add("@CustPhoneNo", SqlDbType.VarChar, txtOrdersCustomerPhone.Text.Length).Value = txtOrdersCustomerPhone.Text.Trim();
                cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, txtInvoiceNo.Text.Length).Value = txtInvoiceNo.Text.Trim();

                cmd.Parameters.Add("@InvoiceType", SqlDbType.VarChar, GlobalClass.gsInvoiceType.Length).Value = GlobalClass.gsInvoiceType.Trim();
                cmd.Parameters.Add("@InvoicePayOption", SqlDbType.VarChar, GlobalClass.gsInvPaymentOptions.Length).Value = GlobalClass.gsInvPaymentOptions.Trim();
                cmd.Parameters.Add("@CreditCardType", SqlDbType.VarChar, cmbCreditCardType.Text.Length).Value = cmbCreditCardType.Text.Trim();
                cmd.Parameters.Add("@EODDate", SqlDbType.VarChar, GlobalClass.gsEODDate.Length).Value = GlobalClass.gsEODDate;
                cmd.Parameters.Add("@Cashier", SqlDbType.VarChar, GlobalClass.gsLoggedInUser.Length).Value = GlobalClass.gsLoggedInUser;
                //Added by Kashif on 26th April 2015
                if (txtDiscAmount.Text!="")
                {
                    cmd.Parameters.Add("@DiscountAmt", SqlDbType.VarChar, txtDiscAmount.Text.Length).Value = txtDiscAmount.Text;
                    //cmd.Parameters.Add("@PaidAmt", SqlDbType.VarChar, txtPaidAmount.Text.Length).Value = txtPaidAmount.Text;
                }
                else
                {
                    cmd.Parameters.Add("@DiscountAmt", SqlDbType.VarChar, 5).Value = "0.00";
                    //cmd.Parameters.Add("@PaidAmt", SqlDbType.VarChar,5).Value = "0.00";
                }
                cmd.Parameters.Add("@PaidAmt", SqlDbType.VarChar, txtPaidAmount.Text.Length).Value = txtPaidAmount.Text;
                //till here
                iResult = cmd.ExecuteNonQuery();
                if (iResult >= 1)
                {
                    MessageBox.Show("Invoice Saved Successfully", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                //int i;
                
                //i = dgDisplayKOTDetails.Rows.Count;
                //if (GlobalClass.gbOrderChanged)
                //{
                //    sFlag = "ORDERCHANGE";
                //    for (int j = 0; j < i; j++)
                //    {
                //        cmd = new SqlCommand();
                //        cmd.CommandType = CommandType.StoredProcedure;
                //        cmd.Connection = GlobalClass.gCon;
                //        cmd.CommandText = "SP_MaintainKOT";
                //        cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                //        cmd.Parameters.Add("@itemcode", SqlDbType.VarChar, dgDisplayKOTDetails.Rows[j].Cells["ItemCode"].Value.ToString().Length).Value = dgDisplayKOTDetails.Rows[j].Cells["ItemCode"].Value.ToString().Trim();
                //        cmd.Parameters.Add("@KOTID", SqlDbType.VarChar, sKotid.Length).Value = sKotid.Trim();
                //        cmd.Parameters.Add("@Itemname", SqlDbType.VarChar, dgDisplayKOTDetails.Rows[j].Cells["KOTItem"].Value.ToString().Length).Value = dgDisplayKOTDetails.Rows[j].Cells["KOTItem"].Value.ToString().Trim();
                //        cmd.Parameters.Add("@Quantity", SqlDbType.VarChar, dgDisplayKOTDetails.Rows[j].Cells["KotItemQty"].Value.ToString().Length).Value = dgDisplayKOTDetails.Rows[j].Cells["KotItemQty"].Value.ToString().Trim();
                //        cmd.Parameters.Add("@UnitPrice", SqlDbType.VarChar, dgDisplayKOTDetails.Rows[j].Cells["KotItemUnitPrice"].Value.ToString().Length).Value = dgDisplayKOTDetails.Rows[j].Cells["KotItemUnitPrice"].Value.ToString().Trim();
                //        cmd.Parameters.Add("@Amount", SqlDbType.VarChar, dgDisplayKOTDetails.Rows[j].Cells["Amount"].Value.ToString().Length).Value = dgDisplayKOTDetails.Rows[j].Cells["Amount"].Value.ToString().Trim();
                //        cmd.Parameters.Add("@Ordertype", SqlDbType.VarChar, cmbOrderType.Text.ToString().Length).Value = cmbOrderType.Text.ToString().Trim();

                //        iResult = cmd.ExecuteNonQuery();
                //        cmd = null;
                //    }
                //    GlobalClass.gbOrderChanged = false;
                //}
                
                GlobalClass.gbOrderSelectedToPrint = false;
                //PrintInvoiceInCrystalReport();
                PrintInvoice();
                ClearForm();
                InvoiceGenerator();
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        public void PrintInvoiceInCrystalReport()
        {
            try
            {
                GlobalClass.WriteLog("In PrintInvoiceInCrystalReport function"); 
                GlobalClass.gsInvoiceNoforPrint = txtInvoiceNo.Text;
                GlobalClass.gsOrderTypeForPrint = cmbOrderType.Text;
                GlobalClass.gsCustNameforPrint = txtOrdersCustName.Text;
                GlobalClass.gsSalesByforPrint = txtOrderssalesman.Text;
                GlobalClass.gsDeliveredByforPrint = cmbDeliveredBy.Text;
                GlobalClass.gsMobNoforPrint = txtOrdersCustomerPhone.Text;
                GlobalClass.gsCustomerAddressforPrint = txtOrdersCustAddress.Text;


                GlobalClass.WriteLog("After Reading details function"); 
                frmPrintInvoice frm = new frmPrintInvoice();
                frm.MdiParent = this.ParentForm;
                frm.Show();
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in PrintInvoiceInCrystalReport:" + ex.Message.ToString());
            }
        }
        public void PrintInvoice()
        {
            printDialogInvoice.Document = printDocInvoice;          

            
            if (printDialogInvoice.ShowDialog() == DialogResult.OK)
            {
                printPreviewDialogInvoice.Document = printDocInvoice;
                //printPreviewDialogInvoice.Width = 200;
                //printPreviewDialogInvoice.MinimumSize = new Size(375, 250);
                //printPreviewDialogInvoice.SetBounds(100, -550, 3000, 3000);

                pageSetupDialog.Document = printDocInvoice;
                //Commented by KAshif on 15th Nov 2014
                ////////if (pageSetupDialog.ShowDialog() == DialogResult.OK)
                ////////{
                ////////    //Commented by Kashif on 13th Nov 2014
                ////////    //printDocInvoice.DefaultPageSettings = pageSetupDialog.PageSettings;
                ////////    //printDocInvoice.PrinterSettings = pageSetupDialog.PrinterSettings;
                ////////}
                ////if (printPreviewDialogInvoice.ShowDialog() == DialogResult.Cancel)
                ////{
                ////    return;
                ////}
                //////printPreviewDialogInvoice.ClientSize = new System.Drawing.Size(500, 400);
                printDocInvoice.PrintPage+=new System.Drawing.Printing.PrintPageEventHandler(printDocInvoice_PrintPage);                
                printDocInvoice.Print();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void PrintInvoice(System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Inch;
            //e.Graphics.PageUnit = GraphicsUnit.Inch;
            float xLeft, yTop;
            //xLeft = e.MarginBounds.Left / 10;
            //yTop = e.MarginBounds.Top / 10;
            xLeft = 0;
            yTop = 0;

            System.Drawing.Printing.PaperSize psize = new System.Drawing.Printing.PaperSize("POS Paper Size", 260, 200);
            printDocInvoice.PrinterSettings.DefaultPageSettings.PaperSize = psize;
            printDocInvoice.DefaultPageSettings.PaperSize = psize;

            e.Graphics.DrawString(GlobalClass.gsCompanyName, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 1/2 , 1/2);
            e.Graphics.DrawString(GlobalClass.gsCompanyAddress, new Font("Arial", 11, FontStyle.Regular), Brushes.Black, 15 + xLeft, 10 + yTop);
            e.Graphics.DrawString("Tel:" + GlobalClass.gsCompanyPhoneNo + " ,Fax:" + GlobalClass.gsCompanyFaxNo, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 5 + xLeft, 15 + yTop);
            e.Graphics.DrawString(GlobalClass.gsBillHeader, new Font("Arial", 12, FontStyle.Underline), Brushes.Black, 20 + xLeft, 20 + yTop);

            e.Graphics.DrawString("Customer:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 5 + xLeft, 30 + yTop);
            e.Graphics.DrawString(txtOrdersCustName.Text, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 23 + xLeft, 30 + yTop);

            e.Graphics.DrawString("Invoice No:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 5 + xLeft, 35 + yTop);
            e.Graphics.DrawString(txtInvoiceNo.Text, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 25 + xLeft, 35 + yTop);

            e.Graphics.DrawString("Tel:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 5 + xLeft, 40 + yTop);
            e.Graphics.DrawString(txtOrdersCustomerPhone.Text, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 15 + xLeft, 40 + yTop);

            e.Graphics.DrawString("DateTime:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 5 + xLeft, 45 + yTop);
            e.Graphics.DrawString(DateTime.Now.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 25 + xLeft, 45 + yTop);

            e.Graphics.DrawString("Mob:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 5 + xLeft, 50 + yTop);
            e.Graphics.DrawString(txtOrdersCustomerPhone.Text, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 15 + xLeft, 50 + yTop);

            e.Graphics.DrawString("Terms:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 5 + xLeft, 55 + yTop);

            e.Graphics.DrawString("Sales By:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 5 + xLeft, 60 + yTop);
            e.Graphics.DrawString(txtOrderssalesman.Text, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 25 + xLeft, 60 + yTop);

            e.Graphics.DrawString("Order Type:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 5 + xLeft, 65 + yTop);
            e.Graphics.DrawString(txtOrderStatus.Text, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 35 + xLeft, 65 + yTop);

            e.Graphics.DrawString("Delivered By:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 5 + xLeft, 70 + yTop);
            e.Graphics.DrawString(cmbDeliveredBy.Text, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 30 + xLeft, 70 + yTop);

            e.Graphics.DrawString("Address:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 5 + xLeft, 75 + yTop);
            e.Graphics.DrawString(txtOrdersCustAddress.Text, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 22 + xLeft, 75 + yTop);

            //e.Graphics.DrawString("SNo.", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 5+xLeft, 60+yTop);
            e.Graphics.DrawString("Item Description", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 80 + yTop);
            e.Graphics.DrawString("Qty", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 25 + xLeft, 80 + yTop);
            e.Graphics.DrawString("Unit Price", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 35 + xLeft, 80 + yTop);
            e.Graphics.DrawString("Amount", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 45 + xLeft, 80 + yTop);

            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(Convert.ToInt16(1 + xLeft), Convert.ToInt16(85 + yTop)), new Point(Convert.ToInt16(80 + xLeft), Convert.ToInt16(85 + yTop)));
            //new Font("Test", FontStyle.Bold);
            int i;
            int counter, iNewLineCounter, height;
            string sWrapItemName = "";
            string[] sSplitItemName = new string[10];

            height = Convert.ToInt16(90);
            for (i = 0; i < dgDisplayKOTDetails.Rows.Count; i++)
            {
                counter = i + 1;
                //e.Graphics.DrawString(counter.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 5+xLeft, height+yTop);
                sWrapItemName = WordWrap(dgDisplayKOTDetails.Rows[i].Cells["KOTItem"].Value.ToString(), 20);
                e.Graphics.DrawString(sWrapItemName, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1 + xLeft, height + yTop);
                e.Graphics.DrawString(dgDisplayKOTDetails.Rows[i].Cells["KOTItemQty"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 25 + xLeft, height + yTop);
                e.Graphics.DrawString(dgDisplayKOTDetails.Rows[i].Cells["KOTItemUnitprice"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 35 + xLeft, height + yTop);
                e.Graphics.DrawString(dgDisplayKOTDetails.Rows[i].Cells["Amount"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 45 + xLeft, height + yTop);
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
                if (height >= e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                }
                else
                {
                    e.HasMorePages = false;
                }
                //e.Graphics.DrawString(dgDisplayKOTDetails.Rows[i].Cells["KOTItemQty"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 220, height);
                //e.Graphics.DrawString(dgDisplayKOTDetails.Rows[i].Cells["KOTItemUnitprice"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 265, height);
                //e.Graphics.DrawString(dgDisplayKOTDetails.Rows[i].Cells["Amount"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 335, height);
                //height = height + 20;
            }
            //height = height + 5;
            e.Graphics.DrawLine(new Pen(Color.Black, 1), new Point(Convert.ToInt16(5 + xLeft), Convert.ToInt16(height + yTop)), new Point(Convert.ToInt16(80 + xLeft), Convert.ToInt16(height + yTop)));
            height = height + 5;
            e.Graphics.DrawString("Total AED :", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 20 + xLeft, height + yTop);
            e.Graphics.DrawString(txtNetAmount.Text, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 45 + xLeft, height + yTop);
            height = height + 5;
            e.Graphics.DrawString(GlobalClass.gsComments, new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 15 + xLeft, height + yTop);
            //e.Graphics.DrawString(GlobalClass.gsComments, new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 80, height);
            //e.Graphics.PageUnit = GraphicsUnit.Point;
               
        }


        private void printDocInvoice_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //int height;
            try
            {
                //PrintInvoice(e);
                e.Graphics.PageUnit = GraphicsUnit.Millimeter;
                //string escape = Char(&H1B);

                //e.Graphics.PageUnit = GraphicsUnit.Inch;
                float xLeft, yTop;
                xLeft = e.MarginBounds.Left / 50;
                yTop = e.MarginBounds.Top / 50;               
                
                
                //System.Drawing.Printing.PaperSize psize = new System.Drawing.Printing.PaperSize("POS Paper Size", 260, 200);
                //printDocInvoice.PrinterSettings.DefaultPageSettings.PaperSize = psize;
                //printDocInvoice.DefaultPageSettings.PaperSize = psize;

                e.Graphics.DrawString(GlobalClass.gsCompanyName+"\n", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 2 + xLeft, 5 + yTop);
                //e.Graphics.DrawString("\n", new Font("Arial", 11, FontStyle.Bold),Brushes.Black, 2 + xLeft, 5 + yTop);

                e.Graphics.DrawString(GlobalClass.gsCompanyAddress+"\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 7 + xLeft, 10 + yTop);
                //e.Graphics.DrawString("\n", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 7 + xLeft, 10 + yTop);

                e.Graphics.DrawString("Tel:" + GlobalClass.gsCompanyPhoneNo + " ,Fax:" + GlobalClass.gsCompanyFaxNo+"\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1 + xLeft, 15 + yTop);
                //e.Graphics.DrawString("\n", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 2 + xLeft, 5 + yTop);

                e.Graphics.DrawString(GlobalClass.gsBillHeader+"\n", new Font("Arial", 10, FontStyle.Underline), Brushes.Black, 12 + xLeft, 20 + yTop);
                //e.Graphics.DrawString("\n", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 2 + xLeft, 5 + yTop);

                //e.Graphics.DrawString("Customer:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 30 + yTop);
                //e.Graphics.DrawString(txtOrdersCustName.Text+"\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 20 + xLeft, 30 + yTop);
                //e.Graphics.DrawString("\n", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 2 + xLeft, 5 + yTop);

                e.Graphics.DrawString("Invoice No:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 30 + yTop);
                e.Graphics.DrawString(txtInvoiceNo.Text+"\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 20 + xLeft, 30 + yTop);
                //e.Graphics.DrawString("\n", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 2 + xLeft, 5 + yTop);

                e.Graphics.DrawString("DateTime:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 35 + yTop);
                e.Graphics.DrawString(DateTime.Now.ToString() + "\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 15 + xLeft, 35 + yTop);

                e.Graphics.DrawString("Order Type:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 40 + yTop);
                //e.Graphics.DrawString(txtOrderStatus.Text + "\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 25 + xLeft, 40 + yTop);
                e.Graphics.DrawString(cmbOrderType.Text + "\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 25 + xLeft, 40 + yTop);

                e.Graphics.DrawString("Sales By:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 45 + yTop);
                e.Graphics.DrawString(txtOrderssalesman.Text + "\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 15 + xLeft, 45 + yTop);

                e.Graphics.DrawString("Customer:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 50 + yTop);
                e.Graphics.DrawString(txtOrdersCustName.Text + "\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 20 + xLeft, 50 + yTop);

                e.Graphics.DrawString("Mob:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 55 + yTop);
                e.Graphics.DrawString(txtOrdersCustomerPhone.Text + "\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 10 + xLeft, 55+ yTop);                

                e.Graphics.DrawString("Tel:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 60 + yTop);
                e.Graphics.DrawString(txtOrdersCustomerPhone.Text+"\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 8 + xLeft, 60 + yTop);

                e.Graphics.DrawString("Address:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 65 + yTop);
                e.Graphics.DrawString(txtOrdersCustAddress.Text + "\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 15 + xLeft, 65 + yTop);

                e.Graphics.DrawString("Delivered By:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 70 + yTop);
                e.Graphics.DrawString(cmbDeliveredBy.Text + "\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 25 + xLeft, 70 + yTop);
                
                //e.Graphics.DrawString("\n", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 2 + xLeft, 5 + yTop);

                //e.Graphics.DrawString("DateTime:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 35 + yTop);
                //e.Graphics.DrawString(DateTime.Now.ToString()+"\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 15 + xLeft, 35 + yTop);
                ////e.Graphics.DrawString("\n", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 2 + xLeft, 5 + yTop);

                ////e.Graphics.DrawString("Mob:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 50 + yTop);
                ////e.Graphics.DrawString(txtOrdersCustomerPhone.Text+"\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 10 + xLeft, 50 + yTop);
                //////e.Graphics.DrawString("\n", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 2 + xLeft, 5 + yTop);

                e.Graphics.DrawString("Terms:"+"\n", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 75 + yTop);
                //e.Graphics.DrawString("\n", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 2 + xLeft, 5 + yTop);

                ////e.Graphics.DrawString("Sales By:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 45 + yTop);
                ////e.Graphics.DrawString(txtOrderssalesman.Text+"\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 15 + xLeft, 45 + yTop);
                //////e.Graphics.DrawString("\n", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 2 + xLeft, 5 + yTop);

                ////e.Graphics.DrawString("Order Type:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 40 + yTop);
                ////e.Graphics.DrawString(txtOrderStatus.Text+"\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 25 + xLeft, 40 + yTop);
                //////e.Graphics.DrawString("\n", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 2 + xLeft, 5 + yTop);

                //e.Graphics.DrawString("Delivered By:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 70 + yTop);
                //e.Graphics.DrawString(cmbDeliveredBy.Text+"\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 25 + xLeft, 70 + yTop);
                ////e.Graphics.DrawString("\n", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 2 + xLeft, 5 + yTop);

                //e.Graphics.DrawString("Address:", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 75 + yTop);
                //e.Graphics.DrawString(txtOrdersCustAddress.Text+"\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 15 + xLeft, 75 + yTop);
                ////e.Graphics.DrawString("\n", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 2 + xLeft, 5 + yTop);

                //e.Graphics.DrawString("SNo.", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 5+xLeft, 60+yTop);
                e.Graphics.DrawString("Item Description", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 1 + xLeft, 80 + yTop);
                e.Graphics.DrawString("Qty", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 30 + xLeft, 80 + yTop);
                e.Graphics.DrawString("Unit Price", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 40 + xLeft, 80 + yTop);
                e.Graphics.DrawString("Amount"+"\n", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 57 + xLeft, 80 + yTop);
                //e.Graphics.DrawString("\n", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 2 + xLeft, 5 + yTop);

                e.Graphics.DrawLine(new Pen(Color.Black, 0), new Point(Convert.ToInt16(1 + xLeft), Convert.ToInt16(85 + yTop)), new Point(Convert.ToInt16(80 + xLeft), Convert.ToInt16(85 + yTop)));
                                
                //e.Graphics.DrawString("\n", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, 2 + xLeft, 5 + yTop);
                //new Font("Test", FontStyle.Bold);
                int i;
                int counter, iNewLineCounter, height;
                string sWrapItemName = "";
                string[] sSplitItemName = new string[10];

                height = Convert.ToInt16(90);
                for (i = 0; i < dgDisplayKOTDetails.Rows.Count; i++)
                {
                    counter = i + 1;
                    //e.Graphics.DrawString(counter.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 5+xLeft, height+yTop);
                    sWrapItemName = WordWrap(dgDisplayKOTDetails.Rows[i].Cells["KOTItem"].Value.ToString(), 20);
                    e.Graphics.DrawString(sWrapItemName, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1 + xLeft, height + yTop);
                    e.Graphics.DrawString(dgDisplayKOTDetails.Rows[i].Cells["KOTItemQty"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 30 + xLeft, height + yTop);
                    e.Graphics.DrawString(dgDisplayKOTDetails.Rows[i].Cells["KOTItemUnitprice"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 40 + xLeft, height + yTop);
                    e.Graphics.DrawString(dgDisplayKOTDetails.Rows[i].Cells["Amount"].Value.ToString()+"\n", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 55 + xLeft, height + yTop);
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
                    if (height >= e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }
                    //e.Graphics.DrawString(dgDisplayKOTDetails.Rows[i].Cells["KOTItemQty"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 220, height);
                    //e.Graphics.DrawString(dgDisplayKOTDetails.Rows[i].Cells["KOTItemUnitprice"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 265, height);
                    //e.Graphics.DrawString(dgDisplayKOTDetails.Rows[i].Cells["Amount"].Value.ToString(), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 335, height);
                    //height = height + 20;
                }
                //height = height + 5;
                e.Graphics.DrawLine(new Pen(Color.Black, 0), new Point(Convert.ToInt16(1 + xLeft), Convert.ToInt16(height + yTop)), new Point(Convert.ToInt16(80 + xLeft), Convert.ToInt16(height + yTop)));
                height = height + 5;
                e.Graphics.DrawString("Total AED :", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 20 + xLeft, height + yTop);
                //e.Graphics.DrawString(txtNetAmount.Text+"\n", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 45 + xLeft, height + yTop);
                e.Graphics.DrawString(txtPaidAmount.Text + "\n", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 45 + xLeft, height + yTop);
                height = height + 5;
                e.Graphics.DrawString(GlobalClass.gsComments, new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 20 + xLeft, height + yTop);
                //e.Graphics.DrawString(GlobalClass.gsComments, new Font("Arial", 9, FontStyle.Bold), Brushes.Black, 80, height);
                //e.Graphics.PageUnit = GraphicsUnit.Point;
               
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in printDocInvoice_PrintPage:"+ex.Message.ToString());
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

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = txtNetAmount.Text;
        }

        private void txtDiscountPer_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                int iDiscountPerc;
                Double itotalAmount;
                Double dDiscountAmt;
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    iDiscountPerc = Convert.ToInt16(txtDiscountPer.Text);
                    itotalAmount = Convert.ToDouble(txtNetAmount.Text);
                    dDiscountAmt = (iDiscountPerc * itotalAmount) / 100;
                    dDiscountAmt = Math.Floor(dDiscountAmt);
                    //txtDiscAmount.Text = dDiscountAmt.ToString();
                    txtDiscAmount.Text = dDiscountAmt.ToString("#,##.00");

                    itotalAmount = itotalAmount - Convert.ToInt16(dDiscountAmt);
                    //txtPaidAmount.Text = itotalAmount.ToString();
                    txtPaidAmount.Text = itotalAmount.ToString("#,##.00");
                    //txtDiscAmount.Text = Convert.ToString(Convert.ToInt16(txtDiscountPer.Text) * Convert.ToInt16(txtNetAmount.Text)) / 100;
                    //txtPaidAmount.Text = Convert.ToString(Convert.ToInt16(txtNetAmount.Text) - Convert.ToInt16(txtDiscAmount.Text));
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
            }


        }

        private void txtDiscountPer_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgInvSearchedKOT_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSalesItemCode_Leave(object sender, EventArgs e)
        {
            try
            {
                string sItemCode, flag;
                ds = new DataSet();
                flag = "TYPEMENU";
                sItemCode = txtSalesItemCode.Text.Trim();
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
                    cmbSalesItemName.Text = ds.Tables["Result"].Rows[0]["ItemName"].ToString();
                    txtSalesPrice.Text = ds.Tables["Result"].Rows[0]["ItemPrice"].ToString();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Error in KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtSalesItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtSalesItemCode.Text.Trim() != "")
                {
                    txtSalesItemCode_Leave(sender, e);
                    txtSalesQuantity.Focus();
                    txtSalesQuantity.SelectAll();
                }
                else
                {
                    MessageBox.Show("Please Enter Item Code", "Orders", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    txtSalesItemCode.Focus();
                }

            }
        }

        private void cmbSalesItemName_Leave(object sender, EventArgs e)
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
                GlobalClass.cmd.Parameters.Add("@ItemName", SqlDbType.VarChar, cmbSalesItemName.Text.Length).Value = cmbSalesItemName.Text.ToString().Trim();
                ds = new DataSet();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                txtSalesItemCode.Text = ds.Tables["Result"].Rows[0]["ItemCode"].ToString();
                txtSalesPrice.Text = ds.Tables["Result"].Rows[0]["ItemPrice"].ToString();

            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Error in KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cmbSalesItemName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbSalesItemName_Leave(sender, e);
                    txtSalesQuantity.Focus();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "KOT", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtSalesQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i;
            string sItemname;
            DataRow dr,drNewOrder;

            try
            {
                if (!GlobalClass.gbNewOrder)
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        Decimal dc;
                        dc = Convert.ToDecimal(txtSalesPrice.Text) * Convert.ToDecimal(txtSalesQuantity.Text);
                        txtSalesAmount.Text = dc.ToString();

                        sItemname = cmbSalesItemName.Text.ToString();

                        if (dgDisplayKOTDetails.Rows.Count == 0)
                        {
                            MessageBox.Show("No Order Selected", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        for (i = 0; i < dgDisplayKOTDetails.Rows.Count; i++)
                        {
                            if (sItemname == dgDisplayKOTDetails.Rows[i].Cells["KOTItem"].Value.ToString().Trim())
                            {
                                dgDisplayKOTDetails.Rows.RemoveAt(i);
                                for (int k = 0; k < dtNewItem.Rows.Count; k++)
                                {
                                    if (dtNewItem.Rows[k].RowState == DataRowState.Deleted)
                                    {
                                        continue;
                                    }

                                    else if (dtNewItem.Rows[k]["KOTItem"].ToString().Trim() == sItemname)
                                    {
                                        dtNewItem.Rows.RemoveAt(k);

                                    }
                                }
                                //dgDisplayKOTDetails.Rows.RemoveAt(i);
                            }
                        }

                        //if (GlobalClass.gsMenuItemSelected == cmbItems.Text.ToString().Trim())
                        //{
                        //    dgview.Rows.RemoveAt(GlobalClass.giMenuItemRowSelectedIndex);
                        //}

                        //dgDisplayKOTDetails.DataSource = null;
                        //dtNewItem.Rows.Clear();
                        dr = dtNewItem.NewRow();

                        dr["KotItem"] = cmbSalesItemName.Text.ToString().Trim();
                        dr["KotItemQty"] = txtSalesQuantity.Text.ToString().Trim();
                        dr["KotItemUnitPrice"] = txtSalesPrice.Text.ToString().Trim();
                        dr["ItemCode"] = txtSalesItemCode.Text.ToString().Trim();
                        dr["Amount"] = txtSalesAmount.Text.ToString().Trim();

                        dtNewItem.Rows.Add(dr);
                        GlobalClass.gbOrderChanged = true;
                        //dgDisplayKOTDetails.Rows.Clear();
                        //DataGridViewRow row = new DataGridViewRow();
                        dgDisplayKOTDetails.DataSource = dtNewItem;
                        GlobalClass.CaptureAuditTrail("INVOICECHANGE", "INvoiceItemAdded", GlobalClass.gsLoggedInUser, "InvoiceItemAdded", "", txtInvoiceNo.Text,cmbSalesItemName.Text , "",txtSalesQuantity.Text,"");

                        //row.CreateCells(this.dgDisplayKOTDetails, txtItemcode.Text, cmbItems.Text, txtQuantity.Text, txtItemPrice.Text, txtAmount.Text);
                        //row.CreateCells(this.dgDisplayKOTDetails, cmbSalesItemName.Text, txtSalesQuantity.Text, txtSalesPrice.Text, txtSalesItemCode.Text, txtSalesAmount.Text);
                        //ds.Tables["Result"].NewRow

                        //this.dgDisplayKOTDetails.Rows.Add(row);
                        txtSalesItemCode.Focus();
                        txtSalesItemCode.Clear();
                        txtSalesQuantity.Clear();
                        cmbSalesItemName.SelectedIndex = 0;
                        txtSalesPrice.Clear();
                        txtSalesAmount.Clear();
                    }
                }
                else if (GlobalClass.gbNewOrder)
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {

                        Decimal dc;
                        dc = Convert.ToDecimal(txtSalesPrice.Text) * Convert.ToDecimal(txtSalesQuantity.Text);
                        txtSalesAmount.Text = dc.ToString();
                        drNewOrder = dtNewOrder.NewRow();

                        if (!dtNewOrder.Columns.Contains("Kotitem")|| !dtNewOrder.Columns.Contains("Amount"))
                        {
                            dtNewOrder.Columns.Add("Kotitem");
                            dtNewOrder.Columns.Add("KotItemQty");
                            dtNewOrder.Columns.Add("KotItemUnitPrice");
                            dtNewOrder.Columns.Add("ItemCode");
                            dtNewOrder.Columns.Add("Amount");
                        }

                        drNewOrder["KotItem"] = cmbSalesItemName.Text.ToString().Trim();
                        drNewOrder["KotItemQty"] = txtSalesQuantity.Text.ToString().Trim();
                        drNewOrder["KotItemUnitPrice"] = txtSalesPrice.Text.ToString().Trim();
                        drNewOrder["ItemCode"] = txtSalesItemCode.Text.ToString().Trim();
                        drNewOrder["Amount"] = txtSalesAmount.Text.ToString().Trim();
                        dtNewOrder.Rows.Add(drNewOrder);
                        dgDisplayKOTDetails.DataSource = dtNewOrder;

                        txtSalesItemCode.Focus();
                        txtSalesItemCode.Clear();
                        txtSalesQuantity.Clear();
                        cmbSalesItemName.SelectedIndex = 0;
                        txtSalesPrice.Clear();
                        txtSalesAmount.Clear();
                    }

                }
            }
            catch (Exception Ex)
            {
                GlobalClass.WriteLog(Ex.Message.ToString());
                MessageBox.Show(Ex.Message.ToString(), "Error in Sales", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgDisplayKOTDetails_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                //int iSum,iAmount;
                Decimal dAmount,iSum;
               // string sAmt;
                iSum = 0;
                
                for (int j = 0; j < dgDisplayKOTDetails.Rows.Count; j++)
                {
                    //iSum = iSum + Convert.ToInt16(ds.Tables["Result"].Rows[j]["Amount"]);
                    //sAmt =dgDisplayKOTDetails.Rows[j].Cells["Amount"].Value.ToString();
                    //iAmount = Convert.ToDecimal(sAmt);
                    iSum = iSum + Convert.ToDecimal(dgDisplayKOTDetails.Rows[j].Cells["Amount"].Value);
                    GlobalClass.gbOrderChanged = true;
                    //MessageBox.Show(ds.Tables["Result"].Rows[i]["Amount"].ToString(),"Saels",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                }
                txtNetAmount.Text = iSum.ToString("0,0.00");
                //Added by Kashif on 05-May-2015 to populate Paid Amount Text box also
                txtPaidAmount.Text = iSum.ToString("0,0.00");
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Error in Sales", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgDisplayKOTDetails_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                int iSum,i;
                string sItemname;
                iSum = 0;
                for (int j = 0; j < dgDisplayKOTDetails.Rows.Count; j++)
                {
                    //iSum = iSum + Convert.ToInt16(ds.Tables["Result"].Rows[j]["Amount"]);
                    iSum = iSum + Convert.ToInt16(dgDisplayKOTDetails.Rows[j].Cells["Amount"].Value);
                    GlobalClass.gbOrderChanged = true;
                    //MessageBox.Show(ds.Tables["Result"].Rows[i]["Amount"].ToString(),"Saels",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                }
                
                txtNetAmount.Text = iSum.ToString("0,0.00");
               // i = e.RowIndex;
               // if (i >= 1)
                //{
                    //sItemname = dgDisplayKOTDetails.Rows[i].Cells["KotItem"].Value.ToString();
                    for (int k = 0; k < dtNewItem.Rows.Count; k++)
                    {
                        if (dtNewItem.Rows[k].RowState == DataRowState.Deleted)
                        {
                            continue;
                        }

                        else if (dtNewItem.Rows[k]["KOTItem"].ToString().Trim() == sItemNameDeleted)
                        {
                            dtNewItem.Rows.RemoveAt(k);
                        }
                    }
               // }
                    //i = e.RowIndex;
                    //GlobalClass.CaptureAuditTrail("INVOICECHANGE", "INvoiceItemDeleted", GlobalClass.gsLoggedInUser, "InvoiceDeleted", "", txtInvoiceNo.Text, dgDisplayKOTDetails.Rows[e.RowIndex].Cells["KotItem"].Value.ToString(), "", dgDisplayKOTDetails.Rows[e.RowIndex].Cells["KotItemQty"].Value.ToString());
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Error in Sales", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgDisplayKOTDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int iRowindex,iQty;
                decimal dcTotalAmount;
                iRowindex = dgDisplayKOTDetails.CurrentCell.RowIndex;
                iQty =Convert.ToInt16( dgDisplayKOTDetails.Rows[iRowindex].Cells["KotItemQty"].Value);
                dcTotalAmount = Convert.ToDecimal(iQty * Convert.ToDecimal(dgDisplayKOTDetails.Rows[iRowindex].Cells["KotItemUnitPrice"].Value));
                dgDisplayKOTDetails.Rows[iRowindex].Cells["Amount"].Value = dcTotalAmount;
                SumMenuAmount();
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Error in Sales", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        public void SumMenuAmount()
        {
            try
            {
                int iSum;
                iSum = 0;
                for (int j = 0; j < dgDisplayKOTDetails.Rows.Count; j++)
                {
                    //iSum = iSum + Convert.ToInt16(ds.Tables["Result"].Rows[j]["Amount"]);
                    iSum = iSum + Convert.ToInt16(dgDisplayKOTDetails.Rows[j].Cells["Amount"].Value);
                    GlobalClass.gbOrderChanged = true;
                    //MessageBox.Show(ds.Tables["Result"].Rows[i]["Amount"].ToString(),"Saels",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                }
                txtNetAmount.Text = iSum.ToString("0,0.00");

            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
            }

        }

        private void printPreviewDialogInvoice_Load(object sender, EventArgs e)
        {

        }

        private void dgDisplayKOTDetails_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                int i;
                string sTotalAmount;
                i = e.Row.Index;
                sItemNameDeleted = dgDisplayKOTDetails.Rows[i].Cells["Kotitem"].Value.ToString();
                sTotalAmount = dgDisplayKOTDetails.Rows[i].Cells["Amount"].Value.ToString();
                GlobalClass.CaptureAuditTrail("INVOICECHANGE", "INvoiceItemDeleted", GlobalClass.gsLoggedInUser, "InvoiceDeleted", sKotid, txtInvoiceNo.Text, dgDisplayKOTDetails.Rows[e.Row.Index].Cells["KotItem"].Value.ToString(), "", dgDisplayKOTDetails.Rows[e.Row.Index].Cells["KotItemQty"].Value.ToString(),sTotalAmount);
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
            }
            
        }

        private void cmbOrderType_Click(object sender, EventArgs e)
        {
            
            try
            {
                //GlobalClass.WriteLog("Before Fetching Invoice Numbers");
                //cmd = new SqlCommand();
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Connection = GlobalClass.gCon;
                //cmd.CommandText = "SP_GetInvoiceCounter";
                //txtInvoiceNo.Text = cmd.ExecuteScalar().ToString().PadLeft(7, '0');

                //GlobalClass.WriteLog("Invoice Number Fetched Successfully. Invoice No:" + txtInvoiceNo.Text);
                InvoiceGenerator();
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
            }
        }

        private void frmSales_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.F10)
                {
                    btnSave_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void cmbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (cmbOrderType.Text == "TA")
            //    {
            //        txtOrdersCustName.Text = "Take Away";
            //    }
            //    else if (cmbOrderType.Text == "HD")
            //    {
            //        txtOrdersCustName.Text = "Home Delivery";
            //    }
            //    else
            //    {
            //        txtOrdersCustName.Text = "Table";
            //    }
            //}
            //catch (Exception ex)
            //{
            //}

        }
        public void InvoiceGenerator()
        {
            try
            {
                GlobalClass.WriteLog("Before Fetching Invoice Numbers");
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_GetInvoiceCounter";
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10).Value = "SALES";
                txtInvoiceNo.Text ="I"+GlobalClass.gsCounterNo+ cmd.ExecuteScalar().ToString().PadLeft(7, '0');

                GlobalClass.WriteLog("Invoice Number Fetched Successfully. Invoice No:" + txtInvoiceNo.Text);
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in InvoiceGenerator:"+ex.Message.ToString());
            }
        }
        public void ReverseInvoiceGenerator()
        {
            try
            {
                GlobalClass.WriteLog("Before Fetching Reverse Invoice Numbers");
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_GetInvoiceCounter";
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 15).Value = "SALESRETURN";
                txtInvoiceNo.Text = "R" + GlobalClass.gsCounterNo + cmd.ExecuteScalar().ToString().PadLeft(7, '0');

                GlobalClass.WriteLog("Reverse Invoice Number Fetched Successfully. Invoice No:" + txtInvoiceNo.Text);
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in InvoiceGenerator:" + ex.Message.ToString());
            }
        }

        private void cmbOrderType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbOrderType.Text == "TA" || cmbOrderType.Text.Replace(" ", "").ToUpper() == "TAKEAWAY")
                {
                    txtOrdersCustName.Text = "Take Away";
                }
                else if (cmbOrderType.Text == "HD" || cmbOrderType.Text.Replace(" ", "").ToUpper() == "HOMEDELIVERY")
                {
                    txtOrdersCustName.Text = "Home Delivery";
                }
                else
                {
                    txtOrdersCustName.Text = "Table";
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void rbtnInvCash_CheckedChanged(object sender, EventArgs e)
        {
            GlobalClass.gsInvoiceType = "CASH";
            txtInvoiceNo.ReadOnly = true;
            if(dgDisplayKOTDetails.Rows.Count==0)
                InvoiceGenerator();
        }

        private void rbtnInvCr_CheckedChanged(object sender, EventArgs e)
        {
            GlobalClass.gsInvoiceType = "CREDIT";
            txtInvoiceNo.ReadOnly = true;
            if (dgDisplayKOTDetails.Rows.Count==0)
                InvoiceGenerator();
        }

        private void rbtnInvReturn_CheckedChanged(object sender, EventArgs e)
        {
            GlobalClass.gsInvoiceType = "CASHRETURN";
            //txtInvoiceNo.Enabled = true;
            //txtInvoiceNo.ReadOnly = false;
            dtNewItem = new DataTable();
            dtNewOrder = new DataTable();
            ReverseInvoiceGenerator();
        }

        private void rbtnPayCash_CheckedChanged(object sender, EventArgs e)
        {
            GlobalClass.gsInvPaymentOptions = "CASH";
            cmbCreditCardType.Enabled = false;
        }

        private void rbtnPayCC_CheckedChanged(object sender, EventArgs e)
        {
            GlobalClass.gsInvPaymentOptions = "CREDITCARD";
            cmbCreditCardType.Enabled = true;
        }

        private void rbtnCheque_CheckedChanged(object sender, EventArgs e)
        {
            GlobalClass.gsInvPaymentOptions = "CHEQUE";
            cmbCreditCardType.Enabled = false;
        }

        private void rbtnCrInvReturn_CheckedChanged(object sender, EventArgs e)
        {
            GlobalClass.gsInvoiceType = "CREDITRETURN";
            //txtInvoiceNo.Enabled = true;
            //txtInvoiceNo.ReadOnly = false;
            dtNewOrder = new DataTable();
            ReverseInvoiceGenerator();
        }

        private void dgDisplayKOTDetails_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //GlobalClass.CaptureAuditTrail("INVOICECHANGE", "INvoiceItemAdded", GlobalClass.gsLoggedInUser, "InvoiceItemAdded", "", txtInvoiceNo.Text, dgDisplayKOTDetails.Rows[e.Row.Index].Cells["KotItem"].Value.ToString(), "", dgDisplayKOTDetails.Rows[e.Row.Index].Cells["KotItemQty"].Value.ToString());
        }

        private void txtDiscAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                int iDiscountPerc;
                Double itotalAmount;
                Double dDiscountAmt;
               // if (e.KeyChar == Convert.ToChar(Keys.Enter))
                //{
                    //iDiscountPerc = Convert.ToInt16(txtDiscountPer.Text);
                    itotalAmount = Convert.ToDouble(txtNetAmount.Text);
                    //dDiscountAmt = (iDiscountPerc * itotalAmount) / 100;
                   // dDiscountAmt = Math.Floor(dDiscountAmt);
                   // txtDiscAmount.Text = dDiscountAmt.ToString();
                    dDiscountAmt = Convert.ToDouble(txtDiscAmount.Text);

                    itotalAmount = itotalAmount - Convert.ToInt16(dDiscountAmt);
                    txtPaidAmount.Text = itotalAmount.ToString();
                    //txtDiscAmount.Text = Convert.ToString(Convert.ToInt16(txtDiscountPer.Text) * Convert.ToInt16(txtNetAmount.Text)) / 100;
                    //txtPaidAmount.Text = Convert.ToString(Convert.ToInt16(txtNetAmount.Text) - Convert.ToInt16(txtDiscAmount.Text));
                //}
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog(ex.Message.ToString());
            }
        }

        private void txtDiscAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbModifySales.Checked == true)
                {
                    if (MessageBox.Show("Are you sure to change invoice", "Change Invoice", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                    {
                        return;
                    }
                    string sInvoiceNo = "", sResult = "";
                    sInvoiceNo = txtInvoiceNo.Text;
                    cmd = new SqlCommand();
                    cmd.Connection = GlobalClass.gCon;
                    cmd.CommandText = "SP_FetchInvoiceDetails";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 30).Value = "MODIFYINVOICE";
                    cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, sInvoiceNo.Length).Value = sInvoiceNo;
                    cmd.Parameters.Add("@InvoiceType", SqlDbType.VarChar, GlobalClass.gsInvoiceType.Length).Value = GlobalClass.gsInvoiceType;
                    sResult = cmd.ExecuteScalar().ToString();
                    MessageBox.Show(sResult, "Change Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    chbModifySales.Checked = false;
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in checkBox1_CheckedChanged:" + ex.Message.ToString());
            }
        }

        private void dgDisplayKOTDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
