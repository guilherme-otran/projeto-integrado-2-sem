using System;
using System.Linq;

namespace projeto_integrado_2_sem.Models
{
    public class User : IStorable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        
        public string Email { get; set; }

        public string currentPassword; // Beware! This is temporary and not stored!
        public string password;
        public string oldPassword;
        public DateTime passwordChangeDate;

        public DateTime BirthDate { get; set; }
        public Status status;

        public Profile Profile;

        public string ProfileName { get { return Profile.Name; } }

        public enum Status
        {
            ACTIVE=0,
            INACTIVE
        }

        string IStorable.id
        {
            get { return this.Id; }
            set { this.Id = value; }
        }

        public User()
        {
            this.Id = null;
            this.Email = null;
            this.password = null;
            this.Profile = null;
        }

        public User(string id, string email, string password, Profile profile)
        {
            this.Id = id;
            this.Email = email;
            this.password = password;
            this.Profile = profile;
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
