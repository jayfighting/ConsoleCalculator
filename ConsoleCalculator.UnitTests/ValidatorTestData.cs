using System;
using System.Collections.Generic;

namespace ConsoleCalculator.UnitTests
{
    public class ValidatorTestData
    {
        public static IEnumerable<object[]> MaxTwoNumberValidationData =>
            new List<object[]>
            {
                new object[] {new double[] {0, 0}, 
                    new List<Func<double[], string>> {Validations.MaxTwoNumbersValidation},
                    new ValidateResult()},
                new object[] {new double[] {0, 0, 0}, 
                    new List<Func<double[], string>> {Validations.MaxTwoNumbersValidation},
                    new ValidateResult(new List<string>(){Errors.MoreThanTwoArgumentError})
                    },
                new object[] {new double[] {0, 0, 0}, 
                    new List<Func<double[], string>>(),
                    new ValidateResult()
                    },
            };
    }
}