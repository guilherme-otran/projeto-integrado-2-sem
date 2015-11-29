using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projeto_integrado_2_sem.Models;
using projeto_integrado_2_sem.Repositories;

namespace projeto_integrado_2_sem.Validators
{
    class ProductValidator : Validator<Product>
    {
        private ProductRepository productRepository;

        public ProductValidator(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ValidationResult Validate(Product record)
        {
            var result = new MultipleAttributeValidationResult();

            if (record.Name != null && record.Name.Length == 0)
                result.AddError("name", MultipleAttributeValidationResult.Error.BLANK_ATTRIBUTE);

            if (record.Amount < 0)
                result.AddError("amount", MultipleAttributeValidationResult.Error.AMOUNT_LESS_THAN_0);

            if (record.Price <= 0)
                result.AddError("price", MultipleAttributeValidationResult.Error.INVALID_PRICE);

            return result;
        }
    }
}
