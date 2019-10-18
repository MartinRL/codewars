using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class ClockwiseSpiralSolution
    {
        public static int[,] CreateSpiral(int n)
        {
            if (n < 1)
                return new int[0, 0];
            
            var spiral = new int[n, n];

            var topBoundary = 0;
            var bottomBoundary = n-1;
            var leftBoundary = 0;
            var rightBoundary =  n-1;
            var counter = 1;
            var direction = Direction.Left;
            var x = 0;
            var y = 0;

            while (topBoundary <= bottomBoundary && leftBoundary <= rightBoundary) 
            {
                if (direction == Direction.Left && x <= rightBoundary)
                {
                    spiral[y, x++] = counter++;
                }
                else if (direction == Direction.Left && x > rightBoundary)
                {
                    direction = Direction.Down;
                    x = rightBoundary;
                    y = ++topBoundary;
                }
                else if (direction == Direction.Down && y <= bottomBoundary)
                {
                    spiral[y++, x] = counter++;
                }
                else if (direction == Direction.Down && y > bottomBoundary)
                {
                    direction = Direction.Right;
                    x = --rightBoundary;
                    y = bottomBoundary;
                }
                else if (direction == Direction.Right && x >= leftBoundary)
                {
                    spiral[y, x--] = counter++;
                }
                else if (direction == Direction.Right && x < leftBoundary)
                {
                    direction = Direction.Up;
                    x = leftBoundary;
                    y = --bottomBoundary;
                }
                else if (direction == Direction.Up && y >= topBoundary)
                {
                    spiral[y--, x] = counter++;
                }
                else if (direction == Direction.Up && y < topBoundary)
                {
                    direction = Direction.Left;
                    x = ++leftBoundary;
                    y = topBoundary;
                }
            }

            return spiral;
        }

        private enum Direction
        {
            Left, Right, Up, Down
        }
    }

    public class ClockwiseSpiralTests
    {
        [Theory]
        [ClassData(typeof(ClockwiseSpiralTestData) )]
        public void VerifyCreateSpiralWith(int n, int[,] expectedSpiral)
        {
            ClockwiseSpiralSolution.CreateSpiral(n).Should().BeEquivalentTo(expectedSpiral);
        }
    }
    
    public class ClockwiseSpiralTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, new[,]
            {
                { 1 }
            } };
            yield return new object[] { 2, new[,]
            {
                {1, 2},
                {4, 3},
            } };
            yield return new object[] { 3, new[,]
            {
                {1, 2, 3},
                {8, 9, 4},
                {7, 6, 5}
            } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
