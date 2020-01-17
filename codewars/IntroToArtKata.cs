namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class IntroToArt
    {
        public string[] GetW(int h)
        {
            if (h < 2)
                return new string[] {};

            const string star = "*";

            var firstRow = star + ((h - 2) * 2 + 1).Spaces() + star + ((h - 2) * 2 + 1).Spaces() + star;
            var lastRow = (h - 1).Spaces() + star + ((h - 1) * 2 - 1).Spaces() + star + (h - 1).Spaces();

            return firstRow.ToIEnumerable()
                .Concat(Enumerable.Range(2, h - 2)
                        .Select(i => (i - 1).Spaces() + star + ((h - (i + 1)) * 2 + 1).Spaces() + star + (1 + (i - 2) * 2).Spaces() + star + ((h - (i + 1)) * 2 + 1).Spaces() + star + (i - 1).Spaces()))
                .Concat(lastRow.ToIEnumerable())
                .ToArray();
        }
    }

    public class IntroToArtTests
    {
        [Theory]
        [InlineData(1, new string[]{})]
        [InlineData(3, new[] {
            "*   *   *",
            " * * * * ",
            "  *   *  "
        })]
        [InlineData(4, new[] {
            "*     *     *",
            " *   * *   * ",
            "  * *   * *  ",
            "   *     *   "
        })]
        [InlineData(7, new[] {
            "*           *           *",
            " *         * *         * ",
            "  *       *   *       *  ",
            "   *     *     *     *   ",
            "    *   *       *   *    ",
            "     * *         * *     ",
            "      *           *      "
        })]
        public void VerifyGetWWith(int h, string[] expectedW) => new IntroToArt().GetW(h).Should().BeEquivalentTo(expectedW);
    }
}
