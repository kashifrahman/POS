namespace SalesPurchase
{
    partial class frmCustomerReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerReport));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExportReport = new System.Windows.Forms.Button();
            this.btnSearchCust = new System.Windows.Forms.Button();
            this.btnGenerateRep = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbReligion = new System.Windows.Forms.ComboBox();
            this.cmbEvent = new System.Windows.Forms.ComboBox();
            this.cmbCustName = new System.Windows.Forms.ComboBox();
            this.cmbCustomerName = new System.Windows.Forms.ComboBox();
            this.rbtnReligion = new System.Windows.Forms.RadioButton();
            this.rbtnByEvent = new System.Windows.Forms.RadioButton();
            this.rbtnCustomerNotVisisted = new System.Windows.Forms.RadioButton();
            this.rbtnByCustomerVisited = new System.Windows.Forms.RadioButton();
            this.dtpckrToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpckrFrom = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbltotalrecord = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgDisplayCustomerRep = new System.Windows.Forms.DataGridView();
            this.txtTotalCount = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDisplayCustomerRep)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbReligion);
            this.groupBox1.Controls.Add(this.cmbEvent);
            this.groupBox1.Controls.Add(this.cmbCustName);
            this.groupBox1.Controls.Add(this.cmbCustomerName);
            this.groupBox1.Controls.Add(this.rbtnReligion);
            this.groupBox1.Controls.Add(this.rbtnByEvent);
            this.groupBox1.Controls.Add(this.rbtnCustomerNotVisisted);
            this.groupBox1.Controls.Add(this.rbtnByCustomerVisited);
            this.groupBox1.Controls.Add(this.dtpckrToDate);
            this.groupBox1.Controls.Add(this.dtpckrFrom);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(905, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Criteria";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExportReport);
            this.groupBox3.Controls.Add(this.btnSearchCust);
            this.groupBox3.Controls.Add(this.btnGenerateRep);
            this.groupBox3.Controls.Add(this.btnExit);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Location = new System.Drawing.Point(403, 39);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(489, 100);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            // 
            // btnExportReport
            // 
            this.btnExportReport.Location = new System.Drawing.Point(142, 53);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Size = new System.Drawing.Size(110, 31);
            this.btnExportReport.TabIndex = 20;
            this.btnExportReport.Text = "Export Report";
            this.btnExportReport.UseVisualStyleBackColor = true;
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);
            // 
            // btnSearchCust
            // 
            this.btnSearchCust.Location = new System.Drawing.Point(6, 54);
            this.btnSearchCust.Name = "btnSearchCust";
            this.btnSearchCust.Size = new System.Drawing.Size(113, 31);
            this.btnSearchCust.TabIndex = 19;
            this.btnSearchCust.Text = "Search Customer";
            this.btnSearchCust.UseVisualStyleBackColor = true;
            this.btnSearchCust.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGenerateRep
            // 
            this.btnGenerateRep.Location = new System.Drawing.Point(6, 13);
            this.btnGenerateRep.Name = "btnGenerateRep";
            this.btnGenerateRep.Size = new System.Drawing.Size(113, 31);
            this.btnGenerateRep.TabIndex = 16;
            this.btnGenerateRep.Text = "Generate Report";
            this.btnGenerateRep.UseVisualStyleBackColor = true;
            this.btnGenerateRep.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(280, 13);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 31);
            this.btnExit.TabIndex = 18;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(141, 13);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(113, 31);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(323, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "To Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "From Date";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // cmbReligion
            // 
            this.cmbReligion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbReligion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbReligion.FormattingEnabled = true;
            this.cmbReligion.Location = new System.Drawing.Point(190, 118);
            this.cmbReligion.Name = "cmbReligion";
            this.cmbReligion.Size = new System.Drawing.Size(207, 21);
            this.cmbReligion.TabIndex = 13;
            this.cmbReligion.SelectedIndexChanged += new System.EventHandler(this.cmbReligion_SelectedIndexChanged);
            // 
            // cmbEvent
            // 
            this.cmbEvent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbEvent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEvent.FormattingEnabled = true;
            this.cmbEvent.Location = new System.Drawing.Point(190, 93);
            this.cmbEvent.Name = "cmbEvent";
            this.cmbEvent.Size = new System.Drawing.Size(207, 21);
            this.cmbEvent.TabIndex = 12;
            this.cmbEvent.SelectedIndexChanged += new System.EventHandler(this.cmbEvent_SelectedIndexChanged);
            // 
            // cmbCustName
            // 
            this.cmbCustName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCustName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustName.FormattingEnabled = true;
            this.cmbCustName.Location = new System.Drawing.Point(190, 67);
            this.cmbCustName.Name = "cmbCustName";
            this.cmbCustName.Size = new System.Drawing.Size(207, 21);
            this.cmbCustName.TabIndex = 11;
            this.cmbCustName.SelectedIndexChanged += new System.EventHandler(this.cmbCustName_SelectedIndexChanged);
            // 
            // cmbCustomerName
            // 
            this.cmbCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomerName.FormattingEnabled = true;
            this.cmbCustomerName.Location = new System.Drawing.Point(190, 39);
            this.cmbCustomerName.Name = "cmbCustomerName";
            this.cmbCustomerName.Size = new System.Drawing.Size(207, 21);
            this.cmbCustomerName.TabIndex = 10;
            this.cmbCustomerName.Visible = false;
            this.cmbCustomerName.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerName_SelectedIndexChanged);
            // 
            // rbtnReligion
            // 
            this.rbtnReligion.AutoSize = true;
            this.rbtnReligion.Location = new System.Drawing.Point(40, 118);
            this.rbtnReligion.Name = "rbtnReligion";
            this.rbtnReligion.Size = new System.Drawing.Size(78, 17);
            this.rbtnReligion.TabIndex = 5;
            this.rbtnReligion.TabStop = true;
            this.rbtnReligion.Text = "By Religion";
            this.rbtnReligion.UseVisualStyleBackColor = true;
            this.rbtnReligion.CheckedChanged += new System.EventHandler(this.rbtnReligion_CheckedChanged);
            // 
            // rbtnByEvent
            // 
            this.rbtnByEvent.AutoSize = true;
            this.rbtnByEvent.Location = new System.Drawing.Point(40, 92);
            this.rbtnByEvent.Name = "rbtnByEvent";
            this.rbtnByEvent.Size = new System.Drawing.Size(68, 17);
            this.rbtnByEvent.TabIndex = 4;
            this.rbtnByEvent.TabStop = true;
            this.rbtnByEvent.Text = "By Event";
            this.rbtnByEvent.UseVisualStyleBackColor = true;
            this.rbtnByEvent.CheckedChanged += new System.EventHandler(this.rbtnByEvent_CheckedChanged);
            // 
            // rbtnCustomerNotVisisted
            // 
            this.rbtnCustomerNotVisisted.AutoSize = true;
            this.rbtnCustomerNotVisisted.Location = new System.Drawing.Point(40, 68);
            this.rbtnCustomerNotVisisted.Name = "rbtnCustomerNotVisisted";
            this.rbtnCustomerNotVisisted.Size = new System.Drawing.Size(118, 17);
            this.rbtnCustomerNotVisisted.TabIndex = 3;
            this.rbtnCustomerNotVisisted.TabStop = true;
            this.rbtnCustomerNotVisisted.Text = "By Customer Visited";
            this.rbtnCustomerNotVisisted.UseVisualStyleBackColor = true;
            this.rbtnCustomerNotVisisted.CheckedChanged += new System.EventHandler(this.rbtnCustomerNotVisisted_CheckedChanged);
            // 
            // rbtnByCustomerVisited
            // 
            this.rbtnByCustomerVisited.AutoSize = true;
            this.rbtnByCustomerVisited.Location = new System.Drawing.Point(40, 43);
            this.rbtnByCustomerVisited.Name = "rbtnByCustomerVisited";
            this.rbtnByCustomerVisited.Size = new System.Drawing.Size(88, 17);
            this.rbtnByCustomerVisited.TabIndex = 2;
            this.rbtnByCustomerVisited.TabStop = true;
            this.rbtnByCustomerVisited.Text = "By Sale Type";
            this.rbtnByCustomerVisited.UseVisualStyleBackColor = true;
            this.rbtnByCustomerVisited.CheckedChanged += new System.EventHandler(this.rbtnByCustomerVisited_CheckedChanged);
            // 
            // dtpckrToDate
            // 
            this.dtpckrToDate.Location = new System.Drawing.Point(395, 16);
            this.dtpckrToDate.Name = "dtpckrToDate";
            this.dtpckrToDate.Size = new System.Drawing.Size(102, 20);
            this.dtpckrToDate.TabIndex = 1;
            // 
            // dtpckrFrom
            // 
            this.dtpckrFrom.Location = new System.Drawing.Point(122, 13);
            this.dtpckrFrom.Name = "dtpckrFrom";
            this.dtpckrFrom.Size = new System.Drawing.Size(101, 20);
            this.dtpckrFrom.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTotalAmount);
            this.groupBox2.Controls.Add(this.txtTotalCount);
            this.groupBox2.Controls.Add(this.lbltotalrecord);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dgDisplayCustomerRep);
            this.groupBox2.Location = new System.Drawing.Point(12, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(905, 416);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report Data";
            // 
            // lbltotalrecord
            // 
            this.lbltotalrecord.AutoSize = true;
            this.lbltotalrecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalrecord.Location = new System.Drawing.Point(84, 387);
            this.lbltotalrecord.Name = "lbltotalrecord";
            this.lbltotalrecord.Size = new System.Drawing.Size(37, 13);
            this.lbltotalrecord.TabIndex = 2;
            this.lbltotalrecord.Text = "None";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 387);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Total Records:";
            // 
            // dgDisplayCustomerRep
            // 
            this.dgDisplayCustomerRep.AllowUserToDeleteRows = false;
            this.dgDisplayCustomerRep.AllowUserToResizeRows = false;
            this.dgDisplayCustomerRep.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgDisplayCustomerRep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDisplayCustomerRep.Location = new System.Drawing.Point(6, 19);
            this.dgDisplayCustomerRep.Name = "dgDisplayCustomerRep";
            this.dgDisplayCustomerRep.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgDisplayCustomerRep.Size = new System.Drawing.Size(886, 355);
            this.dgDisplayCustomerRep.TabIndex = 0;
            this.dgDisplayCustomerRep.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDisplayCustomerRep_CellContentClick);
            this.dgDisplayCustomerRep.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDisplayCustomerRep_CellDoubleClick);
            // 
            // txtTotalCount
            // 
            this.txtTotalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCount.Location = new System.Drawing.Point(178, 380);
            this.txtTotalCount.Name = "txtTotalCount";
            this.txtTotalCount.ReadOnly = true;
            this.txtTotalCount.Size = new System.Drawing.Size(100, 22);
            this.txtTotalCount.TabIndex = 3;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(297, 378);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(100, 22);
            this.txtTotalAmount.TabIndex = 4;
            // 
            // frmCustomerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 588);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomerReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Report";
            this.Load += new System.EventHandler(this.frmCustomerReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDisplayCustomerRep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpckrToDate;
        private System.Windows.Forms.DateTimePicker dtpckrFrom;
        private System.Windows.Forms.RadioButton rbtnReligion;
        private System.Windows.Forms.RadioButton rbtnByEvent;
        private System.Windows.Forms.RadioButton rbtnCustomerNotVisisted;
        private System.Windows.Forms.RadioButton rbtnByCustomerVisited;
        private System.Windows.Forms.ComboBox cmbReligion;
        private System.Windows.Forms.ComboBox cmbEvent;
        private System.Windows.Forms.ComboBox cmbCustName;
        private System.Windows.Forms.ComboBox cmbCustomerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGenerateRep;
        private System.Windows.Forms.DataGridView dgDisplayCustomerRep;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSearchCust;
        private System.Windows.Forms.Button btnExportReport;
        private System.Windows.Forms.Label lbltotalrecord;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtTotalCount;
    }
}