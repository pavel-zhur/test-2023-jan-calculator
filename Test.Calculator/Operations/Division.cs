using Test.Calculator.Operations.Base;

namespace Test.Calculator.Operations;

public class Division : OperationBase
{
    private readonly OperationBase _operand1;
    private readonly OperationBase _operand2;

    public Division(OperationBase operand1, OperationBase operand2)
    {
        _operand1 = operand1;
        _operand2 = operand2;
    }

    protected override double Calculate() => _operand1.ToResult() / _operand2.ToResult();
}