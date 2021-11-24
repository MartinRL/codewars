namespace codewars;

using System;
using FluentAssertions;
using Xunit;

public class JumpingNumberSolution
{
    public static string JumpingNumber(int number)
    {
        var digits = number.ToDigits();

        for (var i = 0; i < digits.Length - 1; i++)
        {
            if (Math.Abs(digits[i] - digits[i + 1]) != 1)
                return "Not!!";
        }

        return "Jumping!!";
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
    public void VerifyJumpingNumberWith(int number, string expected) => JumpingNumberSolution.JumpingNumber(number).Should().Be(expected);
}