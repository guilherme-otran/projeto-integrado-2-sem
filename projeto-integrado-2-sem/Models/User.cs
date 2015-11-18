﻿using System;
using System.ComponentModel;
using System.Linq;

namespace projeto_integrado_2_sem.Models
{
    [Serializable]
    public class User : IStorable
    {

        public string id;
        protected string name;
        protected string email;

        [NonSerializedAttribute]
        protected string currentPassword; // Beware! This is temporary and not stored!

        protected string password;
        protected string oldPassword;
        protected DateTime passwordChangeDate;

        protected DateTime birthDate;
        protected Status currentStatus;
        protected string profileId;

        [NonSerializedAttribute]
        protected Profile profile;

        // View
        public string Id { get { return id; } }
        public string Name { get { return name; } set { name = value; } }
        public string Email { get { return email; } set { email = value; } }

        [Browsable(false)]
        public string Password { get { return password; } set { password = value; } }
        [Browsable(false)]
        public string OldPassword { get { return oldPassword; } set { oldPassword = value; } }
        [Browsable(false)]
        public string CurrentPassword { get { return currentPassword; } set { currentPassword = value; } }

        public DateTime PasswordChangeDate { get { return passwordChangeDate; } set { passwordChangeDate = value; } }
        public DateTime BirthDate { get { return birthDate; } set { birthDate = value; } }
        public Status CurrentStatus { get { return currentStatus; } set { currentStatus = value; } }
        public string ProfileName { get { return profile.Name; } }

        [Browsable(false)]
        public Profile Profile
        {
            get { return profile; }
            set
            {
                profileId = value.id;
                profile = value;
            }
        }

        public enum Status
        {
            ACTIVE=0,
            INACTIVE
        }

        string IStorable.id
        {
            get { return this.Id; }
            set { this.id = value; }
        }

        public User()
        {
            this.id = null;
        }

        public string FirstName()
        {
            if (Name == null)
                return null;

            var splitted = Name.Trim().Split(' ');
            return splitted.FirstOrDefault();
        }

        public string NameInitials()
        {
            if (Name == null)
                return null;

            if (Name.Length == 0)
                return "";

            var splitted = Name.Trim().Split(' ').Select(part => part.First());
            return String.Join("", splitted).ToUpper();
        }

    }
}
