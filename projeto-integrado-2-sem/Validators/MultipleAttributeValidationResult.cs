using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Validators
{
    class MultipleAttributeValidationResult : ValidationResult
    {
        public enum Error
        {
            BLANK_ATTRIBUTE = 0,
            INVALID_DATE,
            INVALID_NUMBER
        }

        public Dictionary<String, List<Error>> errors = new Dictionary<String, List<Error>>();

        public bool Valid()
        {
            return errors.Select(pair => pair.Value.Count).Sum() < 1;
        }

        public void AddError(string attribute, Error error)
        {
            var errList = new List<Error>();

            if (errors.TryGetValue(attribute, out errList))
            {
                errList.Add(error);
            }
            else
            {
                errList.Add(error);
                errors.Add(attribute, errList);
            }
        }

        public void Clear()
        {
            errors.Clear();
        }
    }
}
