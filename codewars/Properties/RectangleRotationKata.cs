namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class RectangleRotationSolution
    {
        public static int RectangleRotation(int a, int b) => throw new NotImplementedException();
    }

    public class RectangleRotationTests
    {
        [Theory]
        [InlineData(6, 4, 23)]
        [InlineData(30, 2, 65)]
        [InlineData(8, 6, 49)]
        [InlineData(16, 20, 333)]
        public void VerifyRectangleRotationWith(int a, int b, int expectedIntegerCoordinates) => RectangleRotationSolution.RectangleRotation(a, b).Should().Be(expectedIntegerCoordinates);
    }
}
