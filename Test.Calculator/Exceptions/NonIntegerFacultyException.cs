using Test.Calculator.Operations;

namespace Test.Calculator.Exceptions;

/// <summary>
/// This exception is thrown by the <see cref="Faculty"/> operation when the operand value is not an whole integer.
/// </summary>
public class NonIntegerFacultyException : MathException
{
    public NonIntegerFacultyException(double value)
        : base($"A faculty of a non-integer {value} could not be calculated, only whole numbers are supported.")
    {
    }
}