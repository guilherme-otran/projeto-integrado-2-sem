using projeto_integrado_2_sem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Casters
{
    class CustomerCaster : GenericTypeCaster<Customer>
    {
        private Customer customer = new Customer();

        public override Customer GetModel()
        {
            return customer;
        }

        public override void SetModel(Customer model)
        {
            this.customer = model;
            Reset();
        }

        public void setName(string name)
        {
            this.customer.Name = name.Trim();
        }

        public void setCpf(string cpf)
        {
            this.customer.Cpf = cpf;
        }
    }
}
