namespace projeto_integrado_2_sem
{
    partial class FormOrderReports
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
            this.salesReportGridView = new System.Windows.Forms.DataGridView();
            this.radGroupCustomer = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radGroupDate = new System.Windows.Forms.RadioButton();
            this.radGroupProd = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.salesReportGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // salesReportGridView
            // 
            this.salesReportGridView.AllowUserToAddRows = false;
            this.salesReportGridView.AllowUserToDeleteRows = false;
            this.salesReportGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.salesReportGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.salesReportGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.salesReportGridView.Location = new System.Drawing.Point(12, 71);
            this.salesReportGridView.Name = "salesReportGridView";
            this.salesReportGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.salesReportGridView.Size = new System.Drawing.Size(499, 316);
            this.salesReportGridView.TabIndex = 0;
            this.salesReportGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.salesReportGridView_DataBindingComplete);
            // 
            // radGroupCustomer
            // 
            this.radGroupCustomer.AutoSize = true;
            this.radGroupCustomer.Checked = true;
            this.radGroupCustomer.Location = new System.Drawing.Point(18, 22);
            this.radGroupCustomer.Name = "radGroupCustomer";
            this.radGroupCustomer.Size = new System.Drawing.Size(57, 17);
            this.radGroupCustomer.TabIndex = 1;
            this.radGroupCustomer.TabStop = true;
            this.radGroupCustomer.Text = "Cliente";
            this.radGroupCustomer.UseVisualStyleBackColor = true;
            this.radGroupCustomer.CheckedChanged += new System.EventHandler(this.radGroup_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radGroupDate);
            this.groupBox1.Controls.Add(this.radGroupProd);
            this.groupBox1.Controls.Add(this.radGroupCustomer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agrupar Por";
            // 
            // radGroupDate
            // 
            this.radGroupDate.AutoSize = true;
            this.radGroupDate.Location = new System.Drawing.Point(149, 22);
            this.radGroupDate.Name = "radGroupDate";
            this.radGroupDate.Size = new System.Drawing.Size(48, 17);
            this.radGroupDate.TabIndex = 3;
            this.radGroupDate.Text = "Data";
            this.radGroupDate.UseVisualStyleBackColor = true;
            this.radGroupDate.CheckedChanged += new System.EventHandler(this.radGroup_CheckedChanged);
            // 
            // radGroupProd
            // 
            this.radGroupProd.AutoSize = true;
            this.radGroupProd.Location = new System.Drawing.Point(81, 22);
            this.radGroupProd.Name = "radGroupProd";
            this.radGroupProd.Size = new System.Drawing.Size(62, 17);
            this.radGroupProd.TabIndex = 2;
            this.radGroupProd.Text = "Produto";
            this.radGroupProd.UseVisualStyleBackColor = true;
            this.radGroupProd.CheckedChanged += new System.EventHandler(this.radGroup_CheckedChanged);
            // 
            // FormOrderReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 399);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.salesReportGridView);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(539, 438);
            this.Name = "FormOrderReports";
            this.Text = "Relatório de Vendas";
            this.Load += new System.EventHandler(this.FormOrderReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salesReportGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView salesReportGridView;
        private System.Windows.Forms.RadioButton radGroupCustomer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radGroupDate;
        private System.Windows.Forms.RadioButton radGroupProd;
    }
}