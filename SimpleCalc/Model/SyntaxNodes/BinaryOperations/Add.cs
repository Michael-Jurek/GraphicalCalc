using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCalc.Model.SyntaxNodes.BinaryOperations;
using SimpleCalc.Model.SyntaxNodes.Interface;

namespace SimpleCalc.Model.SyntaxNodes.BinaryOperations
{
    public class Add: BinaryOperation
    {
        public Add()
        {
        }

        public Add(ISyntaxNode a, ISyntaxNode b) : base(a, b)
        {
        }

        public override string ToStringValue()
        {
            return "+";
        }

        public override double GetResult(double x)
        {
            return GetA().GetResult(x) + GetB().GetResult(x);
        }

        public override bool IsDomainOfFunction(double x)
        {
            return GetA().IsDomainOfFunction(x) && GetB().IsDomainOfFunction(x);
        }
    }
}
