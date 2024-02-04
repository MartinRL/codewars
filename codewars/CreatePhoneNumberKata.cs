namespace codewars;

using static System.Convert;

public class Kata
{
    public static string CreatePhoneNumber(int[] numbers)
    {
        // Use a seed value of "(" and a result selector of adding ")"
        return numbers.Aggregate("(", (result, number) =>
        {
            // Add the number as a char to the result
            result += (char)(number + 48);
            // Add a ")" after the third number, a " " after the fourth, and a "-" after the sixth
            if (result.Length == 4) result += ") ";
            else if (result.Length == 5) result += " ";
            else if (result.Length == 9) result += "-";
            // Return the updated result
            return result;
        }, result => result);
    }
}

public class CreatePhoneNumberTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, "(123) 456-7890")]
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, "(111) 111-1111")]
    public void VerifyCreatePhoneNumberWith(int[] numbers, string expectedPhoneNumber) => Kata.CreatePhoneNumber(numbers).Should().Be(expectedPhoneNumber);
}

