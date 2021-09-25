using System;
using System.Linq;

namespace ConsoleCalculator
{
    public static class Validations
    {
        public static readonly Func<double[], string> MaxTwoNumbersValidation =
            nums => nums.Length > 2 
                ? Errors.MoreThanTwoArgumentError 
                : string.Empty;

        public static readonly Func<double[], string> NoNegativeNumberValidation = nums =>
        {
            var lessThanZero = nums.Where(x => x < 0).ToList();
            return lessThanZero.Any() 
                ? string.Format(Errors.NegativeNumberArgumentError, string.Join(",", lessThanZero)) 
                : string.Empty;
        };
    }
}