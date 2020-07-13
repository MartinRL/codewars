namespace codewars
{
    using System;
    using System.Drawing;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ChessBoardCellColorSolution
    {
        private static Color GetColorOfCell(string cell) => ((int) cell.First() % 2 == (int) cell.Last() % 2) ? Color.Black : Color.White;

        public static bool HaveSameColors(string cell1, string cell2) => GetColorOfCell(cell1) == GetColorOfCell(cell2);
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
