namespace codewars
{
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class LoveVsFriendshipSolution
    {
        public static int WordsToMarks(string str) => str.Sum(_ => _ - 96);
    }

    public class LoveVsFriendshipTests
    {
        [Theory]
        [InlineData("attitude", 100)]
        [InlineData("love", 54)]
        [InlineData("friendship", 108)]
        public void VerifyWordsToMarksWith(string str, int expectedMarks) => LoveVsFriendshipSolution.WordsToMarks(str).Should().Be(expectedMarks);
    }
}
