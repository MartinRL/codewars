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
        public static string Encode(string text) => text.Select(ToInt32).Select(To8BitBinary).AggregateString().Select(c => new string(c, 3)).AggregateString();

        public static string Decode(string text) => text.TakeEvery(3)
            .Select(s => s.First().ToString())
            .AggregateString()
            .TakeEvery(8)
            .Select(s => Convert.ToInt32(s, 2))
            .Select(ToChar)
            .Select(c => c.ToString())
            .AggregateString();

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

    public static class ErrorCorrectionNo1HammingCodeExtension
    {
        public static string AggregateString(this IEnumerable<string> @this) => @this.Aggregate((src, accu) => $"{src}{accu}");

        public static IEnumerable<string> TakeEvery(this string @this, int chunkSize)
        {
            var remainder = @this;
            var chunks = new List<string>();

            while (remainder.Length > chunkSize)
            {
                chunks.Add(remainder.Substring(0, chunkSize));
                remainder = remainder.Substring(chunkSize);
            }

            if (remainder != string.Empty)
                chunks.Add(remainder);

            return chunks;
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
        [InlineData("000111111000111000000000000111111000000111000111000111111111111000000111", "hey")]
        [InlineData("000111000111000111000000000111111000111000000000000111111000000111000111000000111000000000000000000111000111000000111111000111111000000111000111000111111000111111111000000111111111000000111111000111111000000111000111000111111000111000000111000000111000000000000000000111111111000111000000000111111000111111111111000111111000111111000000000111111000000111000000000000111000000000000000000111111000111111000111000111111000000111000111000000111000000000000000000111111111000111000000000111111000111000000000000111111000000000000111000111111111000111000000000000111000000000000000000111111000111000000111000000111000000000000000000111111000000000111111000111111000000000000111000111111000111111111000000000111000000000000000000111111000000111000000000111111000111111111111000000111000000000000000000111111111000111000000000111111000111000000000000111111000111000000111000111111111000000111111000000111000000000000000000111111000111000111111000111111000000000000111000111111111000111000000000111111000000000000111", "The Sensei told me that i can do this kata")]
        [InlineData("000111000111000111000000000000111111000000111111000111111111000000111111000111111111000111000000", "T3st")]
        [InlineData("000111000111000111000000000000111111111111111111000111111111000000111111000111111111000111000000000000111000000000000111000000111000000111000111", "T?st!%")]
        public void VerifyDecodeWith(string text, string expectedDecoding) => ErrorCorrectionNo1HammingCodeSolution.Decode(text).Should().Be(expectedDecoding);

        [Theory]
        [InlineData(104, "01101000")]
        [InlineData(101, "01100101")]
        [InlineData(121, "01111001")]
        public void VerifyTo8BitBinaryWith(int baseTen, string expectedBinary) => ErrorCorrectionNo1HammingCodeSolution.To8BitBinary(baseTen).Should().Be(expectedBinary);
    }
}
