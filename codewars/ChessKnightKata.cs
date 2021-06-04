namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ChessKnightSolution
    {
        public static int GetTheNumberOfDifferentMoves(string cell)
        {
            var horisontalNumPos = (byte)cell.First() - 96;
            var verticalNumPos = (byte)cell.Second();

            var topDist = 8 - verticalNumPos;
            var bottomDist = verticalNumPos - 1;
            var leftDist = horisontalNumPos - 1;
            var rightDist = 8 - horisontalNumPos;

            var numberOfTwoOrBiggerDists = new[] {topDist, bottomDist, leftDist, rightDist}.Count(_ => _ >= 2);

            return numberOfTwoOrBiggerDists;
        }
    }

    public class ChessKnightTests
    {
        [Theory]
        [InlineData("a1", 2)]
        [InlineData("d4", 8)]
        [InlineData("g6", 6)]
        public void VerifyGetTheNumberOfDifferentMovesWith(string cell, int expectedNumberOfDifferentMoves) =>
            ChessKnightSolution.GetTheNumberOfDifferentMoves(cell).Should().Be(expectedNumberOfDifferentMoves);
    }
}
