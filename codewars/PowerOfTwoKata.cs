using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class PowerOfTwoSolution
    {
        public static bool IsPowerOfTwo(int n)
        {
            throw new NotImplementedException();
        }
    }

    public class PowerOfTwoTests
    {
        [Theory]
        [InlineData(2, true)]
        [InlineData(4096, true)]
        [InlineData(1024, true)]
        [InlineData(5, false)]
        [InlineData(333, false)]
        public void VerifyIsPowerOfTwqWith(int n, bool expected)
        {
            PowerOfTwoSolution.IsPowerOfTwo(n).Should().Be(expected);
        }
    }
}
