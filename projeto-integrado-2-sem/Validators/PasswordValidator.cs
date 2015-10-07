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
            TOO_SHORT=0, 
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
            SEQUENCIAL_NUMBERS=0,
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
                var peso = WarningWeight[(int) Warning.SEQUENCIAL_NUMBERS];
                return peso;
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
            if (password.Length < 6)
                validationResult.errors.Add(Error.TOO_SHORT);
            
            if (password.Length > 10)
                validationResult.errors.Add(Error.TOO_LONG);

        }

        private void AnaliseWarnings(ValidaionResult validationResult, User user, string password)
        {

        }
    }
}
