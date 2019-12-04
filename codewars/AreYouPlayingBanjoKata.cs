namespace codewars
{
    using System.Globalization;
    using FluentAssertions;
    using Xunit;

    public class AreYouPlayingBanjoSolution
    {
        public static string AreYouPlayingBanjo(string name) => $"{name} {(name.StartsWith("R", true, CultureInfo.InvariantCulture) ? "plays" : "does not play")} banjo";
    }

    public class AreYouPlayingBanjoTests
    {
        [Theory]
        [InlineData("Martin", "Martin does not play banjo")]
        [InlineData("Rikke", "Rikke plays banjo")]
        [InlineData("rolle", "rolle plays banjo")]
        [InlineData("Conny", "Conny does not play banjo")]
        public static void VerifyAreYouPlayingBanjoWith(string name, string playsBanjo) => AreYouPlayingBanjoSolution.AreYouPlayingBanjo(name).Should().Be(playsBanjo);
    }
}
