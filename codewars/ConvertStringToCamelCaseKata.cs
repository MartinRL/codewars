namespace codewars
{
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ConvertStringToCamelCaseSolution
    {
        public static string ToCamelCase(string str) => string.Concat(str.Split('-', '_').Select((s, i) => i > 0 ? char.ToUpper(s[0]) + s.Substring(1) : s));
    }

    public class ConvertStringToCamelCaseTests
    {
        [Theory]
        [InlineData("the_stealth_warrior", "theStealthWarrior")]
        [InlineData("The-Stealth-Warrior", "TheStealthWarrior")]
        public void VerifyToCamelCaseWith(string str, string expectedCamelCase) => ConvertStringToCamelCaseSolution.ToCamelCase(str).Should().Be(expectedCamelCase);
    }
}
