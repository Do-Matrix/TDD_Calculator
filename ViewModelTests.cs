using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;


namespace TDD_Calculator
{
    /// <summary>
    /// Summary description for TDD_ViewModelTests
    /// </summary>
    [TestFixture]
    public class TDD_ViewModelTests
    {
        [Test]
        public void CanCreateViewModel()
        {
            CalculatorViewModel viewModel = new CalculatorViewModel();
        }

        [Test]
        public void CanInputFirstOperand()
        {
            CalculatorViewModel viewModel = new CalculatorViewModel();
            viewModel.FirstOperand = "1";
            Assert.AreEqual("1", viewModel.FirstOperand);
        }

        [Test]
        public void CanExecuteCalculateCommand()
        {
            CalculatorViewModel viewModel = new CalculatorViewModel();
            ICommand command = viewModel.CalculateCommand;
            command.Execute(null);
        }

        [Test]
        public void CanCalculateTwoPlusTwo()
        {
            CalculatorViewModel viewModel = new CalculatorViewModel();
            viewModel.FirstOperand = "2";
            viewModel.Display = "2";
            ICommand command = viewModel.CalculateCommand;
            viewModel.LastOperation = "+";
            viewModel.Operation = "=";
            command.Execute(null);
            Assert.AreEqual(4, Convert.ToDouble(viewModel.Display));
        }

        [Test]
        public void CanCalculateFiveTimesSeven()
        {
            CalculatorViewModel viewModel = new CalculatorViewModel();
            viewModel.FirstOperand = "5";
            viewModel.Display = "7";
            ICommand command = viewModel.CalculateCommand;
            viewModel.LastOperation = "*";
            viewModel.Operation = "=";
            command.Execute(null);
            Assert.AreEqual(35, Convert.ToDouble(viewModel.Display));
        }
        [Test]
        public void ResultChangeNotificationIsFired()
        {
            CalculatorViewModel viewModel = new CalculatorViewModel();
            bool hasFired = false;
            viewModel.PropertyChanged +=(sender, args) =>
            {
                if (args.PropertyName == "Display")
                    hasFired = true;
            };
            viewModel.FirstOperand = "5";
            viewModel.Display = "7";
            ICommand command = viewModel.CalculateCommand;
            viewModel.LastOperation = "*";
            viewModel.Operation = "=";
            command.Execute(null);
            Assert.IsTrue(hasFired);
        }
    }
}
