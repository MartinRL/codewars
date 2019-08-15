using System;
using System.Linq;
using System.Text.RegularExpressions;
using FluentAssertions;
using Xunit;
using static System.Linq.Enumerable;
using static System.Text.RegularExpressions.Regex;

namespace codewars
{
    public class NewCashierDoesNotKnowAboutSpaceOrShiftSolution
    {
        public static string GetOrder(string input)
        {
            var menu = new[]
            {
                "Burger",
                "Fries",
                "Chicken",
                "Pizza",
                "Sandwich",
                "Onionrings",
                "Milkshake",
                "Coke"
            };
            
            var result = string.Empty;
            
            menu.Each(item => result += string.Concat(Repeat($"{item} ", Matches(input, item.ToLower()).Count)));

            return result.Trim();
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
