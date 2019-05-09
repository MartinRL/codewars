using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class DigitalCypherVol3MissingKeySolution
    {
        public static int FindTheKey(string message, int[] code)
        {
            return int.Parse(string.Join("", message
                    .Select(c => c - ('a' - 1))
                    .Zip(code, (c, n) => n - c)
                    .Select(_ => _.ToString()).ToArray())
                    .Repeating());
        }
    }

    public class DigitalCypherVol3MissingKeyTests
    {
        [Theory]
        [InlineData("scout", new[] { 20, 12, 18, 30, 21 } , 1939)]
        [InlineData("masterpiece", new[] { 14, 10, 22, 29, 6, 27, 19, 18, 6, 12, 8 } , 1939)]
        [InlineData("nomoretears", new[] { 15, 17, 14, 17, 19, 7, 21, 7, 2, 20, 20 } , 12)]
        public void VerifyFindTheKeyWith(string message, int[] code, int key)
        {
            DigitalCypherVol3MissingKeySolution.FindTheKey(message, code).Should().Be(key);
        }
    }
}
