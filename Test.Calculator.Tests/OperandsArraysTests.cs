using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Calculator.Operations;
using Test.Calculator.Operations.Base;

namespace Test.Calculator.Tests;

/// <summary>
/// These tests test that the operations are immutable.
/// </summary>
[TestClass]
public class OperandsArraysTests
{
    [TestMethod]
    public void ParametersCapturedImmediately_Sum()
    {
        OperationBase[] myArray = { new Constant(5) };
        var sum = new Sum(3, 2, myArray); // whatever we pass to the arguments
        myArray[0] = new Constant(100); // no matter how we change the array further
        Assert.AreEqual(10, sum.ToResult()); // stays effective
    }

    [TestMethod]
    public void ParametersCapturedImmediately_Multiplication()
    {
        OperationBase[] myArray = { new Constant(5) };
        var sum = new Multiplication(3, 2, myArray); // whatever we pass to the arguments
        myArray[0] = new Constant(100); // no matter how we change the array further
        Assert.AreEqual(30, sum.ToResult()); // stays effective
    }
}