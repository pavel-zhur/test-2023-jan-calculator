using System.Text;
using Test.Calculator.Operations.Base;

namespace Test.Calculator.Operations;

/// <summary>
/// A subtraction operation.
/// </summary>
public class Subtraction : OperationBase
{
    /// <summary>
    /// Creates a new instance of the <see cref="Subtraction"/> operation.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    public Subtraction(OperationBase left, OperationBase right)
    {
        Left = left ?? throw new ArgumentNullException(nameof(left));
        Right = right ?? throw new ArgumentNullException(nameof(right));
    }

    /// <summary>
    /// The left operand.
    /// </summary>
    public OperationBase Left { get; }

    /// <summary>
    /// The right operand.
    /// </summary>
    public OperationBase Right { get; }

    protected override double Calculate() => Left.ToResult() - Right.ToResult();

    protected override void AppendSentence(StringBuilder stringBuilder, Action<OperationBase> appendChild)
    {
        appendChild(Left);
        stringBuilder.Append(" minus ");
        appendChild(Right);
    }

    protected override void AppendMath(StringBuilder stringBuilder, Action<OperationBase> appendChild)
    {
        appendChild(Left);
        stringBuilder.Append(" - ");
        appendChild(Right);
    }
}