using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class NiceArraySolution
    {
        public static bool IsNice(int[] arr)
        {
            throw new NotImplementedException();
        }
    }

    public class NiceArrayTests
    {
        [Theory]
        [InlineData(new int[] {2,10,9,3}, true)]
        [InlineData(new int[] {3,4,5,7}, false)]
        public void VerifyIsNiceWith(int[] arr, bool expectedIsNice)
        {
            NiceArraySolution.IsNice(arr).Should().Be(expectedIsNice);
        }
    }
}
