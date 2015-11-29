using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Models
{
    [Serializable]
    public class Sale : IStorable, ICloneable
    {
        public string id;
        private string customerId;
        private string productId;
        private DateTime? saleDate = null;
        private int? quantity = null;

        [NonSerialized]
        private Customer customer;

        [NonSerialized]
        private Product product;

        // View
        public string Id { get { return id; } }
        public int? Quantity { get { return quantity; } set { quantity = value; } }
        public DateTime? SaleDate { get { return this.saleDate; } set { this.saleDate = value; } }

        public Decimal? TotalValue
        {
            get
            {
                if (product == null || (!product.Price.HasValue) || (!quantity.HasValue))
                    return null;

                return decimal.Multiply(product.Price.Value, quantity.Value);
            }
        }

        [Browsable(false)]
        public string CustomerId { get { return customerId; } }

        [Browsable(false)]
        public string ProductId { get { return productId; } }

        [Browsable(false)]
        public Customer Customer
        {
            get { return customer; }
            set
            {
                this.customer = value;
                this.customerId = value.id;
            }
        }

        [Browsable(false)]
        public Product Product
        {
            get { return product; }
            set
            {
                this.product = value;
                this.productId = value.id;
            }
        }

        string IStorable.id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        
        public object Clone()
        {
            var sale = new Sale();
            sale.id = id;
            sale.productId = productId;
            sale.product = product;
            sale.customerId = customerId;
            sale.customer = customer;
            sale.quantity = quantity;
            return sale;
        }
    }
}
