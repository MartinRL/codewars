namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class CalculatorSolution
    {
        public static double Evaluate(string expression) => throw new NotImplementedException();
    }

    public class CalculatorTests
    {
        [Theory]
        [InlineData("2 / 2 + 3 * 4 - 6", 7)]
        [InlineData("1+1", 2)]
        [InlineData("1 - 1", 0)]
        [InlineData("1* 1", 1)]
        [InlineData("1 /1", 1)]
        public void VerifyEvaluateWith(string expression, double expectedEvaluation) => CalculatorSolution.Evaluate(expression).Should().Be(expectedEvaluation);
    }
}
