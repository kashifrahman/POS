namespace SalesPurchase
{
    partial class frmKOTPrint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.SP_FetchKOTDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SalesPurchaseDataSet = new SalesPurchase.SalesPurchaseDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SP_FetchKOTDetailsTableAdapter = new SalesPurchase.SalesPurchaseDataSetTableAdapters.SP_FetchKOTDetailsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SP_FetchKOTDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesPurchaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // SP_FetchKOTDetailsBindingSource
            // 
            this.SP_FetchKOTDetailsBindingSource.DataMember = "SP_FetchKOTDetails";
            this.SP_FetchKOTDetailsBindingSource.DataSource = this.SalesPurchaseDataSet;
            // 
            // SalesPurchaseDataSet
            // 
            this.SalesPurchaseDataSet.DataSetName = "SalesPurchaseDataSet";
            this.SalesPurchaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dsKOTPrint";
            reportDataSource1.Value = this.SP_FetchKOTDetailsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SalesPurchase.rptKOTPrint.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(754, 615);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // SP_FetchKOTDetailsTableAdapter
            // 
            this.SP_FetchKOTDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // frmKOTPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 639);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmKOTPrint";
            this.Text = "KOT Print";
            this.Load += new System.EventHandler(this.frmKOTPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SP_FetchKOTDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesPurchaseDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_FetchKOTDetailsBindingSource;
        private SalesPurchaseDataSet SalesPurchaseDataSet;
        private SalesPurchaseDataSetTableAdapters.SP_FetchKOTDetailsTableAdapter SP_FetchKOTDetailsTableAdapter;
    }
}