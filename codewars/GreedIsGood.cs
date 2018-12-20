using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class GreedIsGoodKata
    {
        public static int Score(int[] dice)
        {
            var points = 0;
            var orderedDice = dice.OrderBy(_ => _);

            if (orderedDice.Count(_ => _ == 1) >= 3)
            {
                points += 1000;
                orderedDice = orderedDice.Skip(3).OrderBy(_ => _);
            }

            if (orderedDice.Count(_ => _ == 5) >= 3)
            {
                points += 500;
                orderedDice = orderedDice.Where(_ => _ != 6).OrderByDescending(_ => _).Skip(3).OrderBy(_ => _);
            }
            
            new [] { 6, 4, 3, 2 }.Where(side => orderedDice.Count(d => d == side) >= 3).Each(side => points+= side * 100);
            
            points += orderedDice.Count(_ => _ == 1) * 100;
            points += orderedDice.Count(_ => _ == 5) * 50;

            return points;
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
        public static void ShouldBeWorthless(int[] dice, int score)
        {
            GreedIsGoodKata.Score(dice).Should().Be(score);
        }
    }
}
