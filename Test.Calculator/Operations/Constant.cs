using Test.Calculator.Operations.Base;

namespace Test.Calculator.Operations;

/// <summary>
/// A constant operation.
/// </summary>
public class Constant : OperationBase
{
    private readonly double _value;

    /// <summary>
    /// Creates a new <see cref="Constant"/> operation instance.
    /// </summary>
    public Constant(double value)
    {
        _value = value;
    }

    protected override double Calculate() => _value;
}