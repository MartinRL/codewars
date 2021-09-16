namespace codewars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class PyramidArraySolution
    {
        public static int[][] Pyramid(int n)
        {
            if (n == 0)
                return new int[][] {};

            var pyramid = new int[n][];

            for (var i = 0; i < n; i++)
            {
                pyramid[i] = new string('1', i + 1).Select(c => int.Parse(c.ToString())).ToArray();
            }

            return pyramid;
        }
    }

    public class PyramidArrayTests
    {
        public static IEnumerable<object[]> Cases =>
            new List<object[]>
            {
                new object[] { 0, new int[][] {}},
                new object[] { 1, new int[][] { new[] { 1 } }},
                new object[] { 2, new int[][] { new[] { 1 }, new[] { 1, 1 } }},
                new object[] { 3, new int[][] { new[] { 1 }, new[] { 1, 1 }, new[] { 1, 1, 1 } }},
            };

        [Theory]
        [MemberData(nameof(Cases))]
        public void VerifyPyramidWith(int n, int[][] expectedPyramid) => Assert.Equal(expectedPyramid, PyramidArraySolution.Pyramid(n));
    }
}
