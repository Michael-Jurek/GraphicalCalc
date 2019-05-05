using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SimpleCalc.Model.Validators;

namespace SimpleCalc.Model
{
    public class Calculator
    {

        private string result;
        public string FirstOperand { get; set; }
        public string SecondOperand { get; set; }
        public string Operation { get; set; }

        public string[] Operations { get; } = new string[]{"+","-","*","/","√"};


        public string Result
        {
            get { return result; }
        }

        DataValidator validator = new DataValidator();


        #region Constructors


        public Calculator()
        {
            FirstOperand = string.Empty;
            SecondOperand = string.Empty;
            Operation = string.Empty;
            result = string.Empty;
        }

        public Calculator(string firstOperand, string operation)
        {
            string pom = "";
            pom = validator.ValidateOperand(firstOperand);
            pom = validator.ValidateOperation(operation, Operations);

            if (pom != "")
            {
                result = pom;
            }

            FirstOperand = firstOperand;
            SecondOperand = string.Empty;
            Operation = operation;
            result = string.Empty;
        }

        public Calculator(string firstOperand, string secondOperand, string operation)
        {
            string pom = "";
            pom = validator.ValidateOperand(firstOperand);
            pom = validator.ValidateOperand(secondOperand);
            pom = validator.ValidateOperation(operation, Operations);

            if (pom != "")
            {
                result = pom;
            }

            FirstOperand = firstOperand;
            SecondOperand = secondOperand;
            Operation = operation;
            result = string.Empty;
        }

        #endregion

        #region CountingResults

        public void CalculateResult()
        {
            try
            {
                var pom = "";

                pom = validator.ValidateOperand(FirstOperand);
                pom = validator.ValidateOperand(SecondOperand);
                pom = validator.ValidateOperation(Operation, Operations);
                if (pom != "")
                {
                    result = pom;
                }

                switch (Operation)
                {
                    case "+":
                        result = (Convert.ToDouble(FirstOperand) + Convert.ToDouble(SecondOperand)).ToString();
                        break;
                    case "-":
                        result = (Convert.ToDouble(FirstOperand) - Convert.ToDouble(SecondOperand)).ToString();
                        break;
                    case "*":
                        result = (Convert.ToDouble(FirstOperand) * Convert.ToDouble(SecondOperand)).ToString();
                        break;
                    case "/":
                        result = (Convert.ToDouble(FirstOperand) / Convert.ToDouble(SecondOperand)).ToString();
                        break;
                }
            }
            catch (Exception e)
            {
                result = "ERROR occured ...";
                Console.WriteLine(e.Message);
            }
        }

        public void CalculateSingleOperationResult(string operation, string display)
        {
            try
            {
                switch (operation)
                {
                    case "√":
                        result = (Math.Sqrt(Convert.ToDouble(display))).ToString();
                        break;
                    case "%":
                        result = (Convert.ToDouble(display) / 100).ToString();
                        break;
                    case "x²":
                        result = (Math.Pow(Convert.ToDouble(display),2.0)).ToString();
                        break;
                    case "1/x":
                        result = (1 / Convert.ToDouble(display)).ToString();
                        break;
                    case "sin":
                        result = (Math.Sin(Convert.ToDouble(display))).ToString();
                        break;
                    case "cos":
                        result = (Math.Cos(Convert.ToDouble(display))).ToString();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion
    }
}
