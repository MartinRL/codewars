using codewars;
using FluentAssertions;
using Xunit;

namespace codewars
{
    using static System.Double;
    using static Microsoft.CodeAnalysis.CSharp.Scripting.CSharpScript;
    using FluentAssertions;
    using Xunit;

    public class CalculatorSolution
    {
        public static double Evaluate(string expression) => Parse(EvaluateAsync(expression).Result.ToString());
    }

    public class CalculatorTests
    {
        [Theory]
        [InlineData("2 / 2 + 3 * 4 - 6", 7)]
        [InlineData("2 / 2 + 3 * 4 / 2 - 6", 1)]
        [InlineData("1+1", 2)]
        [InlineData("1 - 1", 0)]
        [InlineData("1* 1", 1)]
        [InlineData("1 /1", 1)]
        public void VerifyEvaluateWith(string expression, double expectedEvaluation) => CalculatorSolution.Evaluate(expression).Should().Be(expectedEvaluation);
    }
}
