namespace codewars;

using static Char;

public class IndexedCapitalizationSolution
{
    public static string Capitalize(string s, List<int> idxs) => string.Concat(s.Select((c, i) => idxs.Contains(i) ? ToUpper(c) : c));
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
