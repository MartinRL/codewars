namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class DigitalRootSolution
    {
        public static int DigitalRoot(long n) => throw new NotImplementedException();
    }

    public class DigitalRootTests
    {
        [Theory]
        [InlineData(16, 7)]
        [InlineData(456, 6)]
        public void VerifyDigitalRootWith(long n, int expectedDigitalRoot) => DigitalRootSolution.DigitalRoot(n).Should().Be(expectedDigitalRoot);
    }
}
