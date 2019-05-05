using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCalc.Model.SyntaxNodes.Interface;

namespace SimpleCalc.Model.SyntaxNodes.Functions
{
    public class Ctg: Function
    {
        public Ctg()
        {

        }

        public Ctg(ISyntaxNode x) : base(x)
        {
        }

        public override string ToStringValue()
        {
            return "cotg";
        }

        public override double GetResult(double x)
        {
            return 1 / Math.Tan(GetX().GetResult(x));
        }

        public override bool IsDomainOfFunction(double x)
        {
            return GetX().IsDomainOfFunction(x);
        }
    }
}
