namespace codewars;

public class CountingDuplicatesSolution
{
    public static int CountDuplicates(string s)
    {
        var lowerCased = s.ToLower();
        var unique = lowerCased.Distinct();

        return unique.Count(c => lowerCased.IndexOf(c) != lowerCased.LastIndexOf(c));
    }
}

public class CountingDuplicatesTests
{
    [Theory]
    [InlineData("", 0)]
    [InlineData("abcde", 0)]
    [InlineData("aabbcde", 2)]
    [InlineData("aabBcde", 2)]
    [InlineData("Indivisibility", 1)]
    [InlineData("Indivisibilities", 2)]
    [InlineData("1123232", 3)]
    public void VerifyCountDuplicatesWith(string argument, int expected) => CountingDuplicatesSolution.CountDuplicates(argument).Should().Be(expected);
}
