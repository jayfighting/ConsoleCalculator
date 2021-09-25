using System;
using System.Collections.Generic;

namespace ConsoleCalculator.UnitTests
{
    public class ValidatorTestData
    {
        public static IEnumerable<object[]> MaxTwoNumberValidationData =>
            new List<object[]>
            {
                new object[]
                {
                    new double[] {0, 0},
                    new List<Func<double[], string>> {Validations.MaxTwoNumbersValidation},
                    new ValidateResult()
                },
                new object[]
                {
                    new double[] {0, 0, 0},
                    new List<Func<double[], string>> {Validations.MaxTwoNumbersValidation},
                    new ValidateResult(new List<string> {Errors.MoreThanTwoArgumentError})
                },
                new object[]
                {
                    new double[] {0, 0, 0},
                    new List<Func<double[], string>>(),
                    new ValidateResult()
                }
            };

        public static IEnumerable<object[]> NegativeNumberValidationData =>
            new List<object[]>
            {
                new object[]
                {
                    new double[] {-1, 0, 0, -2},
                    new List<Func<double[], string>> {Validations.NoNegativeNumberValidation},
                    new ValidateResult(new List<string> 
                        {string.Format(Errors.NegativeNumberArgumentError, "-1,-2")})
                },
                new object[]
                {
                    new double[] {-1, 0, 0},
                    new List<Func<double[], string>>(),
                    new ValidateResult(new List<string>())
                },
                new object[]
                {
                    new double[] {-1, 0, 0},
                    new List<Func<double[], string>>
                        {Validations.NoNegativeNumberValidation, Validations.MaxTwoNumbersValidation},
                    new ValidateResult(new List<string>
                        {Errors.MoreThanTwoArgumentError, {string.Format(Errors.NegativeNumberArgumentError,"-1")}})
                }
            };
    }
}