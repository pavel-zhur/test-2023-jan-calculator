using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Calculator.Operations;

namespace Test.Calculator.Tests;

/// <summary>
/// The tests given in the task definition.
/// </summary>
[TestClass]
public class MainTestsGiven
{
    /// <summary>
    /// new Sum(5.2, 1.5).toResult() should return 6.7
    /// new Division(30, new Sum(2, 3)).toResult() should return 6
    /// new Faculty(4).toResult() should return 24
    /// new Multiplication(new Fraction(9,4), new Fraction(2,3)).toResult() should return 1.5
    /// </summary>
    [TestMethod]
    public void Math()
    {
        Assert.AreEqual(6.7d, new Sum(5.2, 1.5).ToResult());
        Assert.AreEqual(6d, new Division(30, new Sum(2, 3)).ToResult());
        Assert.AreEqual(24, new Faculty(4).ToResult());
        Assert.AreEqual(1.5d, new Multiplication(new Fraction(9, 4), new Fraction(2, 3)).ToResult());
    }
}