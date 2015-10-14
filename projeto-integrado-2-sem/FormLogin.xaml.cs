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
        public bool dialogLogin = false;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = this.txtEmail.Text;
            string password = this.txtPassword.Text;

            LoginInteractor login = new LoginInteractor(email, password);

            try
            {
                this.LoggedUser = login.performCheck();
                labelInvalidCredentials.Visibility = Visibility.Hidden;
                dialogLogin = true;
                this.Close();
            } 
            catch (LoginInteractor.InavlidUsernameOrPassword)
            {
                labelInvalidCredentials.Visibility = Visibility.Visible;
            }
        }

        private void tsi_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Credentials_TextChanged(object sender, EventArgs e)
        {
            labelInvalidCredentials.Visibility = Visibility.Hidden;
        }

       // private void txt_pass_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //}

        private void lblRegister_Click(object sender, EventArgs e)
        {
            FormRegister FormRegister = new FormRegister();
            FormRegister.ShowDialog();
        }

        private void txtPassword_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.GetHashCode() == '\r')
                btnLogin.PerformClick();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
