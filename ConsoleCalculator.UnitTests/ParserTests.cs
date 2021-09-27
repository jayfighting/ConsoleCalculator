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
            var actual = sut.Parse(str, Config.Delimiters);

            actual.Should().BeEquivalentTo(excepted);
        }

        [Theory]
        [MemberData(nameof(ParserTestData.MaxCheckData), MemberType = typeof(ParserTestData))]
        public void MaxParserCanParseString(string str, double[] excepted)
        {
            var sut = new ParserWithMax(1000);
            var actual = sut.Parse(str, Config.Delimiters);

            actual.Should().BeEquivalentTo(excepted);
        }
    }
}