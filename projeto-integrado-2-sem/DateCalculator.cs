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
        public class NoJulianDay : ArgumentException { }; //Periodo de 04/10/1582 a 15/10/1582 quando segundo a reforma papal (sim, sempre o papa huehue), tomou como dia seguinte de 04/10/1852 (calendario juliano) o dia 15/10/1852 (calendario gregoriano).

        public static TimeSpan ageCalc(DateTime born) 
        {
            if (born > DateTime.Today)
                throw new InvalidBornDate();
            else
            {
               
            }
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

        public static int julianDay(int day, int month, int year)
        {
            int jd;
            int a, b, c, d, e;

            if (month < 3)
            {
                year = year - 1;
                month = month + 12;
            }

            a = year / 100;
            b = a / 4;

            if (day >= 15 && month >= 10 && year >= 1582)
                c = 2 - a + b;
            else
                if (day <= 04 && month <= 10 && year <= 1582)
                    c = 0;
                else
                    throw new NoJulianDay();

            d = (int)(365.25 * (year + 4716));
            e = (int)(30.6001 * (month + 1));

            jd = (int)(c + day + d + e + 0.5 - 1524.5);

            return jd;
        }

    }
}

