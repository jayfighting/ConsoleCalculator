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
            var parser = new Parser();
            var validator = new Validator();
            var adder = new Adder();
            var calcService = new CalculatorService(parser, validator, adder);

            Console.WriteLine("Please enter your 2 numbers that's separated by a comma (example: 2, 3)");
            Console.Write("Your Input:");
            var numStr = Console.ReadLine();

            var ans = calcService.Calculate(numStr, Config.Delimiters, validations);

            Console.Write("Your Result:");
            Console.WriteLine(ans);

            Console.ReadLine();
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