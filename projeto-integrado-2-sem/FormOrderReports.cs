using projeto_integrado_2_sem.Models;
using projeto_integrado_2_sem.Repositories;
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
    public partial class FormOrderReports : Form
    {
        private SaleRepository repo = RepositoryManager.ManagerInstance.SaleRepository();
        private CustomerRepository custRepo = RepositoryManager.ManagerInstance.CustomerRepository();
        private ProductRepository prodRepo = RepositoryManager.ManagerInstance.ProductRepository();

        public FormOrderReports()
        {
            InitializeComponent();
        }

        private void radGroup_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDs();
        }

        private void FormOrderReports_Load(object sender, EventArgs e)
        {
            UpdateDs();
        }

        private void UpdateDs()
        {
            BindingSource source = null;
            salesReportGridView.Columns.Clear();

            if (radGroupCustomer.Checked)
            {
                AddCustomerColumns();
                source = new BindingSource(CustomersBinding(), null);
            }

            if (radGroupProd.Checked)
            {
                AddProductColumns();
                source = new BindingSource(ProductsBinding(), null);
            }

            if (radGroupDate.Checked)
            {
                AddDateColumns();
                source = new BindingSource(DateBinding(), null);
            }

            salesReportGridView.DataSource = source;
            salesReportGridView.Columns["TotalValue"].DefaultCellStyle.Format = "C";
        }

        private void salesReportGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (radGroupCustomer.Checked)
                PlaceCustomers();

            if (radGroupProd.Checked)
                PlaceProducts();

            if (radGroupDate.Checked)
                PlaceDates();
        }

        // Customers
        private void AddCustomerColumns()
        {
            var clientNameColumn = new DataGridViewTextBoxColumn();
            clientNameColumn.ValueType = typeof(String);
            clientNameColumn.HeaderText = "Nome do Cliente";
            clientNameColumn.Name = "CustomerName";
            salesReportGridView.Columns.Insert(0, clientNameColumn);

            var clientCpfColumn = new DataGridViewTextBoxColumn();
            clientCpfColumn.ValueType = typeof(String);
            clientCpfColumn.HeaderText = "CPF do Cliente";
            clientCpfColumn.Name = "CustomerCPF";
            salesReportGridView.Columns.Insert(1, clientCpfColumn);
        }

        private void PlaceCustomers()
        {
            foreach (DataGridViewRow row in salesReportGridView.Rows)
            {
                row.Cells["CustomerName"].Value = ((SaleGroup<Customer>)row.DataBoundItem).GroupingKey.Name;
                row.Cells["CustomerCPF"].Value = ((SaleGroup<Customer>)row.DataBoundItem).GroupingKey.Cpf;
            }
        }

        private BindingList<SaleGroup<Customer>> CustomersBinding()
        {
            var grouped = repo.GroupedBy(s => s.CustomerId)
                              .Select(sg => sg.ConvertTo(customerId => custRepo.FindById(customerId)))
                              .ToList();

            return new BindingList<SaleGroup<Customer>>(grouped);
        }

        // Products
        private void AddProductColumns()
        {
            var productNameColumn = new DataGridViewTextBoxColumn();
            productNameColumn.ValueType = typeof(String);
            productNameColumn.HeaderText = "Nome do Produto";
            productNameColumn.Name = "ProductName";
            salesReportGridView.Columns.Insert(0, productNameColumn);
        }

        private void PlaceProducts()
        {
            foreach (DataGridViewRow row in salesReportGridView.Rows)
            {
                row.Cells["ProductName"].Value = ((SaleGroup<Product>)row.DataBoundItem).GroupingKey.Name;
            }
        }

        private BindingList<SaleGroup<Product>> ProductsBinding()
        {
            var grouped = repo.GroupedBy(s => s.ProductId)
                              .Select(sg => sg.ConvertTo(productId => prodRepo.FindById(productId)))
                              .ToList();

            return new BindingList<SaleGroup<Product>>(grouped);
        }

        // Date
        private void AddDateColumns()
        {
            var dateColumn = new DataGridViewTextBoxColumn();
            dateColumn.ValueType = typeof(String);
            dateColumn.HeaderText = "Data";
            dateColumn.Name = "Date";
            salesReportGridView.Columns.Insert(0, dateColumn);
        }

        private void PlaceDates()
        {
            foreach (DataGridViewRow row in salesReportGridView.Rows)
            {
                row.Cells["Date"].Value = ((SaleGroup<DateTime>)row.DataBoundItem).GroupingKey.ToString("dd/MM/yyyy");
            }
        }

        private BindingList<SaleGroup<DateTime>> DateBinding()
        {
            var grouped = repo.GroupedBy(s => s.SaleDate.Value).ToList();

            return new BindingList<SaleGroup<DateTime>>(grouped);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
