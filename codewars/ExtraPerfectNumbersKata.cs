using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class ExtraPerfectNumbersSolution
    {
        public static int[] ExtraPerfect(int n)
        {
            bool isOdd(int _) => _ % 2 == 1;
            
            return Enumerable.Range(1, n).Where(isOdd).ToArray();
        }
    }

    public class ExtraPerfectNumbersTests
    {
        [Theory]
        [InlineData(3, new [] {1, 3})]
        [InlineData(5, new [] {1,3,5})]
        [InlineData(7, new [] {1,3,5,7})]
        [InlineData(28, new [] {1,3,5,7,9,11,13,15,17,19,21,23,25,27})]
        [InlineData(39, new [] {1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39})]
        public void VerifyExtraPerfectWith(int n, int[] expected) => ExtraPerfectNumbersSolution.ExtraPerfect(n).Should().BeEquivalentTo(expected);
    }
}
