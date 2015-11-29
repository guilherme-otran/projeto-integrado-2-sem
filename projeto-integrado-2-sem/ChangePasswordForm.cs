using projeto_integrado_2_sem.Casters;
using projeto_integrado_2_sem.ErrorPresenters;
using projeto_integrado_2_sem.Interactors;
using projeto_integrado_2_sem.Models;
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
    public partial class ChangePasswordForm : Form
    {
        private PasswordValidator validator = new PasswordValidator();
        private UserCaster caster;
        private GenericPersister<User> persister;
        List<GenericErrorPresenter> errorPresenters = new List<GenericErrorPresenter>();
        PasswordValidationErrorPresenter passwdPresenter;

        public ChangePasswordForm(string userId)
        {
            InitializeComponent();

            var userRepo = RepositoryManager.ManagerInstance.UserRepository();
            var user = userRepo.FindById(userId);
            
            caster = new UserCaster(user);
            persister = new GenericPersister<User>(userRepo, new Validator<User>[] { validator }, caster);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            reloadData();
            if (persister.Persist())
            {
                MessageBox.Show("Senha alterada.");
                this.Close();
            }
            else
            {
                displayErrors();
            }
        }

        private void TextBox_TextChange(object sender, EventArgs e)
        {
            reloadData();
            displayErrors();
        }

        private void reloadData()
        {
            caster.Reset();
            caster.changePassword(txtCurrentPassword.Text, txtNewPasswors.Text, txtPassConfirm.Text);
        }

        private void displayErrors()
        {
            var castErrors = (MultipleAttributeValidationResult)persister.CasterErrors();
            var results = new MultipleAttributeValidationResult[] { castErrors };
            var passwordResult = (PasswordValidator.UserPasswordValidationResult)persister.ValidatorErrors(validator);

            foreach (var presenter in errorPresenters)
                presenter.displayMesssages(results);

            if (passwdPresenter != null)
                passwdPresenter.displayMesssages(passwordResult);

            PasswordWarningPresenter.present(passwordResult, lblPasswordWarn);
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            errorPresenters.Add(new GenericErrorPresenter(txtCurrentPassword, this, "currentPassword"));
            errorPresenters.Add(new GenericErrorPresenter(txtPassConfirm, this, "passwordConfirm"));
            passwdPresenter = new PasswordValidationErrorPresenter(txtNewPasswors, this);
        }
    }
}
