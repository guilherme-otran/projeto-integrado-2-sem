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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDate));
            this.rdbAge = new System.Windows.Forms.RadioButton();
            this.rdbInterval = new System.Windows.Forms.RadioButton();
            this.rdbAD = new System.Windows.Forms.RadioButton();
            this.rdbAnalyze = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gboInput = new System.Windows.Forms.GroupBox();
            this.cmbDates = new System.Windows.Forms.ComboBox();
            this.ltbDatesEq = new System.Windows.Forms.ListBox();
            this.lblDay = new System.Windows.Forms.Label();
            this.txtAmtD = new System.Windows.Forms.TextBox();
            this.lblWeek = new System.Windows.Forms.Label();
            this.txtAmtW = new System.Windows.Forms.TextBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.txtAmtM = new System.Windows.Forms.TextBox();
            this.rdbDec = new System.Windows.Forms.RadioButton();
            this.lblInput2 = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbMonth2 = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.lblInput1 = new System.Windows.Forms.Label();
            this.rdbAdd = new System.Windows.Forms.RadioButton();
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtDay2 = new System.Windows.Forms.TextBox();
            this.cmbYear2 = new System.Windows.Forms.ComboBox();
            this.rdbDateCulture = new System.Windows.Forms.RadioButton();
            this.gboInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbAge
            // 
            this.rdbAge.AutoSize = true;
            this.rdbAge.Checked = true;
            this.rdbAge.Location = new System.Drawing.Point(17, 66);
            this.rdbAge.Name = "rdbAge";
            this.rdbAge.Size = new System.Drawing.Size(52, 17);
            this.rdbAge.TabIndex = 4;
            this.rdbAge.TabStop = true;
            this.rdbAge.Text = "Idade";
            this.rdbAge.UseVisualStyleBackColor = true;
            this.rdbAge.CheckedChanged += new System.EventHandler(this.rdbAge_CheckedChanged);
            // 
            // rdbInterval
            // 
            this.rdbInterval.AutoSize = true;
            this.rdbInterval.Location = new System.Drawing.Point(79, 66);
            this.rdbInterval.Name = "rdbInterval";
            this.rdbInterval.Size = new System.Drawing.Size(110, 17);
            this.rdbInterval.TabIndex = 5;
            this.rdbInterval.Text = "Intervalo de datas";
            this.rdbInterval.UseVisualStyleBackColor = true;
            this.rdbInterval.CheckedChanged += new System.EventHandler(this.rdbInterval_CheckedChanged);
            // 
            // rdbAD
            // 
            this.rdbAD.AutoSize = true;
            this.rdbAD.Location = new System.Drawing.Point(200, 66);
            this.rdbAD.Name = "rdbAD";
            this.rdbAD.Size = new System.Drawing.Size(174, 17);
            this.rdbAD.TabIndex = 6;
            this.rdbAD.Text = "Acrescimo/Decréscimo de data";
            this.rdbAD.UseVisualStyleBackColor = true;
            this.rdbAD.CheckedChanged += new System.EventHandler(this.rdbAD_CheckedChanged);
            // 
            // rdbAnalyze
            // 
            this.rdbAnalyze.AutoSize = true;
            this.rdbAnalyze.Location = new System.Drawing.Point(384, 66);
            this.rdbAnalyze.Name = "rdbAnalyze";
            this.rdbAnalyze.Size = new System.Drawing.Size(100, 17);
            this.rdbAnalyze.TabIndex = 7;
            this.rdbAnalyze.Text = "Análise de Data";
            this.rdbAnalyze.UseVisualStyleBackColor = true;
            this.rdbAnalyze.CheckedChanged += new System.EventHandler(this.rdbAnalyze_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(148, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Escolha uma opção de cálculo de datas";
            // 
            // gboInput
            // 
            this.gboInput.Controls.Add(this.cmbDates);
            this.gboInput.Controls.Add(this.ltbDatesEq);
            this.gboInput.Controls.Add(this.lblDay);
            this.gboInput.Controls.Add(this.txtAmtD);
            this.gboInput.Controls.Add(this.lblWeek);
            this.gboInput.Controls.Add(this.txtAmtW);
            this.gboInput.Controls.Add(this.lblMonth);
            this.gboInput.Controls.Add(this.txtAmtM);
            this.gboInput.Controls.Add(this.rdbDec);
            this.gboInput.Controls.Add(this.lblInput2);
            this.gboInput.Controls.Add(this.btnProcess);
            this.gboInput.Controls.Add(this.txtDay);
            this.gboInput.Controls.Add(this.cmbYear);
            this.gboInput.Controls.Add(this.cmbMonth2);
            this.gboInput.Controls.Add(this.cmbMonth);
            this.gboInput.Controls.Add(this.lblInput1);
            this.gboInput.Controls.Add(this.rdbAdd);
            this.gboInput.Location = new System.Drawing.Point(74, 113);
            this.gboInput.Name = "gboInput";
            this.gboInput.Size = new System.Drawing.Size(480, 110);
            this.gboInput.TabIndex = 8;
            this.gboInput.TabStop = false;
            // 
            // cmbDates
            // 
            this.cmbDates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDates.FormattingEnabled = true;
            this.cmbDates.Items.AddRange(new object[] {
            "01 de Janeiro de 1991",
            "17 de Setembro de 1997",
            "04 de Setembro de 1998",
            "23 de Outubro de 2001",
            "09 de Janeiro de 2007",
            "09 de Maio de 2011",
            "07 de Janeiro de 2019",
            ""});
            this.cmbDates.Location = new System.Drawing.Point(135, 50);
            this.cmbDates.Name = "cmbDates";
            this.cmbDates.Size = new System.Drawing.Size(211, 21);
            this.cmbDates.TabIndex = 14;
            this.cmbDates.Visible = false;
            this.cmbDates.SelectedIndexChanged += new System.EventHandler(this.cmbDates_SelectedIndexChanged);
            // 
            // ltbDatesEq
            // 
            this.ltbDatesEq.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltbDatesEq.FormattingEnabled = true;
            this.ltbDatesEq.ItemHeight = 16;
            this.ltbDatesEq.Location = new System.Drawing.Point(31, 88);
            this.ltbDatesEq.Name = "ltbDatesEq";
            this.ltbDatesEq.Size = new System.Drawing.Size(430, 68);
            this.ltbDatesEq.TabIndex = 15;
            this.ltbDatesEq.Visible = false;
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(304, 116);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(26, 13);
            this.lblDay.TabIndex = 13;
            this.lblDay.Text = "dias";
            this.lblDay.Visible = false;
            // 
            // txtAmtD
            // 
            this.txtAmtD.Location = new System.Drawing.Point(246, 111);
            this.txtAmtD.Name = "txtAmtD";
            this.txtAmtD.Size = new System.Drawing.Size(55, 20);
            this.txtAmtD.TabIndex = 12;
            this.txtAmtD.Visible = false;
            this.txtAmtD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dates_KeyPress);
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Location = new System.Drawing.Point(193, 116);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(49, 13);
            this.lblWeek.TabIndex = 11;
            this.lblWeek.Text = "semanas";
            this.lblWeek.Visible = false;
            // 
            // txtAmtW
            // 
            this.txtAmtW.Location = new System.Drawing.Point(135, 111);
            this.txtAmtW.Name = "txtAmtW";
            this.txtAmtW.Size = new System.Drawing.Size(55, 20);
            this.txtAmtW.TabIndex = 10;
            this.txtAmtW.Visible = false;
            this.txtAmtW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dates_KeyPress);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(89, 114);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(37, 13);
            this.lblMonth.TabIndex = 9;
            this.lblMonth.Text = "meses";
            this.lblMonth.Visible = false;
            // 
            // txtAmtM
            // 
            this.txtAmtM.Location = new System.Drawing.Point(31, 109);
            this.txtAmtM.Name = "txtAmtM";
            this.txtAmtM.Size = new System.Drawing.Size(55, 20);
            this.txtAmtM.TabIndex = 8;
            this.txtAmtM.Visible = false;
            this.txtAmtM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dates_KeyPress);
            // 
            // rdbDec
            // 
            this.rdbDec.AutoSize = true;
            this.rdbDec.Location = new System.Drawing.Point(349, 95);
            this.rdbDec.Name = "rdbDec";
            this.rdbDec.Size = new System.Drawing.Size(62, 17);
            this.rdbDec.TabIndex = 7;
            this.rdbDec.Text = "Diminuir";
            this.rdbDec.UseVisualStyleBackColor = true;
            this.rdbDec.Visible = false;
            // 
            // lblInput2
            // 
            this.lblInput2.AutoSize = true;
            this.lblInput2.Location = new System.Drawing.Point(15, 91);
            this.lblInput2.Name = "lblInput2";
            this.lblInput2.Size = new System.Drawing.Size(0, 13);
            this.lblInput2.TabIndex = 4;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(335, 57);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Processar";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(31, 60);
            this.txtDay.MaxLength = 2;
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(57, 20);
            this.txtDay.TabIndex = 0;
            this.txtDay.TextChanged += new System.EventHandler(this.txtDay_TextChanged);
            this.txtDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dates_KeyPress);
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Items.AddRange(new object[] {
            "{ 1900 , ..., 2015}"});
            this.cmbYear.Location = new System.Drawing.Point(239, 59);
            this.cmbYear.MaxLength = 4;
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(66, 21);
            this.cmbYear.TabIndex = 2;
            this.cmbYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dates_KeyPress);
            // 
            // cmbMonth2
            // 
            this.cmbMonth2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth2.FormattingEnabled = true;
            this.cmbMonth2.Items.AddRange(new object[] {
            "Janeiro",
            "Fevereiro",
            "Março",
            "Abril",
            "Maio",
            "Junho",
            "Julho",
            "Agosto",
            "Setembro",
            "Outubro",
            "Novembro",
            "Dezembro"});
            this.cmbMonth2.Location = new System.Drawing.Point(103, 109);
            this.cmbMonth2.Name = "cmbMonth2";
            this.cmbMonth2.Size = new System.Drawing.Size(121, 21);
            this.cmbMonth2.TabIndex = 5;
            this.cmbMonth2.Visible = false;
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "Janeiro",
            "Fevereiro",
            "Março",
            "Abril",
            "Maio",
            "Junho",
            "Julho",
            "Agosto",
            "Setembro",
            "Outubro",
            "Novembro",
            "Dezembro"});
            this.cmbMonth.Location = new System.Drawing.Point(103, 59);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(121, 21);
            this.cmbMonth.TabIndex = 1;
            // 
            // lblInput1
            // 
            this.lblInput1.AutoSize = true;
            this.lblInput1.Location = new System.Drawing.Point(15, 28);
            this.lblInput1.Name = "lblInput1";
            this.lblInput1.Size = new System.Drawing.Size(0, 13);
            this.lblInput1.TabIndex = 0;
            // 
            // rdbAdd
            // 
            this.rdbAdd.AutoSize = true;
            this.rdbAdd.Checked = true;
            this.rdbAdd.Location = new System.Drawing.Point(349, 72);
            this.rdbAdd.Name = "rdbAdd";
            this.rdbAdd.Size = new System.Drawing.Size(82, 17);
            this.rdbAdd.TabIndex = 6;
            this.rdbAdd.TabStop = true;
            this.rdbAdd.Text = "Acrescentar";
            this.rdbAdd.UseVisualStyleBackColor = true;
            this.rdbAdd.Visible = false;
            this.rdbAdd.CheckedChanged += new System.EventHandler(this.rdbAdd_CheckedChanged);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutput.Location = new System.Drawing.Point(252, 245);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(0, 20);
            this.lblOutput.TabIndex = 6;
            // 
            // txtDay2
            // 
            this.txtDay2.Location = new System.Drawing.Point(107, 223);
            this.txtDay2.MaxLength = 2;
            this.txtDay2.Name = "txtDay2";
            this.txtDay2.Size = new System.Drawing.Size(57, 20);
            this.txtDay2.TabIndex = 4;
            this.txtDay2.Visible = false;
            this.txtDay2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dates_KeyPress);
            // 
            // cmbYear2
            // 
            this.cmbYear2.FormattingEnabled = true;
            this.cmbYear2.Items.AddRange(new object[] {
            "{ 1900 , ..., 2015}"});
            this.cmbYear2.Location = new System.Drawing.Point(315, 222);
            this.cmbYear2.MaxLength = 4;
            this.cmbYear2.Name = "cmbYear2";
            this.cmbYear2.Size = new System.Drawing.Size(66, 21);
            this.cmbYear2.TabIndex = 6;
            this.cmbYear2.Visible = false;
            this.cmbYear2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dates_KeyPress);
            // 
            // rdbDateCulture
            // 
            this.rdbDateCulture.AutoSize = true;
            this.rdbDateCulture.Location = new System.Drawing.Point(496, 66);
            this.rdbDateCulture.Name = "rdbDateCulture";
            this.rdbDateCulture.Size = new System.Drawing.Size(116, 17);
            this.rdbDateCulture.TabIndex = 9;
            this.rdbDateCulture.Text = "Datas equivalentes";
            this.rdbDateCulture.UseVisualStyleBackColor = true;
            this.rdbDateCulture.CheckedChanged += new System.EventHandler(this.rdbDateCulture_CheckedChanged);
            // 
            // FormDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 446);
            this.Controls.Add(this.rdbDateCulture);
            this.Controls.Add(this.txtDay2);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.cmbYear2);
            this.Controls.Add(this.gboInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdbAnalyze);
            this.Controls.Add(this.rdbAD);
            this.Controls.Add(this.rdbInterval);
            this.Controls.Add(this.rdbAge);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calculadora de Datas";
            this.Load += new System.EventHandler(this.FormDate_Load);
            this.gboInput.ResumeLayout(false);
            this.gboInput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbAge;
        private System.Windows.Forms.RadioButton rdbInterval;
        private System.Windows.Forms.RadioButton rdbAD;
        private System.Windows.Forms.RadioButton rdbAnalyze;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gboInput;
        private System.Windows.Forms.Label lblInput1;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtDay2;
        private System.Windows.Forms.ComboBox cmbYear2;
        private System.Windows.Forms.ComboBox cmbMonth2;
        private System.Windows.Forms.Label lblInput2;
        private System.Windows.Forms.RadioButton rdbDec;
        private System.Windows.Forms.RadioButton rdbAdd;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.TextBox txtAmtD;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.TextBox txtAmtW;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.TextBox txtAmtM;
        private System.Windows.Forms.RadioButton rdbDateCulture;
        private System.Windows.Forms.ComboBox cmbDates;
        private System.Windows.Forms.ListBox ltbDatesEq;
    }
}