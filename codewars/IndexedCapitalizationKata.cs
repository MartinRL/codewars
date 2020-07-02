namespace codewars
{
    using System;
    using static System.Char;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class IndexedCapitalizationSolution
    {
        public static string Capitalize(string s, List<int> idxs) => new string(s.Select((c, i) => idxs.Contains(i) ? ToUpper(c) : c).ToArray());
    }

    public class IndexedCapitalizationTests
    {
        [Theory]
        [InlineData("abcdef", new [] { 1, 2, 5 }, "aBCdeF")]
        [InlineData("abcdef", new [] { 1, 2, 5, 100 }, "aBCdeF")]
        [InlineData("abcdef", new [] { 1, 100, 2, 5 }, "aBCdeF")]
        [InlineData("codewars", new [] { 1, 3, 5, 50 }, "cOdEwArs")]
        [InlineData("abracadabra", new [] { 2, 6, 9, 10 }, "abRacaDabRA")]
        [InlineData("codewarriors", new [] { 5 }, "codewArriors")]
        [InlineData("indexinglessons", new [] { 0 }, "Indexinglessons")]
        public void VerifyCapitalizeWith(string s, IEnumerable<int> idxs, string capitalized) => IndexedCapitalizationSolution.Capitalize(s, idxs.ToList()).Should().Be(capitalized);
    }
}
