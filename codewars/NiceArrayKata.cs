using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class NiceArraySolution
    {
        public static bool IsNice(int[] arr) => arr.Length != 0 && arr.All(n => arr.Any(m => n - 1 == m || n + 1 == m));
    }

    public class NiceArrayTests
    {
        [Theory]
        [InlineData(new[] {2,10,9,3}, true)]
        [InlineData(new[] {3,4,5,7}, false)]
        [InlineData(new int[] {}, false)]
        public void VerifyIsNiceWith(int[] arr, bool expectedIsNice)
        {
            NiceArraySolution.IsNice(arr).Should().Be(expectedIsNice);
        }
    }
}
