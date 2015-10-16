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
using projeto_integrado_2_sem.Models;

namespace projeto_integrado_2_sem
{
    /// <summary>
    /// Interaction logic for FormMain.xaml
    /// </summary>
    public partial class FormMain : Window
    {
            private User currentUser;
            //private FormDate FormDate = new FormDate();

            public FormMain(User CurrentUser)
            {
                InitializeComponent();
                this.currentUser = CurrentUser;
            }

            private void FormMain_Loaded(object sender, RoutedEventArgs e)
            {
                //btnDate.Visible = CurrentProfile().CanViewDateCalculator;
                if (CurrentProfile().CanViewDateCalculator)  //Gambiarra apenas para funcionar, voltarei aqui quando achar um metodo de
                    btnDate.Visibility = Visibility.Visible; //bool em tipo visibility
                else
                    btnDate.Visibility = Visibility.Hidden;
            }

            private void btnDate_Click(object sender, EventArgs e)
            {
               // FormDate.ShowDialog();
            }

            private Profile CurrentProfile()
            {
                return currentUser.Profile;
            }

            private void btnLogout_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }

            private void FormMain1_Closed(object sender, EventArgs e)
            {
                FormLogin formlogin = new FormLogin();
                formlogin.LoggedUser = null;
                formlogin.ShowDialog();
            }
    }
}
