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
            if (record.Name.Length == 0)
                result.AddError("name", MultipleAttributeValidationResult.Error.BLANK_ATTRIBUTE);

            if (record.Email.Length == 0)
                result.AddError("email", MultipleAttributeValidationResult.Error.BLANK_ATTRIBUTE);

            if (!record.Email.Contains("@"))
                result.AddError("email", MultipleAttributeValidationResult.Error.INVALID_EMAIL);

            return result;
        }
    }
}
