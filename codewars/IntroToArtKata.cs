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

            const char space = ' ';
            const string star = "*";

            var firstRow = star + new string(space, (h - 2) * 2 + 1) + star + new string(space, (h - 2) * 2 + 1) + star;
            var lastRow = new string(space, h - 1) + star + new string(space, (h - 1) * 2 - 1) + star + new string(space, h - 1);

            return new[] { firstRow }
                .Concat(Enumerable.Range(2, h - 2).Select(i => new string(space, i - 1) + star + new string(space, (h - (i + 1)) * 2 + 1) + star + new string(space, 1 + (i - 2) * 2) + star + new string(space, (h - (i + 1)) * 2 + 1) + star + new string(space, i - 1)))
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
