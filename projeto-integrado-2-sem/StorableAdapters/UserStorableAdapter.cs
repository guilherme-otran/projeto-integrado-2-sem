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
        public const int EMAIL_INDEX = 1;

        public string Version()
        {
            return "2";
        }

        public int AttributeCount()
        {
            return 8;
        }

        public string[] AsStringArray(User storable)
        {
            string profileId = null;

            if (storable.Profile != null)
                profileId = storable.Profile.id;

            return new string[] { 
                storable.Name, 
                storable.Email,
                storable.password, 
                storable.oldPassword, 
                storable.passwordChangeDate.ToBinary().ToString(), 
                storable.BirthDate.ToBinary().ToString(), 
                ((int)storable.status).ToString(), 
                profileId 
            };
        }

        public User FromStringArray(string identifier, string[] data)
        {
            Profile prof = null;

            if (data[7] == Profile.AdminProfile().id)
                prof = Profile.AdminProfile();
            if (data[7] == Profile.Assistant().id)
                prof = Profile.Assistant();
            if (prof == null)
                prof = Profile.Operator();

            var user = new User();
            user.Id = identifier;
            user.Name = data[0];
            user.Email = data[1];
            user.password = data[2];
            user.oldPassword = data[3];
            user.passwordChangeDate = DateTime.FromBinary(long.Parse(data[4]));
            user.BirthDate = DateTime.FromBinary(long.Parse(data[5]));
            user.status = (User.Status) int.Parse(data[6]);
            user.Profile = prof;
            return user;
        }

        public string Identifier(User storable)
        {
            return storable.Id;
        }

        public string DefineIdentifier(User storable, int autoIncrementValue)
        {
            storable.Id = autoIncrementValue.ToString().PadLeft(6, '0');
            return Identifier(storable);
        }
    }
}
