using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using static System.Int64;

namespace codewars
{
    public class SupersizeMeSolution
    {
        public static long Supersize(long num) => Parse(new string(num.ToString().OrderByDescending(_ => _).ToArray()));
    }

    public class SupersizeMeTests
    {
        [Theory]
        [InlineData(69, 96)]
        [InlineData(513, 531)]
        [InlineData(2017, 7210)]
        [InlineData(414, 441)]
        [InlineData(608719, 987610)]
        [InlineData(123456789, 987654321)]
        [InlineData(700000000001, 710000000000)]
        [InlineData(666666, 666666)]
        [InlineData(2, 2)]
        public void VerifySupersizeWith(long num, long expectedSupersizedNum) => SupersizeMeSolution.Supersize(num).Should().Be(expectedSupersizedNum);
    }
}
