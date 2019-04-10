using System;
using System.Text.RegularExpressions;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class AutomorphicNumberSolution
    {
        public static string Automorphic(int n)
        {
            return Regex.IsMatch(Convert.ToInt32(Math.Pow(n, 2)).ToString(), @"\d*" + n) ? "Automorphic" : "Not!!";
        }
    }

    public class AutomorphicNumberTests
    {
        [Theory]
        [InlineData(1, "Automorphic")]
        [InlineData(3, "Not!!")]
        [InlineData(6, "Automorphic")]
        [InlineData(9, "Not!!")]
        [InlineData(25, "Automorphic")]
        [InlineData(53, "Not!!")]
        [InlineData(76, "Automorphic")]
        [InlineData(95, "Not!!")]
        [InlineData(625, "Automorphic")]
        [InlineData(225, "Not!!")]
        public void VerifyAutomorphicWith(int n, string expected)
        {
            AutomorphicNumberSolution.Automorphic(n).Should().Be(expected);
        }
    }
}