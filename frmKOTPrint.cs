using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SalesPurchase
{
    public partial class frmKOTPrint : Form
    {
        public frmKOTPrint()
        {
            InitializeComponent();
        }

        private void frmKOTPrint_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'SalesPurchaseDataSet.SP_FetchKOTDetails' table. You can move, or remove it, as needed.
                ReportParameterCollection KOTID = new ReportParameterCollection();
                KOTID.Add(new ReportParameter("KOTID", GlobalClass.gsKOTIDforPrint));
                reportViewer1.LocalReport.SetParameters(KOTID);

                ReportParameterCollection Customer = new ReportParameterCollection();
                Customer.Add(new ReportParameter("Customer", GlobalClass.gsCustomerNameforPrint));
                reportViewer1.LocalReport.SetParameters(Customer);

                ReportParameterCollection CustomerAddess = new ReportParameterCollection();
                CustomerAddess.Add(new ReportParameter("CustomerAddress", GlobalClass.gsCustomerAddressforPrint));
                reportViewer1.LocalReport.SetParameters(CustomerAddess);

                ReportParameterCollection OrderType = new ReportParameterCollection();
                OrderType.Add(new ReportParameter("OrderType", GlobalClass.gsOrderTypeforPrint));
                reportViewer1.LocalReport.SetParameters(OrderType);

                //string sDatetime="";
                //sDatetime=DateTime.Now.ToString();

                //ReportParameterCollection DateTime = new ReportParameterCollection();
                //DateTime.Add(new ReportParameter("DateTime", sDatetime));
                //reportViewer1.LocalReport.SetParameters(DateTime);

                this.SP_FetchKOTDetailsTableAdapter.Fill(this.SalesPurchaseDataSet.SP_FetchKOTDetails, "FETCH", GlobalClass.gsKOTIDforPrint);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {

            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
