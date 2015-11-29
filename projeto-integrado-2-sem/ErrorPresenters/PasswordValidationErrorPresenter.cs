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
        public PasswordValidationErrorPresenter(Control validatable) :
            base(validatable, null)
        {
        }

        public void displayMesssages(PasswordValidator.UserPasswordValidationResult result)
        {
            clearErrors();
            var errors = result.errors;
            var message = "";

            foreach (var error in errors)
            {
                message += ErrorMessages.passwordValidatorErrorMessages[(int)error];
                message += "\n";
            }

            if (!result.Valid())
                markHasErrors(message);
        }
    }
}
