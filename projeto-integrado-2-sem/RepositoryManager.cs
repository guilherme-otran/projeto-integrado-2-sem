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

        public RepositoryManager()
        {
            this.userRepository = new UserRepository();
            try
            {
                this.userRepository.InitComponents();
            }
            catch (BaseRepository<User>.InvalidFile)
            {
                this.userRepository.InitializeFile();
            }
        }

        public UserRepository UserRepository()
        {
            return userRepository;
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
        }
    }
}
