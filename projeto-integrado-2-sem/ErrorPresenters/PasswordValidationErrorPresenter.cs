using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto_integrado_2_sem.Validators;

namespace projeto_integrado_2_sem.ErrorPresenters
{
    class PasswordValidationErrorPresenter : GenericErrorPresenter
    {
        public PasswordValidationErrorPresenter(Control validatable, Form container) :
            base(validatable, container, null)
        {
        }

        public void displayMesssages(PasswordValidator.UserPasswordValidationResult result)
        {
            clearErrors();
            var errors = result.errors;

            foreach (var error in errors)
            {
                messageLabel.Text += ErrorMessages.passwordValidatorErrorMessages[(int)error];
                messageLabel.Text += "; ";
            }

            if (!result.Valid())
                markHasErrors();
        }
    }
}
