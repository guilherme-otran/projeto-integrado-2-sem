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
    class CustomerValidator : Validator<Customer>
    {
        private CustomerRepository customerRepo;

        public CustomerValidator(CustomerRepository customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public ValidationResult Validate(Customer record)
        {
            var result = new MultipleAttributeValidationResult();

            if (record.Name != null && record.Name.Length == 0)
                result.AddError("name", MultipleAttributeValidationResult.Error.BLANK_ATTRIBUTE);

            if (record.Cpf != null)
            {
                if (!validCpf(record.Cpf))
                    result.AddError("cpf", MultipleAttributeValidationResult.Error.INVALID_CPF);
                else
                {
                    if (customerRepo.Any(c => c.Cpf.Equals(record.Cpf) && (record.Id == null || !record.Id.Equals(c.Id))))
                        result.AddError("cpf", MultipleAttributeValidationResult.Error.IN_USE_BY_ACTIVE);

                    if (customerRepo.DeadRecordsRepo().Any(c => c.Cpf.Equals(record.Cpf) && (record.Id == null || !record.Id.Equals(c.Id))))
                        result.AddError("cpf", MultipleAttributeValidationResult.Error.IN_USE_BY_INACTIVE);
                }
            }

            return result;
        }

        private bool validCpf(string cpf)
        {
            // 370.791.178-01 => 14 digits
            var cpfReg = new Regex(@"\A\d{3}\.\d{3}\.\d{3}-\d{2}\Z");

            if (!cpfReg.IsMatch(cpf))
                return false;

            var cpfDigits = cpf.Replace(".", "").Replace("-", "").Select(c => int.Parse(c.ToString()));

            var sum1 = 0;
            for (int i = 0; i <= 8; i++)
                sum1 += cpfDigits.ElementAt(i) * (10 - i);

            sum1 = sum1 % 11;

            if (sum1 < 2)
                sum1 = 0;
            else
                sum1 = 11 - sum1;

            if (sum1 != cpfDigits.ElementAt(9))
                return false;

            var sum2 = 0;
            for (int i = 0; i <= 9; i++)
                sum2 += cpfDigits.ElementAt(i) * (11 - i);

            sum2 = sum2 % 11;

            if (sum2 < 2)
                sum2 = 0;
            else
                sum2 = 11 - sum2;

            if (cpfDigits.ElementAt(10) != sum2)
                return false;

            return true;
        }
    }
}
