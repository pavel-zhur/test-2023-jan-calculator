using Test.Calculator.Operations.Base;

namespace Test.Calculator.Operations;

public class Multiplication : OperationBase
{
    private readonly IReadOnlyList<OperationBase> _operands;

    public Multiplication(OperationBase operand1, OperationBase operand2, params OperationBase[] operands)
    {
        if (operands == null) throw new ArgumentNullException(nameof(operands));

        _operands = operands.Prepend(operand2).Prepend(operand1).ToArray();
    }

    protected override double Calculate()
        => _operands.Aggregate(1d, (x, y) => x * y.ToResult());
}