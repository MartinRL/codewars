namespace codewars;

public class ChessBoardCellColorSolution
{
    public static bool HaveSameColors(string cell1, string cell2) => (cell2.First() - cell1.First() + cell2.Last() - cell1.Last()) % 2 == 0;
}

public class ChessBoardCellColorTests
{

    [Theory]
    [InlineData("A1", "C3", true)]
    [InlineData("A1", "H3", false)]
    [InlineData("A1", "A2", false)]
    [InlineData("E7", "E3", true)]
    [InlineData("D1", "B5", true)]
    public void VerifyHaveSameColorsWith(string cell1, string cell2, bool expected) => ChessBoardCellColorSolution.HaveSameColors(cell1, cell2).Should().Be(expected);
}
