namespace codewars
{
    using FluentAssertions;
    using Xunit;

    public static class GetTheMiddleCharacterSolution
    {
        public static string GetMiddle(string s)
        {
            var quotient = s.Length / 2;

            if (s.Length % 2 == 0)
                return s[quotient - 1].ToString() + s[quotient];

            return s[quotient].ToString();
        }
    }

    public class GetTheMiddleCharacterTests
    {
        [Theory]
        [InlineData("test", "es")]
        [InlineData("testing", "t")]
        [InlineData("middle", "dd")]
        [InlineData("A", "A")]
        public void VerifyGetMiddleWith(string argument, string expected) => GetTheMiddleCharacterSolution.GetMiddle(argument).Should().Be(expected);
    }
}
