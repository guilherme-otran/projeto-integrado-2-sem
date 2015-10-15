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
using projeto_integrado_2_sem.Interactors;
using projeto_integrado_2_sem.Models;

namespace System.Windows.Controls
{
    public static class MyExt
    {
        public static void PerformClick(this Button btn)
        {
            btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }
    }
}

namespace projeto_integrado_2_sem
{
    /// <summary>
    /// Interaction logic for FormLogin.xaml
    /// </summary>
    public partial class FormLogin : Window
    {

        public User LoggedUser;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin1_Loaded(object sender, RoutedEventArgs e)
        {
            this.KeyDown += new KeyEventHandler(txtPassword_KeyDown);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = this.txtEmail.Text;
            string password = this.txtPassword.Password;

            LoginInteractor login = new LoginInteractor(email, password);

            try
            {
                this.LoggedUser = login.performCheck();
                labelInvalidCredentials.Visibility = Visibility.Hidden;
                this.Close();
            } 
            catch (LoginInteractor.InavlidUsernameOrPassword)
            {
                labelInvalidCredentials.Visibility = Visibility.Visible;
            }
        }

        private void Credentials_TextChanged(object sender, EventArgs e)
        {
            labelInvalidCredentials.Visibility = Visibility.Hidden;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnLogin.PerformClick();
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            FormRegister FormRegister = new FormRegister();
            FormRegister.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void texts_TextChanged(object sender, TextChangedEventArgs e)
        {
            labelInvalidCredentials.Visibility = Visibility.Hidden;
        }

    }
}
