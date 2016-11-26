namespace SalesPurchase
{
    partial class frmDepartmentMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDepartmentMaster));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgDepttMaster = new System.Windows.Forms.DataGridView();
            this.btnDepttClear = new System.Windows.Forms.Button();
            this.btnDepttExit = new System.Windows.Forms.Button();
            this.txtDepttName = new System.Windows.Forms.TextBox();
            this.txtDepttCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDepttSearch = new System.Windows.Forms.Button();
            this.btnDepttDelete = new System.Windows.Forms.Button();
            this.btnDepttModify = new System.Windows.Forms.Button();
            this.btnDepttSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDepttMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgDepttMaster);
            this.groupBox1.Controls.Add(this.btnDepttClear);
            this.groupBox1.Controls.Add(this.btnDepttExit);
            this.groupBox1.Controls.Add(this.txtDepttName);
            this.groupBox1.Controls.Add(this.txtDepttCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnDepttSearch);
            this.groupBox1.Controls.Add(this.btnDepttDelete);
            this.groupBox1.Controls.Add(this.btnDepttModify);
            this.groupBox1.Controls.Add(this.btnDepttSave);
            this.groupBox1.Location = new System.Drawing.Point(25, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 349);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Department";
            // 
            // dgDepttMaster
            // 
            this.dgDepttMaster.AllowUserToDeleteRows = false;
            this.dgDepttMaster.AllowUserToResizeRows = false;
            this.dgDepttMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDepttMaster.Location = new System.Drawing.Point(18, 112);
            this.dgDepttMaster.Name = "dgDepttMaster";
            this.dgDepttMaster.Size = new System.Drawing.Size(454, 109);
            this.dgDepttMaster.TabIndex = 10;
            // 
            // btnDepttClear
            // 
            this.btnDepttClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDepttClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepttClear.Location = new System.Drawing.Point(18, 302);
            this.btnDepttClear.Name = "btnDepttClear";
            this.btnDepttClear.Size = new System.Drawing.Size(95, 37);
            this.btnDepttClear.TabIndex = 9;
            this.btnDepttClear.Text = "Clear";
            this.btnDepttClear.UseVisualStyleBackColor = false;
            this.btnDepttClear.Click += new System.EventHandler(this.btnDepttClear_Click);
            // 
            // btnDepttExit
            // 
            this.btnDepttExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDepttExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDepttExit.FlatAppearance.BorderSize = 5;
            this.btnDepttExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepttExit.Location = new System.Drawing.Point(455, 241);
            this.btnDepttExit.Name = "btnDepttExit";
            this.btnDepttExit.Size = new System.Drawing.Size(96, 42);
            this.btnDepttExit.TabIndex = 8;
            this.btnDepttExit.Text = "Exit";
            this.btnDepttExit.UseVisualStyleBackColor = false;
            this.btnDepttExit.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtDepttName
            // 
            this.txtDepttName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepttName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepttName.Location = new System.Drawing.Point(158, 76);
            this.txtDepttName.Name = "txtDepttName";
            this.txtDepttName.Size = new System.Drawing.Size(221, 21);
            this.txtDepttName.TabIndex = 7;
            // 
            // txtDepttCode
            // 
            this.txtDepttCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepttCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDepttCode.Location = new System.Drawing.Point(158, 37);
            this.txtDepttCode.Name = "txtDepttCode";
            this.txtDepttCode.Size = new System.Drawing.Size(221, 21);
            this.txtDepttCode.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Department Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Department Code";
            // 
            // btnDepttSearch
            // 
            this.btnDepttSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDepttSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepttSearch.Location = new System.Drawing.Point(351, 241);
            this.btnDepttSearch.Name = "btnDepttSearch";
            this.btnDepttSearch.Size = new System.Drawing.Size(84, 42);
            this.btnDepttSearch.TabIndex = 3;
            this.btnDepttSearch.Text = "Search";
            this.btnDepttSearch.UseVisualStyleBackColor = false;
            this.btnDepttSearch.Click += new System.EventHandler(this.btnDepttSearch_Click);
            // 
            // btnDepttDelete
            // 
            this.btnDepttDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDepttDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepttDelete.Location = new System.Drawing.Point(248, 241);
            this.btnDepttDelete.Name = "btnDepttDelete";
            this.btnDepttDelete.Size = new System.Drawing.Size(85, 42);
            this.btnDepttDelete.TabIndex = 2;
            this.btnDepttDelete.Text = "Delete";
            this.btnDepttDelete.UseVisualStyleBackColor = false;
            this.btnDepttDelete.Click += new System.EventHandler(this.btnDepttDelete_Click);
            // 
            // btnDepttModify
            // 
            this.btnDepttModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDepttModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepttModify.Location = new System.Drawing.Point(142, 241);
            this.btnDepttModify.Name = "btnDepttModify";
            this.btnDepttModify.Size = new System.Drawing.Size(84, 42);
            this.btnDepttModify.TabIndex = 1;
            this.btnDepttModify.Text = "Modify";
            this.btnDepttModify.UseVisualStyleBackColor = false;
            this.btnDepttModify.Click += new System.EventHandler(this.btnDepttModify_Click);
            // 
            // btnDepttSave
            // 
            this.btnDepttSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDepttSave.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnDepttSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepttSave.ForeColor = System.Drawing.Color.Black;
            this.btnDepttSave.Location = new System.Drawing.Point(18, 241);
            this.btnDepttSave.Name = "btnDepttSave";
            this.btnDepttSave.Size = new System.Drawing.Size(95, 42);
            this.btnDepttSave.TabIndex = 0;
            this.btnDepttSave.Text = "Save";
            this.btnDepttSave.UseVisualStyleBackColor = false;
            this.btnDepttSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmDepartmentMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(594, 373);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDepartmentMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Department Master";
            this.Load += new System.EventHandler(this.frmDepartmentMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDepttMaster)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDepttName;
        private System.Windows.Forms.TextBox txtDepttCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDepttSearch;
        private System.Windows.Forms.Button btnDepttDelete;
        private System.Windows.Forms.Button btnDepttModify;
        private System.Windows.Forms.Button btnDepttSave;
        private System.Windows.Forms.Button btnDepttExit;
        private System.Windows.Forms.DataGridView dgDepttMaster;
        private System.Windows.Forms.Button btnDepttClear;
    }
}