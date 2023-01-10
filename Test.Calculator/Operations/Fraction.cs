using System.Text;
using Test.Calculator.Operations.Base;

namespace Test.Calculator.Operations;

/// <summary>
/// A constant operation representing a fraction of two doubles.
/// </summary>
public class Fraction : OperationBase
{
    private readonly double _operand1;
    private readonly double _operand2;

    /// <summary>
    /// Creates a new instance of the <see cref="Fraction"/> operation.
    /// </summary>
    /// <param name="operand1">The left operand.</param>
    /// <param name="operand2">The right operand.</param>
    public Fraction(double operand1, double operand2)
    {
        _operand1 = operand1;
        _operand2 = operand2;
    }

    protected override double Calculate() => _operand1 / _operand2;
    
    protected override void AppendSentence(StringBuilder stringBuilder)
    {
        Append(stringBuilder);
    }

    protected override void AppendMath(StringBuilder stringBuilder, Action<OperationBase> appendChild)
    {
        Append(stringBuilder);
    }

    private void Append(StringBuilder stringBuilder)
    {
        stringBuilder.AppendFormat("{0}/{1}", _operand1, _operand2);
    }
}