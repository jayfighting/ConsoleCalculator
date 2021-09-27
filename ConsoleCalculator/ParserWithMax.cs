namespace ConsoleCalculator
{
    public class ParserWithMax : Parser
    {
        private readonly double _maxValue;

        public ParserWithMax(double maxValue) 
        {
            _maxValue = maxValue;
        }

        public override double[] Parse(string s, string[] delimiters)
        {
            var result = base.Parse(s, delimiters);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = result[i] > _maxValue ? result[i] = 0 : result[i];
            }

            return result;
        }
    }
}