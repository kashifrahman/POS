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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        SqlDataReader rdr;
        SqlCommand cmd = new SqlCommand();
        Boolean bClosing = false;

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalClass.lretval = GlobalClass.ReadConfigValues();
                GlobalClass.lretval= GlobalClass.ConnectToDB(GlobalClass.gsDBIP,GlobalClass.gsDBname,GlobalClass.gsDbUSer,GlobalClass.gsDBPassword);
                lblLoggedinusername.Text = GlobalClass.gsLoggedInUser;

                cmd = new SqlCommand();
                GlobalClass.WriteLog("Before Fetching User Rights");
                cmd.CommandText = "SP_ValidateUserRights";
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 40).Value = "VALIDATEUSERRIGHTS";
                cmd.Parameters.Add("@Username", SqlDbType.VarChar, GlobalClass.gsLoggedInUser.Length).Value = GlobalClass.gsLoggedInUser;
                rdr = cmd.ExecuteReader();
                GlobalClass.WriteLog("After Fetching User Rights");
                if (!rdr.HasRows)
                {
                    MessageBox.Show("User :" + GlobalClass.gsLoggedInUser + " does not have rights on any Queue", "Main", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    rdr.Close();
                    rdr.Dispose();
                    cmd.Dispose();
                    return;
                }
                while (rdr.Read())
                {
                    if (rdr.GetString(0).Replace(" ","").ToString().ToUpper() == "COMPANYMASTER")
                    {
                        companyMasterToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "SALES")
                    {
                        salesToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "KOT")
                    {
                        ordersToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "BRANCHMASTER")
                    {
                        branchMasterToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "EMPLOYEEMASTER")
                    {
                        employeeMasterToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "DEPARTMENTMASTER")
                    {
                        departmentToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "PRODUCTMASTER")
                    {
                        productMasterToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "PRODUCTGROUP")
                    {
                        productGroupToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "CUSTOMERMASTER")
                    {
                        customerMasterToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "SUPPLIERMASTER")
                    {
                        supplierMasterToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "TABLEMASTER")
                    {
                        tableMasterToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "EVENTMASTER")
                    {
                        eventMasterToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "PURCHASEMASTER")
                    {
                        purchaseMasterToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "MAINTAINPURCHASE")
                    {
                        maintainStockToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "ADDUSER/GROUP")
                    {
                        addUserToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "DAYENDTIME")
                    {
                        dayEndTimeToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "REPORTS")
                    {
                        reportsToolStripMenuItem1.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "SALESREPORT")
                    {
                        salesReportToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "DAYENDREPORT")
                    {
                        dayEndReportToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "CUSTOMERREPORT")
                    {
                        customerReportToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "MAINTAINPURCHASE")
                    {
                        maintainStockToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "DENOMINATIONS")
                    {
                        denominationsToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "RECEIPTISSUE")
                    {
                        receiptIssueToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).Replace(" ", "").ToString().ToUpper() == "RECEIPTPAYMENT")
                    {
                        receiptPaymentToolStripMenuItem.Enabled = true;
                    }
                    if (rdr.GetString(0).ToString().ToUpper() == "Delivery Boy Wise Report".ToUpper())
                    {
                        deliveryBoyWiseReportToolStripMenuItem.Enabled = true;
                    }
                    

                }
                GlobalClass.WriteLog("After enabling all Menus as per user rights");
                rdr.Close();
                rdr.Dispose();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in form Main Load:"+ex.Message.ToString());
            }
        }

        private void maintainMenuItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenus fr = new frmMenus();
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmMenus)
                {
                    MessageBox.Show("Product Master is already Open", "Product Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

            }
            this.IsMdiContainer = true;
            fr.MdiParent = this;
            fr.Show();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void assignRightsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void maintainCustomerDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void maintainStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaintainPurchase fr = new frmMaintainPurchase();

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmMaintainPurchase)
                {
                    MessageBox.Show("Purchase window is already open", "Purchase", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }

            this.IsMdiContainer = true;
            fr.MdiParent = this;
            fr.Show();
        }

        private void billWiseSummaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmOrders fr = new frmOrders();
            //fr.BringToFront();

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmOrders)
                {
                    MessageBox.Show("KOT Window is already open", "KOT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }            
            this.IsMdiContainer = true;
            fr.MdiParent = this;
            //fr.Select();
            fr.Show();
            //fr.Focus();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {

                Application.Exit();
                //frmMain_FormClosing(sender,  e);
                //this.Dispose();
            }
            catch (Exception ex)
            {
            }
        }

        private void companyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompanyMaster fr = new frmCompanyMaster();

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmCompanyMaster)
                {
                    MessageBox.Show("Company Master window already open", "Company Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            this.IsMdiContainer = true;
            fr.MdiParent = this;
            fr.Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSales fr = new frmSales();
            //fr.BringToFront();
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmSales)
                {
                    MessageBox.Show("Sales Window is already open", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            this.IsMdiContainer = true;
            fr.MdiParent = this;
            fr.Show();
            //fr.BringToFront();
        }

        private void customerMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustMaster frm = new frmCustMaster();

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmCustMaster)
                {
                    MessageBox.Show("Customer Master Window is already Open", "Customer Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            this.IsMdiContainer = true;
            frm.MdiParent = this;
            frm.Show();
        }

        private void employeeMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeMaster fr = new frmEmployeeMaster();
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmEmployeeMaster)
                {
                    MessageBox.Show("Employee Master Window is already Open", "Employee Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            this.IsMdiContainer = true;
            fr.MdiParent = this;
            fr.Show();
        }

        private void productMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // frmMenus fr =new frmMenus();
           // f//r.Show();

            frmMenus fr = new frmMenus();
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmMenus)
                {
                    MessageBox.Show("Product Master is already Open", "Product Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }

            }
            this.IsMdiContainer = true;
            fr.MdiParent = this;
            fr.Show();
        }

        private void addUserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmAddUserGroup frm = new frmAddUserGroup();
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmAddUserGroup)
                {
                    MessageBox.Show("User/Group Master is already Open", "Product Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            this.IsMdiContainer = true;
            frm.MdiParent = this;
            frm.Show();
        }

        private void tableMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTableMaster frm = new frmTableMaster();
            frm.Show();
        }

        private void productGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaintainGroups frm = new frmMaintainGroups();
            frm.Show();
        }

        private void eventMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEventMaster frm = new frmEventMaster();
            frm.Show();
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDepartmentMaster frm = new frmDepartmentMaster();

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmDepartmentMaster)
                {
                    MessageBox.Show("Department Master Window is already open", "Department Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            this.IsMdiContainer = true;
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                //Boolean bClosing = false;
                if (!bClosing)
                {
                    if (MessageBox.Show("Are you sure to Exit", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        //return;
                        //Application.Exit();
                        e.Cancel = true;
                        bClosing = true;
                        return;
                    }
                }
                //e.Cancel = true;
                bClosing = true;
                Application.Exit();
                //this.Dispose();
                //this.Close();
                //Application.Exit();
            }
            catch (Exception ex)
            {

            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Boolean bFormFound=false;
                if (e.KeyCode == Keys.F1)
                {
                    foreach(Form  form in Application.OpenForms)
                    {
                        if (form is frmOrders)
                        {
                            bFormFound =true;;
                            MessageBox.Show("KOT window is already Open", "KOT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                    if (ordersToolStripMenuItem.Enabled == false)
                    {
                        MessageBox.Show("You don't have Rights for KOT", "KOT", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    if (!bFormFound)
                    {
                        frmOrders frm = new frmOrders();
                        this.IsMdiContainer = true;
                        frm.MdiParent = this;
                        frm.Show();
                    }
                }
                bFormFound = false;
                if (e.KeyCode == Keys.F2)
                {
                    foreach (Form form in Application.OpenForms)
                    {

                        if (form is frmSales)
                        {
                            bFormFound = true;
                            MessageBox.Show("Sales window is already Open", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                    if (salesToolStripMenuItem.Enabled == false)
                    {
                        MessageBox.Show("You don't have Rights for Sales", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    if (!bFormFound)
                    {
                        frmSales frm = new frmSales();
                        this.IsMdiContainer = true;
                        frm.MdiParent = this;
                        frm.Show();
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void purchaseMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseMaster frm = new frmPurchaseMaster();

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmPurchaseMaster)
                {
                    MessageBox.Show("Purchase Master Window is already open", "Department Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            this.IsMdiContainer = true;
            frm.MdiParent = this;
            frm.Show();
        }

        private void reportsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReports fr = new frmReports();
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmReports)
                {
                    MessageBox.Show("Reports Window is already open", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            this.IsMdiContainer = true;
            fr.MdiParent = this;
            fr.Show();
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesReport fr = new frmSalesReport();

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmPurchaseMaster)
                {
                    MessageBox.Show("Sales Report Window is already open", "Sales Reports", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            this.IsMdiContainer = true;
            fr.MdiParent = this;
            fr.Show();
        }

        private void denominationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDenominations fr = new frmDenominations();

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmDenominations)
                {
                    MessageBox.Show("Denominations Window is already open", "Denominations", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            this.IsMdiContainer = true;
            fr.MdiParent = this;
            fr.Show();
        }

        private void dayEndReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDayEndReport fr = new frmDayEndReport();

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmDayEndReport)
                {
                    MessageBox.Show("Daily Day End Sales Report Window is already open", "Department Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            this.IsMdiContainer = true;
            fr.MdiParent = this;
            fr.Show();
        }

        private void dayEndTImeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dayEndTimeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmChangeEODTime fr = new frmChangeEODTime();

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmChangeEODTime)
                {
                    MessageBox.Show("CHange Day End Window is already open", "Department Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            this.IsMdiContainer = true;
            fr.MdiParent = this;
            fr.Show();
        }

        private void customerReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerReport fr = new frmCustomerReport();

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmCustomerReport)
                {
                    MessageBox.Show("Customer Report Window is already open", "Customer Report", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            this.IsMdiContainer = true;
            fr.MdiParent = this;
            fr.Show();
        }

        private void receiptIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReceiptIssue fr = new frmReceiptIssue();

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmReceiptIssue)
                {
                    MessageBox.Show("Receipt Issue Window is already open", "Receipt Issue", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            this.IsMdiContainer = true;
            fr.MdiParent = this;
            fr.Show();
        }

        private void assignRightsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void showAuditTrailToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            logoutToolStripMenuItem_Click_1(sender, e);
            
        }

        private void deliveryBoyWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeliveryBoyWiseReport fr = new frmDeliveryBoyWiseReport();

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmDeliveryBoyWiseReport)
                {
                    MessageBox.Show("Delivery Boy wise Report Window is already open", "Report Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            this.IsMdiContainer = true;
            fr.MdiParent = this;
            fr.Show();
        }
    }
}
