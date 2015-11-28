using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projeto_integrado_2_sem.Models;
using System.IO;

namespace projeto_integrado_2_sem.Repositories
{
    class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository() :
            base(new BufferedStream(new FileStream("C:\\temp\\customers.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite)))
        {
        }

        public override void InitializeFile()
        {
            base.InitializeFile(new CustomerStorableAdapter());
        }
    }

}
