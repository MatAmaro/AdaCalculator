﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaCalculator
{
    public class Calculator : ICalculator
    {
        public (string operation, double result) Calculate(string operation, double a, double b)
        {
            (string operation, double result) resultOperation;
            double c;
            switch (operation)
            {
                case "divide":
                    if (b == 0)
                        throw new DivideByZeroException();
                    c = Math.Round(a / b, 2);
                    break;
                case "multiply":
                    c = a * b;
                    break;
                case "subtract":
                    c = a - b;
                    break;
                case "sum":
                    c = a + b;
                    break;
                default:
                    throw new ArgumentException();
            }
            resultOperation = (operation, c);
            return resultOperation;
        }
    }
}