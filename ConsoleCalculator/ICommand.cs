namespace ConsoleCalculator
{
    public interface ICommand
    {
        double Execute(double[] nums);
        string ExecuteWithFormula(double[] nums);
    }
}