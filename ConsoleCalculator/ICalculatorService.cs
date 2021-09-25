using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public interface ICalculatorService
    {
        double Calculate(string input, string[] delimiters, List<Func<double[], string>> validations);
    }
}