namespace codewars;

using static System.String;
using static System.UInt64;

public class CreatePhoneNumberSolution
{
    public static string CreatePhoneNumber(int[] numbers) => $"{Parse(Join(Empty, numbers)):(000) 000-0000}";
}

public class CreatePhoneNumberTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, "(123) 456-7890")]
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, "(111) 111-1111")]
    public void VerifyCreatePhoneNumberWith(int[] numbers, string expectedPhoneNumber) =>
        CreatePhoneNumberSolution.CreatePhoneNumber(numbers).Should().Be(expectedPhoneNumber);

    [Fact]
    public Task VerifyCreatePhoneNumber() => Verify(CreatePhoneNumberSolution.CreatePhoneNumber([1, 2, 3, 4, 5, 6, 7, 8, 9, 0]));

    [Fact]
    public Task VerifyCreatePhoneNumber2() => Verify(CreatePhoneNumberSolution.CreatePhoneNumber([1, 1, 1, 1, 1, 1, 1, 1, 1, 1]));

}

