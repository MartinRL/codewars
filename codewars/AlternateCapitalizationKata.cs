namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class AlternateCapitalizationSolution
    {
        private static string CapitalizeEverySecond(string s, int fromIndex = 0) => new string(s.Select((c, i) => i % 2 == 0 ? c : char.ToUpper(c)).ToArray());

        public static string[] Capitalize(string s) => new [] { CapitalizeEverySecond(s), CapitalizeEverySecond(s, 1) };
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
