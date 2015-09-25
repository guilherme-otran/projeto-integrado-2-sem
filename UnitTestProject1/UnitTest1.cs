using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projeto_integrado_2_sem;
using projeto_integrado_2_sem.Interactors;

namespace UnitTestProject1
{
    [TestClass]
    public class DateCalculatorTest
    {
        [TestMethod]
        public void TestageCalc()
        {
            TimeSpan test = DateCalculator.ageCalc(new DateTime(1997, 9, 17));
            Assert.AreEqual(TimeSpan.Parse("6582:00:00:00"), test); //Testado dia 25/09/2015, para datas posteriores, calcular e mudar o parâmetro a ser enviado
        }
        [TestMethod]
        public void TestageCalc_When_birthdate_is_greater_than_current_date()
        {
            bool test;
            try 
            { 
                DateCalculator.ageCalc(new DateTime(2016, 1, 1));
                test = false;
            }
            catch (DateCalculator.InvalidBornDate) 
            { 
                test = true;
                Assert.AreEqual(true, test); 
            }
        }
        [TestMethod]
        public void TesttimeInterval()
        {
            TimeSpan test = DateCalculator.timeInterval(new DateTime(2014,01,01), new DateTime(2015,01,01));
            Assert.AreEqual(TimeSpan.Parse("365:00:00:00"),test);
        }
        [TestMethod]
        public void TestdateIncrease()
        {
            DateTime test = DateCalculator.dateIncrease(new DateTime(2014,01,01), TimeSpan.Parse("365:00:00:00"));
            Assert.AreEqual(new DateTime(2015, 01, 01), test);
        }
        [TestMethod]
        public void TestdateDecrease()
        {
            DateTime test = DateCalculator.dateDecrease(new DateTime(2014, 01, 01), TimeSpan.Parse("365:00:00:00"));
            Assert.AreEqual(new DateTime(2013, 01, 01), test);
        }
        [TestMethod]
        public void Testbissextile_when_is_bissextile_divisible_by_4_but_not_by_100()
        {
            bool test = DateCalculator.bissextile(2016);
            Assert.AreEqual(true, test);
        }
        [TestMethod]
        public void Testbissextile_when_is_bissextile_divisible_by_400()
        {
            bool test = DateCalculator.bissextile(2000);
            Assert.AreEqual(true, test);
        }
        [TestMethod]
        public void Testbissextile_when_is_not_bissextile()
        {
            bool test = DateCalculator.bissextile(2015);
            Assert.AreEqual(false, test);
        }

        [TestMethod]
        public void TestjulianDay_when_month_is_less_than_3()
        {
            int test = DateCalculator.julianDay(23, 01, 2015);
            Assert.AreEqual(2457046, test);
        }

        [TestMethod]
        public void TestjulianDay_when_month_is_greater_than_3()
        {
            int test = DateCalculator.julianDay(23, 09, 2015);
            Assert.AreEqual(2457289, test);
        }

        [TestMethod]
        public void TestjulianDay_when_year_is_greater_than_1582()
        {
            int test = DateCalculator.julianDay(23, 09, 2015);
            Assert.AreEqual(2457289, test);
        }
        [TestMethod]
        public void TestjulianDay_when_year_is_less_than_1582()
        {
            int test = DateCalculator.julianDay(23, 09, 1581);
            Assert.AreEqual(2298784, test);
        }
        [TestMethod]
        public void TestjulianDay_when_year_is_1582_and_month_greater_than_10()
        {
            int test = DateCalculator.julianDay(23, 11, 1582);
            Assert.AreEqual(2299200, test);
        }
        [TestMethod]
        public void TestjulianDay_when_year_is_1582_and_month_less_than_10()
        {
            int test = DateCalculator.julianDay(23, 09, 1582);
            Assert.AreEqual(2299149, test);
        }
        [TestMethod]
        public void TestjulianDay_when_year_is_1582_and_month_is_10_and_day_is_15()
        {
            int test = DateCalculator.julianDay(15, 10, 1582);
            Assert.AreEqual(2299161, test);
        }
        [TestMethod]
        public void TestjulianDay_when_year_is_1582_and_month_is_10_and_day_is_4()
        {
            int test = DateCalculator.julianDay(4, 10, 1582);
            Assert.AreEqual(2299160, test);
        }
        [TestMethod]
        public void TestjulianDay_when_year_is_1582_and_month_is_10_and_day_is_7()
        {

            var test = false;
            try
            {
                DateCalculator.julianDay(7, 10, 1582);
            } catch (DateCalculator.NoJulianDay)
            {
                test = true;
            }
            Assert.AreEqual(true, test);
        }

    }
}
