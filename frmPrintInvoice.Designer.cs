namespace SalesPurchase
{
    partial class frmPrintInvoice
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
            this.CrystalRptVwrInvoice = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrystalRptVwrInvoice
            // 
            this.CrystalRptVwrInvoice.ActiveViewIndex = -1;
            this.CrystalRptVwrInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalRptVwrInvoice.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrystalRptVwrInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrystalRptVwrInvoice.Location = new System.Drawing.Point(0, 0);
            this.CrystalRptVwrInvoice.Name = "CrystalRptVwrInvoice";
            this.CrystalRptVwrInvoice.Size = new System.Drawing.Size(880, 491);
            this.CrystalRptVwrInvoice.TabIndex = 0;
            this.CrystalRptVwrInvoice.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmPrintInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 491);
            this.Controls.Add(this.CrystalRptVwrInvoice);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrintInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Invoice";
            this.Load += new System.EventHandler(this.frmPrintInvoice_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalRptVwrInvoice;
    }
}