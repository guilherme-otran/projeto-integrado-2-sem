using System;
using System.Linq;

namespace projeto_integrado_2_sem.Models
{
    public class User : IStorable
    {
        public string id;

        public string code;
        public string name;
        
        public string email;

        public string password;
        public string oldPassword;
        public DateTime passwordChangeDate;

        public DateTime birthDate;
        public Status status;

        public Profile Profile;

        public enum Status
        {
            ACTIVE=0,
            INACTIVE
        }

        string IStorable.id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public User()
        {
            this.id = null;
            this.email = null;
            this.password = null;
            this.Profile = null;
        }

        public User(string id, string email, string password, Profile profile)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.Profile = profile;
        }

        public string FirstName()
        {
            if (name == null)
                return null;

            var splitted = name.Trim().Split(' ');
            return splitted.FirstOrDefault();
        }

        public string NameInitials()
        {
            if (name == null)
                return null;

            if (name.Length == 0)
                return "";

            var splitted = name.Trim().Split(' ').Select(part => part.First());
            return String.Join("", splitted).ToUpper();
        }

    }
}
