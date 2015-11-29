using projeto_integrado_2_sem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Casters
{
    class SaleCaster : GenericTypeCaster<Sale>
    {
        private Sale sale = new Sale();

        public override Sale GetModel()
        {
            return sale;
        }

        public override void SetModel(Sale model)
        {
            this.sale = model;
            Reset();
        }

        public void setQuantity(string qt)
        {
            int parsed;

            if (int.TryParse(qt, out parsed))
                sale.Quantity = parsed;
            else
            {
                this.result.AddError("quantity", Validators.MultipleAttributeValidationResult.Error.INVALID_NUMBER);
                sale.Quantity = null;
            }
        }

        public void setProduct(Product prod)
        {
            if (prod == null)
                this.result.AddError("product", Validators.MultipleAttributeValidationResult.Error.INVALID_ASSOCIATION_ID);
            else
                sale.Product = prod;
        }

        public void setCustomer(Customer cust)
        {
            sale.Customer = cust;
        }

        public void setDate(string dateStr)
        {
            DateTime date = new DateTime();
            if (DateTime.TryParse(dateStr, out date))
            {
                sale.SaleDate = date;
            }
            else
            {
                sale.SaleDate = null;
                this.result.AddError("saleDate", Validators.MultipleAttributeValidationResult.Error.INVALID_DATE);
            }
        }
    }
}
