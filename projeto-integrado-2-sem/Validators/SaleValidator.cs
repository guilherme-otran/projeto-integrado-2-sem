using projeto_integrado_2_sem.Models;
using projeto_integrado_2_sem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Validators
{
    class SaleValidator : Validator<Sale>
    {

        public ValidationResult Validate(Sale record)
        {
            var result = new MultipleAttributeValidationResult();

            if (record.SaleDate.HasValue)
            {
                if (record.SaleDate.Value.Subtract(DateTime.Today).TotalDays > 10)
                    result.AddError("saleDate", MultipleAttributeValidationResult.Error.AFTER_TEN_DAYS);

                if (record.SaleDate.Value.Subtract(DateTime.Today).TotalDays < -10)
                    result.AddError("saleDate", MultipleAttributeValidationResult.Error.BEFORE_TEN_DAYS);
            }

            if (record.Quantity.HasValue && record.Quantity < 1)
                result.AddError("quantity", MultipleAttributeValidationResult.Error.LESS_THAN_ONE);

            return result;
        }
    }
}
