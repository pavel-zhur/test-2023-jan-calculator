using Test.Calculator.Operations.Base;

namespace Test.Calculator.Operations;

public class Fraction : OperationBase
{
    private readonly double _operand1;
    private readonly double _operand2;

    public Fraction(double operand1, double operand2)
    {
        _operand1 = operand1;
        _operand2 = operand2;
    }

    protected override double Calculate() => _operand1 / _operand2;
}