using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Validators
{
    public interface Validator<T>
    {
        ValidationResult Validate(T record);
    }
}
