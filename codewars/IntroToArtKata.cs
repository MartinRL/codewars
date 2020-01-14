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

            var firstRow = new[] { "*" + new string(' ', (h - 2) * 2 + 1) + "*" + new string(' ', (h - 2) * 2 + 1) + "*" };
            var lastRow = new[] { new string(' ', h - 1) + "*" + new string(' ', firstRow.First().Length - 2 - (h - 1) * 2) + "*" + new string(' ', h - 1)  };

            return firstRow
                .Concat(Enumerable.Range(2, h - 2).Select(i => new string(' ', i - 1) + "*" + new string(' ', (h - 3) * 2 + 1) + "*" + new string(' ', 1) + "*" + new string(' ', (h - 3) * 2 + 1) + "*" + new string(' ', i - 1)))
                .Concat(lastRow)
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
