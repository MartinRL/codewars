using FluentAssertions;
using Xunit;

namespace codewars
{
    public class FindTheNextPerfectSquareKata
    {
        public static long FindNextSquare(long num)
        {
            // TODO
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
        public void RunCountDuplicatesTheory(long num, long expected)
        {
            FindTheNextPerfectSquareKata.FindNextSquare(num).Should().Be(expected);
        }
    }
}
