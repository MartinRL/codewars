using System;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class GreedIsGoodKata
    {
        public static int Score(int[] dice) 
        {
            throw new NotImplementedException();
        }
    }

    public class GreedIsGoodTests
    {
        [Theory]
        [InlineData(new[] {2, 3, 4, 6, 2}, 0)]
        [InlineData(new[] {4, 4, 4, 3, 3}, 400)]
        [InlineData(new[] {2, 4, 4, 5, 4}, 450)]
        [InlineData(new[] {5, 1, 3, 4, 1}, 250)]
        [InlineData(new[] {1, 1, 1, 3, 1}, 1100)]
        public static void ShouldBeWorthless(int[] dice, int score)
        {
            GreedIsGoodKata.Score(dice).Should().Be(score);
        }
    }
}
