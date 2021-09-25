using System.Collections.Generic;

namespace ConsoleCalculator.UnitTests
{
    public class AdderTestData
    {
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {new double[] {20}, 20},
                new object[] {new double[] {1, 5000}, 5001},
                new object[] {new double[] {4, -3}, 1},
                new object[] {new double[] {1,2,3,4,5,6,7,8,9,10,11,12}, 78}
            };
    }
}