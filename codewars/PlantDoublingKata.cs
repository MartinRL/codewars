namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;
    using static System.Math;

    public class PlantDoublingSolution
    {
        public static int Calculate(int n)
        {
            if (n <= 1)
                return 1;

            return n % 2 == 0 ? 1 : 2;
        }
    }

    public class PlantDoublingTests
    {
        [Theory]
        [InlineData(5, 2)]
        [InlineData(8, 1)]
        [InlineData(536870911, 29)]
        [InlineData(1, 1)]
        public void VerifyCalculateWith(int n, int expectedNoOfPlants) => PlantDoublingSolution.Calculate(n).Should().Be(expectedNoOfPlants);
    }
}
