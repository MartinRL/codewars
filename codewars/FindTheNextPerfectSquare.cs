using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class FindTheNextPerfectSquareKata
    {
        public static long FindNextSquare(long num)
        {
            bool IsPerfectSquare(long x) => Math.Sqrt(x) % 1 == 0;

            if (!IsPerfectSquare(num))
                return -1;
            
            return GetLongsStartingWith(num).First(IsPerfectSquare);
        }

        private static IEnumerable<long> GetLongsStartingWith(long start) 
        { 
            while (start < long.MaxValue)
                yield return ++start; 
        }
    }
    
    public class FindTheNextPerfectSquareTests
    {
        [Theory]
        [InlineData(155, -1)]
        [InlineData(121, 144)]
        [InlineData(625, 676)]
        [InlineData(319225, 320356)]
        [InlineData(15241383936, 15241630849)]
        public void RunFindNextSquareTheory(long num, long expected)
        {
            FindTheNextPerfectSquareKata.FindNextSquare(num).Should().Be(expected);
        }
    }
}
