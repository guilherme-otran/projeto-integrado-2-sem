using projeto_integrado_2_sem.Interactors;
using projeto_integrado_2_sem.Models;
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
    public partial class FormLogin : Form
    {
        public User LoggedUser;

        public FormLogin()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string email = this.txt_user.Text;
            string password = this.txt_pass.Text;

            LoginInteractor login = new LoginInteractor(email, password);

            try
            {
                this.LoggedUser = login.performCheck();
                labelInvalidCredentials.Hide();
                this.DialogResult = DialogResult.OK;
                this.Close();
            } 
            catch (LoginInteractor.InavlidUsernameOrPassword)
            {
                labelInvalidCredentials.Show();
            }
            
        }

        private void tsi_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Credentials_TextChanged(object sender, EventArgs e)
        {
            labelInvalidCredentials.Hide();
        }

        private void txt_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                btn_login.PerformClick();
        }
    }
}
