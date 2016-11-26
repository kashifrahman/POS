namespace SalesPurchase
{
    partial class frmReports
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReports));
            this.btnGenerateRpt = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtPckrFrom = new System.Windows.Forms.DateTimePicker();
            this.dtPckrTo = new System.Windows.Forms.DateTimePicker();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.mskdtxtToDate = new System.Windows.Forms.MaskedTextBox();
            this.dgReports = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.mskdtxtFromDate = new System.Windows.Forms.MaskedTextBox();
            this.rptViewerReports = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgReports)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerateRpt
            // 
            this.btnGenerateRpt.Location = new System.Drawing.Point(349, 68);
            this.btnGenerateRpt.Name = "btnGenerateRpt";
            this.btnGenerateRpt.Size = new System.Drawing.Size(102, 28);
            this.btnGenerateRpt.TabIndex = 0;
            this.btnGenerateRpt.Text = "Generate Report";
            this.btnGenerateRpt.UseVisualStyleBackColor = true;
            this.btnGenerateRpt.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(588, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "From Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Report Type";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dtPckrFrom
            // 
            this.dtPckrFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPckrFrom.Location = new System.Drawing.Point(28, 76);
            this.dtPckrFrom.Name = "dtPckrFrom";
            this.dtPckrFrom.Size = new System.Drawing.Size(28, 20);
            this.dtPckrFrom.TabIndex = 5;
            this.dtPckrFrom.ValueChanged += new System.EventHandler(this.dtPckrFrom_ValueChanged);
            // 
            // dtPckrTo
            // 
            this.dtPckrTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPckrTo.Location = new System.Drawing.Point(184, 75);
            this.dtPckrTo.Name = "dtPckrTo";
            this.dtPckrTo.Size = new System.Drawing.Size(25, 20);
            this.dtPckrTo.TabIndex = 6;
            this.dtPckrTo.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(197, 19);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(280, 21);
            this.cmbReportType.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(181, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "To Date";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.mskdtxtToDate);
            this.groupBox1.Controls.Add(this.dgReports);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.mskdtxtFromDate);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnGenerateRpt);
            this.groupBox1.Controls.Add(this.cmbReportType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtPckrFrom);
            this.groupBox1.Controls.Add(this.dtPckrTo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1133, 101);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(475, 68);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 28);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "(yyyy-MM-dd)";
            // 
            // mskdtxtToDate
            // 
            this.mskdtxtToDate.BeepOnError = true;
            this.mskdtxtToDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskdtxtToDate.Location = new System.Drawing.Point(215, 75);
            this.mskdtxtToDate.Mask = "0000-00-00";
            this.mskdtxtToDate.Name = "mskdtxtToDate";
            this.mskdtxtToDate.Size = new System.Drawing.Size(116, 20);
            this.mskdtxtToDate.TabIndex = 10;
            this.mskdtxtToDate.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.mskdtxtToDate_TypeValidationCompleted);
            this.mskdtxtToDate.Leave += new System.EventHandler(this.mskdtxtToDate_Leave);
            // 
            // dgReports
            // 
            this.dgReports.AllowUserToAddRows = false;
            this.dgReports.AllowUserToDeleteRows = false;
            this.dgReports.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgReports.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgReports.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgReports.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReports.Location = new System.Drawing.Point(736, 18);
            this.dgReports.Name = "dgReports";
            this.dgReports.ReadOnly = true;
            this.dgReports.Size = new System.Drawing.Size(391, 77);
            this.dgReports.TabIndex = 10;
            this.dgReports.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "(yyyy-MM-dd)";
            // 
            // mskdtxtFromDate
            // 
            this.mskdtxtFromDate.BeepOnError = true;
            this.mskdtxtFromDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskdtxtFromDate.Location = new System.Drawing.Point(62, 76);
            this.mskdtxtFromDate.Mask = "0000-00-00";
            this.mskdtxtFromDate.Name = "mskdtxtFromDate";
            this.mskdtxtFromDate.Size = new System.Drawing.Size(100, 20);
            this.mskdtxtFromDate.TabIndex = 9;
            this.mskdtxtFromDate.ValidatingType = typeof(System.DateTime);
            this.mskdtxtFromDate.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mskdtxtFromDate_MaskInputRejected);
            this.mskdtxtFromDate.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.mskdtxtFromDate_TypeValidationCompleted);
            this.mskdtxtFromDate.Leave += new System.EventHandler(this.mskdtxtFromDate_Leave);
            // 
            // rptViewerReports
            // 
            this.rptViewerReports.ActiveViewIndex = -1;
            this.rptViewerReports.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rptViewerReports.Cursor = System.Windows.Forms.Cursors.Default;
            this.rptViewerReports.Location = new System.Drawing.Point(16, 19);
            this.rptViewerReports.Name = "rptViewerReports";
            this.rptViewerReports.Size = new System.Drawing.Size(1111, 585);
            this.rptViewerReports.TabIndex = 12;
            this.rptViewerReports.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.rptViewerReports.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rptViewerReports);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(12, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1133, 610);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Display Reports";
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 741);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgReports)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateRpt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtPckrFrom;
        private System.Windows.Forms.DateTimePicker dtPckrTo;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox mskdtxtToDate;
        private System.Windows.Forms.MaskedTextBox mskdtxtFromDate;
        private System.Windows.Forms.DataGridView dgReports;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer rptViewerReports;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClear;
    }
}