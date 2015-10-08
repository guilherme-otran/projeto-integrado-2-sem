using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projeto_integrado_2_sem.Models;

namespace projeto_integrado_2_sem.Validators
{
    public class PasswordValidator
    {
        public enum Error : int
        {
            TOO_SHORT = 0,
            TOO_LONG,
            SPACES,
            SPECIAL_CHARS,
            NO_DISTINC_CASES,
            TOO_FEW_LETTERS,
            TOO_FEW_NUMBERS,
            REPEATED_LETTERS,
            REPEATED_NUMBERS,
            EQUALS_PREVIOUS_PASSWORD,
            EQUALS_USER_CODE
        }

        public enum Warning : int
        {
            SEQUENCIAL_NUMBERS = 0,
            ONLY_TWO_LETTERS,
            ONLY_TWO_NUMBERS,
            CONTAINS_USER_CODE,
            CONTAINS_NAME,
            CONTAINS_NAME_INITIALS,
            CONTAINS_FULL_BIRTH_DATE,
            CONTAINS_DAY_AND_MONTH_OF_BIRTH_DATE,
            CONTAINS_REVERSE_FULL_BIRTH_DATE,
            CONTAINS_REVERSE_DAY_AND_MONTH_OF_BIRTH_DATE,
        }

        public static int[] WarningWeight = new int[] { 1, 1, 1, 2, 2, 2, 3, 3 };

        public class ValidaionResult
        {
            public List<Error> errors;
            public List<Warning> warnings;

            public ValidaionResult()
            {
                errors = new List<Error>();
                warnings = new List<Warning>();
            }

            public int score()
            {
                int scoreTotal = 0;
                foreach (Warning warning in warnings)
                {
                    var peso = WarningWeight[(int)warning];
                    scoreTotal += peso;
                }
                return scoreTotal;
            }
	}

        public ValidaionResult ValidatePassword(User user, string password)
        {
            var validationResult = new ValidaionResult();
            AnaliseErrors(validationResult, user, password);
            AnaliseWarnings(validationResult, user, password);

            return validationResult;
        }

        private void AnaliseErrors(ValidaionResult validationResult, User user, string password)
        {
            StringBuilder builder = new StringBuilder();

            if (password.Length < 6)
                validationResult.errors.Add(Error.TOO_SHORT);
            
            if (password.Length > 10)
                validationResult.errors.Add(Error.TOO_LONG);

            bool hasLowerCase = false;
            bool hasUpperCase = false;
            foreach (var key in password)
            {
                hasLowerCase |= char.IsLetter(key) && char.IsLower(key);
                hasUpperCase |= char.IsLetter(key) && char.IsUpper(key);

                if (hasLowerCase && hasUpperCase)
                    break;
            }

            if (!(hasLowerCase && hasUpperCase))
                validationResult.errors.Add(Error.NO_DISTINC_CASES);

            foreach (var key in password)
                if (char.IsWhiteSpace(key)) 
                {
                    validationResult.errors.Add(Error.SPACES);
                    break;
                }

            foreach (var key in password)
                if (!(char.IsWhiteSpace(key) || char.IsLetter(key) || char.IsNumber(key)))
                {
                    validationResult.errors.Add(Error.SPECIAL_CHARS);
                    break;
                }

            foreach (var key in password)
            {
                builder.Append(key);
                builder.Append(key);
                builder.Append(key);
                if (char.IsNumber(key) && password.Contains(builder.ToString()))
                {
                    validationResult.errors.Add(Error.REPEATED_NUMBERS);
                    break;
                }
                builder.Clear();
            }

            foreach (var key in password)
            {
                builder.Append(key);
                builder.Append(key);
                builder.Append(key);
                if (char.IsLetter(key) && password.Contains(builder.ToString()))
                {
                    validationResult.errors.Add(Error.REPEATED_LETTERS);
                    break;
                }
                builder.Clear();
            }


        }

        private void AnaliseWarnings(ValidaionResult validationResult, User user, string password)
        {

        }
    }
}
