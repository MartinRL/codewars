namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class StringArrayRevisalSolution
    {
        public static string[] RemoveConsecutiveDuplicateLettersFrom(string[] strings) => throw new NotImplementedException();
    }

    public class StringArrayRevisalTests
    {
        [Theory]
        [InlineData(new[] {"ccooddddddewwwaaaaarrrrsssss", "piccaninny", "hubbubbubboo"}, new[] {"codewars", "picaniny", "hubububo"})]
        [InlineData(new[] {"kelless","voorraaddoosspullen","achcha"}, new[] {"keles", "voradospulen", "achcha"})]
        public void VerifyRemoveConsecutiveDuplicateLettersFromWith(string[] strings, string[] expectedStrings) => StringArrayRevisalSolution.RemoveConsecutiveDuplicateLettersFrom(strings).Should().Equal(expectedStrings);
    }
}
