using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class SingleCharacterExtractor : DelimiterExtractorBase
    {
        public override bool TryExtract(string s, out List<string> delimiters, out string input)
        {
            var match = base.Extract(s);
            delimiters = null;
            input = string.Empty;
            
            // If matches is not exactly one character and only one set of delimiter
            if (match == null || match.Groups.Count != 3 || match.Groups[1].Value.Length != 1)
            {
                return false;
            }

            delimiters = new List<string>() {match.Groups[1].Value};
            input = match.Groups[2].Value;

            return true;
        }
    }
}