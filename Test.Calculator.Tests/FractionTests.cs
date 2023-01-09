using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Calculator.Operations;

namespace Test.Calculator.Tests;

/// <summary>
/// Tests of the <see cref="Fraction"/> operation.
/// </summary>
[TestClass]
public class FractionTests
{
    /// <summary>
    /// Division by zero is expected to return a positive infinity.
    /// </summary>
    [TestMethod]
    public void DivisionByZero()
    {
        Assert.AreEqual(double.PositiveInfinity, new Fraction(4, 0).ToResult());
    }

    /// <summary>
    /// A regular division.
    /// </summary>
    [TestMethod]
    public void RegularFraction()
    {
        Assert.AreEqual(3d, new Fraction(6, 2).ToResult());
    }
}