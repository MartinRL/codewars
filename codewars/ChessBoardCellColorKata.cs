namespace codewars
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using FluentAssertions;
    using Xunit;

    public class ChessBoardCellColorSolution
    {
        public static Color GetColorOfCell(string cell) => throw new NotImplementedException();

        public static bool HaveSameColors(string cell1, string cell2) => throw new NotImplementedException();
    }

    public class ChessBoardCellColorTests
    {
        private class GetColorOfCellTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { "A1", Color.Black };
                yield return new object[] { "C3", Color.Black };
                yield return new object[] { "H3", Color.White};
                yield return new object[] { "A2", Color.White};
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        [Theory]
        [ClassData(typeof(GetColorOfCellTestData))]
        public void GetColorOfCell(string cell1, string cell2, bool expected) => ChessBoardCellColorSolution.HaveSameColors(cell1, cell2).Should().Be(expected);

        [Theory]

        [InlineData("A1", "C3", true)]
        [InlineData("A1", "H3", false)]
        [InlineData("A1", "A2", false)]
        public void VerifyHaveSameColorsWith(string cell1, string cell2, bool expected) => ChessBoardCellColorSolution.HaveSameColors(cell1, cell2).Should().Be(expected);
    }
}
