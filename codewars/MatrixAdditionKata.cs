using System.Linq;
using FluentAssertions;
using FluentAssertions.Common;
using Xunit;

namespace codewars
{
    public class MatrixAdditionSolution
    {
        public static int[][] Add(int[][] a, int[][] b) => a.Zip(b, (ar, br) => ar.Zip(br, (i, j) => i + j).ToArray()).ToArray();
    }

    public class MatrixAdditionTests
    {
        [Fact]
        public void VerifyAddWith()
        {
            var a = new int[][]
            {
                new[] {1, 2},
                new[] {1, 2}
            };
            var b = new int[][]
            {
                new[] {2, 3},
                new[] {2, 3}
            };
            
            MatrixAdditionSolution.Add(a, b).Should().IsSameOrEqualTo(new int[][]
            {
                new[] {3, 5},
                new[] {3, 5}
            });
        }
    }
}
