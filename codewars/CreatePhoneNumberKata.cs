namespace codewars;

using static System.Convert;

public class Kata
{
    public static string CreatePhoneNumber(int[] numbers)
    {
        var numbersAsChars = numbers.Select(_ => ToChar(_ + 48));
        var areaCode = new string(numbersAsChars.Take(3).ToArray());
        var phoneNumber1 = new string(numbersAsChars.Skip(areaCode.Length).Take(3).ToArray());
        string phoneNumber2 = new string(numbersAsChars.Skip(areaCode.Length + phoneNumber1.Length).Take(4).ToArray());

        return $"({areaCode}) {phoneNumber1}-{phoneNumber2}";
    }
}

public class CreatePhoneNumberTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, "(123) 456-7890")]
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, "(111) 111-1111")]
    public void VerifyCreatePhoneNumberWith(int[] numbers, string expectedPhoneNumber) => Kata.CreatePhoneNumber(numbers).Should().Be(expectedPhoneNumber);
}

