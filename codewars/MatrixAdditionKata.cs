using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class MatrixAdditionSolution
    {
        public static int[][] Add(int[][] a, int[][] b)
        {
            throw new NotImplementedException();
        }
    }

    public class MatrixAdditionTests
    {
        [Fact]
        public void VerifyAddWith()
        {
            var a = new[]
            {
                new[] {1, 2},
                new[] {1, 2}
            };
            var b = new[]
            {
                new[] {2, 3},
                new[] {2, 3}
            };
            var expectedAdd = new[]
            {
                new[] {3, 5},
                new[] {3, 5}
            };
            
            MatrixAdditionSolution.Add(a, b).Should().AllBeEquivalentTo(expectedAdd);
        }
    }
}
