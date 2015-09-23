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
        public void Testbissextile_when_is_bissextile()
        {
            bool test = DateCalculator.bissextile(2016);
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
