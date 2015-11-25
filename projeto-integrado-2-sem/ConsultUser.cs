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
        User currentUser;

        public ConsultUser(string userId)
        {
            InitializeComponent();
            userRepo = RepositoryManager.ManagerInstance.UserRepository();
            this.currentUser = userRepo.findById(userId);
            persister = new GenericPersister<User>(userRepo, new Validator<User>[] { userValidator }, userCaster);
            userCaster.SetModel(currentUser);
        }

        private void ConsultUser_Load(object sender, EventArgs e)
        {
            errorPresenters.Add(new GenericErrorPresenter(txtName, this, "name"));
            errorPresenters.Add(new GenericErrorPresenter(new Control[] { txtDay, cmbMonth, cmbYear }, this, "birthDate"));

            txtConsultId.Text = currentUser.Id;
            if (currentUser.Name != null)
                txtName.Text = currentUser.Name;

            txtEmail.Text = currentUser.Email;
            txtProfile.Text = currentUser.ProfileName;

            if (currentUser.PasswordChangeDate != DateTime.MinValue)
                txtPassChange.Text = currentUser.PasswordChangeDate.ToShortDateString();

            //cmbYear.DataSource = Enumerable.Range(1950, ((DateTime.Today.Year) - 1949)).ToList();

            if (currentUser.BirthDate != DateTime.MinValue)
            {
                txtDay.Text = currentUser.BirthDate.Day.ToString();
                cmbMonth.SelectedIndex = currentUser.BirthDate.Month - 1;
                cmbYear.Text = currentUser.BirthDate.Year.ToString();
            }
        }

        private void ReloadData()
        {
            userCaster.Reset();
            userCaster.setName(txtName.Text);
            userCaster.setBirthDate(txtDay.Text + "/" + (cmbMonth.SelectedIndex + 1).ToString() + "/" + cmbYear.Text);
        }

        private void displayValidationErrors()
        {
            var castErrors = (MultipleAttributeValidationResult)persister.CasterErrors();
            var userErrors = (MultipleAttributeValidationResult)persister.ValidatorErrors(userValidator);
            var results = new MultipleAttributeValidationResult[] { castErrors, userErrors };

            foreach (var presenter in errorPresenters)
                presenter.displayMesssages(results);
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

        private void update_TextChanged(object sender, EventArgs e)
        {
            ReloadData();
            displayValidationErrors();
        }
    }
}
