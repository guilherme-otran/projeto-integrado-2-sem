using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem
{
    public class Profile
    {
        public bool CanViewDateCalculator;

        public static Profile AdminProfile()
        {
            var profile = new Profile();
            profile.CanViewDateCalculator = true;
            return profile;
        }
    }
}
