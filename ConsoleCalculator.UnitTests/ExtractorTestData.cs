using System.Collections.Generic;

namespace ConsoleCalculator.UnitTests
{
    public class ExtractorTestData
    {
        public static IEnumerable<object[]> SingleCharacterDelimiterData =>
            new List<object[]>()
            {
                new object[] {"//#\\n2#5", true, new List<string>() {"#"}, "2#5"},
                new object[] {"//,\\n2,ff,100", true, new List<string>() {","}, "2,ff,100"},
                new object[] {"//##\\n2#5", false, null, ""}
            };
    }
}