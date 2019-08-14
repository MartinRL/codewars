using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using static System.Array;

namespace codewars
{
    public class NewCashierDoesNotKnowAboutSpaceOrShiftSolution
    {
        public static string GetOrder(string input)
        {
            var formattedMenuItems = input;
            
            var menuItems = new[]
            {
                "burger",
                "fries",
                "chicken",
                "pizza",
                "sandwich",
                "onionrings",
                "milkshake",
                "coke"
            };

            menuItems.Each(menuItem => formattedMenuItems = formattedMenuItems.Replace(menuItem, $"{menuItem},"));

            return formattedMenuItems
                .Remove(formattedMenuItems.Length - 1)
                .Split(',')
                .OrderBy(_ => IndexOf(menuItems, _))
                .Select(_ => _.First().ToString().ToUpper() + _.Substring(1))
                .Aggregate((r, _) => $"{r} {_}");
        }
    }

    public class NewCashierDoesNotKnowAboutSpaceOrShiftTests
    {
        [Theory]
        [InlineData("milkshakepizzachickenfriescokeburgerpizzasandwichmilkshakepizza", "Burger Fries Chicken Pizza Pizza Pizza Sandwich Milkshake Milkshake Coke")]
        [InlineData("pizzachickenfriesburgercokemilkshakefriessandwich", "Burger Fries Fries Chicken Pizza Sandwich Milkshake Coke")]
        public void VerifyGetOrderWith(string input, string expectedOrder)
        {
            NewCashierDoesNotKnowAboutSpaceOrShiftSolution.GetOrder(input).Should().Be(expectedOrder);
        }
    }
}
