namespace Test.Calculator.Operations.Base;

public abstract class OperationBase
{
    private double? _value;

    public static implicit operator OperationBase(double constant) => new Constant(constant);

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

    private void EnsureCalculated()
    {
        _value ??= Calculate();
    }
}