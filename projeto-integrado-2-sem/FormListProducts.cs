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
    public partial class FormListProducts : Form
    {
        public FormListProducts()
        {
            InitializeComponent();
        }

        private void btnRegisterProduct_Click(object sender, EventArgs e)
        {
            (new FormProduct()).ShowDialog();
        }
    }
}
