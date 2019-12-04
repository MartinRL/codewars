using static System.Convert;

namespace codewars
{
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class SumMixedArray
    {
        public static int Execute(object[] mixedArray) => mixedArray.Select(ToInt32).Sum();
    }

    public class SumMixedArrayTests
    {
        [Theory]
        [InlineData(new object[] {9, 3, "7", "3"}, 22)]
        [InlineData(new object[] {"5", "0", 9, 3, 2, 1, "9", 6, 7}, 42)]
        [InlineData(new object[] {"3", 6, 6, 0, "5", 8, 5, "6", 2, "0"}, 41)]
        public void VerifySumMixedArrayWith(object[] mixedArray, int expectedSum) => SumMixedArray.Execute(mixedArray).Should().Be(expectedSum);
    }
}
