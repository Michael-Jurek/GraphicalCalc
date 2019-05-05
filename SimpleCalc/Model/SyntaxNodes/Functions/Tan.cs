﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCalc.Model.SyntaxNodes.Interface;

namespace SimpleCalc.Model.SyntaxNodes.Functions
{
    public class Tan: Function
    {
        public Tan()
        {

        }

        public Tan(ISyntaxNode x) : base(x)
        {
        }

        public override string ToStringValue()
        {
            return "tan";
        }

        public override double GetResult(double x)
        {
            return Math.Tan(GetX().GetResult(x));
        }

        public override bool IsDomainOfFunction(double x)
        {
            return GetX().IsDomainOfFunction(x) && Math.Cos(x) != 0;
        }
    }
}
