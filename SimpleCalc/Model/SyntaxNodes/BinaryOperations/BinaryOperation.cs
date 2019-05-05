using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCalc.Model.SyntaxNodes.Interface;

namespace SimpleCalc.Model.SyntaxNodes.BinaryOperations
{
    public abstract class BinaryOperation: ISyntaxNode
    {
        private ISyntaxNode a;
        private ISyntaxNode b;

        public BinaryOperation()
        {

        }

        public BinaryOperation(ISyntaxNode a, ISyntaxNode b)
        {
            this.a = a;
            this.b = b;
        }

        public ISyntaxNode GetA()
        {
            return a;
        }

        public void SetA(ISyntaxNode a)
        {
            this.a = a;
        }

        public ISyntaxNode GetB()
        {
            return b;
        }

        public void SetB(ISyntaxNode b)
        {
            this.b = b;
        }

        public abstract string ToStringValue();
        public abstract double GetResult(double x);
        public abstract bool IsDomainOfFunction(double x);
    }
}
