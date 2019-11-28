using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class GrowingPlantSolution
    {
        public static int CalculateDaysFor(int upSpeed, int downSpeed, int desiredHeight)
        {
            return (desiredHeight / downSpeed - 1) / (upSpeed / downSpeed - 1);
        }
    }

    public class GrowingPlantTests
    {
        [Theory]
        [InlineData(100, 10, 910, 10)]
        [InlineData(10, 9, 4, 1)]
        public void VerifyCalculateDaysForWith(int upSpeed, int downSpeed, int desiredHeight, int expectedNoOfDays) => GrowingPlantSolution.CalculateDaysFor(upSpeed, downSpeed, desiredHeight).Should().Be(expectedNoOfDays);
    }
}
