using projeto_integrado_2_sem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Validators
{
    public class UserValidator : Validator<User>
    {

        public ValidationResult Validate(User record)
        {
            var result = new MultipleAttributeValidationResult();
            if (record.name.Length == 0)
                result.AddError("name", MultipleAttributeValidationResult.Error.BLANK_ATTRIBUTE);

            if (record.email.Length == 0)
                result.AddError("email", MultipleAttributeValidationResult.Error.BLANK_ATTRIBUTE);

            if (!record.email.Contains("@"))
                result.AddError("email", MultipleAttributeValidationResult.Error.INVALID_EMAIL);

            if (record.code.Length == 0)
                result.AddError("code", MultipleAttributeValidationResult.Error.BLANK_ATTRIBUTE);

            return result;
        }
    }
}
