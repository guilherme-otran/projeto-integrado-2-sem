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

        public void performCheck()
        {
            if (email != "admin" || password != "hu3hu3")
                throw new InavlidUsernameOrPassword();
        }
    }
}
