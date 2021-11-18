namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public static class VowelCountSolution
    {
        public static int GetVowelCount(string str) => throw new NotImplementedException();
    }

    public class VowelCountTests
    {
        [Theory]
        [InlineData("abracadabra", 5)]
        public void VerifyGetVowelCountWith(string str, int expectedVowelCount) => VowelCountSolution.GetVowelCount(str).Should().Be(expectedVowelCount);
    }
}
