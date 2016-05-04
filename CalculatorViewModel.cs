using Microsoft.Practices.Prism.Commands;
using System.Windows.Input;
using System;
using System.ComponentModel;

namespace TDD_Calculator
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private Calculator calc;
        private DelegateCommand<string> calculateCommand;
        private DelegateCommand<string> digitButtonPressedCommand;
        private DelegateCommand<string> clearOperatorsCommand;

        private string display;
        private bool newDisplayRequired;
        private string lastOperation;



        #region Constructors
        public CalculatorViewModel()
        {
            calc = new Calculator();
            display = "0";
            FirstOperand = string.Empty;

        }
        #endregion

        #region Public Properties

        public string FirstOperand
        {
            get { return calc.FirstNumber; }
            set { calc.FirstNumber = value; }
        }
        public string Operation
        {
            get { return calc.MathOp; }
            set { calc.MathOp = value; }
        }

        public string SecondOperand
        {
            get { return calc.SecondNumber; }
            set { calc.SecondNumber = value; }
        }

        public ICommand CalculateCommand
        {
            get
            {
                if (calculateCommand == null)
                {
                    calculateCommand = new DelegateCommand<string>(OperationPress);
                }
                return calculateCommand;
            }

        }

        public ICommand DigitButtonPressedCommand
        {
            get
            {
                if (digitButtonPressedCommand == null)
                {
                    digitButtonPressedCommand = new DelegateCommand<string>(DigitPress);
                }
                return digitButtonPressedCommand;
            }
        }

        public ICommand ClearOperatorsCommand
        {
            get
            {
                if (clearOperatorsCommand == null)
                {
                    clearOperatorsCommand = new DelegateCommand<string>(ClearPress);
                }
                return clearOperatorsCommand;
            }
        }


        public string Result { get { return Convert.ToString(calc.Evaluate()); } }

        public string Display
        {
            get { return display; }
            set
            {
                display = value;
                OnPropertyChanged("Display");

            }
        }

        public string LastOperation
        {
            get { return lastOperation; }
            set { lastOperation = value; }

        }

        #endregion



        public void DigitPress(string button)
        {
            switch (button)
            {

                case ".":
                    if (newDisplayRequired)
                    {
                        Display = "0.";
                    }
                    else
                    {
                        if (!display.Contains("."))
                        {
                            Display = display + ".";
                        }
                    }
                    break;
                default:
                    if (display == "0" || newDisplayRequired)
                        Display = button;
                    else
                        Display = display + button;
                    break;
            }
        }

        public void OperationPress(string operation)
        {

            try
            {
                if (FirstOperand == string.Empty || LastOperation == "=")
                {
                    FirstOperand = display;
                    LastOperation = operation; //took out a this.
                }

                else
                {
                    SecondOperand = display;
                    Operation = lastOperation;
                    calc.Evaluate();


                    LastOperation = operation; //took out a this.
                    Display = Result;
                    FirstOperand = display;
                }
                newDisplayRequired = true;
            }
            catch (Exception ex)
            {
                Display = Result == string.Empty ? "Error - see event log" : Result;
            }

        }

        public void ClearPress(string clearOperator)
        {
            if (clearOperator == "C")
            {
                Display = "0";
                FirstOperand = String.Empty;
                SecondOperand = String.Empty;
                LastOperation = String.Empty;
                Operation = String.Empty;
            }
            if (clearOperator == "CE")
            {
                Display = "";
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
