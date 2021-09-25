using System;

namespace ConsoleCalculator
{
    public static class Validations
    {
        public static readonly Func<double[], string> MaxTwoNumbersValidation =
            nums => nums.Length > 2 
                ? Errors.MoreThanTwoArgumentError 
                : string.Empty;
    }
}