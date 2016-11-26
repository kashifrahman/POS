using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
using System.Data.SqlClient;


namespace SalesPurchase
{
    public partial class frmPrintKOT : Form
    {
        public frmPrintKOT()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                string sreportpath;
                //CrystalRptViewer.ParameterFieldInfo.Clear();
                //CrystalRptViewer.RefreshReport();
                sreportpath = Application.StartupPath + "\\" + "KOTReport.rpt";
                CrystalDecisions.CrystalReports.Engine.ReportDocument KotReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //KotReport =new KOTReport("KOTReport.rpt");
                KotReport.Load(sreportpath);
                KotReport.SetDatabaseLogon("sa", "system123#", GlobalClass.gsDBIP, "Salepurchase");
                
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                ds = new DataSet();
                cmd = new SqlCommand();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_FetchKOTDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10).Value = "FETCH";
                cmd.Parameters.Add("@Kotid", SqlDbType.VarChar, GlobalClass.gsKOTIDforPrint.Length).Value = GlobalClass.gsKOTIDforPrint;
                ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "SP_FetchKOTDetails");
                KotReport.SetDataSource(ds);

                //*************************************

                //CrystalRptViewer.RefreshReport();

                //ParameterFields paramFields = new ParameterFields();

                //ParameterField KOTID = new ParameterField();

                //KOTID.Name = "KOTID"; //year is Crystal Report Parameter name.

                //ParameterDiscreteValue kVal = new ParameterDiscreteValue();

                //kVal.Value = GlobalClass.gsKOTIDforPrint;

                //KOTID.CurrentValues.Add(kVal);

                //paramFields.Add(KOTID);
                //CrystalRptViewer.ParameterFieldInfo.Clear();

                //CrystalRptViewer.ParameterFieldInfo = paramFields;


                //*************************************
                //CrystalRptViewer.ParameterFieldInfo.Clear();
                KotReport.SetParameterValue("CNAME", "Kashif");
                KotReport.SetParameterValue("KOTID", "Rahman");
                //ParameterField c1 = new ParameterField();
                //ParameterFields f1 = new ParameterFields();
                //ParameterDiscreteValue val1 = new ParameterDiscreteValue();
                //c1.Name = "CNAME";
                //val1.Value = GlobalClass.gsKOTIDforPrint;
                //c1.CurrentValues.Add(val1);
                //KotReport.DataDefinition.ParameterFields["CNAME"].ApplyCurrentValues(c1.CurrentValues);

                //f1.Add(c1);
                //KotReport.ParameterFields.Add(c1);


                //KotReport.SetParameterValue(0, GlobalClass.gsKOTIDforPrint);

                //KotReport.SetDataSource(ds);

                CrystalRptViewer.ReportSource = KotReport;
                //CrystalRptViewer.ParameterFieldInfo = f1;
                CrystalRptViewer.Refresh();
            }
            catch (Exception ex)
            {
            } 
        }
        private void frmPrintKOT_Load(object sender, EventArgs e)
        {

            crystalReportViewer1_Load(sender, e);
            ////try
            ////{
            ////    string sreportpath;
            ////    sreportpath = Application.StartupPath + "\\" + "KOTReport.rpt";
            ////    CrystalDecisions.CrystalReports.Engine.ReportDocument KotReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            ////    //KotReport =new KOTReport("KOTReport.rpt");
            ////    KotReport.Load(sreportpath);
            ////    KotReport.SetDatabaseLogon("sa", "system123#", GlobalClass.gsDBIP, "Salepurchase");
            ////    DataSet ds = new DataSet();
            ////    SqlCommand cmd = new SqlCommand();
    
            ////    ds = new DataSet();
            ////    cmd = new SqlCommand();
            ////    cmd.Connection = GlobalClass.gCon;
            ////    cmd.CommandText = "SP_FetchKOTDetails";
            ////    cmd.CommandType = CommandType.StoredProcedure;
            ////    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10).Value = "FETCH";
            ////    cmd.Parameters.Add("@Kotid", SqlDbType.VarChar, GlobalClass.gsKOTIDforPrint.Length).Value = GlobalClass.gsKOTIDforPrint;
            ////    ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "SP_FetchKOTDetails");

            ////    CrystalRptViewer.ParameterFieldInfo.Clear();
            ////    KOTReport.SetParameterValue("CNAME", "Kashif");
            ////    KOTReport.SetParameterValue("KOTID", "Rahman");
            ////    //ParameterField c1 = new ParameterField();
            ////    //ParameterFields f1 = new ParameterFields();
            ////    //ParameterDiscreteValue val1 = new ParameterDiscreteValue();
            ////    //c1.Name = "CNAME";
            ////    //val1.Value = GlobalClass.gsKOTIDforPrint;
            ////    //c1.CurrentValues.Add(val1);
            ////    //KotReport.DataDefinition.ParameterFields["CNAME"].ApplyCurrentValues(c1.CurrentValues);

            ////    //f1.Add(c1);
            ////    //KotReport.ParameterFields.Add(c1);
               

            ////    //KotReport.SetParameterValue(0, GlobalClass.gsKOTIDforPrint);
                
            ////    KotReport.SetDataSource(ds); 
                
            ////    CrystalRptViewer.ReportSource = KotReport;
            ////    //CrystalRptViewer.ParameterFieldInfo = f1;
            ////    CrystalRptViewer.Refresh(); 
            ////}
            ////catch (Exception ex)
            ////{
            ////}          
        }
    }
}
