using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Calculator.Exceptions;
using Test.Calculator.Operations;

namespace Test.Calculator.Tests
{
    /// <summary>
    /// Tests for the <see cref="Faculty"/> operation.
    /// </summary>
    [TestClass]
    public class FacultyTests
    {
        /// <summary>
        /// Values less than 16 bits are handled differently than values more than 16 bits in code.
        /// This test is for sub-16 bits values.
        /// </summary>
        [TestMethod]
        public void TooHigh_Sub16_PositiveInfinity()
        {
            Assert.AreEqual(double.PositiveInfinity, new Faculty(5000).ToResult());
        }

        /// <summary>
        /// Values less than 16 bits are handled differently than values more than 16 bits in code.
        /// This test is for more than 16 bits values.
        /// </summary>
        [TestMethod]
        public void TooHigh_Over16_PositiveInfinity()
        {
            Assert.AreEqual(double.PositiveInfinity, new Faculty(int.MaxValue).ToResult());
        }

        /// <summary>
        /// Correct zero handling.
        /// </summary>
        [TestMethod]
        public void Correct0()
        {
            Assert.AreEqual(1, new Faculty(0).ToResult());
        }

        /// <summary>
        /// Correct 1 handling.
        /// </summary>
        [TestMethod]
        public void Correct1()
        {
            Assert.AreEqual(1, new Faculty(1).ToResult());
        }

        /// <summary>
        /// A regular test.
        /// </summary>
        [TestMethod]
        public void Correct5()
        {
            Assert.AreEqual(120, new Faculty(5).ToResult());
        }

        /// <summary>
        /// Correct handling of non-integers.
        /// </summary>
        [DataTestMethod]
        [DataRow(5.5d)]
        [DataRow(5d - 1d/1000000000000d)]
        [DataRow(5d + 1d/1000000000000d)]
        [DataRow(0d + 5.6d + 5.8d - 0.4d)] // known bug.
        public void NonInteger_Throws(double nonInteger)
        {
            Assert.ThrowsException<NonIntegerFactorialException>(() => new Faculty(nonInteger).ToResult());
        }

        /// <summary>
        /// Correct handling of subnormal values.
        /// </summary>
        [DataTestMethod]
        [DataRow(double.PositiveInfinity)]
        [DataRow(double.NaN)]
        public void SubnormalPassThrough(double subnormal)
        {
            Assert.AreEqual(subnormal, new Faculty(subnormal).ToResult());
        }

        /// <summary>
        /// Correct handling of negative values, including the subnormal ones.
        /// </summary>
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