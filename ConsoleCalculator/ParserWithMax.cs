namespace ConsoleCalculator
{
    public class ParserWithMax : Parser
    {
        private readonly double _maxValue;

        public ParserWithMax(string[] delimiters, double maxValue) : base(delimiters)
        {
            _maxValue = maxValue;
        }

        public override double[] Parse(string s)
        {
            var result = base.Parse(s);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = result[i] > _maxValue ? result[i] = 0 : result[i];
            }

            return result;
        }
    }
}