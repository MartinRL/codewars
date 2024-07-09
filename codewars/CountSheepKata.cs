namespace codewars;

public static class CountSheepSolution
{
    public static int CountSheep(bool[] sheep) => sheep.Count(_ => _);
}

public class CountSheepTests
{
    [Theory]
    [InlineData(new[] {true, false, true}, 2)]
    [InlineData(new[]
    {
        true, true, true, false,
        true, true, true, true,
        true, false, true, false,
        true, false, false, true,
        true, true, true, true,
        false, false, true, true
    }, 17)]
    [InlineData(new[]
    {
        false, false, false, false,
        false, false, false, false,
        false, false, false, false
    }, 0)]
    public void VerifyCountSheepExampleWith(bool[] sheep, int expected) => CountSheepSolution.CountSheep(sheep).Should().Be(expected);
}
