using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Calculator
{
    class Calculator
    {
        MathOp operand = new MathOp();
        double result;

        string firstNumber;
        public string FirstNumber
        {
            get
            {
                return firstNumber;
            }
            set
            {
                firstNumber = value;
            }
        }

        string secondNumber;
        public string SecondNumber
        {
            get
            {
                return secondNumber;
            }
            set
            {
                secondNumber = value;
            }
        }

        string mathOp;
        public string MathOp
        {
            get
            {
                return mathOp;
            }
            set
            {
                mathOp = value;
            }
        }
        public double Evaluate()
        {
            switch (mathOp)
            {
                case "+":
                    result = operand.Addition(Convert.ToDouble(firstNumber), Convert.ToDouble(secondNumber));
                    break;
                case "-":
                    result = operand.Subtraction(Convert.ToDouble(firstNumber), Convert.ToDouble(secondNumber));
                    break;
                case "*":
                    result = operand.Multiplication(Convert.ToDouble(firstNumber), Convert.ToDouble(secondNumber));
                    break;
                case "/":
                    result = operand.Division(Convert.ToDouble(firstNumber), Convert.ToDouble(secondNumber));
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}

