using projeto_integrado_2_sem.Interactors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace projeto_integrado_2_sem
{
    public partial class FormDate : Form
    {
        public FormDate()
        {
            InitializeComponent();
        }

        private void FormDate_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = Enumerable.Range(1950, ((DateTime.Today.Year)-1949)).ToList();
            cmbYear2.DataSource = Enumerable.Range(1950, ((DateTime.Today.Year) - 1949)).ToList();
        }

        private bool validateDate(int day, int month, int year) // Função para validar a data
        {
            int lastDay = DateTime.DaysInMonth(year, month); // obtem o último dia do mês, ou seja, quantos dias têm o mês.

            if (day <= lastDay)
                return true;
            else
                return false;
        }

        private void clearAndInvisible()
        {
            txtDay.Visible = false;
            txtDay2.Visible = false;
            cmbMonth.Visible = false;
            cmbMonth2.Visible = false;
            cmbYear.Visible = false;
            cmbYear2.Visible = false;
            rdbAdd.Visible = false;
            rdbDec.Visible = false;
            txtAmtD.Visible = false;
            txtAmtM.Visible = false;
            txtAmtW.Visible = false;
            lblMonth.Visible = false;
            lblWeek.Visible = false;
            lblDay.Visible = false;
            lblInput1.Text = "";
            lblInput2.Text = "";
            lblOutput.Text = "";
        }

        private void messageLabel2()
        {
            if (rdbAdd.Checked)
                lblInput2.Text = "Digite o tempo a ser acrescentado";
            else
                lblInput2.Text = "Digite o tempo a ser diminuido";
        }

        private string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        private void rdbAge_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAge.Checked)
            {
                gboInput.Size = new Size(480, 110);
                lblOutput.Location = new Point(224, 245);
                btnProcess.Location = new Point(335, 57);
                gboInput.Text = "Calcular idade";
                lblInput1.Text = "Digite sua data de nascimento:";
                txtDay.Visible = true;
                cmbMonth.Visible = true;
                cmbYear.Visible = true;
            }
            else
            {
                clearAndInvisible();
            }
        }

        private void rdbInterval_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbInterval.Checked)
            {
                gboInput.Size = new Size(480, 180);
                btnProcess.Location = new Point(336, 80);
                lblOutput.Location = new Point(224, 295);
                gboInput.Text = "Calcular o intervalo entre duas datas";
                lblInput1.Text = "Digite a primeira data: ";
                txtDay.Visible = true;
                cmbMonth.Visible = true;
                cmbYear.Visible = true;
                lblInput2.Text = "Digite a segunda data: ";
                txtDay2.Visible = true;
                cmbMonth2.Visible = true;
                cmbYear2.Visible = true;
            }
            else
            {
                clearAndInvisible();
            }
        }

        private void rdbAdd_CheckedChanged(object sender, EventArgs e)
        {
            messageLabel2();
        }

        private void rdbAD_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbAD.Checked)
            {
                gboInput.Size = new Size(480, 180);
                btnProcess.Location = new Point(203, 150);
                lblOutput.Location = new Point(224, 295);
                rdbAdd.Visible = true;
                rdbDec.Visible = true;
                lblInput1.Text = "Digite a data inicial";
                messageLabel2();
                txtDay.Visible = true;
                cmbMonth.Visible = true;
                cmbYear.Visible = true;
                txtAmtD.Visible = true;
                txtAmtM.Visible = true;
                txtAmtW.Visible = true;
                lblMonth.Visible = true;
                lblWeek.Visible = true;
                lblDay.Visible = true;
            }
            else
            {
                clearAndInvisible();
            }
        }

        private void rdbAnalyze_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAnalyze.Checked)
            {
                gboInput.Size = new Size(480, 110);
                lblOutput.Location = new Point(224, 245);
                btnProcess.Location = new Point(335, 57);
                gboInput.Text = "Análisar uma data";
                lblInput1.Text = "Digite a data a ser análisada";
                txtDay.Visible = true;
                cmbMonth.Visible = true;
                cmbYear.Visible = true;
            }
            else
                clearAndInvisible();
        }

        private void dates_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)||char.IsControl(e.KeyChar)))
                e.KeyChar = char.MinValue;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (rdbAge.Checked)
            {
                try
                {
                    if (validateDate(int.Parse(txtDay.Text), cmbMonth.SelectedIndex + 1, int.Parse(cmbYear.Text)))
                    {
                        DateTime birthDate = new DateTime(int.Parse(cmbYear.Text), cmbMonth.SelectedIndex + 1, int.Parse(txtDay.Text));

                        MessageBox.Show("data " + birthDate);

                        TimeSpan age = DateCalculator.ageCalc(birthDate);

                        lblOutput.Text = "Sua Idade é:\n";
                        lblOutput.Text += "\nEm anos: " + ((int)((age.Days) / 365.25));
                        lblOutput.Text += "\nEm meses: " + ((int)(((age.Days) / 365.25) * 12));
                        lblOutput.Text += "\nEm dias: " + age.Days;
                        lblOutput.Text += "\nEm horas: " + age.TotalHours;
                    }
                    else
                    {
                        txtDay.Text = "";
                        MessageBox.Show("Data inválida");
                    }
                }
                catch
                {
                    txtDay.Text = "";
                    MessageBox.Show("Preencha todos os campos com valores corretos!");
                }

            }

            if(rdbInterval.Checked)
            {
                try
                {
                    if (validateDate(int.Parse(txtDay.Text), cmbMonth.SelectedIndex + 1, int.Parse(cmbYear.Text)) && validateDate(int.Parse(txtDay2.Text), cmbMonth2.SelectedIndex + 1, int.Parse(cmbYear2.Text)))
                    {
                        DateTime date1 = new DateTime(int.Parse(cmbYear.Text), cmbMonth.SelectedIndex + 1, int.Parse(txtDay.Text));
                        DateTime date2 = new DateTime(int.Parse(cmbYear2.Text), cmbMonth2.SelectedIndex + 1, int.Parse(txtDay2.Text));

                        TimeSpan interval = DateCalculator.timeInterval(date1, date2);

                        lblOutput.Text = "O intervalo é:\n";
                        lblOutput.Text += "\nEm anos: " + ((int)((interval.Days) / 365.25));
                        lblOutput.Text += "\nEm meses: " + ((int)(((interval.Days) / 365.25) * 12));
                        lblOutput.Text += "\nEm dias: " + interval.Days;
                        lblOutput.Text += "\nEm horas: " + interval.TotalHours;
                    }
                    else
                    {
                        txtDay.Text = "";
                        txtDay2.Text = "";
                        MessageBox.Show("Data inválida");
                    }
                }
                catch
                {
                    txtDay.Text = "";
                    MessageBox.Show("Preencha todos os campos com valores corretos!");
                }
            }

            if(rdbAD.Checked)
            {
                try
                {
                    if (validateDate(int.Parse(txtDay.Text), cmbMonth.SelectedIndex + 1, int.Parse(cmbYear.Text)))
                    {
                        DateTime initialTime = new DateTime(int.Parse(cmbYear.Text), cmbMonth.SelectedIndex + 1, int.Parse(txtDay.Text));
                        TimeSpan interval = new TimeSpan((int.Parse(txtAmtM.Text)) * 30 + (int.Parse(txtAmtW.Text)) * 7 + (int.Parse(txtAmtD.Text)), 0, 0,0,0);

                        DateTime dateResult;
                        if (rdbAdd.Checked)
                            dateResult = DateCalculator.dateIncrease(initialTime, interval);
                        else
                            dateResult = DateCalculator.dateDecrease(initialTime, interval);

                        lblOutput.Text = "Data: " + dateResult.ToString("dd/MM/yyyy"); 
                    }
                    else
                        MessageBox.Show("Data inválida");
                }
                catch
                {
                    MessageBox.Show("Preencha todos os campos com valores corretos!");
                }
            }

            if(rdbAnalyze.Checked)
            {
                try 
                {
                   if (validateDate(int.Parse(txtDay.Text), cmbMonth.SelectedIndex + 1, int.Parse(cmbYear.Text)))
                    {
                        var brazilian = new System.Globalization.CultureInfo("pt-br");
                        DateTime date = new DateTime(int.Parse(cmbYear.Text), cmbMonth.SelectedIndex + 1, int.Parse(txtDay.Text));
                        lblOutput.Text = UppercaseFirst(brazilian.DateTimeFormat.GetDayName(date.DayOfWeek));
                        lblOutput.Text += ", " + date.Day + " de " + brazilian.DateTimeFormat.GetMonthName(date.Month);
                        lblOutput.Text += " de " + date.Year;

                        lblOutput.Text += "\nDia Juliano: " + DateCalculator.julianDay(date.Day, date.Month, date.Year);
                        //lblOutput.Text += "\nData informada não possuí um dia juliano equivalente"; 

                        //lblOutput.Text += "\nDia sequêncial do ano: " + 
                        if (DateCalculator.bissextile(date.Year))
                            lblOutput.Text += "\nAno bissexto";
                        else
                            lblOutput.Text += "\nAno não é bissexto";
                    }
                    else
                        MessageBox.Show("Data inválida");
                }
                catch
                {
                    MessageBox.Show("Preencha todos os campos com valores corretos!");
                }
            }
        }
    }
}
