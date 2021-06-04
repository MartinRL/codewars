namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ChessKnightSolution
    {
        public static int GetTheNumberOfDifferentMoves(string cell) => throw new NotImplementedException();
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
