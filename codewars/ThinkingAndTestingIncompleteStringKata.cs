namespace codewars;

public class ThinkingAndTestingIncompleteStringSolution
{
    public static string TestIt(string s) => s.Length < 2 ? s : string.Concat((char)((s[0] + s[1]) / 2), TestIt(s.Substring(2)));
}

public class ThinkingAndTestingIncompleteStringTests
{
    [Theory]
    [InlineData("", "")]
    [InlineData("a", "a")]
    [InlineData("b", "b")]
    [InlineData("aa", "a")]
    [InlineData("ab", "a")]
    [InlineData("bc", "b")]
    [InlineData("aaaa", "aa")]
    [InlineData("aaaaaa", "aaa")]
    public void VerifyTestItWith(string s, string expected) => ThinkingAndTestingIncompleteStringSolution.TestIt(s).Should().Be(expected);
}
