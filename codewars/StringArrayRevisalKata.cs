namespace codewars;

public class StringArrayRevisalSolution
{
    private static string RemoveConsecutiveDuplicateLettersFrom(string s)
    {
        var chars = new List<char> { s[0] };

        for (var i = 1; i < s.Length; i++)
        {
            if (s[i] != s[i - 1])
                chars.Add(s[i]);
        }

        return string.Concat(chars);
    }

    public static IEnumerable<string> RemoveConsecutiveDuplicateLettersFrom(IEnumerable<string> strings) => strings.Select(RemoveConsecutiveDuplicateLettersFrom);
}

public class StringArrayRevisalTests
{
    [Theory]
    [InlineData(new[] {"ccooddddddewwwaaaaarrrrsssss", "piccaninny", "hubbubbubboo"}, new[] {"codewars", "picaniny", "hubububo"})]
    [InlineData(new[] {"kelless","voorraaddoosspullen","achcha"}, new[] {"keles", "voradospulen", "achcha"})]
    public void VerifyRemoveConsecutiveDuplicateLettersFromWith(IEnumerable<string> strings, IEnumerable<string> expectedStrings) => StringArrayRevisalSolution.RemoveConsecutiveDuplicateLettersFrom(strings).Should().Equal(expectedStrings);
}
