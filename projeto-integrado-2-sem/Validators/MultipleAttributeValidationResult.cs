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
            INVALID_NUMBER,
            INVALID_ASSOCIATION_ID,
            INVALID_EMAIL,
            INVALID_CONFIRMATION,
            NOT_EQUAL,
            INVALID_CPF,
            IN_USE_BY_ACTIVE,
            IN_USE_BY_INACTIVE,
            AFTER_TEN_DAYS,
            BEFORE_TEN_DAYS,
            LESS_THAN_ONE
        }

        public Dictionary<String, List<Error>> errors = new Dictionary<String, List<Error>>();

        public bool Valid()
        {
            return errors.Select(pair => pair.Value.Count).Sum() < 1;
        }

        public void AddError(string attribute, Error error)
        {
            List<Error> errList;

            if (errors.TryGetValue(attribute, out errList))
            {
                errList.Add(error);
            }
            else
            {
                errList = new List<Error>();
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
