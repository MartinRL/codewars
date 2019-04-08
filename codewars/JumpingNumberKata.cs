using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class JumpingNumberSolution
    {
        public static string JumpingNumber(int number)
        {
            throw new NotImplementedException();
        }
    }

    public class JumpingNumberTests
    {
        [Theory]
        [InlineData(1, "Jumping!!")]
        [InlineData(7, "Jumping!!")]
        [InlineData(9, "Jumping!!")]
        [InlineData(23, "Jumping!!")]
        [InlineData(32, "Jumping!!")]
        [InlineData(98, "Jumping!!")]
        [InlineData(8987, "Jumping!!")]
        [InlineData(4343456, "Jumping!!")]
        [InlineData(98789876, "Jumping!!")]
        [InlineData(00000079, "Not!!")]
        public void VerifyJumpingNumberWith(int number, string expected)
        {
            JumpingNumberSolution.JumpingNumber(number).Should().Be(expected);
        }
    }
}
