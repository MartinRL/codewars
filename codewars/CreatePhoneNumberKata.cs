namespace codewars;

public class Kata
{
    public static string CreatePhoneNumber(int[] numbers) =>
        numbers.Aggregate("(", (result, number) =>
        {
            result += number;
            if (result.Length == 4) result += ") ";
            else if (result.Length == 9) result += "-";

            return result;
        });
}

public class CreatePhoneNumberTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, "(123) 456-7890")]
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, "(111) 111-1111")]
    public void VerifyCreatePhoneNumberWith(int[] numbers, string expectedPhoneNumber) => Kata.CreatePhoneNumber(numbers).Should().Be(expectedPhoneNumber);
}

