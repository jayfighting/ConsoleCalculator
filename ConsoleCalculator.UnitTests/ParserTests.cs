using FluentAssertions;
using Xunit;

namespace ConsoleCalculator.UnitTests
{
    public class ParserTests
    {
        [Theory]
        [MemberData(nameof(ParserTestData.Data), MemberType = typeof(ParserTestData))]
        public void CanParseString(string str, double[] excepted)
        {
            var sut = new Parser();
            var actual = sut.Parse(str, ',');

            actual.Should().BeEquivalentTo(excepted);
        }
    }
}