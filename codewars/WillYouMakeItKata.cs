using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class WillYouMakeItSolution
    {
        public static bool ZeroFuel(uint distanceToPump, uint mpg, uint fuelLeft) => mpg * fuelLeft >= distanceToPump;
    }

    public class WillYouMakeItTests
    {
        [Theory]
        [InlineData(50, 25, 2, true)]
        [InlineData(100, 50, 1, false)]
        public void VerifyZeroFuelWith(uint distanceToPump, uint mpg, uint fuelLeft, bool iWillMakeIt) => WillYouMakeItSolution.ZeroFuel(distanceToPump, mpg, fuelLeft).Should().Be(iWillMakeIt);
    }
}
