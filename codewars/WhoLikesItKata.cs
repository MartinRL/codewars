using FluentAssertions;
using Xunit;

namespace codewars
{
    public class WhoLikesItSolution
    {
        public static string Likes(string[] name)
        {
            switch (name.Length)
            {
                case 0:
                    return "no one likes this";
                
                case 1:
                    return $"{name[0]} likes this";
                    
                case 2:
                    return $"{name[0]} and {name[1]} like this";
                    
                case 3:
                    return $"{name[0]}, {name[1]} and {name[2]} like this";
                    
                default:
                    return $"{name[0]}, {name[1]} and {name.Length - 2} others like this";
            }
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
        public void VerifyLikesWith(string[] name, string expectedLikes) => WhoLikesItSolution.Likes(name).Should().Be(expectedLikes);
    }
}
