using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem
{
    public class User : IStorable<User>
    {
        public string id;
        public string email;
        public string password;
        public Profile Profile;

        public User()
        {
            this.id = null;
            this.email = null;
            this.password = null;
            this.Profile = null;
        }

        public User(string id, string email, string password, Profile profile)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.Profile = profile;
        }

        public string[] AsStringArray()
        {
            return new string[] { id, email, password };
        }

        public void FromStringArray(string[] data)
        {
            this.id = data[0];
            this.email = data[1];
            this.password = data[2];
        }

    }
}
