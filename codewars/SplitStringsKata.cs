namespace codewars;

public class SplitStringSolution
{
    public static string[] SplitString(string str) =>
        ((str.Length % 2 == 0) ? str : str + "_").Chunk(2).Select(_ => new string(_)).ToArray();
}

public class SplitStringTests
{
    [Theory]
    [InlineData("abc", new string[] { "ab", "c_" })]
    [InlineData("abcdef", new string[] { "ab", "cd", "ef" })]
    public void VerifySplitStringWith(string str, string[] expectedArray) => SplitStringSolution.SplitString(str).Should().Equal(expectedArray);
}
