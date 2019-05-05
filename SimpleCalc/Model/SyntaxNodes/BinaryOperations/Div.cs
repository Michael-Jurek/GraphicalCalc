using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCalc.Model.SyntaxNodes.Interface;

namespace SimpleCalc.Model.SyntaxNodes.BinaryOperations
{
    public class Div: BinaryOperation
    {
        public Div()
        {

        }

        public Div(ISyntaxNode a, ISyntaxNode b) : base(a, b)
        {
        }

        public override string ToStringValue()
        {
            return "/";
        }

        public override double GetResult(double x)
        {
            return GetA().GetResult(x) / GetB().GetResult(x);
        }

        public override bool IsDomainOfFunction(double x)
        {
            if (GetA().IsDomainOfFunction(x) && GetB().IsDomainOfFunction(x) && GetB().GetResult(x) >= double.MinValue)
            {
                return true;
            }

            return false;
        }
    }
}
