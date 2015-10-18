using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using projeto_integrado_2_sem.Repositories;
using projeto_integrado_2_sem.Models;

namespace projeto_integrado_2_sem
{
    /// <summary>
    /// Interaction logic for FormRegister.xaml
    /// </summary>
    public partial class FormRegister : Window
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
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

        private void formRegister_Loaded(object sender, RoutedEventArgs e)
        {
            cmbYear.ItemsSource = Enumerable.Range(1950, ((DateTime.Today.Year) - 1949)).ToList();
        }

        //private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        //{
          //  if (!(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar)))
            //    e.KeyChar = char.MinValue;
        //}

        //private void dates_KeyPress(object sender, KeyPressEventArgs e)
        //{
         //   if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar)))
           //     e.KeyChar = char.MinValue;
        //}

        private void atualizacao_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtName.Text != "" && txtEmail.Text != "" && txtDay.Text != "" && cmbMonth.Text != "" && cmbYear.Text != "" && txtPassword.Password != "" && txtPassConfirm.Password != "")
                btnProcess.IsEnabled = true;
            else
                btnProcess.IsEnabled = false;
        }
        private void atualizacao_TextChanged(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "" && txtEmail.Text != "" && txtDay.Text != "" && cmbMonth.Text != "" && cmbYear.Text != "" && txtPassword.Password != "" && txtPassConfirm.Password != "")
                btnProcess.IsEnabled = true;
            else
                btnProcess.IsEnabled = false;
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.name = this.txtName.Text;
            user.email = this.txtEmail.Text;
            user.Profile = Profile.UserProfile();

            try
            {
                if (!(validateDates(int.Parse(txtDay.Text), cmbMonth.SelectedIndex + 1, int.Parse(cmbYear.Text))))
                {
                    MessageBox.Show("Data de nascimento inválida");
                    txtDay.Text = "";
                    cmbMonth.SelectedIndex = 0;
                    cmbYear.SelectedIndex = 0;
                }
                else
                {
                    user.birthDate = new DateTime(int.Parse(cmbYear.Text), cmbMonth.SelectedIndex + 1, int.Parse(txtDay.Text));

                    if (!(String.Compare(txtPassword.Password, txtPassConfirm.Password) == 0))
                    {
                        MessageBox.Show("As senhas digitadas não são iguais");
                        txtPassword.Password = "";
                        txtPassConfirm.Password = "";
                    }
                    else
                    {
                        user.password = this.txtPassword.Password;

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
                MessageBox.Show("Preencha os dados corretamente!");
            }
        }
    }
}
