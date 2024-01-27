namespace codewars;

public class SplitStringSolution
{
    public static string[] SplitString(string str) => throw new NotImplementedException();
}

public class SplitStringTests
{
    [Theory]
    [InlineData("abc", new string[] { "ab", "c_" })]
    [InlineData("abcdef", new string[] { "ab", "cd", "ef" })]
    public void VerifySplitStringWith(string str, string[] expectedArray) => SplitStringSolution.SplitString(str).Should().Equal(expectedArray);
}
