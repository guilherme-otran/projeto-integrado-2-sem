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

            FormLogin loginForm = new FormLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FormMain(loginForm.LoggedUser));
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
