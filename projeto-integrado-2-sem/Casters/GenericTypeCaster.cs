using projeto_integrado_2_sem.Models;
using projeto_integrado_2_sem.Validators;

namespace projeto_integrado_2_sem.Casters
{
    abstract class GenericTypeCaster<T> where T : IStorable
    {
        public MultipleAttributeValidationResult result = new MultipleAttributeValidationResult();

        public abstract T GetModel();
        public abstract void SetModel(T model);

        public ValidationResult GetResult()
        {
            return result;
        }

        public bool Valid()
        {
            return result.Valid();
        }

        public void Reset()
        {
            result.Clear();
        }
    }
}
