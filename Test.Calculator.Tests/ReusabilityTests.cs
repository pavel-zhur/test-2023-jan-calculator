using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Calculator.Operations;
using Test.Calculator.Operations.Base;

namespace Test.Calculator.Tests;

/// <summary>
/// Tests that the operations are reusable multiple times.
/// </summary>
[TestClass]
public class ReusabilityTests
{
    /// <summary>
    /// The same operation may appear multiple times in a tree.
    /// </summary>
    [TestMethod]
    public void OperationsAreReusable()
    {
        var childOperation = new Multiplication(2, 3, new Sum(4, 5));
        var parentOperation = new Sum(
            childOperation, 
            childOperation, 
            Enumerable.Repeat(childOperation, 5).Cast<OperationBase>().ToArray());

        Assert.AreEqual(378, parentOperation.ToResult());
        Assert.AreEqual("((2 * 3 * (4 + 5)) + (2 * 3 * (4 + 5)) + (2 * 3 * (4 + 5)) + (2 * 3 * (4 + 5)) + (2 * 3 * (4 + 5)) + (2 * 3 * (4 + 5)) + (2 * 3 * (4 + 5))) = 378", parentOperation.Print());
        Assert.AreEqual("sum of multiplication of 2, 3, and sum of 4 and 5, multiplication of 2, 3, and sum of 4 and 5, multiplication of 2, 3, and sum of 4 and 5, multiplication of 2, 3, and sum of 4 and 5, multiplication of 2, 3, and sum of 4 and 5, multiplication of 2, 3, and sum of 4 and 5, and multiplication of 2, 3, and sum of 4 and 5 is 378", parentOperation.PrintSentence());
    }

    /// <summary>
    /// Tests that .Print() and .PrintSentence() may be called multiple times.
    /// </summary>
    [TestMethod]
    public void MultipleCalculationsPossible()
    {
        var operation = new Sum(2, new Division(48, new Faculty(4)));

        TestRootResult();
        TestRootResult();
        TestRootResult();

        TestRootPrint();
        TestRootPrint();
        TestRootPrint();

        TestRootPrintSentence();
        TestRootPrintSentence();
        TestRootPrintSentence();

        TestChildResult();
        TestChildResult();
        TestChildResult();

        TestChildPrint();
        TestChildPrint();
        TestChildPrint();

        TestChildPrintSentence();
        TestChildPrintSentence();
        TestChildPrintSentence();

        void TestRootResult() => Assert.AreEqual(4, operation.ToResult());
        void TestRootPrint() => Assert.AreEqual("(2 + (48 / (4!))) = 4", operation.Print());
        void TestRootPrintSentence() => Assert.AreEqual("sum of 2 and division of 48 by faculty of 4 is 4", operation.PrintSentence());

        void TestChildResult() => Assert.AreEqual(2, operation.Operands[1].ToResult());
        void TestChildPrint() => Assert.AreEqual("(48 / (4!)) = 2", operation.Operands[1].Print());
        void TestChildPrintSentence() => Assert.AreEqual("division of 48 by faculty of 4 is 2", operation.Operands[1].PrintSentence());
    }
}