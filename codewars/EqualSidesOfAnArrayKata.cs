namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class EqualSidesOfAnArraySolution
    {
        public static int FindEvenIndex(int[] arr)
        {
            for (var i = 1; i < arr.Count(); i++)
            {
                if (arr.Take(i).Sum() == arr.Skip(i + 1).Sum())
                    return i;
            }

            return -1;
        }
    }

    public class EqualSidesOfAnArrayTests
    {
        [Theory]
        [InlineData(new[] {1, 2, 3, 4, 3, 2, 1}, 3)]
        [InlineData(new[] {1, 100, 50, -51, 1, 1}, 1)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6}, -1)]
        [InlineData(new[] {20, 10, 30, 10, 10, 15, 35}, 3)]
        public void VerifyFindEvenIndexWith(int[] arr, int expectedIndex) => EqualSidesOfAnArraySolution.FindEvenIndex(arr).Should().Be(expectedIndex);
    }
}
