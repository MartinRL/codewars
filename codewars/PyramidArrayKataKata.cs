namespace codewars;

public class PyramidArraySolution
{
    public static int[][] Pyramid(int n) => [.. Enumerable.Range(1, n).Select(i => Enumerable.Repeat(1, i).ToArray())];
}

public class PyramidArrayTests
{
    public static IEnumerable<object[]> Cases =>
        new List<object[]>
        {
            new object[] { 0, Array.Empty<int[]>()},
            new object[] { 1, new int[][] { [1] }},
            new object[] { 2, new int[][] { [1], [1, 1] }},
            new object[] { 3, new int[][] { [1], [1, 1], [1, 1, 1] }},
        };

    [Theory]
    [MemberData(nameof(Cases))]
    public void VerifyPyramidWith(int n, int[][] expectedPyramid) => Assert.Equal(expectedPyramid, PyramidArraySolution.Pyramid(n));
}
