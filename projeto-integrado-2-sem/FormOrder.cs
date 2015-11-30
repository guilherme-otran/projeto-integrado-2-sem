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
    public partial class FormOrder : Form
    {
        private CustomerRepository custRepo = RepositoryManager.ManagerInstance.CustomerRepository();
        private ProductRepository prodRepo = RepositoryManager.ManagerInstance.ProductRepository();
        private SaleRepository saleRepo = RepositoryManager.ManagerInstance.SaleRepository();

        private SaleValidator validator = new SaleValidator();
        private SaleCaster caster = new SaleCaster();
        private GenericPersister<Sale> persister;

        private List<GenericErrorPresenter> presenters = new List<GenericErrorPresenter>();

        private Customer customer;

        public FormOrder(string customerId)
        {
            InitializeComponent();
            persister = new SalePersister(saleRepo, prodRepo, validator, caster);
            this.customer = custRepo.FindById(customerId);
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            txtCustName.Text = customer.Name;
            txtCustCpf.Text = customer.Cpf;

            var source = new BindingSource(prodRepo.List(), null);
            cmbProdName.DataSource = source;
            cmbProdName.ValueMember = "Name";

            presenters.Add(new GenericErrorPresenter(numOrderQtd, "quantity"));
            presenters.Add(new GenericErrorPresenter(mTxtOrderDate, "saleDate"));
            presenters.Add(new GenericErrorPresenter(cmbProdName, "product"));
        }

        private void ReloadData()
        {
            caster.Reset();
            caster.setDate(mTxtOrderDate.Text);
            caster.setQuantity(numOrderQtd.Value.ToString());
            caster.setCustomer(customer);

            var prod = (Product)cmbProdName.SelectedItem;
            caster.setProduct(prod);

            if (prod == null)
            {
                txtProdPrice.Clear();
            }
            else
            {
                txtProdPrice.Text = prod.Price.Value.ToString("C");
            }

            if (caster.GetModel().TotalValue.HasValue)
            {
                txtOrderTotal.Text = caster.GetModel().TotalValue.Value.ToString("C");
            }
            else
            {
                txtOrderTotal.Clear();
            }
        }

        private void DisplayErrors()
        {
            var validatorResult = (MultipleAttributeValidationResult)persister.ValidatorErrors(validator);
            var castResult = (MultipleAttributeValidationResult)persister.CasterErrors();
            var result = new MultipleAttributeValidationResult[] { castResult, validatorResult };

            foreach (var presenter in presenters)
                presenter.displayMesssages(result);
        }

        private void All_TextChanged(object sender, EventArgs e)
        {
            ReloadData();
            DisplayErrors();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ReloadData();
            if (persister.Persist())
            {
                MessageBox.Show("Pedido salvo com sucesso. Nº " + persister.GetId());
                this.Close();
            }
            else
            {
                DisplayErrors();
            }
        }

        private void numOrderQtd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
            {
                numOrderQtd.Value += 1;
                numOrderQtd.Value -= 1;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
