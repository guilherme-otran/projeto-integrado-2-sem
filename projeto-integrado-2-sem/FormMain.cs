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
    public partial class FormMain : Form
    {
        public User CurrentUser;

        public FormMain()
        {
            InitializeComponent();
        }

        public FormMain(User CurrentUser)
        {
            InitializeComponent();
            this.CurrentUser = CurrentUser;
        }

        private Profile CurrentProfile()
        {
            return CurrentUser.Profile;
        }
    }
}
