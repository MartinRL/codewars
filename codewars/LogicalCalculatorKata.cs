using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class LogicalCalculatorSolution
    {
        public static bool LogicalCalc(bool[] array, string op) => array.Aggregate((result, item) => op == "AND" ? result && item : op == "OR" ? result || item : result != item);
    }

    public class LogicalCalculatorTests
    {
        [Theory]
        [InlineData(new bool[] { true, true, true, false }, "AND", false)]
        [InlineData(new bool[] { true, true, true, false }, "OR", true)]
        [InlineData(new bool[] { true, true, true, false }, "XOR", true)]
        public void VerifyLogicalCalcWith(bool[] array, string op, bool expectedLogicalValue) => LogicalCalculatorSolution.LogicalCalc(array, op).Should().Be(expectedLogicalValue);
    }
}
