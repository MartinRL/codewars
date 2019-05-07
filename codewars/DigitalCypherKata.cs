using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class DigitalCypherSolution
    {
        public static int[] Encode(string str, int n)
        {
            throw new NotImplementedException();
        }
    }

    public class DigitalCypherTests
    {
        [Theory]
        [InlineData("scout", 1939, new[] {20, 12, 18, 30, 21})]
        [InlineData("masterpiece", 1939, new[] {14, 10, 22, 29, 6, 27, 19, 18, 6, 12, 8})]
        public void VerifyEncodeWith(string str, int n, int[] expected)
        {
            DigitalCypherSolution.Encode(str, n).Should().AllBeEquivalentTo(expected);
        }
    }
}
