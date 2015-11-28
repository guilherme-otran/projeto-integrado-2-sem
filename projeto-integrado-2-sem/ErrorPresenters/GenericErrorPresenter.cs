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

        protected PictureBox errorIcon;
        protected ToolTip toolTip;

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

            toolTip = new ToolTip();
            toolTip.IsBalloon = true;
            toolTip.InitialDelay = 1;

            container.Controls.Add(errorIcon);
        }

        protected void clearErrors()
        {
            errorIcon.Visible = false;

            foreach (var ctr in validatables)
                toolTip.SetToolTip(ctr, "");

            toolTip.SetToolTip(errorIcon, "");
        }

        protected void markHasErrors(string errors)
        {
            errorIcon.Visible = true;

            foreach (var ctr in validatables)
            {
                toolTip.SetToolTip(ctr, errors);
            }

            toolTip.SetToolTip(errorIcon, errors);
        }

        public void displayMesssages(MultipleAttributeValidationResult result)
        {
            displayMesssages(new MultipleAttributeValidationResult[] { result });
        }

        public void displayMesssages(MultipleAttributeValidationResult[] results)
        {
            clearErrors();
            bool hasErrors = false;
            var message = "";

            foreach (var result in results)
            {
                List<MultipleAttributeValidationResult.Error> errors;

                if (result.errors.TryGetValue(key, out errors))
                {
                    foreach (var error in errors)
                    {
                        message += ErrorMessages.multipleAttributeErrorMessages[(int)error];
                        message += "\n";
                        hasErrors = true;
                    }
                }
            }

            if (hasErrors)
                markHasErrors(message);
        }
    }
}
