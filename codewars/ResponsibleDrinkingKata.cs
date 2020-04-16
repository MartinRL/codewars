namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class Drinkin
    {
        public string Hydrate(string drinks) => $"{drinks.Where(char.IsDigit).Select(d => int.Parse(d.ToString())).Sum().ToString()} glasses of water";
    }

    public class ResponsibleDrinkingTests
    {
        [Theory]
        [InlineData("1 beer", "1 glass of water")]
        [InlineData("1 shot, 5 beers, 2 shots, 1 glass of wine, 1 beer", "10 glasses of water")]
        public void VerifyHydrateWith(string drinks, string expectedHydration) => new Drinkin().Hydrate(drinks).Should().Be(expectedHydration);
    }
}
