using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public interface ICalculatorService
    {
        double Calculate(string input, char delimiter, List<Func<double[], string>> validations);
    }
}