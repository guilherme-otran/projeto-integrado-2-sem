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

        private void rdbAge_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAge.Checked)
            {
                gboInput.Size = new Size(480, 110);
                lblOutput.Location = new Point(224, 245);
                gboInput.Text = "Calcular idade";
                lblInput1.Text = "Digite sua data de nascimento:";
                btnProcess.Location = new Point(335, 57);
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
                lblInput2.Text = "Digite a segunda data: ";
                txtDay2.Visible = true;
                cmbMonth2.Visible = true;
                cmbYear2.Visible = true;
            }
            else
            {
                lblInput2.Text = "";
                txtDay2.Visible = false;
                cmbMonth2.Visible = false;
                cmbYear2.Visible = false;

            }
        }

        private void rdbAD_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbAD.Checked)
            {
                btnProcess.Location = new Point(203, 150);
                rdbAdd.Visible = true;
                rdbDec.Visible = true;
            }
            else
            {
                rdbAdd.Visible = false;
                rdbDec.Visible = false;
            }
        }

        private void dates_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)))
                e.KeyChar = char.MinValue;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (rdbAge.Checked)
            {
                lblOutput.Text = "";
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
                lblOutput.Text = "";
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
            }
        }
    }
}
