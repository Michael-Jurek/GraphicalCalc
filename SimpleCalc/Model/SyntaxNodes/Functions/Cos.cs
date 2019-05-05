using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCalc.Model.SyntaxNodes.Interface;

namespace SimpleCalc.Model.SyntaxNodes.Functions
{
    public class Cos: Function
    {
        public Cos()
        {

        }

        public Cos(ISyntaxNode x) : base(x)
        {
        }

        public override string ToStringValue()
        {
            return "cos";
        }

        public override double GetResult(double x)
        {
            return Math.Cos(GetX().GetResult(x));
        }

        public override bool IsDomainOfFunction(double x)
        {
            return GetX().IsDomainOfFunction(x);
        }
    }
}
