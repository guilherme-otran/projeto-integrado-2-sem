﻿namespace projeto_integrado_2_sem
{
    partial class FormListUsers
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
            this.usersGridView = new System.Windows.Forms.DataGridView();
            this.btnBlockUnblock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(494, 439);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(170, 57);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Cadastrar Usuário";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // usersGridView
            // 
            this.usersGridView.AllowUserToAddRows = false;
            this.usersGridView.AllowUserToDeleteRows = false;
            this.usersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersGridView.Location = new System.Drawing.Point(0, 12);
            this.usersGridView.Name = "usersGridView";
            this.usersGridView.ReadOnly = true;
            this.usersGridView.Size = new System.Drawing.Size(682, 421);
            this.usersGridView.TabIndex = 7;
            this.usersGridView.RowContextMenuStripChanged += new System.Windows.Forms.DataGridViewRowEventHandler(this.usersGridView_RowContextMenuStripChanged);
            this.usersGridView.SelectionChanged += new System.EventHandler(this.usersGridView_SelectionChanged);
            // 
            // btnBlockUnblock
            // 
            this.btnBlockUnblock.Location = new System.Drawing.Point(365, 439);
            this.btnBlockUnblock.Name = "btnBlockUnblock";
            this.btnBlockUnblock.Size = new System.Drawing.Size(102, 57);
            this.btnBlockUnblock.TabIndex = 8;
            this.btnBlockUnblock.Text = "Selecione um usuário";
            this.btnBlockUnblock.UseVisualStyleBackColor = true;
            // 
            // FormListUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 508);
            this.Controls.Add(this.btnBlockUnblock);
            this.Controls.Add(this.usersGridView);
            this.Controls.Add(this.btnRegister);
            this.Name = "FormListUsers";
            this.Text = "Lista de usuários";
            ((System.ComponentModel.ISupportInitialize)(this.usersGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.DataGridView usersGridView;
        private System.Windows.Forms.Button btnBlockUnblock;
    }
}