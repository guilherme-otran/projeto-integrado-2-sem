using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projeto_integrado_2_sem.Models;
using System.IO;

namespace projeto_integrado_2_sem.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository() : base("products.dat") { }

        public override void InitializeFile()
        {
            base.InitializeFile(new ProductStorableAdapter());
        }
    }

}
