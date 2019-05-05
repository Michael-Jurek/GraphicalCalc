using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCalc.Model.SyntaxNodes.Interface;

namespace SimpleCalc.Model.SyntaxNodes.Functions
{
    public class Sin: Function
    {
        public Sin()
        {

        }

        public Sin(ISyntaxNode x) : base(x)
        {
        }

        public override string ToStringValue()
        {
            return "sin";
        }

        public override double GetResult(double x)
        {
            return Math.Sin(GetX().GetResult(x));
        }

        public override bool IsDomainOfFunction(double x)
        {
            return GetX().IsDomainOfFunction(x);
        }
    }
}
