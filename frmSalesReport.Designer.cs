namespace SalesPurchase
{
    partial class frmSalesReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesReport));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtToInvoiceNo = new System.Windows.Forms.TextBox();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGenerateSalesRpt = new System.Windows.Forms.Button();
            this.cmbSalesBy = new System.Windows.Forms.ComboBox();
            this.cmbItemGroup = new System.Windows.Forms.ComboBox();
            this.cmbItemCode = new System.Windows.Forms.ComboBox();
            this.rbtnCustom = new System.Windows.Forms.Label();
            this.rbtnCustomer = new System.Windows.Forms.RadioButton();
            this.rbtnSa = new System.Windows.Forms.Label();
            this.rbtnSalesMan = new System.Windows.Forms.RadioButton();
            this.rbtnIte = new System.Windows.Forms.Label();
            this.rbtnItemCo = new System.Windows.Forms.Label();
            this.rbtnBillNo = new System.Windows.Forms.Label();
            this.rbtnItemGroup = new System.Windows.Forms.RadioButton();
            this.rbtnItemcode = new System.Windows.Forms.RadioButton();
            this.rbtnInvoiceNo = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtPckrToDate = new System.Windows.Forms.DateTimePicker();
            this.dtPckrFrmDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CrystalReportViewerSales = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.printDocumentSalesReport = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialogSalesReprt = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtToInvoiceNo);
            this.groupBox1.Controls.Add(this.txtInvoiceNo);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnGenerateSalesRpt);
            this.groupBox1.Controls.Add(this.cmbSalesBy);
            this.groupBox1.Controls.Add(this.cmbItemGroup);
            this.groupBox1.Controls.Add(this.cmbItemCode);
            this.groupBox1.Controls.Add(this.rbtnCustom);
            this.groupBox1.Controls.Add(this.rbtnCustomer);
            this.groupBox1.Controls.Add(this.rbtnSa);
            this.groupBox1.Controls.Add(this.rbtnSalesMan);
            this.groupBox1.Controls.Add(this.rbtnIte);
            this.groupBox1.Controls.Add(this.rbtnItemCo);
            this.groupBox1.Controls.Add(this.rbtnBillNo);
            this.groupBox1.Controls.Add(this.rbtnItemGroup);
            this.groupBox1.Controls.Add(this.rbtnItemcode);
            this.groupBox1.Controls.Add(this.rbtnInvoiceNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtPckrToDate);
            this.groupBox1.Controls.Add(this.dtPckrFrmDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1168, 183);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sales Report Criteria";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(293, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 32;
            this.label5.Text = "From Invoice:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(517, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "To Invoice:";
            // 
            // txtToInvoiceNo
            // 
            this.txtToInvoiceNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtToInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtToInvoiceNo.Location = new System.Drawing.Point(588, 56);
            this.txtToInvoiceNo.Name = "txtToInvoiceNo";
            this.txtToInvoiceNo.Size = new System.Drawing.Size(116, 20);
            this.txtToInvoiceNo.TabIndex = 30;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Location = new System.Drawing.Point(379, 57);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(134, 20);
            this.txtInvoiceNo.TabIndex = 29;
            this.txtInvoiceNo.TextChanged += new System.EventHandler(this.txtInvoiceNo_TextChanged);
            this.txtInvoiceNo.Leave += new System.EventHandler(this.txtInvoiceNo_Leave);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(540, 130);
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
            this.btnClear.Location = new System.Drawing.Point(683, 88);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(106, 35);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnGenerateSalesRpt
            // 
            this.btnGenerateSalesRpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateSalesRpt.Location = new System.Drawing.Point(537, 88);
            this.btnGenerateSalesRpt.Name = "btnGenerateSalesRpt";
            this.btnGenerateSalesRpt.Size = new System.Drawing.Size(106, 35);
            this.btnGenerateSalesRpt.TabIndex = 23;
            this.btnGenerateSalesRpt.Text = "Generate Report";
            this.btnGenerateSalesRpt.UseVisualStyleBackColor = true;
            this.btnGenerateSalesRpt.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbSalesBy
            // 
            this.cmbSalesBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSalesBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSalesBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalesBy.FormattingEnabled = true;
            this.cmbSalesBy.Location = new System.Drawing.Point(280, 132);
            this.cmbSalesBy.Name = "cmbSalesBy";
            this.cmbSalesBy.Size = new System.Drawing.Size(233, 21);
            this.cmbSalesBy.TabIndex = 22;
            this.cmbSalesBy.SelectedIndexChanged += new System.EventHandler(this.cmbSalesBy_SelectedIndexChanged);
            // 
            // cmbItemGroup
            // 
            this.cmbItemGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbItemGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemGroup.FormattingEnabled = true;
            this.cmbItemGroup.Location = new System.Drawing.Point(280, 108);
            this.cmbItemGroup.Name = "cmbItemGroup";
            this.cmbItemGroup.Size = new System.Drawing.Size(233, 21);
            this.cmbItemGroup.TabIndex = 21;
            this.cmbItemGroup.SelectedIndexChanged += new System.EventHandler(this.cmbItemGroup_SelectedIndexChanged);
            // 
            // cmbItemCode
            // 
            this.cmbItemCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbItemCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemCode.FormattingEnabled = true;
            this.cmbItemCode.Location = new System.Drawing.Point(280, 81);
            this.cmbItemCode.Name = "cmbItemCode";
            this.cmbItemCode.Size = new System.Drawing.Size(233, 21);
            this.cmbItemCode.TabIndex = 20;
            this.cmbItemCode.SelectedIndexChanged += new System.EventHandler(this.cmbItemCode_SelectedIndexChanged);
            // 
            // rbtnCustom
            // 
            this.rbtnCustom.AutoSize = true;
            this.rbtnCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCustom.Location = new System.Drawing.Point(151, 157);
            this.rbtnCustom.Name = "rbtnCustom";
            this.rbtnCustom.Size = new System.Drawing.Size(258, 15);
            this.rbtnCustom.TabIndex = 19;
            this.rbtnCustom.Text = "Reports By Dead Stock(Items not Sold Report)";
            // 
            // rbtnCustomer
            // 
            this.rbtnCustomer.AutoSize = true;
            this.rbtnCustomer.Location = new System.Drawing.Point(129, 158);
            this.rbtnCustomer.Name = "rbtnCustomer";
            this.rbtnCustomer.Size = new System.Drawing.Size(14, 13);
            this.rbtnCustomer.TabIndex = 18;
            this.rbtnCustomer.TabStop = true;
            this.rbtnCustomer.UseVisualStyleBackColor = true;
            this.rbtnCustomer.CheckedChanged += new System.EventHandler(this.rbtnCustomer_CheckedChanged);
            // 
            // rbtnSa
            // 
            this.rbtnSa.AutoSize = true;
            this.rbtnSa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSa.Location = new System.Drawing.Point(149, 132);
            this.rbtnSa.Name = "rbtnSa";
            this.rbtnSa.Size = new System.Drawing.Size(128, 15);
            this.rbtnSa.TabIndex = 17;
            this.rbtnSa.Text = "Reports By Sales Man";
            this.rbtnSa.Click += new System.EventHandler(this.rbtnSalesMan_Click);
            // 
            // rbtnSalesMan
            // 
            this.rbtnSalesMan.AutoSize = true;
            this.rbtnSalesMan.Location = new System.Drawing.Point(129, 132);
            this.rbtnSalesMan.Name = "rbtnSalesMan";
            this.rbtnSalesMan.Size = new System.Drawing.Size(14, 13);
            this.rbtnSalesMan.TabIndex = 16;
            this.rbtnSalesMan.TabStop = true;
            this.rbtnSalesMan.UseVisualStyleBackColor = true;
            this.rbtnSalesMan.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // rbtnIte
            // 
            this.rbtnIte.AutoSize = true;
            this.rbtnIte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnIte.Location = new System.Drawing.Point(149, 108);
            this.rbtnIte.Name = "rbtnIte";
            this.rbtnIte.Size = new System.Drawing.Size(130, 15);
            this.rbtnIte.TabIndex = 15;
            this.rbtnIte.Text = "Reports By Item Group";
            this.rbtnIte.Click += new System.EventHandler(this.rbtnItemGroup_Click);
            // 
            // rbtnItemCo
            // 
            this.rbtnItemCo.AutoSize = true;
            this.rbtnItemCo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnItemCo.Location = new System.Drawing.Point(149, 80);
            this.rbtnItemCo.Name = "rbtnItemCo";
            this.rbtnItemCo.Size = new System.Drawing.Size(130, 15);
            this.rbtnItemCo.TabIndex = 14;
            this.rbtnItemCo.Text = "Reports By Item Name";
            this.rbtnItemCo.Click += new System.EventHandler(this.rbtnItemCode_Click);
            // 
            // rbtnBillNo
            // 
            this.rbtnBillNo.AutoSize = true;
            this.rbtnBillNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnBillNo.Location = new System.Drawing.Point(149, 57);
            this.rbtnBillNo.Name = "rbtnBillNo";
            this.rbtnBillNo.Size = new System.Drawing.Size(126, 15);
            this.rbtnBillNo.TabIndex = 9;
            this.rbtnBillNo.Text = "Reports By Invoice No";
            this.rbtnBillNo.Click += new System.EventHandler(this.rbtnBillNo_Click);
            // 
            // rbtnItemGroup
            // 
            this.rbtnItemGroup.AutoSize = true;
            this.rbtnItemGroup.Location = new System.Drawing.Point(129, 108);
            this.rbtnItemGroup.Name = "rbtnItemGroup";
            this.rbtnItemGroup.Size = new System.Drawing.Size(14, 13);
            this.rbtnItemGroup.TabIndex = 8;
            this.rbtnItemGroup.TabStop = true;
            this.rbtnItemGroup.UseVisualStyleBackColor = true;
            this.rbtnItemGroup.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // rbtnItemcode
            // 
            this.rbtnItemcode.AutoSize = true;
            this.rbtnItemcode.Location = new System.Drawing.Point(129, 80);
            this.rbtnItemcode.Name = "rbtnItemcode";
            this.rbtnItemcode.Size = new System.Drawing.Size(14, 13);
            this.rbtnItemcode.TabIndex = 7;
            this.rbtnItemcode.TabStop = true;
            this.rbtnItemcode.UseVisualStyleBackColor = true;
            this.rbtnItemcode.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rbtnInvoiceNo
            // 
            this.rbtnInvoiceNo.AutoSize = true;
            this.rbtnInvoiceNo.Location = new System.Drawing.Point(129, 58);
            this.rbtnInvoiceNo.Name = "rbtnInvoiceNo";
            this.rbtnInvoiceNo.Size = new System.Drawing.Size(14, 13);
            this.rbtnInvoiceNo.TabIndex = 6;
            this.rbtnInvoiceNo.TabStop = true;
            this.rbtnInvoiceNo.UseVisualStyleBackColor = true;
            this.rbtnInvoiceNo.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(417, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(119, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "From";
            // 
            // dtPckrToDate
            // 
            this.dtPckrToDate.CustomFormat = "DD/MM/YYYY";
            this.dtPckrToDate.Location = new System.Drawing.Point(444, 13);
            this.dtPckrToDate.Name = "dtPckrToDate";
            this.dtPckrToDate.Size = new System.Drawing.Size(200, 20);
            this.dtPckrToDate.TabIndex = 1;
            // 
            // dtPckrFrmDate
            // 
            this.dtPckrFrmDate.CustomFormat = "DD/MM/YYYY";
            this.dtPckrFrmDate.Location = new System.Drawing.Point(161, 13);
            this.dtPckrFrmDate.Name = "dtPckrFrmDate";
            this.dtPckrFrmDate.Size = new System.Drawing.Size(179, 20);
            this.dtPckrFrmDate.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CrystalReportViewerSales);
            this.groupBox2.Location = new System.Drawing.Point(12, 201);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1168, 475);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sales Report Details";
            // 
            // CrystalReportViewerSales
            // 
            this.CrystalReportViewerSales.ActiveViewIndex = -1;
            this.CrystalReportViewerSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrystalReportViewerSales.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrystalReportViewerSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrystalReportViewerSales.Location = new System.Drawing.Point(3, 16);
            this.CrystalReportViewerSales.Name = "CrystalReportViewerSales";
            this.CrystalReportViewerSales.Size = new System.Drawing.Size(1162, 456);
            this.CrystalReportViewerSales.TabIndex = 0;
            this.CrystalReportViewerSales.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
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
            // frmSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 688);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSalesReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Report";
            this.Load += new System.EventHandler(this.frmSalesReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnItemGroup;
        private System.Windows.Forms.RadioButton rbtnItemcode;
        private System.Windows.Forms.RadioButton rbtnInvoiceNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtPckrToDate;
        private System.Windows.Forms.DateTimePicker dtPckrFrmDate;
        private System.Windows.Forms.Label rbtnBillNo;
        private System.Windows.Forms.Label rbtnCustom;
        private System.Windows.Forms.RadioButton rbtnCustomer;
        private System.Windows.Forms.Label rbtnSa;
        private System.Windows.Forms.RadioButton rbtnSalesMan;
        private System.Windows.Forms.Label rbtnIte;
        private System.Windows.Forms.Label rbtnItemCo;
        private System.Windows.Forms.ComboBox cmbSalesBy;
        private System.Windows.Forms.ComboBox cmbItemGroup;
        private System.Windows.Forms.ComboBox cmbItemCode;
        private System.Windows.Forms.Button btnGenerateSalesRpt;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Drawing.Printing.PrintDocument printDocumentSalesReport;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialogSalesReprt;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer CrystalReportViewerSales;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtToInvoiceNo;
    }
}