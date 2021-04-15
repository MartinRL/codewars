namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class WeightForWeightKataSolution
    {
        public static string OrderWeight(string weights) => throw new NotImplementedException();
    }

    public class WeightForWeightKataTests
    {
        [Theory]
        [InlineData("2000 103 123 4444 99", "103 123 4444 99 2000")]
        [InlineData("11 11 2000 10003 22 123 1234000 44444444 9999", "2000 10003 1234000 44444444 9999 11 11 22 123")]
        public void VerifyOrderWeightWith(string weights, string expectedOrderedWeights) => WeightForWeightKataSolution.OrderWeight(weights).Should().Be(expectedOrderedWeights);
    }
}
