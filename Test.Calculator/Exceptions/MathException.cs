namespace Test.Calculator.Exceptions
{
    public class MathException : Exception
    {
        public MathException(string message)
            : base(message)
        {

        }
    }

    public class NegativeFactorialException : MathException
    {
        public NegativeFactorialException(double value)
            : base($"A factorial of a negative {value} is not defined. Only non-negatives are supported.")
        {
        }
    }

    public class NonIntegerFactorialException : MathException
    {
        public NonIntegerFactorialException(double value)
            : base($"A factorial of a non-integer {value} could not be calculated, only whole numbers are supported.")
        {
        }
    }
}
