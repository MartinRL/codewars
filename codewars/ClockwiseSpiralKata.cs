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
            throw new NotImplementedException();
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
