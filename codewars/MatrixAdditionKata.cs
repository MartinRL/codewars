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
            return a.Select((row , i) => row.Zip(b.ElementAt(i), (ea, eb) => ea + eb).ToArray()).ToArray();
        }
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
            
            MatrixAdditionSolution.Add(a, b)[0][0].Should().Be(3);
            MatrixAdditionSolution.Add(a, b)[0][1].Should().Be(5);
            MatrixAdditionSolution.Add(a, b)[1][0].Should().Be(3);
            MatrixAdditionSolution.Add(a, b)[1][1].Should().Be(5);
        }
    }
}
