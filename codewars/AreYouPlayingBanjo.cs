using System;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class AreYouPlayingBanjoKata
    {
        public static string AreYouPlayingBanjo(string name)
        {
            throw new NotImplementedException();
        }
    }
    
    public class AreYouPlayingBanjoTests
    {
        [Theory]
        [InlineData("Martin", "Martin does not play banjo")]
        [InlineData("Rikke", "Rikke plays banjo")]
        public static void ExecuteAreYouPlayingBanjo(string name, string playsBanjo)
        {
            AreYouPlayingBanjoKata.AreYouPlayingBanjo(name).Should().Be(playsBanjo);
        }
    }
}
