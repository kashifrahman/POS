namespace SalesPurchase
{
    partial class frmEventMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEventMaster));
            this.btnEventAdd = new System.Windows.Forms.Button();
            this.btnEventSearch = new System.Windows.Forms.Button();
            this.btnEventDelete = new System.Windows.Forms.Button();
            this.btnEventExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.dgEventMaster = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgEventMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEventAdd
            // 
            this.btnEventAdd.Location = new System.Drawing.Point(57, 291);
            this.btnEventAdd.Name = "btnEventAdd";
            this.btnEventAdd.Size = new System.Drawing.Size(75, 35);
            this.btnEventAdd.TabIndex = 0;
            this.btnEventAdd.Text = "Save";
            this.btnEventAdd.UseVisualStyleBackColor = true;
            this.btnEventAdd.Click += new System.EventHandler(this.btnEventAdd_Click);
            // 
            // btnEventSearch
            // 
            this.btnEventSearch.Location = new System.Drawing.Point(154, 291);
            this.btnEventSearch.Name = "btnEventSearch";
            this.btnEventSearch.Size = new System.Drawing.Size(75, 35);
            this.btnEventSearch.TabIndex = 1;
            this.btnEventSearch.Text = "Search";
            this.btnEventSearch.UseVisualStyleBackColor = true;
            this.btnEventSearch.Click += new System.EventHandler(this.btnEventSearch_Click);
            // 
            // btnEventDelete
            // 
            this.btnEventDelete.Location = new System.Drawing.Point(260, 291);
            this.btnEventDelete.Name = "btnEventDelete";
            this.btnEventDelete.Size = new System.Drawing.Size(75, 35);
            this.btnEventDelete.TabIndex = 2;
            this.btnEventDelete.Text = "Delete";
            this.btnEventDelete.UseVisualStyleBackColor = true;
            this.btnEventDelete.Click += new System.EventHandler(this.btnEventDelete_Click);
            // 
            // btnEventExit
            // 
            this.btnEventExit.Location = new System.Drawing.Point(486, 291);
            this.btnEventExit.Name = "btnEventExit";
            this.btnEventExit.Size = new System.Drawing.Size(75, 35);
            this.btnEventExit.TabIndex = 3;
            this.btnEventExit.Text = "Exit";
            this.btnEventExit.UseVisualStyleBackColor = true;
            this.btnEventExit.Click += new System.EventHandler(this.btnEventExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Event Name";
            // 
            // txtEventName
            // 
            this.txtEventName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEventName.Location = new System.Drawing.Point(154, 60);
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.Size = new System.Drawing.Size(292, 20);
            this.txtEventName.TabIndex = 5;
            // 
            // dgEventMaster
            // 
            this.dgEventMaster.AllowUserToAddRows = false;
            this.dgEventMaster.AllowUserToDeleteRows = false;
            this.dgEventMaster.AllowUserToResizeRows = false;
            this.dgEventMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEventMaster.Location = new System.Drawing.Point(154, 99);
            this.dgEventMaster.Name = "dgEventMaster";
            this.dgEventMaster.Size = new System.Drawing.Size(296, 172);
            this.dgEventMaster.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(371, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmEventMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 355);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgEventMaster);
            this.Controls.Add(this.txtEventName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEventExit);
            this.Controls.Add(this.btnEventDelete);
            this.Controls.Add(this.btnEventSearch);
            this.Controls.Add(this.btnEventAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmEventMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Event Master";
            ((System.ComponentModel.ISupportInitialize)(this.dgEventMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEventAdd;
        private System.Windows.Forms.Button btnEventSearch;
        private System.Windows.Forms.Button btnEventDelete;
        private System.Windows.Forms.Button btnEventExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.DataGridView dgEventMaster;
        private System.Windows.Forms.Button button1;
    }
}