namespace SalesPurchase
{
    partial class frmDeliveryBoyWiseReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeliveryBoyWiseReport));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbDeliveredBy = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtPckrToDate = new System.Windows.Forms.DateTimePicker();
            this.dtPckrFrmDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnGenerateSalesRpt = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.printDocumentSalesReport = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialogSalesReprt = new System.Windows.Forms.PrintPreviewDialog();
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmbDeliveredBy);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtPckrToDate);
            this.groupBox1.Controls.Add(this.dtPckrFrmDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(887, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delivery Boy Wise Report Criteria";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 35);
            this.button1.TabIndex = 31;
            this.button1.Text = "Generate Crystal Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // cmbDeliveredBy
            // 
            this.cmbDeliveredBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDeliveredBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDeliveredBy.FormattingEnabled = true;
            this.cmbDeliveredBy.Location = new System.Drawing.Point(159, 50);
            this.cmbDeliveredBy.Name = "cmbDeliveredBy";
            this.cmbDeliveredBy.Size = new System.Drawing.Size(195, 21);
            this.cmbDeliveredBy.TabIndex = 28;
            this.cmbDeliveredBy.SelectedIndexChanged += new System.EventHandler(this.cmbDeliveredBy_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 15);
            this.label4.TabIndex = 27;
            this.label4.Text = "Reports By Delivered Boy";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(284, 85);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(106, 35);
            this.btnExit.TabIndex = 25;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(172, 85);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(106, 35);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(307, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "From";
            // 
            // dtPckrToDate
            // 
            this.dtPckrToDate.CustomFormat = "DD/MM/YYYY";
            this.dtPckrToDate.Location = new System.Drawing.Point(334, 22);
            this.dtPckrToDate.Name = "dtPckrToDate";
            this.dtPckrToDate.Size = new System.Drawing.Size(200, 20);
            this.dtPckrToDate.TabIndex = 1;
            // 
            // dtPckrFrmDate
            // 
            this.dtPckrFrmDate.CustomFormat = "DD/MM/YYYY";
            this.dtPckrFrmDate.Location = new System.Drawing.Point(51, 22);
            this.dtPckrFrmDate.Name = "dtPckrFrmDate";
            this.dtPckrFrmDate.Size = new System.Drawing.Size(179, 20);
            this.dtPckrFrmDate.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(932, 75);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(106, 35);
            this.btnPrint.TabIndex = 30;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnGenerateSalesRpt
            // 
            this.btnGenerateSalesRpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateSalesRpt.Location = new System.Drawing.Point(918, 19);
            this.btnGenerateSalesRpt.Name = "btnGenerateSalesRpt";
            this.btnGenerateSalesRpt.Size = new System.Drawing.Size(106, 35);
            this.btnGenerateSalesRpt.TabIndex = 23;
            this.btnGenerateSalesRpt.Text = "Generate Report";
            this.btnGenerateSalesRpt.UseVisualStyleBackColor = true;
            this.btnGenerateSalesRpt.Visible = false;
            this.btnGenerateSalesRpt.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(901, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 15);
            this.label5.TabIndex = 31;
            this.label5.Text = "Total Records:";
            this.label5.Visible = false;
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecords.Location = new System.Drawing.Point(997, 57);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(41, 15);
            this.lblTotalRecords.TabIndex = 32;
            this.lblTotalRecords.Text = "None";
            this.lblTotalRecords.Visible = false;
            // 
            // printDocumentSalesReport
            // 
            this.printDocumentSalesReport.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumentSalesReport_PrintPage);
            // 
            // printPreviewDialogSalesReprt
            // 
            this.printPreviewDialogSalesReprt.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialogSalesReprt.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialogSalesReprt.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialogSalesReprt.Enabled = true;
            this.printPreviewDialogSalesReprt.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialogSalesReprt.Icon")));
            this.printPreviewDialogSalesReprt.Name = "printPreviewDialogSalesReprt";
            this.printPreviewDialogSalesReprt.Visible = false;
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.Location = new System.Drawing.Point(12, 146);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.ShowGroupTreeButton = false;
            this.crystalReportViewer.Size = new System.Drawing.Size(1003, 487);
            this.crystalReportViewer.TabIndex = 2;
            this.crystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmDeliveryBoyWiseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 645);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.crystalReportViewer);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGenerateSalesRpt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeliveryBoyWiseReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delivery Boy Wise Report";
            this.Load += new System.EventHandler(this.frmSalesReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtPckrToDate;
        private System.Windows.Forms.DateTimePicker dtPckrFrmDate;
        private System.Windows.Forms.Button btnGenerateSalesRpt;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cmbDeliveredBy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocumentSalesReport;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialogSalesReprt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Button button1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
    }
}