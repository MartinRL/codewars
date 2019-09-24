using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class ConvertStringToCamelCaseSolution
    {
        public static string ToCamelCase(string str) => 
            new string(str.Select((e, i) => (i > 0 && (str.ElementAt(i - 1) == '_' || str.ElementAt(i - 1) == '-')) ? char.ToUpper(e) : e).ToArray())
                .Replace("_", string.Empty)
                .Replace("-", string.Empty);
    }

    public class ConvertStringToCamelCaseTests
    {
        [Theory]
        [InlineData("the_stealth_warrior", "theStealthWarrior")]
        [InlineData("The-Stealth-Warrior", "TheStealthWarrior")]
        public void VerifyToCamelCaseWith(string str, string expectedCamelCase)
        {
            ConvertStringToCamelCaseSolution.ToCamelCase(str).Should().Be(expectedCamelCase);
        }
    }
}
