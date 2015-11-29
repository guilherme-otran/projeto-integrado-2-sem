using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projeto_integrado_2_sem.Models;

namespace projeto_integrado_2_sem.Casters
{
    class ProductCaster : GenericTypeCaster<Product>
    {
        private Product product = new Product();

        public override Product GetModel()
        {
            return product;
        }

        public override void SetModel(Product model)
        {
            this.product = model;
            Reset();
        }
        public void setName(string name)
        {
            this.product.Name = name.Trim();
        }
        public void setPrice(float price)
        {
            this.product.Price = price;
        }
        public void setAmount(int amount)
        {
            this.product.Amount = amount;
        }
    }
} 
