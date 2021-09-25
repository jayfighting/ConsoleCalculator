using System.Collections.Generic;

namespace ConsoleCalculator.UnitTests
{
    public class ParserTestData
    {
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {"", new double[]{0}},
                new object[] {",", new double[]{0, 0}},
                new object[] {"5,tytyt", new double[]{5, 0}},
            };
    }
}