using Test.Calculator.Operations;

namespace Test.Calculator.Exceptions;

/// <summary>
/// This exception is thrown by the <see cref="Faculty"/> operation when the operand value is negative.
/// </summary>
public class NegativeFacultyException : MathException
{
    public NegativeFacultyException(double value)
        : base($"A faculty of a negative {value} is not defined. Only non-negatives are supported.")
    {
    }
}