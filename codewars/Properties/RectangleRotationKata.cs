namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class RectangleRotationSolution
    {
        public static int RectangleRotation(int a, int b)
        {
            var sqrt2 = Math.Sqrt(2);
            double ah = a / 2f;
            double bh = b / 2f;
            double Top(double x) => ah * sqrt2 - x;
            double Bottom(double x) => -ah * sqrt2 - x;
            double Right(double x) => -bh * sqrt2 + x;
            double Left(double x) => bh * sqrt2 + x;
            int CalcColumn(int x)
            {
                var max = Math.Floor(Math.Min(Top(x), Left(x)));
                var min = Math.Ceiling(Math.Max(Right(x), Bottom(x)));
                return (int)Math.Round(max - min) + 1;
            }
            var highest = sqrt2 * (ah + bh) / 2;

            var rightSide = 0;
            for (int column = 1; column < highest; column++)
            {
                rightSide += CalcColumn(column);
            }

            var column0 = CalcColumn(0);
            return column0 + 2 * rightSide;
        }
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
