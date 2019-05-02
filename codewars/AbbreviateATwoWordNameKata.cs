using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class AbbreviateATwoWordNameSolution
    {
        public static string AbbrevName(string name)
        {
            var names = name.Split(' ');

            return $"{names[0].First()}.{names[1].First()}";
        }
    }

    public class AbbreviateATwoWordNameTests
    {
        [Theory]
        [InlineData("Sam Harris", "S.H")]
        [InlineData("Patrick Feenan", "P.F")]
        [InlineData("Evan Cole", "E.C")]
        [InlineData("P Favuzzi", "P.F")]
        [InlineData("David Mendieta", "D.M")]
        public void VerifyAbbrevNameWith(string name, string expectedAbbreviation)
        {
            AbbreviateATwoWordNameSolution.AbbrevName(name).Should().Be(expectedAbbreviation);
        }
    }
}
