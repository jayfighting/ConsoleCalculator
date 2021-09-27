using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PrintHeader();

            var validations = new List<Func<double[], string>> {Validations.NoNegativeNumberValidation};
            var extractors = new List<DelimiterExtractorBase>()
            {
                new SingleCharacterExtractor(),
                new SingleWordExtractor(),
                new MultiWordsExtractor()
            };
            const int maxVal = 1000;
            var delimiterExtractorService = new DelimiterExtractorService(extractors);
            var parser = new ParserWithMax(maxVal);
            var validator = new Validator(validations);
            var adder = new Adder();
            Console.CancelKeyPress += (sender, eventArgs) => Environment.Exit(0);
            var calcService = new CalculatorService(parser, validator, adder, delimiterExtractorService);
            
            while (true)
            {
                
                Console.WriteLine("Please enter your formula (Ctrl+c) to exit..");
                Console.Write("Your Input:");
                var numStr = Console.ReadLine();

                var ans = calcService.Calculate(numStr);

                Console.Write("Your Result:");
                Console.WriteLine(ans);
                
                Console.WriteLine();
            }
        }

        private static void PrintHeader()
        {
            Console.WriteLine("Welcome to Console Calculator");
            Console.WriteLine(@"
                                 .----------------.  .----------------.  .----------------.  .----------------. 
                                | .--------------. || .--------------. || .--------------. || .--------------. |
                                | |  _______     | || |    ______    | || |    ______    | || |   _______    | |
                                | | |_   __ \    | || |   / ____ `.  | || |  .' ____ \   | || |  |  _____|   | |
                                | |   | |__) |   | || |   `'  __) |  | || |  | |____\_|  | || |  | |____     | |
                                | |   |  __ /    | || |   _  |__ '.  | || |  | '____`'.  | || |  '_.____''.  | |
                                | |  _| |  \ \_  | || |  | \____) |  | || |  | (____) |  | || |  | \____) |  | |
                                | | |____| |___| | || |   \______.'  | || |  '.______.'  | || |   \______.'  | |
                                | |              | || |              | || |              | || |              | |
                                | '--------------' || '--------------' || '--------------' || '--------------' |
                                 '----------------'  '----------------'  '----------------'  '----------------' ");
        }
    }
}