using System.Text;
using Test.Calculator.Operations.Base;

namespace Test.Calculator.Operations;

/// <summary>
/// A constant operation representing a fraction of two doubles.
/// </summary>
public class Fraction : OperationBase
{
    /// <summary>
    /// Creates a new instance of the <see cref="Fraction"/> operation.
    /// </summary>
    /// <param name="numerator">The top operand, numerator.</param>
    /// <param name="denominator">The bottom operand, denominator.</param>
    public Fraction(double numerator, double denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    /// <summary>
    /// The top operand, numerator.
    /// </summary>
    public double Numerator { get; }

    /// <summary>
    /// The bottom operand, denominator.
    /// </summary>
    public double Denominator { get; }

    protected override double Calculate() => Numerator / Denominator;
    
    protected override void AppendSentence(StringBuilder stringBuilder, Action<OperationBase> appendChild)
    {
        Append(stringBuilder);
    }

    protected override void AppendMath(StringBuilder stringBuilder, Action<OperationBase> appendChild)
    {
        Append(stringBuilder);
    }

    private void Append(StringBuilder stringBuilder)
    {
        stringBuilder.AppendFormat("{0}/{1}", Numerator, Denominator);
    }
}