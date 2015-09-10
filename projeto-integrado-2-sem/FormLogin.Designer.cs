namespace projeto_integrado_2_sem
{
    partial class FormLogin
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
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsi_about = new System.Windows.Forms.ToolStripMenuItem();
            this.tsi_close = new System.Windows.Forms.ToolStripMenuItem();
            this.labelInvalidCredentials = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(192, 164);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(168, 20);
            this.txt_pass.TabIndex = 1;
            this.txt_pass.TextChanged += new System.EventHandler(this.Credentials_TextChanged);
            this.txt_pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_pass_KeyPress);
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(192, 102);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(168, 20);
            this.txt_user.TabIndex = 0;
            this.txt_user.TextChanged += new System.EventHandler(this.Credentials_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(192, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(192, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Senha:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(234, 199);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsi_about,
            this.tsi_close});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(544, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsi_about
            // 
            this.tsi_about.Name = "tsi_about";
            this.tsi_about.Size = new System.Drawing.Size(47, 20);
            this.tsi_about.Text = "Sobre";
            // 
            // tsi_close
            // 
            this.tsi_close.Name = "tsi_close";
            this.tsi_close.Size = new System.Drawing.Size(37, 20);
            this.tsi_close.Text = "Sair";
            this.tsi_close.Click += new System.EventHandler(this.tsi_close_Click);
            // 
            // labelInvalidCredentials
            // 
            this.labelInvalidCredentials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelInvalidCredentials.ForeColor = System.Drawing.Color.Red;
            this.labelInvalidCredentials.Location = new System.Drawing.Point(12, 37);
            this.labelInvalidCredentials.Name = "labelInvalidCredentials";
            this.labelInvalidCredentials.Size = new System.Drawing.Size(520, 32);
            this.labelInvalidCredentials.TabIndex = 4;
            this.labelInvalidCredentials.Text = "E-mail ou Senha incorreto(s)!";
            this.labelInvalidCredentials.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelInvalidCredentials.Visible = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 333);
            this.Controls.Add(this.labelInvalidCredentials);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormLogin";
            this.Text = "Projeto Integrado";
            this.TextChanged += new System.EventHandler(this.Credentials_TextChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsi_about;
        private System.Windows.Forms.ToolStripMenuItem tsi_close;
        private System.Windows.Forms.Label labelInvalidCredentials;
    }
}

