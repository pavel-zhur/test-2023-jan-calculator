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

    /// <summary>
    /// new Sum(5.2, 1.5).print() should return (5.2 + 1.5) = 6.7  .
    /// new Division(30, new Sum(2, 3)).print() should return (30 / (2 + 3)) = 6
    /// new Faculty(4).print() should return  (4!) = 24  .
    /// new Multiplication(new Fraction(6,4), new Fraction(2,3)).print() should return ((9/4) * (2/3)) = 1.5
    /// </summary>
    [TestMethod]
    public void Print()
    {
        Assert.AreEqual("(5.2 + 1.5) = 6.7", new Sum(5.2, 1.5).Print());
        Assert.AreEqual("(30 / (2 + 3)) = 6", new Division(30, new Sum(2, 3)).Print());
        Assert.AreEqual("(4!) = 24", new Faculty(4).Print());
        Assert.AreEqual("((9/4) * (2/3)) = 1.5", new Multiplication(new Fraction(9, 4), new Fraction(2, 3)).Print());
    }

    /// <summary>
    /// new Sum(5.2, 1.5).printSentence() should return sum of 5.2 and 1.5 is 6.7  .
    /// new Division(30, new Sum(2, 3)).printSentence() should return division of 30 by sum of 2 and 3 is 6
    /// new Faculty(4).printSentence() should return faculty of 4 is 24  .
    /// new Multiplication(new Fraction(6,4), new Fraction(2,3)).printSentence() should return multiplication of 9/4 and 2/3 is 1.5
    /// </summary>
    [TestMethod]
    public void PrintSentence()
    {
        Assert.AreEqual("sum of 5.2 and 1.5 is 6.7", new Sum(5.2, 1.5).PrintSentence());
        Assert.AreEqual("division of 30 by sum of 2 and 3 is 6", new Division(30, new Sum(2, 3)).PrintSentence());
        Assert.AreEqual("faculty of 4 is 24", new Faculty(4).PrintSentence());
        Assert.AreEqual("multiplication of 9/4 and 2/3 is 1.5", new Multiplication(new Fraction(9, 4), new Fraction(2, 3)).PrintSentence());
    }
}