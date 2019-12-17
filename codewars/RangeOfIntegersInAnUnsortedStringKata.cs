namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class RangeOfIntegersInAnUnsortedStringSolution
    {
        public static int[] MysteryRange(string s, int n)
        {
            throw new NotImplementedException();
        }
    }

    public class RangeOfIntegersInAnUnsortedStringTests
    {
        [Theory]
        [InlineData("1568141291110137", 10, new[] {6, 15})]
        [InlineData("6291211413114538107", 14, new[] {1, 14})]
        [InlineData("13161820142119101112917232215", 15, new[] {9, 23})]
        [InlineData("2318134142120517221910151678611129", 20, new[] {4, 23})]
        [InlineData("10610211511099104113100116105103101111114107108112109", 18, new[] {99, 116})]
        [InlineData("1721532418565922162558663126649136347436733301144143236653738464135820194215516155541239452852623450572927602348104049", 60, new[] {8, 67})]
        public void VerifyMysteryRangeWith(string s, int n, int[] expectedRange) => RangeOfIntegersInAnUnsortedStringSolution.MysteryRange(s, n).Should().BeEquivalentTo(expectedRange);
    }
}
