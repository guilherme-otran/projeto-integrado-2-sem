using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using projeto_integrado_2_sem.Repositories;
using projeto_integrado_2_sem.Models;
using projeto_integrado_2_sem.Interactors;
using projeto_integrado_2_sem.Validators;
using projeto_integrado_2_sem.Casters;
using projeto_integrado_2_sem.ErrorPresenters;
using System.Drawing;

namespace projeto_integrado_2_sem
{
    public partial class FormRegister : Form
    {
        UserRepository userRepo;
        UserCaster userCaster = new UserCaster();
        PasswordValidator passwordValidator = new PasswordValidator();
        UserValidator userValidator = new UserValidator();
        GenericPersister<User> persister;
        List<GenericErrorPresenter> errorPresenters = new List<GenericErrorPresenter>();
        PasswordValidationErrorPresenter passwdPresenter;

        public FormRegister()
        {
            InitializeComponent();
            userRepo = RepositoryManager.ManagerInstance.UserRepository();
            persister = new GenericPersister<User>(userRepo, new Validator<User>[] { userValidator, passwordValidator }, userCaster);
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = Enumerable.Range(1950, ((DateTime.Today.Year) - 1949)).ToList();

            errorPresenters.Add(new GenericErrorPresenter(txtEmail, this, "email"));
            errorPresenters.Add(new GenericErrorPresenter(txtName, this, "name"));
            errorPresenters.Add(new GenericErrorPresenter(txtPassConfirm, this, "passwordConfirm"));
            errorPresenters.Add(new GenericErrorPresenter(new Control[] { txtDay, cmbMonth, cmbYear }, this, "birthDate"));
            errorPresenters.Add(new GenericErrorPresenter(cmbProfile, this, "profile"));

            passwdPresenter = new PasswordValidationErrorPresenter(txtPassword, this);

            ReloadData();
        }

        private void dates_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.KeyChar = char.MinValue;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string selectedProfileId()
        {
            if (cmbProfile.SelectedIndex == 0)
                return Profile.Operator().id;
            
            if (cmbProfile.SelectedIndex == 1)
                return Profile.Assistant().id;

            return "";
        }

        private string birthDate()
        {
            return txtDay.Text + "/" + (cmbMonth.SelectedIndex + 1).ToString() + "/" + cmbYear.Text;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
           if (persister.Persist())
           {
                MessageBox.Show("Usuário registrado.");
                this.Close();
           }
           else
           {
                displayValidationErrors();
           }
        }

        private void all_TextChanged(object sender, EventArgs e)
        {
            ReloadData();
            displayValidationErrors();
        }

        private void ReloadData()
        {
            userCaster.Reset();
            userCaster.setName(txtName.Text);
            userCaster.setBirthDate(birthDate());
            userCaster.setEmail(txtEmail.Text);
            userCaster.setPassword(txtPassword.Text);
            userCaster.setPasswordConfirm(txtPassConfirm.Text);
            userCaster.setProfile(selectedProfileId());
            userCaster.setStatus(((int)User.Status.ACTIVE).ToString());
        }

        private void displayValidationErrors()
        {
            var castErrors = (MultipleAttributeValidationResult)persister.CasterErrors();
            var userErrors = (MultipleAttributeValidationResult)persister.ValidatorErrors(userValidator);
            var results = new MultipleAttributeValidationResult[] { castErrors, userErrors };
            var passwordResult = (PasswordValidator.UserPasswordValidationResult)persister.ValidatorErrors(passwordValidator);

            foreach (var presenter in errorPresenters)
                presenter.displayMesssages(results);

            if (passwdPresenter != null)
                passwdPresenter.displayMesssages(passwordResult);

            switch (passwordResult.score())
            {
                case 0:
                case 1:
                case 2: lblPassStrenght.Text = "Muito Fraca";
                        lblPassStrenght.ForeColor = Color.Red;
                        break;
                case 3:
                case 4: lblPassStrenght.Text = "Fraca";
                        lblPassStrenght.ForeColor = Color.Orange;
                        break;
                case 5:
                case 6: lblPassStrenght.Text = "Razoável";
                        lblPassStrenght.ForeColor = Color.Yellow;
                        break;
                case 7:
                case 8: lblPassStrenght.Text = "Forte";
                        lblPassStrenght.ForeColor = Color.Blue;
                        break;
                case 9:
                case 10: lblPassStrenght.Text = "Muito Forte";
                         lblPassStrenght.ForeColor = Color.Green;
                         break;
            }
            
            var warnings = "\n";

            foreach (var warn in passwordResult.warnings)
                warnings += "\n" + ErrorMessages.passwordValidatorWarningMessages[(int)warn];

            lblPassStrenght.Text += warnings;
        }
    }
}

