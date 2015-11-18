using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projeto_integrado_2_sem.Models;
using System.Text.RegularExpressions;

namespace projeto_integrado_2_sem.Validators
{
    public class PasswordValidator : Validator<User>
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
            EQUALS_USER_CODE,
            TOO_WEAK
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

        public static int[] WarningWeight = new int[] { 1, 1, 1, 2, 2, 2, 3, 3, 3, 3 };

        public class UserPasswordValidationResult : ValidationResult
        {
            public List<Error> errors;
            public List<Warning> warnings;

            public UserPasswordValidationResult()
            {
                errors = new List<Error>();
                warnings = new List<Warning>();
                for (int i = 0; i <= (int)Warning.CONTAINS_REVERSE_DAY_AND_MONTH_OF_BIRTH_DATE; i++)
                {
                    warnings.Add((Warning)i);
                }
            }

            public bool Valid()
            {
                return errors.Count == 0;
            }

            public int score()
            {
                if (!Valid())
                {
                    return 0;
                }

                int badScoreTotal = 0;
                foreach (Warning warning in warnings)
                {
                    var peso = WarningWeight[(int)warning];
                    badScoreTotal += peso;
                }

                if (badScoreTotal > 10)
                    return 0;

                return 10 - badScoreTotal;
            }
	    }

        public ValidationResult Validate(User record)
        {
            var validationResult = new UserPasswordValidationResult();
            AnaliseErrors(validationResult, record, record.Password);
            AnaliseWarnings(validationResult, record, record.Password);

            if (validationResult.score() < 3)
                validationResult.errors.Add(Error.TOO_WEAK);

            return validationResult;
        }

        private void AnaliseErrors(UserPasswordValidationResult validationResult, User user, string password)
        {
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

            var acceptableRegexp = new Regex(@"\A[A-Za-z0-9\s]*\Z");
            if (!acceptableRegexp.Match(password).Success)
                validationResult.errors.Add(Error.SPECIAL_CHARS);

            foreach (var key in password)
            {
                if (char.IsNumber(key) && password.Contains(new String(key, 3)))
                {
                    validationResult.errors.Add(Error.REPEATED_NUMBERS);
                    break;
                }
            }

            var lowerPassword = password.ToLower();
            foreach (var key in lowerPassword)
            {
                if (char.IsLetter(key) && lowerPassword.Contains(new String(key, 3)))
                {
                    validationResult.errors.Add(Error.REPEATED_LETTERS);
                    break;
                }
            }

            var numberCount = 0;
            var letterCount = 0;

            foreach (var key in password)
            {
                if (char.IsLetter(key))
                    letterCount++;
                if (char.IsNumber(key))
                    numberCount++;
            }

            if (numberCount < 2)
                validationResult.errors.Add(Error.TOO_FEW_NUMBERS);

            if (letterCount < 2)
                validationResult.errors.Add(Error.TOO_FEW_LETTERS);

            if (password.Equals(user.OldPassword))
                validationResult.errors.Add(Error.EQUALS_PREVIOUS_PASSWORD);

            if (password.Equals(user.Id))
                validationResult.errors.Add(Error.EQUALS_USER_CODE);
        }

        private void AnaliseWarnings(UserPasswordValidationResult validationResult, User user, string password)
        {
            // Check for 4+ digits sum or subtraction sequences (1234, 2468, 4321, etc)
            var regexp = new Regex("\\d{4,}"); // Finds 4+ digits toghether
            var finded = regexp.Match(password);
            var valid = true;
            if (finded.Success)
            {
                var digits = finded.Value;
                var deltas = new List<int>();

                for (var i=0; i<(digits.Length-1); i++)
                    // Delta betwen two digits
                    deltas.Add(int.Parse(digits[i + 1].ToString()) - int.Parse(digits[i].ToString()));

                // Check for 3 equal deltas (4 digits -> 3 deltas)
                for (var i=0; i<(deltas.Count - 2); i++)
                    if (deltas.ElementAt(i) == deltas.ElementAt(i+1) && deltas.ElementAt(i) == deltas.ElementAt(i+2))
                    {
                        valid = false;
                        break;
                    }
            }

            if (valid)
                validationResult.warnings.Remove(Warning.SEQUENCIAL_NUMBERS);

            var letterCount = 0;
            var digitCount = 0;
            
            foreach (var c in password)
            {
                if (char.IsLetter(c))
                    letterCount++;
                if (char.IsDigit(c))
                    digitCount++;
            }

            if (letterCount > 2)
                validationResult.warnings.Remove(Warning.ONLY_TWO_LETTERS);

            if (digitCount > 2)
                validationResult.warnings.Remove(Warning.ONLY_TWO_NUMBERS);

            var userCode = user.Id;
            if (userCode == null || (!password.ToLower().Contains(userCode.ToLower())))
                validationResult.warnings.Remove(Warning.CONTAINS_USER_CODE);

            var firstName = user.FirstName();
            if (firstName == null || (!password.ToLower().Contains(firstName.ToLower())))
                validationResult.warnings.Remove(Warning.CONTAINS_NAME);

            var userInitials = user.NameInitials();
            if (userInitials == null || (!password.ToUpper().Contains(userInitials)))
                validationResult.warnings.Remove(Warning.CONTAINS_NAME_INITIALS);

            if (user.BirthDate != DateTime.MinValue)
            {
                var birthDateStr = user.BirthDate.ToString("ddMMyyyy");
                if (!password.Contains(birthDateStr))
                {
                    validationResult.warnings.Remove(Warning.CONTAINS_FULL_BIRTH_DATE);

                    birthDateStr = user.BirthDate.ToString("ddMM");
                    if (!password.Contains(birthDateStr))
                        validationResult.warnings.Remove(Warning.CONTAINS_DAY_AND_MONTH_OF_BIRTH_DATE);
                }
                else
                {
                    validationResult.warnings.Remove(Warning.CONTAINS_DAY_AND_MONTH_OF_BIRTH_DATE);
                }

                birthDateStr = user.BirthDate.ToString("yyyyMMdd");
                if (!password.Contains(birthDateStr))
                {
                    validationResult.warnings.Remove(Warning.CONTAINS_REVERSE_FULL_BIRTH_DATE);

                    birthDateStr = user.BirthDate.ToString("MMdd");
                    if (!password.Contains(birthDateStr))
                        validationResult.warnings.Remove(Warning.CONTAINS_REVERSE_DAY_AND_MONTH_OF_BIRTH_DATE);
                }
                else
                {
                    validationResult.warnings.Remove(Warning.CONTAINS_REVERSE_DAY_AND_MONTH_OF_BIRTH_DATE);
                }
            }
            else
            {
                validationResult.warnings.Remove(Warning.CONTAINS_FULL_BIRTH_DATE);
                validationResult.warnings.Remove(Warning.CONTAINS_DAY_AND_MONTH_OF_BIRTH_DATE);
                validationResult.warnings.Remove(Warning.CONTAINS_REVERSE_FULL_BIRTH_DATE);
                validationResult.warnings.Remove(Warning.CONTAINS_REVERSE_DAY_AND_MONTH_OF_BIRTH_DATE);
            }

        }
    }
}
