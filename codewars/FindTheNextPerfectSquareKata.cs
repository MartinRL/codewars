using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class FindTheNextPerfectSquareSolution
    
    {
        public static long FindNextSquare(long num)
        {
            bool IsPerfectSquare(long x) => Math.Sqrt(x) % 1 == 0;

            if (!IsPerfectSquare(num))
                return -1;
            
            return (long)Math.Pow(Math.Sqrt(num) + 1 /* next integer will yield a perfect square */ , 2);
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
        public void VerifyFindNextSquareWith(long num, long expected)
        {
            FindTheNextPerfectSquareSolution.FindNextSquare(num).Should().Be(expected);
        }
    }
}
