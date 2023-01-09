using System.Text;
using Test.Calculator.Operations.Base;

namespace Test.Calculator.Operations;

/// <summary>
/// A division operation.
/// </summary>
public class Division : OperationBase
{
    private readonly OperationBase _operand1;
    private readonly OperationBase _operand2;

    /// <summary>
    /// Creates a new <see cref="Division"/> operation instance.
    /// </summary>
    /// <param name="operand1">The left operand.</param>
    /// <param name="operand2">The right operand.</param>
    public Division(OperationBase operand1, OperationBase operand2)
    {
        _operand1 = operand1;
        _operand2 = operand2;
    }

    protected override double Calculate() => _operand1.ToResult() / _operand2.ToResult();
    
    protected override void AppendMathInternal(StringBuilder stringBuilder)
    {
        AppendMath(stringBuilder, _operand1);
        stringBuilder.Append(" / ");
        AppendMath(stringBuilder, _operand2);
    }
}