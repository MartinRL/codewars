namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class HammingDistanceBinaryCodesSolution
    {
        public static int CalculateDistance(string a, string b) => a.Zip(b, (ca, cb) => ca != cb).Count(_ => _);
    }

    public class HammingDistanceBinaryCodesTests
    {
        [Theory]
        [InlineData("100101", "101001", 2)]
        [InlineData("1010", "0101", 4)]
        [InlineData("100101011011010010010", "101100010110010110101", 9)]
        public void VerifyCalculateDistanceWith(string a, string b, int expectedDistance) => HammingDistanceBinaryCodesSolution.CalculateDistance(a, b).Should().Be(expectedDistance);
    }
}
