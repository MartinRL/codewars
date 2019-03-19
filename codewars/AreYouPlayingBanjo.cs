using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class AreYouPlayingBanjoKata
    {
        public static string AreYouPlayingBanjo(string name)
        {
            return char.ToLower(name.First()) == 'r' ? name + " plays banjo" : name + " does not play banjo";
        }
    }
    
    public class AreYouPlayingBanjoTests
    {
        [Theory]
        [InlineData("Martin", "Martin does not play banjo")]
        [InlineData("Rikke", "Rikke plays banjo")]
        [InlineData("rolle", "rolle plays banjo")]
        [InlineData("Conny", "Conny does not play banjo")]
        public static void ExecuteAreYouPlayingBanjo(string name, string playsBanjo)
        {
            AreYouPlayingBanjoKata.AreYouPlayingBanjo(name).Should().Be(playsBanjo);
        }
    }
}
