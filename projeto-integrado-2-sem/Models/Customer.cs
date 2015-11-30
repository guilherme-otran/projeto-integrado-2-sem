using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Models
{
    [Serializable]
    public class Customer : IStorable, ICloneable
    {
        public string id;
        protected string name;
        protected string cpf;

        // View
        public string Id { get { return id; } }

        [System.ComponentModel.DisplayName("Nome")]
        public string Name { get { return name; } set { name = value; } }

        [System.ComponentModel.DisplayName("CPF")]
        public string Cpf { get { return cpf; } set { cpf = value; } }

        string IStorable.id
        {
            get { return this.Id; }
            set { this.id = value; }
        }

        public object Clone()
        {
            var customer = new Customer();
            customer.id = this.id;
            customer.name = this.name;
            customer.cpf = this.cpf;

            return customer;
        }
    }
}
