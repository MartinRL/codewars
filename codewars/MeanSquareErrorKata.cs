using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class MeanSquareErrorSolution
    {
        public static double Solution(int[] firstArray, int[] secondArray)
        {
            return firstArray.Zip(secondArray, (f, s) => Math.Pow(Math.Abs(f - s), 2)).Average();
        }
    }

    public class MeanSquareErrorTests
    {
        [Theory]
        [InlineData(new[] {1, 2, 3}, new[] {4, 5, 6}, 9)]
        [InlineData(new[] {10, 20, 10, 2}, new[] {10, 25, 5, -2}, 16.5)]
        [InlineData(new[] {0, -1}, new[] {-1, 0}, 1)]
        public void VerifySolutionWith(int[] firstArray, int[] secondArray, double expectedAverage)
        {
            MeanSquareErrorSolution.Solution(firstArray, secondArray).Should().Be(expectedAverage);
        }
    }
}
