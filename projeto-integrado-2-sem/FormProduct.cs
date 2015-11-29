using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto_integrado_2_sem.Casters;
using projeto_integrado_2_sem.ErrorPresenters;
using projeto_integrado_2_sem.Validators;
using projeto_integrado_2_sem.Repositories;
using projeto_integrado_2_sem.Interactors;
using projeto_integrado_2_sem.Models;
namespace projeto_integrado_2_sem
{
    public partial class FormProduct : Form
    {
        private ProductRepository productRepo = RepositoryManager.ManagerInstance.productRepository;
        private ProductCaster caster = new ProductCaster();
        private ProductValidator validator;
        private GenericPersister<Product> persister;
        private IList<GenericErrorPresenter> errorsPresenters = new List<GenericErrorPresenter>();

        public FormProduct() : this(null) { }

        public FormProduct(string productId)
        {
            InitializeComponent();
            validator = new ProductValidator(productRepo);
            persister = new GenericPersister<Product>(productRepo, validator, caster);

        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            errorsPresenters.Add(new GenericErrorPresenter(txtProductName, "name"));
            errorsPresenters.Add(new GenericErrorPresenter(mtxtPrice, "price"));
            errorsPresenters.Add(new GenericErrorPresenter(txtAmount, "amount"));
        }

        private void all_TextChanged(object sender, EventArgs e)
        {
            reloadData();
            displayValidationErrors();
        }

        private void reloadData()
        {
            caster.Reset();
            caster.setName(txtProductName.Text);
            caster.setPrice(mtxtPrice.Text);
           // caster.setAmount(int.Parse(txtAmount.Text));
        }

        private void displayValidationErrors()
        {
            var castResult = (MultipleAttributeValidationResult)persister.CasterErrors();
            var validResult = (MultipleAttributeValidationResult)persister.ValidatorErrors(validator);
            var result = new MultipleAttributeValidationResult[] { castResult, validResult };

            foreach (var presenter in errorsPresenters)
                presenter.displayMesssages(result);
        }
    }
}
