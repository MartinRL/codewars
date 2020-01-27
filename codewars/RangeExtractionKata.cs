namespace codewars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class RangeExtractionSolution
    {
        public static string Extract(int[] args)
        {
            var argsQueue = new Queue<int>(args);
            var rangeList = new List<string>();

            while (argsQueue.Any())
            {
                rangeList.Add(GetSubrange());
            }

            string GetSubrange()
            {
                var start = argsQueue.Dequeue();

                if (!argsQueue.Any() || argsQueue.Peek() > start + 1)
                    return $"{start}";

                var current = start;
                while (argsQueue.Any() && argsQueue.Peek() == current + 1)
                {
                    current = argsQueue.Dequeue();
                }

                return $"{start}{(current == start + 1 ? "," : "-")}{current}";
            }

            return string.Join(",", rangeList);
        }
    }

    public class RangeExtractionTests
    {
        [Theory]
        [InlineData(new int[0], "")]
        [InlineData(new[] { 1 }, "1")]
        [InlineData(new[] { 1, 2 }, "1,2")]
        [InlineData(new[] { 1, 5 }, "1,5")]
        [InlineData(new[] { 1, 2, 3 }, "1-3")]
        [InlineData(new[] { -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20 }, "-6,-3-1,3-5,7-11,14,15,17-20")]
        [InlineData(new[] { -3, -2, -1, 2, 10, 15, 16, 18, 19, 20 }, "-3--1,2,10,15,16,18-20")]
        public void VerifyExtractWith(int[] args, string expectedRange) => RangeExtractionSolution.Extract(args).Should().Be(expectedRange);
    }
}
