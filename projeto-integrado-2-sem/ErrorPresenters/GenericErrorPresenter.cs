using projeto_integrado_2_sem.Validators;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;

namespace projeto_integrado_2_sem.ErrorPresenters
{
    class GenericErrorPresenter
    {
        private Control[] validatables;

        protected Label messageLabel;
        protected PictureBox errorIcon;

        private string key;

        public GenericErrorPresenter(Control validatable, Form container, string key) :
            this(new Control[] { validatable }, container, key)
        {
        }

        public GenericErrorPresenter(Control[] validatables, Form container, string key)
        {
            this.validatables = validatables;
            this.key = key;

            errorIcon = new PictureBox();
            errorIcon.Image = new Bitmap(Properties.Resources.errorIcon);
            errorIcon.Location = validatables.Last().Location;
            errorIcon.Left += validatables.Last().Width + 5;
            errorIcon.Top -= 5;
            errorIcon.Width = errorIcon.Image.Width;
            errorIcon.Height = errorIcon.Image.Height;
            errorIcon.Visible = false;

            this.messageLabel = new Label();
            this.messageLabel.Location = validatables.Last().Location;
            messageLabel.Left += validatables.Last().Width + 25;
            messageLabel.AutoSize = true;

            container.Controls.Add(errorIcon);
            container.Controls.Add(messageLabel);
        }

        protected void clearErrors()
        {
            errorIcon.Visible = false;
            messageLabel.Text = "";
        }

        protected void markHasErrors()
        {
            errorIcon.Visible = true;
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
