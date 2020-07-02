namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class AlternateCapitalizationSolution
    {
        public static string[] Capitalize(string s) => throw new NotImplementedException();
    }

    public class AlternateCapitalizationTests
    {
        [Theory]
        [InlineData("abcdef", new [] { "AbCdEf", "aBcDeF" })]
        [InlineData("codewars", new [] { "CoDeWaRs", "cOdEwArS" })]
        [InlineData("abracadabra", new [] { "AbRaCaDaBrA", "aBrAcAdAbRa" })]
        [InlineData("codewarriors", new [] { "CoDeWaRrIoRs", "cOdEwArRiOrS" })]
        public void VerifyCapitalizeWith(string s, string[] capitalized) => AlternateCapitalizationSolution.Capitalize(s).Should().BeEquivalentTo(capitalized);
    }
}
