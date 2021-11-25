namespace codewars;

public static class MumblingSolution
{
    public static string Accum(string s) => string.Join("-",
        s.ToCharArray()
            .Select((c, i) => char.ToUpper(c).ToString() + new string(char.ToLower(c), i)));
}

public class MumblingTests
{
    [Theory]
    [InlineData("abcd", "A-Bb-Ccc-Dddd")]
    [InlineData("RqaEzty", "R-Qq-Aaa-Eeee-Zzzzz-Tttttt-Yyyyyyy")]
    [InlineData("cwAt", "C-Ww-Aaa-Tttt")]
    public void VerifyAccumWith(string s, string accummed) => MumblingSolution.Accum(s).Should().Be(accummed);
}