using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class AlphabetWarsNuclearStrikeSolution
    {
        public static string AlphabetWar(string battlefield)
        {
            throw new NotImplementedException();
        }
    }

    public class AlphabetWarsNuclearStrikeTests
    {
        [Theory]
        [InlineData("abde[fgh]ijk", "abdefghijk")]
        [InlineData("ab#de[fgh]ijk", "fgh")]
        [InlineData("ab#de[fgh]ij#k", "")]
        [InlineData("##abde[fgh]ijk", "")]
        [InlineData("##abde[fgh]", "")]
        [InlineData("abde[fgh]", "abdefgh")]
        [InlineData("##abde[fgh]ijk[mn]op", "mn")]
        [InlineData("#abde[fgh]i#jk[mn]op", "mn")]
        [InlineData("[ab]adfd[dd]##[abe]dedf[ijk]d#d[h]#", "abijk")]
        public void VerifyAlphabetWarWith(string battlefield, string expectedSurvivors)
        {
            AlphabetWarsNuclearStrikeSolution.AlphabetWar(battlefield).Should().Be(expectedSurvivors);
        }
    }
}
