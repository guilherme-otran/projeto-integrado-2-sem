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
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gboInput = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.gboInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbAge
            // 
            this.rdbAge.AutoSize = true;
            this.rdbAge.Location = new System.Drawing.Point(46, 66);
            this.rdbAge.Name = "rdbAge";
            this.rdbAge.Size = new System.Drawing.Size(52, 17);
            this.rdbAge.TabIndex = 0;
            this.rdbAge.TabStop = true;
            this.rdbAge.Text = "Idade";
            this.rdbAge.UseVisualStyleBackColor = true;
            this.rdbAge.CheckedChanged += new System.EventHandler(this.rdbAge_CheckedChanged);
            // 
            // rdbInterval
            // 
            this.rdbInterval.AutoSize = true;
            this.rdbInterval.Location = new System.Drawing.Point(114, 66);
            this.rdbInterval.Name = "rdbInterval";
            this.rdbInterval.Size = new System.Drawing.Size(110, 17);
            this.rdbInterval.TabIndex = 1;
            this.rdbInterval.TabStop = true;
            this.rdbInterval.Text = "Intervalo de datas";
            this.rdbInterval.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(235, 66);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(188, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Acrescimo/Decrescimo de periodo";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(429, 66);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(100, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Análise de Data";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Escolha uma opção de cálculo de datas:";
            // 
            // gboInput
            // 
            this.gboInput.Controls.Add(this.btnProcess);
            this.gboInput.Controls.Add(this.txtDay);
            this.gboInput.Controls.Add(this.cmbYear);
            this.gboInput.Controls.Add(this.cmbMonth);
            this.gboInput.Controls.Add(this.label2);
            this.gboInput.Location = new System.Drawing.Point(48, 113);
            this.gboInput.Name = "gboInput";
            this.gboInput.Size = new System.Drawing.Size(481, 108);
            this.gboInput.TabIndex = 5;
            this.gboInput.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Insira sua data de nascimento:";
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "01 - Janeiro",
            "02 - Fevereiro",
            "03 - Março",
            "04 - Abril",
            "05 - Maio",
            "06 - Junho",
            "07 - Julho",
            "08 - Agosto",
            "09 - Setembro",
            "10 - Outubro",
            "11 - Novembro",
            "12 - Dezembro"});
            this.cmbMonth.Location = new System.Drawing.Point(103, 59);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(121, 21);
            this.cmbMonth.TabIndex = 1;
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Items.AddRange(new object[] {
            "{ 1900 , ..., 2015}"});
            this.cmbYear.Location = new System.Drawing.Point(239, 59);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(66, 21);
            this.cmbYear.TabIndex = 2;
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(31, 60);
            this.txtDay.MaxLength = 2;
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(57, 20);
            this.txtDay.TabIndex = 3;
            this.txtDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDay_KeyPress);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(335, 57);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "Processar";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(287, 253);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(0, 13);
            this.lblOutput.TabIndex = 6;
            // 
            // FormDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 398);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.gboInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.rdbInterval);
            this.Controls.Add(this.rdbAge);
            this.Name = "FormDate";
            this.Text = "FormDate";
            this.Load += new System.EventHandler(this.FormDate_Load);
            this.gboInput.ResumeLayout(false);
            this.gboInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbAge;
        private System.Windows.Forms.RadioButton rdbInterval;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gboInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblOutput;
    }
}