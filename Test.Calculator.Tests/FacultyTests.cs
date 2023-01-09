using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Calculator.Exceptions;
using Test.Calculator.Operations;

namespace Test.Calculator.Tests
{
    [TestClass]
    public class FacultyTests
    {
        [TestMethod]
        public void TooHigh_Sub16_PositiveInfinity()
        {
            Assert.AreEqual(double.PositiveInfinity, new Faculty(5000).ToResult());
        }

        [TestMethod]
        public void TooHigh_Over16_PositiveInfinity()
        {
            Assert.AreEqual(double.PositiveInfinity, new Faculty(int.MaxValue).ToResult());
        }

        [TestMethod]
        public void Correct0()
        {
            Assert.AreEqual(1, new Faculty(0).ToResult());
        }

        [TestMethod]
        public void Correct1()
        {
            Assert.AreEqual(1, new Faculty(1).ToResult());
        }

        [TestMethod]
        public void Correct5()
        {
            Assert.AreEqual(120, new Faculty(5).ToResult());
        }

        [DataTestMethod]
        [DataRow(5.5d)]
        [DataRow(5d - 1d/1000000000000d)]
        [DataRow(5d + 1d/1000000000000d)]
        [DataRow(0d + 5.6d + 5.8d - 0.4d)] // known bug.
        public void NonInteger_Throws(double nonInteger)
        {
            Assert.ThrowsException<NonIntegerFactorialException>(() => new Faculty(nonInteger).ToResult());
        }

        [DataTestMethod]
        [DataRow(double.PositiveInfinity)]
        [DataRow(double.NaN)]
        public void SubnormalPassThrough(double subnormal)
        {
            Assert.AreEqual(subnormal, new Faculty(subnormal).ToResult());
        }

        [DataTestMethod]
        [DataRow(double.NegativeInfinity)]
        [DataRow(-double.Epsilon)]
        [DataRow(-10d)]
        public void Negative(double negative)
        {
            Assert.ThrowsException<NegativeFactorialException>(() => new Faculty(negative).ToResult());
        }
    }
}