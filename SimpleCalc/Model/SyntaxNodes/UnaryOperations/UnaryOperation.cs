using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCalc.Model.SyntaxNodes.Interface;

namespace SimpleCalc.Model.SyntaxNodes.UnaryOperations
{
    public abstract class UnaryOperation: ISyntaxNode
    {
        private ISyntaxNode a;
        private bool isSetA;

        public UnaryOperation()
        {
            isSetA = false;
        }

        public UnaryOperation(ISyntaxNode a)
        {
            isSetA = true;
            this.a = a;
        }

        public ISyntaxNode GetA()
        {
            return this.a;
        }

        public void SetA(ISyntaxNode a)
        {
            this.a = a;
        }

        public bool IsSetA()
        {
            return isSetA;
        }

        public abstract string ToStringValue();
        public abstract double GetResult(double x);
        public abstract bool IsDomainOfFunction(double x);
    }
}
