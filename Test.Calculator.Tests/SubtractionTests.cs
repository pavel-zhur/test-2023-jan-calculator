using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Calculator.Operations;

namespace Test.Calculator.Tests;

/// <summary>
/// Tests of the <see cref="Subtraction"/> operation.
/// </summary>
[TestClass]
public class SubtractionTests
{
    /// <summary>
    /// Infinity minus a negative infinity equals positive infinity.
    /// </summary>
    [TestMethod]
    public void PositiveInfinity()
    {
        Assert.AreEqual(double.PositiveInfinity, new Subtraction(double.PositiveInfinity, double.NegativeInfinity).ToResult());
    }

    /// <summary>
    /// Not a number test.
    /// </summary>
    [TestMethod]
    public void NaN()
    {
        Assert.AreEqual(double.NaN, new Subtraction(double.PositiveInfinity, double.PositiveInfinity).ToResult());
    }

    /// <summary>
    /// A regular sum.
    /// </summary>
    [TestMethod]
    public void RegularSubtraction()
    {
        Assert.AreEqual(4d, new Subtraction(6, 2).ToResult());
    }
}