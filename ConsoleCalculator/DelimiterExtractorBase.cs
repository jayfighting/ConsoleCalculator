using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleCalculator
{
    public abstract class DelimiterExtractorBase
    {
        private const string _pattern = @"//(.*)\\n(.*)";
        private const string _pattern2 = "//(.*)\n(.*)";
        protected virtual Match Extract(string s)
        {
            return Regex.Match(s, _pattern);
        }

        public abstract bool TryExtract(string s, out List<string> delimiters, out string input);
    }
}