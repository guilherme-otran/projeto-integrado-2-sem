using projeto_integrado_2_sem.Models;
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
    public partial class FormListUsers : Form
    {
        private UserRepository repo = RepositoryManager.ManagerInstance.UserRepository();

        public FormListUsers()
        {
            InitializeComponent();
            usersGridView.DataSource = new BindingSource(repo.List(), null);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.ShowDialog();
            usersGridView.DataSource = new BindingSource(repo.List(), null);
        }
    }
}
