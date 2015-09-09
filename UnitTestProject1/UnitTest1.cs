using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using projeto_integrado_2_sem;

namespace UnitTestProject1
{
    [TestClass]
    public class DateCalculatorTest
    {
        [TestMethod]
        public void Testbissextile()
        {
            bool test = DateCalculator.bissextile(DateTime.Parse("2004-01-01T00:00:00Z"));
            Assert.AreEqual(true, test);
        }
    }
}
