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
            spiral[0, 0] = 1;

            if (n == 1)
                return spiral;

            var row = 0;
            var col = 0;
            var i = 2;
            
            GoRight();

            void GoRight()
            {
                try
                {
                    col++;
                    if ((int)spiral.GetValue(row, col) > 0)
                    {
                        GoDown();
                    }
                    spiral[row, col] = i;
                    i++;
                    if (i > n * n)
                        return;
                    GoRight();
                }
                catch (Exception)
                {
                    col--;
                    GoDown();
                }
            }
            
            void GoDown()
            {
                try
                {
                    row++;
                    if ((int)spiral.GetValue(row, col) > 0)
                    {
                        GoLeft();
                    }
                    spiral[row, col] = i;
                    i++;
                    if (i > n * n)
                        return;
                    GoDown();
                }
                catch (Exception)
                {
                    row--;
                    GoLeft();
                }
            }
            
            void GoLeft()
            {
                try
                {
                    col--;
                    if ((int)spiral.GetValue(row, col) > 0)
                    {
                        GoUp();
                    }
                    spiral[row, col] = i;
                    i++;
                    if (i > n * n)
                        return;
                    GoLeft();
                }
                catch (Exception)
                {
                    col++;
                    GoUp();
                }
            }
            
            void GoUp()
            {
                try
                {
                    row--;
                    if ((int)spiral.GetValue(row, col) > 0)
                    {
                        GoUp();
                    }
                    spiral[row, col] = i;
                    i++;
                    if (i > n * n)
                        return;
                    GoRight();
                }
                catch (Exception)
                {
                    row++;
                    GoRight();
                }
            }
            
            return spiral;
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
