using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Calculator.Operations;

namespace Test.Calculator.Tests.MathTests;

/// <summary>
/// Tests of the <see cref="Division"/> operation.
/// </summary>
[TestClass]
public class DivisionTests
{
    /// <summary>
    /// Division by zero is expected to return a positive infinity.
    /// </summary>
    [TestMethod]
    public void DivisionByZero()
    {
        Assert.AreEqual(double.PositiveInfinity, new Division(4, 0).ToResult());
    }

    /// <summary>
    /// A regular division.
    /// </summary>
    [TestMethod]
    public void RegularDivision()
    {
        Assert.AreEqual(3d, new Division(6, 2).ToResult());
    }
}