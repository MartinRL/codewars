using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class SpecialNumberSolution
    {
        public static string SpecialNumber(int number)
        {
            ISet<int> nonSpecialDigits = new SortedSet<int> { 6, 7, 8, 9 };

            return number.ToDigits().Any(d => nonSpecialDigits.Contains(d)) ? "NOT!!" : "Special!!";
        }
    }

    public class SpecialNumberTests
    {
        [Theory]
        [InlineData(00002, "Special!!")]
        [InlineData(00003, "Special!!")]
        [InlineData(00011, "Special!!")]
        [InlineData(00055, "Special!!")]
        [InlineData(25432, "Special!!")]
        [InlineData(02783, "NOT!!")]
        [InlineData(00006, "NOT!!")]
        [InlineData(00009, "NOT!!")]
        [InlineData(00026, "NOT!!")]
        [InlineData(00092, "NOT!!")]
        public void VerifySpecialNumberWith(int number, string expected)
        {
            SpecialNumberSolution.SpecialNumber(number).Should().Be(expected);
        }
    }
}
