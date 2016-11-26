namespace SalesPurchase
{
    partial class frmSearchCreditCustomers
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
            this.dgvwSearchCreditCustomers = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvwSearchCreditCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvwSearchCreditCustomers
            // 
            this.dgvwSearchCreditCustomers.AllowUserToAddRows = false;
            this.dgvwSearchCreditCustomers.AllowUserToDeleteRows = false;
            this.dgvwSearchCreditCustomers.AllowUserToResizeRows = false;
            this.dgvwSearchCreditCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvwSearchCreditCustomers.Location = new System.Drawing.Point(31, 31);
            this.dgvwSearchCreditCustomers.Name = "dgvwSearchCreditCustomers";
            this.dgvwSearchCreditCustomers.ReadOnly = true;
            this.dgvwSearchCreditCustomers.Size = new System.Drawing.Size(693, 357);
            this.dgvwSearchCreditCustomers.TabIndex = 0;
            this.dgvwSearchCreditCustomers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvwSearchCreditCustomers_CellContentClick);
            this.dgvwSearchCreditCustomers.Click += new System.EventHandler(this.dgvwSearchCreditCustomers_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(31, 394);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(98, 41);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(156, 394);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(92, 41);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmSearchCreditCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 447);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgvwSearchCreditCustomers);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearchCreditCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Credit Customers";
            this.Load += new System.EventHandler(this.frmSearchCreditCustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvwSearchCreditCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvwSearchCreditCustomers;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
    }
}