namespace projeto_integrado_2_sem
{
    partial class FormDate
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
            this.rdbAge = new System.Windows.Forms.RadioButton();
            this.rdbInterval = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rdbAge
            // 
            this.rdbAge.AutoSize = true;
            this.rdbAge.Location = new System.Drawing.Point(25, 43);
            this.rdbAge.Name = "rdbAge";
            this.rdbAge.Size = new System.Drawing.Size(52, 17);
            this.rdbAge.TabIndex = 0;
            this.rdbAge.TabStop = true;
            this.rdbAge.Text = "Idade";
            this.rdbAge.UseVisualStyleBackColor = true;
            // 
            // rdbInterval
            // 
            this.rdbInterval.AutoSize = true;
            this.rdbInterval.Location = new System.Drawing.Point(116, 43);
            this.rdbInterval.Name = "rdbInterval";
            this.rdbInterval.Size = new System.Drawing.Size(110, 17);
            this.rdbInterval.TabIndex = 1;
            this.rdbInterval.TabStop = true;
            this.rdbInterval.Text = "Intervalo de datas";
            this.rdbInterval.UseVisualStyleBackColor = true;
            // 
            // FormDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.rdbInterval);
            this.Controls.Add(this.rdbAge);
            this.Name = "FormDate";
            this.Text = "FormDate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbAge;
        private System.Windows.Forms.RadioButton rdbInterval;
    }
}