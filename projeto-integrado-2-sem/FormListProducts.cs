using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projeto_integrado_2_sem.Models;
using projeto_integrado_2_sem.Repositories;


namespace projeto_integrado_2_sem
{
    public partial class FormListProducts : Form
    {
        private Product selectecProduct;
        private ProductRepository repository = RepositoryManager.ManagerInstance.ProductRepository();

        public FormListProducts()
        {
            InitializeComponent();
        }

        private void FormListProducts_Load(object sender, EventArgs e)
        {
            updateDs();
        }

        private void updateDs()
        {
            //BaseRepository<Product> productRepo;
            BindingList<Product> productList;

            productList = repository.List();

            var source = new BindingSource(productList, null);
            productsGridView.DataSource = source;
        }

        private void btnRegisterProduct_Click(object sender, EventArgs e)
        {
            (new FormProduct()).ShowDialog();
        }

        private void productsGridView_SelectionChanged(object sender, EventArgs e)
        {
            if(productsGridView.SelectedRows.Count == 1)
                this.selectecProduct = (Product)productsGridView.SelectedRows[0].DataBoundItem;
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            (new FormProduct(selectecProduct.Id)).ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
