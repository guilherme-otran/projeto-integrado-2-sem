using projeto_integrado_2_sem.Models;
using projeto_integrado_2_sem.Repositories;
using projeto_integrado_2_sem.Casters;
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
        private User selectedUser;


        private void atualizarButtonBlockUn()
        {
            if (usersGridView.SelectedRows.Count > 0)
            {
                selectedUser = (User)usersGridView.SelectedRows[0].DataBoundItem;
                if (selectedUser.CurrentStatus == User.Status.ACTIVE)
                {
                    btnBlockUnblock.Text = "Bloquear";
                }
                else
                {
                    btnBlockUnblock.Text = "Desbloquear usuário";
                }
            }
        }

        public FormListUsers()
        {
            InitializeComponent();
            usersGridView.DataSource = new BindingSource(repo.List(), null);
        }

        private void FormListUsers_Load(object sender, EventArgs e)
        {
            //usersGridView.Select(0,0);
            atualizarButtonBlockUn();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.ShowDialog();
            usersGridView.DataSource = new BindingSource(repo.List(), null);
            usersGridView.Select();
        }

        private void usersGridView_RowContextMenuStripChanged(object sender, DataGridViewRowEventArgs e)
        {
            selectedUser = (User)usersGridView.SelectedRows[0].DataBoundItem;
            if(selectedUser.CurrentStatus == User.Status.ACTIVE)
            {
                btnBlockUnblock.Text = "Bloquear usuário";
            }
            else
            {
                btnBlockUnblock.Text = "Desbloquear usuário";
            }
        }

        private void usersGridView_SelectionChanged(object sender, EventArgs e)
        {
            atualizarButtonBlockUn();
        }

        private void btnBlockUnblock_Click(object sender, EventArgs e)
        {
            if (btnBlockUnblock.Text == "Bloquear")
                if(selectedUser.Profile.id == Profile.AdminProfile().id)
                    MessageBox.Show("Impossível bloquear o admin");
                else
                    selectedUser.CurrentStatus = User.Status.INACTIVE;
            else
                selectedUser.CurrentStatus = User.Status.ACTIVE;

            RepositoryManager.ManagerInstance.userRepository.Persist(selectedUser);
            usersGridView.DataSource = new BindingSource(repo.List(), null);
        }
    }
}
