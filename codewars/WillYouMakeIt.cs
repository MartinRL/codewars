using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class WillYouMakeItKata
    {
        public static bool ZeroFuel(uint distanceToPump, uint mpg, uint fuelLeft)
        {
            throw new NotImplementedException();
        }
    }

    public class WillYouMakeItTests
    {
        [Theory]
        [InlineData(50, 25, 2, true)]
        [InlineData(100, 50, 1, false)]
        public void ExecuteOrderExample(uint distanceToPump, uint mpg, uint fuelLeft, bool iWillMakeIt)
        {
            WillYouMakeItKata.ZeroFuel(distanceToPump, mpg, fuelLeft).Should().Be(iWillMakeIt);
        }
    }
}
