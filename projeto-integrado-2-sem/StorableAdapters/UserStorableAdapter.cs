using projeto_integrado_2_sem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem
{
    class UserStorableAdapter : IStorableAdapter<User>
    {
        public const int EMAIL_INDEX = 0;

        public string Version()
        {
            return "0";
        }

        public int AttributeCount()
        {
            return 3;
        }

        public string[] AsStringArray(User storable)
        {
            string profileId = null;

            if (storable.Profile != null)
                profileId = storable.Profile.id;

            return new string[] { storable.email, storable.password, profileId };
        }

        public User FromStringArray(string identifier, string[] data)
        {
            if (data[2] == Profile.AdminProfile().id)
                return new User(identifier, data[0], data[1], Profile.AdminProfile());

            return new User(identifier, data[0], data[1], Profile.Operator());
        }

        public string Identifier(User storable)
        {
            return storable.id;
        }

        public string GenerateIdentifier(User storable)
        {
            storable.id = Math.Abs(DateTime.Now.Ticks).ToString("x");
            return Identifier(storable);
        }
    }
}
