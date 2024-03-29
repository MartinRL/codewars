namespace codewars;

public class MatrixAdditionSolution
{
    public static int[][] Add(int[][] a, int[][] b) => a.Zip(b, (ar, br) => ar.Zip(br, (i, j) => i + j).ToArray()).ToArray();
}

public class MatrixAdditionTests
{
    [Fact]
    public void VerifyAddWith()
    {
        var a = new[]
        {
            new[] {1, 2},
            new[] {1, 2}
        };
        var b = new[]
        {
            new[] {2, 3},
            new[] {2, 3}
        };

        MatrixAdditionSolution.Add(a, b).Should().BeEquivalentTo(new[]
        {
            new[] {3, 5},
            new[] {3, 5}
        });
    }
}