namespace codewars
{
    using FluentAssertions;
    using Xunit;
    using static System.Math;

    public class GrowingPlantSolution
    {
        public static int CalculateDaysFor(int upSpeed, int downSpeed, int desiredHeight) =>
            upSpeed >= desiredHeight ? 1 : (int) Ceiling(Round((desiredHeight / (decimal) downSpeed - 1) / (upSpeed / (decimal) downSpeed - 1), 2));
    }

    public class GrowingPlantTests
    {
        [Theory]
        [InlineData(100, 10, 910, 10)]
        [InlineData(10, 9, 4, 1)]
        [InlineData(14, 7, 208, 29)]
        [InlineData(11, 9, 877, 434)]
        [InlineData(96, 87, 153, 8)]
        public void VerifyCalculateDaysForWith(int upSpeed, int downSpeed, int desiredHeight, int expectedNoOfDays) =>
            GrowingPlantSolution.CalculateDaysFor(upSpeed, downSpeed, desiredHeight).Should().Be(expectedNoOfDays);
    }
}
