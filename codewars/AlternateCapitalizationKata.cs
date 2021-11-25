namespace codewars;

using static Char;

public class AlternateCapitalizationSolution
{
    private static string CapitalizeEverySecond(string s, int fromIndex = 0) => string.Concat(s.Select((c, i) => i % 2 != fromIndex % 2 ? c : ToUpper(c)));

    public static string[] Capitalize(string s) => new [] { CapitalizeEverySecond(s), CapitalizeEverySecond(s, 1) };
}

public class AlternateCapitalizationTests
{
    [Theory]
    [InlineData("abcdef", new [] { "AbCdEf", "aBcDeF" })]
    [InlineData("codewars", new [] { "CoDeWaRs", "cOdEwArS" })]
    [InlineData("abracadabra", new [] { "AbRaCaDaBrA", "aBrAcAdAbRa" })]
    [InlineData("codewarriors", new [] { "CoDeWaRrIoRs", "cOdEwArRiOrS" })]
    public void VerifyCapitalizeWith(string s, string[] capitalized) => AlternateCapitalizationSolution.Capitalize(s).Should().Equal(capitalized);
}