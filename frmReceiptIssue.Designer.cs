namespace SalesPurchase
{
    partial class frmReceiptIssue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceiptIssue));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbCustomerName = new System.Windows.Forms.ComboBox();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.txtRINumber = new System.Windows.Forms.TextBox();
            this.dtpckrTodate = new System.Windows.Forms.DateTimePicker();
            this.dtpckrFromDt = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtsalesman = new System.Windows.Forms.TextBox();
            this.txtremarks = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvwdisplayinvoice = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.grpboxChequeDetails = new System.Windows.Forms.GroupBox();
            this.txtChqAmount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtChequeDt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAcNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbCreditCardType = new System.Windows.Forms.ComboBox();
            this.rbtnCheque = new System.Windows.Forms.RadioButton();
            this.rbtnCreditCard = new System.Windows.Forms.RadioButton();
            this.rbtnCash = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSearchRI = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTotalAMount = new System.Windows.Forms.TextBox();
            this.txtTotalPaidAmt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtTotalBalAmt = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvwdisplayinvoice)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.grpboxChequeDetails.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Receipt Issue for Credit Sales";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cmbCustomerName);
            this.groupBox1.Controls.Add(this.txtInvoiceNo);
            this.groupBox1.Controls.Add(this.txtRINumber);
            this.groupBox1.Controls.Add(this.dtpckrTodate);
            this.groupBox1.Controls.Add(this.dtpckrFromDt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(24, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 99);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Credit Customers";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(375, 66);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 29);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(268, 66);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 29);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbCustomerName
            // 
            this.cmbCustomerName.FormattingEnabled = true;
            this.cmbCustomerName.Location = new System.Drawing.Point(88, 65);
            this.cmbCustomerName.Name = "cmbCustomerName";
            this.cmbCustomerName.Size = new System.Drawing.Size(139, 21);
            this.cmbCustomerName.TabIndex = 9;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Location = new System.Drawing.Point(311, 44);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(139, 20);
            this.txtInvoiceNo.TabIndex = 8;
            // 
            // txtRINumber
            // 
            this.txtRINumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRINumber.Location = new System.Drawing.Point(88, 42);
            this.txtRINumber.Name = "txtRINumber";
            this.txtRINumber.Size = new System.Drawing.Size(139, 20);
            this.txtRINumber.TabIndex = 7;
            // 
            // dtpckrTodate
            // 
            this.dtpckrTodate.Location = new System.Drawing.Point(253, 18);
            this.dtpckrTodate.Name = "dtpckrTodate";
            this.dtpckrTodate.Size = new System.Drawing.Size(86, 20);
            this.dtpckrTodate.TabIndex = 6;
            // 
            // dtpckrFromDt
            // 
            this.dtpckrFromDt.Location = new System.Drawing.Point(88, 18);
            this.dtpckrFromDt.Name = "dtpckrFromDt";
            this.dtpckrFromDt.Size = new System.Drawing.Size(86, 20);
            this.dtpckrFromDt.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Invoice No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Customer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "RI Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "To Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "From Date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtsalesman);
            this.groupBox2.Controls.Add(this.txtremarks);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(24, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(562, 63);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // txtsalesman
            // 
            this.txtsalesman.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsalesman.Location = new System.Drawing.Point(88, 38);
            this.txtsalesman.Name = "txtsalesman";
            this.txtsalesman.Size = new System.Drawing.Size(139, 20);
            this.txtsalesman.TabIndex = 14;
            // 
            // txtremarks
            // 
            this.txtremarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtremarks.Location = new System.Drawing.Point(88, 14);
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(418, 20);
            this.txtremarks.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Sales Man";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Remarks";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvwdisplayinvoice);
            this.groupBox3.Location = new System.Drawing.Point(24, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(562, 232);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Invoice Details";
            // 
            // dgvwdisplayinvoice
            // 
            this.dgvwdisplayinvoice.AllowUserToAddRows = false;
            this.dgvwdisplayinvoice.AllowUserToDeleteRows = false;
            this.dgvwdisplayinvoice.AllowUserToResizeRows = false;
            this.dgvwdisplayinvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvwdisplayinvoice.Location = new System.Drawing.Point(7, 19);
            this.dgvwdisplayinvoice.Name = "dgvwdisplayinvoice";
            this.dgvwdisplayinvoice.Size = new System.Drawing.Size(549, 207);
            this.dgvwdisplayinvoice.TabIndex = 0;
            this.dgvwdisplayinvoice.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvwdisplayinvoice_RowsAdded);
            this.dgvwdisplayinvoice.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvwdisplayinvoice_RowsRemoved);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.grpboxChequeDetails);
            this.groupBox4.Controls.Add(this.cmbCreditCardType);
            this.groupBox4.Controls.Add(this.rbtnCheque);
            this.groupBox4.Controls.Add(this.rbtnCreditCard);
            this.groupBox4.Controls.Add(this.rbtnCash);
            this.groupBox4.Location = new System.Drawing.Point(24, 440);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(562, 104);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Payment Mode";
            // 
            // grpboxChequeDetails
            // 
            this.grpboxChequeDetails.Controls.Add(this.txtChqAmount);
            this.grpboxChequeDetails.Controls.Add(this.label13);
            this.grpboxChequeDetails.Controls.Add(this.txtChequeDt);
            this.grpboxChequeDetails.Controls.Add(this.label12);
            this.grpboxChequeDetails.Controls.Add(this.txtChequeNo);
            this.grpboxChequeDetails.Controls.Add(this.label11);
            this.grpboxChequeDetails.Controls.Add(this.txtAcNo);
            this.grpboxChequeDetails.Controls.Add(this.label10);
            this.grpboxChequeDetails.Controls.Add(this.txtBankName);
            this.grpboxChequeDetails.Controls.Add(this.label9);
            this.grpboxChequeDetails.Enabled = false;
            this.grpboxChequeDetails.Location = new System.Drawing.Point(234, 14);
            this.grpboxChequeDetails.Name = "grpboxChequeDetails";
            this.grpboxChequeDetails.Size = new System.Drawing.Size(315, 84);
            this.grpboxChequeDetails.TabIndex = 13;
            this.grpboxChequeDetails.TabStop = false;
            this.grpboxChequeDetails.Text = "Cheque Details";
            // 
            // txtChqAmount
            // 
            this.txtChqAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChqAmount.Location = new System.Drawing.Point(224, 58);
            this.txtChqAmount.Name = "txtChqAmount";
            this.txtChqAmount.Size = new System.Drawing.Size(85, 20);
            this.txtChqAmount.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(176, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Amount";
            // 
            // txtChequeDt
            // 
            this.txtChequeDt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChequeDt.Location = new System.Drawing.Point(69, 58);
            this.txtChequeDt.Name = "txtChequeDt";
            this.txtChequeDt.Size = new System.Drawing.Size(103, 20);
            this.txtChequeDt.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Cheque Date";
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChequeNo.Location = new System.Drawing.Point(212, 35);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(97, 20);
            this.txtChequeNo.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(154, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Chequeno";
            // 
            // txtAcNo
            // 
            this.txtAcNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcNo.Location = new System.Drawing.Point(45, 35);
            this.txtAcNo.Name = "txtAcNo";
            this.txtAcNo.Size = new System.Drawing.Size(103, 20);
            this.txtAcNo.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "A/c No";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // txtBankName
            // 
            this.txtBankName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBankName.Location = new System.Drawing.Point(45, 13);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(264, 20);
            this.txtBankName.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Bank";
            // 
            // cmbCreditCardType
            // 
            this.cmbCreditCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCreditCardType.FormattingEnabled = true;
            this.cmbCreditCardType.Location = new System.Drawing.Point(90, 41);
            this.cmbCreditCardType.Name = "cmbCreditCardType";
            this.cmbCreditCardType.Size = new System.Drawing.Size(139, 21);
            this.cmbCreditCardType.TabIndex = 12;
            // 
            // rbtnCheque
            // 
            this.rbtnCheque.AutoSize = true;
            this.rbtnCheque.Location = new System.Drawing.Point(90, 18);
            this.rbtnCheque.Name = "rbtnCheque";
            this.rbtnCheque.Size = new System.Drawing.Size(62, 17);
            this.rbtnCheque.TabIndex = 2;
            this.rbtnCheque.TabStop = true;
            this.rbtnCheque.Text = "Cheque";
            this.rbtnCheque.UseVisualStyleBackColor = true;
            this.rbtnCheque.CheckedChanged += new System.EventHandler(this.rbtnCheque_CheckedChanged);
            // 
            // rbtnCreditCard
            // 
            this.rbtnCreditCard.AutoSize = true;
            this.rbtnCreditCard.Location = new System.Drawing.Point(11, 42);
            this.rbtnCreditCard.Name = "rbtnCreditCard";
            this.rbtnCreditCard.Size = new System.Drawing.Size(77, 17);
            this.rbtnCreditCard.TabIndex = 1;
            this.rbtnCreditCard.TabStop = true;
            this.rbtnCreditCard.Text = "Credit Card";
            this.rbtnCreditCard.UseVisualStyleBackColor = true;
            this.rbtnCreditCard.CheckedChanged += new System.EventHandler(this.rbtnCreditCard_CheckedChanged);
            // 
            // rbtnCash
            // 
            this.rbtnCash.AutoSize = true;
            this.rbtnCash.Location = new System.Drawing.Point(11, 19);
            this.rbtnCash.Name = "rbtnCash";
            this.rbtnCash.Size = new System.Drawing.Size(54, 17);
            this.rbtnCash.TabIndex = 0;
            this.rbtnCash.TabStop = true;
            this.rbtnCash.Text = "CASH";
            this.rbtnCash.UseVisualStyleBackColor = true;
            this.rbtnCash.CheckedChanged += new System.EventHandler(this.rbtnCash_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnExit);
            this.groupBox6.Controls.Add(this.btnSearchRI);
            this.groupBox6.Controls.Add(this.btnPrint);
            this.groupBox6.Controls.Add(this.btnDelete);
            this.groupBox6.Controls.Add(this.btnEdit);
            this.groupBox6.Controls.Add(this.btnSave);
            this.groupBox6.Location = new System.Drawing.Point(24, 543);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(562, 51);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(468, 14);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 29);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button8_Click);
            // 
            // btnSearchRI
            // 
            this.btnSearchRI.Location = new System.Drawing.Point(369, 14);
            this.btnSearchRI.Name = "btnSearchRI";
            this.btnSearchRI.Size = new System.Drawing.Size(75, 29);
            this.btnSearchRI.TabIndex = 16;
            this.btnSearchRI.Text = "Search";
            this.btnSearchRI.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(279, 14);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 29);
            this.btnPrint.TabIndex = 15;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(193, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 29);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(99, 14);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 29);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(8, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(136, 422);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Total Amount";
            // 
            // txtTotalAMount
            // 
            this.txtTotalAMount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAMount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAMount.Location = new System.Drawing.Point(212, 419);
            this.txtTotalAMount.Name = "txtTotalAMount";
            this.txtTotalAMount.Size = new System.Drawing.Size(76, 21);
            this.txtTotalAMount.TabIndex = 24;
            // 
            // txtTotalPaidAmt
            // 
            this.txtTotalPaidAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalPaidAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPaidAmt.Location = new System.Drawing.Point(364, 420);
            this.txtTotalPaidAmt.Name = "txtTotalPaidAmt";
            this.txtTotalPaidAmt.Size = new System.Drawing.Size(76, 21);
            this.txtTotalPaidAmt.TabIndex = 25;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(289, 422);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Total Paid Amt";
            // 
            // txtTotalBalAmt
            // 
            this.txtTotalBalAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalBalAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBalAmt.Location = new System.Drawing.Point(510, 419);
            this.txtTotalBalAmt.Name = "txtTotalBalAmt";
            this.txtTotalBalAmt.Size = new System.Drawing.Size(76, 21);
            this.txtTotalBalAmt.TabIndex = 27;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(440, 422);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "Total Bal Amt";
            // 
            // frmReceiptIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 599);
            this.Controls.Add(this.txtTotalBalAmt);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtTotalPaidAmt);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtTotalAMount);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReceiptIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receipt Issue";
            this.Load += new System.EventHandler(this.frmReceiptIssue_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvwdisplayinvoice)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.grpboxChequeDetails.ResumeLayout(false);
            this.grpboxChequeDetails.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbCustomerName;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.TextBox txtRINumber;
        private System.Windows.Forms.DateTimePicker dtpckrTodate;
        private System.Windows.Forms.DateTimePicker dtpckrFromDt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtsalesman;
        private System.Windows.Forms.TextBox txtremarks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvwdisplayinvoice;
        private System.Windows.Forms.ComboBox cmbCreditCardType;
        private System.Windows.Forms.RadioButton rbtnCheque;
        private System.Windows.Forms.RadioButton rbtnCreditCard;
        private System.Windows.Forms.RadioButton rbtnCash;
        private System.Windows.Forms.GroupBox grpboxChequeDetails;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAcNo;
        private System.Windows.Forms.TextBox txtChqAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtChequeDt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSearchRI;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTotalAMount;
        private System.Windows.Forms.TextBox txtTotalPaidAmt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtTotalBalAmt;
        private System.Windows.Forms.Label label16;
    }
}