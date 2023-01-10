using System.Text;
using Test.Calculator.Operations.Base;

namespace Test.Calculator.Operations;

/// <summary>
/// A division operation.
/// </summary>
public class Division : OperationBase
{
    /// <summary>
    /// Creates a new <see cref="Division"/> operation instance.
    /// </summary>
    /// <param name="left">The left operand.</param>
    /// <param name="right">The right operand.</param>
    public Division(OperationBase left, OperationBase right)
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

    protected override double Calculate() => Left.ToResult() / Right.ToResult();

    protected override void AppendSentence(StringBuilder stringBuilder, Action<OperationBase> appendChild)
    {
        stringBuilder.Append("division of ");
        appendChild(Left);
        stringBuilder.Append(" by ");
        appendChild(Right);
    }

    protected override void AppendMath(StringBuilder stringBuilder, Action<OperationBase> appendChild)
    {
        appendChild(Left);
        stringBuilder.Append(" / ");
        appendChild(Right);
    }
}