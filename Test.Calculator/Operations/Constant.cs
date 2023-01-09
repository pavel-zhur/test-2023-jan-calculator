using Test.Calculator.Operations.Base;

namespace Test.Calculator.Operations;

public class Constant : OperationBase
{
    private readonly double _value;

    public Constant(double value)
    {
        _value = value;
    }

    protected override double Calculate() => _value;
}