using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem
{
    class User : IStorable<User>
    {
        public string id;
        public string email;
        public string password;

        public User()
        {
            this.id = null;
            this.email = null;
            this.password = null;
        }

        public User(string id, string email, string password)
        {
            this.id = id;
            this.email = email;
            this.password = password;
        }

        public string[] AsStringArray()
        {
            return new string[] { id, email, password };
        }

        public static User FromStringArray(string[] data)
        {
            return new User(data[0], data[1], data[2]);
        }

    }
}
