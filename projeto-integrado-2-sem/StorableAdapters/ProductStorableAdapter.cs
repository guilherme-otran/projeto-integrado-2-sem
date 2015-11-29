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
    public class ProductStorableAdapter : IStorableAdapter<Product>
    {
        private int autoIncrementValue = 1;

        public string Identifier(Product storable)
        {
            return storable.Id;
        }

        public virtual string DefineIdentifier(Product storable)
        {
            storable.id = autoIncrementValue.ToString().PadLeft(6, '0');
            autoIncrementValue++;
            return Identifier(storable);
        }

        public Product FromSerializedToPublic(Product stored)
        {
            return (Product)stored.Clone();
        }
    }
}
