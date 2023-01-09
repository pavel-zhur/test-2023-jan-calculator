using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Calculator.Operations;

namespace Test.Calculator.Tests;

[TestClass]
public class SequencePrintTests
{
    [TestMethod]
    public void Print2()
    {
        Assert.AreEqual("sum of 2 and 3 is 5", new Sum(2, 3).PrintSentence());
    }

    [TestMethod]
    public void Print3()
    {
        Assert.AreEqual("sum of 2, 3, and 4 is 9", new Sum(2, 3, 4).PrintSentence());
    }

    [TestMethod]
    public void Print4()
    {
        Assert.AreEqual("sum of 2, 3, 4, and 5 is 14", new Sum(2, 3, 4, 5).PrintSentence());
    }
}