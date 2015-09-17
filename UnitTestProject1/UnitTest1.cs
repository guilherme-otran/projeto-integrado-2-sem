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
        public void Testbissextile()
        {
            bool test = DateCalculator.bissextile(DateTime.Parse("2004-07-01 07:19:58.000"));
            Assert.AreEqual(true, test);
        }
        [TestMethod]
        public void TestjulianDay()
        {
            int test = DateCalculator.julianDay(04, 10, 1582);
            Assert.AreEqual(2299160, test);
        }
    }
}
