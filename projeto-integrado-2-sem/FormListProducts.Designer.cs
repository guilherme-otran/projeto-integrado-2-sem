namespace projeto_integrado_2_sem
{
    partial class FormListProducts
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
            this.customersGridView = new System.Windows.Forms.DataGridView();
            this.btnRegisterProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // customersGridView
            // 
            this.customersGridView.AllowUserToAddRows = false;
            this.customersGridView.AllowUserToDeleteRows = false;
            this.customersGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customersGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customersGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.customersGridView.Location = new System.Drawing.Point(0, 77);
            this.customersGridView.MultiSelect = false;
            this.customersGridView.Name = "customersGridView";
            this.customersGridView.ReadOnly = true;
            this.customersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customersGridView.ShowEditingIcon = false;
            this.customersGridView.Size = new System.Drawing.Size(674, 356);
            this.customersGridView.TabIndex = 8;
            // 
            // btnRegisterProduct
            // 
            this.btnRegisterProduct.Location = new System.Drawing.Point(528, 450);
            this.btnRegisterProduct.Name = "btnRegisterProduct";
            this.btnRegisterProduct.Size = new System.Drawing.Size(134, 49);
            this.btnRegisterProduct.TabIndex = 9;
            this.btnRegisterProduct.Text = "Cadastrar novo produto";
            this.btnRegisterProduct.UseVisualStyleBackColor = true;
            this.btnRegisterProduct.Click += new System.EventHandler(this.btnRegisterProduct_Click);
            // 
            // FormListProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(674, 511);
            this.Controls.Add(this.btnRegisterProduct);
            this.Controls.Add(this.customersGridView);
            this.Name = "FormListProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Produtos";
            ((System.ComponentModel.ISupportInitialize)(this.customersGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView customersGridView;
        private System.Windows.Forms.Button btnRegisterProduct;
    }
}