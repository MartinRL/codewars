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
            if (op == "XOR")
                return array.Aggregate((result, item) => result ^ item);
            
            if (op == "OR")
                return array.Aggregate((result, item) => result || item);
            
            return array.Aggregate((result, item) => result && item);
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
