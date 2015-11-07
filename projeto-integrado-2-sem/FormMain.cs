using projeto_integrado_2_sem.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace projeto_integrado_2_sem
{
    public partial class FormMain : Form
    {
        public bool LogoutRequested = false;

        private User CurrentUser;
        private FormDate FormDate = new FormDate();
        
        public FormMain(User CurrentUser)
        {
            InitializeComponent();
            this.CurrentUser = CurrentUser;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            btnDate.Visible = CurrentProfile().CanViewDateCalculator;
            btnRegister.Visible = CurrentProfile().CanViewRegisterUser;
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            FormDate.ShowDialog();
        }

        private Profile CurrentProfile()
        {
            return CurrentUser.Profile;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LogoutRequested = true;
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FormListUsers formListUser = new FormListUsers();
            formListUser.ShowDialog();
        }
    }
}
