using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class AlphabeticAnagramsSolution
    {
        public static long ListPosition(string value)
        {
            throw new NotImplementedException();
        }
    }

    public class AlphabeticAnagramsTests
    {
        [Theory]
        [InlineData("A", 1)]
        [InlineData("ABAB", 2)]    
        [InlineData("AAAB", 1)]
        [InlineData("BAAA", 4)]
        [InlineData("QUESTION", 24572)]
        [InlineData("BOOKKEEPER", 10743)]
        public void VerifyListPositionWith(string value, long expectedPosition)
        {
            AlphabeticAnagramsSolution.ListPosition(value).Should().Be(expectedPosition);
        }
    }
}
