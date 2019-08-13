using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class NewCashierDoesNotKnowAboutSpaceOrShiftSolution
    {
        public static string GetOrder(string input)
        {
            throw new NotImplementedException();
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
