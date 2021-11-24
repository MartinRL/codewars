namespace codewars;

using System.Linq;
using FluentAssertions;
using Xunit;

public static class ArrayDiffSolution
{
    public static int[] ArrayDiff(int[] a, int[] b) => a.Where(x => !b.Contains(x)).ToArray();
}

public class ArrayDiffTests
{
    [Theory]
    [InlineData(new[] {1, 2}, new[] {1}, new[] {2})]
    [InlineData(new[] {1, 2, 2}, new[] {1}, new[] {2, 2})]
    [InlineData(new[] {1, 2, 2}, new[] {2}, new[] {1})]
    public void ElementsInBShouldBeRemovedFromA(int[] a, int[] b, int[] c) => ArrayDiffSolution.ArrayDiff(a, b).Should().BeEquivalentTo(c);
}