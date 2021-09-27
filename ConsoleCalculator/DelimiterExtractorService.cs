using System.Collections.Generic;
using System.Linq;

namespace ConsoleCalculator
{
    public class DelimiterExtractorService : IDelimiterExtractorService
    {
        private readonly List<DelimiterExtractorBase> _extractors;
        private HashSet<string> _delimiters; 
        public DelimiterExtractorService(List<DelimiterExtractorBase> extractors)
        {
            _extractors = extractors;
        }

        public string[] Extract(string s, out string input)
        {
            //reset the filters every time, doesn't the previous runs
            _delimiters = new HashSet<string>(Config.Delimiters);
            input = s;
            
            foreach (var extractor in _extractors)
            {
                // order matters here, the first one that's able to match will return 
                if (extractor.TryExtract(s, out var delimiters, out var tempInput))
                {
                    delimiters.ForEach(x => _delimiters.Add(x));
                    input = tempInput;
                    
                    break;
                }
            }

            return _delimiters.ToArray();
        }
    }
}