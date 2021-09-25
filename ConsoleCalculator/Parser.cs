using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Parser : IParser
    {
        private string[] _delimiters { get; }
        public Parser(string[] delimiters)
        {
            _delimiters = delimiters;
        }

        public virtual double[] Parse(string s)
        {
            var result = new List<double>();

            var nums = s.Split(_delimiters, StringSplitOptions.None);

            foreach (var num in nums)
            {
                if (double.TryParse(num, out var dNum))
                {
                    result.Add(dNum);
                }
                else
                {
                    result.Add(0);
                }
            }

            return result.ToArray();
        }
    }
}