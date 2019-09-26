using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class WhoLikesItSolution
    {
        public static string Likes(string[] name)
        {
            throw new NotImplementedException();
        }
    }

    public class WhoLikesItTests
    {
        [Theory]
        [InlineData(new string[0], "no one likes this")]
        [InlineData(new[] {"Peter"}, "Peter likes this")]
        [InlineData(new[] {"Jacob", "Alex"}, "Jacob and Alex like this")]
        [InlineData(new[] {"Max", "John", "Mark"}, "Max, John and Mark like this")]
        [InlineData(new[] {"Alex", "Jacob", "Mark", "Max"}, "Alex, Jacob and 2 others like this")]
        public void VerifyLikesWith(string[] name, string expectedLikes)
        {
            WhoLikesItSolution.Likes(name).Should().Be(expectedLikes);
        }
    }
}
