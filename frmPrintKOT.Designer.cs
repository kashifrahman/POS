namespace SalesPurchase
{
    partial class frmPrintKOT
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
            this.CrystalRptViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.KOTReport = new SalesPurchase.KOTReport();
            this.SuspendLayout();
            // 
            // CrystalRptViewer
            // 
            this.CrystalRptViewer.ActiveViewIndex = 0;
            this.CrystalRptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalRptViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrystalRptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrystalRptViewer.Location = new System.Drawing.Point(0, 0);
            this.CrystalRptViewer.Name = "CrystalRptViewer";
            this.CrystalRptViewer.ReportSource = this.KOTReport;
            this.CrystalRptViewer.Size = new System.Drawing.Size(874, 588);
            this.CrystalRptViewer.TabIndex = 0;
            this.CrystalRptViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.CrystalRptViewer.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // frmPrintKOT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 588);
            this.Controls.Add(this.CrystalRptViewer);
            this.Name = "frmPrintKOT";
            this.Text = "Print KOT";
            this.Load += new System.EventHandler(this.frmPrintKOT_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalRptViewer;
        private KOTReport KOTReport;
    }
}