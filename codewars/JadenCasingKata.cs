namespace codewars;

using static System.Globalization.CultureInfo;

public static class JadenCasingSolution
{
    public static string JadenCase(string s) => CurrentCulture.TextInfo.ToTitleCase(s);
}

public class JadenCasingTests
{
    [Theory]
    [InlineData("How can mirrors be real if our eyes aren't real", "How Can Mirrors Be Real If Our Eyes Aren't Real")]
    [InlineData("this is me", "This Is Me")]
    public void VerifyJadenCaseWith(string s, string jadenCased) => JadenCasingSolution.JadenCase(s).Should().Be(jadenCased);
}
