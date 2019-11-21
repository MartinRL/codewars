using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using static System.Linq.Enumerable;
using static System.String;
using static System.Text.RegularExpressions.Regex;

namespace codewars
{
    public class NewCashierDoesNotKnowAboutSpaceOrShiftSolution
    {
        public static string GetOrder(string input) =>
            new[]
            {
                "Burger",
                "Fries",
                "Chicken",
                "Pizza",
                "Sandwich",
                "Onionrings",
                "Milkshake",
                "Coke"
            }
            .Aggregate((result, item) => $"{result} {Concat(Repeat($"{item} ", Matches(input, item.ToLower()).Count))}".Trim());
    }

    public class NewCashierDoesNotKnowAboutSpaceOrShiftTests
    {
        [Theory]
        [InlineData("milkshakepizzachickenfriescokeburgerpizzasandwichmilkshakepizza", "Burger Fries Chicken Pizza Pizza Pizza Sandwich Milkshake Milkshake Coke")]
        [InlineData("pizzachickenfriesburgercokemilkshakefriessandwich", "Burger Fries Fries Chicken Pizza Sandwich Milkshake Coke")]
        public void VerifyGetOrderWith(string input, string expectedOrder) => NewCashierDoesNotKnowAboutSpaceOrShiftSolution.GetOrder(input).Should().Be(expectedOrder);
    }
}
