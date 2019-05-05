using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCalc.Model.SyntaxNodes.Interface;

namespace SimpleCalc.Model.SyntaxNodes
{
    public class X: ISyntaxNode
    {
        public string ToStringValue()
        {
            return "x";
        }

        public double GetResult(double x)
        {
            return x;
        }

        public bool IsDomainOfFunction(double x)
        {
            return true;
        }
    }
}
