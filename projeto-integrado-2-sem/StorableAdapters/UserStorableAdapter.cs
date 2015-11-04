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
        public const int EMAIL_INDEX = 2;

        public string Version()
        {
            return "0";
        }

        public int AttributeCount()
        {
            return 9;
        }

        public string[] AsStringArray(User storable)
        {
            string profileId = null;

            if (storable.Profile != null)
                profileId = storable.Profile.id;

            return new string[] { 
                storable.code, 
                storable.name, 
                storable.email,
                storable.password, 
                storable.oldPassword, 
                storable.passwordChangeDate.ToBinary().ToString(), 
                storable.birthDate.ToBinary().ToString(), 
                storable.status.ToString(), 
                profileId 
            };
        }

        public User FromStringArray(string identifier, string[] data)
        {
            Profile prof = null;

            if (data[8] == Profile.AdminProfile().id)
                prof = Profile.AdminProfile();
            if (data[8] == Profile.Assistant().id)
                prof = Profile.Assistant();
            if (prof == null)
                prof = Profile.Operator();

            var user = new User();
            user.code = data[0];
            user.name = data[1];
            user.email = data[2];
            user.password = data[3];
            user.oldPassword = data[4];
            user.passwordChangeDate = DateTime.FromBinary(long.Parse(data[5]));
            user.birthDate = DateTime.FromBinary(long.Parse(data[6]));
            user.status = int.Parse(data[7]);
            user.Profile = prof;
            return user;
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
