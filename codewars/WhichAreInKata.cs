namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class WhichAreInSolution
    {
        public static string[] GetIns(string[] array1, string[] array2) => throw new NotImplementedException();
    }

    public class WhichAreInTests
    {
        [Theory]
        [InlineData(new[] {"arp", "live", "strong"}, new[] {"lively", "alive", "harp", "sharp", "armstrong"}, new[] {"arp", "live", "strong"})]
        [InlineData(new[] {"tarp", "mice", "bull"}, new[] {"lively", "alive", "harp", "sharp", "armstrong"}, new string[] {})]
        public void VerifyGetInsWith(string[] array1, string[] array2, string[] expectedIns) => WhichAreInSolution.GetIns(array1, array2).Should().Equal(expectedIns);
    }
}
