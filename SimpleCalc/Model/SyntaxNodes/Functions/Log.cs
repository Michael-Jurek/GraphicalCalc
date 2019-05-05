using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCalc.Model.SyntaxNodes.Interface;

namespace SimpleCalc.Model.SyntaxNodes.Functions
{
    public class Log: Function
    {
        public Log()
        {

        }

        public Log(ISyntaxNode x) : base(x)
        {
        }

        public override string ToStringValue()
        {
            return "log";
        }

        public override double GetResult(double x)
        {
            return Math.Log(GetX().GetResult(x));
        }

        public override bool IsDomainOfFunction(double x)
        {
            return GetX().IsDomainOfFunction(x);
        }
    }
}
