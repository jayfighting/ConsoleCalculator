using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public interface IValidator
    {
        ValidateResult Validate(double[] nums);
    }
}