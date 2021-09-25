using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleCalculator
{
    public class Validator : IValidator
    {
        public ValidateResult Validate(double[] nums, List<Func<double[], string>> validators)
        {
            ValidateResult result = new ValidateResult();
            
            foreach (var validator in validators)
            {
                result.Add(validator(nums));
            }

            return result;
        }
    }
}