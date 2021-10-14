namespace codewars
{
    using System;
    using static System.Char;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class DigitalRootSolution
    {
        public static int DigitalRoot(long n) => n.ToString().Length == 1 ? (int)n : DigitalRoot((long) n.ToString().Sum(GetNumericValue));
    }

    public class DigitalRootTests
    {
        [Theory]
        [InlineData(16, 7)]
        [InlineData(456, 6)]
        public void VerifyDigitalRootWith(long n, int expectedDigitalRoot) => DigitalRootSolution.DigitalRoot(n).Should().Be(expectedDigitalRoot);
    }
}
