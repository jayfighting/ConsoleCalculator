using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Parser : IParser
    {
        public virtual double[] Parse(string s, string[] delimiters)
        {
            var result = new List<double>();

            var nums = s.Split(delimiters, StringSplitOptions.None);

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