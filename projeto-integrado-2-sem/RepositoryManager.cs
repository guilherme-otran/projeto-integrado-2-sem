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
        public ProductRepository productRepository;
        public SaleRepository saleRepository;

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

            this.productRepository = new ProductRepository();
            try
            {
                this.productRepository.InitComponents();
            }
            catch (ProductRepository.InvalidFile)
            {
                this.productRepository.InitializeFile();
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

            this.saleRepository = new SaleRepository(productRepository, customerRepository);
            try
            {
                this.saleRepository.InitComponents();
            }
            catch (SaleRepository.InvalidFile)
            {
                this.saleRepository.InitializeFile();
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

        public ProductRepository ProductRepository()
        {
            return productRepository;
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

            if (productRepository.Count() < 1)
            {
                var prod = new Product();
                prod.Name = "Mouse";
                prod.Price = 15;
                prod.InventoryCount = 10;
                productRepository.Persist(prod);

                prod = new Product();
                prod.Name = "Teclado";
                prod.Price = 30;
                prod.InventoryCount = 8;
                productRepository.Persist(prod);
            }
        }

        public void closeAll()
        {
            this.userRepository.Close();
            this.customerRepository.Close();
            this.productRepository.Close();
        }
    }
}
