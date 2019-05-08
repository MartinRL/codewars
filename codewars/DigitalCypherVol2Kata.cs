using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class DigitalCypherVol2Solution
    {
        public static string Decode(int[] code, int key)
        {
            throw new NotImplementedException();
        }
    }

    public class DigitalCypherVol2Tests
    {
        [Theory]
        [InlineData(new[] {20, 12, 18, 30, 21}, 1939, "scout")]
        [InlineData(new[] {14, 10, 22, 29, 6, 27, 19, 18, 6, 12, 8}, 1939, "masterpiece")]
        public void VerifyDecodeWith(int[] code, int key, string expected)
        {
            DigitalCypherVol2Solution.Decode(code, key).Should().Be(expected);
        }
    }
}
