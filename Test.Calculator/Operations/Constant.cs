using System.Text;
using Test.Calculator.Operations.Base;

namespace Test.Calculator.Operations;

/// <summary>
/// A constant operation.
/// </summary>
public class Constant : OperationBase
{
    private readonly double _value;

    protected override bool AddParenthesesOnPrinting => false;

    /// <summary>
    /// Creates a new <see cref="Constant"/> operation instance.
    /// </summary>
    public Constant(double value)
    {
        _value = value;
    }

    protected override double Calculate() => _value;
    
    protected override void AppendSentence(StringBuilder stringBuilder)
    {
        AppendMath(stringBuilder);
    }

    protected override void AppendMath(StringBuilder stringBuilder)
    {
        stringBuilder.Append(_value);
    }
}