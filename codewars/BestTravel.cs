using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class BestTravelKata
    {
        public static int? chooseBestSum(int t, int k, List<int> ls) 
        {
            throw new NotImplementedException();
        }
    }

    public class BestTravelTests
    {
        [Theory]
        [InlineData(163, 3, new [] { 50, 55, 56, 57, 58 }, 163)]
        [InlineData(163, 3, new [] { 50 }, null)]
        [InlineData(230, 3, new [] { 91, 74, 73, 85, 73, 81, 87 }, 228)]
        public void ExecuteChooseBestSumExample(int t, int k, int[] ls, int? expected)
        {
            BestTravelKata.chooseBestSum(t, k, ls.ToList()).Should().Be(expected);
        }
    }
}
