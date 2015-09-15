using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Models
{
    public class User : IStorable
    {
        public string id;

        public string email;
        public string password;
        public Profile Profile;

        string IStorable.id
        {
            get { return this.id; }
            set { this.id = value; }
        }

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

    }
}
