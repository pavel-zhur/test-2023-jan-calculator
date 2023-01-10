using System.Text;
using Test.Calculator.Operations.Base;
using Test.Calculator.Tools;

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
        if (operand1 == null) throw new ArgumentNullException(nameof(operand1));
        if (operand2 == null) throw new ArgumentNullException(nameof(operand2));
        if (operands == null) throw new ArgumentNullException(nameof(operands));
        if (operands.Contains(null)) throw new ArgumentNullException(nameof(operands));

        _operands = operands.Prepend(operand2).Prepend(operand1).ToArray();
    }

    protected override double Calculate()
        => _operands.Aggregate(1d, (x, y) => x * y.ToResult());

    protected override void AppendSentence(StringBuilder stringBuilder)
    {
        stringBuilder.Append("multiplication of ");

        _operands.PrintMultiple(stringBuilder, x => AppendSentence(stringBuilder, x));
    }

    protected override void AppendMath(StringBuilder stringBuilder, Action<OperationBase> appendChild)
    {
        for (var i = 0; i < _operands.Count; i++)
        {
            if (i > 0)
                stringBuilder.Append(" * ");

            appendChild(_operands[i]);
        }
    }
}