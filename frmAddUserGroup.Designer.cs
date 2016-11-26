namespace SalesPurchase
{
    partial class frmAddUserGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUserGroup));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtSecurityAns = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSecurityQuestion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgManageUser = new System.Windows.Forms.DataGridView();
            this.btnClearUser = new System.Windows.Forms.Button();
            this.btnExitAddUser = new System.Windows.Forms.Button();
            this.btnSearchUser = new System.Windows.Forms.Button();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.txtAddConfirmPass = new System.Windows.Forms.TextBox();
            this.txtaddPassword = new System.Windows.Forms.TextBox();
            this.txtAddUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtnListGroups = new System.Windows.Forms.RadioButton();
            this.rbtnListUsers = new System.Windows.Forms.RadioButton();
            this.btnDone = new System.Windows.Forms.Button();
            this.lstDisplayUser = new System.Windows.Forms.ListBox();
            this.lstDisplayAddGroups = new System.Windows.Forms.ListBox();
            this.btnremovegroupfromuser = new System.Windows.Forms.Button();
            this.btnaddgrouptouser = new System.Windows.Forms.Button();
            this.lstDisplayGroup = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaveGroup = new System.Windows.Forms.Button();
            this.btnSearchGroup = new System.Windows.Forms.Button();
            this.btnUpdateGroup = new System.Windows.Forms.Button();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.btnClearGroup = new System.Windows.Forms.Button();
            this.btnExitGroup = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDoneGrpQueue = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lstSelectedQueues = new System.Windows.Forms.ListBox();
            this.rbtnQueuedet = new System.Windows.Forms.RadioButton();
            this.rbtnGrp = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstQueueDetails = new System.Windows.Forms.ListBox();
            this.lstGrpDisplay = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgManageUser)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(788, 518);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.txtSecurityAns);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.cmbSecurityQuestion);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.dgManageUser);
            this.tabPage1.Controls.Add(this.btnClearUser);
            this.tabPage1.Controls.Add(this.btnExitAddUser);
            this.tabPage1.Controls.Add(this.btnSearchUser);
            this.tabPage1.Controls.Add(this.btnUpdateUser);
            this.tabPage1.Controls.Add(this.btnDeleteUser);
            this.tabPage1.Controls.Add(this.btnAddUser);
            this.tabPage1.Controls.Add(this.txtAddConfirmPass);
            this.tabPage1.Controls.Add(this.txtaddPassword);
            this.tabPage1.Controls.Add(this.txtAddUsername);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(706, 492);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Manage User";
            // 
            // txtSecurityAns
            // 
            this.txtSecurityAns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecurityAns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecurityAns.Location = new System.Drawing.Point(141, 157);
            this.txtSecurityAns.Name = "txtSecurityAns";
            this.txtSecurityAns.Size = new System.Drawing.Size(211, 21);
            this.txtSecurityAns.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Your Answer";
            // 
            // cmbSecurityQuestion
            // 
            this.cmbSecurityQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSecurityQuestion.FormattingEnabled = true;
            this.cmbSecurityQuestion.Location = new System.Drawing.Point(238, 129);
            this.cmbSecurityQuestion.Name = "cmbSecurityQuestion";
            this.cmbSecurityQuestion.Size = new System.Drawing.Size(419, 21);
            this.cmbSecurityQuestion.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(204, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Please select your Security Question";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // dgManageUser
            // 
            this.dgManageUser.AllowUserToAddRows = false;
            this.dgManageUser.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgManageUser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgManageUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgManageUser.Location = new System.Drawing.Point(34, 184);
            this.dgManageUser.Name = "dgManageUser";
            this.dgManageUser.ReadOnly = true;
            this.dgManageUser.Size = new System.Drawing.Size(605, 161);
            this.dgManageUser.TabIndex = 3;
            this.dgManageUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgManageUser_CellContentClick);
            // 
            // btnClearUser
            // 
            this.btnClearUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearUser.Location = new System.Drawing.Point(463, 364);
            this.btnClearUser.Name = "btnClearUser";
            this.btnClearUser.Size = new System.Drawing.Size(80, 30);
            this.btnClearUser.TabIndex = 8;
            this.btnClearUser.Text = "Clear";
            this.btnClearUser.UseVisualStyleBackColor = true;
            this.btnClearUser.Click += new System.EventHandler(this.btnClearUser_Click);
            // 
            // btnExitAddUser
            // 
            this.btnExitAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExitAddUser.Location = new System.Drawing.Point(564, 364);
            this.btnExitAddUser.Name = "btnExitAddUser";
            this.btnExitAddUser.Size = new System.Drawing.Size(80, 30);
            this.btnExitAddUser.TabIndex = 9;
            this.btnExitAddUser.Text = "Exit";
            this.btnExitAddUser.UseVisualStyleBackColor = true;
            this.btnExitAddUser.Click += new System.EventHandler(this.btnExitAddUser_Click);
            // 
            // btnSearchUser
            // 
            this.btnSearchUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchUser.Location = new System.Drawing.Point(357, 364);
            this.btnSearchUser.Name = "btnSearchUser";
            this.btnSearchUser.Size = new System.Drawing.Size(80, 30);
            this.btnSearchUser.TabIndex = 7;
            this.btnSearchUser.Text = "Search";
            this.btnSearchUser.UseVisualStyleBackColor = true;
            this.btnSearchUser.Click += new System.EventHandler(this.btnSearchUser_Click);
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateUser.Location = new System.Drawing.Point(256, 364);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(80, 30);
            this.btnUpdateUser.TabIndex = 6;
            this.btnUpdateUser.Text = "Modify";
            this.btnUpdateUser.UseVisualStyleBackColor = true;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUser.Location = new System.Drawing.Point(153, 364);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(80, 30);
            this.btnDeleteUser.TabIndex = 5;
            this.btnDeleteUser.Text = "Delete";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.Location = new System.Drawing.Point(50, 364);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(80, 30);
            this.btnAddUser.TabIndex = 4;
            this.btnAddUser.Text = "Save";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAddConfirmPass
            // 
            this.txtAddConfirmPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddConfirmPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddConfirmPass.Location = new System.Drawing.Point(143, 98);
            this.txtAddConfirmPass.Name = "txtAddConfirmPass";
            this.txtAddConfirmPass.PasswordChar = '*';
            this.txtAddConfirmPass.Size = new System.Drawing.Size(123, 21);
            this.txtAddConfirmPass.TabIndex = 2;
            this.txtAddConfirmPass.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.txtAddConfirmPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddConfirmPass_KeyPress);
            // 
            // txtaddPassword
            // 
            this.txtaddPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtaddPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaddPassword.Location = new System.Drawing.Point(144, 66);
            this.txtaddPassword.Name = "txtaddPassword";
            this.txtaddPassword.PasswordChar = '*';
            this.txtaddPassword.Size = new System.Drawing.Size(123, 21);
            this.txtaddPassword.TabIndex = 1;
            // 
            // txtAddUsername
            // 
            this.txtAddUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddUsername.Location = new System.Drawing.Point(144, 37);
            this.txtAddUsername.Name = "txtAddUsername";
            this.txtAddUsername.Size = new System.Drawing.Size(123, 21);
            this.txtAddUsername.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirm Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightGray;
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(780, 492);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manage Group";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRemove);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.rbtnListGroups);
            this.groupBox3.Controls.Add(this.rbtnListUsers);
            this.groupBox3.Controls.Add(this.btnDone);
            this.groupBox3.Controls.Add(this.lstDisplayUser);
            this.groupBox3.Controls.Add(this.lstDisplayAddGroups);
            this.groupBox3.Controls.Add(this.btnremovegroupfromuser);
            this.groupBox3.Controls.Add(this.btnaddgrouptouser);
            this.groupBox3.Controls.Add(this.lstDisplayGroup);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(13, 185);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(668, 293);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Assign Groups to Users";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(553, 252);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(99, 35);
            this.btnRemove.TabIndex = 33;
            this.btnRemove.Text = "REMOVE";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(490, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "Selected Groups";
            // 
            // rbtnListGroups
            // 
            this.rbtnListGroups.AutoSize = true;
            this.rbtnListGroups.Location = new System.Drawing.Point(190, 24);
            this.rbtnListGroups.Name = "rbtnListGroups";
            this.rbtnListGroups.Size = new System.Drawing.Size(96, 20);
            this.rbtnListGroups.TabIndex = 8;
            this.rbtnListGroups.TabStop = true;
            this.rbtnListGroups.Text = "List Group";
            this.rbtnListGroups.UseVisualStyleBackColor = true;
            this.rbtnListGroups.CheckedChanged += new System.EventHandler(this.rbtnListGroups_CheckedChanged);
            // 
            // rbtnListUsers
            // 
            this.rbtnListUsers.AutoSize = true;
            this.rbtnListUsers.Location = new System.Drawing.Point(6, 27);
            this.rbtnListUsers.Name = "rbtnListUsers";
            this.rbtnListUsers.Size = new System.Drawing.Size(95, 20);
            this.rbtnListUsers.TabIndex = 7;
            this.rbtnListUsers.TabStop = true;
            this.rbtnListUsers.Text = "List Users";
            this.rbtnListUsers.UseVisualStyleBackColor = true;
            this.rbtnListUsers.CheckedChanged += new System.EventHandler(this.rbtnListUsers_CheckedChanged);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(441, 252);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(88, 35);
            this.btnDone.TabIndex = 11;
            this.btnDone.Text = "ADD";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // lstDisplayUser
            // 
            this.lstDisplayUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDisplayUser.FormattingEnabled = true;
            this.lstDisplayUser.ItemHeight = 16;
            this.lstDisplayUser.Location = new System.Drawing.Point(7, 50);
            this.lstDisplayUser.Name = "lstDisplayUser";
            this.lstDisplayUser.ScrollAlwaysVisible = true;
            this.lstDisplayUser.Size = new System.Drawing.Size(176, 196);
            this.lstDisplayUser.Sorted = true;
            this.lstDisplayUser.TabIndex = 29;
            this.lstDisplayUser.Click += new System.EventHandler(this.lstDisplayUser_Click);
            this.lstDisplayUser.SelectedIndexChanged += new System.EventHandler(this.lstDisplayUser_SelectedIndexChanged);
            // 
            // lstDisplayAddGroups
            // 
            this.lstDisplayAddGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDisplayAddGroups.FormattingEnabled = true;
            this.lstDisplayAddGroups.ItemHeight = 16;
            this.lstDisplayAddGroups.Location = new System.Drawing.Point(493, 50);
            this.lstDisplayAddGroups.Name = "lstDisplayAddGroups";
            this.lstDisplayAddGroups.ScrollAlwaysVisible = true;
            this.lstDisplayAddGroups.Size = new System.Drawing.Size(152, 196);
            this.lstDisplayAddGroups.TabIndex = 27;
            this.lstDisplayAddGroups.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            this.lstDisplayAddGroups.DoubleClick += new System.EventHandler(this.lstDisplayAddGroups_DoubleClick);
            // 
            // btnremovegroupfromuser
            // 
            this.btnremovegroupfromuser.Location = new System.Drawing.Point(397, 143);
            this.btnremovegroupfromuser.Name = "btnremovegroupfromuser";
            this.btnremovegroupfromuser.Size = new System.Drawing.Size(90, 40);
            this.btnremovegroupfromuser.TabIndex = 10;
            this.btnremovegroupfromuser.Text = "<< Deselect";
            this.btnremovegroupfromuser.UseVisualStyleBackColor = true;
            this.btnremovegroupfromuser.Click += new System.EventHandler(this.btnremovegroupfromuser_Click);
            // 
            // btnaddgrouptouser
            // 
            this.btnaddgrouptouser.Location = new System.Drawing.Point(397, 87);
            this.btnaddgrouptouser.Name = "btnaddgrouptouser";
            this.btnaddgrouptouser.Size = new System.Drawing.Size(90, 41);
            this.btnaddgrouptouser.TabIndex = 9;
            this.btnaddgrouptouser.Text = "Select >>";
            this.btnaddgrouptouser.UseVisualStyleBackColor = true;
            this.btnaddgrouptouser.Click += new System.EventHandler(this.btnaddgrouptouser_Click);
            // 
            // lstDisplayGroup
            // 
            this.lstDisplayGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDisplayGroup.FormattingEnabled = true;
            this.lstDisplayGroup.ItemHeight = 16;
            this.lstDisplayGroup.Location = new System.Drawing.Point(190, 50);
            this.lstDisplayGroup.Name = "lstDisplayGroup";
            this.lstDisplayGroup.ScrollAlwaysVisible = true;
            this.lstDisplayGroup.Size = new System.Drawing.Size(192, 196);
            this.lstDisplayGroup.Sorted = true;
            this.lstDisplayGroup.TabIndex = 0;
            this.lstDisplayGroup.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.lstDisplayGroup.DoubleClick += new System.EventHandler(this.lstDisplayGroup_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGroupName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnClearGroup);
            this.groupBox1.Controls.Add(this.btnSaveGroup);
            this.groupBox1.Controls.Add(this.btnExitGroup);
            this.groupBox1.Controls.Add(this.btnSearchGroup);
            this.groupBox1.Controls.Add(this.btnUpdateGroup);
            this.groupBox1.Controls.Add(this.btnDeleteGroup);
            this.groupBox1.Location = new System.Drawing.Point(13, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 163);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Groups";
            // 
            // txtGroupName
            // 
            this.txtGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGroupName.Location = new System.Drawing.Point(93, 19);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(239, 20);
            this.txtGroupName.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Group Name";
            // 
            // btnSaveGroup
            // 
            this.btnSaveGroup.Location = new System.Drawing.Point(30, 121);
            this.btnSaveGroup.Name = "btnSaveGroup";
            this.btnSaveGroup.Size = new System.Drawing.Size(75, 35);
            this.btnSaveGroup.TabIndex = 1;
            this.btnSaveGroup.Text = "Save";
            this.btnSaveGroup.UseVisualStyleBackColor = true;
            this.btnSaveGroup.Click += new System.EventHandler(this.button12_Click);
            // 
            // btnSearchGroup
            // 
            this.btnSearchGroup.Location = new System.Drawing.Point(370, 124);
            this.btnSearchGroup.Name = "btnSearchGroup";
            this.btnSearchGroup.Size = new System.Drawing.Size(75, 32);
            this.btnSearchGroup.TabIndex = 4;
            this.btnSearchGroup.Text = "Search";
            this.btnSearchGroup.UseVisualStyleBackColor = true;
            this.btnSearchGroup.Click += new System.EventHandler(this.button9_Click);
            // 
            // btnUpdateGroup
            // 
            this.btnUpdateGroup.Location = new System.Drawing.Point(257, 125);
            this.btnUpdateGroup.Name = "btnUpdateGroup";
            this.btnUpdateGroup.Size = new System.Drawing.Size(75, 32);
            this.btnUpdateGroup.TabIndex = 3;
            this.btnUpdateGroup.Text = "Update";
            this.btnUpdateGroup.UseVisualStyleBackColor = true;
            this.btnUpdateGroup.Click += new System.EventHandler(this.button10_Click);
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.Location = new System.Drawing.Point(147, 125);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(75, 31);
            this.btnDeleteGroup.TabIndex = 2;
            this.btnDeleteGroup.Text = "Delete";
            this.btnDeleteGroup.UseVisualStyleBackColor = true;
            this.btnDeleteGroup.Click += new System.EventHandler(this.button11_Click);
            // 
            // btnClearGroup
            // 
            this.btnClearGroup.Location = new System.Drawing.Point(466, 125);
            this.btnClearGroup.Name = "btnClearGroup";
            this.btnClearGroup.Size = new System.Drawing.Size(75, 31);
            this.btnClearGroup.TabIndex = 5;
            this.btnClearGroup.Text = "Clear";
            this.btnClearGroup.UseVisualStyleBackColor = true;
            this.btnClearGroup.Click += new System.EventHandler(this.btnClearGroup_Click);
            // 
            // btnExitGroup
            // 
            this.btnExitGroup.Location = new System.Drawing.Point(577, 125);
            this.btnExitGroup.Name = "btnExitGroup";
            this.btnExitGroup.Size = new System.Drawing.Size(75, 32);
            this.btnExitGroup.TabIndex = 6;
            this.btnExitGroup.Text = "Exit";
            this.btnExitGroup.UseVisualStyleBackColor = true;
            this.btnExitGroup.Click += new System.EventHandler(this.btnExitGroup_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.LightGray;
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.btnDoneGrpQueue);
            this.tabPage3.Controls.Add(this.btnExit);
            this.tabPage3.Controls.Add(this.lstSelectedQueues);
            this.tabPage3.Controls.Add(this.rbtnQueuedet);
            this.tabPage3.Controls.Add(this.rbtnGrp);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.btnAdd);
            this.tabPage3.Controls.Add(this.lstQueueDetails);
            this.tabPage3.Controls.Add(this.lstGrpDisplay);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(780, 492);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Manage Group Queue";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(536, 306);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 34);
            this.button3.TabIndex = 10;
            this.button3.Text = "REMOVE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(500, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Selected Queues";
            // 
            // btnDoneGrpQueue
            // 
            this.btnDoneGrpQueue.Location = new System.Drawing.Point(445, 306);
            this.btnDoneGrpQueue.Name = "btnDoneGrpQueue";
            this.btnDoneGrpQueue.Size = new System.Drawing.Size(75, 34);
            this.btnDoneGrpQueue.TabIndex = 8;
            this.btnDoneGrpQueue.Text = "ADD";
            this.btnDoneGrpQueue.UseVisualStyleBackColor = true;
            this.btnDoneGrpQueue.Click += new System.EventHandler(this.btnDoneGrpQueue_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(619, 306);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 34);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lstSelectedQueues
            // 
            this.lstSelectedQueues.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSelectedQueues.FormattingEnabled = true;
            this.lstSelectedQueues.ItemHeight = 16;
            this.lstSelectedQueues.Location = new System.Drawing.Point(503, 70);
            this.lstSelectedQueues.Name = "lstSelectedQueues";
            this.lstSelectedQueues.Size = new System.Drawing.Size(182, 196);
            this.lstSelectedQueues.TabIndex = 6;
            this.lstSelectedQueues.DoubleClick += new System.EventHandler(this.lstSelectedQueues_DoubleClick);
            // 
            // rbtnQueuedet
            // 
            this.rbtnQueuedet.AutoSize = true;
            this.rbtnQueuedet.Location = new System.Drawing.Point(231, 47);
            this.rbtnQueuedet.Name = "rbtnQueuedet";
            this.rbtnQueuedet.Size = new System.Drawing.Size(76, 17);
            this.rbtnQueuedet.TabIndex = 5;
            this.rbtnQueuedet.TabStop = true;
            this.rbtnQueuedet.Text = "Queue List";
            this.rbtnQueuedet.UseVisualStyleBackColor = true;
            this.rbtnQueuedet.CheckedChanged += new System.EventHandler(this.rbtnQueuedet_CheckedChanged);
            // 
            // rbtnGrp
            // 
            this.rbtnGrp.AutoSize = true;
            this.rbtnGrp.Location = new System.Drawing.Point(20, 47);
            this.rbtnGrp.Name = "rbtnGrp";
            this.rbtnGrp.Size = new System.Drawing.Size(73, 17);
            this.rbtnGrp.TabIndex = 4;
            this.rbtnGrp.TabStop = true;
            this.rbtnGrp.Text = "Group List";
            this.rbtnGrp.UseVisualStyleBackColor = true;
            this.rbtnGrp.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(422, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "<<Deselect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(422, 128);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 33);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Select>>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstQueueDetails
            // 
            this.lstQueueDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstQueueDetails.FormattingEnabled = true;
            this.lstQueueDetails.ItemHeight = 16;
            this.lstQueueDetails.Location = new System.Drawing.Point(225, 70);
            this.lstQueueDetails.Name = "lstQueueDetails";
            this.lstQueueDetails.Size = new System.Drawing.Size(182, 196);
            this.lstQueueDetails.TabIndex = 1;
            this.lstQueueDetails.DoubleClick += new System.EventHandler(this.lstQueueDetails_DoubleClick);
            // 
            // lstGrpDisplay
            // 
            this.lstGrpDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstGrpDisplay.FormattingEnabled = true;
            this.lstGrpDisplay.ItemHeight = 16;
            this.lstGrpDisplay.Location = new System.Drawing.Point(20, 70);
            this.lstGrpDisplay.Name = "lstGrpDisplay";
            this.lstGrpDisplay.Size = new System.Drawing.Size(182, 196);
            this.lstGrpDisplay.TabIndex = 0;
            // 
            // frmAddUserGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(812, 542);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddUserGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage User/Groups";
            this.Load += new System.EventHandler(this.frmAddUserGroup_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgManageUser)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtAddConfirmPass;
        private System.Windows.Forms.TextBox txtaddPassword;
        private System.Windows.Forms.TextBox txtAddUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExitAddUser;
        private System.Windows.Forms.Button btnSearchUser;
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnClearUser;
        private System.Windows.Forms.Button btnClearGroup;
        private System.Windows.Forms.Button btnExitGroup;
        private System.Windows.Forms.Button btnSearchGroup;
        private System.Windows.Forms.Button btnUpdateGroup;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.Button btnSaveGroup;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgManageUser;
        private System.Windows.Forms.ListBox lstDisplayAddGroups;
        private System.Windows.Forms.Button btnremovegroupfromuser;
        private System.Windows.Forms.Button btnaddgrouptouser;
        private System.Windows.Forms.ListBox lstDisplayGroup;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.ListBox lstDisplayUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtnListGroups;
        private System.Windows.Forms.RadioButton rbtnListUsers;
        private System.Windows.Forms.TextBox txtSecurityAns;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbSecurityQuestion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RadioButton rbtnQueuedet;
        private System.Windows.Forms.RadioButton rbtnGrp;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstQueueDetails;
        private System.Windows.Forms.ListBox lstGrpDisplay;
        private System.Windows.Forms.ListBox lstSelectedQueues;
        private System.Windows.Forms.Button btnDoneGrpQueue;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button button3;
    }
}