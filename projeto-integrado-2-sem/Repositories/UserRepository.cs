using projeto_integrado_2_sem.Models;

namespace projeto_integrado_2_sem.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository() : base("users.dat")
        {
        }

        public User findByEmail(string email)
        {
            return FindBy(user => user.Email == email);
        }

        public override void InitializeFile()
        {
            base.InitializeFile(new UserStorableAdapter());
        }

        public override void Persist(User record)
        {
            if (record.CurrentPassword != null)
                record.OldPassword = record.CurrentPassword;

            record.CurrentPassword = null;

            base.Persist(record);
        }
    }
}
