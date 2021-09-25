using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleCalculator
{
    public class Validator : IValidator
    {
        private readonly List<Func<double[], string>> _validators;

        public Validator(List<Func<double[], string>> validators)
        {
            _validators = validators;
        }
        public ValidateResult Validate(double[] nums)
        {
            ValidateResult result = new ValidateResult();
            
            foreach (var validator in _validators)
            {
                result.Add(validator(nums));
            }

            return result;
        }
    }
}