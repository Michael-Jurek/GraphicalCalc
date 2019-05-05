using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCalc.Model.SyntaxNodes.Interface;

namespace SimpleCalc.Model.SyntaxNodes.UnaryOperations
{
    public class Neg: UnaryOperation
    {
        public Neg()
        {

        }

        public Neg(ISyntaxNode a) : base(a)
        {

        }

        public override string ToStringValue()
        {
            return "--";
        }

        public override double GetResult(double x)
        {
            return -GetA().GetResult(x);
        }

        public override bool IsDomainOfFunction(double x)
        {
            return GetA().IsDomainOfFunction(x);
        }
    }
}
