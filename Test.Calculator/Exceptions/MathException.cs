namespace Test.Calculator.Exceptions
{
    /// <summary>
    /// This is a base exception for various exceptions thrown by the calculator operations.
    /// </summary>
    public class MathException : Exception
    {
        protected MathException(string message)
            : base(message)
        {
        }
    }
}
