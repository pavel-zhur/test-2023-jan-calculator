using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Calculator.Operations;
using Test.Calculator.Operations.Base;

namespace Test.Calculator.Tests;

/// <summary>
/// Tests that operations constructors throw exceptions when nulls are passed.
/// </summary>
[TestClass]
public class ValidationTests
{
    /// <summary>
    /// Sum operation.
    /// </summary>
    [TestMethod]
    public void Sum()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new Sum(null!, 3));
        Assert.ThrowsException<ArgumentNullException>(() => new Sum(3, null!));
        Assert.ThrowsException<ArgumentNullException>(() => new Sum(3, 5, null!));
        Assert.ThrowsException<ArgumentNullException>(() => new Sum(3, 5, new OperationBase[] { null! }));
        Assert.ThrowsException<ArgumentNullException>(() => new Sum(3, 5, 4, null!));
    }

    /// <summary>
    /// Multiplication operation.
    /// </summary>
    [TestMethod]
    public void Multiplication()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new Multiplication(null!, 3));
        Assert.ThrowsException<ArgumentNullException>(() => new Multiplication(3, null!));
        Assert.ThrowsException<ArgumentNullException>(() => new Multiplication(3, 5, null!));
        Assert.ThrowsException<ArgumentNullException>(() => new Multiplication(3, 5, new OperationBase[] { null! }));
        Assert.ThrowsException<ArgumentNullException>(() => new Multiplication(3, 5, 4, null!));
    }

    /// <summary>
    /// Division operation.
    /// </summary>
    [TestMethod]
    public void Division()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new Division(null!, 3));
        Assert.ThrowsException<ArgumentNullException>(() => new Division(3, null!));
    }

    /// <summary>
    /// Faculty operation.
    /// </summary>
    [TestMethod]
    public void Faculty()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new Faculty(null!));
    }

    /// <summary>
    /// Subtraction operation.
    /// </summary>
    [TestMethod]
    public void Subtraction()
    {
        Assert.ThrowsException<ArgumentNullException>(() => new Subtraction(null!, 3));
        Assert.ThrowsException<ArgumentNullException>(() => new Subtraction(3, null!));
    }
}