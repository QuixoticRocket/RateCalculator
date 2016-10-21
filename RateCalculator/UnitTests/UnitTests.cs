using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    internal class BaseTest : LoanCalculator.Calculations.BaseCalculation
    {
        //used soley for access to the base class methods - we could do this in MOQ or somethign similar, but for speed's sake ...
    }

    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestCompoundCalculation()
        {
            BaseTest test = new BaseTest();
            decimal result = test.CalculateCompoundInterest(1500, Convert.ToDecimal((4.3 / 100)), 4, 6*12);

            Assert.AreEqual(string.Format("{0:N2}", result), "1,938.84"); 
            //a bit quick and dirty i'm afraid. we should truncate the decimal result and then compare that or compare it to a proper decimal output, but i'm going on a formula off the internet here.
        }
    }
}
