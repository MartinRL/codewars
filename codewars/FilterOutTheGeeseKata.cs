namespace codewars;

using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

public class FilterOutTheGeeseSolution
{
    public static IEnumerable<string> GooseFilter(IEnumerable<string> birds)
    {
        var geese = new[] {"African", "Roman Tufted", "Toulouse", "Pilgrim", "Steinbacher"};

        return birds.Except(geese);
    }
}

public class FilterOutTheGeeseTests
{
    [Theory]
    [InlineData(new[] {"Mallard", "Hook Bill", "African", "Crested", "Pilgrim", "Toulouse", "Blue Swedish"},
        new[] {"Mallard", "Hook Bill", "Crested", "Blue Swedish"})]
    [InlineData(new[] {"Mallard", "Barbary", "Hook Bill", "Blue Swedish", "Crested"},
        new[] {"Mallard", "Barbary", "Hook Bill", "Blue Swedish", "Crested"})]
    [InlineData(new[] {"African", "Roman Tufted", "Toulouse", "Pilgrim", "Steinbacher"},
        new string[] { })]
    public void VerifyGooseFilter(IEnumerable<string> birds, IEnumerable<string> expectedBirdsWithoutGeese) =>
        FilterOutTheGeeseSolution.GooseFilter(birds).Should().BeEquivalentTo(expectedBirdsWithoutGeese);
}