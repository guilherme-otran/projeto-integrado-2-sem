using projeto_integrado_2_sem.Validators;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

namespace projeto_integrado_2_sem.ErrorPresenters
{
    class GenericErrorPresenter
    {
        private Control[] validatables;

        protected Label messageLabel;
        private string key;

        public GenericErrorPresenter(Control validatable, Form container, string key) :
            this(new Control[] { validatable }, container, key)
        {
        }

        public GenericErrorPresenter(Control[] validatables, Form container, string key)
        {
            this.validatables = validatables;
            this.key = key;

            this.messageLabel = new Label();
            this.messageLabel.Location = validatables.Last().Location;
            messageLabel.Left += validatables.Last().Width + 10;
            messageLabel.AutoSize = true;

            container.Controls.Add(messageLabel);
        }

        protected void clearErrors()
        {
            messageLabel.Text = "";
            for (var i = 0; i < validatables.Length; i++)
                validatables[i].BackColor = Color.White;
        }

        protected void markHasErrors()
        {
            foreach (var v in validatables)
                v.BackColor = Color.Red;
        }

        public void displayMesssages(MultipleAttributeValidationResult[] results)
        {
            clearErrors();
            bool hasErrors = false;

            foreach (var result in results)
            {
                List<MultipleAttributeValidationResult.Error> errors;

                if (result.errors.TryGetValue(key, out errors))
                {
                    foreach (var error in errors)
                    {
                        messageLabel.Text += ErrorMessages.multipleAttributeErrorMessages[(int)error];
                        messageLabel.Text += "; ";
                        hasErrors = true;
                    }
                }
            }

            if (hasErrors)
                markHasErrors();
        }
    }
}
