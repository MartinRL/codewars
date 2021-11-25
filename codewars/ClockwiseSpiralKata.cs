namespace codewars;

using System.Collections;

public class ClockwiseSpiralSolution
{
    public static int[,] CreateSpiral(int n)
    {
        var spiral = new int[n, n];

        var topBoundary = 0;
        var bottomBoundary = n - 1;
        var leftBoundary = 0;
        var rightBoundary = n - 1;
        var counter = 1;
        var direction = Direction.Left;
        var x = 0;
        var y = 0;

        while (topBoundary <= bottomBoundary && leftBoundary <= rightBoundary)
        {
            switch (direction)
            {
                case Direction.Left when x <= rightBoundary:
                    spiral[y, x++] = counter++;
                    break;
                case Direction.Left when x > rightBoundary:
                    direction = Direction.Down;
                    x = rightBoundary;
                    y = ++topBoundary;
                    break;
                case Direction.Down when y <= bottomBoundary:
                    spiral[y++, x] = counter++;
                    break;
                case Direction.Down when y > bottomBoundary:
                    direction = Direction.Right;
                    x = --rightBoundary;
                    y = bottomBoundary;
                    break;
                case Direction.Right when x >= leftBoundary:
                    spiral[y, x--] = counter++;
                    break;
                case Direction.Right when x < leftBoundary:
                    direction = Direction.Up;
                    x = leftBoundary;
                    y = --bottomBoundary;
                    break;
                case Direction.Up when y >= topBoundary:
                    spiral[y--, x] = counter++;
                    break;
                case Direction.Up when y < topBoundary:
                    direction = Direction.Left;
                    x = ++leftBoundary;
                    y = topBoundary;
                    break;
            }
        }

        return spiral;
    }

    private enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
}

public class ClockwiseSpiralTests
{
    public static TheoryData<int, int[,]> Cases =>
        new()
        {
            {
                1, new[,]
                {
                    {1}
                }
            },
            {
                2, new[,]
                {
                    {1, 2},
                    {4, 3}
                }
            },
            {
                3, new[,]
                {
                    {1, 2, 3},
                    {8, 9, 4},
                    {7, 6, 5}
                }
            },
        };

    [Theory]
    [MemberData(nameof(Cases))]
    public void VerifyCreateSpiralWith(int n, int[,] expectedSpiral) => ClockwiseSpiralSolution.CreateSpiral(n).Should().BeEquivalentTo(expectedSpiral);
}
