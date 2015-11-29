using projeto_integrado_2_sem.Models;
using projeto_integrado_2_sem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem
{
    [Serializable]
    public class SaleStorableAdapter : IStorableAdapter<Sale>
    {
        private int autoIncrementValue = 1;

        [NonSerialized]
        public ProductRepository prodRepo;

        [NonSerialized]
        public CustomerRepository custRepo;

        public string Identifier(Sale storable)
        {
            return storable.Id;
        }

        public virtual string DefineIdentifier(Sale storable)
        {
            storable.id = autoIncrementValue.ToString().PadLeft(6, '0');
            autoIncrementValue++;
            return Identifier(storable);
        }

        public Sale FromSerializedToPublic(Sale stored)
        {
            var cloned = (Sale)stored.Clone();
            cloned.Product = prodRepo.FindById(cloned.ProductId);

            var customer = custRepo.FindById(cloned.CustomerId);

            if (customer == null)
                customer = custRepo.DeadRecordsRepo().FindById(cloned.CustomerId);

            cloned.Customer = customer;

            return cloned;
        }
    }
}
