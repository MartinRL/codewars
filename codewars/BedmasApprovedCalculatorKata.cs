using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class BedmasApprovedCalculatorSolution
    {
        public static double Calculate(string s)
        {
            throw new NotImplementedException();
        }
    }

    public class BedmasApprovedCalculatorTests
    {
        [Theory]
        [InlineData("1 + 2", 3)]
        [InlineData("2*2", 4)]
        public void VerifyCalculateWith(string s, double expectedCalculated)
        {
            BedmasApprovedCalculatorSolution.Calculate(s).Should().Be(expectedCalculated);
        }
    }
}
