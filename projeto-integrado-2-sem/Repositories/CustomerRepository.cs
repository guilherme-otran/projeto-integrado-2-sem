using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projeto_integrado_2_sem.Models;
using System.IO;

namespace projeto_integrado_2_sem.Repositories
{
    public class CustomerRepository : ExclusionBaseRepository<Customer>
    {
        public CustomerRepository() : base("customers.dat", "dead-customers.dat") { }

        public override void InitializeFile()
        {
            base.InitializeFile(new CustomerStorableAdapter());
        }

        public Customer findByCpf(string cpf)
        {
            return FindBy(c => c.Cpf.Equals(cpf));
        }
    }

}
