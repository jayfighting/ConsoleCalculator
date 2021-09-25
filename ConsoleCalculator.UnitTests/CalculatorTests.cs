using FluentAssertions;
using Xunit;

namespace ConsoleCalculator.UnitTests
{
    public class CalculatorTests
    {
        [Theory]
        [MemberData(nameof(CalculatorTestData.Data), MemberType = typeof(CalculatorTestData))]
        public void AddShouldAdd(double[] nums, double expected)
        {
            var sut = new Adder();
        
            var actual = sut.Execute(nums);
            actual.Should().Be(expected);
        }
    }
}