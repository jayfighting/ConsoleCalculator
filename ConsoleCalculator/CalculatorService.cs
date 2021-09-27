using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ICommand _command;
        private readonly IDelimiterExtractorService _extractorService;
        private readonly IParser _parser;
        private readonly IValidator _validator;
        

        public CalculatorService(IParser parser, IValidator validator, ICommand command, 
            IDelimiterExtractorService extractorService)
        {
            _parser = parser;
            _validator = validator;
            _command = command;
            _extractorService = extractorService;
        }

        public string Calculate(string input)
        {
            var delimiters = _extractorService.Extract(input, out var fInput);
            var nums = _parser.Parse(fInput, delimiters);

            var validateResult = _validator.Validate(nums);

            if (!validateResult.Passed)
            {
                throw new ArgumentException(string.Join(Environment.NewLine, validateResult.ValidationErrors));
            } 
            
            return _command.ExecuteWithFormula(nums);
        }
    }
}