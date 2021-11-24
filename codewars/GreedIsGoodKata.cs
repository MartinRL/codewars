namespace codewars;

using System.Linq;
using FluentAssertions;
using Xunit;

public static class GreedIsGoodSolution
{
    public static int Score(int[] dice)
    {
        return dice
            .GroupBy(d => d)
            .Select(g => Points(g.Key, g.Count()))
            .Sum();
    }

    private static int Points(int die, int count)
    {
        switch (die)
        {
            case 1:
                return count / 3 * 1000 + count % 3 * 100;
            case 5:
                return count / 3 * 500 + count % 3 * 50;
            default:
                return count / 3 * die * 100;
        }
    }
}

public class GreedIsGoodTests
{
    [Theory]
    [InlineData(new[] {2, 3, 4, 6, 2}, 0)]
    [InlineData(new[] {2, 2, 2, 2, 2}, 200)]
    [InlineData(new[] {2, 3, 3, 6, 3}, 300)]
    [InlineData(new[] {4, 4, 4, 3, 3}, 400)]
    [InlineData(new[] {2, 6, 6, 5, 6}, 650)]
    [InlineData(new[] {2, 4, 4, 5, 4}, 450)]
    [InlineData(new[] {2, 4, 5, 5, 5}, 500)]
    [InlineData(new[] {6, 4, 5, 5, 5}, 500)]
    [InlineData(new[] {5, 1, 3, 4, 1}, 250)]
    [InlineData(new[] {1, 1, 1, 3, 1}, 1100)]
    public static void VerifyScoreWith(int[] dice, int score) => GreedIsGoodSolution.Score(dice).Should().Be(score);
}