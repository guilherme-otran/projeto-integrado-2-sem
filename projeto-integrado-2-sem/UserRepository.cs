using projeto_integrado_2_sem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository() : 
            base(new UserStorableAdapter(), 
                 new BufferedStream(new FileStream("C:\\temp\\users.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)))
        {
        }

        public User findByEmail(string email)
        {
            return findByData(email, UserStorableAdapter.EMAIL_INDEX);
        }
    }
}
