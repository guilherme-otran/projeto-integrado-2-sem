using projeto_integrado_2_sem.Models;
using projeto_integrado_2_sem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Interactors
{
    class LoginInteractor
    {
        public class InavlidUsernameOrPassword : ArgumentException { };

        private UserRepository userRepository;
        private string email;
        private string password;

        public LoginInteractor(string email, string password)
        {
            this.email = email;
            this.password = password;
            this.userRepository = RepositoryManager.ManagerInstance.UserRepository();
        }

        public User performCheck()
        {
            var user = userRepository.findByEmail(email);

            if (user == null || user.password != password)
                throw new InavlidUsernameOrPassword();

            return user;
        }
    }
}
