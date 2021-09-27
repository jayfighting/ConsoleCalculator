using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleCalculator
{
    public class Adder : ICommand
    {
        public double Execute(double[] nums)
        {
            return nums.Sum();
        }

        public string ExecuteWithFormula(double[] nums)
        {
            return string.Join('+', nums) + " = " + Execute(nums);
        }
    }
}