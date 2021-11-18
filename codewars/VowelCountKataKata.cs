namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public static class VowelCountSolution
    {
        public static int GetVowelCount(string str) => str.Count(c => "aeiou".Contains(c));
    }

    public class VowelCountTests
    {
        [Theory]
        [InlineData("abracadabra", 5)]
        public void VerifyGetVowelCountWith(string str, int expectedVowelCount) => VowelCountSolution.GetVowelCount(str).Should().Be(expectedVowelCount);
    }
}
