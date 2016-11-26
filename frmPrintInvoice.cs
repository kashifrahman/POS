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
    public partial class frmPrintInvoice : Form
    {
        public frmPrintInvoice()
        {
            InitializeComponent();
        }

        private void frmPrintInvoice_Load(object sender, EventArgs e)
        {
            try
            {
                string sreportpath;
                //CrystalRptViewer.ParameterFieldInfo.Clear();
                //CrystalRptViewer.RefreshReport();
                sreportpath = Application.StartupPath + "\\" + "InvoicePrint.rpt";
                GlobalClass.WriteLog("Invoice report path:" + sreportpath);
                CrystalDecisions.CrystalReports.Engine.ReportDocument InvoiceDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //KotReport =new KOTReport("KOTReport.rpt");
                GlobalClass.WriteLog("Before Loading Crystal Report");
                InvoiceDocument.Load(sreportpath);
                GlobalClass.WriteLog("After Loading Crystal Report");
                InvoiceDocument.SetDatabaseLogon("sa", "system123#", GlobalClass.gsDBIP, "Salepurchase");                
             //   InvoiceDocument.SetParameterValue("InvoiceNo", "Kashif");
              //  InvoiceDocument.SetParameterValue("PhoneNo", "0501470562");

                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                ds = new DataSet();
                cmd = new SqlCommand();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_FetchInvoiceDetailsForPrint";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 20).Value = "FETCHINVOICE";
                cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, 20).Value = GlobalClass.gsInvoiceNoforPrint;
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "SP_FetchInvoiceDetailsForPrint");
                InvoiceDocument.SetDataSource(ds);
                
                InvoiceDocument.SetParameterValue("InvoiceNo",GlobalClass.gsInvoiceNoforPrint);
                InvoiceDocument.SetParameterValue("PhoneNo",GlobalClass.gsMobNoforPrint);
                InvoiceDocument.SetParameterValue("CustomerName", GlobalClass.gsCustNameforPrint);
                InvoiceDocument.SetParameterValue("OrderType", GlobalClass.gsOrderTypeForPrint);
                InvoiceDocument.SetParameterValue("SalesBy", GlobalClass.gsSalesByforPrint);
                InvoiceDocument.SetParameterValue("DeliveredBy", GlobalClass.gsDeliveredByforPrint);
                InvoiceDocument.SetParameterValue("Address", GlobalClass.gsCustomerAddressforPrint);


                CrystalRptVwrInvoice.ReportSource = InvoiceDocument;
                //CrystalRptViewer.ParameterFieldInfo = f1;
                CrystalRptVwrInvoice.Refresh();
                
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in frmPrintInvoice_Load:" + ex.Message.ToString());
            } 
        }

        private void InvoicePrint1_InitReport(object sender, EventArgs e)
        {

        }
    }
}
