using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalc.Model.Validators
{
    public class DataValidator
    {
        public string ValidateOperand(string operand)
        {
            try
            {
                Convert.ToDouble(operand);
                return "";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Invalid operand: " + operand;
            }
        }

        public string ValidateOperation(string operation, string[] operations)
        {
            if (!operations.Contains(operation))
            {
                    return "Unknown operation: " + operation;
                }
            else
            {
                Console.WriteLine("Operation: " + operation);
                return "";
            }
            
        }
    }
}
