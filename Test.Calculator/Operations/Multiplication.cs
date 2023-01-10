using System.Text;
using Test.Calculator.Operations.Base;
using Test.Calculator.Tools;

namespace Test.Calculator.Operations;

/// <summary>
/// A multiplication operation.
/// </summary>
public class Multiplication : OperationBase
{
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

        Operands = operands.Prepend(operand2).Prepend(operand1).ToArray();
    }

    /// <summary>
    /// The operands collection. Contains at least two elements.
    /// </summary>
    public IReadOnlyList<OperationBase> Operands { get; }

    protected override double Calculate()
        => Operands.Aggregate(1d, (x, y) => x * y.ToResult());

    protected override void AppendSentence(StringBuilder stringBuilder, Action<OperationBase> appendChild)
    {
        stringBuilder.Append("multiplication of ");

        Operands.PrintMultiple(stringBuilder, appendChild);
    }

    protected override void AppendMath(StringBuilder stringBuilder, Action<OperationBase> appendChild)
    {
        for (var i = 0; i < Operands.Count; i++)
        {
            if (i > 0)
                stringBuilder.Append(" * ");

            appendChild(Operands[i]);
        }
    }
}