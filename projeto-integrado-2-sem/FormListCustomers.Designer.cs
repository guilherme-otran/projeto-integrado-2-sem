namespace projeto_integrado_2_sem
{
    partial class FormListCustomers
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
            this.btnRegister = new System.Windows.Forms.Button();
            this.customersGridView = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnInactive = new System.Windows.Forms.Button();
            this.radioActives = new System.Windows.Forms.RadioButton();
            this.radioInactives = new System.Windows.Forms.RadioButton();
            this.txtFilterName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mTxtFilterCpf = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.customersGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(137, 439);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(170, 57);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Cadastrar Cliente";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
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
            this.customersGridView.Location = new System.Drawing.Point(0, 72);
            this.customersGridView.MultiSelect = false;
            this.customersGridView.Name = "customersGridView";
            this.customersGridView.ReadOnly = true;
            this.customersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customersGridView.ShowEditingIcon = false;
            this.customersGridView.Size = new System.Drawing.Size(671, 353);
            this.customersGridView.TabIndex = 7;
            this.customersGridView.SelectionChanged += new System.EventHandler(this.usersGridView_SelectionChanged);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(313, 439);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(170, 57);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Editar Cliente";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnInactive
            // 
            this.btnInactive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInactive.Enabled = false;
            this.btnInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInactive.Location = new System.Drawing.Point(489, 439);
            this.btnInactive.Name = "btnInactive";
            this.btnInactive.Size = new System.Drawing.Size(170, 57);
            this.btnInactive.TabIndex = 9;
            this.btnInactive.Text = "Inativar Cliente";
            this.btnInactive.UseVisualStyleBackColor = true;
            this.btnInactive.Click += new System.EventHandler(this.btnInactive_Click);
            // 
            // radioActives
            // 
            this.radioActives.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioActives.AutoSize = true;
            this.radioActives.Checked = true;
            this.radioActives.Location = new System.Drawing.Point(12, 449);
            this.radioActives.Name = "radioActives";
            this.radioActives.Size = new System.Drawing.Size(54, 17);
            this.radioActives.TabIndex = 10;
            this.radioActives.TabStop = true;
            this.radioActives.Text = "Ativos";
            this.radioActives.UseVisualStyleBackColor = true;
            this.radioActives.CheckedChanged += new System.EventHandler(this.radioActives_CheckedChanged);
            // 
            // radioInactives
            // 
            this.radioInactives.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioInactives.AutoSize = true;
            this.radioInactives.Location = new System.Drawing.Point(12, 472);
            this.radioInactives.Name = "radioInactives";
            this.radioInactives.Size = new System.Drawing.Size(62, 17);
            this.radioInactives.TabIndex = 11;
            this.radioInactives.Text = "Inativos";
            this.radioInactives.UseVisualStyleBackColor = true;
            // 
            // txtFilterName
            // 
            this.txtFilterName.Location = new System.Drawing.Point(51, 19);
            this.txtFilterName.Name = "txtFilterName";
            this.txtFilterName.Size = new System.Drawing.Size(244, 20);
            this.txtFilterName.TabIndex = 12;
            this.txtFilterName.TextChanged += new System.EventHandler(this.txtFilterName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nome:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mTxtFilterCpf);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFilterName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 54);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "CPF:";
            // 
            // mTxtFilterCpf
            // 
            this.mTxtFilterCpf.Location = new System.Drawing.Point(337, 19);
            this.mTxtFilterCpf.Mask = "000\\.000\\.000-00";
            this.mTxtFilterCpf.Name = "mTxtFilterCpf";
            this.mTxtFilterCpf.Size = new System.Drawing.Size(114, 20);
            this.mTxtFilterCpf.TabIndex = 17;
            this.mTxtFilterCpf.TextChanged += new System.EventHandler(this.mTxtFilterCpf_TextChanged);
            // 
            // FormListCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(671, 508);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioInactives);
            this.Controls.Add(this.radioActives);
            this.Controls.Add(this.btnInactive);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.customersGridView);
            this.Controls.Add(this.btnRegister);
            this.Name = "FormListCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de clientes";
            ((System.ComponentModel.ISupportInitialize)(this.customersGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.DataGridView customersGridView;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnInactive;
        private System.Windows.Forms.RadioButton radioActives;
        private System.Windows.Forms.RadioButton radioInactives;
        private System.Windows.Forms.TextBox txtFilterName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox mTxtFilterCpf;
        private System.Windows.Forms.Label label1;
    }
}