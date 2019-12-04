namespace codewars
{
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public static class MaximumProductSolution
    {
        public static int AdjacentElementsProduct(int[] elements) =>
            elements
                .Skip(1)
                .Select((t, i) => t * elements[i])
                .Max();
    }

    public class MaximumProductTests
    {
        [Theory]
        [InlineData(new[] {5, 8}, 40)]
        [InlineData(new[] {1, 2, 3}, 6)]
        [InlineData(new[] {1, 5, 10, 9}, 90)]
        [InlineData(new[] {5, 1, 2, 3, 1, 4}, 6)]
        [InlineData(new[] {4, 12, 3, 1, 5}, 48)]
        public void VerifyAdjacentElementsProductWith(int[] elements, int expectedProduct) => MaximumProductSolution.AdjacentElementsProduct(elements).Should().Be(expectedProduct);
    }
}
