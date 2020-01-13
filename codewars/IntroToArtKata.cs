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

            return new[]
            {
                "*" + new string(' ', (h - 2) * 2 + 1) + "*" + new string(' ', (h - 2) * 2 + 1) + "*",
                new string(' ', 1) + "*" + new string(' ', (h - 3) * 2 + 1) + "*" + new string(' ', 1) + "*" + new string(' ', (h - 3) * 2 + 1) + "*" + new string(' ', 1),
                new string(' ', 2) + "*" + new string(' ', 1) + "*" + new string(' ', (h - 3) * 2 + 1) + "*" + new string(' ', 1) + "*" + new string(' ', 2),
                new string(' ', 3) + "*" + new string(' ', (h - 2) * 2 + 1) + "*" + new string(' ', 3),
            };
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
