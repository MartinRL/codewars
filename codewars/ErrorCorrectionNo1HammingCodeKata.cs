namespace codewars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static System.Convert;
    using FluentAssertions;
    using Xunit;

    public class ErrorCorrectionNo1HammingCodeSolution
    {
        public static string Encode(string text) => text
            .SelectMany(c => Convert.ToString(c, 2).PadLeft(8, '0'))
            .Aggregate(string.Empty, (c, n) => c + new string(n, 3));

        public static string Decode(string bits) => bits
            .ToChunks(3)
            .Select(GetBit)
            .ToChunks(8)
            .Select(s => ToInt32(s, 2))
            .Select(ToChar)
            .Select(c => c.ToString())
            .AggregateString();

        public static char GetBit(IEnumerable<char> @this) => @this.Count(c => c == '1') >= 2 ? '1' : '0';

    }

    public static class ErrorCorrectionNo1HammingCodeExtension
    {
        public static string AggregateString(this IEnumerable<string> @this) => @this.Aggregate((src, accu) => $"{src}{accu}");

        public static IEnumerable<string> ToChunks(this IEnumerable<char> @this, int size)
        {
            for (var i = 0; i < @this.Count(); i += size)
                yield return string.Concat(@this.Skip(i).Take(size));
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
        [InlineData("100111111000111001000010000111111000000111001111000111110110111000010111", "hey")]
        [InlineData("000111000111000111000100000111111000111000001000000111111000000111000111000100111000000000000000000111000111000000111111000111111000000111000111000111111000111111111000000111111111000000111111000110111000010111000111000111111000111001000111000000111000000000000000000111111111000111000000000111111000111111111111000111111000111111000000000111111000000111000001000000111000000000001000000111111000111111000111000111111000000111000111000000111000000000000000000111111111000111000000000111111000111000000000000111111000000010000111000111111111000111000000000100111000000000000000000111111000111000000111000000111000000000000000000111111000000000111111000111111000000000000111000111111000111111111000000000111000000000000010000111111000000111000000000111111000111111110111000000111000000000000000000111111111000111000000000111111000111000000000000111111000111000000111000111111111000000111111000000111000000000000000000111111000111000111111000111111000000000000111000111111111000111000000000111111000000000000111", "The Sensei told me that i can do this kata")]
        [InlineData("000111000111000111000001000000111111000000111111000111111111000000111011000111111111000111000000", "T3st")]
        [InlineData("000111000111000111000010000000111111111111011111000111111111000000111111000111101111000111000000000000111000000000000111000000111000000111000111", "T?st!%")]
        public void VerifyDecodeWith(string text, string expectedDecoding) => ErrorCorrectionNo1HammingCodeSolution.Decode(text).Should().Be(expectedDecoding);
    }
}
