﻿namespace ConsoleCalculator
{
    public interface IParser
    {
        double[] Parse(string s, string[] delimiters);
    }
}