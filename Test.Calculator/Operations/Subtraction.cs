using System.Text;
using Test.Calculator.Operations.Base;

namespace Test.Calculator.Operations;

/// <summary>
/// A subtraction operation.
/// </summary>
public class Subtraction : OperationBase
{
    private readonly OperationBase _operand1;
    private readonly OperationBase _operand2;

    /// <summary>
    /// Creates a new instance of the <see cref="Subtraction"/> operation.
    /// </summary>
    /// <param name="operand1">The left operand.</param>
    /// <param name="operand2">The right operand.</param>
    public Subtraction(OperationBase operand1, OperationBase operand2)
    {
        _operand1 = operand1;
        _operand2 = operand2;
    }

    protected override double Calculate() => _operand1.ToResult() - _operand2.ToResult();

    protected override void AppendSentence(StringBuilder stringBuilder)
    {
        AppendSentence(stringBuilder, _operand1);
        stringBuilder.Append(" minus ");
        AppendSentence(stringBuilder, _operand2);
    }

    protected override void AppendMath(StringBuilder stringBuilder)
    {
        AppendMathWithParentheses(stringBuilder, _operand1);
        stringBuilder.Append(" - ");
        AppendMathWithParentheses(stringBuilder, _operand2);
    }
}