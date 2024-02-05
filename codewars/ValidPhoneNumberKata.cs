namespace codewars;

using static System.Text.RegularExpressions.Regex;

public static class ValidPhoneNumberSolution
{
    public static bool ValidPhoneNumber(string phoneNumber) => IsMatch(phoneNumber, @"^\(\d{3}\) \d{3}-\d{4}$");
}

public class ValidPhoneNumberTests
{
    [Theory]
    [InlineData("(123) 456-7890", true)]
    [InlineData("(1111)5X5 2345", false)]
    public void VerifyValidPhoneNumberWith(string phoneNumber, bool expectedValidity) =>
        ValidPhoneNumberSolution.ValidPhoneNumber(phoneNumber).Should().Be(expectedValidity);
}
