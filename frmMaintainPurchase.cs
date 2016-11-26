using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SalesPurchase
{
    public partial class frmMaintainPurchase : Form
    {
        private Button btnSearch;
        private Button btnUpdate;
        private Button btnSave;
        private Button btnDelete;
        private Button btnClear;
        private Label label1;
        private GroupBox groupBox1;
        private DataGridView dgPInvoiceDetails;
        private TextBox txtAmount;
        private Label label5;
        private TextBox txtPrice;
        private TextBox txtItemQty;
        private Label label9;
        private Label label8;
        private Label label7;
        private GroupBox groupBox2;
        private RadioButton rbtnCREDIT;
        private RadioButton rbtnCASH;
        private GroupBox groupBox3;
        private Label label11;
        private TextBox txtGRVNO;
        private Label label10;
        private TextBox txtRemarks;
        private Label label16;
        private Label label15;
        private DateTimePicker dtpckrInvoiceDt;
        private Label label14;
        private TextBox txtInvoiceNo;
        private Label label13;
        private Label label12;
        private GroupBox groupBox4;
        private TextBox txtTotalAmoutPayable;
        private Label label21;
        private TextBox txtDiscountAmt;
        private Label label20;
        private TextBox txtDiscountPerc;
        private Label label19;
        private TextBox txtTotalAmount;
        private Label label18;
        private TextBox txtTotalItemCount;
        private Label label17;
        private Timer timer1;
        private IContainer components;
        private ComboBox cmbSupplier;
        private ComboBox cmbPurchaser;
        private ComboBox cmbItemCode;
        private ComboBox cmbItemDescription;
        private Button btnExit;
        private GroupBox groupBox5;
        private DataGridViewTextBoxColumn PItemCode;
        private DataGridViewTextBoxColumn PItemName;
        private DataGridViewTextBoxColumn PItemQty;
        private DataGridViewTextBoxColumn PItemPrice;
        private DataGridViewTextBoxColumn PItemAmount;
        private RadioButton rbtnCashPurchaseReturn;
        private RadioButton rbtnCreditPurchaseReturn;
        private DateTimePicker dtpckrInvRecdt;
    
        public frmMaintainPurchase()
        {
            InitializeComponent();
        }
        string sFlag = "";
        DataSet ds = new DataSet();

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaintainPurchase));
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbItemCode = new System.Windows.Forms.ComboBox();
            this.cmbItemDescription = new System.Windows.Forms.ComboBox();
            this.dgPInvoiceDetails = new System.Windows.Forms.DataGridView();
            this.PItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PItemQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PItemAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtItemQty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnCreditPurchaseReturn = new System.Windows.Forms.RadioButton();
            this.rbtnCashPurchaseReturn = new System.Windows.Forms.RadioButton();
            this.rbtnCREDIT = new System.Windows.Forms.RadioButton();
            this.rbtnCASH = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpckrInvRecdt = new System.Windows.Forms.DateTimePicker();
            this.cmbPurchaser = new System.Windows.Forms.ComboBox();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpckrInvoiceDt = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtGRVNO = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTotalAmoutPayable = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtDiscountAmt = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDiscountPerc = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTotalItemCount = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPInvoiceDetails)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(283, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 30);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(99, 15);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 30);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Modify";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(8, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(190, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(378, 15);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Item Description";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbItemCode);
            this.groupBox1.Controls.Add(this.cmbItemDescription);
            this.groupBox1.Controls.Add(this.dgPInvoiceDetails);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtItemQty);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(26, 188);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 236);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Details";
            // 
            // cmbItemCode
            // 
            this.cmbItemCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItemCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemCode.FormattingEnabled = true;
            this.cmbItemCode.Location = new System.Drawing.Point(9, 33);
            this.cmbItemCode.Name = "cmbItemCode";
            this.cmbItemCode.Size = new System.Drawing.Size(70, 21);
            this.cmbItemCode.TabIndex = 29;
            this.cmbItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemCode_KeyDown);
            this.cmbItemCode.Leave += new System.EventHandler(this.cmbItemCode_Leave);
            // 
            // cmbItemDescription
            // 
            this.cmbItemDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbItemDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbItemDescription.FormattingEnabled = true;
            this.cmbItemDescription.Location = new System.Drawing.Point(86, 33);
            this.cmbItemDescription.Name = "cmbItemDescription";
            this.cmbItemDescription.Size = new System.Drawing.Size(238, 21);
            this.cmbItemDescription.TabIndex = 28;
            this.cmbItemDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbItemDescription_KeyDown);
            this.cmbItemDescription.Leave += new System.EventHandler(this.cmbItemDescription_Leave);
            // 
            // dgPInvoiceDetails
            // 
            this.dgPInvoiceDetails.AllowUserToAddRows = false;
            this.dgPInvoiceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPInvoiceDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PItemCode,
            this.PItemName,
            this.PItemQty,
            this.PItemPrice,
            this.PItemAmount});
            this.dgPInvoiceDetails.Location = new System.Drawing.Point(6, 60);
            this.dgPInvoiceDetails.Name = "dgPInvoiceDetails";
            this.dgPInvoiceDetails.Size = new System.Drawing.Size(527, 170);
            this.dgPInvoiceDetails.TabIndex = 27;
            this.dgPInvoiceDetails.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgPInvoiceDetails_RowsAdded);
            this.dgPInvoiceDetails.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgPInvoiceDetails_RowsRemoved);
            // 
            // PItemCode
            // 
            this.PItemCode.HeaderText = "Item Code";
            this.PItemCode.Name = "PItemCode";
            this.PItemCode.Width = 80;
            // 
            // PItemName
            // 
            this.PItemName.HeaderText = "Item Name";
            this.PItemName.Name = "PItemName";
            // 
            // PItemQty
            // 
            this.PItemQty.HeaderText = "Item Quantity";
            this.PItemQty.Name = "PItemQty";
            // 
            // PItemPrice
            // 
            this.PItemPrice.HeaderText = "Item Unit Price";
            this.PItemPrice.Name = "PItemPrice";
            // 
            // PItemAmount
            // 
            this.PItemAmount.HeaderText = "Item Amount";
            this.PItemAmount.Name = "PItemAmount";
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Location = new System.Drawing.Point(456, 34);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(55, 20);
            this.txtAmount.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Item Code";
            // 
            // txtPrice
            // 
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Location = new System.Drawing.Point(402, 34);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(44, 20);
            this.txtPrice.TabIndex = 25;
            this.txtPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrice_KeyDown);
            // 
            // txtItemQty
            // 
            this.txtItemQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemQty.Location = new System.Drawing.Point(332, 34);
            this.txtItemQty.Name = "txtItemQty";
            this.txtItemQty.Size = new System.Drawing.Size(64, 20);
            this.txtItemQty.TabIndex = 24;
            this.txtItemQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemQty_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(453, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Amount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(402, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Price";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(332, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Item Quantity";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnCreditPurchaseReturn);
            this.groupBox2.Controls.Add(this.rbtnCashPurchaseReturn);
            this.groupBox2.Controls.Add(this.rbtnCREDIT);
            this.groupBox2.Controls.Add(this.rbtnCASH);
            this.groupBox2.Location = new System.Drawing.Point(26, -1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(561, 41);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // rbtnCreditPurchaseReturn
            // 
            this.rbtnCreditPurchaseReturn.AutoSize = true;
            this.rbtnCreditPurchaseReturn.Location = new System.Drawing.Point(335, 15);
            this.rbtnCreditPurchaseReturn.Name = "rbtnCreditPurchaseReturn";
            this.rbtnCreditPurchaseReturn.Size = new System.Drawing.Size(176, 17);
            this.rbtnCreditPurchaseReturn.TabIndex = 3;
            this.rbtnCreditPurchaseReturn.TabStop = true;
            this.rbtnCreditPurchaseReturn.Text = "CREDIT PURCHASE RETURN";
            this.rbtnCreditPurchaseReturn.UseVisualStyleBackColor = true;
            this.rbtnCreditPurchaseReturn.CheckedChanged += new System.EventHandler(this.rbtnCreditPurchaseReturn_CheckedChanged);
            // 
            // rbtnCashPurchaseReturn
            // 
            this.rbtnCashPurchaseReturn.AutoSize = true;
            this.rbtnCashPurchaseReturn.Location = new System.Drawing.Point(157, 16);
            this.rbtnCashPurchaseReturn.Name = "rbtnCashPurchaseReturn";
            this.rbtnCashPurchaseReturn.Size = new System.Drawing.Size(165, 17);
            this.rbtnCashPurchaseReturn.TabIndex = 2;
            this.rbtnCashPurchaseReturn.TabStop = true;
            this.rbtnCashPurchaseReturn.Text = "CASH PURCHASE RETURN";
            this.rbtnCashPurchaseReturn.UseVisualStyleBackColor = true;
            this.rbtnCashPurchaseReturn.CheckedChanged += new System.EventHandler(this.rbtnCashPurchaseReturn_CheckedChanged);
            // 
            // rbtnCREDIT
            // 
            this.rbtnCREDIT.AutoSize = true;
            this.rbtnCREDIT.Location = new System.Drawing.Point(86, 16);
            this.rbtnCREDIT.Name = "rbtnCREDIT";
            this.rbtnCREDIT.Size = new System.Drawing.Size(65, 17);
            this.rbtnCREDIT.TabIndex = 1;
            this.rbtnCREDIT.TabStop = true;
            this.rbtnCREDIT.Text = "CREDIT";
            this.rbtnCREDIT.UseVisualStyleBackColor = true;
            this.rbtnCREDIT.CheckedChanged += new System.EventHandler(this.rbtnCREDIT_CheckedChanged);
            // 
            // rbtnCASH
            // 
            this.rbtnCASH.AutoSize = true;
            this.rbtnCASH.Location = new System.Drawing.Point(11, 15);
            this.rbtnCASH.Name = "rbtnCASH";
            this.rbtnCASH.Size = new System.Drawing.Size(54, 17);
            this.rbtnCASH.TabIndex = 0;
            this.rbtnCASH.TabStop = true;
            this.rbtnCASH.Text = "CASH";
            this.rbtnCASH.UseVisualStyleBackColor = true;
            this.rbtnCASH.CheckedChanged += new System.EventHandler(this.rbtnCASH_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpckrInvRecdt);
            this.groupBox3.Controls.Add(this.cmbPurchaser);
            this.groupBox3.Controls.Add(this.cmbSupplier);
            this.groupBox3.Controls.Add(this.txtRemarks);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.dtpckrInvoiceDt);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtInvoiceNo);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtGRVNO);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(26, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(561, 139);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Purchase Invoice Header";
            // 
            // dtpckrInvRecdt
            // 
            this.dtpckrInvRecdt.Location = new System.Drawing.Point(321, 13);
            this.dtpckrInvRecdt.Name = "dtpckrInvRecdt";
            this.dtpckrInvRecdt.Size = new System.Drawing.Size(146, 20);
            this.dtpckrInvRecdt.TabIndex = 32;
            // 
            // cmbPurchaser
            // 
            this.cmbPurchaser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPurchaser.FormattingEnabled = true;
            this.cmbPurchaser.Location = new System.Drawing.Point(85, 90);
            this.cmbPurchaser.Name = "cmbPurchaser";
            this.cmbPurchaser.Size = new System.Drawing.Size(382, 21);
            this.cmbPurchaser.TabIndex = 31;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(85, 39);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(382, 21);
            this.cmbSupplier.TabIndex = 30;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(85, 116);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(381, 20);
            this.txtRemarks.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 119);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "Remarks";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Purchaser";
            // 
            // dtpckrInvoiceDt
            // 
            this.dtpckrInvoiceDt.Location = new System.Drawing.Point(311, 64);
            this.dtpckrInvoiceDt.Name = "dtpckrInvoiceDt";
            this.dtpckrInvoiceDt.Size = new System.Drawing.Size(156, 20);
            this.dtpckrInvoiceDt.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(227, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "Invoice Date";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Location = new System.Drawing.Point(85, 64);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(127, 20);
            this.txtInvoiceNo.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Invoice No";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Supplier";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(207, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Invoice Received Date";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txtGRVNO
            // 
            this.txtGRVNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGRVNO.Location = new System.Drawing.Point(85, 13);
            this.txtGRVNO.Name = "txtGRVNO";
            this.txtGRVNO.ReadOnly = true;
            this.txtGRVNO.Size = new System.Drawing.Size(116, 20);
            this.txtGRVNO.TabIndex = 20;
            this.txtGRVNO.TextChanged += new System.EventHandler(this.txtGRVNO_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "GRV No";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtTotalAmoutPayable);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.txtDiscountAmt);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.txtDiscountPerc);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.txtTotalAmount);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.txtTotalItemCount);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Location = new System.Drawing.Point(26, 425);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(561, 61);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            // 
            // txtTotalAmoutPayable
            // 
            this.txtTotalAmoutPayable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAmoutPayable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmoutPayable.Location = new System.Drawing.Point(460, 13);
            this.txtTotalAmoutPayable.Name = "txtTotalAmoutPayable";
            this.txtTotalAmoutPayable.Size = new System.Drawing.Size(55, 20);
            this.txtTotalAmoutPayable.TabIndex = 36;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(348, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(111, 13);
            this.label21.TabIndex = 35;
            this.label21.Text = "Total Amount Payable";
            // 
            // txtDiscountAmt
            // 
            this.txtDiscountAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscountAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountAmt.Location = new System.Drawing.Point(271, 36);
            this.txtDiscountAmt.Name = "txtDiscountAmt";
            this.txtDiscountAmt.Size = new System.Drawing.Size(68, 20);
            this.txtDiscountAmt.TabIndex = 34;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(179, 39);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 13);
            this.label20.TabIndex = 33;
            this.label20.Text = "Discount Amount";
            // 
            // txtDiscountPerc
            // 
            this.txtDiscountPerc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscountPerc.Location = new System.Drawing.Point(97, 36);
            this.txtDiscountPerc.Name = "txtDiscountPerc";
            this.txtDiscountPerc.Size = new System.Drawing.Size(66, 20);
            this.txtDiscountPerc.TabIndex = 32;
            this.txtDiscountPerc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscountPerc_KeyPress);
            this.txtDiscountPerc.Leave += new System.EventHandler(this.txtDiscountPerc_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 36);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 13);
            this.label19.TabIndex = 31;
            this.label19.Text = "Discount %";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(271, 13);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(68, 20);
            this.txtTotalAmount.TabIndex = 30;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(179, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 13);
            this.label18.TabIndex = 29;
            this.label18.Text = "Total Amount";
            // 
            // txtTotalItemCount
            // 
            this.txtTotalItemCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalItemCount.Location = new System.Drawing.Point(97, 13);
            this.txtTotalItemCount.Name = "txtTotalItemCount";
            this.txtTotalItemCount.Size = new System.Drawing.Size(66, 20);
            this.txtTotalItemCount.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 13);
            this.label17.TabIndex = 28;
            this.label17.Text = "Total Item Count";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(467, 15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 21;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSave);
            this.groupBox5.Controls.Add(this.btnExit);
            this.groupBox5.Controls.Add(this.btnUpdate);
            this.groupBox5.Controls.Add(this.btnDelete);
            this.groupBox5.Controls.Add(this.btnSearch);
            this.groupBox5.Controls.Add(this.btnClear);
            this.groupBox5.Location = new System.Drawing.Point(26, 487);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(561, 51);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            // 
            // frmMaintainPurchase
            // 
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(599, 540);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMaintainPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase";
            this.Load += new System.EventHandler(this.frmMaintainPurchase_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPInvoiceDetails)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void frmMaintainPurchase_Load(object sender, EventArgs e)
        {
            try
            {                
                //sFlag = "FETCH";
                //GlobalClass.cmd = new SqlCommand();
                //GlobalClass.cmd.Connection = GlobalClass.gCon;
                //GlobalClass.cmd.CommandText = "SP_GRVNoGenerator";
                //GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                //GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                //txtGRVNO.Text ="G"+ GlobalClass.cmd.ExecuteScalar().ToString().PadLeft(7, '0');
                GRVNoGenerator();

                sFlag = "FETCHEMPNAME";
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_FetchMenuDetails";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                ds = new DataSet();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                for (int i = 0; i < ds.Tables["Result"].Rows.Count; i++)
                    cmbPurchaser.Items.Add(ds.Tables["Result"].Rows[i]["Employeename"].ToString().Trim());

                sFlag = "LOAD";
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_FetchPurchaseItems";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                ds = new DataSet();
                ds.Load(GlobalClass.cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                for (int i = 0; i < ds.Tables["Result"].Rows.Count; i++)
                {
                    cmbItemCode.Items.Add(ds.Tables["Result"].Rows[i]["PItemcode"].ToString().Trim());
                    cmbItemDescription.Items.Add(ds.Tables["Result"].Rows[i]["PItemname"].ToString().Trim());
                }

                cmbPurchaser.SelectedIndex = -1;
                rbtnCASH.Checked = true;
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in frmMaintainPurchase_Load:"+ex.Message.ToString());
            }
        }
        public void PurchaseReturnGRVNoGenerator()
        {
            try
            {
                sFlag = "PURCHASERETURN";
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_GetInvoiceCounter";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                txtGRVNO.Text ="GR"+ GlobalClass.cmd.ExecuteScalar().ToString().PadLeft(7, '0');
               }
            catch(Exception ex)
            {
                GlobalClass.WriteLog("Error in PurchaseReturnGRVNoGenerator:" + ex.Message.ToString());
            }
        }
        public void GRVNoGenerator()
        {
            try
            {
                sFlag = "FETCH";
                GlobalClass.cmd = new SqlCommand();
                GlobalClass.cmd.Connection = GlobalClass.gCon;
                GlobalClass.cmd.CommandText = "SP_GRVNoGenerator";
                GlobalClass.cmd.CommandType = CommandType.StoredProcedure;
                GlobalClass.cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag.Trim();
                txtGRVNO.Text = "G" + GlobalClass.cmd.ExecuteScalar().ToString().PadLeft(7, '0');
            }
            catch (Exception ex)
            {
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                int iResult;
                i = dgPInvoiceDetails.Rows.Count;

                //i = dgview.Rows.Count;
                if (i == 0)
                {
                    MessageBox.Show("No Items for Purchase", "Purchase", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                string sFlag = "SAVE", sRetval ;
                sRetval= MaintainPurchaseInvoice(sFlag);
            }
            catch (Exception ex)
            {
            }
        }
        public string MaintainPurchaseInvoice(string sFlag)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                int count;
                decimal dcTotalInvAmt;
                dcTotalInvAmt = 0;
                string sRetval;
                count=dgPInvoiceDetails.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    cmd=new SqlCommand();
                    cmd.Connection = GlobalClass.gCon;
                    cmd.CommandText = "SP_MaintainPurchaseInvoice";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag;
                    cmd.Parameters.Add("@GRVNo", SqlDbType.VarChar, txtGRVNO.Text.Length).Value = txtGRVNO.Text.Trim();
                    cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar, txtInvoiceNo.Text.Length).Value = txtInvoiceNo.Text.Trim();
                    cmd.Parameters.Add("@PItemCode", SqlDbType.VarChar, dgPInvoiceDetails.Rows[i].Cells["PItemCode"].Value.ToString().Length).Value = dgPInvoiceDetails.Rows[i].Cells["PItemcode"].Value.ToString().Trim();
                    cmd.Parameters.Add("@PItemName", SqlDbType.VarChar, dgPInvoiceDetails.Rows[i].Cells["PItemName"].Value.ToString().Length).Value = dgPInvoiceDetails.Rows[i].Cells["PItemName"].Value.ToString().Trim();
                    cmd.Parameters.Add("@PItemUnitPrice", SqlDbType.VarChar, dgPInvoiceDetails.Rows[i].Cells["PItemPrice"].Value.ToString().Length).Value = dgPInvoiceDetails.Rows[i].Cells["PItemPrice"].Value.ToString().Trim();
                    cmd.Parameters.Add("@PItemQty", SqlDbType.VarChar, dgPInvoiceDetails.Rows[i].Cells["PItemQty"].Value.ToString().Length).Value = dgPInvoiceDetails.Rows[i].Cells["PItemQty"].Value.ToString().Trim();
                    cmd.Parameters.Add("@PItemAmount", SqlDbType.VarChar, dgPInvoiceDetails.Rows[i].Cells["PItemAmount"].Value.ToString().Length).Value = dgPInvoiceDetails.Rows[i].Cells["PItemAmount"].Value.ToString().Trim();
                    sRetval= cmd.ExecuteScalar().ToString();
                    dcTotalInvAmt = dcTotalInvAmt + Convert.ToDecimal(dgPInvoiceDetails.Rows[i].Cells["PItemAmount"].Value);

                }
                cmd = new SqlCommand();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_MaintainPurchaseInvoiceMaster";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, 10).Value = "SAVE";
                cmd.Parameters.Add("@GRVNo", SqlDbType.VarChar,txtGRVNO.Text.Length).Value = txtGRVNO.Text.Trim();
                cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar,txtInvoiceNo.Text.Length).Value = txtInvoiceNo.Text.Trim();
                cmd.Parameters.Add("@InvoiceHonouredType", SqlDbType.VarChar,GlobalClass.gsPurchaseInvType.Length).Value = GlobalClass.gsPurchaseInvType;
                cmd.Parameters.Add("@InvoiceRecdDate", SqlDbType.VarChar,dtpckrInvRecdt.Value.ToString("yyyy-MM-dd").Length).Value = dtpckrInvRecdt.Value.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@SupplierDetails", SqlDbType.VarChar,cmbSupplier.Text.Length).Value =cmbSupplier.Text;
                cmd.Parameters.Add("@Invoicedate", SqlDbType.VarChar,dtpckrInvoiceDt.Value.ToString("yyyy-MM-dd").Length).Value =dtpckrInvoiceDt.Value.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@Purchaser", SqlDbType.VarChar,cmbPurchaser.Text.Length).Value =cmbPurchaser.Text;
                cmd.Parameters.Add("@Remarks", SqlDbType.VarChar,txtRemarks.Text.Length).Value =txtRemarks.Text;
                cmd.Parameters.Add("@TotalItemCount", SqlDbType.VarChar,10).Value =count.ToString();
                cmd.Parameters.Add("@DiscPerc", SqlDbType.VarChar,txtDiscountPerc.Text.Length).Value =txtDiscountPerc.Text;
                cmd.Parameters.Add("@InvoiceTotAmt", SqlDbType.VarChar,10).Value =dcTotalInvAmt.ToString();
                if (txtDiscountAmt.Text == "")
                {
                    txtDiscountAmt.Text = "0.00";
                }
                cmd.Parameters.Add("@DiscountAmt", SqlDbType.VarChar,txtDiscountAmt.Text.Length).Value =txtDiscountAmt.Text.Trim();
                cmd.Parameters.Add("@TotalamountPayable", SqlDbType.VarChar,txtTotalAmoutPayable.Text.Length).Value =txtTotalAmoutPayable.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Purchased Invoice Details Saved Successfully", "Purchase Master", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                ClearForm();
                //GRVNoGenerator();
                return GlobalClass.SUCCESS;

            }
            catch (Exception ex)
            {
                return GlobalClass.FAIL;
            }

        }

        private void cmbItemCode_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                string sItemCode, flag;
                ds = new DataSet();
                flag = "TYPEMENU";
                sItemCode = cmbItemCode.Text.Trim();
                if (sItemCode != "")
                {
                    cmd = new SqlCommand();
                    cmd.Connection = GlobalClass.gCon;
                    cmd.CommandText = "SP_FetchPurchaseItems";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, flag.Length).Value = flag;
                    cmd.Parameters.Add("@PItemcode", SqlDbType.VarChar, sItemCode.Length).Value = sItemCode;
                    ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                    if (ds.Tables["Result"].Rows.Count == 0)
                    {
                        MessageBox.Show("No Items found for the code", "Purchase Items", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    cmbItemDescription.Text = ds.Tables["Result"].Rows[0]["PItemName"].ToString();
                    txtPrice.Text = ds.Tables["Result"].Rows[0]["PItemUnitPrice"].ToString();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in cmbItemCode_Leave:"+ex.Message.ToString());
                MessageBox.Show("Error in cmbItemCode_Leave:"+ex.Message.ToString(), "Error in MainTain Purchase", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cmbItemDescription_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                string sItemCode, flag;
                ds = new DataSet();
                flag = "TYPEMENUITEMS";
                sItemCode = cmbItemDescription.Text.Trim();
                if (sItemCode != "")
                {
                    cmd = new SqlCommand();
                    cmd.Connection = GlobalClass.gCon;
                    cmd.CommandText = "SP_FetchPurchaseItems";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Flag", SqlDbType.VarChar, flag.Length).Value = flag;
                    cmd.Parameters.Add("@PItemcode", SqlDbType.VarChar, sItemCode.Length).Value = sItemCode;
                    ds.Load(cmd.ExecuteReader(), LoadOption.OverwriteChanges, "Result");
                    if (ds.Tables["Result"].Rows.Count == 0)
                    {
                        MessageBox.Show("No Items found for the code", "Purchase Items", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    cmbItemCode.Text = ds.Tables["Result"].Rows[0]["PItemCode"].ToString();
                    txtPrice.Text = ds.Tables["Result"].Rows[0]["PItemUnitPrice"].ToString();
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in cmbItemCode_Leave:" + ex.Message.ToString());
                MessageBox.Show("Error in cmbItemCode_Leave:" + ex.Message.ToString(), "Error in MainTain Purchase", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtItemQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPrice.Focus();
                }
                    //Decimal dc;
                    //dc = Convert.ToDecimal(txtPrice.Text) * Convert.ToDecimal(txtItemQty.Text);
                    //txtAmount.Text = dc.ToString();

                    //DataGridViewRow row = new DataGridViewRow();
                    //row.CreateCells(dgPInvoiceDetails, cmbItemCode.Text, cmbItemDescription.Text, txtItemQty.Text, txtPrice.Text, txtAmount.Text);
                    //dgPInvoiceDetails.Rows.Add(row);
                    //cmbItemCode.Focus();
                    //cmbItemCode.SelectedIndex = -1;
                    //cmbItemDescription.SelectedIndex = -1;
                    //txtItemQty.Text = "";
                    //txtAmount.Text = "";
                    //txtPrice.Text = "";

                //}
            }
            catch (Exception ex)
            {
            }
        }

        private void txtGRVNO_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbtnCREDIT_CheckedChanged(object sender, EventArgs e)
        {
            GlobalClass.gsPurchaseInvType = "CREDIT";
            GRVNoGenerator();
        }

        private void rbtnCASH_CheckedChanged(object sender, EventArgs e)
        {
            GlobalClass.gsPurchaseInvType = "CASH";
            GRVNoGenerator();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        public void ClearForm()
        {
            try
            {
                rbtnCASH.Checked = true;
                txtGRVNO.Text = "";
                txtInvoiceNo.Text = "";
                dtpckrInvRecdt.Value = DateTime.Now;
                dtpckrInvoiceDt.Value = DateTime.Now;
                txtRemarks.Text = "";
                dgPInvoiceDetails.Rows.Clear();
                cmbSupplier.Text = "";
                cmbPurchaser.Text = "";
                cmbItemCode.Text = "";
                cmbItemDescription.Text = "";
                txtItemQty.Text = "";
                txtPrice.Text = "";
                txtTotalAmount.Text = "";
                txtTotalAmoutPayable.Text = "";
                txtTotalItemCount.Text = "";
                txtDiscountAmt.Text = "";
                txtDiscountPerc.Text = "";
                txtAmount.Text = "";
                GRVNoGenerator();
            }

            catch (Exception ex)
            {
            }
        }

        private void dgPInvoiceDetails_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                //int iSum,iAmount;
                Decimal dAmount, iSum;
                // string sAmt;
                iSum = 0;

                for (int j = 0; j < dgPInvoiceDetails.Rows.Count; j++)
                {
                    //iSum = iSum + Convert.ToInt16(ds.Tables["Result"].Rows[j]["Amount"]);
                    //sAmt =dgDisplayKOTDetails.Rows[j].Cells["Amount"].Value.ToString();
                    //iAmount = Convert.ToDecimal(sAmt);
                    iSum = iSum + Convert.ToDecimal(dgPInvoiceDetails.Rows[j].Cells["PItemAmount"].Value);
                    //GlobalClass.gbOrderChanged = true;
                    //MessageBox.Show(ds.Tables["Result"].Rows[i]["Amount"].ToString(),"Saels",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                }
                txtTotalAmount.Text = iSum.ToString("0,0.00");
                txtTotalAmoutPayable.Text = iSum.ToString("0,0.00");
                txtTotalItemCount.Text = dgPInvoiceDetails.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in dgPInvoiceDetails_RowsAdded:"+ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Error in Purchase", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgPInvoiceDetails_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                //int iSum,iAmount;
                Decimal dAmount, iSum;
                // string sAmt;
                iSum = 0;

                for (int j = 0; j < dgPInvoiceDetails.Rows.Count; j++)
                {
                    //iSum = iSum + Convert.ToInt16(ds.Tables["Result"].Rows[j]["Amount"]);
                    //sAmt =dgDisplayKOTDetails.Rows[j].Cells["Amount"].Value.ToString();
                    //iAmount = Convert.ToDecimal(sAmt);
                    iSum = iSum + Convert.ToDecimal(dgPInvoiceDetails.Rows[j].Cells["PItemAmount"].Value);
                    //GlobalClass.gbOrderChanged = true;
                    //MessageBox.Show(ds.Tables["Result"].Rows[i]["Amount"].ToString(),"Saels",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                }
                txtTotalAmount.Text = iSum.ToString("0,0.00");
                txtTotalAmoutPayable.Text = iSum.ToString("0,0.00");
                txtTotalItemCount.Text = dgPInvoiceDetails.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in dgPInvoiceDetails_RowsRemoved:" + ex.Message.ToString());
                MessageBox.Show(ex.Message.ToString(), "Error in Purchase", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtDiscountPerc_Leave(object sender, EventArgs e)
        {

        }

        private void txtDiscountPerc_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int iDiscountPerc;
                Double itotalAmount;
                Double dDiscountAmt;
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    iDiscountPerc = Convert.ToInt16(txtDiscountPerc.Text);
                    itotalAmount = Convert.ToDouble(txtTotalAmount.Text);
                    dDiscountAmt = (iDiscountPerc * itotalAmount) / 100;
                    dDiscountAmt = Math.Floor(dDiscountAmt);
                    txtDiscountAmt.Text = dDiscountAmt.ToString();

                    itotalAmount = itotalAmount - Convert.ToInt16(dDiscountAmt);
                    txtTotalAmoutPayable.Text = itotalAmount.ToString();
                    //txtDiscAmount.Text = Convert.ToString(Convert.ToInt16(txtDiscountPer.Text) * Convert.ToInt16(txtNetAmount.Text)) / 100;
                    //txtPaidAmount.Text = Convert.ToString(Convert.ToInt16(txtNetAmount.Text) - Convert.ToInt16(txtDiscAmount.Text));
                }
            }
            catch (Exception ex)
            {
                GlobalClass.WriteLog("Error in txtDiscountPerc_KeyPress:"+ex.Message.ToString());
            }
        }

        private void rbtnCreditPurchaseReturn_CheckedChanged(object sender, EventArgs e)
        {
            GlobalClass.gsPurchaseInvType = "CRPURCHASERET";
            PurchaseReturnGRVNoGenerator();
        }

        private void rbtnCashPurchaseReturn_CheckedChanged(object sender, EventArgs e)
        {
            GlobalClass.gsPurchaseInvType = "CASHPURCHASERET";
            PurchaseReturnGRVNoGenerator();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                SqlCommand cmd = new SqlCommand();
                string sRetval;
                i = dgPInvoiceDetails.Rows.Count;

                //i = dgview.Rows.Count;
                if (i == 0)
                {
                    MessageBox.Show("No Items to Delete", "Purchase", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (MessageBox.Show("Are you sure to delete", "Purchase", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)==DialogResult.Cancel)
                {
                    //MessageBox.Show("No Items to Delete", "Purchase", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                string sFlag = "DELETE";
                cmd = new SqlCommand();
                cmd.Connection = GlobalClass.gCon;
                cmd.CommandText = "SP_MaintainPurchaseInvoiceMaster";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Flag", SqlDbType.VarChar, sFlag.Length).Value = sFlag;
                cmd.Parameters.Add("@GRVNo", SqlDbType.VarChar, txtGRVNO.Text.Length).Value = txtGRVNO.Text.Trim();
                sRetval=cmd.ExecuteScalar().ToString();
                //sRetval = MaintainPurchaseInvoice(sFlag);
            }
            catch (Exception ex)
            {
            }
        }

        private void cmbItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    cmbItemCode_Leave(sender, e);

                txtItemQty.Focus();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Decimal dc;
                    dc = Convert.ToDecimal(txtPrice.Text) * Convert.ToDecimal(txtItemQty.Text);
                    txtAmount.Text = dc.ToString();

                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgPInvoiceDetails, cmbItemCode.Text, cmbItemDescription.Text, txtItemQty.Text, txtPrice.Text, txtAmount.Text);
                    dgPInvoiceDetails.Rows.Add(row);
                    cmbItemCode.Focus();
                    cmbItemCode.SelectedIndex = -1;
                    cmbItemDescription.SelectedIndex = -1;
                    txtItemQty.Text = "";
                    txtAmount.Text = "";
                    txtPrice.Text = "";
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void cmbItemDescription_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                cmbItemDescription_Leave(sender, e);
            }
            catch ( Exception ex)
            {
            }
    
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
