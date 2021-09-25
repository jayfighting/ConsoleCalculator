using System.Collections.Generic;

namespace ConsoleCalculator.UnitTests
{
    public class CalculatorTestData
    {
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] {new double[] {20}, 20},
                new object[] {new double[] {1, 5000}, 5001},
                new object[] {new double[] {4, -3}, 1}
            };
    }
}