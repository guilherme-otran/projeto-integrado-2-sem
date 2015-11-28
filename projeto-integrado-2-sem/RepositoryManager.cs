using projeto_integrado_2_sem.Models;
using projeto_integrado_2_sem.Repositories;

namespace projeto_integrado_2_sem
{
    public class RepositoryManager
    {
        public static RepositoryManager ManagerInstance;

        public static void InitManager()
        {
            ManagerInstance = new RepositoryManager();
            ManagerInstance.seedData();
        }

        public static void CloseManager()
        {
            ManagerInstance.closeAll();
        }

        public UserRepository userRepository;
        public CustomerRepository customerRepository;

        public RepositoryManager()
        {
            this.userRepository = new UserRepository();
            try
            {
                this.userRepository.InitComponents();
            }
            catch (UserRepository.InvalidFile)
            {
                this.userRepository.InitializeFile();
            }

            this.customerRepository = new CustomerRepository();
            try
            {
                this.customerRepository.InitComponents();
            }
            catch (CustomerRepository.InvalidFile)
            {
                this.customerRepository.InitializeFile();
            }
        }

        public UserRepository UserRepository()
        {
            return userRepository;
        }

        public CustomerRepository CustomerRepository()
        {
            return customerRepository;
        }

        public void seedData()
        {
            if (userRepository.Count() < 1)
            {
                var usr = new User();
                usr.Name = "Administrador";
                usr.Email = "admin@projeto.com";
                usr.Password = "hu3hu3";
                usr.PasswordChangeDate = System.DateTime.Now;
                usr.BirthDate = System.DateTime.Now.Date;
                usr.Profile = Profile.AdminProfile();
                userRepository.Persist(usr);

                usr = new User();
                usr.Name = "Usuario teste";
                usr.Email = "user@projeto.com";
                usr.Password = "hu3hu3";
                usr.PasswordChangeDate = System.DateTime.Now;
                usr.BirthDate = System.DateTime.Now.Date;
                usr.Profile = Profile.Operator();
                userRepository.Persist(usr);
            }
        }

        public void closeAll()
        {
            this.userRepository.Close();
            this.customerRepository.Close();
        }
    }
}
