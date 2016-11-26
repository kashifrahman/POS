namespace SalesPurchase
{
    partial class frmMaintainGroups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaintainGroups));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMainGroup = new System.Windows.Forms.TextBox();
            this.rbtnSearchMainGroup = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtnSearchGroup = new System.Windows.Forms.RadioButton();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbtnSearchSubgroup = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSubGroup = new System.Windows.Forms.TextBox();
            this.btnGroupSave = new System.Windows.Forms.Button();
            this.btnGroupDelete = new System.Windows.Forms.Button();
            this.btnGroupClear = new System.Windows.Forms.Button();
            this.btnGroupExit = new System.Windows.Forms.Button();
            this.dgGroupMaster = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGroupMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMainGroup);
            this.groupBox1.Controls.Add(this.rbtnSearchMainGroup);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main Group";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Main Group";
            // 
            // txtMainGroup
            // 
            this.txtMainGroup.Location = new System.Drawing.Point(100, 38);
            this.txtMainGroup.Name = "txtMainGroup";
            this.txtMainGroup.Size = new System.Drawing.Size(163, 20);
            this.txtMainGroup.TabIndex = 0;
            this.txtMainGroup.TextChanged += new System.EventHandler(this.txtMainGroup_TextChanged);
            // 
            // rbtnSearchMainGroup
            // 
            this.rbtnSearchMainGroup.AutoSize = true;
            this.rbtnSearchMainGroup.Location = new System.Drawing.Point(7, 77);
            this.rbtnSearchMainGroup.Name = "rbtnSearchMainGroup";
            this.rbtnSearchMainGroup.Size = new System.Drawing.Size(117, 17);
            this.rbtnSearchMainGroup.TabIndex = 3;
            this.rbtnSearchMainGroup.TabStop = true;
            this.rbtnSearchMainGroup.Text = "Search Main Group";
            this.rbtnSearchMainGroup.UseVisualStyleBackColor = true;
            this.rbtnSearchMainGroup.CheckedChanged += new System.EventHandler(this.rbtnSearchMainGroup_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.rbtnSearchGroup);
            this.groupBox2.Controls.Add(this.txtGroup);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(287, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Group";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter Group";
            // 
            // rbtnSearchGroup
            // 
            this.rbtnSearchGroup.AutoSize = true;
            this.rbtnSearchGroup.Location = new System.Drawing.Point(9, 77);
            this.rbtnSearchGroup.Name = "rbtnSearchGroup";
            this.rbtnSearchGroup.Size = new System.Drawing.Size(91, 17);
            this.rbtnSearchGroup.TabIndex = 4;
            this.rbtnSearchGroup.TabStop = true;
            this.rbtnSearchGroup.Text = "Search Group";
            this.rbtnSearchGroup.UseVisualStyleBackColor = true;
            this.rbtnSearchGroup.CheckedChanged += new System.EventHandler(this.rbtnSearchGroup_CheckedChanged);
            // 
            // txtGroup
            // 
            this.txtGroup.Location = new System.Drawing.Point(76, 38);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(122, 20);
            this.txtGroup.TabIndex = 1;
            this.txtGroup.TextChanged += new System.EventHandler(this.txtGroup_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(210, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Group";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbtnSearchSubgroup);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtSubGroup);
            this.groupBox4.Location = new System.Drawing.Point(497, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(229, 100);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sub Group";
            // 
            // rbtnSearchSubgroup
            // 
            this.rbtnSearchSubgroup.AutoSize = true;
            this.rbtnSearchSubgroup.Location = new System.Drawing.Point(6, 77);
            this.rbtnSearchSubgroup.Name = "rbtnSearchSubgroup";
            this.rbtnSearchSubgroup.Size = new System.Drawing.Size(113, 17);
            this.rbtnSearchSubgroup.TabIndex = 5;
            this.rbtnSearchSubgroup.TabStop = true;
            this.rbtnSearchSubgroup.Text = "Search Sub Group";
            this.rbtnSearchSubgroup.UseVisualStyleBackColor = true;
            this.rbtnSearchSubgroup.CheckedChanged += new System.EventHandler(this.rbtnSearchSubgroup_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Enter Sub Group";
            // 
            // txtSubGroup
            // 
            this.txtSubGroup.Location = new System.Drawing.Point(93, 38);
            this.txtSubGroup.Name = "txtSubGroup";
            this.txtSubGroup.Size = new System.Drawing.Size(131, 20);
            this.txtSubGroup.TabIndex = 2;
            this.txtSubGroup.TextChanged += new System.EventHandler(this.txtSubGroup_TextChanged);
            // 
            // btnGroupSave
            // 
            this.btnGroupSave.Location = new System.Drawing.Point(176, 285);
            this.btnGroupSave.Name = "btnGroupSave";
            this.btnGroupSave.Size = new System.Drawing.Size(75, 23);
            this.btnGroupSave.TabIndex = 7;
            this.btnGroupSave.Text = "Save";
            this.btnGroupSave.UseVisualStyleBackColor = true;
            this.btnGroupSave.Click += new System.EventHandler(this.btnGroupSave_Click);
            // 
            // btnGroupDelete
            // 
            this.btnGroupDelete.Location = new System.Drawing.Point(269, 285);
            this.btnGroupDelete.Name = "btnGroupDelete";
            this.btnGroupDelete.Size = new System.Drawing.Size(75, 23);
            this.btnGroupDelete.TabIndex = 8;
            this.btnGroupDelete.Text = "Delete";
            this.btnGroupDelete.UseVisualStyleBackColor = true;
            this.btnGroupDelete.Click += new System.EventHandler(this.btnGroupDelete_Click);
            // 
            // btnGroupClear
            // 
            this.btnGroupClear.Location = new System.Drawing.Point(363, 285);
            this.btnGroupClear.Name = "btnGroupClear";
            this.btnGroupClear.Size = new System.Drawing.Size(75, 23);
            this.btnGroupClear.TabIndex = 9;
            this.btnGroupClear.Text = "Clear";
            this.btnGroupClear.UseVisualStyleBackColor = true;
            this.btnGroupClear.Click += new System.EventHandler(this.btnGroupClear_Click);
            // 
            // btnGroupExit
            // 
            this.btnGroupExit.Location = new System.Drawing.Point(454, 285);
            this.btnGroupExit.Name = "btnGroupExit";
            this.btnGroupExit.Size = new System.Drawing.Size(75, 23);
            this.btnGroupExit.TabIndex = 10;
            this.btnGroupExit.Text = "Exit";
            this.btnGroupExit.UseVisualStyleBackColor = true;
            this.btnGroupExit.Click += new System.EventHandler(this.button4_Click);
            // 
            // dgGroupMaster
            // 
            this.dgGroupMaster.AllowUserToAddRows = false;
            this.dgGroupMaster.AllowUserToDeleteRows = false;
            this.dgGroupMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGroupMaster.Location = new System.Drawing.Point(245, 118);
            this.dgGroupMaster.Name = "dgGroupMaster";
            this.dgGroupMaster.Size = new System.Drawing.Size(240, 161);
            this.dgGroupMaster.TabIndex = 6;
            this.dgGroupMaster.Click += new System.EventHandler(this.dgGroupMaster_Click);
            // 
            // frmMaintainGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 320);
            this.Controls.Add(this.dgGroupMaster);
            this.Controls.Add(this.btnGroupExit);
            this.Controls.Add(this.btnGroupClear);
            this.Controls.Add(this.btnGroupDelete);
            this.Controls.Add(this.btnGroupSave);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMaintainGroups";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maintain Groups";
            this.Load += new System.EventHandler(this.frmMaintainGroups_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGroupMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMainGroup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubGroup;
        private System.Windows.Forms.Button btnGroupSave;
        private System.Windows.Forms.Button btnGroupDelete;
        private System.Windows.Forms.Button btnGroupClear;
        private System.Windows.Forms.Button btnGroupExit;
        private System.Windows.Forms.RadioButton rbtnSearchMainGroup;
        private System.Windows.Forms.RadioButton rbtnSearchGroup;
        private System.Windows.Forms.RadioButton rbtnSearchSubgroup;
        private System.Windows.Forms.DataGridView dgGroupMaster;
    }
}