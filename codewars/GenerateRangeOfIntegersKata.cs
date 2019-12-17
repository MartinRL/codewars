namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class GenerateRangeOfIntegersSolution
    {
        public static int[] GenerateRange(int min, int max, int step) => throw new NotImplementedException();
    }

    public class GenerateRangeOfIntegersTests
    {
        [Theory]
        [InlineData(2, 10, 2, new [] { 2, 4, 6, 8, 10 })]
        [InlineData(1, 10, 3, new [] { 1, 4, 7, 10 })]
        public void VerifyGenerateRangeWith(int min, int max, int step, int[] expectedRange) => GenerateRangeOfIntegersSolution.GenerateRange(min, max, step).Should().BeEquivalentTo(expectedRange);
    }
}
