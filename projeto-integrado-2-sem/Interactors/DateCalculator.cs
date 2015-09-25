using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_integrado_2_sem.Interactors
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
                return DateTime.Today - born;
             }          
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

        public static bool bissextile(int year)
        {
            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                return true;
            else
                return false;
        }

        public static int julianDay(int day, int month, int year)
        {
            int jd; //JULIAN DATE
            int a, b, c, d, e; // variaveis da formula do dia juliano

            if (month < 3)
            {
                year = year - 1;
                month = month + 12;
            }

            a = year / 100;
            b = a / 4;

            if ( (year > 1582) || (month > 10 && year == 1582) ||(day >= 15 && month == 10 && year == 1582))
                c = 2 - a + b;
            else
                if (year < 1582 || (month < 10 && year == 1582) ||(day <= 04 && month == 10 && year == 1582))
                    c = 0;
                else
                    throw new NoJulianDay();

            d = (int)(365.25 * (year + 4716));
            e = (int)(30.6001 * (month + 1));

            jd = (int)(c + day + d + e - 1524);

            return jd;
        }

        public static string[] datesForIndex(int i)
        {
                switch (i)
                {
                    case 0:
                        return new string[] {
                        "Calendario Judaico: 15, Tevet, 5751",
                        "Calendario Muçulmano: 14, Jumada t-Tania, 1411",
                        "Calendario Chinês: 16, Ding-Chou, 4688 - Animal: Cavalo"};

                    case 1:
                        return new string[] {
                        "Calendario Judaico: 15, Elul, 5757",
                        "Calendario Muçulmano: 14, Jumada l-Ula, 1418",
                        "Calendario Chinês: 16, Ji-You, 4695 - Animal: Boi" };

                    case 2:
                        return new string[] {
                        "Calendario Judaico: 13, Elul, 5758 ",
                        "Calendario Muçulmano: 12, Jumada l-Ula, 1419",
                        "Calendario Chinês: 14, Xin-You, 4696 - Animal: Tigre" };

                    case 3:
                        return new string[] {
                        "Calendario Judaico: 6, Cheshvan, 5762",
                        "Calendario Muçulmano: 5, Sha'ban, 1422",
                        "Calendario Chinês: 7, Wu-Xu, 4699 - Animal: Cobra" };

                    case 4:
                        return new string[] {
                        "Calendario Judaico: 19, Tevet, 5767",
                        "Calendario Muçulmano: 19, Dhu I-Hijja, 1427",
                        "Calendario Chinês: 21, Ji-Chou, 4704 - Animal: Cachorro" };

                    case 5:
                        return new string[] {
                        "Calendario Judaico: 5, Iyar, 5771",
                        "Calendario Muçulmano: 5, Jumada t-Tania, 1432",
                        "Calendario Chinês: 7, Gui-Si, 4709 - Animal: Lebre" };

                    case 6:
                        return new string[] {
                        "Calendario Judaico: 1, Shevat, 5779",
                        "Calendario Muçulmano: 29, Rabi'ath-Thani, 1440",
                        "Calendario Chinês: 2, Gui-Chou, 4716 - Animal: Cachorro" };
                }
                return null;
            }
    }
}

