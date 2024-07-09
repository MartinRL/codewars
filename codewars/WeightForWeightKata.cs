namespace codewars;

using static Char;

public class WeightForWeightKataSolution
{
    public static string OrderWeight(string weights) => weights.Split(' ').OrderBy(_ => _.Sum(GetNumericValue)).ThenBy(_ => _).Aggregate((x, y) => $"{x} {y}");
}

public class WeightForWeightKataTests
{
    [Theory]
    [InlineData("103 123 4444 99 2000", "2000 103 123 4444 99")]
    [InlineData("2000 10003 1234000 44444444 9999 11 11 22 123", "11 11 2000 10003 22 123 1234000 44444444 9999")]
    public void VerifyOrderWeightWith(string weights, string expectedOrderedWeights) => WeightForWeightKataSolution.OrderWeight(weights).Should().Be(expectedOrderedWeights);
}
