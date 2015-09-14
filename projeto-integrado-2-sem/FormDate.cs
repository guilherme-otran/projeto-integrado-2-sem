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
        private bool validateDate(int day, int month, int year)
        {
            int lastDay = DateTime.DaysInMonth(year, month); // obtem o último dia do mês, ou seja, quantos dias têm o mês.

            if (day <= lastDay)
                return true;
            else
                return false;
        }
        public FormDate()
        {
            InitializeComponent();
        }

        private void FormDate_Load(object sender, EventArgs e)
        {
            rdbAge.Checked = true;
            cmbYear.DataSource = Enumerable.Range(1900, ((DateTime.Today.Year)-1900)).ToList();
        }

        private void rdbAge_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAge.Checked)
            {
                gboInput.Text = "Calcular Idade";
            }
        }

        private void txtDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)))
                e.KeyChar = char.MinValue;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (validateDate(int.Parse(txtDay.Text), cmbMonth.SelectedIndex, int.Parse(cmbYear.Text)))
            { 
                /*DateTime birthDate = new DateTime();
                 *                
                 *TimeSpan age = DateCalculator.ageCalc(birthDate);                   TimeSpan FAIL!!
                 *                                                                       C# huehue br
                 *lblOutput.Text = "Sua Idade é " + ;                   ERROR 404      TimeSpan.Year not found. 
                 *                                                                          
                 */
            }

        }
    }
}
