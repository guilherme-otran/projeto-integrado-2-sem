using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_integrado_2_sem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RepositoryManager.InitManager();

            Application.ApplicationExit += delegate { RepositoryManager.CloseManager(); };

            FormMain formMain;

            do
            {
                FormLogin loginForm = new FormLogin();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    formMain = new FormMain(loginForm.LoggedUser);
                    Application.Run(formMain);
                }
                else
                {
                    Application.Exit();
                    break;
                }
            } while (formMain.LogoutRequested);
        }
    }
}
