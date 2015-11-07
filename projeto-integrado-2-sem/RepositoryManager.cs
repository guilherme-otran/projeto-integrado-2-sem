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
                this.userRepository.initComponents();
            }
            catch (BaseRepository<User>.InvalidHeader)
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
                userRepository.persist(new User(null, "admin@projeto.com", "hu3hu3", Profile.AdminProfile()));
                userRepository.persist(new User(null, "user@projeto.com", "hu3hu3", Profile.Operator()));
            }
            // Perform an update
            // var user = userRepository.findById("8d2bc7bf8782a73");
            // user.password = "BRhu3";
            // userRepository.persist(user);
        }

        public void closeAll()
        {
            this.userRepository.close();
        }
    }
}
