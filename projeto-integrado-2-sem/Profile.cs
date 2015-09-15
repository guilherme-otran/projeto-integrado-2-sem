using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Models
{
    public class Profile : IStorable
    {
        public string id { get; set; }
        public bool CanViewDateCalculator;

        public static Profile AdminProfile()
        {
            var profile = new Profile();
            profile.id = "1234";
            profile.CanViewDateCalculator = true;
            return profile;
        }

        public static Profile UserProfile()
        {
            var profile = new Profile();
            profile.id = "4321";
            profile.CanViewDateCalculator = false;
            return profile;
        }
    }
}
