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
            bool test = DateCalculator.bissextile(2000);
            Assert.AreEqual(true, test);
        }
        [TestMethod]
        public void TestjulianDay()
        {
            int test = DateCalculator.julianDay(23, 09, 2015);
            Assert.AreEqual(2457289, test);
        }
    }
}
