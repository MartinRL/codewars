namespace codewars
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class StringArrayRevisalSolution
    {
        public static IEnumerable<string> RemoveConsecutiveDuplicateLettersFrom(IEnumerable<string> strings) => strings.Select(s => string.Concat(s.Distinct()));
    }

    public class StringArrayRevisalTests
    {
        [Theory]
        [InlineData(new[] {"ccooddddddewwwaaaaarrrrsssss", "piccaninny", "hubbubbubboo"}, new[] {"codewars", "picaniny", "hubububo"})]
        [InlineData(new[] {"kelless","voorraaddoosspullen","achcha"}, new[] {"keles", "voradospulen", "achcha"})]
        public void VerifyRemoveConsecutiveDuplicateLettersFromWith(IEnumerable<string> strings, IEnumerable<string> expectedStrings) => StringArrayRevisalSolution.RemoveConsecutiveDuplicateLettersFrom(strings).Should().Equal(expectedStrings);
    }
}
