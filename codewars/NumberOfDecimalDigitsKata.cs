namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class NumberOfDecimalDigitsSolution
    {
        public static int Digits(ulong n) => n.ToString().Length;
    }

    public class NumberOfDecimalDigitsTests
    {
        [Theory]
        [InlineData(5ul, 1)]
        [InlineData(12345ul, 5)]
        [InlineData(9876543210ul, 10)]
        public void VerifyDigitsWith(ulong n, int expectedNoOfDecimalDigits) => NumberOfDecimalDigitsSolution.Digits(n).Should().Be(expectedNoOfDecimalDigits);
    }
}
