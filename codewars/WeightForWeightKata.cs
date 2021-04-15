namespace codewars
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class WeightForWeightKataSolution
    {
        public static string OrderWeight(string weights) => weights.Split(" ").OrderBy(_ => _, new WeightComparer()).Aggregate((x, y) => $"{x} {y}");
    }

    public class WeightComparer : IComparer<string>
    {
        public int Compare(string x, string y) => x.WeightedWeight() > y.WeightedWeight() ? 1 : x.WeightedWeight() < y.WeightedWeight() ? -1 : string.Compare(x, y);
    }

    public static class WeightForWeightKataExtensions
    {
        public static long WeightedWeight(this string @this) => @this.Sum(c => uint.Parse(c.ToString(), NumberStyles.Integer));
    }

    public class WeightForWeightKataTests
    {
        [Theory]
        [InlineData("103 123 4444 99 2000", "2000 103 123 4444 99")]
        [InlineData("2000 10003 1234000 44444444 9999 11 11 22 123", "11 11 2000 10003 22 123 1234000 44444444 9999")]
        public void VerifyOrderWeightWith(string weights, string expectedOrderedWeights) => WeightForWeightKataSolution.OrderWeight(weights).Should().Be(expectedOrderedWeights);
    }

    public class WeightComparerTests
    {
        [Theory]
        [InlineData("99", "100", 1)]
        [InlineData("100", "99", -1)]
        [InlineData("100", "100", 0)]
        public void VerifyOrderWeightWith(string weight1, string weight2, int expectedComparison) => new WeightComparer().Compare(weight1, weight2).Should().Be(expectedComparison);
    }

    public class WeightForWeightExtensionsTests
    {
        [Theory]
        [InlineData("99", 18)]
        [InlineData("100", 1)]
        public void VerifyOrderWeightWith(string weight, long expectedWeightedWeight) => weight.WeightedWeight().Should().Be(expectedWeightedWeight);
    }
}
