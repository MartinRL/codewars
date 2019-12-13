namespace codewars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class HammingDistanceBinaryNotationSolution
    {
        public static int CalculateDistance(int a, int b)
        {
            var aAsBinaryString = a.ToBinaryString();
            var bAsBinaryString = b.ToBinaryString();

            if (aAsBinaryString.Length > bAsBinaryString.Length)
            {
                bAsBinaryString = bAsBinaryString.PadLeft(aAsBinaryString.Length, '0');
            }
            else
            {
                aAsBinaryString = aAsBinaryString.PadLeft(bAsBinaryString.Length, '0');
            }

            return aAsBinaryString.Zip(bAsBinaryString, (ca, cb) => !ca.Equals(cb)).Count(_ => _);
        }
    }

    public static class HammingDistanceBinaryNotationSolutionExtensions
    {
        public static string ToBinaryString(this int @this) => Convert.ToString(@this, 2);
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
