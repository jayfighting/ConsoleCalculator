using System;
using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace ConsoleCalculator.UnitTests
{
    public class ValidatorTests
    {
        [Theory]
        [MemberData(nameof(ValidatorTestData.MaxTwoNumberValidationData), MemberType = typeof(ValidatorTestData))]
        public void MaxTwoNumsValidationShouldValidate(double[] nums, 
            List<Func<double[], string>> validations,
            ValidateResult expected)
        {
            var sut = new Validator();
            var actual = sut.Validate(nums, validations);

            using (new AssertionScope())
            {
                actual.Passed.Should().Be(expected.Passed);
                actual.ValidationErrors.Should().BeEquivalentTo(expected.ValidationErrors);
            }
        }
    }
}