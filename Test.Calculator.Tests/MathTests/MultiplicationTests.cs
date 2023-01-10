using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Calculator.Operations;

namespace Test.Calculator.Tests.MathTests;

/// <summary>
/// Tests of the <see cref="Multiplication"/> operation.
/// </summary>
[TestClass]
public class MultiplicationTests
{
    /// <summary>
    /// Getting NaN.
    /// </summary>
    [TestMethod]
    public void NotANumber()
    {
        Assert.AreEqual(double.NaN, new Multiplication(0, double.PositiveInfinity).ToResult());
    }

    /// <summary>
    /// A regular multiplication.
    /// </summary>
    [TestMethod]
    public void RegularMultiplication()
    {
        Assert.AreEqual(12d, new Multiplication(6, 2).ToResult());
    }
}