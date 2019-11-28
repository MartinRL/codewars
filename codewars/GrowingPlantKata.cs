using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using static System.Math;

namespace codewars
{
    public class GrowingPlantSolution
    {
        public static int CalculateDaysFor(int upSpeed, int downSpeed, int desiredHeight) => upSpeed >= desiredHeight ? 1 : (int)Ceiling((desiredHeight / (decimal)downSpeed - 1) / (upSpeed / (decimal)downSpeed - 1));
    }

    public class GrowingPlantTests
    {
        [Theory]
        [InlineData(100, 10, 910, 10)]
        [InlineData(10, 9, 4, 1)]
        [InlineData(14, 7, 208, 29)]
        [InlineData(11, 9, 877, 434)]
        public void VerifyCalculateDaysForWith(int upSpeed, int downSpeed, int desiredHeight, int expectedNoOfDays) => GrowingPlantSolution.CalculateDaysFor(upSpeed, downSpeed, desiredHeight).Should().Be(expectedNoOfDays);
    }
}
