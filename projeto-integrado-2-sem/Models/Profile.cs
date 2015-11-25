using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Models
{
    public class Profile : IStorable, ICloneable
    {
        public string id { get; set; }
        public string Name { get; internal set; }

        public bool CanViewDateCalculator;
        public bool CanViewManagerUser;

        public static Profile AdminProfile()
        {
            var profile = new Profile();
            profile.id = "1";
            profile.CanViewDateCalculator = true;

            profile.CanViewManagerUser = true;
            profile.Name = "Admin";
            return profile;
        }

        public static Profile Operator()
        {
            var profile = new Profile();
            profile.id = "2";
            profile.CanViewDateCalculator = true;
            profile.CanViewManagerUser = false;
            profile.Name = "Operador";
            return profile;
        }
        public static Profile Assistant()
        {
            var profile = new Profile();
            profile.id = "3";
            profile.CanViewDateCalculator = false;
            profile.CanViewManagerUser = false;
            profile.Name = "Assistente";
            return profile;
        }

        public object Clone()
        {
            var copy = new Profile();
            copy.id = this.id;
            copy.Name = this.Name;
            return copy;
        }
    }
}
