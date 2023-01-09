namespace Test.Calculator.Exceptions;

public class NonIntegerFacultyException : MathException
{
    public NonIntegerFacultyException(double value)
        : base($"A faculty of a non-integer {value} could not be calculated, only whole numbers are supported.")
    {
    }
}