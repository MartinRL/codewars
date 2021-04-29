namespace codewars
{
    using System;
    using System.Linq;
    using static System.Convert;
    using FluentAssertions;
    using Xunit;

    public class ErrorCorrectionNo1HammingCodeSolution
    {
        public static string Encode(string text) => text.Select(ToInt32).Select(To8BitBinary).Aggregate((_, __) => $"{_} {__}");

        public static string To8BitBinary(int baseTen)
        {
            var result = string.Empty;
            
            while (baseTen > 1)
            {
                var remainder = baseTen % 2;
                result = Convert.ToString(remainder) + result;
                baseTen /= 2;
            }

            return (Convert.ToString(baseTen) + result).PadLeft(8, '0');
        }
    }

    public class ErrorCorrectionNo1HammingCodeTests
    {
        [Theory]
        [InlineData("hey", "000111111000111000000000000111111000000111000111000111111111111000000111")]
        [InlineData("The Sensei told me that i can do this kata", "000111000111000111000000000111111000111000000000000111111000000111000111000000111000000000000000000111000111000000111111000111111000000111000111000111111000111111111000000111111111000000111111000111111000000111000111000111111000111000000111000000111000000000000000000111111111000111000000000111111000111111111111000111111000111111000000000111111000000111000000000000111000000000000000000111111000111111000111000111111000000111000111000000111000000000000000000111111111000111000000000111111000111000000000000111111000000000000111000111111111000111000000000000111000000000000000000111111000111000000111000000111000000000000000000111111000000000111111000111111000000000000111000111111000111111111000000000111000000000000000000111111000000111000000000111111000111111111111000000111000000000000000000111111111000111000000000111111000111000000000000111111000111000000111000111111111000000111111000000111000000000000000000111111000111000111111000111111000000000000111000111111111000111000000000111111000000000000111")]
        [InlineData("T3st", "000111000111000111000000000000111111000000111111000111111111000000111111000111111111000111000000")]
        [InlineData("T?st!%", "000111000111000111000000000000111111111111111111000111111111000000111111000111111111000111000000000000111000000000000111000000111000000111000111")]
        public void VerifyEncodeWith(string text, string expectedEncoding) => ErrorCorrectionNo1HammingCodeSolution.Encode(text).Should().Be(expectedEncoding);

        [Theory]
        [InlineData(104, "01101000")]
        [InlineData(101, "01100101")]
        [InlineData(121, "01111001")]
        public void VerifyTo8BitBinaryWith(int baseTen, string expectedBinary) => ErrorCorrectionNo1HammingCodeSolution.To8BitBinary(baseTen).Should().Be(expectedBinary);
    }
}
