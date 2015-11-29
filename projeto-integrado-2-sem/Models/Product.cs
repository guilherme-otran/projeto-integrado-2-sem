using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Models
{
    [Serializable]
    public class Product : IStorable, ICloneable
    {
        public string id;
        private string name;
        private int inventoryCount;

        // View
        public string Id { get { return id; } }
        public string Name { get { return name; } set { name = value; } }
        public int InventoryCount { get { return inventoryCount; } set { inventoryCount = value; } }

        string IStorable.id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        
        public object Clone()
        {
            var product = new Product();
            product.id = this.id;
            product.name = this.name;
            product.inventoryCount = this.inventoryCount;

            return product;
        }
    }
}
