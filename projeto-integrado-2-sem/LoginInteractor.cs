using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem
{
    class LoginInteractor
    {
        public class InavlidUsernameOrPassword : ArgumentException { };

        private string email;
        private string password;

        public LoginInteractor(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public User performCheck()
        {
            if (email != "admin" || password != "hu3hu3")
                throw new InavlidUsernameOrPassword();

            return new User("123456", "admin", "hu3hu3", Profile.AdminProfile());
        }
    }
}
