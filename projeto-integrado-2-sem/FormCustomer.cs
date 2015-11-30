using projeto_integrado_2_sem.Casters;
using projeto_integrado_2_sem.ErrorPresenters;
using projeto_integrado_2_sem.Interactors;
using projeto_integrado_2_sem.Models;
using projeto_integrado_2_sem.Repositories;
using projeto_integrado_2_sem.Validators;
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
    public partial class FormCustomer : Form
    {
        private CustomerRepository customerRepo = RepositoryManager.ManagerInstance.CustomerRepository();
        private CustomerCaster caster = new CustomerCaster();
        private CustomerValidator validator;
        private GenericPersister<Customer> persister;
        private IList<GenericErrorPresenter> errorPresenters = new List<GenericErrorPresenter>();

        public FormCustomer() : this(null) { }

        public FormCustomer(string customerId)
        {
            InitializeComponent();
            validator = new CustomerValidator(customerRepo);
            persister = new GenericPersister<Customer>(customerRepo, validator, caster);

            if (customerId != null)
            {
                var customer = customerRepo.FindById(customerId);
                txtName.Text = customer.Name;
                mTxtCpf.Text = customer.Cpf;
                caster.SetModel(customer);
            }
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            errorPresenters.Add(new GenericErrorPresenter(txtName, "name"));
            errorPresenters.Add(new GenericErrorPresenter(mTxtCpf, "cpf"));
        }

        private void all_TextChanged(object sender, EventArgs e)
        {
            reloadData();
            displayValidationErrors();
        }

        private void reloadData()
        {
            caster.Reset();
            caster.setName(txtName.Text);
            caster.setCpf(mTxtCpf.Text);
        }

        private void displayValidationErrors()
        {
            var result = (MultipleAttributeValidationResult)persister.ValidatorErrors(validator);

            foreach (var presenter in errorPresenters)
                presenter.displayMesssages(result);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reloadData();

            if (persister.Persist())
            {
                MessageBox.Show("Cliente registrado com o código " + persister.GetId());
                this.Close();
            }
            else
            {
                displayValidationErrors();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
