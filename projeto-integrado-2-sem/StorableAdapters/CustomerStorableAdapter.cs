using projeto_integrado_2_sem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem
{
    [Serializable]
    class CustomerStorableAdapter : IStorableAdapter<Customer>
    {
        private int autoIncrementValue = 1;

        public int AttributeCount()
        {
            return 3;
        }

        public string Identifier(Customer storable)
        {
            return storable.Id;
        }

        public string DefineIdentifier(Customer storable)
        {
            storable.id = autoIncrementValue.ToString().PadLeft(6, '0');
            autoIncrementValue++;
            return Identifier(storable);
        }

        public Customer FromSerializedToPublic(Customer stored)
        {
            return (Customer)stored.Clone();
        }
    }
}
