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
        public void setPrice(string priceStr)
        {
            Decimal price = Decimal.Zero;

            if (Decimal.TryParse(priceStr, out price))
                this.product.Price = price;
            else
            {
                this.product.Price = null;
                this.result.AddError("price", Validators.MultipleAttributeValidationResult.Error.INVALID_PRICE);
            }
        }
        public void setAmount(int amount)
        {
            this.product.Amount = amount;
        }
    }
} 
