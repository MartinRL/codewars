namespace codewars
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class PlantDoublingSolution
    {
        public static int Calculate(int n) => Convert.ToString(n, 2).Split('1').Length - 1;
    }

    public class PlantDoublingTests
    {
        [Theory]
        [InlineData(5, 2)]
        [InlineData(8, 1)]
        [InlineData(536870911, 29)]
        [InlineData(536870912, 1)]
        [InlineData(1, 1)]
        public void VerifyCalculateWith(int n, int expectedNoOfPlants) => PlantDoublingSolution.Calculate(n).Should().Be(expectedNoOfPlants);
    }
}
