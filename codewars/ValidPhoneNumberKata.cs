namespace codewars;

public static class Kata
{
    public static bool ValidPhoneNumber(string phoneNumber)
    {
        throw new NotImplementedException();
    }
}

public class ValidPhoneNumberTests
{
    [Theory]
    [InlineData("(123) 456-7890", true)]
    [InlineData("(1111)5X5 2345", false)]
    public void VerifyValidPhoneNumberWith(string phoneNumber, bool expectedValidity) =>
        Kata.ValidPhoneNumber(phoneNumber).Should().Be(expectedValidity);
}
