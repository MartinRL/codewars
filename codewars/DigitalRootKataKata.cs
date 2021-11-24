namespace codewars;

using System;
using static System.Char;
using System.Linq;
using FluentAssertions;
using Xunit;

public static class DigitalRootSolution
{
    public static int DigitalRoot(long n) => (int) (1 + (n - 1) % 9);
}

public class DigitalRootTests
{
    [Theory]
    [InlineData(16, 7)]
    [InlineData(456, 6)]
    public void VerifyDigitalRootWith(long n, int expectedDigitalRoot) => DigitalRootSolution.DigitalRoot(n).Should().Be(expectedDigitalRoot);
}