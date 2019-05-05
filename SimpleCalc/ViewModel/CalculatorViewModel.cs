using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using SimpleCalc.Model;

namespace SimpleCalc.ViewModel
{
    public class CalculatorViewModel
    {
        private Model.Calculator _calc;


        private string display;
        private string lastOperation;
        private bool newDisplayRequired = false;

        public string FirstOperand
        {
            get { return _calc.FirstOperand; }
            set { _calc.FirstOperand = value; }
        }

        public string SecondOperand
        {
            get { return _calc.SecondOperand; }
            set { _calc.SecondOperand = value; }
        }

        public string Operation
        {
            get { return _calc.Operation; }
            set { _calc.Operation = value; }
        }

        public string LastOperation
        {
            get { return lastOperation; }
            set { lastOperation = value; }
        }

        public string Result
        {
            get { return _calc.Result; }
        }


        public string Display
        {
            get { return display; }
            set { display = value; }
        }

        public CalculatorViewModel()
        {
            this._calc = new Calculator();
            this.display = "0";
            this.FirstOperand = string.Empty;
            this.SecondOperand = string.Empty;
            this.Operation = string.Empty;
        }

        #region ButtonPressed


        #endregion

        #region Buttons

        // Buttons presed
        public void Button(string button)
        {
            switch (button)
            {
                case "C":
                    Display = "0";
                    FirstOperand = string.Empty;
                    SecondOperand = string.Empty;
                    Operation = string.Empty;
                    LastOperation = string.Empty;
                    break;
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
                case "CE":
                    if (FirstOperand == string.Empty)
                    {
                        Display = "0";
                    }
                    else
                    {
                        SecondOperand = "0";
                        Display = "0";
                    }                    
                    break;
                case "DEL":
                    if (display.Length > 1)
                    {
                        Display = display.Substring(0, display.Length - 1);
                    }
                    else Display = "0";
                    break;
                default:
                    break;
            }
        }

        // Digit buttons pressed
        public void DigitButton(string button)
        {
            if (display == "0" || newDisplayRequired)
            {
                Display = button;
            }
            else
            {
                Display = display + button;
            }

            newDisplayRequired = false;
        }

        // Operations + calculating result
        public void OperationButton(string button)
        {
            try
            {
                if (FirstOperand == string.Empty || LastOperation == "=")
                {
                    FirstOperand = display;
                    LastOperation = button;
                }
                else
                {
                    SecondOperand = display;
                    Operation = lastOperation;
                    _calc.CalculateResult();

                    LastOperation = button;
                    Display = Result;
                    FirstOperand = display;
                }

                newDisplayRequired = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Display = Result == string.Empty ? "ERROR - SEE EVENT LOG" : Result;
                throw;
            }
        }

        #endregion


        public void SingleOperationButton(string button)
        {
            try
            {
                if (display!="")
                {
                    _calc.CalculateSingleOperationResult(button, display);
                    Display = Result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
