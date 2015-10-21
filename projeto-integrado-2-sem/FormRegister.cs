using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto_integrado_2_sem.Repositories;
using projeto_integrado_2_sem.Models;
using projeto_integrado_2_sem.Interactors;
using projeto_integrado_2_sem.Validators;

namespace projeto_integrado_2_sem
{
    public partial class FormRegister : Form
    {
        private string[] errorMessages = new string[]{ 
            "Senha muito curta (mínimo 6 caracteres)",
            "Senha muito longa (maximo 10 caracteres)",
            "Não pode conter espaços",
            "São permitidas apenas letras e números",
            "Não contém letras máiúsculas e minúsculas",
            "Deve conter pelo menos 2 números",
            "Deve conter pelo menos 2 letras",
            "Não pode ser igual a senha antiga",
            "Não pode ser igual a o código",
            "É muito fraca"
        };

        private string[] warnMessages = new string[]{ 
            "Contém números em sequencia",
            "Contém menos de 2 letras",
            "Contém menos de 2 números",
            "Contém código do usuário",
            "Contém o primeiro nome",
            "Contém as iniciais do nome",
            "Contém a data de nascimento",
            "Contém o dia e o mes do nascimento",
            "Contém a data de nascimento inversa",
            "Contém o mes e o dia do nascimento"
        };

        RegisterUser registerUser = new RegisterUser();
        PasswordValidator passwordValidator = new PasswordValidator();
        
        private bool validateDates(int day, int month, int year)
        {
            try
            {
                DateTime date = new DateTime(year, month, day);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public FormRegister()
        {
            InitializeComponent();
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            cmbYear.DataSource = Enumerable.Range(1950, ((DateTime.Today.Year) - 1949)).ToList();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.KeyChar = char.MinValue;
        }

        private void dates_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.KeyChar = char.MinValue;
        }

        private void atualizacao_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox && ((TextBox) sender) == txtPassword)
            {
                var tmpUser = new User();
                tmpUser.password = txtPassword.Text;
                var result = (PasswordValidator.UserPasswordValidationResult) passwordValidator.Validate(tmpUser);

                switch (result.score())
                {
                    case 0:
                    case 1:
                    case 2: lblPassStrenght.Text = "Muito Fraca"; break;
                    case 3:
                    case 4: lblPassStrenght.Text = "Fraca"; break;
                    case 5:
                    case 6: lblPassStrenght.Text = "Razoável"; break;
                    case 7:
                    case 8: lblPassStrenght.Text = "Forte"; break;
                    case 9:
                    case 10: lblPassStrenght.Text = "Muito forte"; break;
                }

                var warnings = "\n";
                foreach (var warn in result.warnings)
                    warnings += warnMessages[(int)warn];

                lblPassStrenght.Text += warnings;
            }
            if (txtName.Text != "" && txtEmail.Text != "" && txtDay.Text != "" && cmbMonth.Text != "" && cmbYear.Text != "" && txtPassword.Text != "" && txtPassConfirm.Text != "")
                btnProcess.Enabled = true;
            else
                btnProcess.Enabled = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                user.name = this.txtName.Text;
                user.email = this.txtEmail.Text;
                user.Profile = Profile.UserProfile();

                if (!(validateDates(int.Parse(txtDay.Text), cmbMonth.SelectedIndex + 1, int.Parse(cmbYear.Text))))
                {
                    MessageBox.Show("Data de nascimento inválida");
                    txtDay.Text = "";
                    cmbMonth.Text = "";
                    cmbYear.Text = "";
                }
                else
                {
                    user.birthDate = new DateTime(int.Parse(cmbYear.Text), cmbMonth.SelectedIndex + 1, int.Parse(txtDay.Text));

                    if (!(String.Compare(txtPassword.Text, txtPassConfirm.Text) == 0))
                    {
                        MessageBox.Show("As senhas digitadas não são iguais");
                        txtPassword.Text = "";
                        txtPassConfirm.Text = "";
                    }
                    else
                    {
                        user.password = this.txtPassword.Text;
                        var result = (PasswordValidator.UserPasswordValidationResult) passwordValidator.Validate(user);

                        if (result.Valid())
                        {
                            registerUser.setOneUser(user); //registra o usuário no txt

                            // Faz o login após o usuario se cadastrar

                            FormMain formMain = new FormMain(user);
                            formMain.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            var errorMessagesStr = "";
                            foreach (var error in result.errors)
                            {
                                errorMessagesStr += errorMessages[(int)error] + "\n";
                            }

                            MessageBox.Show("Sua senha não é valida:\n" + errorMessagesStr);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Digite os valores corretamente!");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblPassStrenght_Click(object sender, EventArgs e)
        {

        }
    }
}
