using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class ConvertStringToCamelCaseSolution
    {
        public static string ToCamelCase(string str)
        {
            throw new NotImplementedException();
        }
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
