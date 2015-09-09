using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem
{
    public class DateCalculator
    {
        public class InvalidBornDate : ArgumentException { };

        public static TimeSpan ageCalc(DateTime born) {
            if (born > DateTime.Today)
                throw new InvalidBornDate();
            else
                return DateTime.Today - born; 
        }

        public static TimeSpan timeInterval(DateTime inic, DateTime fin)
        {
            return fin - inic;
        }

        public static DateTime dateIncrease(DateTime dateCurrent, TimeSpan period)
        {
            return dateCurrent + period;
        }

        public static DateTime dateDecrease(DateTime dateCurrent, TimeSpan period)
        {
            return dateCurrent - period;
        }

        public static bool bissextile(DateTime date)
        {
            if (date.Year % 4 == 0 && date.Year % 100 != 0)
                return true;
            else
                return false;
        }


    }
}

