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
        private int amount;
        private Decimal? price;

        // View
        public string Id { get { return id; } }
        [System.ComponentModel.DisplayName("Nome")]
        public string Name { get { return name; } set { name = value; } }
        [System.ComponentModel.DisplayName("Qtd. Disponível")]
        public int Amount { get { return amount; } set { amount = value; } }
        [System.ComponentModel.DisplayName("Preço")]
        public Decimal? Price { get { return price; } set { price = value; } }

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
            product.amount = this.amount;
            product.price = this.price;

            return product;
        }
    }
}
