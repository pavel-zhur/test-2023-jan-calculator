using System.Text;
using Test.Calculator.Operations.Base;

namespace Test.Calculator.Operations;

/// <summary>
/// A multiplication operation.
/// </summary>
public class Multiplication : OperationBase
{
    private readonly IReadOnlyList<OperationBase> _operands;

    /// <summary>
    /// Creates a new instance of the <see cref="Multiplication"/> operation.
    /// </summary>
    /// <param name="operand1">The first operand.</param>
    /// <param name="operand2">The second operand.</param>
    /// <param name="operands">Any additional operands.</param>
    public Multiplication(OperationBase operand1, OperationBase operand2, params OperationBase[] operands)
    {
        if (operands == null) throw new ArgumentNullException(nameof(operands));

        _operands = operands.Prepend(operand2).Prepend(operand1).ToArray();
    }

    protected override double Calculate()
        => _operands.Aggregate(1d, (x, y) => x * y.ToResult());

    protected override void AppendMathInternal(StringBuilder stringBuilder)
    {
        for (var index = 0; index < _operands.Count; index++)
        {
            if (index > 0)
                stringBuilder.Append(" * ");

            AppendMath(stringBuilder, _operands[index]);
        }
    }
}