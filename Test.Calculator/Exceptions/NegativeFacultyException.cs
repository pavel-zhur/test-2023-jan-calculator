namespace Test.Calculator.Exceptions;

public class NegativeFacultyException : MathException
{
    public NegativeFacultyException(double value)
        : base($"A faculty of a negative {value} is not defined. Only non-negatives are supported.")
    {
    }
}