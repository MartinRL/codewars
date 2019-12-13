namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class HammingDistanceBinaryNotationSolution
    {
        public static int CalculateDistance(int a, int b)
        {
            return Convert.ToString(a, 2).Zip(Convert.ToString(b, 2), (ca, cb) => !ca.Equals(cb)).Count(_ => _);
        }
    }

    public class HammingDistanceBinaryNotationTests
    {
        [Theory]
        [InlineData(25,87, 4)]
        [InlineData(256,302, 4)]
        [InlineData(34013,702, 7)]
        public void VerifyCalculateDistanceWith(int a, int b, int expectedDistance) => HammingDistanceBinaryNotationSolution.CalculateDistance(a, b).Should().Be(expectedDistance);
    }
}
