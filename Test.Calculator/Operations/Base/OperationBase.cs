using System.Text;
using Test.Calculator.Exceptions;

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
        _value ??= Calculate();
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
        AppendMathWithParentheses(stringBuilder);
        stringBuilder.AppendFormat(" = {0}", result);
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Prints the expression in full, with the English language. Does not throw exceptions.
    /// </summary>
    /// <returns>The result sentence.</returns>
    public string PrintSentence()
    {
        StringBuilder stringBuilder = new();
        AppendSentence(stringBuilder);

        try
        {
            var result = ToResult();

            if (double.IsPositiveInfinity(result))
            {
                stringBuilder.Append(
                    " could not be calculated precisely, the result value is too high. A division by zero is probable.");
            }
            else if (!double.IsNormal(result))
            {
                stringBuilder.AppendFormat(
                    " could not be calculated precisely, the result value is {0}.", result);
            }
            else
            {
                stringBuilder.AppendFormat(" is {0}", result);
            }
        }
        catch (OverflowException)
        {
            stringBuilder.Append(" calculation result in an overflow.");
        }
        catch (MathException ex)
        {
            stringBuilder.AppendFormat(" could not be calculated precisely. {0}", ex.Message);
        }

        return stringBuilder.ToString();
    }

    /// <summary>
    /// Implement this method in the derived classes to do the calculation.
    /// This method may do the heavy work, as it will be called only once and the result will be cached.
    /// </summary>
    protected abstract double Calculate();

    /// <summary>
    /// Prints the expression with the English language, without the parentheses.
    /// </summary>
    /// <param name="stringBuilder">The string builder to append the expression to.</param>
    protected abstract void AppendSentence(StringBuilder stringBuilder);

    /// <summary>
    /// Appends the given operation to the given string builder.
    /// </summary>
    /// <param name="stringBuilder">The string builder to append to.</param>
    /// <param name="operationBase">The operation to append to.</param>
    /// <remarks>This method is needed because <see cref="AppendSentence(System.Text.StringBuilder)"/> is protected, making it public or protected internal is not correct.</remarks>
    protected static void AppendSentence(StringBuilder stringBuilder, OperationBase operationBase)
    {
        operationBase.AppendSentence(stringBuilder);
    }

    /// <summary>
    /// Prints the expression with the math language, without the parentheses.
    /// </summary>
    /// <param name="stringBuilder">The string builder to append the expression to.</param>
    /// <param name="appendChild">An action to call to send a child operation to the string builder.</param>
    protected abstract void AppendMath(StringBuilder stringBuilder, Action<OperationBase> appendChild);

    /// <summary>
    /// Appends this operation to the string builder in math language.
    /// </summary>
    /// <param name="stringBuilder">The string builder to append to.</param>
    private void AppendMathWithParentheses(StringBuilder stringBuilder)
    {
        if (AddParenthesesOnPrinting)
        {
            stringBuilder.Append('(');
        }

        AppendMath(stringBuilder, x => x.AppendMathWithParentheses(stringBuilder));
    
        if (AddParenthesesOnPrinting)
        {
            stringBuilder.Append(')');
        }
    }
}