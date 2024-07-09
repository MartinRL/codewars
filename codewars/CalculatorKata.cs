namespace codewars;

public class CalculatorSolution
{
    public static double Evaluate(string expression) => expression.Compute();
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
