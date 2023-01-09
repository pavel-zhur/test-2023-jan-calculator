using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Calculator.Operations;

namespace Test.Calculator.Tests;

/// <summary>
/// Tests of the <see cref="Sum"/> operation.
/// </summary>
[TestClass]
public class SumTests
{
    /// <summary>
    /// Not a number test.
    /// </summary>
    [TestMethod]
    public void NaN()
    {
        Assert.AreEqual(double.NaN, new Sum(double.PositiveInfinity, double.NegativeInfinity).ToResult());
    }

    /// <summary>
    /// A regular sum.
    /// </summary>
    [TestMethod]
    public void RegularSum()
    {
        Assert.AreEqual(8d, new Division(6, 2).ToResult());
    }
}