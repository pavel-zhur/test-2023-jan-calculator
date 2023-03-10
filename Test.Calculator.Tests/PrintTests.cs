using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Calculator.Exceptions;
using Test.Calculator.Operations;
using Test.Calculator.Operations.Base;

namespace Test.Calculator.Tests;

/// <summary>
/// Extended tests of the <see cref="OperationBase.Print"/> and <see cref="OperationBase.PrintSentence"/> methods.
/// </summary>
[TestClass]
public class PrintTests
{
    /// <summary>
    /// A complex expression test.
    /// </summary>
    [TestMethod]
    public void PrintComplex()
    {
        AssertPrints(
            "(((3 + 4 + 5 + 6) + (3 * 4 * 5) + 44) / ((3 + 4 + 5 + 6) + (3 * 4 * 5) + 44)) = 1",
            "division of sum of sum of 3, 4, 5, and 6, multiplication of 3, 4, and 5, and 44 by sum of sum of 3, 4, 5, and 6, multiplication of 3, 4, and 5, and 44 is 1",
            new Division(new Sum(new Sum(3, 4, 5, 6), new Multiplication(3, 4, 5), new Constant(44)),
                new Sum(new Sum(3, 4, 5, 6), new Multiplication(3, 4, 5), new Constant(44))));
    }

    /// <summary>
    /// A nested faculty expression test.
    /// </summary>
    [TestMethod]
    public void PrintNestedFaculty()
    {
        AssertPrints(
            "(((2!)!)!) = 2",
            "faculty of faculty of faculty of 2 is 2",
            new Faculty(new Faculty(new Faculty(2))));
    }

    /// <summary>
    /// An infinity test.
    /// </summary>
    [TestMethod]
    public void PrintInfinity()
    {
        AssertPrints(
            "(3 / 0) = ∞",
            "division of 3 by 0 could not be calculated precisely, the result value is too high. A division by zero is probable.",
            new Division(3, 0));
    }

    /// <summary>
    /// A NaN test.
    /// </summary>
    [TestMethod]
    public void PrintNaN()
    {
        AssertPrints(
            "((3 / 0) - (3 / 0)) = NaN",
            "division of 3 by 0 minus division of 3 by 0 could not be calculated precisely, the result value is NaN.",
            new Subtraction(new Division(3, 0), new Division(3, 0)));
    }

    /// <summary>
    /// A faculty pass-through of the NaN test.
    /// </summary>
    [TestMethod]
    public void PrintFacultyNaNPassThrough()
    {
        AssertPrints(
            "(((3 / 0) - (3 / 0))!) = NaN",
            "faculty of division of 3 by 0 minus division of 3 by 0 could not be calculated precisely, the result value is NaN.",
            new Faculty(new Subtraction(new Division(3, 0), new Division(3, 0))));
    }

    /// <summary>
    /// A faculty pass-through of the positive infinity test.
    /// </summary>
    [TestMethod]
    public void PrintPositiveInfinityFacultyPassThrough()
    {
        AssertPrints(
            "((3 / 0)!) = ∞",
            "faculty of division of 3 by 0 could not be calculated precisely, the result value is too high. A division by zero is probable.",
            new Faculty(new Division(3, 0)));
    }

    /// <summary>
    /// A faculty exception test.
    /// </summary>
    [TestMethod]
    public void PrintFacultyThrows()
    {
        OperationBase operation = new Faculty(new Division(5, 2));
        Assert.ThrowsException<NonIntegerFacultyException>(operation.Print);
        Assert.AreEqual("faculty of division of 5 by 2 could not be calculated precisely. A faculty of a non-integer 2.5 could not be calculated, only whole numbers are supported.", operation.PrintSentence());
    }

    /// <summary>
    /// Assert that the .Print() returns one expression and the .PrintSentence() returns another expression.
    /// </summary>
    /// <param name="expectedPrint">The expression .Print() is expected to return.</param>
    /// <param name="expectedPrintSentence">The expression .PrintSentence() is expected to return.</param>
    /// <param name="operation">The operation to test.</param>
    private static void AssertPrints(
        string expectedPrint,
        string expectedPrintSentence,
        OperationBase operation)
    {
        Assert.AreEqual(expectedPrint, operation.Print());
        Assert.AreEqual(expectedPrintSentence, operation.PrintSentence());
    }
}