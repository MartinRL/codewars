namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ChessBoardCellColorSolution
    {
        public static bool HaveSameColors(string cell1, string cell2) => throw new NotImplementedException();
    }

    public class ChessBoardCellColorTests
    {
        [Theory]
        [InlineData("A1", "C3", true)]
        [InlineData("A1", "H3", false)]
        [InlineData("A1", "A2", false)]
        public void VerifyHaveSameColorsWith(string cell1, string cell2, bool expected) => ChessBoardCellColorSolution.HaveSameColors(cell1, cell2).Should().Be(expected);
    }
}
