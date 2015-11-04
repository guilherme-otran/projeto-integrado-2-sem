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
            profile.id = "1";
            profile.CanViewDateCalculator = true;
            return profile;
        }

        public static Profile Operator()
        {
            var profile = new Profile();
            profile.id = "2";
            profile.CanViewDateCalculator = true;
            return profile;
        }
        public static Profile Assistant()
        {
            var profile = new Profile();
            profile.id = "3";
            profile.CanViewDateCalculator = false;
            return profile;
        }
    }
}
