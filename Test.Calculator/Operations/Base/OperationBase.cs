using System.Text;

namespace Test.Calculator.Operations.Base;

/// <summary>
/// This is a base class for operations in this calculator. Feel free to extend it.
/// </summary>
public abstract class OperationBase
{
    private double? _value;

    /// <summary>
    /// Specifies whether printing this operation with the math language should wrap it with parentheses. The default is true. Override with the false value, if needed.
    /// </summary>
    protected virtual bool AddParenthesesOnPrinting => true;

    /// <summary>
    /// Provides convenient conversion of double values to <see cref="Constant"/>.
    /// </summary>
    public static implicit operator OperationBase(double constant) => new Constant(constant);

    /// <summary>
    /// Gets the double result of the operation. Throws various exceptions if the calculation did not succeed.
    /// </summary>
    /// <returns>The result.</returns>
    public double ToResult()
    {
        EnsureCalculated();
        return _value!.Value;
    }

    /// <summary>
    /// Prints the expression in full, with the maths language. Throws various exceptions if the calculation did not succeed.
    /// </summary>
    /// <returns>The expression.</returns>
    public string Print()
    {
        var result = ToResult();
        StringBuilder stringBuilder = new();
        AppendMath(stringBuilder);
        stringBuilder.AppendFormat(" = {0}", result);
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Implement this method in the derived classes to do the calculation.
    /// This method may do the heavy work, as it will be called only once and the result will be cached.
    /// </summary>
    protected abstract double Calculate();

    /// <summary>
    /// Prints the expression with the math language, without the parentheses.
    /// </summary>
    /// <param name="stringBuilder">The string builder to append the expression to.</param>
    protected abstract void AppendMathInternal(StringBuilder stringBuilder);

    /// <summary>
    /// Appends the given operation to the given string builder.
    /// </summary>
    /// <param name="stringBuilder">The string builder to append to.</param>
    /// <param name="operationBase">The operation to append to.</param>
    /// <remarks>This method is needed because <see cref="AppendMath(System.Text.StringBuilder)"/> is protected, making it public or protected internal is not correct.</remarks>
    protected static void AppendMath(StringBuilder stringBuilder, OperationBase operationBase)
    {
        operationBase.AppendMath(stringBuilder);
    }

    /// <summary>
    /// Appends this operation to the string builder in math language.
    /// </summary>
    /// <param name="stringBuilder">The string builder to append to.</param>
    private void AppendMath(StringBuilder stringBuilder)
    {
        if (AddParenthesesOnPrinting)
        {
            stringBuilder.Append("(");
        }

        AppendMathInternal(stringBuilder);
    
        if (AddParenthesesOnPrinting)
        {
            stringBuilder.Append(")");
        }
    }

    /// <summary>
    /// Calculates the <see cref="_value"/> if it has not been calculated yet.
    /// This is the lazy implementation.
    /// </summary>
    private void EnsureCalculated()
    {
        _value ??= Calculate();
    }
}