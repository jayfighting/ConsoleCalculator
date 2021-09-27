using System.Collections;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class SingleWordExtractor : DelimiterExtractorBase
    {
        public override bool TryExtract(string s, out List<string> delimiters, out string input)
        {
            var match = base.Extract(s);
            delimiters = null;
            input = string.Empty;

            // If matches is not exactly one character and only one set of delimiter
            if (match == null || match.Groups.Count != 3)
            {
                return false;
            }

            var delimiterStr = match.Groups[1].Value;
            if (string.IsNullOrEmpty(delimiterStr) || delimiterStr.Length < 2 || delimiterStr[0] != '['
                || delimiterStr[delimiterStr.Length - 1] != ']')
            {
                return false;
            }

            delimiterStr = delimiterStr.TrimStart('[');
            delimiterStr = delimiterStr.TrimEnd(']');
            // only support one bracket pair
            if (delimiterStr.Contains('['))
            {
                return false;
            }
            
            delimiters = new List<string> {delimiterStr};
            input = match.Groups[2].Value;

            return true;
        }
    }
}