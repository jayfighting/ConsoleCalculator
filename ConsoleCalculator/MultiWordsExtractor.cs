using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalculator
{
    public class MultiWordsExtractor : DelimiterExtractorBase
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

            var stack = new Stack<char>(0);
            var delimiterResult = new List<string>();

            foreach (var ch in delimiterStr)
            {
                if (ch == ']')
                {
                    if (stack.Count == 0) return false;
                    
                    var currDelimiter = new StringBuilder();
                    while (stack.Count > 0)
                    {
                        var popped = stack.Pop();

                        if (popped == '[')
                        {
                            if (string.IsNullOrEmpty(currDelimiter.ToString()))
                            {
                                return false;
                            }

                            delimiterResult.Add(new string(currDelimiter.ToString().Reverse().ToArray()));
                            break;
                        }

                        if (stack.Count == 0)
                        {
                            // cannot find the start matching bracket    
                            return false;
                        }

                        currDelimiter.Append(popped);
                    }
                }
                else
                {
                    stack.Push(ch);
                }
            }

            if (stack.Count > 0)
            {
                return false;
            }

            delimiters = delimiterResult;
            input = match.Groups[2].Value;

            return true;
        }
    }
}