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
        public static IEnumerable<object[]> SingleWordDelimiterData =>
            new List<object[]>()
            {
                new object[] {"//[***]\\n11***22***33", true, new List<string>(){"***"}, "11***22***33"},
                new object[] {"//[***][##]\\n11***22***33", false, null, ""},
                new object[] {"//#\\n2#5", false, null, ""},
            };
        
        public static IEnumerable<object[]> MultiWordsDelimiterData =>
            new List<object[]>()
            {
                new object[] {"//[***]\\n11***22***33", true, new List<string>(){"***"}, "11***22***33"},
                new object[] {"//[*][!!][r9r]\\n11r9r22*hh*33!!44", true, new List<string>(){"*", "!!", "r9r"}, 
                    "11r9r22*hh*33!!44"},
                new object[] {"//[***]]\\n11***22***33", false, null, ""},
                new object[] {"//[[***]]\\n11***22***33", false, null, ""},
                new object[] {"//[[***]\\n11***22***33", false, null, ""},
            };
    }
}