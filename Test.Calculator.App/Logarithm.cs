using System.Text;
using Test.Calculator.Operations.Base;

namespace Test.Calculator.App;

/// <summary>
/// A custom operation, a logarithm.
/// </summary>
/// <remarks>Example of extending the library.</remarks>
internal class Logarithm : OperationBase
{
    public Logarithm(OperationBase number, OperationBase @base)
    {
        Number = number;
        Base = @base;
    }

    /// <summary>
    /// The logarithm operand.
    /// </summary>
    public OperationBase Number { get; }

    /// <summary>
    /// The logarithm base.
    /// </summary>
    public OperationBase Base { get; }

    protected override double Calculate() => Math.Log(Number.ToResult(), Base.ToResult());

    protected override void AppendSentence(StringBuilder stringBuilder, Action<OperationBase> appendChild)
    {
        stringBuilder.Append("logarithm of ");
        appendChild(Number);
        stringBuilder.Append(" to the base ");
        appendChild(Base);
    }

    protected override void AppendMath(StringBuilder stringBuilder, Action<OperationBase> appendChild)
    {
        appendChild(Number);
        stringBuilder.Append(" log ");
        appendChild(Base);
    }
}