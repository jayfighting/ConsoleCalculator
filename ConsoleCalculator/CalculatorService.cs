using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ICommand _command;
        private readonly IParser _parser;
        private readonly IValidator _validator;

        public CalculatorService(IParser parser, IValidator validator, ICommand command)
        {
            _parser = parser;
            _validator = validator;
            _command = command;
        }

        public double Calculate(string input, string[] delimiters, List<Func<double[], string>> validations)
        {
            var nums = _parser.Parse(input, delimiters);

            var validateResult = _validator.Validate(nums, validations);

            if (!validateResult.Passed)
            {
                throw new ArgumentException(string.Join(Environment.NewLine, validateResult.ValidationErrors));
            } 
            
            return _command.Execute(nums);
        }
    }
}