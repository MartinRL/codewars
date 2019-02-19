using System;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class TwiceAsOldSolution
    {
        public static int TwiceAsOld(int dadYears, int sonYears)
        {
            var dadAge = dadYears;
            var yearsAgo = 0;

            do
            {
                --dadAge;
                ++yearsAgo;
            } while (dadAge != sonYears * 2);

            return yearsAgo;
        }
    }
    
    public class TwiceAsOldTests
    {
        [Theory]
        [InlineData(30, 0, 30)]
        [InlineData(30, 7, 16)]
        [InlineData(45, 30, 15)]
        public void ExecuteCountDuplicatesExample(int dadYears, int sonYears, int expectedYears)
        {
            TwiceAsOldSolution.TwiceAsOld(dadYears, sonYears).Should().Be(expectedYears);
        }
    }
}
