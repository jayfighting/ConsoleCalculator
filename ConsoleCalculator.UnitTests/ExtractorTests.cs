using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace ConsoleCalculator.UnitTests
{
    public class ExtractorTests
    {
        [Theory]
        [MemberData(nameof(ExtractorTestData.SingleCharacterDelimiterData), MemberType = typeof(ExtractorTestData))]
        public void SingleCharacterDelimiterExtractorShouldExtract(string s, bool isSuccess, List<string> delimiters, string input)
        {
            var sut = new SingleCharacterExtractor();
            var isSuccessful = sut.TryExtract(s, out var actualDelimiter, out var actualInput);

            using (new AssertionScope())
            {
                isSuccessful.Should().Be(isSuccess);
                actualDelimiter.Should().BeEquivalentTo(delimiters);
                actualInput.Should().Be(input);
            }
        }
    }
}