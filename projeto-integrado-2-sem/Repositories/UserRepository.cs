using projeto_integrado_2_sem.Models;
using System.IO;

namespace projeto_integrado_2_sem.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository() : 
            base(new BufferedStream(new FileStream("C:\\temp\\users.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)))
        {
        }

        public User findByEmail(string email)
        {
            return findBy(user => user.Email == email);
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
