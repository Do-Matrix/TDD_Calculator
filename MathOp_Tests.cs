using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TDD_Calculator
{
    [TestFixture]
    class TDDCalc_MathOp_Test
    {
        #region MasterTests
        [Test]
        public void Instantiation_test()
        {
            MathOp calcTest = new MathOp();
        }
        public void Addition_test(double firstnum, double secondnum, double expected)
        {
            MathOp calcTest = new MathOp();
            double answer = calcTest.Addition(firstnum, secondnum);
            Assert.AreEqual(expected, answer);
        }
        public void Subtraction_test(double firstnum, double secondnum, double expected)
        {
            MathOp calcTest = new MathOp();
            double answer = calcTest.Subtraction(firstnum, secondnum);
            Assert.AreEqual(expected, answer);
        }
        public void Multiplication_test(double firstnum, double secondnum, double expected)
        {
            MathOp calcTest = new MathOp();
            double answer = calcTest.Multiplication(firstnum, secondnum);
            Assert.AreEqual(expected, answer);
        }
        public void Division_test(double firstnum, double secondnum, double expected)
        {
            MathOp calcTest = new MathOp();
            double answer = calcTest.Division(firstnum, secondnum);
            Assert.AreEqual(expected, answer);
        }
        #endregion

        #region AdditionTests
        [Test]
        public void Addition1()
        {
            Addition_test(1, 1, 2);
        }
        #endregion

        #region SubtrationTests
        [Test]
        public void Subtraction1()
        {
            Subtraction_test(1, 1, 0);
        }
        #endregion

        #region MultiplicationTests
        [Test]
        public void Multiplication1()
        {
            Multiplication_test(2, 23, 46);
        }
        #endregion

        #region DivisionTests
        [Test]
        public void Division1()
        {
            Division_test(1, 10, 0.1);
        }
        [Test]
        public void Division2()
        {
            Division_test(1, 16, 0.0625);
        }
        #endregion
    }
}
