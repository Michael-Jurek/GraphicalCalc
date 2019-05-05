using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalc.Model.SyntaxNodes.Interface
{
    public interface ISyntaxNode
    {
        // returns symbol for element
        string ToStringValue();
        // return result for element
        double GetResult(double x);
        // checks if value of x belongs to the domain of definition of the element
        bool IsDomainOfFunction(double x);
    }
}
