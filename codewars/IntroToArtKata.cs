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

            var firstRow = "*" + new string(' ', (h - 2) * 2 + 1) + "*" + new string(' ', (h - 2) * 2 + 1) + "*";
            var lastRow = new string(' ', h - 1) + "*" + new string(' ', (h - 1) * 2 - 1) + "*" + new string(' ', h - 1);

            return new[] { firstRow }
                .Concat(Enumerable.Range(2, h - 2).Select(i => new string(' ', i - 1) + "*" + new string(' ', (h - (i + 1)) * 2 + 1) + "*" + new string(' ', 1 + (i - 2) * 2) + "*" + new string(' ', (h - (i + 1)) * 2 + 1) + "*" + new string(' ', i - 1)))
                .Concat(new[] { lastRow })
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
