﻿using projeto_integrado_2_sem.Models;
using System;

namespace projeto_integrado_2_sem
{
    [Serializable]
    class UserStorableAdapter : IStorableAdapter<User>
    {
        private int autoIncrementValue = 1;
        
        public string Identifier(User storable)
        {
            return storable.Id;
        }

        public string DefineIdentifier(User storable)
        {
            storable.id = autoIncrementValue.ToString().PadLeft(6, '0');
            autoIncrementValue++;
            return Identifier(storable);
        }

        public User FromSerializedToPublic(User stored)
        {
            stored = (User) stored.Clone();

            if (Profile.AdminProfile().id == stored.ProfileId)
                stored.Profile = Profile.AdminProfile();

            if (Profile.Assistant().id == stored.ProfileId)
                stored.Profile = Profile.Assistant();

            if (stored.Profile == null)
                stored.Profile = Profile.Operator();

            return stored;
        }
    }
}
