namespace codewars;

using System;
using System.Text.RegularExpressions;
using FluentAssertions;
using Xunit;

public class KookaCounterSolution
{
    public static int Count(string laughing) => new Regex(@"(ha|Ha)\1+").Matches(laughing).Count;
}

public class KookaCounterTests
{
    [Theory]
    [InlineData("", 0)]
    [InlineData("hahahahaha", 1)]
    [InlineData("hahahahahaHaHaHa", 2)]
    [InlineData("HaHaHahahaHaHa", 3)]
    public void VerifyCountWith(string laughing, int expectedNoOfKookas) => KookaCounterSolution.Count(laughing).Should().Be(expectedNoOfKookas);
}