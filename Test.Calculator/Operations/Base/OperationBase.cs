namespace Test.Calculator.Operations.Base;

/// <summary>
/// This is a base class for operations in this calculator. Feel free to extend it.
/// </summary>
public abstract class OperationBase
{
    private double? _value;

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
    /// Implement this method in the derived classes to do the calculation.
    /// This method may do the heavy work, as it will be called only once and the result will be cached.
    /// </summary>
    protected abstract double Calculate();

    /// <summary>
    /// Calculates the <see cref="_value"/> if it has not been calculated yet.
    /// This is the lazy implementation.
    /// </summary>
    private void EnsureCalculated()
    {
        _value ??= Calculate();
    }
}