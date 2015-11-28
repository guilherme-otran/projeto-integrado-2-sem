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
        protected Status currentStatus;

        // View
        public string Id { get { return id; } }
        public string Name { get { return name; } set { name = value; } }
        public string Cpf { get { return cpf; } set { cpf = value; } }
        public Status CurrentStatus { get { return currentStatus; } set { currentStatus = value; } }

        public enum Status
        {
            ACTIVE = 0,
            INACTIVE
        }

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
            customer.currentStatus = this.currentStatus;

            return customer;
        }
    }
}
