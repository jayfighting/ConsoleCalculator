namespace ConsoleCalculator
{
    public interface IParser
    {
        double[] Parse(string s, char delimiter);
    }
}