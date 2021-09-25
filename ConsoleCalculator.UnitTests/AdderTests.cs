using FluentAssertions;
using Xunit;

namespace ConsoleCalculator.UnitTests
{
    public class AdderTests
    {
        [Theory]
        [MemberData(nameof(AdderTestData.Data), MemberType = typeof(AdderTestData))]
        public void AddShouldAdd(double[] nums, double expected)
        {
            var sut = new Adder();
        
            var actual = sut.Execute(nums);
            actual.Should().Be(expected);
        }
    }
}