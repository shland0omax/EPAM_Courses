using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewtonLL;

namespace NewtonLLTests
{
    [TestClass]
    public class NewtonMethodTests
    {
        [TestMethod]
        public void Execute_Sqrt4_2Expected()
        {
            double a = NewtonMethod.Execute(4, 2, double.Epsilon);
            Assert.AreEqual(a, 2.0);
        }

        [TestMethod]
        public void Execute_4PowNeg2_05Expected()
        {
            double a = NewtonMethod.Execute(4, -2, double.Epsilon);
            Assert.AreEqual(a, 0.5);
        }

        [TestMethod]
        public void Execute_Neg4PowNeg2_NaNExpected()
        {
            double a = NewtonMethod.Execute(-4, -2);
            Assert.AreEqual(a, double.NaN);
        }

        [TestMethod]
        public void Execute_Neg27Pow3_Neg3Expected()
        {
            double a = NewtonMethod.Execute(-27, 3, double.Epsilon);
            Assert.AreEqual(a, -3);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void Execute_NaN_ExceptionExpected()
        {
            double a = NewtonMethod.Execute(double.NaN, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Execute_EpsNaN_ExceptionExpected()
        {
            double a = NewtonMethod.Execute(22, 3, double.NaN);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Execute_EpsLessThen0_ExceptionExpected()
        {
            double a = NewtonMethod.Execute(22, 3, -1);
        }
    }
}
