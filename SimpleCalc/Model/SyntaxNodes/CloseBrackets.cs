using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCalc.Model.SyntaxNodes.Interface;

namespace SimpleCalc.Model.SyntaxNodes
{
    public class CloseBrackets: ISyntaxNode
    {
        public string ToStringValue()
        {
            return ")";
        }

        public double GetResult(double x)
        {
            return 0;
        }

        public bool IsDomainOfFunction(double x)
        {
            return true;
        }
    }
}
