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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListCustomers));
            this.btnRegister = new System.Windows.Forms.Button();
            this.customersGridView = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnInactive = new System.Windows.Forms.Button();
            this.radioActives = new System.Windows.Forms.RadioButton();
            this.radioInactives = new System.Windows.Forms.RadioButton();
            this.txtFilterName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mTxtFilterCpf = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.customersGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(142, 473);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(137, 57);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Cadastrar Cliente";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // customersGridView
            // 
            this.customersGridView.AllowUserToAddRows = false;
            this.customersGridView.AllowUserToDeleteRows = false;
            this.customersGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customersGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customersGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.customersGridView.Location = new System.Drawing.Point(0, 99);
            this.customersGridView.MultiSelect = false;
            this.customersGridView.Name = "customersGridView";
            this.customersGridView.ReadOnly = true;
            this.customersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customersGridView.ShowEditingIcon = false;
            this.customersGridView.Size = new System.Drawing.Size(704, 361);
            this.customersGridView.TabIndex = 7;
            this.customersGridView.SelectionChanged += new System.EventHandler(this.usersGridView_SelectionChanged);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(411, 473);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(132, 57);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Editar Cliente";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnInactive
            // 
            this.btnInactive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnInactive.Enabled = false;
            this.btnInactive.FlatAppearance.BorderSize = 0;
            this.btnInactive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInactive.ForeColor = System.Drawing.Color.White;
            this.btnInactive.Location = new System.Drawing.Point(549, 473);
            this.btnInactive.Name = "btnInactive";
            this.btnInactive.Size = new System.Drawing.Size(134, 57);
            this.btnInactive.TabIndex = 9;
            this.btnInactive.Text = "Inativar Cliente";
            this.btnInactive.UseVisualStyleBackColor = false;
            this.btnInactive.Click += new System.EventHandler(this.btnInactive_Click);
            // 
            // radioActives
            // 
            this.radioActives.AutoSize = true;
            this.radioActives.Checked = true;
            this.radioActives.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioActives.Location = new System.Drawing.Point(22, 476);
            this.radioActives.Name = "radioActives";
            this.radioActives.Size = new System.Drawing.Size(66, 22);
            this.radioActives.TabIndex = 10;
            this.radioActives.TabStop = true;
            this.radioActives.Text = "Ativos";
            this.radioActives.UseVisualStyleBackColor = true;
            this.radioActives.CheckedChanged += new System.EventHandler(this.radioActives_CheckedChanged);
            // 
            // radioInactives
            // 
            this.radioInactives.AutoSize = true;
            this.radioInactives.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioInactives.Location = new System.Drawing.Point(22, 499);
            this.radioInactives.Name = "radioInactives";
            this.radioInactives.Size = new System.Drawing.Size(76, 22);
            this.radioInactives.TabIndex = 11;
            this.radioInactives.Text = "Inativos";
            this.radioInactives.UseVisualStyleBackColor = true;
            // 
            // txtFilterName
            // 
            this.txtFilterName.Location = new System.Drawing.Point(65, 22);
            this.txtFilterName.Name = "txtFilterName";
            this.txtFilterName.Size = new System.Drawing.Size(244, 24);
            this.txtFilterName.TabIndex = 12;
            this.txtFilterName.TextChanged += new System.EventHandler(this.txtFilterName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nome";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mTxtFilterCpf);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFilterName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(90, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 54);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // mTxtFilterCpf
            // 
            this.mTxtFilterCpf.Location = new System.Drawing.Point(374, 22);
            this.mTxtFilterCpf.Mask = "000\\.000\\.000-00";
            this.mTxtFilterCpf.Name = "mTxtFilterCpf";
            this.mTxtFilterCpf.Size = new System.Drawing.Size(114, 24);
            this.mTxtFilterCpf.TabIndex = 17;
            this.mTxtFilterCpf.TextChanged += new System.EventHandler(this.mTxtFilterCpf_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "CPF";
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnNewOrder.FlatAppearance.BorderSize = 0;
            this.btnNewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewOrder.ForeColor = System.Drawing.Color.White;
            this.btnNewOrder.Location = new System.Drawing.Point(285, 473);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(120, 57);
            this.btnNewOrder.TabIndex = 16;
            this.btnNewOrder.Text = "Novo Pedido";
            this.btnNewOrder.UseVisualStyleBackColor = false;
            this.btnNewOrder.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnBack
            // 
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(0, 1);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(63, 51);
            this.btnBack.TabIndex = 17;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(311, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = "Clientes";
            // 
            // FormListCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(704, 541);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNewOrder);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioInactives);
            this.Controls.Add(this.radioActives);
            this.Controls.Add(this.btnInactive);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.customersGridView);
            this.Controls.Add(this.btnRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(720, 603);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(720, 580);
            this.Name = "FormListCustomers";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
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
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label3;
    }
}