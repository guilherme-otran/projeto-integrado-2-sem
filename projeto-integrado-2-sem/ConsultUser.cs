using projeto_integrado_2_sem.Casters;
using projeto_integrado_2_sem.ErrorPresenters;
using projeto_integrado_2_sem.Interactors;
using projeto_integrado_2_sem.Models;
using projeto_integrado_2_sem.Repositories;
using projeto_integrado_2_sem.Validators;
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

        UserCaster userCaster = new UserCaster();
        UserValidator userValidator = new UserValidator();
        GenericPersister<User> persister;
        List<GenericErrorPresenter> errorPresenters = new List<GenericErrorPresenter>();

        public ConsultUser()
        {
            InitializeComponent();
            userRepo = RepositoryManager.ManagerInstance.UserRepository();
            persister = new GenericPersister<User>(userRepo, new Validator<User>[] { userValidator }, userCaster);
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

            userCaster.SetModel(user);
            enableEdit();
        }

        private void txtConsultId_TextChanged(object sender, EventArgs e)
        {
            txtName.Clear();
            txtEmail.Clear();
            txtProfile.Clear();
            txtPassChange.Clear();
            txtBirthDate.Clear();
            blockEdit();
        }

        private void txtConsultId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                btnConsult_Click(sender, e);
        }

        private void enableEdit()
        {
            this.txtName.ReadOnly = false;
            this.txtBirthDate.ReadOnly = false;
            this.btnChange.Enabled = true;
        }

        private void blockEdit()
        {
            this.txtName.ReadOnly = true;
            this.txtBirthDate.ReadOnly = true;
            this.btnChange.Enabled = false;
        }

        private void ConsultUser_Load(object sender, EventArgs e)
        {
            errorPresenters.Add(new GenericErrorPresenter(txtName, this, "name"));
            errorPresenters.Add(new GenericErrorPresenter(txtBirthDate, this, "birthDate"));
        }

        private void ReloadData()
        {
            userCaster.Reset();
            userCaster.setName(txtName.Text);
            userCaster.setBirthDate(txtBirthDate.Text);
        }

        private void displayValidationErrors()
        {
            var castErrors = (MultipleAttributeValidationResult)persister.CasterErrors();
            var userErrors = (MultipleAttributeValidationResult)persister.ValidatorErrors(userValidator);
            var results = new MultipleAttributeValidationResult[] { castErrors, userErrors };

            foreach (var presenter in errorPresenters)
                presenter.displayMesssages(results);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ReloadData();
            displayValidationErrors();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (persister.Persist())
            {
                MessageBox.Show("Usuário alterado!");
                this.Close();
            }
            else
            {
                displayValidationErrors();
            }
        }
    }
}
