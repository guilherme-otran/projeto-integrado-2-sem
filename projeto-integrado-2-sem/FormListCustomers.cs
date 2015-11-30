using projeto_integrado_2_sem.Models;
using projeto_integrado_2_sem.Repositories;
using projeto_integrado_2_sem.Casters;
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
    public partial class FormListCustomers : Form
    {
        private CustomerRepository repo = RepositoryManager.ManagerInstance.CustomerRepository();
        private Customer selectedCustomer;

        public FormListCustomers()
        {
            InitializeComponent();
            updateDs();
        }

        private void updateDs()
        {
            BaseRepository<Customer> mRepo;
            BindingList<Customer> list;

            if (radioActives.Checked)
                mRepo = repo;
            else
                mRepo = repo.DeadRecordsRepo();

            list = mRepo.List(c => c.Name.StartsWith(txtFilterName.Text) && c.Cpf.StartsWith(cpfText()));

            var source = new BindingSource(list, null);
            customersGridView.DataSource = source;
        }

        private string cpfText()
        {
            var cpf = "";

            foreach (var c in mTxtFilterCpf.Text)
                if (c != ' ')
                    cpf += c;
                else
                    return cpf;

            return cpf;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            (new FormCustomer()).ShowDialog();
            updateDs();
        }

        private void usersGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!radioActives.Checked)
            {
                btnEdit.Enabled = false;
                btnInactive.Enabled = false;
                btnNewOrder.Enabled = false;
                return;
            }

            if (customersGridView.SelectedRows.Count == 1)
            {
                btnEdit.Enabled = true;
                btnInactive.Enabled = true;
                btnNewOrder.Enabled = true;
                this.selectedCustomer = (Customer)customersGridView.SelectedRows[0].DataBoundItem;
            }
            else
            {
                btnEdit.Enabled = false;
                btnInactive.Enabled = false;
                btnNewOrder.Enabled = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            (new FormCustomer(selectedCustomer.Id)).ShowDialog();
            updateDs();
        }

        private void btnInactive_Click(object sender, EventArgs e)
        {
            repo.Destroy(selectedCustomer);
            updateDs();
        }

        private void radioActives_CheckedChanged(object sender, EventArgs e)
        {
            updateDs();
            btnRegister.Enabled = radioActives.Checked;
        }

        private void txtFilterName_TextChanged(object sender, EventArgs e)
        {
            updateDs();
        }

        private void mTxtFilterCpf_TextChanged(object sender, EventArgs e)
        {
            updateDs();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            if (customersGridView.SelectedRows.Count == 1)
                (new FormOrder(selectedCustomer.Id)).ShowDialog();
            else
                MessageBox.Show("Selecione um cliente para continuar");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
