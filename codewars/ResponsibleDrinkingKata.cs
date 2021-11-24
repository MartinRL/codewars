namespace codewars;

using System;
using System.Linq;
using static System.Char;
using static System.String;
using FluentAssertions;
using Xunit;

public class Drinkin
{
    public string Hydrate(string drinks)
    {
        var noOfDrinks = drinks.Where(IsDigit).Select(GetNumericValue).Sum();

        return $"{noOfDrinks} glass{(noOfDrinks > 1 ? "es" : Empty)} of water";
    }
}

public class ResponsibleDrinkingTests
{
    [Theory]
    [InlineData("1 beer", "1 glass of water")]
    [InlineData("1 shot, 5 beers, 2 shots, 1 glass of wine, 1 beer", "10 glasses of water")]
    public void VerifyHydrateWith(string drinks, string expectedHydration) => new Drinkin().Hydrate(drinks).Should().Be(expectedHydration);
}