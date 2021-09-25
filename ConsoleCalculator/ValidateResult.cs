using System.Collections.Generic;
using System.Linq;

namespace ConsoleCalculator
{
    public class ValidateResult
    {
        public bool Passed => !ValidationErrors.Any();
        private readonly List<string> _validationErrors = new List<string>();
        public IReadOnlyCollection<string> ValidationErrors => _validationErrors.AsReadOnly();

        public ValidateResult()
        {
        }

        public ValidateResult(List<string> errors)
        {
            _validationErrors = errors;
        }

        public void Add(string error)
        {
            if (!string.IsNullOrEmpty(error))
            {
                _validationErrors.Add(error);
            }
        }
    }
}