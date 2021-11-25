namespace codewars;

using static Char;
using static Regex;

public class AlphabetWarsNuclearStrikeSolution
{
    public static string AlphabetWar(string battlefield)
    {
        if (!battlefield.Contains('#'))
            return battlefield.Where(IsLetter).AsString();

        var splitBattlefield = Split(battlefield, @"([\[\s.\]])");
        bool Strike(char _) => _ == '#';

        return splitBattlefield
            .Skip(1)
            .Take(splitBattlefield.Length - 3)
            .Where((s, i) => splitBattlefield[i] == "[" && splitBattlefield[i - 1].Count(Strike) + splitBattlefield[i + 3].Count(Strike) <= 1)
            .Aggregate(string.Empty, (survivors, next) => survivors + next)
            .AsString();
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
    public void VerifyAlphabetWarWith(string battlefield, string expectedSurvivors) =>
        AlphabetWarsNuclearStrikeSolution.AlphabetWar(battlefield).Should().Be(expectedSurvivors);
}