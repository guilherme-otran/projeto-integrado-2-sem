using projeto_integrado_2_sem.Repositories;
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
    public partial class ConsultUser : Form
    {
        private UserRepository userRepo = RepositoryManager.ManagerInstance.UserRepository();
        public ConsultUser()
        {
            InitializeComponent();
        }

        private void btnConsult_Click(object sender, EventArgs e)
        {
            var user = userRepo.findById(txtConsultId.Text);
            if (user == null)
            {
                MessageBox.Show("Usuário não encontrado");
                txtConsultId.Clear();
                return;
            }

            if (user.Name != null)
                txtName.Text = user.Name;

            txtEmail.Text = user.Email;
            txtProfile.Text = user.ProfileName;

            if (user.passwordChangeDate != DateTime.MinValue)
                txtPassChange.Text = user.passwordChangeDate.ToShortDateString();

            if (user.BirthDate != DateTime.MinValue)
                txtBirthDate.Text = user.BirthDate.ToShortDateString();
        }

        private void txtConsultId_TextChanged(object sender, EventArgs e)
        {
            txtName.Clear();
            txtEmail.Clear();
            txtProfile.Clear();
            txtPassChange.Clear();
            txtBirthDate.Clear();
        }

        private void txtConsultId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                btnConsult_Click(sender, e);
        }
    }
}
