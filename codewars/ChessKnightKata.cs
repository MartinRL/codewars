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
            var verticalNumPos = char.GetNumericValue(cell.Second());

            var topDist = 8 - verticalNumPos;
            var bottomDist = verticalNumPos - 1;
            var leftDist = horisontalNumPos - 1;
            var rightDist = 8 - horisontalNumPos;

            return new[]
            {
                topDist >= 1 && leftDist >= 2,
                topDist >= 2 && leftDist >= 1,
                topDist >= 2 && rightDist >= 1,
                topDist >= 1 && rightDist >= 2,
                bottomDist >= 1 && rightDist >= 2,
                bottomDist >= 2 && rightDist >= 1,
                bottomDist >= 2 && leftDist >= 1,
                bottomDist >= 1 && leftDist >= 2,
            }.Count(_ => _);
        }
    }

    public class ChessKnightTests
    {
        [Theory]
        [InlineData("a1", 2)]
        [InlineData("c2", 6)]
        [InlineData("d4", 8)]
        [InlineData("g6", 6)]
        public void VerifyGetTheNumberOfDifferentMovesWith(string cell, int expectedNumberOfDifferentMoves) =>
            ChessKnightSolution.GetTheNumberOfDifferentMoves(cell).Should().Be(expectedNumberOfDifferentMoves);
    }
}
