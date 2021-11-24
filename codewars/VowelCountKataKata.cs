namespace codewars;

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

public static class VowelCountSolution
{
    public static int GetVowelCount(string str) => str.Count(c => "aeiou".Contains(c));
}

public class VowelCountTests
{
    [Fact]
    public void VerifyGetVowelCountWith() => VowelCountSolution.GetVowelCount("abracadabra").Should().Be(5);
}