namespace ConsoleCalculator
{
    public interface IDelimiterExtractorService
    {
        string[] Extract(string s, out string input);
    }
}