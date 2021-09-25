using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class Parser : IParser
    {
        public double[] Parse(string s, char delimiter)
        {
            var result = new List<double>();
            
            var nums = s.Split(delimiter);

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