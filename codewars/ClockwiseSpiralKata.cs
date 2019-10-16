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

            var numbers = Enumerable.Range(2, n * n);

            var x = 0;
            var y = 0;
            var i = 0;
            
            GoRight();

            void GoRight()
            {
                try
                {
                    x++;
                    if ((int)spiral.GetValue(x, y) > 0)
                    {
                        GoDown();
                    }
                    spiral.SetValue(numbers.ElementAt(i), x, y);
                    i++;
                    GoRight();
                }
                catch (Exception)
                {
                    GoDown();
                }
            }
            
            void GoDown()
            {
                throw new NotImplementedException();
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
