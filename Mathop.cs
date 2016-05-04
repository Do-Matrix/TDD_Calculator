using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Calculator
{
    class MathOp
    {
        public double Addition(double firstNum, double secondNum)
        {
            return firstNum + secondNum;
        }

        public double Subtraction(double firstNum, double secondNum)
        {
            return firstNum - secondNum;
        }

        public double Multiplication(double firstNum, double secondNum)
        {
            return firstNum * secondNum;
        }

        public double Division(double firstNum, double secondNum)
        {
            return firstNum / secondNum;
        }
    }
}
