using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto_integrado_2_sem.Repositories;
using projeto_integrado_2_sem.Models;
using projeto_integrado_2_sem.Interactors;

namespace projeto_integrado_2_sem
{
    public partial class FormRegister : Form
    {
        RegisterUser registerUser = new RegisterUser();
        
        private bool validateDates(int day, int month, int year)
        {
            try
            {
                DateTime date = new DateTime(year, month, day);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public FormRegister()
        {
            InitializeComponent();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = Enumerable.Range(1950, ((DateTime.Today.Year) - 1949)).ToList();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.KeyChar = char.MinValue;
        }

        private void dates_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.KeyChar = char.MinValue;
        }

        private void atualizacao_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtEmail.Text != "" && txtDay.Text != "" && cmbMonth.Text != "" && cmbYear.Text != "" && txtPassword.Text != "" && txtPassConfirm.Text != "")
                btnProcess.Enabled = true;
            else
                btnProcess.Enabled = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                user.name = this.txtName.Text;
                user.email = this.txtEmail.Text;
                user.Profile = Profile.UserProfile();

                if (!(validateDates(int.Parse(txtDay.Text), cmbMonth.SelectedIndex + 1, int.Parse(cmbYear.Text))))
                {
                    MessageBox.Show("Data de nascimento inválida");
                    txtDay.Text = "";
                    cmbMonth.Text = "";
                    cmbYear.Text = "";
                }
                else
                {
                    user.birthDate = new DateTime(int.Parse(cmbYear.Text), cmbMonth.SelectedIndex + 1, int.Parse(txtDay.Text));

                    if (!(String.Compare(txtPassword.Text, txtPassConfirm.Text) == 0))
                    {
                        MessageBox.Show("As senhas digitadas não são iguais");
                        txtPassword.Text = "";
                        txtPassConfirm.Text = "";
                    }
                    else
                    {
                        user.password = this.txtPassword.Text;

                        registerUser.setOneUser(user); //registra o usuário no txt

                        // Faz o login após o usuario se cadastrar

                        FormMain formMain = new FormMain(user);
                        formMain.ShowDialog();
                        this.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Digite os valores corretamente!");
            }
        }
    }
}
