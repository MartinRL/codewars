using System.Linq;
using FluentAssertions;
using Xunit;
using static System.Char;
using static System.Text.RegularExpressions.Regex;

namespace codewars
{
    public class AlphabetWarsNuclearStrikeSolution
    {
        public static string AlphabetWar(string battlefield)
        {
            if (!battlefield.Contains('#'))
                return battlefield.Where(IsLetter).AsString();

            var splitBattlefield = Split(battlefield, @"([\[\s.\]])");
            var survivors = string.Empty;
            bool Strike(char _) => _ == '#';

            for (var i = 1; i < splitBattlefield.Length - 3; i++)
            {
                if (splitBattlefield[i] == "[" && splitBattlefield[i - 1].Count(Strike) + splitBattlefield[i + 3].Count(Strike) <= 1)
                {
                    survivors += splitBattlefield[i + 1];
                }
            }

            return survivors;
        }
    }

    public class AlphabetWarsNuclearStrikeTests
    {
        [Theory]
        [InlineData("abde#fghijk", "")]
        [InlineData("abde[fgh]ijk", "abdefghijk")]
        [InlineData("ab#de[fgh]ijk", "fgh")]
        [InlineData("ab#de[fgh]ij#k", "")]
        [InlineData("##abde[fgh]ijk", "")]
        [InlineData("##abde[fgh]", "")]
        [InlineData("abde[fgh]", "abdefgh")]
        [InlineData("##abde[fgh]ijk[mn]op", "mn")]
        [InlineData("#abde[fgh]i#jk[mn]op", "mn")]
        [InlineData("[ab]adfd[dd]##[abe]dedf[ijk]d#d[h]#", "abijk")]
        public void VerifyAlphabetWarWith(string battlefield, string expectedSurvivors) => AlphabetWarsNuclearStrikeSolution.AlphabetWar(battlefield).Should().Be(expectedSurvivors);
    }
}
