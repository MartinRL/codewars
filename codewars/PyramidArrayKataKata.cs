namespace codewars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class PyramidArraySolution
    {
        public static int[][] Pyramid(int n) => throw new NotImplementedException();
    }

    public class PyramidArrayTests
    {
        public static IEnumerable<object[]> Cases =>
            new List<object[]>
            {
                new object[] { 0, new int[][] {}},
                new object[] { 1, new[] { new[] { 1 } }},
                new object[] { 2, new[] { new[] { 1 }, new[] { 1, 1 } }},
                new object[] { 3, new[] { new[] { 1 }, new[] { 1, 1 }, new[] { 1, 1, 1 } }},
            };

        [Theory]
        [MemberData(nameof(Cases))]
        public void VerifyPyramidWith(int n, int[][] expectedPyramid) => PyramidArraySolution.Pyramid(n).Should().Equal(expectedPyramid);
    }
}