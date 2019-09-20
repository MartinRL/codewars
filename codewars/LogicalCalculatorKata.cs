using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class LogicalCalculatorSolution
    {
        public static bool LogicalCalc(bool[] array, string op)
        {
            return array.Aggregate((result, item) =>
            {
                if (op == "AND")
                    return result && item;

                return result || item;
            });
        }
    }

    public class LogicalCalculatorTests
    {
        [Theory]
        [InlineData(new bool[] { true, true, true, false }, "AND", false)]
        [InlineData(new bool[] { true, true, true, false }, "OR", true)]
        [InlineData(new bool[] { true, true, true, false }, "XOR", true)]
        public void VerifyLogicalCalcWith(bool[] array, string op, bool expectedLogicalValue)
        {
            LogicalCalculatorSolution.LogicalCalc(array, op).Should().Be(expectedLogicalValue);
        }
    }
}
