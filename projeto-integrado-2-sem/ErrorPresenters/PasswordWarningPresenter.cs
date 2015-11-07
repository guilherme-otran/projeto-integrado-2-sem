using projeto_integrado_2_sem.Validators;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_integrado_2_sem.ErrorPresenters
{
    class PasswordWarningPresenter
    {
        public static void present(PasswordValidator.UserPasswordValidationResult result, Label lblPassStrenght)
        {
            switch (result.score())
            {
                case 0:
                case 1:
                case 2:
                    lblPassStrenght.Text = "Muito Fraca";
                    lblPassStrenght.ForeColor = Color.Red;
                    break;
                case 3:
                case 4:
                    lblPassStrenght.Text = "Fraca";
                    lblPassStrenght.ForeColor = Color.Orange;
                    break;
                case 5:
                case 6:
                    lblPassStrenght.Text = "Razoável";
                    lblPassStrenght.ForeColor = Color.Yellow;
                    break;
                case 7:
                case 8:
                    lblPassStrenght.Text = "Forte";
                    lblPassStrenght.ForeColor = Color.Blue;
                    break;
                case 9:
                case 10:
                    lblPassStrenght.Text = "Muito Forte";
                    lblPassStrenght.ForeColor = Color.Green;
                    break;
            }

            var warnings = "\n";

            foreach (var warn in result.warnings)
                warnings += "\n" + ErrorMessages.passwordValidatorWarningMessages[(int)warn];

            lblPassStrenght.Text += warnings;
        }
    }
}
